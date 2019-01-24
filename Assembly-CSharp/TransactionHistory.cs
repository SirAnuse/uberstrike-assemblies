using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.ViewModel;
using UberStrike.Realtime.UnitySdk;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020001BB RID: 443
public class TransactionHistory : Singleton<TransactionHistory>
{
	// Token: 0x06000C46 RID: 3142 RVA: 0x0005263C File Offset: 0x0005083C
	private TransactionHistory()
	{
		this._itemTransactions = new TransactionHistory.TransactionCache<ItemTransactionsViewModel>();
		this._pointTransactions = new TransactionHistory.TransactionCache<PointDepositsViewModel>();
		this._creditTransactions = new TransactionHistory.TransactionCache<CurrencyDepositsViewModel>();
		this._tabs = new GUIContent[]
		{
			new GUIContent("Items"),
			new GUIContent("Points"),
			new GUIContent("Credits")
		};
		this._itemsTableColumnHeadingArray = new string[]
		{
			"Date",
			"Item Name",
			"Points",
			"Credits",
			"Duration"
		};
		this._pointsTableColumnHeadingArray = new string[]
		{
			"Date",
			"Points",
			"Type"
		};
		this._creditsTableColumnHeadingArray = new string[]
		{
			"Transaction Key",
			"Date",
			"Cost",
			"Credits",
			"Points",
			"Bundle Name"
		};
		this._prevPageButtonLabel = "Prev Page";
		this._nextPageButtonLabel = "Next Page";
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x00052750 File Offset: 0x00050950
	public void DrawPanel(Rect panelRect)
	{
		GUI.BeginGroup(panelRect, GUIContent.none, BlueStonez.window_standard_grey38);
		this.DrawTabs(new Rect(2f, 5f, panelRect.width - 4f, 30f));
		this.DrawTable(new Rect(2f, 35f, panelRect.width - 4f, panelRect.height - 35f));
		GUI.EndGroup();
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x000527C8 File Offset: 0x000509C8
	private void DrawTable(Rect panelRect)
	{
		Rect headingRect = new Rect(panelRect.x + 5f, panelRect.y, panelRect.width - 10f, 25f);
		Rect scrollViewRect = new Rect(panelRect.x + 5f, panelRect.y + 30f, panelRect.width - 10f, panelRect.height - 35f - 32f - 5f);
		Rect rect = new Rect(0f, scrollViewRect.y + scrollViewRect.height, panelRect.width, panelRect.height - scrollViewRect.height);
		TransactionHistory.TransactionType selectedTab = (TransactionHistory.TransactionType)this._selectedTab;
		if (selectedTab == TransactionHistory.TransactionType.Item)
		{
			this.DrawItemsTableHeadingBar(headingRect);
			this.DrawItemsTableContent(scrollViewRect);
			this.DrawItemsButtons(rect);
		}
		else if (selectedTab == TransactionHistory.TransactionType.Point)
		{
			this.DrawPointsTableHeadingBar(headingRect);
			this.DrawPointsTableContent(scrollViewRect);
			this.DrawPointsButtons(rect);
		}
		else if (selectedTab == TransactionHistory.TransactionType.Credit)
		{
			this.DrawCreditsTableHeadingBar(headingRect);
			this.DrawCreditsTableContent(scrollViewRect);
			this.DrawCreditsButtons(rect);
		}
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x000528E0 File Offset: 0x00050AE0
	private void DrawTabs(Rect tabRect)
	{
		int num = UnityGUI.Toolbar(tabRect, this._selectedTab, this._tabs, this._tabs.Length, BlueStonez.tab_medium);
		if (num != this._selectedTab)
		{
			this._selectedTab = num;
			this.GetCurrentTransactions();
		}
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x00052928 File Offset: 0x00050B28
	private float GetColumnOffset(TransactionHistory.AccountArea area, int index, float totalWidth)
	{
		if (area == TransactionHistory.AccountArea.Items)
		{
			switch (index)
			{
			case 0:
				return 0f;
			case 1:
				return 100f;
			case 2:
				return 100f + Mathf.Max(totalWidth, 400f) - 300f;
			case 3:
				return 100f + Mathf.Max(totalWidth, 400f) - 300f + 50f;
			case 4:
				return 100f + Mathf.Max(totalWidth, 400f) - 300f + 50f + 50f;
			default:
				return 0f;
			}
		}
		else
		{
			if (area == TransactionHistory.AccountArea.Points)
			{
				return (float)(index * Mathf.RoundToInt(totalWidth / 3f));
			}
			if (area != TransactionHistory.AccountArea.Credits)
			{
				return 0f;
			}
			switch (index)
			{
			case 0:
				return 0f;
			case 1:
				return 150f;
			case 2:
				return 220f;
			case 3:
				return 270f;
			case 4:
				return 320f;
			case 5:
				return 370f;
			default:
				return 0f;
			}
		}
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x00052A3C File Offset: 0x00050C3C
	private float GetColumnWidth(TransactionHistory.AccountArea area, int index, float totalWidth)
	{
		if (area == TransactionHistory.AccountArea.Items)
		{
			switch (index)
			{
			case 0:
				return 151f;
			case 1:
				return Mathf.Max(totalWidth, 400f) - 300f + 1f;
			case 2:
				return 51f;
			case 3:
				return 51f;
			case 4:
				return 100f;
			default:
				return 0f;
			}
		}
		else if (area == TransactionHistory.AccountArea.Points)
		{
			switch (index)
			{
			case 0:
				return (float)(Mathf.RoundToInt(totalWidth / 3f) + 1);
			case 1:
				return (float)(Mathf.RoundToInt(totalWidth / 3f) + 1);
			case 2:
				return (float)Mathf.RoundToInt(totalWidth / 3f);
			default:
				return 0f;
			}
		}
		else
		{
			if (area != TransactionHistory.AccountArea.Credits)
			{
				return 0f;
			}
			switch (index)
			{
			case 0:
				return 151f;
			case 1:
				return 71f;
			case 2:
				return 51f;
			case 3:
				return 51f;
			case 4:
				return 51f;
			case 5:
				return Mathf.Max(totalWidth, 450f) - 370f;
			default:
				return 0f;
			}
		}
	}

	// Token: 0x06000C4D RID: 3149 RVA: 0x00052B64 File Offset: 0x00050D64
	private void DrawItemsTableHeadingBar(Rect headingRect)
	{
		GUI.BeginGroup(headingRect);
		for (int i = 0; i < this._itemsTableColumnHeadingArray.Length; i++)
		{
			Rect position = new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Items, i, headingRect.width), 0f, this.GetColumnWidth(TransactionHistory.AccountArea.Items, i, headingRect.width), headingRect.height);
			GUI.Button(position, string.Empty, BlueStonez.box_grey50);
			GUI.Label(position, new GUIContent(this._itemsTableColumnHeadingArray[i]), BlueStonez.label_interparkmed_11pt);
		}
		GUI.EndGroup();
	}

	// Token: 0x06000C4E RID: 3150 RVA: 0x00052BF0 File Offset: 0x00050DF0
	private void DrawItemsTableContent(Rect scrollViewRect)
	{
		GUI.Box(scrollViewRect, GUIContent.none, BlueStonez.window_standard_grey38);
		if (this._itemTransactions.CurrentPage != null)
		{
			this._scrollControls = GUITools.BeginScrollView(scrollViewRect.Expand(0, -1), this._scrollControls, new Rect(0f, 0f, scrollViewRect.width - 17f, (float)this._itemTransactions.CurrentPage.ItemTransactions.Count * 23f), false, false, true);
			float num = 0f;
			foreach (ItemTransactionView itemTransactionView in this._itemTransactions.CurrentPage.ItemTransactions)
			{
				IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(itemTransactionView.ItemId);
				string text = (itemInShop == null) ? string.Format("item[{0}]", itemTransactionView.ItemId) : TextUtility.ShortenText(itemInShop.Name, 20, true);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Items, 0, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Items, 0, scrollViewRect.width), 23f), itemTransactionView.WithdrawalDate.ToString(TransactionHistory.DATE_FORMAT), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Items, 1, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Items, 1, scrollViewRect.width), 23f), text, BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Items, 2, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Items, 2, scrollViewRect.width), 23f), itemTransactionView.Points.ToString(), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Items, 3, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Items, 3, scrollViewRect.width), 23f), itemTransactionView.Credits.ToString(), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Items, 4, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Items, 4, scrollViewRect.width), 23f), ShopUtils.PrintDuration(itemTransactionView.Duration), BlueStonez.label_interparkmed_11pt);
				num += 23f;
			}
			GUITools.EndScrollView();
		}
	}

	// Token: 0x06000C4F RID: 3151 RVA: 0x00052E60 File Offset: 0x00051060
	private void DrawItemsButtons(Rect rect)
	{
		GUIStyle button = BlueStonez.button;
		GUI.enabled = (this._itemTransactions.CurrentPageIndex != 0);
		if (GUITools.Button(new Rect(rect.x + 6f, rect.y + 5f, 100f, 32f), new GUIContent(this._prevPageButtonLabel), button))
		{
			this._itemTransactions.CurrentPageIndex--;
			this.AsyncGetItemTransactions();
		}
		GUI.enabled = true;
		if (this._itemTransactions.ElementCount > 0)
		{
			GUI.Label(new Rect((rect.x + rect.width) / 2f - 100f, rect.y + 5f, 200f, 32f), string.Format("Page {0} of {1}", this._itemTransactions.CurrentPageIndex + 1, this._itemTransactions.PageCount), BlueStonez.label_interparkbold_11pt);
			GUI.enabled = (this._itemTransactions.CurrentPageIndex + 1 < this._itemTransactions.PageCount);
			if (GUITools.Button(new Rect(rect.x + rect.width - 100f - 2f, rect.y + 5f, 100f, 32f), new GUIContent(this._nextPageButtonLabel), button))
			{
				this._itemTransactions.CurrentPageIndex++;
				this.AsyncGetItemTransactions();
			}
			GUI.enabled = true;
		}
	}

	// Token: 0x06000C50 RID: 3152 RVA: 0x00052FF0 File Offset: 0x000511F0
	private void DrawPointsTableHeadingBar(Rect headingRect)
	{
		GUI.BeginGroup(headingRect);
		for (int i = 0; i < this._pointsTableColumnHeadingArray.Length; i++)
		{
			Rect position = new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Points, i, headingRect.width), 0f, this.GetColumnWidth(TransactionHistory.AccountArea.Points, i, headingRect.width), headingRect.height);
			GUI.Button(position, string.Empty, BlueStonez.box_grey50);
			GUI.Label(position, new GUIContent(this._pointsTableColumnHeadingArray[i]), BlueStonez.label_interparkmed_11pt);
		}
		GUI.EndGroup();
	}

	// Token: 0x06000C51 RID: 3153 RVA: 0x0005307C File Offset: 0x0005127C
	private void DrawPointsTableContent(Rect scrollViewRect)
	{
		GUI.Box(scrollViewRect, GUIContent.none, BlueStonez.window_standard_grey38);
		if (this._pointTransactions.CurrentPage != null)
		{
			this._scrollControls = GUITools.BeginScrollView(scrollViewRect.Expand(0, -1), this._scrollControls, new Rect(0f, 0f, scrollViewRect.width - 17f, (float)this._pointTransactions.CurrentPage.PointDeposits.Count * 23f), false, false, true);
			float num = 0f;
			foreach (PointDepositView pointDepositView in this._pointTransactions.CurrentPage.PointDeposits)
			{
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Points, 0, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Points, 0, scrollViewRect.width), 23f), pointDepositView.DepositDate.ToString(TransactionHistory.DATE_FORMAT), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Points, 1, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Points, 1, scrollViewRect.width), 23f), pointDepositView.Points.ToString(), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Points, 2, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Points, 2, scrollViewRect.width), 23f), pointDepositView.DepositType.ToString(), BlueStonez.label_interparkmed_11pt);
				num += 23f;
			}
			GUITools.EndScrollView();
		}
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x0005322C File Offset: 0x0005142C
	private void DrawPointsButtons(Rect rect)
	{
		GUIStyle button = BlueStonez.button;
		GUI.enabled = (this._pointTransactions.CurrentPageIndex != 0);
		if (GUITools.Button(new Rect(rect.x + 6f, rect.y + 5f, 100f, 32f), new GUIContent(this._prevPageButtonLabel), button))
		{
			this._pointTransactions.CurrentPageIndex--;
			this.AsyncGetPointsDeposits();
		}
		GUI.enabled = true;
		if (this._pointTransactions.ElementCount > 0)
		{
			GUI.Label(new Rect((rect.x + rect.width) / 2f - 100f, rect.y + 5f, 200f, 32f), string.Format("Page {0} of {1}", this._pointTransactions.CurrentPageIndex + 1, this._pointTransactions.PageCount), BlueStonez.label_interparkbold_11pt);
			GUI.enabled = (this._pointTransactions.CurrentPageIndex + 1 < this._pointTransactions.PageCount);
			if (GUITools.Button(new Rect(rect.x + rect.width - 100f - 2f, rect.y + 5f, 100f, 32f), new GUIContent(this._nextPageButtonLabel), button))
			{
				this._pointTransactions.CurrentPageIndex++;
				this.AsyncGetPointsDeposits();
			}
			GUI.enabled = true;
		}
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x000533BC File Offset: 0x000515BC
	private void DrawCreditsTableHeadingBar(Rect headingRect)
	{
		GUI.BeginGroup(headingRect);
		for (int i = 0; i < this._creditsTableColumnHeadingArray.Length; i++)
		{
			Rect position = new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Credits, i, headingRect.width), 0f, this.GetColumnWidth(TransactionHistory.AccountArea.Credits, i, headingRect.width), headingRect.height);
			GUI.Button(position, string.Empty, BlueStonez.box_grey50);
			GUI.Label(position, new GUIContent(this._creditsTableColumnHeadingArray[i]), BlueStonez.label_interparkmed_11pt);
		}
		GUI.EndGroup();
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x00053448 File Offset: 0x00051648
	private void DrawCreditsTableContent(Rect scrollViewRect)
	{
		GUI.Box(scrollViewRect, GUIContent.none, BlueStonez.window_standard_grey38);
		if (this._creditTransactions.CurrentPage != null)
		{
			this._scrollControls = GUITools.BeginScrollView(scrollViewRect.Expand(0, -1), this._scrollControls, new Rect(0f, 0f, scrollViewRect.width - 17f, (float)this._creditTransactions.CurrentPage.CurrencyDeposits.Count * 23f), false, false, true);
			float num = 0f;
			foreach (CurrencyDepositView currencyDepositView in this._creditTransactions.CurrentPage.CurrencyDeposits)
			{
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Credits, 0, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Credits, 0, scrollViewRect.width), 23f), TextUtility.ShortenText(currencyDepositView.TransactionKey, 20, true), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Credits, 1, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Credits, 1, scrollViewRect.width), 23f), currencyDepositView.DepositDate.ToString(TransactionHistory.DATE_FORMAT), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Credits, 2, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Credits, 2, scrollViewRect.width), 23f), currencyDepositView.CurrencyLabel + currencyDepositView.Cash.ToString("#0.00"), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Credits, 3, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Credits, 3, scrollViewRect.width), 23f), currencyDepositView.Credits.ToString(), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Credits, 4, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Credits, 4, scrollViewRect.width), 23f), currencyDepositView.Points.ToString(), BlueStonez.label_interparkmed_11pt);
				GUI.Label(new Rect(this.GetColumnOffset(TransactionHistory.AccountArea.Credits, 5, scrollViewRect.width), num, this.GetColumnWidth(TransactionHistory.AccountArea.Credits, 5, scrollViewRect.width), 23f), TextUtility.ShortenText(currencyDepositView.BundleName, 14, true), BlueStonez.label_interparkmed_11pt);
				num += 23f;
			}
			GUITools.EndScrollView();
		}
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x000536D8 File Offset: 0x000518D8
	private void DrawCreditsButtons(Rect rect)
	{
		GUIStyle button = BlueStonez.button;
		GUI.enabled = (this._creditTransactions.CurrentPageIndex != 0);
		if (GUITools.Button(new Rect(rect.x + 6f, rect.y + 5f, 100f, 32f), new GUIContent(this._prevPageButtonLabel), button))
		{
			this._creditTransactions.CurrentPageIndex--;
			this.AsyncGetCurrencyDeposits();
		}
		GUI.enabled = true;
		if (this._creditTransactions.ElementCount > 0)
		{
			GUI.Label(new Rect((rect.x + rect.width) / 2f - 100f, rect.y + 5f, 200f, 32f), string.Format("Page {0} of {1}", this._creditTransactions.CurrentPageIndex + 1, this._creditTransactions.PageCount), BlueStonez.label_interparkbold_11pt);
			GUI.enabled = (this._creditTransactions.CurrentPageIndex + 1 < this._creditTransactions.PageCount);
			if (GUITools.Button(new Rect(rect.x + rect.width - 100f - 2f, rect.y + 5f, 100f, 32f), new GUIContent(this._nextPageButtonLabel), button))
			{
				this._creditTransactions.CurrentPageIndex++;
				this.AsyncGetCurrencyDeposits();
			}
			GUI.enabled = true;
		}
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x00053868 File Offset: 0x00051A68
	private void AsyncGetItemTransactions()
	{
		if (this._itemTransactions.CurrentPageNeedsRefresh)
		{
			int nextPageIndex = this._itemTransactions.CurrentPageIndex;
			UserWebServiceClient.GetItemTransactions(PlayerDataManager.AuthToken, nextPageIndex + 1, 15, delegate(ItemTransactionsViewModel ev)
			{
				this._itemTransactions.SetPage(nextPageIndex, ev);
				this._itemTransactions.ElementCount = ev.TotalCount;
			}, delegate(Exception ex)
			{
			});
		}
	}

	// Token: 0x06000C57 RID: 3159 RVA: 0x000538E4 File Offset: 0x00051AE4
	private void AsyncGetCurrencyDeposits()
	{
		if (this._creditTransactions.CurrentPageNeedsRefresh)
		{
			int nextPageIndex = this._creditTransactions.CurrentPageIndex;
			UserWebServiceClient.GetCurrencyDeposits(PlayerDataManager.AuthToken, nextPageIndex + 1, 15, delegate(CurrencyDepositsViewModel ev)
			{
				this._creditTransactions.SetPage(nextPageIndex, ev);
				this._creditTransactions.ElementCount = ev.TotalCount;
			}, delegate(Exception ex)
			{
			});
		}
	}

	// Token: 0x06000C58 RID: 3160 RVA: 0x00053960 File Offset: 0x00051B60
	private void AsyncGetPointsDeposits()
	{
		if (this._pointTransactions.CurrentPageNeedsRefresh)
		{
			int nextPageIndex = this._pointTransactions.CurrentPageIndex;
			UserWebServiceClient.GetPointsDeposits(PlayerDataManager.AuthToken, nextPageIndex + 1, 15, delegate(PointDepositsViewModel ev)
			{
				this._pointTransactions.SetPage(nextPageIndex, ev);
				this._pointTransactions.ElementCount = ev.TotalCount;
			}, delegate(Exception ex)
			{
			});
		}
	}

	// Token: 0x06000C59 RID: 3161 RVA: 0x000539DC File Offset: 0x00051BDC
	public void GetCurrentTransactions()
	{
		switch (this._selectedTab)
		{
		case 0:
			this.AsyncGetItemTransactions();
			break;
		case 1:
			this.AsyncGetPointsDeposits();
			break;
		case 2:
			this.AsyncGetCurrencyDeposits();
			break;
		}
	}

	// Token: 0x04000B9E RID: 2974
	private const float RowHeight = 23f;

	// Token: 0x04000B9F RID: 2975
	private const float ButtonWidth = 100f;

	// Token: 0x04000BA0 RID: 2976
	private const float ButtonHeight = 32f;

	// Token: 0x04000BA1 RID: 2977
	private const int ElementsPerPage = 15;

	// Token: 0x04000BA2 RID: 2978
	private static string DATE_FORMAT = "yyyy/MM/dd";

	// Token: 0x04000BA3 RID: 2979
	private int _selectedTab;

	// Token: 0x04000BA4 RID: 2980
	private GUIContent[] _tabs;

	// Token: 0x04000BA5 RID: 2981
	private Vector2 _scrollControls;

	// Token: 0x04000BA6 RID: 2982
	private string[] _itemsTableColumnHeadingArray;

	// Token: 0x04000BA7 RID: 2983
	private string[] _pointsTableColumnHeadingArray;

	// Token: 0x04000BA8 RID: 2984
	private string[] _creditsTableColumnHeadingArray;

	// Token: 0x04000BA9 RID: 2985
	private string _prevPageButtonLabel;

	// Token: 0x04000BAA RID: 2986
	private string _nextPageButtonLabel;

	// Token: 0x04000BAB RID: 2987
	private TransactionHistory.TransactionCache<ItemTransactionsViewModel> _itemTransactions;

	// Token: 0x04000BAC RID: 2988
	private TransactionHistory.TransactionCache<PointDepositsViewModel> _pointTransactions;

	// Token: 0x04000BAD RID: 2989
	private TransactionHistory.TransactionCache<CurrencyDepositsViewModel> _creditTransactions;

	// Token: 0x020001BC RID: 444
	private enum TransactionType
	{
		// Token: 0x04000BB2 RID: 2994
		Item,
		// Token: 0x04000BB3 RID: 2995
		Point,
		// Token: 0x04000BB4 RID: 2996
		Credit
	}

	// Token: 0x020001BD RID: 445
	private enum AccountArea
	{
		// Token: 0x04000BB6 RID: 2998
		Items,
		// Token: 0x04000BB7 RID: 2999
		Points,
		// Token: 0x04000BB8 RID: 3000
		Credits
	}

	// Token: 0x020001BE RID: 446
	public class TransactionCache<T>
	{
		// Token: 0x06000C5D RID: 3165 RVA: 0x00009563 File Offset: 0x00007763
		public TransactionCache()
		{
			this.PageCache = new SortedList<int, T>();
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x00009576 File Offset: 0x00007776
		// (set) Token: 0x06000C5F RID: 3167 RVA: 0x0000957E File Offset: 0x0000777E
		public SortedList<int, T> PageCache { get; private set; }

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000C60 RID: 3168 RVA: 0x00009587 File Offset: 0x00007787
		// (set) Token: 0x06000C61 RID: 3169 RVA: 0x0000958F File Offset: 0x0000778F
		public int CurrentPageIndex { get; set; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000C62 RID: 3170 RVA: 0x00053A28 File Offset: 0x00051C28
		public T CurrentPage
		{
			get
			{
				if (this.PageCache.ContainsKey(this.CurrentPageIndex))
				{
					return this.PageCache[this.CurrentPageIndex];
				}
				return default(T);
			}
		}

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000C63 RID: 3171 RVA: 0x00053A68 File Offset: 0x00051C68
		public bool CurrentPageNeedsRefresh
		{
			get
			{
				return this.CurrentPage == null || (this.CurrentPageIndex > 0 && this.CurrentPageIndex == this.PageCount - 1 && this._refreshLastPage < Time.time);
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000C64 RID: 3172 RVA: 0x00009598 File Offset: 0x00007798
		// (set) Token: 0x06000C65 RID: 3173 RVA: 0x000095A0 File Offset: 0x000077A0
		public int ElementCount { get; set; }

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000C66 RID: 3174 RVA: 0x000095A9 File Offset: 0x000077A9
		public int PageCount
		{
			get
			{
				return Mathf.CeilToInt((float)(this.ElementCount / 15)) + 1;
			}
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x000095BC File Offset: 0x000077BC
		public void SetPage(int index, T page)
		{
			this.PageCache[index] = page;
			if (index + 1 == this.PageCount)
			{
				this._refreshLastPage = Time.time + 30f;
			}
		}

		// Token: 0x04000BB9 RID: 3001
		private float _refreshLastPage;
	}
}
