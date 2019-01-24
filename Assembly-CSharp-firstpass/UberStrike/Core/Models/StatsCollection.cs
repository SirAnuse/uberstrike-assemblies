using System;

namespace UberStrike.Core.Models
{
	// Token: 0x02000228 RID: 552
	[Serializable]
	public class StatsCollection
	{
		// Token: 0x06000E69 RID: 3689 RVA: 0x00009EC8 File Offset: 0x000080C8
		public int GetKills()
		{
			return this.MeleeKills + this.MachineGunKills + this.ShotgunSplats + this.SniperKills + this.SplattergunKills + this.CannonKills + this.LauncherKills - this.Suicides;
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x00009F01 File Offset: 0x00008101
		public int GetShots()
		{
			return this.MeleeShotsFired + this.MachineGunShotsFired + this.ShotgunShotsFired + this.SniperShotsFired + this.SplattergunShotsFired + this.CannonShotsFired + this.LauncherShotsFired;
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00009F33 File Offset: 0x00008133
		public int GetHits()
		{
			return this.MeleeShotsHit + this.MachineGunShotsHit + this.ShotgunShotsHit + this.SniperShotsHit + this.SplattergunShotsHit + this.CannonShotsHit + this.LauncherShotsHit;
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x00009F65 File Offset: 0x00008165
		public int GetDamageDealt()
		{
			return this.MeleeDamageDone + this.MachineGunDamageDone + this.ShotgunDamageDone + this.SniperDamageDone + this.SplattergunDamageDone + this.CannonDamageDone + this.LauncherDamageDone;
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000E6D RID: 3693 RVA: 0x00009F97 File Offset: 0x00008197
		// (set) Token: 0x06000E6E RID: 3694 RVA: 0x00009F9F File Offset: 0x0000819F
		public int Headshots { get; set; }

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000E6F RID: 3695 RVA: 0x00009FA8 File Offset: 0x000081A8
		// (set) Token: 0x06000E70 RID: 3696 RVA: 0x00009FB0 File Offset: 0x000081B0
		public int Nutshots { get; set; }

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000E71 RID: 3697 RVA: 0x00009FB9 File Offset: 0x000081B9
		// (set) Token: 0x06000E72 RID: 3698 RVA: 0x00009FC1 File Offset: 0x000081C1
		public int ConsecutiveSnipes { get; set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000E73 RID: 3699 RVA: 0x00009FCA File Offset: 0x000081CA
		// (set) Token: 0x06000E74 RID: 3700 RVA: 0x00009FD2 File Offset: 0x000081D2
		public int Xp { get; set; }

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000E75 RID: 3701 RVA: 0x00009FDB File Offset: 0x000081DB
		// (set) Token: 0x06000E76 RID: 3702 RVA: 0x00009FE3 File Offset: 0x000081E3
		public int Deaths { get; set; }

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000E77 RID: 3703 RVA: 0x00009FEC File Offset: 0x000081EC
		// (set) Token: 0x06000E78 RID: 3704 RVA: 0x00009FF4 File Offset: 0x000081F4
		public int DamageReceived { get; set; }

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000E79 RID: 3705 RVA: 0x00009FFD File Offset: 0x000081FD
		// (set) Token: 0x06000E7A RID: 3706 RVA: 0x0000A005 File Offset: 0x00008205
		public int ArmorPickedUp { get; set; }

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000E7B RID: 3707 RVA: 0x0000A00E File Offset: 0x0000820E
		// (set) Token: 0x06000E7C RID: 3708 RVA: 0x0000A016 File Offset: 0x00008216
		public int HealthPickedUp { get; set; }

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000E7D RID: 3709 RVA: 0x0000A01F File Offset: 0x0000821F
		// (set) Token: 0x06000E7E RID: 3710 RVA: 0x0000A027 File Offset: 0x00008227
		public int MeleeKills { get; set; }

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000E7F RID: 3711 RVA: 0x0000A030 File Offset: 0x00008230
		// (set) Token: 0x06000E80 RID: 3712 RVA: 0x0000A038 File Offset: 0x00008238
		public int MeleeShotsFired { get; set; }

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000E81 RID: 3713 RVA: 0x0000A041 File Offset: 0x00008241
		// (set) Token: 0x06000E82 RID: 3714 RVA: 0x0000A049 File Offset: 0x00008249
		public int MeleeShotsHit { get; set; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000E83 RID: 3715 RVA: 0x0000A052 File Offset: 0x00008252
		// (set) Token: 0x06000E84 RID: 3716 RVA: 0x0000A05A File Offset: 0x0000825A
		public int MeleeDamageDone { get; set; }

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000E85 RID: 3717 RVA: 0x0000A063 File Offset: 0x00008263
		// (set) Token: 0x06000E86 RID: 3718 RVA: 0x0000A06B File Offset: 0x0000826B
		public int MachineGunKills { get; set; }

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000E87 RID: 3719 RVA: 0x0000A074 File Offset: 0x00008274
		// (set) Token: 0x06000E88 RID: 3720 RVA: 0x0000A07C File Offset: 0x0000827C
		public int MachineGunShotsFired { get; set; }

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000E89 RID: 3721 RVA: 0x0000A085 File Offset: 0x00008285
		// (set) Token: 0x06000E8A RID: 3722 RVA: 0x0000A08D File Offset: 0x0000828D
		public int MachineGunShotsHit { get; set; }

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000E8B RID: 3723 RVA: 0x0000A096 File Offset: 0x00008296
		// (set) Token: 0x06000E8C RID: 3724 RVA: 0x0000A09E File Offset: 0x0000829E
		public int MachineGunDamageDone { get; set; }

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000E8D RID: 3725 RVA: 0x0000A0A7 File Offset: 0x000082A7
		// (set) Token: 0x06000E8E RID: 3726 RVA: 0x0000A0AF File Offset: 0x000082AF
		public int ShotgunSplats { get; set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000E8F RID: 3727 RVA: 0x0000A0B8 File Offset: 0x000082B8
		// (set) Token: 0x06000E90 RID: 3728 RVA: 0x0000A0C0 File Offset: 0x000082C0
		public int ShotgunShotsFired { get; set; }

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000E91 RID: 3729 RVA: 0x0000A0C9 File Offset: 0x000082C9
		// (set) Token: 0x06000E92 RID: 3730 RVA: 0x0000A0D1 File Offset: 0x000082D1
		public int ShotgunShotsHit { get; set; }

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000E93 RID: 3731 RVA: 0x0000A0DA File Offset: 0x000082DA
		// (set) Token: 0x06000E94 RID: 3732 RVA: 0x0000A0E2 File Offset: 0x000082E2
		public int ShotgunDamageDone { get; set; }

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000E95 RID: 3733 RVA: 0x0000A0EB File Offset: 0x000082EB
		// (set) Token: 0x06000E96 RID: 3734 RVA: 0x0000A0F3 File Offset: 0x000082F3
		public int SniperKills { get; set; }

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000E97 RID: 3735 RVA: 0x0000A0FC File Offset: 0x000082FC
		// (set) Token: 0x06000E98 RID: 3736 RVA: 0x0000A104 File Offset: 0x00008304
		public int SniperShotsFired { get; set; }

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000E99 RID: 3737 RVA: 0x0000A10D File Offset: 0x0000830D
		// (set) Token: 0x06000E9A RID: 3738 RVA: 0x0000A115 File Offset: 0x00008315
		public int SniperShotsHit { get; set; }

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000E9B RID: 3739 RVA: 0x0000A11E File Offset: 0x0000831E
		// (set) Token: 0x06000E9C RID: 3740 RVA: 0x0000A126 File Offset: 0x00008326
		public int SniperDamageDone { get; set; }

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000E9D RID: 3741 RVA: 0x0000A12F File Offset: 0x0000832F
		// (set) Token: 0x06000E9E RID: 3742 RVA: 0x0000A137 File Offset: 0x00008337
		public int SplattergunKills { get; set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000E9F RID: 3743 RVA: 0x0000A140 File Offset: 0x00008340
		// (set) Token: 0x06000EA0 RID: 3744 RVA: 0x0000A148 File Offset: 0x00008348
		public int SplattergunShotsFired { get; set; }

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000EA1 RID: 3745 RVA: 0x0000A151 File Offset: 0x00008351
		// (set) Token: 0x06000EA2 RID: 3746 RVA: 0x0000A159 File Offset: 0x00008359
		public int SplattergunShotsHit { get; set; }

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000EA3 RID: 3747 RVA: 0x0000A162 File Offset: 0x00008362
		// (set) Token: 0x06000EA4 RID: 3748 RVA: 0x0000A16A File Offset: 0x0000836A
		public int SplattergunDamageDone { get; set; }

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000EA5 RID: 3749 RVA: 0x0000A173 File Offset: 0x00008373
		// (set) Token: 0x06000EA6 RID: 3750 RVA: 0x0000A17B File Offset: 0x0000837B
		public int CannonKills { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x0000A184 File Offset: 0x00008384
		// (set) Token: 0x06000EA8 RID: 3752 RVA: 0x0000A18C File Offset: 0x0000838C
		public int CannonShotsFired { get; set; }

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000EA9 RID: 3753 RVA: 0x0000A195 File Offset: 0x00008395
		// (set) Token: 0x06000EAA RID: 3754 RVA: 0x0000A19D File Offset: 0x0000839D
		public int CannonShotsHit { get; set; }

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000EAB RID: 3755 RVA: 0x0000A1A6 File Offset: 0x000083A6
		// (set) Token: 0x06000EAC RID: 3756 RVA: 0x0000A1AE File Offset: 0x000083AE
		public int CannonDamageDone { get; set; }

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000EAD RID: 3757 RVA: 0x0000A1B7 File Offset: 0x000083B7
		// (set) Token: 0x06000EAE RID: 3758 RVA: 0x0000A1BF File Offset: 0x000083BF
		public int LauncherKills { get; set; }

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000EAF RID: 3759 RVA: 0x0000A1C8 File Offset: 0x000083C8
		// (set) Token: 0x06000EB0 RID: 3760 RVA: 0x0000A1D0 File Offset: 0x000083D0
		public int LauncherShotsFired { get; set; }

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000EB1 RID: 3761 RVA: 0x0000A1D9 File Offset: 0x000083D9
		// (set) Token: 0x06000EB2 RID: 3762 RVA: 0x0000A1E1 File Offset: 0x000083E1
		public int LauncherShotsHit { get; set; }

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x0000A1EA File Offset: 0x000083EA
		// (set) Token: 0x06000EB4 RID: 3764 RVA: 0x0000A1F2 File Offset: 0x000083F2
		public int LauncherDamageDone { get; set; }

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x0000A1FB File Offset: 0x000083FB
		// (set) Token: 0x06000EB6 RID: 3766 RVA: 0x0000A203 File Offset: 0x00008403
		public int Suicides { get; set; }

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000EB7 RID: 3767 RVA: 0x0000A20C File Offset: 0x0000840C
		// (set) Token: 0x06000EB8 RID: 3768 RVA: 0x0000A214 File Offset: 0x00008414
		public int Points { get; set; }
	}
}
