using System;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000201 RID: 513
public class WeaponItemDetailGUI : IBaseItemDetailGUI
{
	// Token: 0x06000E42 RID: 3650 RVA: 0x0000A699 File Offset: 0x00008899
	public WeaponItemDetailGUI(UberStrikeItemWeaponView item)
	{
		this._item = item;
	}

	// Token: 0x06000E43 RID: 3651 RVA: 0x00061858 File Offset: 0x0005FA58
	public void Draw()
	{
		if (this._item != null)
		{
			GUITools.ProgressBar(new Rect(14f, 95f, 165f, 12f), LocalizedStrings.Damage, WeaponConfigurationHelper.GetDamageNormalized(this._item), ColorScheme.ProgressBar, 64);
			GUITools.ProgressBar(new Rect(14f, 111f, 165f, 12f), LocalizedStrings.RateOfFire, WeaponConfigurationHelper.GetRateOfFireNormalized(this._item), ColorScheme.ProgressBar, 64);
			if (this._item.ItemClass == UberstrikeItemClass.WeaponCannon || this._item.ItemClass == UberstrikeItemClass.WeaponLauncher || this._item.ItemClass == UberstrikeItemClass.WeaponSplattergun)
			{
				GUITools.ProgressBar(new Rect(175f, 95f, 165f, 12f), LocalizedStrings.Velocity, WeaponConfigurationHelper.GetProjectileSpeedNormalized(this._item), ColorScheme.ProgressBar, 64);
				GUITools.ProgressBar(new Rect(175f, 111f, 165f, 12f), LocalizedStrings.Impact, WeaponConfigurationHelper.GetSplashRadiusNormalized(this._item), ColorScheme.ProgressBar, 64);
			}
			else if (this._item.ItemClass == UberstrikeItemClass.WeaponMelee)
			{
				bool enabled = GUI.enabled;
				GUI.enabled = false;
				GUITools.ProgressBar(new Rect(175f, 95f, 165f, 12f), LocalizedStrings.Accuracy, 0f, ColorScheme.ProgressBar, 64);
				GUITools.ProgressBar(new Rect(175f, 111f, 165f, 12f), LocalizedStrings.Recoil, 0f, ColorScheme.ProgressBar, 64);
				GUI.enabled = enabled;
			}
			else
			{
				GUITools.ProgressBar(new Rect(175f, 95f, 165f, 12f), LocalizedStrings.Accuracy, WeaponConfigurationHelper.GetAccuracySpreadNormalized(this._item), ColorScheme.ProgressBar, 64);
				GUITools.ProgressBar(new Rect(175f, 111f, 165f, 12f), LocalizedStrings.Recoil, WeaponConfigurationHelper.GetRecoilKickbackNormalized(this._item), ColorScheme.ProgressBar, 64);
                GUITools.ProgressBar(new Rect(175f, 127f, 165f, 12f), LocalizedStrings.ArmorPierced, WeaponConfigurationHelper.GetArmorPiercedNormalized(this._item), ColorScheme.ProgressBar, 64);
			}
		}
	}

	// Token: 0x04000D22 RID: 3362
	private UberStrikeItemWeaponView _item;
}
