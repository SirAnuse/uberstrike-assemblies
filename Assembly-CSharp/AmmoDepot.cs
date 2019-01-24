using System;
using System.Collections.Generic;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000420 RID: 1056
public static class AmmoDepot
{
	// Token: 0x06001DF5 RID: 7669 RVA: 0x00093DE8 File Offset: 0x00091FE8
	static AmmoDepot()
	{
		AmmoDepot._startAmmo = new Dictionary<AmmoType, int>(7);
		foreach (object obj in Enum.GetValues(typeof(AmmoType)))
		{
			AmmoType key = (AmmoType)((int)obj);
			AmmoDepot._startAmmo.Add(key, 100);
			AmmoDepot._currentAmmo.Add(key, 0);
			AmmoDepot._maxAmmo.Add(key, 200);
		}
	}

	// Token: 0x06001DF6 RID: 7670 RVA: 0x00093E98 File Offset: 0x00092098
	public static void Reset()
	{
		AmmoDepot._currentAmmo[AmmoType.Handgun] = AmmoDepot._startAmmo[AmmoType.Handgun];
		AmmoDepot._currentAmmo[AmmoType.Machinegun] = AmmoDepot._startAmmo[AmmoType.Machinegun];
		AmmoDepot._currentAmmo[AmmoType.Launcher] = AmmoDepot._startAmmo[AmmoType.Launcher];
		AmmoDepot._currentAmmo[AmmoType.Shotgun] = AmmoDepot._startAmmo[AmmoType.Shotgun];
		AmmoDepot._currentAmmo[AmmoType.Cannon] = AmmoDepot._startAmmo[AmmoType.Cannon];
		AmmoDepot._currentAmmo[AmmoType.Splattergun] = AmmoDepot._startAmmo[AmmoType.Splattergun];
		AmmoDepot._currentAmmo[AmmoType.Snipergun] = AmmoDepot._startAmmo[AmmoType.Snipergun];
	}

	// Token: 0x06001DF7 RID: 7671 RVA: 0x00093F40 File Offset: 0x00092140
	public static void SetMaxAmmoForType(UberstrikeItemClass weaponClass, int maxAmmoCount)
	{
		if (PlayerDataManager.IsPlayerLoggedIn)
		{
			switch (weaponClass)
			{
			case UberstrikeItemClass.WeaponMachinegun:
				AmmoDepot._maxAmmo[AmmoType.Machinegun] = maxAmmoCount;
				break;
			case UberstrikeItemClass.WeaponShotgun:
				AmmoDepot._maxAmmo[AmmoType.Shotgun] = maxAmmoCount;
				break;
			case UberstrikeItemClass.WeaponSniperRifle:
				AmmoDepot._maxAmmo[AmmoType.Snipergun] = maxAmmoCount;
				break;
			case UberstrikeItemClass.WeaponCannon:
				AmmoDepot._maxAmmo[AmmoType.Cannon] = maxAmmoCount;
				break;
			case UberstrikeItemClass.WeaponSplattergun:
				AmmoDepot._maxAmmo[AmmoType.Splattergun] = maxAmmoCount;
				break;
			case UberstrikeItemClass.WeaponLauncher:
				AmmoDepot._maxAmmo[AmmoType.Launcher] = maxAmmoCount;
				break;
			}
		}
	}

	// Token: 0x06001DF8 RID: 7672 RVA: 0x00093FE4 File Offset: 0x000921E4
	public static void SetStartAmmoForType(UberstrikeItemClass weaponClass, int startAmmoCount)
	{
		if (PlayerDataManager.IsPlayerLoggedIn)
		{
			switch (weaponClass)
			{
			case UberstrikeItemClass.WeaponMachinegun:
				AmmoDepot._startAmmo[AmmoType.Machinegun] = startAmmoCount;
				break;
			case UberstrikeItemClass.WeaponShotgun:
				AmmoDepot._startAmmo[AmmoType.Shotgun] = startAmmoCount;
				break;
			case UberstrikeItemClass.WeaponSniperRifle:
				AmmoDepot._startAmmo[AmmoType.Snipergun] = startAmmoCount;
				break;
			case UberstrikeItemClass.WeaponCannon:
				AmmoDepot._startAmmo[AmmoType.Cannon] = startAmmoCount;
				break;
			case UberstrikeItemClass.WeaponSplattergun:
				AmmoDepot._startAmmo[AmmoType.Splattergun] = startAmmoCount;
				break;
			case UberstrikeItemClass.WeaponLauncher:
				AmmoDepot._startAmmo[AmmoType.Launcher] = startAmmoCount;
				break;
			}
		}
	}

	// Token: 0x06001DF9 RID: 7673 RVA: 0x00094088 File Offset: 0x00092288
	public static bool CanAddAmmo(AmmoType t)
	{
		UberstrikeItemClass itemClass;
		return AmmoDepot.TryGetAmmoTypeFromItemClass(t, out itemClass) && Singleton<WeaponController>.Instance.HasWeaponOfClass(itemClass) && AmmoDepot._currentAmmo[t] < AmmoDepot._maxAmmo[t];
	}

	// Token: 0x06001DFA RID: 7674 RVA: 0x000940CC File Offset: 0x000922CC
	public static void AddAmmoOfClass(UberstrikeItemClass c)
	{
		AmmoType t;
		if (AmmoDepot.TryGetAmmoType(c, out t))
		{
			AmmoDepot.AddDefaultAmmoOfType(t);
		}
	}

	// Token: 0x06001DFB RID: 7675 RVA: 0x00013EFF File Offset: 0x000120FF
	public static void AddDefaultAmmoOfType(AmmoType t)
	{
		AmmoDepot.AddAmmoOfType(t, AmmoDepot._startAmmo[t]);
	}

	// Token: 0x06001DFC RID: 7676 RVA: 0x000940EC File Offset: 0x000922EC
	public static void AddAmmoOfType(AmmoType t, int bullets)
	{
		AmmoDepot._currentAmmo[t] = Mathf.Clamp(AmmoDepot._currentAmmo[t] + bullets, 0, AmmoDepot._maxAmmo[t]);
		GameState.Current.PlayerData.Ammo.Value = AmmoDepot._currentAmmo[t];
	}

	// Token: 0x06001DFD RID: 7677 RVA: 0x00094144 File Offset: 0x00092344
	public static void AddStartAmmoOfType(AmmoType t, float percentage = 1f)
	{
		int num = Mathf.CeilToInt((float)AmmoDepot._startAmmo[t] * percentage);
		AmmoDepot._currentAmmo[t] = Mathf.Clamp(AmmoDepot._currentAmmo[t] + num, 0, AmmoDepot._maxAmmo[t]);
		GameState.Current.PlayerData.Ammo.Value = AmmoDepot._currentAmmo[t];
	}

	// Token: 0x06001DFE RID: 7678 RVA: 0x000941B0 File Offset: 0x000923B0
	public static void AddMaxAmmoOfType(AmmoType t, float percentage = 1f)
	{
		int num = Mathf.CeilToInt((float)AmmoDepot._maxAmmo[t] * percentage);
		AmmoDepot._currentAmmo[t] = Mathf.Clamp(AmmoDepot._currentAmmo[t] + num, 0, AmmoDepot._maxAmmo[t]);
		GameState.Current.PlayerData.Ammo.Value = AmmoDepot._currentAmmo[t];
	}

	// Token: 0x06001DFF RID: 7679 RVA: 0x00013F12 File Offset: 0x00012112
	public static bool HasAmmoOfType(AmmoType t)
	{
		return AmmoDepot._currentAmmo[t] > 0;
	}

	// Token: 0x06001E00 RID: 7680 RVA: 0x0009421C File Offset: 0x0009241C
	public static bool HasAmmoOfClass(UberstrikeItemClass t)
	{
		AmmoType t2;
		return t == UberstrikeItemClass.WeaponMelee || (AmmoDepot.TryGetAmmoType(t, out t2) && AmmoDepot.HasAmmoOfType(t2));
	}

	// Token: 0x06001E01 RID: 7681 RVA: 0x00013F22 File Offset: 0x00012122
	public static int AmmoOfType(AmmoType t)
	{
		return AmmoDepot._currentAmmo[t];
	}

	// Token: 0x06001E02 RID: 7682 RVA: 0x0009424C File Offset: 0x0009244C
	public static int AmmoOfClass(UberstrikeItemClass t)
	{
		AmmoType t2;
		if (AmmoDepot.TryGetAmmoType(t, out t2))
		{
			return AmmoDepot.AmmoOfType(t2);
		}
		return 0;
	}

	// Token: 0x06001E03 RID: 7683 RVA: 0x00094270 File Offset: 0x00092470
	public static int MaxAmmoOfClass(UberstrikeItemClass t)
	{
		AmmoType key;
		if (AmmoDepot.TryGetAmmoType(t, out key))
		{
			return AmmoDepot._maxAmmo[key];
		}
		return 0;
	}

	// Token: 0x06001E04 RID: 7684 RVA: 0x00094298 File Offset: 0x00092498
	public static bool TryGetAmmoType(UberstrikeItemClass item, out AmmoType t)
	{
		switch (item)
		{
		case UberstrikeItemClass.WeaponMachinegun:
			t = AmmoType.Machinegun;
			return true;
		case UberstrikeItemClass.WeaponShotgun:
			t = AmmoType.Shotgun;
			return true;
		case UberstrikeItemClass.WeaponSniperRifle:
			t = AmmoType.Snipergun;
			return true;
		case UberstrikeItemClass.WeaponCannon:
			t = AmmoType.Cannon;
			return true;
		case UberstrikeItemClass.WeaponSplattergun:
			t = AmmoType.Splattergun;
			return true;
		case UberstrikeItemClass.WeaponLauncher:
			t = AmmoType.Launcher;
			return true;
		default:
			t = AmmoType.Handgun;
			return false;
		}
	}

	// Token: 0x06001E05 RID: 7685 RVA: 0x000942F0 File Offset: 0x000924F0
	public static bool TryGetAmmoTypeFromItemClass(AmmoType t, out UberstrikeItemClass itemClass)
	{
		switch (t)
		{
		case AmmoType.Cannon:
			itemClass = UberstrikeItemClass.WeaponCannon;
			return true;
		case AmmoType.Launcher:
			itemClass = UberstrikeItemClass.WeaponLauncher;
			return true;
		case AmmoType.Machinegun:
			itemClass = UberstrikeItemClass.WeaponMachinegun;
			return true;
		case AmmoType.Shotgun:
			itemClass = UberstrikeItemClass.WeaponShotgun;
			return true;
		case AmmoType.Snipergun:
			itemClass = UberstrikeItemClass.WeaponSniperRifle;
			return true;
		case AmmoType.Splattergun:
			itemClass = UberstrikeItemClass.WeaponSplattergun;
			return true;
		}
		itemClass = UberstrikeItemClass.WeaponMachinegun;
		return false;
	}

	// Token: 0x06001E06 RID: 7686 RVA: 0x00094348 File Offset: 0x00092548
	public static bool UseAmmoOfType(AmmoType t, int count = 1)
	{
		if (AmmoDepot._currentAmmo[t] > 0)
		{
			AmmoDepot._currentAmmo[t] = Mathf.Max(AmmoDepot._currentAmmo[t] - count, 0);
			GameState.Current.PlayerData.Ammo.Value = AmmoDepot._currentAmmo[t];
			return true;
		}
		return false;
	}

	// Token: 0x06001E07 RID: 7687 RVA: 0x000943A8 File Offset: 0x000925A8
	public static bool UseAmmoOfClass(UberstrikeItemClass t, int count = 1)
	{
		AmmoType t2;
		return AmmoDepot.TryGetAmmoType(t, out t2) && AmmoDepot.UseAmmoOfType(t2, count);
	}

	// Token: 0x06001E08 RID: 7688 RVA: 0x000943CC File Offset: 0x000925CC
	public static string ToString(AmmoType t)
	{
		return AmmoDepot._currentAmmo[t].ToString();
	}

	// Token: 0x06001E09 RID: 7689 RVA: 0x000943EC File Offset: 0x000925EC
	public static void RemoveExtraAmmoOfType(UberstrikeItemClass t)
	{
		AmmoType key;
		if (AmmoDepot.TryGetAmmoType(t, out key) && AmmoDepot._currentAmmo[key] > AmmoDepot._maxAmmo[key])
		{
			AmmoDepot._currentAmmo[key] = AmmoDepot._maxAmmo[key];
		}
	}

	// Token: 0x04001A17 RID: 6679
	private static Dictionary<AmmoType, int> _currentAmmo = new Dictionary<AmmoType, int>(7);

	// Token: 0x04001A18 RID: 6680
	private static Dictionary<AmmoType, int> _startAmmo;

	// Token: 0x04001A19 RID: 6681
	private static Dictionary<AmmoType, int> _maxAmmo = new Dictionary<AmmoType, int>(7);
}
