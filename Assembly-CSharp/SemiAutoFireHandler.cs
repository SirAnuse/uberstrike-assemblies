using System;
using UnityEngine;

// Token: 0x0200043F RID: 1087
public class SemiAutoFireHandler : IWeaponFireHandler
{
	// Token: 0x06001EEA RID: 7914 RVA: 0x000146C1 File Offset: 0x000128C1
	public SemiAutoFireHandler(BaseWeaponDecorator weapon, float frequency)
	{
		this.frequency = frequency;
		this._weapon = weapon;
		this.IsTriggerPulled = false;
	}

	// Token: 0x17000698 RID: 1688
	// (get) Token: 0x06001EEB RID: 7915 RVA: 0x000146DE File Offset: 0x000128DE
	// (set) Token: 0x06001EEC RID: 7916 RVA: 0x000146E6 File Offset: 0x000128E6
	public bool IsTriggerPulled { get; private set; }

	// Token: 0x06001EED RID: 7917 RVA: 0x000146EF File Offset: 0x000128EF
	public void OnTriggerPulled(bool pulled)
	{
		if (pulled && !this.IsTriggerPulled && Singleton<WeaponController>.Instance.Shoot())
		{
			this._weapon.PostShoot();
		}
		this.IsTriggerPulled = pulled;
	}

	// Token: 0x06001EEE RID: 7918 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Update()
	{
	}

	// Token: 0x06001EEF RID: 7919 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Stop()
	{
	}

	// Token: 0x17000699 RID: 1689
	// (get) Token: 0x06001EF0 RID: 7920 RVA: 0x00014723 File Offset: 0x00012923
	public bool CanShoot
	{
		get
		{
			return this.nextShootTime < Time.time;
		}
	}

	// Token: 0x06001EF1 RID: 7921 RVA: 0x00014732 File Offset: 0x00012932
	public void RegisterShot()
	{
		this.nextShootTime = Time.time + this.frequency;
	}

	// Token: 0x04001A8D RID: 6797
	private BaseWeaponDecorator _weapon;

	// Token: 0x04001A8E RID: 6798
	private float frequency;

	// Token: 0x04001A8F RID: 6799
	private float nextShootTime;
}
