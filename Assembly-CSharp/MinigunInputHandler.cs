using System;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class MinigunInputHandler : WeaponInputHandler
{
	// Token: 0x06001F09 RID: 7945 RVA: 0x000147D9 File Offset: 0x000129D9
	public MinigunInputHandler(IWeaponLogic logic, bool isLocal, MinigunWeaponDecorator weapon, UberStrikeItemWeaponView view) : base(logic, isLocal)
	{
		this._weapon = weapon;
		base.FireHandler = new FullAutoFireHandler(weapon, WeaponConfigurationHelper.GetRateOfFire(view));
	}

	// Token: 0x06001F0A RID: 7946 RVA: 0x00096048 File Offset: 0x00094248
	public override void Update()
	{
		if (!this._weapon)
		{
			return;
		}
		if (this._warmTime < this._weapon.MaxWarmUpTime)
		{
			if (this._isGunWarm || this._isTriggerPulled)
			{
				if (!this._isWarmupPlayed)
				{
					this._isWarmupPlayed = true;
					this._weapon.PlayWindUpSound(this._warmTime);
				}
				this._warmTime += Time.deltaTime;
				if (this._warmTime >= this._weapon.MaxWarmUpTime)
				{
					this._weapon.PlayDuringSound();
				}
				this._weapon.SpinWeaponHead();
			}
			base.FireHandler.OnTriggerPulled(false);
		}
		else if (this._isTriggerPulled)
		{
			base.FireHandler.OnTriggerPulled(true);
		}
		else if (this._isGunWarm)
		{
			this._weapon.SpinWeaponHead();
			base.FireHandler.OnTriggerPulled(false);
		}
		else
		{
			base.FireHandler.OnTriggerPulled(false);
		}
		if (!this._isGunWarm && !this._isTriggerPulled)
		{
			if (this._warmTime > 0f)
			{
				this._warmTime -= Time.deltaTime;
				if (this._warmTime < 0f)
				{
					this._warmTime = 0f;
				}
				if (this._isWarmupPlayed)
				{
					this._weapon.PlayWindDownSound((1f - this._warmTime / this._weapon.MaxWarmUpTime) * this._weapon.MaxWarmDownTime);
				}
			}
			this._isWarmupPlayed = false;
		}
		base.FireHandler.Update();
	}

	// Token: 0x06001F0B RID: 7947 RVA: 0x000147FD File Offset: 0x000129FD
	public override void OnSecondaryFire(bool pressed)
	{
		this._isGunWarm = pressed;
	}

	// Token: 0x06001F0C RID: 7948 RVA: 0x00014806 File Offset: 0x00012A06
	public override bool CanChangeWeapon()
	{
		return !this._isGunWarm;
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x000961F4 File Offset: 0x000943F4
	public override void Stop()
	{
		this._warmTime = 0f;
		this._isGunWarm = false;
		this._isWarmupPlayed = false;
		this._isTriggerPulled = false;
		base.FireHandler.Stop();
		if (this._weapon)
		{
			this._weapon.StopSound();
		}
	}

	// Token: 0x06001F0E RID: 7950 RVA: 0x00014811 File Offset: 0x00012A11
	public override void OnPrimaryFire(bool pressed)
	{
		this._isTriggerPulled = pressed;
	}

	// Token: 0x06001F0F RID: 7951 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPrevWeapon()
	{
	}

	// Token: 0x06001F10 RID: 7952 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnNextWeapon()
	{
	}

	// Token: 0x04001A98 RID: 6808
	protected bool _isGunWarm;

	// Token: 0x04001A99 RID: 6809
	protected bool _isWarmupPlayed;

	// Token: 0x04001A9A RID: 6810
	protected float _warmTime;

	// Token: 0x04001A9B RID: 6811
	private bool _isTriggerPulled;

	// Token: 0x04001A9C RID: 6812
	private MinigunWeaponDecorator _weapon;
}
