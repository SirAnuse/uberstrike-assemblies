using System;
using UnityEngine;

// Token: 0x020001E2 RID: 482
public class ItemBundlePopup : LotteryPopupDialog
{
	// Token: 0x06000D96 RID: 3478 RVA: 0x0005EADC File Offset: 0x0005CCDC
	public ItemBundlePopup(BundleUnityView bundleUnityView)
	{
		this._bundleUnityView = bundleUnityView;
		this.Title = bundleUnityView.BundleView.Name;
		this.Text = bundleUnityView.BundleView.Description;
		this.Width = 388;
		this.Height = 560 - GlobalUIRibbon.Instance.Height() - 10;
		this._lotteryItemGrid = new ShopItemGrid(bundleUnityView.BundleView.BundleItemViews, 0, 0);
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x0005EB54 File Offset: 0x0005CD54
	protected override void DrawPlayGUI(Rect rect)
	{
		GUI.color = ColorScheme.HudTeamBlue;
		float num = BlueStonez.label_interparkbold_18pt.CalcSize(new GUIContent(this.Title)).x * 2.5f;
		GUI.DrawTexture(new Rect((rect.width - num) * 0.5f, -29f, num, 100f), HudTextures.WhiteBlur128);
		GUI.color = Color.white;
		GUITools.OutlineLabel(new Rect(0f, 10f, rect.width, 30f), this.Title, BlueStonez.label_interparkbold_18pt, 1, Color.white, ColorScheme.GuiTeamBlue.SetAlpha(0.5f));
		GUI.Label(new Rect(30f, 35f, rect.width - 60f, 40f), this.Text, BlueStonez.label_interparkbold_13pt);
		int num2 = 288;
		int num3 = (this.Width - num2 - 6) / 2;
		int num4 = 323;
		GUI.BeginGroup(new Rect((float)num3, 75f, (float)num2, (float)num4), BlueStonez.item_slot_large);
		Rect rect2 = new Rect((float)((num2 - 282) / 2), (float)((num4 - 317) / 2), 282f, 317f);
		this._bundleUnityView.Image.Draw(rect2, false);
		this._lotteryItemGrid.Show = (rect2.Contains(Event.current.mousePosition) || ApplicationDataManager.IsMobile);
		this._lotteryItemGrid.Draw(new Rect(0f, 0f, (float)num2, (float)num4));
		GUI.EndGroup();
		if (GUI.Button(new Rect(rect.width * 0.5f - 95f, rect.height - 42f, 20f, 20f), GUIContent.none, BlueStonez.button_left))
		{
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
			PopupSystem.HideMessage(this);
			BundleUnityView previousItem = Singleton<BundleManager>.Instance.GetPreviousItem(this._bundleUnityView);
			if (previousItem != null)
			{
				PopupSystem.Show(new ItemBundlePopup(previousItem));
			}
		}
		if (GUI.Button(new Rect(rect.width * 0.5f + 75f, rect.height - 42f, 20f, 20f), GUIContent.none, BlueStonez.button_right))
		{
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
			PopupSystem.HideMessage(this);
			BundleUnityView nextItem = Singleton<BundleManager>.Instance.GetNextItem(this._bundleUnityView);
			if (nextItem != null)
			{
				PopupSystem.Show(new ItemBundlePopup(nextItem));
			}
		}
		GUI.enabled = (!this._bundleUnityView.IsOwned && this._bundleUnityView.IsValid && GUITools.SaveClickIn(1f));
		this.BuyButton(rect, this._bundleUnityView);
		GUI.enabled = true;
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x00003C87 File Offset: 0x00001E87
	private void BuyButton(Rect position, BundleUnityView bundleUnityView)
	{
	}

	// Token: 0x04000CD6 RID: 3286
	private BundleUnityView _bundleUnityView;

	// Token: 0x04000CD7 RID: 3287
	private ShopItemGrid _lotteryItemGrid;
}
