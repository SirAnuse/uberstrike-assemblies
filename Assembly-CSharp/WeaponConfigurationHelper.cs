using System;
using System.Collections.Generic;
using System.Linq;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public static class WeaponConfigurationHelper
{
	// Token: 0x06001DCA RID: 7626 RVA: 0x00093A4C File Offset: 0x00091C4C
	static WeaponConfigurationHelper()
	{
		WeaponConfigurationHelper.MaxRecoilKickback = 1f;
		WeaponConfigurationHelper.MaxRateOfFire = 1f;
		WeaponConfigurationHelper.MaxProjectileSpeed = 1f;
		WeaponConfigurationHelper.MaxAccuracySpread = 1f;
		WeaponConfigurationHelper.MaxDamage = 1f;
		WeaponConfigurationHelper.MaxAmmo = 1f;
        WeaponConfigurationHelper.MaxArmorPierced = 1f;
	}

	// Token: 0x06001DCB RID: 7627 RVA: 0x00093AC8 File Offset: 0x00091CC8
	public static void UpdateWeaponStatistics(UberStrikeItemShopClientView shopView)
	{
		if (shopView != null && shopView.WeaponItems.Count > 0)
		{
			WeaponConfigurationHelper.MaxAmmo = (float)(from item in shopView.WeaponItems
			orderby item.MaxAmmo descending
			select item).First<UberStrikeItemWeaponView>().MaxAmmo;
			WeaponConfigurationHelper.MaxSplashRadius = (float)(from item in shopView.WeaponItems
			orderby item.SplashRadius descending
			select item).First<UberStrikeItemWeaponView>().SplashRadius / 100f;
			WeaponConfigurationHelper.MaxRecoilKickback = (float)(from item in shopView.WeaponItems
			orderby item.RecoilKickback descending
			select item).First<UberStrikeItemWeaponView>().RecoilKickback;
			WeaponConfigurationHelper.MaxRateOfFire = (float)(from item in shopView.WeaponItems
			orderby item.RateOfFire descending
			select item).First<UberStrikeItemWeaponView>().RateOfFire / 1000f;
			WeaponConfigurationHelper.MaxProjectileSpeed = (float)(from item in shopView.WeaponItems
			orderby item.ProjectileSpeed descending
			select item).First<UberStrikeItemWeaponView>().ProjectileSpeed;
			WeaponConfigurationHelper.MaxAccuracySpread = (float)((from item in shopView.WeaponItems
			orderby item.AccuracySpread descending
			select item).First<UberStrikeItemWeaponView>().AccuracySpread / 10);
			WeaponConfigurationHelper.MaxDamage = (float)(from item in shopView.WeaponItems
			orderby item.DamagePerProjectile descending
			select item).First<UberStrikeItemWeaponView>().DamagePerProjectile;
            WeaponConfigurationHelper.MaxArmorPierced = (float)(from item in shopView.WeaponItems
                                                          orderby item.ArmorPierced descending
                                                          select item).First<UberStrikeItemWeaponView>().ArmorPierced;
            foreach (UberStrikeItemWeaponView uberStrikeItemWeaponView in shopView.WeaponItems)
			{
				WeaponConfigurationHelper.rateOfFireCache[uberStrikeItemWeaponView.ID] = new SecureMemory<int>(uberStrikeItemWeaponView.RateOfFire);
				WeaponConfigurationHelper.spreadCache[uberStrikeItemWeaponView.ID] = new SecureMemory<int>(uberStrikeItemWeaponView.AccuracySpread);
				WeaponConfigurationHelper.speedCache[uberStrikeItemWeaponView.ID] = new SecureMemory<int>(uberStrikeItemWeaponView.ProjectileSpeed);
				WeaponConfigurationHelper.splashCache[uberStrikeItemWeaponView.ID] = new SecureMemory<int>(uberStrikeItemWeaponView.SplashRadius);
                WeaponConfigurationHelper.armorPiercedCache[uberStrikeItemWeaponView.ID] = new SecureMemory<int>(uberStrikeItemWeaponView.ArmorPierced);
            }
		}
	}

	// Token: 0x17000673 RID: 1651
	// (get) Token: 0x06001DCC RID: 7628 RVA: 0x00013C62 File Offset: 0x00011E62
	// (set) Token: 0x06001DCD RID: 7629 RVA: 0x00013C69 File Offset: 0x00011E69
	public static float MaxAmmo { get; private set; }

	// Token: 0x17000674 RID: 1652
	// (get) Token: 0x06001DCE RID: 7630 RVA: 0x00013C71 File Offset: 0x00011E71
	// (set) Token: 0x06001DCF RID: 7631 RVA: 0x00013C78 File Offset: 0x00011E78
	public static float MaxDamage { get; private set; }

	// Token: 0x17000675 RID: 1653
	// (get) Token: 0x06001DD0 RID: 7632 RVA: 0x00013C80 File Offset: 0x00011E80
	// (set) Token: 0x06001DD1 RID: 7633 RVA: 0x00013C87 File Offset: 0x00011E87
	public static float MaxAccuracySpread { get; private set; }

	// Token: 0x17000676 RID: 1654
	// (get) Token: 0x06001DD2 RID: 7634 RVA: 0x00013C8F File Offset: 0x00011E8F
	// (set) Token: 0x06001DD3 RID: 7635 RVA: 0x00013C96 File Offset: 0x00011E96
	public static float MaxProjectileSpeed { get; private set; }

	// Token: 0x17000677 RID: 1655
	// (get) Token: 0x06001DD4 RID: 7636 RVA: 0x00013C9E File Offset: 0x00011E9E
	// (set) Token: 0x06001DD5 RID: 7637 RVA: 0x00013CA5 File Offset: 0x00011EA5
	public static float MaxRateOfFire { get; private set; }

	// Token: 0x17000678 RID: 1656
	// (get) Token: 0x06001DD6 RID: 7638 RVA: 0x00013CAD File Offset: 0x00011EAD
	// (set) Token: 0x06001DD7 RID: 7639 RVA: 0x00013CB4 File Offset: 0x00011EB4
	public static float MaxRecoilKickback { get; private set; }

    public static float MaxArmorPierced { get; private set; }

	// Token: 0x17000679 RID: 1657
	// (get) Token: 0x06001DD8 RID: 7640 RVA: 0x00013CBC File Offset: 0x00011EBC
	// (set) Token: 0x06001DD9 RID: 7641 RVA: 0x00013CC3 File Offset: 0x00011EC3
	public static float MaxSplashRadius { get; private set; } = 1f;

	// Token: 0x06001DDA RID: 7642 RVA: 0x00013CCB File Offset: 0x00011ECB
	public static float GetAmmoNormalized(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)view.MaxAmmo / WeaponConfigurationHelper.MaxAmmo);
	}

	// Token: 0x06001DDB RID: 7643 RVA: 0x00013CEA File Offset: 0x00011EEA
	public static float GetDamageNormalized(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)(view.DamagePerProjectile * view.ProjectilesPerShot) / WeaponConfigurationHelper.MaxDamage);
	}

	// Token: 0x06001DDC RID: 7644 RVA: 0x00013D10 File Offset: 0x00011F10
	public static float GetAccuracySpreadNormalized(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)view.AccuracySpread / 10f / WeaponConfigurationHelper.MaxAccuracySpread);
	}

    public static float GetArmorPiercedNormalized(UberStrikeItemWeaponView view)
    {
        return (view == null) ? 0f : ((float)view.ArmorPierced / 10f / WeaponConfigurationHelper.MaxArmorPierced);
    }

    // Token: 0x06001DDD RID: 7645 RVA: 0x00013D35 File Offset: 0x00011F35
    public static float GetProjectileSpeedNormalized(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)view.ProjectileSpeed / WeaponConfigurationHelper.MaxProjectileSpeed);
	}

	// Token: 0x06001DDE RID: 7646 RVA: 0x00013D54 File Offset: 0x00011F54
	public static float GetRateOfFireNormalized(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)view.RateOfFire / 1000f / WeaponConfigurationHelper.MaxRateOfFire);
	}

	// Token: 0x06001DDF RID: 7647 RVA: 0x00013D79 File Offset: 0x00011F79
	public static float GetRecoilKickbackNormalized(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)view.RecoilKickback / WeaponConfigurationHelper.MaxRecoilKickback);
	}

	// Token: 0x06001DE0 RID: 7648 RVA: 0x00013D98 File Offset: 0x00011F98
	public static float GetSplashRadiusNormalized(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)view.SplashRadius / 100f / WeaponConfigurationHelper.MaxSplashRadius);
	}

	// Token: 0x06001DE1 RID: 7649 RVA: 0x00013DBD File Offset: 0x00011FBD
	public static float GetAmmo(UberStrikeItemWeaponView view)
	{
		return (float)((view == null) ? 0 : view.MaxAmmo);
	}

    public static float GetArmorPierced(UberStrikeItemWeaponView view)
    {
        return (float)((view == null) ? 0 : view.ArmorPierced);
    }

    // Token: 0x06001DE2 RID: 7650 RVA: 0x00013DD2 File Offset: 0x00011FD2
    public static float GetDamage(UberStrikeItemWeaponView view)
	{
		return (float)((view == null) ? 0 : (view.DamagePerProjectile * view.ProjectilesPerShot));
	}

	// Token: 0x06001DE3 RID: 7651 RVA: 0x00013DEE File Offset: 0x00011FEE
	public static float GetRecoilKickback(UberStrikeItemWeaponView view)
	{
		return (float)((view == null) ? 0 : view.RecoilKickback);
	}

	// Token: 0x06001DE4 RID: 7652 RVA: 0x00013E03 File Offset: 0x00012003
	public static float GetRecoilMovement(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)view.RecoilMovement / 100f);
	}

	// Token: 0x06001DE5 RID: 7653 RVA: 0x00013E22 File Offset: 0x00012022
	public static float GetCriticalStrikeBonus(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)view.CriticalStrikeBonus / 100f);
	}

	// Token: 0x06001DE6 RID: 7654 RVA: 0x00013E41 File Offset: 0x00012041
	public static float GetAccuracySpread(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)WeaponConfigurationHelper.GetSecureSpread(view.ID) / 10f);
	}

	// Token: 0x06001DE7 RID: 7655 RVA: 0x00013E65 File Offset: 0x00012065
	public static float GetRateOfFire(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 1f : ((float)WeaponConfigurationHelper.GetSecureRateOfFire(view.ID) / 1000f);
	}

	// Token: 0x06001DE8 RID: 7656 RVA: 0x00013E89 File Offset: 0x00012089
	public static float GetProjectileSpeed(UberStrikeItemWeaponView view)
	{
		return (float)((view == null) ? 1 : WeaponConfigurationHelper.GetSecureProjectileSpeed(view.ID));
	}

	// Token: 0x06001DE9 RID: 7657 RVA: 0x00013EA3 File Offset: 0x000120A3
	public static float GetSplashRadius(UberStrikeItemWeaponView view)
	{
		return (view == null) ? 0f : ((float)WeaponConfigurationHelper.GetSecureSplashRadius(view.ID) / 100f);
	}

	// Token: 0x06001DEA RID: 7658 RVA: 0x00093D38 File Offset: 0x00091F38
	public static int GetSecureRateOfFire(int itemId)
	{
		SecureMemory<int> secureMemory;
		if (WeaponConfigurationHelper.rateOfFireCache.TryGetValue(itemId, out secureMemory))
		{
			return secureMemory.ReadData(true);
		}
		return 1;
	}

	// Token: 0x06001DEB RID: 7659 RVA: 0x00093D60 File Offset: 0x00091F60
	public static int GetSecureSpread(int itemId)
	{
		SecureMemory<int> secureMemory;
		if (WeaponConfigurationHelper.spreadCache.TryGetValue(itemId, out secureMemory))
		{
			return secureMemory.ReadData(true);
		}
		return Mathf.RoundToInt(WeaponConfigurationHelper.MaxAccuracySpread * 10f);
	}

	// Token: 0x06001DEC RID: 7660 RVA: 0x00093D98 File Offset: 0x00091F98
	public static int GetSecureProjectileSpeed(int itemId)
	{
		SecureMemory<int> secureMemory;
		if (WeaponConfigurationHelper.speedCache.TryGetValue(itemId, out secureMemory))
		{
			return secureMemory.ReadData(true);
		}
		return 1;
	}

	// Token: 0x06001DED RID: 7661 RVA: 0x00093DC0 File Offset: 0x00091FC0
	public static int GetSecureSplashRadius(int itemId)
	{
		SecureMemory<int> secureMemory;
		if (WeaponConfigurationHelper.splashCache.TryGetValue(itemId, out secureMemory))
		{
			return secureMemory.ReadData(true);
		}
		return 0;
	}

    public static int GetSecureArmorPierced(int itemId)
    {
        SecureMemory<int> secureMemory;
        if (WeaponConfigurationHelper.armorPiercedCache.TryGetValue(itemId, out secureMemory))
        {
            return secureMemory.ReadData(true);
        }
        return 1;
    }

    // Token: 0x040019FD RID: 6653
    private static Dictionary<int, SecureMemory<int>> rateOfFireCache = new Dictionary<int, SecureMemory<int>>();

	// Token: 0x040019FE RID: 6654
	private static Dictionary<int, SecureMemory<int>> spreadCache = new Dictionary<int, SecureMemory<int>>();

	// Token: 0x040019FF RID: 6655
	private static Dictionary<int, SecureMemory<int>> speedCache = new Dictionary<int, SecureMemory<int>>();

	// Token: 0x04001A00 RID: 6656
	private static Dictionary<int, SecureMemory<int>> splashCache = new Dictionary<int, SecureMemory<int>>();

    // Token: 0x04001A00 RID: 6656
    private static Dictionary<int, SecureMemory<int>> armorPiercedCache = new Dictionary<int, SecureMemory<int>>();
}
