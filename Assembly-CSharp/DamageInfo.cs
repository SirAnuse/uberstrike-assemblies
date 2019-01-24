using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200021A RID: 538
public class DamageInfo
{
	// Token: 0x06000ED7 RID: 3799 RVA: 0x0000AB3F File Offset: 0x00008D3F
	public DamageInfo(short damage)
	{
		this.Damage = damage;
		this.Force = Vector3.zero;
		this.BodyPart = BodyPart.Body;
		this.Bullets = 1;
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x0000AB67 File Offset: 0x00008D67
	public DamageInfo(Vector3 force, BodyPart bodyPart)
	{
		this.Force = force;
		this.BodyPart = bodyPart;
		this.Bullets = 1;
	}

	// Token: 0x17000371 RID: 881
	// (get) Token: 0x06000ED9 RID: 3801 RVA: 0x0000AB84 File Offset: 0x00008D84
	// (set) Token: 0x06000EDA RID: 3802 RVA: 0x0000AB8C File Offset: 0x00008D8C
	public byte Bullets { get; set; }

	// Token: 0x17000372 RID: 882
	// (get) Token: 0x06000EDB RID: 3803 RVA: 0x0000AB95 File Offset: 0x00008D95
	// (set) Token: 0x06000EDC RID: 3804 RVA: 0x0000AB9D File Offset: 0x00008D9D
	public short Damage { get; set; }

	// Token: 0x17000373 RID: 883
	// (get) Token: 0x06000EDD RID: 3805 RVA: 0x0000ABA6 File Offset: 0x00008DA6
	// (set) Token: 0x06000EDE RID: 3806 RVA: 0x0000ABAE File Offset: 0x00008DAE
	public Vector3 Force { get; set; }

	// Token: 0x17000374 RID: 884
	// (get) Token: 0x06000EDF RID: 3807 RVA: 0x0000ABB7 File Offset: 0x00008DB7
	// (set) Token: 0x06000EE0 RID: 3808 RVA: 0x0000ABBF File Offset: 0x00008DBF
	public float UpwardsForceMultiplier { get; set; }

	// Token: 0x17000375 RID: 885
	// (get) Token: 0x06000EE1 RID: 3809 RVA: 0x0000ABC8 File Offset: 0x00008DC8
	// (set) Token: 0x06000EE2 RID: 3810 RVA: 0x0000ABD0 File Offset: 0x00008DD0
	public Vector3 Hitpoint { get; set; }

	// Token: 0x17000376 RID: 886
	// (get) Token: 0x06000EE3 RID: 3811 RVA: 0x0000ABD9 File Offset: 0x00008DD9
	// (set) Token: 0x06000EE4 RID: 3812 RVA: 0x0000ABE1 File Offset: 0x00008DE1
	public BodyPart BodyPart { get; set; }

	// Token: 0x17000377 RID: 887
	// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x0000ABEA File Offset: 0x00008DEA
	// (set) Token: 0x06000EE6 RID: 3814 RVA: 0x0000ABF2 File Offset: 0x00008DF2
	public int ProjectileID { get; set; }

	// Token: 0x17000378 RID: 888
	// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x0000ABFB File Offset: 0x00008DFB
	// (set) Token: 0x06000EE8 RID: 3816 RVA: 0x0000AC03 File Offset: 0x00008E03
	public int WeaponID { get; set; }

	// Token: 0x17000379 RID: 889
	// (get) Token: 0x06000EE9 RID: 3817 RVA: 0x0000AC0C File Offset: 0x00008E0C
	// (set) Token: 0x06000EEA RID: 3818 RVA: 0x0000AC14 File Offset: 0x00008E14
	public UberstrikeItemClass WeaponClass { get; set; }

	// Token: 0x1700037A RID: 890
	// (get) Token: 0x06000EEB RID: 3819 RVA: 0x0000AC1D File Offset: 0x00008E1D
	// (set) Token: 0x06000EEC RID: 3820 RVA: 0x0000AC25 File Offset: 0x00008E25
	public byte SlotId { get; set; }

	// Token: 0x1700037B RID: 891
	// (get) Token: 0x06000EED RID: 3821 RVA: 0x0000AC2E File Offset: 0x00008E2E
	// (set) Token: 0x06000EEE RID: 3822 RVA: 0x0000AC36 File Offset: 0x00008E36
	public float CriticalStrikeBonus { get; set; }

	// Token: 0x1700037C RID: 892
	// (get) Token: 0x06000EEF RID: 3823 RVA: 0x0000AC3F File Offset: 0x00008E3F
	// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x0000AC47 File Offset: 0x00008E47
	public DamageEffectType DamageEffectFlag { get; set; }

	// Token: 0x1700037D RID: 893
	// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x0000AC50 File Offset: 0x00008E50
	// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x0000AC58 File Offset: 0x00008E58
	public float DamageEffectValue { get; set; }

	// Token: 0x1700037E RID: 894
	// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x0000AC61 File Offset: 0x00008E61
	// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x0000AC69 File Offset: 0x00008E69
	public byte Distance { get; set; }

	// Token: 0x1700037F RID: 895
	// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x0000AC72 File Offset: 0x00008E72
	public bool IsExplosion
	{
		get
		{
			return this.WeaponClass == UberstrikeItemClass.WeaponCannon || this.WeaponClass == UberstrikeItemClass.WeaponLauncher;
		}
	}
}
