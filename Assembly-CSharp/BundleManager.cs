using System;
using System.Collections;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using Steamworks;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x0200029F RID: 671
public class BundleManager : Singleton<BundleManager>
{
	// Token: 0x06001289 RID: 4745 RVA: 0x0000CBF8 File Offset: 0x0000ADF8
	private BundleManager()
	{
		this._bundlesPerCategory = new Dictionary<BundleCategoryType, List<BundleUnityView>>();
	}

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x0600128A RID: 4746 RVA: 0x0000CC0B File Offset: 0x0000AE0B
	// (set) Token: 0x0600128B RID: 4747 RVA: 0x0000CC13 File Offset: 0x0000AE13
	public int Count { get; private set; }

	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x0600128C RID: 4748 RVA: 0x0000CC1C File Offset: 0x0000AE1C
	// (set) Token: 0x0600128D RID: 4749 RVA: 0x0000CC24 File Offset: 0x0000AE24
	public bool CanMakeMasPayments { get; private set; }

	// Token: 0x0600128E RID: 4750 RVA: 0x0006E744 File Offset: 0x0006C944
	private void OnMicroTxnCallback(MicroTxnAuthorizationResponse_t param)
	{
		Debug.Log("Steam MicroTxnParams: " + param);
		if (param.m_bAuthorized > 0)
		{
			ShopWebServiceClient.FinishBuyBundleSteam(param.m_ulOrderID.ToString(), delegate(bool success)
			{
				if (success)
				{
					PopupSystem.ClearAll();
					PopupSystem.ShowMessage("Purchase Successful", "Thank you, your purchase was successful.", PopupSystem.AlertType.OK, delegate()
					{
						ApplicationDataManager.RefreshWallet();
					});
				}
				else
				{
					Debug.Log("Managed error from WebServices");
					PopupSystem.ClearAll();
					PopupSystem.ShowMessage("Purchase Failed", "Sorry, there was a problem processing your payment. Please visit support.uberstrike.com for help.", PopupSystem.AlertType.OK);
				}
			}, delegate(Exception ex)
			{
				Debug.Log(ex.Message);
				PopupSystem.ClearAll();
				PopupSystem.ShowMessage("Purchase Failed", "Sorry, there was a problem processing your payment. Please visit support.uberstrike.com for help.", PopupSystem.AlertType.OK);
			});
		}
		else
		{
			Debug.Log("Purchase canceled");
			PopupSystem.ClearAll();
		}
	}

	// Token: 0x0600128F RID: 4751 RVA: 0x0006E7D4 File Offset: 0x0006C9D4
	public List<BundleUnityView> GetCreditBundles()
	{
		List<BundleUnityView> result = new List<BundleUnityView>();
		this._bundlesPerCategory.TryGetValue(BundleCategoryType.None, out result);
		return result;
	}

	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x06001290 RID: 4752 RVA: 0x0006E7F8 File Offset: 0x0006C9F8
	public IEnumerable<BundleUnityView> AllItemBundles
	{
		get
		{
			foreach (KeyValuePair<BundleCategoryType, List<BundleUnityView>> category in this._bundlesPerCategory)
			{
				if (category.Key != BundleCategoryType.None)
				{
					foreach (BundleUnityView box in category.Value)
					{
						yield return box;
					}
				}
			}
			yield break;
		}
	}

	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x06001291 RID: 4753 RVA: 0x0006E81C File Offset: 0x0006CA1C
	public IEnumerable<BundleUnityView> AllBundles
	{
		get
		{
			foreach (List<BundleUnityView> bundleUnityViews in this._bundlesPerCategory.Values)
			{
				foreach (BundleUnityView bundleUnityView in bundleUnityViews)
				{
					yield return bundleUnityView;
				}
			}
			yield break;
		}
	}

	// Token: 0x06001292 RID: 4754 RVA: 0x0006E840 File Offset: 0x0006CA40
	public void Initialize()
	{
		this.MicroTxnCallback = Callback<MicroTxnAuthorizationResponse_t>.Create(new Callback<MicroTxnAuthorizationResponse_t>.DispatchDelegate(this.OnMicroTxnCallback));
		ShopWebServiceClient.GetBundles(ApplicationDataManager.Channel, delegate(List<BundleView> bundles)
		{
			this.SetBundles(bundles);
		}, delegate(Exception exception)
		{
			Debug.LogError("Error getting " + ApplicationDataManager.Channel + " bundles from the server.");
		});
	}

	// Token: 0x06001293 RID: 4755 RVA: 0x0006E898 File Offset: 0x0006CA98
	private void SetBundles(List<BundleView> bundleViews)
	{
		if (bundleViews != null && bundleViews.Count > 0)
		{
			foreach (BundleView bundleView in bundleViews)
			{
				List<BundleUnityView> list;
				if (!this._bundlesPerCategory.TryGetValue(bundleView.Category, out list))
				{
					list = new List<BundleUnityView>();
					this._bundlesPerCategory[bundleView.Category] = list;
				}
				list.Add(new BundleUnityView(bundleView));
			}
			this.Count = 0;
			foreach (BundleUnityView bundleUnityView in this.AllBundles)
			{
				bundleUnityView.CurrencySymbol = "$";
				bundleUnityView.Price = bundleUnityView.BundleView.USDPrice.ToString("N2");
				bundleUnityView.IsOwned = false;
				this.Count++;
			}
		}
		else
		{
			Debug.LogError("SetBundles: Bundles received from the server were null or empty!");
		}
	}

	// Token: 0x06001294 RID: 4756 RVA: 0x0006E9D0 File Offset: 0x0006CBD0
	public IEnumerator StartCancelDialogTimer()
	{
		if (this.dialogTimer < 5f)
		{
			this.dialogTimer = 5f;
		}
		while (this._appStorePopup != null && this.dialogTimer > 0f)
		{
			this.dialogTimer -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		if (this._appStorePopup != null)
		{
			this._appStorePopup.SetAlertType(PopupSystem.AlertType.Cancel);
		}
		yield break;
	}

	// Token: 0x06001295 RID: 4757 RVA: 0x0006E9EC File Offset: 0x0006CBEC
	public void BuyBundle(BundleUnityView bundle)
	{
		Debug.Log("Trying to buy bundle with id id: " + bundle.BundleView.Id.ToString());
		int id = bundle.BundleView.Id;
		string steamId = PlayerDataManager.SteamId;
		string authToken = PlayerDataManager.AuthToken;
		ShopWebServiceClient.BuyBundleSteam(id, steamId, authToken, delegate(bool success)
		{
			if (!success)
			{
				Debug.Log("Starting steam payment failed! (Handled WS Error)");
				PopupSystem.ClearAll();
				PopupSystem.ShowMessage("Purchase Failed", "Sorry, there was a problem processing your payment. Please visit support.uberstrike.com for help.", PopupSystem.AlertType.OK);
			}
		}, delegate(Exception ex)
		{
			Debug.Log(ex.Message);
			PopupSystem.ClearAll();
			PopupSystem.ShowMessage("Purchase Failed", "Sorry, there was a problem processing your payment. Please visit support.uberstrike.com for help.", PopupSystem.AlertType.OK);
		});
		this._appStorePopup = (PopupSystem.ShowMessage("In App Purchase", "Purchasing, please wait...", PopupSystem.AlertType.None) as BasePopupDialog);
		UnityRuntime.StartRoutine(this.StartCancelDialogTimer());
	}

	// Token: 0x06001296 RID: 4758 RVA: 0x0006EAA0 File Offset: 0x0006CCA0
	private bool IsItemPackOwned(List<BundleItemView> items)
	{
		if (items.Count > 0)
		{
			foreach (BundleItemView bundleItemView in items)
			{
				if (!Singleton<InventoryManager>.Instance.Contains(bundleItemView.ItemId))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06001297 RID: 4759 RVA: 0x0006EB1C File Offset: 0x0006CD1C
	public BundleUnityView GetNextItem(BundleUnityView currentItem)
	{
		List<BundleUnityView> list = new List<BundleUnityView>(this.AllItemBundles);
		if (list.Count <= 0)
		{
			return currentItem;
		}
		int num = list.FindIndex((BundleUnityView i) => i == currentItem);
		if (num < 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		int index = (num + 1) % list.Count;
		return list[index];
	}

	// Token: 0x06001298 RID: 4760 RVA: 0x0006EB94 File Offset: 0x0006CD94
	public BundleUnityView GetPreviousItem(BundleUnityView currentItem)
	{
		List<BundleUnityView> list = new List<BundleUnityView>(this.AllItemBundles);
		if (list.Count <= 0)
		{
			return currentItem;
		}
		int num = list.FindIndex((BundleUnityView i) => i == currentItem);
		if (num < 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		int index = (num - 1 + list.Count) % list.Count;
		return list[index];
	}

	// Token: 0x040012B4 RID: 4788
	private BasePopupDialog _appStorePopup;

	// Token: 0x040012B5 RID: 4789
	private Dictionary<BundleCategoryType, List<BundleUnityView>> _bundlesPerCategory;

	// Token: 0x040012B6 RID: 4790
	private Callback<MicroTxnAuthorizationResponse_t> MicroTxnCallback;

	// Token: 0x040012B7 RID: 4791
	private float dialogTimer;
}
