using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

namespace UberStrike.Core.Models
{
	// Token: 0x02000222 RID: 546
	[Synchronizable]
	[Serializable]
	public class GameActorInfo
	{
		// Token: 0x06000DF6 RID: 3574 RVA: 0x00011A2C File Offset: 0x0000FC2C
		public GameActorInfo()
		{
			this.Weapons = new List<int>
			{
				0,
				0,
				0,
				0
			};
			this.Gear = new List<int>
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			this.QuickItems = new List<int>
			{
				0,
				0,
				0
			};
			this.FunctionalItems = new List<int>
			{
				0,
				0,
				0
			};
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x00009ADA File Offset: 0x00007CDA
		// (set) Token: 0x06000DF8 RID: 3576 RVA: 0x00009AE2 File Offset: 0x00007CE2
		public int Cmid { get; set; }

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x00009AEB File Offset: 0x00007CEB
		// (set) Token: 0x06000DFA RID: 3578 RVA: 0x00009AF3 File Offset: 0x00007CF3
		public string PlayerName { get; set; }

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000DFB RID: 3579 RVA: 0x00009AFC File Offset: 0x00007CFC
		// (set) Token: 0x06000DFC RID: 3580 RVA: 0x00009B04 File Offset: 0x00007D04
		public MemberAccessLevel AccessLevel { get; set; }

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000DFD RID: 3581 RVA: 0x00009B0D File Offset: 0x00007D0D
		// (set) Token: 0x06000DFE RID: 3582 RVA: 0x00009B15 File Offset: 0x00007D15
		public ChannelType Channel { get; set; }

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000DFF RID: 3583 RVA: 0x00009B1E File Offset: 0x00007D1E
		// (set) Token: 0x06000E00 RID: 3584 RVA: 0x00009B26 File Offset: 0x00007D26
		public string ClanTag { get; set; }

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x06000E01 RID: 3585 RVA: 0x00009B2F File Offset: 0x00007D2F
		// (set) Token: 0x06000E02 RID: 3586 RVA: 0x00009B37 File Offset: 0x00007D37
		public byte Rank { get; set; }

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06000E03 RID: 3587 RVA: 0x00009B40 File Offset: 0x00007D40
		// (set) Token: 0x06000E04 RID: 3588 RVA: 0x00009B48 File Offset: 0x00007D48
		public byte PlayerId { get; set; }

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000E05 RID: 3589 RVA: 0x00009B51 File Offset: 0x00007D51
		// (set) Token: 0x06000E06 RID: 3590 RVA: 0x00009B59 File Offset: 0x00007D59
		public PlayerStates PlayerState { get; set; }

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000E07 RID: 3591 RVA: 0x00009B62 File Offset: 0x00007D62
		// (set) Token: 0x06000E08 RID: 3592 RVA: 0x00009B6A File Offset: 0x00007D6A
		public short Health { get; set; }

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000E09 RID: 3593 RVA: 0x00009B73 File Offset: 0x00007D73
		// (set) Token: 0x06000E0A RID: 3594 RVA: 0x00009B7B File Offset: 0x00007D7B
		public TeamID TeamID { get; set; }

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x00009B84 File Offset: 0x00007D84
		// (set) Token: 0x06000E0C RID: 3596 RVA: 0x00009B8C File Offset: 0x00007D8C
		public int Level { get; set; }

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00009B95 File Offset: 0x00007D95
		// (set) Token: 0x06000E0E RID: 3598 RVA: 0x00009B9D File Offset: 0x00007D9D
		public ushort Ping { get; set; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x00009BA6 File Offset: 0x00007DA6
		// (set) Token: 0x06000E10 RID: 3600 RVA: 0x00009BAE File Offset: 0x00007DAE
		public byte CurrentWeaponSlot { get; set; }

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000E11 RID: 3601 RVA: 0x00009BB7 File Offset: 0x00007DB7
		// (set) Token: 0x06000E12 RID: 3602 RVA: 0x00009BBF File Offset: 0x00007DBF
		public FireMode CurrentFiringMode { get; set; }

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000E13 RID: 3603 RVA: 0x00009BC8 File Offset: 0x00007DC8
		// (set) Token: 0x06000E14 RID: 3604 RVA: 0x00009BD0 File Offset: 0x00007DD0
		public byte ArmorPoints { get; set; }

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000E15 RID: 3605 RVA: 0x00009BD9 File Offset: 0x00007DD9
		// (set) Token: 0x06000E16 RID: 3606 RVA: 0x00009BE1 File Offset: 0x00007DE1
		public byte ArmorPointCapacity { get; set; }

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000E17 RID: 3607 RVA: 0x00009BEA File Offset: 0x00007DEA
		// (set) Token: 0x06000E18 RID: 3608 RVA: 0x00009BF2 File Offset: 0x00007DF2
		public Color SkinColor { get; set; }

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000E19 RID: 3609 RVA: 0x00009BFB File Offset: 0x00007DFB
		// (set) Token: 0x06000E1A RID: 3610 RVA: 0x00009C03 File Offset: 0x00007E03
		public short Kills { get; set; }

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000E1B RID: 3611 RVA: 0x00009C0C File Offset: 0x00007E0C
		// (set) Token: 0x06000E1C RID: 3612 RVA: 0x00009C14 File Offset: 0x00007E14
		public short Deaths { get; set; }

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000E1D RID: 3613 RVA: 0x00009C1D File Offset: 0x00007E1D
		// (set) Token: 0x06000E1E RID: 3614 RVA: 0x00009C25 File Offset: 0x00007E25
		public List<int> Weapons { get; set; }

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000E1F RID: 3615 RVA: 0x00009C2E File Offset: 0x00007E2E
		// (set) Token: 0x06000E20 RID: 3616 RVA: 0x00009C36 File Offset: 0x00007E36
		public List<int> Gear { get; set; }

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000E21 RID: 3617 RVA: 0x00009C3F File Offset: 0x00007E3F
		// (set) Token: 0x06000E22 RID: 3618 RVA: 0x00009C47 File Offset: 0x00007E47
		public List<int> FunctionalItems { get; set; }

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000E23 RID: 3619 RVA: 0x00009C50 File Offset: 0x00007E50
		// (set) Token: 0x06000E24 RID: 3620 RVA: 0x00009C58 File Offset: 0x00007E58
		public List<int> QuickItems { get; set; }

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06000E25 RID: 3621 RVA: 0x00009C61 File Offset: 0x00007E61
		// (set) Token: 0x06000E26 RID: 3622 RVA: 0x00009C69 File Offset: 0x00007E69
		public SurfaceType StepSound { get; set; }

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000E27 RID: 3623 RVA: 0x00009C72 File Offset: 0x00007E72
		public bool IsFiring
		{
			get
			{
				return this.Is(PlayerStates.Shooting);
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000E28 RID: 3624 RVA: 0x00009C7C File Offset: 0x00007E7C
		public bool IsReadyForGame
		{
			get
			{
				return this.Is(PlayerStates.Ready);
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000E29 RID: 3625 RVA: 0x00009C86 File Offset: 0x00007E86
		public bool IsOnline
		{
			get
			{
				return !this.Is(PlayerStates.Offline);
			}
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x00009C93 File Offset: 0x00007E93
		public bool Is(PlayerStates state)
		{
			return (byte)(this.PlayerState & state) != 0;
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000E2B RID: 3627 RVA: 0x00009CA4 File Offset: 0x00007EA4
		public int CurrentWeaponID
		{
			get
			{
				return (this.Weapons == null || this.Weapons.Count <= (int)this.CurrentWeaponSlot) ? 0 : this.Weapons[(int)this.CurrentWeaponSlot];
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000E2C RID: 3628 RVA: 0x00009CDE File Offset: 0x00007EDE
		public bool IsAlive
		{
			get
			{
				return (byte)(this.PlayerState & PlayerStates.Dead) == 0;
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000E2D RID: 3629 RVA: 0x00009CEC File Offset: 0x00007EEC
		public bool IsSpectator
		{
			get
			{
				return (byte)(this.PlayerState & PlayerStates.Spectator) != 0;
			}
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00009CFD File Offset: 0x00007EFD
		public float GetAbsorptionRate()
		{
			return 0.66f;
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00011AEC File Offset: 0x0000FCEC
		public void Damage(short damage, BodyPart part, out short healthDamage, out byte armorDamage)
		{
			if (this.ArmorPoints > 0)
			{
				int value = Mathf.CeilToInt(this.GetAbsorptionRate() * (float)damage);
				armorDamage = (byte)Mathf.Clamp(value, 0, (int)this.ArmorPoints);
				healthDamage = (short)(damage - (short)armorDamage);
			}
			else
			{
				armorDamage = 0;
				healthDamage = damage;
			}
		}
	}
}
