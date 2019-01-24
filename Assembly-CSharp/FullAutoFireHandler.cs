using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x0200043C RID: 1084
public class FullAutoFireHandler : IWeaponFireHandler
{
	// Token: 0x06001ED2 RID: 7890 RVA: 0x000145EA File Offset: 0x000127EA
	public FullAutoFireHandler(BaseWeaponDecorator weapon, float frequency)
	{
		this.weapon = weapon;
		this.frequency = frequency;
	}

	// Token: 0x17000691 RID: 1681
	// (get) Token: 0x06001ED3 RID: 7891 RVA: 0x00014600 File Offset: 0x00012800
	// (set) Token: 0x06001ED4 RID: 7892 RVA: 0x00014608 File Offset: 0x00012808
	public bool IsTriggerPulled { get; private set; }

	// Token: 0x17000692 RID: 1682
	// (get) Token: 0x06001ED5 RID: 7893 RVA: 0x00014611 File Offset: 0x00012811
	// (set) Token: 0x06001ED6 RID: 7894 RVA: 0x00014619 File Offset: 0x00012819
	public bool IsShooting { get; private set; }

	// Token: 0x06001ED7 RID: 7895 RVA: 0x00014622 File Offset: 0x00012822
	public void OnTriggerPulled(bool pulled)
	{
		this.IsTriggerPulled = pulled;
	}

	// Token: 0x06001ED8 RID: 7896 RVA: 0x00095D6C File Offset: 0x00093F6C
	public void Update()
	{
		if (this.IsTriggerPulled && !this.IsShooting && this.CanShoot && Singleton<WeaponController>.Instance.CheckAmmoCount())
		{
			GameState.Current.PlayerData.Set(PlayerStates.Shooting, true);
			this.IsShooting = true;
			this.shootingStartTime = Time.time;
			this.shootCounter = 0;
		}
		if (this.IsShooting)
		{
			Singleton<WeaponController>.Instance.Shoot();
		}
		if (this.IsShooting && (!this.IsTriggerPulled || !Singleton<WeaponController>.Instance.CheckAmmoCount()))
		{
			GameState.Current.PlayerData.Set(PlayerStates.Shooting, false);
			this.IsShooting = false;
			if (this.weapon)
			{
				this.weapon.PostShoot();
			}
		}
	}

	// Token: 0x06001ED9 RID: 7897 RVA: 0x0001462B File Offset: 0x0001282B
	public void Stop()
	{
		GameState.Current.PlayerData.Set(PlayerStates.Shooting, false);
		this.IsTriggerPulled = false;
		this.IsShooting = false;
	}

	// Token: 0x17000693 RID: 1683
	// (get) Token: 0x06001EDA RID: 7898 RVA: 0x0001464D File Offset: 0x0001284D
	public bool CanShoot
	{
		get
		{
			return this.shootingStartTime + this.frequency * (float)this.shootCounter <= Time.time;
		}
	}

	// Token: 0x06001EDB RID: 7899 RVA: 0x0001466E File Offset: 0x0001286E
	public void RegisterShot()
	{
		this.shootCounter++;
	}

	// Token: 0x04001A86 RID: 6790
	private BaseWeaponDecorator weapon;

	// Token: 0x04001A87 RID: 6791
	private float frequency;

	// Token: 0x04001A88 RID: 6792
	private float shootingStartTime;

	// Token: 0x04001A89 RID: 6793
	private int shootCounter;
}
