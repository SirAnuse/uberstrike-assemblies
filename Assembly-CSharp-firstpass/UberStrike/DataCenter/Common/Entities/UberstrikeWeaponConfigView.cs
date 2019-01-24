using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001FC RID: 508
	public class UberstrikeWeaponConfigView
	{
		// Token: 0x06000D93 RID: 3475 RVA: 0x00002050 File Offset: 0x00000250
		public UberstrikeWeaponConfigView()
		{
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x00011658 File Offset: 0x0000F858
		public UberstrikeWeaponConfigView(int damageKnockback, int damagePerProjectile, int accuracySpread, int recoilKickback, int startAmmo, int maxAmmo, int missileTimeToDetonate, int missileForceImpulse, int missileBounciness, int rateOfire, int splashRadius, int projectilesPerShot, int projectileSpeed, int recoilMovement)
		{
			this.DamageKnockback = damageKnockback;
			this.DamagePerProjectile = damagePerProjectile;
			this.AccuracySpread = accuracySpread;
			this.RecoilKickback = recoilKickback;
			this.StartAmmo = startAmmo;
			this.MaxAmmo = maxAmmo;
            //this.ArmorPierced = armorPierced;
			this.MissileTimeToDetonate = missileTimeToDetonate;
			this.MissileForceImpulse = missileForceImpulse;
			this.MissileBounciness = missileBounciness;
			this.SplashRadius = splashRadius;
			this.ProjectilesPerShot = projectilesPerShot;
			this.ProjectileSpeed = projectileSpeed;
			this.RateOfFire = rateOfire;
			this.RecoilMovement = recoilMovement;
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000D95 RID: 3477 RVA: 0x000097B2 File Offset: 0x000079B2
		// (set) Token: 0x06000D96 RID: 3478 RVA: 0x000097BA File Offset: 0x000079BA
		public int DamageKnockback { get; set; }

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000D97 RID: 3479 RVA: 0x000097C3 File Offset: 0x000079C3
		// (set) Token: 0x06000D98 RID: 3480 RVA: 0x000097CB File Offset: 0x000079CB
		public int DamagePerProjectile { get; set; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x000097D4 File Offset: 0x000079D4
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x000097DC File Offset: 0x000079DC
		public int AccuracySpread { get; set; }

        //public int ArmorPierced { get; set; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x000097E5 File Offset: 0x000079E5
		// (set) Token: 0x06000D9C RID: 3484 RVA: 0x000097ED File Offset: 0x000079ED
		public int RecoilKickback { get; set; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000D9D RID: 3485 RVA: 0x000097F6 File Offset: 0x000079F6
		// (set) Token: 0x06000D9E RID: 3486 RVA: 0x000097FE File Offset: 0x000079FE
		public int StartAmmo { get; set; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000D9F RID: 3487 RVA: 0x00009807 File Offset: 0x00007A07
		// (set) Token: 0x06000DA0 RID: 3488 RVA: 0x0000980F File Offset: 0x00007A0F
		public int MaxAmmo { get; set; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x00009818 File Offset: 0x00007A18
		// (set) Token: 0x06000DA2 RID: 3490 RVA: 0x00009820 File Offset: 0x00007A20
		public int MissileTimeToDetonate { get; set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000DA3 RID: 3491 RVA: 0x00009829 File Offset: 0x00007A29
		// (set) Token: 0x06000DA4 RID: 3492 RVA: 0x00009831 File Offset: 0x00007A31
		public int MissileForceImpulse { get; set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000DA5 RID: 3493 RVA: 0x0000983A File Offset: 0x00007A3A
		// (set) Token: 0x06000DA6 RID: 3494 RVA: 0x00009842 File Offset: 0x00007A42
		public int MissileBounciness { get; set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x0000984B File Offset: 0x00007A4B
		// (set) Token: 0x06000DA8 RID: 3496 RVA: 0x00009853 File Offset: 0x00007A53
		public int SplashRadius { get; set; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x0000985C File Offset: 0x00007A5C
		// (set) Token: 0x06000DAA RID: 3498 RVA: 0x00009864 File Offset: 0x00007A64
		public int ProjectilesPerShot { get; set; }

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000DAB RID: 3499 RVA: 0x0000986D File Offset: 0x00007A6D
		// (set) Token: 0x06000DAC RID: 3500 RVA: 0x00009875 File Offset: 0x00007A75
		public int ProjectileSpeed { get; set; }

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000DAD RID: 3501 RVA: 0x0000987E File Offset: 0x00007A7E
		// (set) Token: 0x06000DAE RID: 3502 RVA: 0x00009886 File Offset: 0x00007A86
		public int RateOfFire { get; set; }

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x0000988F File Offset: 0x00007A8F
		// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x00009897 File Offset: 0x00007A97
		public int RecoilMovement { get; set; }

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000DB1 RID: 3505 RVA: 0x000098A0 File Offset: 0x00007AA0
		// (set) Token: 0x06000DB2 RID: 3506 RVA: 0x000098A8 File Offset: 0x00007AA8
		public int LevelRequired { get; set; }

		// Token: 0x06000DB3 RID: 3507 RVA: 0x000116D8 File Offset: 0x0000F8D8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeWeaponConfigView: [DamageKnockback: ");
			stringBuilder.Append(this.DamageKnockback);
			stringBuilder.Append("][DamagePerProjectile: ");
			stringBuilder.Append(this.DamagePerProjectile);
			stringBuilder.Append("][AccuracySpread: ");
			stringBuilder.Append(this.AccuracySpread);
            /*stringBuilder.Append("][ArmorPierced: ");
            stringBuilder.Append(this.ArmorPierced);*/
            stringBuilder.Append("][RecoilKickback: ");
			stringBuilder.Append(this.RecoilKickback);
			stringBuilder.Append("][StartAmmo: ");
			stringBuilder.Append(this.StartAmmo);
			stringBuilder.Append("][MaxAmmo: ");
			stringBuilder.Append(this.MaxAmmo);
			stringBuilder.Append("][MissileTimeToDetonate: ");
			stringBuilder.Append(this.MissileTimeToDetonate);
			stringBuilder.Append("][MissileForceImpulse: ");
			stringBuilder.Append(this.MissileForceImpulse);
			stringBuilder.Append("][MissileBounciness: ");
			stringBuilder.Append(this.MissileBounciness);
			stringBuilder.Append("][RateOfFire: ");
			stringBuilder.Append(this.RateOfFire);
			stringBuilder.Append("][SplashRadius: ");
			stringBuilder.Append(this.SplashRadius);
			stringBuilder.Append("][ProjectilesPerShot: ");
			stringBuilder.Append(this.ProjectilesPerShot);
			stringBuilder.Append("][ProjectileSpeed: ");
			stringBuilder.Append(this.ProjectileSpeed);
			stringBuilder.Append("][RecoilMovement: ");
			stringBuilder.Append(this.RecoilMovement);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
