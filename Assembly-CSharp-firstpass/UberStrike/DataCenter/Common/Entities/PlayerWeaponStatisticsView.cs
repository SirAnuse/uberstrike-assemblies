using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001EB RID: 491
	[Serializable]
	public class PlayerWeaponStatisticsView
	{
		// Token: 0x06000CCE RID: 3278 RVA: 0x00002050 File Offset: 0x00000250
		public PlayerWeaponStatisticsView()
		{
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x000109C0 File Offset: 0x0000EBC0
		public PlayerWeaponStatisticsView(int meleeTotalSplats, int machineGunTotalSplats, int shotgunTotalSplats, int sniperTotalSplats, int splattergunTotalSplats, int cannonTotalSplats, int launcherTotalSplats, int meleeTotalShotsFired, int meleeTotalShotsHit, int meleeTotalDamageDone, int machineGunTotalShotsFired, int machineGunTotalShotsHit, int machineGunTotalDamageDone, int shotgunTotalShotsFired, int shotgunTotalShotsHit, int shotgunTotalDamageDone, int sniperTotalShotsFired, int sniperTotalShotsHit, int sniperTotalDamageDone, int splattergunTotalShotsFired, int splattergunTotalShotsHit, int splattergunTotalDamageDone, int cannonTotalShotsFired, int cannonTotalShotsHit, int cannonTotalDamageDone, int launcherTotalShotsFired, int launcherTotalShotsHit, int launcherTotalDamageDone)
		{
			this.CannonTotalDamageDone = cannonTotalDamageDone;
			this.CannonTotalShotsFired = cannonTotalShotsFired;
			this.CannonTotalShotsHit = cannonTotalShotsHit;
			this.CannonTotalSplats = cannonTotalSplats;
			this.LauncherTotalDamageDone = launcherTotalDamageDone;
			this.LauncherTotalShotsFired = launcherTotalShotsFired;
			this.LauncherTotalShotsHit = launcherTotalShotsHit;
			this.LauncherTotalSplats = launcherTotalSplats;
			this.MachineGunTotalDamageDone = machineGunTotalDamageDone;
			this.MachineGunTotalShotsFired = machineGunTotalShotsFired;
			this.MachineGunTotalShotsHit = machineGunTotalShotsHit;
			this.MachineGunTotalSplats = machineGunTotalSplats;
			this.MeleeTotalDamageDone = meleeTotalDamageDone;
			this.MeleeTotalShotsFired = meleeTotalShotsFired;
			this.MeleeTotalShotsHit = meleeTotalShotsHit;
			this.MeleeTotalSplats = meleeTotalSplats;
			this.ShotgunTotalDamageDone = shotgunTotalDamageDone;
			this.ShotgunTotalShotsFired = shotgunTotalShotsFired;
			this.ShotgunTotalShotsHit = shotgunTotalShotsHit;
			this.ShotgunTotalSplats = shotgunTotalSplats;
			this.SniperTotalDamageDone = sniperTotalDamageDone;
			this.SniperTotalShotsFired = sniperTotalShotsFired;
			this.SniperTotalShotsHit = sniperTotalShotsHit;
			this.SniperTotalSplats = sniperTotalSplats;
			this.SplattergunTotalDamageDone = splattergunTotalDamageDone;
			this.SplattergunTotalShotsFired = splattergunTotalShotsFired;
			this.SplattergunTotalShotsHit = splattergunTotalShotsHit;
			this.SplattergunTotalSplats = splattergunTotalSplats;
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000CD0 RID: 3280 RVA: 0x0000918C File Offset: 0x0000738C
		// (set) Token: 0x06000CD1 RID: 3281 RVA: 0x00009194 File Offset: 0x00007394
		public int MeleeTotalSplats { get; set; }

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000CD2 RID: 3282 RVA: 0x0000919D File Offset: 0x0000739D
		// (set) Token: 0x06000CD3 RID: 3283 RVA: 0x000091A5 File Offset: 0x000073A5
		public int MachineGunTotalSplats { get; set; }

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000CD4 RID: 3284 RVA: 0x000091AE File Offset: 0x000073AE
		// (set) Token: 0x06000CD5 RID: 3285 RVA: 0x000091B6 File Offset: 0x000073B6
		public int ShotgunTotalSplats { get; set; }

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000CD6 RID: 3286 RVA: 0x000091BF File Offset: 0x000073BF
		// (set) Token: 0x06000CD7 RID: 3287 RVA: 0x000091C7 File Offset: 0x000073C7
		public int SniperTotalSplats { get; set; }

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000CD8 RID: 3288 RVA: 0x000091D0 File Offset: 0x000073D0
		// (set) Token: 0x06000CD9 RID: 3289 RVA: 0x000091D8 File Offset: 0x000073D8
		public int SplattergunTotalSplats { get; set; }

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000CDA RID: 3290 RVA: 0x000091E1 File Offset: 0x000073E1
		// (set) Token: 0x06000CDB RID: 3291 RVA: 0x000091E9 File Offset: 0x000073E9
		public int CannonTotalSplats { get; set; }

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000CDC RID: 3292 RVA: 0x000091F2 File Offset: 0x000073F2
		// (set) Token: 0x06000CDD RID: 3293 RVA: 0x000091FA File Offset: 0x000073FA
		public int LauncherTotalSplats { get; set; }

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000CDE RID: 3294 RVA: 0x00009203 File Offset: 0x00007403
		// (set) Token: 0x06000CDF RID: 3295 RVA: 0x0000920B File Offset: 0x0000740B
		public int MeleeTotalShotsFired { get; set; }

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000CE0 RID: 3296 RVA: 0x00009214 File Offset: 0x00007414
		// (set) Token: 0x06000CE1 RID: 3297 RVA: 0x0000921C File Offset: 0x0000741C
		public int MeleeTotalShotsHit { get; set; }

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000CE2 RID: 3298 RVA: 0x00009225 File Offset: 0x00007425
		// (set) Token: 0x06000CE3 RID: 3299 RVA: 0x0000922D File Offset: 0x0000742D
		public int MeleeTotalDamageDone { get; set; }

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000CE4 RID: 3300 RVA: 0x00009236 File Offset: 0x00007436
		// (set) Token: 0x06000CE5 RID: 3301 RVA: 0x0000923E File Offset: 0x0000743E
		public int MachineGunTotalShotsFired { get; set; }

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000CE6 RID: 3302 RVA: 0x00009247 File Offset: 0x00007447
		// (set) Token: 0x06000CE7 RID: 3303 RVA: 0x0000924F File Offset: 0x0000744F
		public int MachineGunTotalShotsHit { get; set; }

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000CE8 RID: 3304 RVA: 0x00009258 File Offset: 0x00007458
		// (set) Token: 0x06000CE9 RID: 3305 RVA: 0x00009260 File Offset: 0x00007460
		public int MachineGunTotalDamageDone { get; set; }

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000CEA RID: 3306 RVA: 0x00009269 File Offset: 0x00007469
		// (set) Token: 0x06000CEB RID: 3307 RVA: 0x00009271 File Offset: 0x00007471
		public int ShotgunTotalShotsFired { get; set; }

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000CEC RID: 3308 RVA: 0x0000927A File Offset: 0x0000747A
		// (set) Token: 0x06000CED RID: 3309 RVA: 0x00009282 File Offset: 0x00007482
		public int ShotgunTotalShotsHit { get; set; }

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000CEE RID: 3310 RVA: 0x0000928B File Offset: 0x0000748B
		// (set) Token: 0x06000CEF RID: 3311 RVA: 0x00009293 File Offset: 0x00007493
		public int ShotgunTotalDamageDone { get; set; }

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x0000929C File Offset: 0x0000749C
		// (set) Token: 0x06000CF1 RID: 3313 RVA: 0x000092A4 File Offset: 0x000074A4
		public int SniperTotalShotsFired { get; set; }

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x000092AD File Offset: 0x000074AD
		// (set) Token: 0x06000CF3 RID: 3315 RVA: 0x000092B5 File Offset: 0x000074B5
		public int SniperTotalShotsHit { get; set; }

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x000092BE File Offset: 0x000074BE
		// (set) Token: 0x06000CF5 RID: 3317 RVA: 0x000092C6 File Offset: 0x000074C6
		public int SniperTotalDamageDone { get; set; }

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x000092CF File Offset: 0x000074CF
		// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x000092D7 File Offset: 0x000074D7
		public int SplattergunTotalShotsFired { get; set; }

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x000092E0 File Offset: 0x000074E0
		// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x000092E8 File Offset: 0x000074E8
		public int SplattergunTotalShotsHit { get; set; }

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x000092F1 File Offset: 0x000074F1
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x000092F9 File Offset: 0x000074F9
		public int SplattergunTotalDamageDone { get; set; }

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x00009302 File Offset: 0x00007502
		// (set) Token: 0x06000CFD RID: 3325 RVA: 0x0000930A File Offset: 0x0000750A
		public int CannonTotalShotsFired { get; set; }

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000CFE RID: 3326 RVA: 0x00009313 File Offset: 0x00007513
		// (set) Token: 0x06000CFF RID: 3327 RVA: 0x0000931B File Offset: 0x0000751B
		public int CannonTotalShotsHit { get; set; }

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000D00 RID: 3328 RVA: 0x00009324 File Offset: 0x00007524
		// (set) Token: 0x06000D01 RID: 3329 RVA: 0x0000932C File Offset: 0x0000752C
		public int CannonTotalDamageDone { get; set; }

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000D02 RID: 3330 RVA: 0x00009335 File Offset: 0x00007535
		// (set) Token: 0x06000D03 RID: 3331 RVA: 0x0000933D File Offset: 0x0000753D
		public int LauncherTotalShotsFired { get; set; }

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000D04 RID: 3332 RVA: 0x00009346 File Offset: 0x00007546
		// (set) Token: 0x06000D05 RID: 3333 RVA: 0x0000934E File Offset: 0x0000754E
		public int LauncherTotalShotsHit { get; set; }

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000D06 RID: 3334 RVA: 0x00009357 File Offset: 0x00007557
		// (set) Token: 0x06000D07 RID: 3335 RVA: 0x0000935F File Offset: 0x0000755F
		public int LauncherTotalDamageDone { get; set; }

		// Token: 0x06000D08 RID: 3336 RVA: 0x00010AB0 File Offset: 0x0000ECB0
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[PlayerWeaponStatisticsView: ");
			stringBuilder.Append("[CannonTotalDamageDone: ");
			stringBuilder.Append(this.CannonTotalDamageDone);
			stringBuilder.Append("][CannonTotalShotsFired: ");
			stringBuilder.Append(this.CannonTotalShotsFired);
			stringBuilder.Append("][CannonTotalShotsHit: ");
			stringBuilder.Append(this.CannonTotalShotsHit);
			stringBuilder.Append("][CannonTotalSplats: ");
			stringBuilder.Append(this.CannonTotalSplats);
			stringBuilder.Append("][LauncherTotalDamageDone: ");
			stringBuilder.Append(this.LauncherTotalDamageDone);
			stringBuilder.Append("][LauncherTotalShotsFired: ");
			stringBuilder.Append(this.LauncherTotalShotsFired);
			stringBuilder.Append("][LauncherTotalShotsHit: ");
			stringBuilder.Append(this.LauncherTotalShotsHit);
			stringBuilder.Append("][LauncherTotalSplats: ");
			stringBuilder.Append(this.LauncherTotalSplats);
			stringBuilder.Append("][MachineGunTotalDamageDone: ");
			stringBuilder.Append(this.MachineGunTotalDamageDone);
			stringBuilder.Append("][MachineGunTotalShotsFired: ");
			stringBuilder.Append(this.MachineGunTotalShotsFired);
			stringBuilder.Append("][MachineGunTotalShotsHit: ");
			stringBuilder.Append(this.MachineGunTotalShotsHit);
			stringBuilder.Append("][MachineGunTotalSplats: ");
			stringBuilder.Append(this.MachineGunTotalSplats);
			stringBuilder.Append("][MeleeTotalDamageDone: ");
			stringBuilder.Append(this.MeleeTotalDamageDone);
			stringBuilder.Append("][MeleeTotalShotsFired: ");
			stringBuilder.Append(this.MeleeTotalShotsFired);
			stringBuilder.Append("][MeleeTotalShotsHit: ");
			stringBuilder.Append(this.MeleeTotalShotsHit);
			stringBuilder.Append("][MeleeTotalSplats: ");
			stringBuilder.Append(this.MeleeTotalSplats);
			stringBuilder.Append("][ShotgunTotalDamageDone: ");
			stringBuilder.Append(this.ShotgunTotalDamageDone);
			stringBuilder.Append("][ShotgunTotalShotsFired: ");
			stringBuilder.Append(this.ShotgunTotalShotsFired);
			stringBuilder.Append("][ShotgunTotalShotsHit: ");
			stringBuilder.Append(this.ShotgunTotalShotsHit);
			stringBuilder.Append("][ShotgunTotalSplats: ");
			stringBuilder.Append(this.ShotgunTotalSplats);
			stringBuilder.Append("][SniperTotalDamageDone: ");
			stringBuilder.Append(this.SniperTotalDamageDone);
			stringBuilder.Append("][SniperTotalShotsFired: ");
			stringBuilder.Append(this.SniperTotalShotsFired);
			stringBuilder.Append("][SniperTotalShotsHit: ");
			stringBuilder.Append(this.SniperTotalShotsHit);
			stringBuilder.Append("][SniperTotalSplats: ");
			stringBuilder.Append(this.SniperTotalSplats);
			stringBuilder.Append("][SplattergunTotalDamageDone: ");
			stringBuilder.Append(this.SplattergunTotalDamageDone);
			stringBuilder.Append("][SplattergunTotalShotsFired: ");
			stringBuilder.Append(this.SplattergunTotalShotsFired);
			stringBuilder.Append("][SplattergunTotalShotsHit: ");
			stringBuilder.Append(this.SplattergunTotalShotsHit);
			stringBuilder.Append("][SplattergunTotalSplats: ");
			stringBuilder.Append(this.SplattergunTotalSplats);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
