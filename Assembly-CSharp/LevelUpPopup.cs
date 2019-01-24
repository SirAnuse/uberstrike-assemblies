using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001E4 RID: 484
public class LevelUpPopup : IPopupDialog
{
	// Token: 0x06000DA0 RID: 3488 RVA: 0x0000A052 File Offset: 0x00008252
	public LevelUpPopup(int level, Action action = null) : this(level, level - 1, action)
	{
	}

	// Token: 0x06000DA1 RID: 3489 RVA: 0x0005F3A0 File Offset: 0x0005D5A0
	public LevelUpPopup(int newLevel, int previousLevel, Action action = null)
	{
		this._action = action;
		this._level = newLevel;
		this.Title = "Level Up";
		this.Text = "Congratulations, you reached level " + this._level + "!";
		this.Width = 388;
		this.Height = 560 - GlobalUIRibbon.Instance.Height() - 10;
		List<ShopItemView> list = new List<ShopItemView>();
		for (int i = newLevel; i > previousLevel; i--)
		{
			list.AddRange(this.GetItemsUnlocked(i));
		}
		AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.LevelUp, 0UL, 1f, 1f);
		this._itemGrid = new ShopItemGrid(list, 0, 0);
		this._itemGrid.Show = true;
	}

	// Token: 0x1700034A RID: 842
	// (get) Token: 0x06000DA2 RID: 3490 RVA: 0x0000A05F File Offset: 0x0000825F
	// (set) Token: 0x06000DA3 RID: 3491 RVA: 0x0000A067 File Offset: 0x00008267
	public string Text { get; set; }

	// Token: 0x1700034B RID: 843
	// (get) Token: 0x06000DA4 RID: 3492 RVA: 0x0000A070 File Offset: 0x00008270
	// (set) Token: 0x06000DA5 RID: 3493 RVA: 0x0000A078 File Offset: 0x00008278
	public string Title { get; set; }

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06000DA6 RID: 3494 RVA: 0x0000A081 File Offset: 0x00008281
	// (set) Token: 0x06000DA7 RID: 3495 RVA: 0x0000A089 File Offset: 0x00008289
	public bool IsWaiting { get; set; }

	// Token: 0x06000DA8 RID: 3496 RVA: 0x0005F480 File Offset: 0x0005D680
	public void OnGUI()
	{
		Rect position = this.GetPosition();
		GUI.Box(position, GUIContent.none, BlueStonez.window);
		GUITools.PushGUIState();
		GUI.BeginGroup(position);
		this.DrawPlayGUI(position);
		GUI.EndGroup();
		GUITools.PopGUIState();
		if (this.IsWaiting)
		{
			WaitingTexture.Draw(position.center, 0);
		}
	}

	// Token: 0x06000DA9 RID: 3497 RVA: 0x0005F4D8 File Offset: 0x0005D6D8
	private Rect GetPosition()
	{
		float left = (float)(Screen.width - this.Width) * 0.5f;
		float top = (float)GlobalUIRibbon.Instance.Height() + (float)(Screen.height - GlobalUIRibbon.Instance.Height() - this.Height) * 0.5f;
		return new Rect(left, top, (float)this.Width, (float)this.Height);
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x0005F53C File Offset: 0x0005D73C
	private List<ShopItemView> GetItemsUnlocked(int level)
	{
		List<ShopItemView> list = new List<ShopItemView>();
		if (level > 1)
		{
			foreach (IUnityItem unityItem in Singleton<ItemManager>.Instance.ShopItems)
			{
				if (unityItem.View.LevelLock == level && unityItem.View.IsForSale)
				{
					list.Add(new ShopItemView(unityItem.View.ID));
				}
			}
		}
		return list;
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x0005F5D8 File Offset: 0x0005D7D8
	private void DrawPlayGUI(Rect rect)
	{
		GUI.color = ColorScheme.HudTeamBlue;
		float num = BlueStonez.label_interparkbold_18pt.CalcSize(new GUIContent(this.Title)).x * 2.5f;
		GUI.DrawTexture(new Rect((rect.width - num) * 0.5f, -29f, num, 100f), HudTextures.WhiteBlur128);
		GUI.color = Color.white;
		GUITools.OutlineLabel(new Rect(0f, 10f, rect.width, 30f), this.Title, BlueStonez.label_interparkbold_18pt, 1, Color.white, ColorScheme.GuiTeamBlue.SetAlpha(0.5f));
		GUI.Label(new Rect(30f, 35f, rect.width - 60f, 40f), this.Text, BlueStonez.label_interparkbold_16pt);
		int num2 = 288;
		int num3 = (this.Width - num2 - 6) / 2;
		int num4 = 323;
		int count = this._itemGrid.Items.Count;
		GUI.BeginGroup(new Rect((float)num3, 75f, (float)num2, (float)num4), BlueStonez.item_slot_large);
		Rect position = new Rect((float)((num2 - 282) / 2), (float)((num4 - 317) / 2), 282f, 317f);
		GUI.DrawTexture(position, UberstrikeIcons.LevelUpPopup);
		if (count > 0)
		{
			this._itemGrid.Draw(new Rect(0f, 0f, (float)num2, (float)num4));
		}
		GUI.EndGroup();
		if (count > 0)
		{
			GUI.Label(new Rect(30f, rect.height - 107f, rect.width - 60f, 40f), string.Format("You unlocked {0} new item{1}.", count, (count != 1) ? "s" : string.Empty), BlueStonez.label_interparkbold_16pt);
		}
		int num5 = -70;
		if (GUI.Button(new Rect(rect.width * 0.5f + (float)num5, rect.height - 47f, 140f, 30f), "OK", BlueStonez.buttongold_large_price))
		{
			PopupSystem.HideMessage(this);
			if (this._action != null)
			{
				this._action();
			}
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06000DAC RID: 3500 RVA: 0x00008F9A File Offset: 0x0000719A
	public GuiDepth Depth
	{
		get
		{
			return GuiDepth.Event;
		}
	}

	// Token: 0x06000DAD RID: 3501 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnHide()
	{
	}

	// Token: 0x04000CDB RID: 3291
	protected int Width = 650;

	// Token: 0x04000CDC RID: 3292
	protected int Height = 330;

	// Token: 0x04000CDD RID: 3293
	private ShopItemGrid _itemGrid;

	// Token: 0x04000CDE RID: 3294
	private Action _action;

	// Token: 0x04000CDF RID: 3295
	private int _level;
}
