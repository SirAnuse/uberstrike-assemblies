using System;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;

// Token: 0x020002AD RID: 685
public static class DefaultItemUtil
{
	// Token: 0x060012F4 RID: 4852 RVA: 0x0006F8DC File Offset: 0x0006DADC
	public static void ConfigureDefaultGearAndWeapons()
	{
		Singleton<ItemManager>.Instance.AddDefaultItem(new UberStrikeItemGearView
		{
			ID = 1084,
			PrefabName = "LutzDefaultGearHead"
		});
		Singleton<ItemManager>.Instance.AddDefaultItem(new UberStrikeItemGearView
		{
			ID = 1086,
			PrefabName = "LutzDefaultGearGloves"
		});
		Singleton<ItemManager>.Instance.AddDefaultItem(new UberStrikeItemGearView
		{
			ID = 1087,
			PrefabName = "LutzDefaultGearUpperBody"
		});
		Singleton<ItemManager>.Instance.AddDefaultItem(new UberStrikeItemGearView
		{
			ID = 1088,
			PrefabName = "LutzDefaultGearLowerBody"
		});
		Singleton<ItemManager>.Instance.AddDefaultItem(new UberStrikeItemGearView
		{
			ID = 1089,
			PrefabName = "LutzDefaultGearBoots"
		});
		for (UberstrikeItemClass uberstrikeItemClass = UberstrikeItemClass.WeaponMelee; uberstrikeItemClass <= UberstrikeItemClass.WeaponLauncher; uberstrikeItemClass++)
		{
			Singleton<ItemManager>.Instance.AddDefaultItem(DefaultItemUtil.GetDefaultWeaponView(uberstrikeItemClass));
		}
	}

	// Token: 0x060012F5 RID: 4853 RVA: 0x0006F9D4 File Offset: 0x0006DBD4
	public static UberStrikeItemWeaponView GetDefaultWeaponView(UberstrikeItemClass itemClass)
	{
		switch (itemClass)
		{
		case UberstrikeItemClass.WeaponMelee:
			return new UberStrikeItemWeaponView
			{
				ID = 1000,
				ItemClass = UberstrikeItemClass.WeaponMelee,
				PrefabName = "TheSplatbat",
				DamageKnockback = 1000,
                //ArmorPierced = 0,
				DamagePerProjectile = 99,
				AccuracySpread = 0,
				RecoilKickback = 0,
				StartAmmo = 0,
				MaxAmmo = 0,
				MissileTimeToDetonate = 0,
				MissileForceImpulse = 0,
				MissileBounciness = 0,
				RateOfFire = 500,
				SplashRadius = 100,
				ProjectilesPerShot = 1,
				ProjectileSpeed = 0,
				RecoilMovement = 0,
				HasAutomaticFire = true,
				DefaultZoomMultiplier = 1,
				MinZoomMultiplier = 1,
				MaxZoomMultiplier = 1
			};
		case UberstrikeItemClass.WeaponMachinegun:
			return new UberStrikeItemWeaponView
			{
				ID = 1002,
				ItemClass = UberstrikeItemClass.WeaponMachinegun,
				PrefabName = "MachineGun",
				DamageKnockback = 50,
                //ArmorPierced = 0,
                DamagePerProjectile = 13,
				AccuracySpread = 3,
				RecoilKickback = 4,
				StartAmmo = 100,
				MaxAmmo = 300,
				MissileTimeToDetonate = 0,
				MissileForceImpulse = 0,
				MissileBounciness = 0,
				RateOfFire = 125,
				SplashRadius = 100,
				ProjectilesPerShot = 1,
				ProjectileSpeed = 0,
				RecoilMovement = 5,
				WeaponSecondaryAction = 2,
				HasAutomaticFire = true,
				DefaultZoomMultiplier = 2,
				MinZoomMultiplier = 2,
				MaxZoomMultiplier = 2
			};
		case UberstrikeItemClass.WeaponShotgun:
			return new UberStrikeItemWeaponView
			{
				ID = 1003,
				ItemClass = UberstrikeItemClass.WeaponShotgun,
				PrefabName = "ShotGun",
				DamageKnockback = 160,
                //ArmorPierced = 0,
                DamagePerProjectile = 9,
				AccuracySpread = 8,
				RecoilKickback = 15,
				StartAmmo = 20,
				MaxAmmo = 50,
				MissileTimeToDetonate = 0,
				MissileForceImpulse = 0,
				MissileBounciness = 0,
				RateOfFire = 1000,
				SplashRadius = 100,
				ProjectilesPerShot = 11,
				ProjectileSpeed = 0,
				RecoilMovement = 10,
				DefaultZoomMultiplier = 1,
				MinZoomMultiplier = 1,
				MaxZoomMultiplier = 1
			};
		case UberstrikeItemClass.WeaponSniperRifle:
			return new UberStrikeItemWeaponView
			{
				ID = 1004,
				ItemClass = UberstrikeItemClass.WeaponSniperRifle,
				PrefabName = "SniperRifle",
				DamageKnockback = 150,
                //ArmorPierced = 0,
                DamagePerProjectile = 70,
				AccuracySpread = 0,
				RecoilKickback = 12,
				StartAmmo = 20,
				MaxAmmo = 50,
				MissileTimeToDetonate = 0,
				MissileForceImpulse = 0,
				MissileBounciness = 0,
				RateOfFire = 1500,
				SplashRadius = 100,
				ProjectilesPerShot = 1,
				ProjectileSpeed = 0,
				RecoilMovement = 15,
				WeaponSecondaryAction = 1,
				DefaultZoomMultiplier = 2,
				MinZoomMultiplier = 2,
				MaxZoomMultiplier = 4
			};
		case UberstrikeItemClass.WeaponCannon:
			return new UberStrikeItemWeaponView
			{
				ID = 1005,
				ItemClass = UberstrikeItemClass.WeaponCannon,
				PrefabName = "Cannon",
				DamageKnockback = 600,
                //ArmorPierced = 0,
                DamagePerProjectile = 65,
				AccuracySpread = 0,
				RecoilKickback = 12,
				StartAmmo = 10,
				MaxAmmo = 25,
				MissileTimeToDetonate = 5000,
				MissileForceImpulse = 0,
				MissileBounciness = 0,
				RateOfFire = 1000,
				SplashRadius = 250,
				ProjectilesPerShot = 1,
				ProjectileSpeed = 50,
				RecoilMovement = 32,
				DefaultZoomMultiplier = 1,
				MinZoomMultiplier = 1,
				MaxZoomMultiplier = 1
			};
		case UberstrikeItemClass.WeaponSplattergun:
			return new UberStrikeItemWeaponView
			{
				ID = 1006,
				ItemClass = UberstrikeItemClass.WeaponSplattergun,
				PrefabName = "SplatterGun",
				DamageKnockback = 150,
                //ArmorPierced = 0,
                DamagePerProjectile = 16,
				AccuracySpread = 0,
				RecoilKickback = 0,
				StartAmmo = 60,
				MaxAmmo = 200,
				MissileTimeToDetonate = 5000,
				MissileForceImpulse = 0,
				MissileBounciness = 80,
				RateOfFire = 90,
				SplashRadius = 80,
				ProjectilesPerShot = 1,
				ProjectileSpeed = 70,
				RecoilMovement = 0,
				DefaultZoomMultiplier = 1,
				MinZoomMultiplier = 1,
				MaxZoomMultiplier = 1
			};
		case UberstrikeItemClass.WeaponLauncher:
			return new UberStrikeItemWeaponView
			{
				ID = 1007,
				ItemClass = UberstrikeItemClass.WeaponLauncher,
				PrefabName = "Launcher",
				DamageKnockback = 450,
                //ArmorPierced = 0,
                DamagePerProjectile = 70,
				AccuracySpread = 0,
				RecoilKickback = 15,
				StartAmmo = 15,
				MaxAmmo = 30,
				MissileTimeToDetonate = 1250,
				MissileForceImpulse = 0,
				MissileBounciness = 0,
				RateOfFire = 1000,
				SplashRadius = 400,
				ProjectilesPerShot = 1,
				ProjectileSpeed = 20,
				RecoilMovement = 9,
				DefaultZoomMultiplier = 1,
				MinZoomMultiplier = 1,
				MaxZoomMultiplier = 1
			};
		}
		return null;
	}

	// Token: 0x040012EA RID: 4842
	public const string HeadName = "LutzDefaultGearHead";

	// Token: 0x040012EB RID: 4843
	public const string GlovesName = "LutzDefaultGearGloves";

	// Token: 0x040012EC RID: 4844
	public const string UpperbodyName = "LutzDefaultGearUpperBody";

	// Token: 0x040012ED RID: 4845
	public const string LowerbodyName = "LutzDefaultGearLowerBody";

	// Token: 0x040012EE RID: 4846
	public const string BootsName = "LutzDefaultGearBoots";

	// Token: 0x040012EF RID: 4847
	public const string FaceName = "LutzDefaultGearFace";

	// Token: 0x040012F0 RID: 4848
	public const string MeleeName = "TheSplatbat";

	// Token: 0x040012F1 RID: 4849
	public const string HandGunName = "HandGun";

	// Token: 0x040012F2 RID: 4850
	public const string MachineGunName = "MachineGun";

	// Token: 0x040012F3 RID: 4851
	public const string SplatterGunName = "SplatterGun";

	// Token: 0x040012F4 RID: 4852
	public const string CannonName = "Cannon";

	// Token: 0x040012F5 RID: 4853
	public const string SniperRifleName = "SniperRifle";

	// Token: 0x040012F6 RID: 4854
	public const string LauncherName = "Launcher";

	// Token: 0x040012F7 RID: 4855
	public const string ShotGunName = "ShotGun";

	// Token: 0x040012F8 RID: 4856
	public const int HeadId = 1084;

	// Token: 0x040012F9 RID: 4857
	public const int GlovesId = 1086;

	// Token: 0x040012FA RID: 4858
	public const int UpperbodyId = 1087;

	// Token: 0x040012FB RID: 4859
	public const int LowerbodyId = 1088;

	// Token: 0x040012FC RID: 4860
	public const int BootsId = 1089;

	// Token: 0x040012FD RID: 4861
	public const int MeleeId = 1000;

	// Token: 0x040012FE RID: 4862
	public const int HandgunId = 1001;

	// Token: 0x040012FF RID: 4863
	public const int MachineGunId = 1002;

	// Token: 0x04001300 RID: 4864
	public const int ShotGunId = 1003;

	// Token: 0x04001301 RID: 4865
	public const int SniperRifleId = 1004;

	// Token: 0x04001302 RID: 4866
	public const int CannonId = 1005;

	// Token: 0x04001303 RID: 4867
	public const int SplatterGunId = 1006;

	// Token: 0x04001304 RID: 4868
	public const int LauncherId = 1007;
}
