using System;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class IronsightInputHandler : WeaponInputHandler
{
	// Token: 0x06001F00 RID: 7936 RVA: 0x00095EA0 File Offset: 0x000940A0
	public IronsightInputHandler(IWeaponLogic logic, bool isLocal, ZoomInfo zoomInfo, UberStrikeItemWeaponView view) : base(logic, isLocal)
	{
		this._zoomInfo = zoomInfo;
		if (view.HasAutomaticFire)
		{
			base.FireHandler = new FullAutoFireHandler(logic.Decorator, WeaponConfigurationHelper.GetRateOfFire(view));
		}
		else
		{
			base.FireHandler = new SemiAutoFireHandler(logic.Decorator, WeaponConfigurationHelper.GetRateOfFire(view));
		}
	}

	// Token: 0x06001F01 RID: 7937 RVA: 0x000147B0 File Offset: 0x000129B0
	public override void OnSecondaryFire(bool pressed)
	{
		this._isIronsight = pressed;
	}

	// Token: 0x06001F02 RID: 7938 RVA: 0x00095F00 File Offset: 0x00094100
	public override void Update()
	{
		base.FireHandler.Update();
		this.UpdateIronsight();
		if (this._isIronsight)
		{
			if (!LevelCamera.IsZoomedIn)
			{
				WeaponInputHandler.ZoomIn(this._zoomInfo, this._weaponLogic.Decorator, 0f, false);
			}
		}
		else if (LevelCamera.IsZoomedIn)
		{
			WeaponInputHandler.ZoomOut(this._zoomInfo, this._weaponLogic.Decorator);
		}
		if (!this._isIronsight && this._ironSightDelay > 0f)
		{
			this._ironSightDelay -= Time.deltaTime;
		}
	}

	// Token: 0x06001F03 RID: 7939 RVA: 0x00095FA4 File Offset: 0x000941A4
	public override void Stop()
	{
		base.FireHandler.Stop();
		if (this._isIronsight)
		{
			this._isIronsight = false;
			if (this._isLocal)
			{
				LevelCamera.ResetZoom();
			}
			if (WeaponFeedbackManager.Instance.IsIronSighted)
			{
				WeaponFeedbackManager.Instance.ResetIronSight();
			}
		}
	}

	// Token: 0x06001F04 RID: 7940 RVA: 0x000147B9 File Offset: 0x000129B9
	public override bool CanChangeWeapon()
	{
		return !this._isIronsight && this._ironSightDelay <= 0f;
	}

	// Token: 0x06001F05 RID: 7941 RVA: 0x00095FF8 File Offset: 0x000941F8
	private void UpdateIronsight()
	{
		if (this._isIronsight)
		{
			if (!WeaponFeedbackManager.Instance.IsIronSighted)
			{
				WeaponFeedbackManager.Instance.BeginIronSight();
			}
		}
		else if (WeaponFeedbackManager.Instance.IsIronSighted)
		{
			WeaponFeedbackManager.Instance.EndIronSight();
		}
	}

	// Token: 0x06001F06 RID: 7942 RVA: 0x0001476F File Offset: 0x0001296F
	public override void OnPrimaryFire(bool pressed)
	{
		base.FireHandler.OnTriggerPulled(pressed);
	}

	// Token: 0x06001F07 RID: 7943 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPrevWeapon()
	{
	}

	// Token: 0x06001F08 RID: 7944 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnNextWeapon()
	{
	}

	// Token: 0x04001A96 RID: 6806
	protected bool _isIronsight;

	// Token: 0x04001A97 RID: 6807
	protected float _ironSightDelay;
}
