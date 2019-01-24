using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x020001AC RID: 428
public class CreditBundlesShopGui
{
	// Token: 0x06000BC3 RID: 3011 RVA: 0x0004D00C File Offset: 0x0004B20C
	public void Draw(Rect position)
	{
		float height = Mathf.Max(position.height, (float)this.scrollHeight);
		this.bundleScroll = GUI.BeginScrollView(position, this.bundleScroll, new Rect(0f, 0f, position.width - 17f, height), false, true);
		List<BundleUnityView> creditBundles = Singleton<BundleManager>.Instance.GetCreditBundles();
		if (creditBundles.Count == 0)
		{
			GUI.Label(new Rect(4f, 4f, position.width - 20f, 24f), "No credit packs are currently on sale.", BlueStonez.label_interparkbold_16pt);
		}
		else
		{
			int num = 4;
			int num2 = 0;
			List<string> list = new List<string>();
			GUI.Label(new Rect(4f, (float)(num + 4), position.width - 20f, 20f), "Credit Packs", BlueStonez.label_interparkbold_18pt_left);
			num += 30;
			foreach (BundleUnityView bundleUnityView in creditBundles)
			{
				int num3 = (num2 % 2 != 1) ? 0 : 187;
				if ((float)num < position.height && num + 95 > 0)
				{
					this.DrawPackSlot(new Rect((float)num3, (float)num, 188f, 95f), bundleUnityView);
					list.Add(bundleUnityView.BundleView.IconUrl);
				}
				num += ((num2 % 2 != 1) ? 0 : 94);
				num2++;
			}
			if (num2 % 2 == 1)
			{
				num += 94;
			}
			GUI.Label(new Rect(4f, (float)num, position.width - 8f, 1f), GUIContent.none, BlueStonez.horizontal_line_grey95);
			this.scrollHeight = num;
		}
		GUI.EndScrollView();
	}

	// Token: 0x06000BC4 RID: 3012 RVA: 0x0004D1E8 File Offset: 0x0004B3E8
	private void DrawPackSlot(Rect position, BundleUnityView bundleUnityView)
	{
		int id = bundleUnityView.BundleView.Id;
		bool flag = position.Contains(Event.current.mousePosition);
		if (!this._alpha.ContainsKey(id))
		{
			this._alpha[id] = 0f;
		}
		this._alpha[id] = Mathf.Lerp(this._alpha[id], (float)((!flag) ? 0 : 1), Time.deltaTime * (float)((!flag) ? 10 : 3));
		GUI.BeginGroup(position);
		GUI.Label(new Rect(2f, 2f, position.width - 4f, 79f), GUIContent.none, BlueStonez.gray_background);
		bundleUnityView.Icon.Draw(new Rect(4f, 4f, 75f, 75f), false);
		GUI.Label(new Rect(81f, 0f, position.width - 80f, 44f), bundleUnityView.BundleView.Name, BlueStonez.label_interparkbold_13pt_left);
		GUI.enabled = GUITools.SaveClickIn(1f);
		this.BuyButton(position, bundleUnityView);
		GUI.enabled = true;
		GUI.EndGroup();
	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x0004D328 File Offset: 0x0004B528
	private void BuyButton(Rect position, BundleUnityView bundleUnityView)
	{
		if (GUI.Button(new Rect(81f, 51f, position.width - 110f, 20f), new GUIContent(bundleUnityView.CurrencySymbol + bundleUnityView.Price, "Buy the " + bundleUnityView.BundleView.Name + " pack."), BlueStonez.buttongold_medium))
		{
			GUITools.Clicked();
			if (ApplicationDataManager.Channel == ChannelType.Steam)
			{
				Singleton<BundleManager>.Instance.BuyBundle(bundleUnityView);
			}
			else
			{
				PopupSystem.ClearAll();
				PopupSystem.ShowMessage("Purchase Failed", "Sorry, only Steam players can purchase credit bundles.", PopupSystem.AlertType.OK);
			}
		}
	}

	// Token: 0x04000B38 RID: 2872
	private Vector2 bundleScroll = Vector2.zero;

	// Token: 0x04000B39 RID: 2873
	private int scrollHeight;

	// Token: 0x04000B3A RID: 2874
	private Dictionary<int, float> _alpha = new Dictionary<int, float>();
}
