using System;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x020001EF RID: 495
public class ArmorItemDetailGUI : IBaseItemDetailGUI
{
	// Token: 0x06000DF2 RID: 3570 RVA: 0x0000A361 File Offset: 0x00008561
	public ArmorItemDetailGUI(UberStrikeItemGearView item, Texture2D armorPointsIcon)
	{
		this._item = item;
		this._armorPointsIcon = armorPointsIcon;
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x00060220 File Offset: 0x0005E420
	public void Draw()
	{
		GUI.DrawTexture(new Rect(48f, 89f, 32f, 32f), this._armorPointsIcon);
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(48f, 89f, 32f, 32f), this._item.ArmorPoints.ToString(), BlueStonez.label_interparkbold_16pt);
		GUI.contentColor = Color.white;
		GUI.Label(new Rect(80f, 89f, 32f, 32f), "AP", BlueStonez.label_interparkbold_18pt_left);
	}

	// Token: 0x04000D0C RID: 3340
	private UberStrikeItemGearView _item;

	// Token: 0x04000D0D RID: 3341
	private Texture2D _armorPointsIcon;
}
