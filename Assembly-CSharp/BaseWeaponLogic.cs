using System;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000460 RID: 1120
public abstract class BaseWeaponLogic : IWeaponLogic
{
	// Token: 0x06001FE9 RID: 8169 RVA: 0x00015070 File Offset: 0x00013270
	protected BaseWeaponLogic(WeaponItem item, IWeaponController controller)
	{
		this.Controller = controller;
		this.Config = item.Configuration;
	}

	// Token: 0x1400002D RID: 45
	// (add) Token: 0x06001FEA RID: 8170 RVA: 0x0001508B File Offset: 0x0001328B
	// (remove) Token: 0x06001FEB RID: 8171 RVA: 0x000150A4 File Offset: 0x000132A4
	public event Action<CmunePairList<BaseGameProp, ShotPoint>> OnTargetHit;

	// Token: 0x170006D7 RID: 1751
	// (get) Token: 0x06001FEC RID: 8172 RVA: 0x000150BD File Offset: 0x000132BD
	// (set) Token: 0x06001FED RID: 8173 RVA: 0x000150C5 File Offset: 0x000132C5
	public IWeaponController Controller { get; private set; }

	// Token: 0x170006D8 RID: 1752
	// (get) Token: 0x06001FEE RID: 8174 RVA: 0x000150CE File Offset: 0x000132CE
	// (set) Token: 0x06001FEF RID: 8175 RVA: 0x000150D6 File Offset: 0x000132D6
	public WeaponItemConfiguration Config { get; private set; }

	// Token: 0x170006D9 RID: 1753
	// (get) Token: 0x06001FF0 RID: 8176
	public abstract BaseWeaponDecorator Decorator { get; }

	// Token: 0x170006DA RID: 1754
	// (get) Token: 0x06001FF1 RID: 8177 RVA: 0x00004D4D File Offset: 0x00002F4D
	public virtual int AmmoCountPerShot
	{
		get
		{
			return 1;
		}
	}

	// Token: 0x170006DB RID: 1755
	// (get) Token: 0x06001FF2 RID: 8178 RVA: 0x0000B716 File Offset: 0x00009916
	public virtual float HitDelay
	{
		get
		{
			return 0f;
		}
	}

	// Token: 0x170006DC RID: 1756
	// (get) Token: 0x06001FF3 RID: 8179 RVA: 0x000150DF File Offset: 0x000132DF
	// (set) Token: 0x06001FF4 RID: 8180 RVA: 0x000150E7 File Offset: 0x000132E7
	public bool IsWeaponReady { get; private set; }

	// Token: 0x170006DD RID: 1757
	// (get) Token: 0x06001FF5 RID: 8181 RVA: 0x000150F0 File Offset: 0x000132F0
	// (set) Token: 0x06001FF6 RID: 8182 RVA: 0x000150F8 File Offset: 0x000132F8
	public bool IsWeaponActive { get; set; }

	// Token: 0x06001FF7 RID: 8183
	public abstract void Shoot(Ray ray, out CmunePairList<BaseGameProp, ShotPoint> hits);

	// Token: 0x06001FF8 RID: 8184 RVA: 0x00015101 File Offset: 0x00013301
	protected void OnHits(CmunePairList<BaseGameProp, ShotPoint> hits)
	{
		if (this.OnTargetHit != null)
		{
			this.OnTargetHit(hits);
		}
	}
}
