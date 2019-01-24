using System;
using UberStrike.Core.Models.Views;

// Token: 0x02000445 RID: 1093
public class SniperRifleInputHandler : WeaponInputHandler
{
	// Token: 0x06001F11 RID: 7953 RVA: 0x00095EA0 File Offset: 0x000940A0
	public SniperRifleInputHandler(IWeaponLogic logic, bool isLocal, ZoomInfo zoomInfo, UberStrikeItemWeaponView view) : base(logic, isLocal)
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

	// Token: 0x06001F12 RID: 7954 RVA: 0x0001481A File Offset: 0x00012A1A
	public override void OnSecondaryFire(bool pressed)
	{
		this._scopeOpen = pressed;
		this.Update();
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x00014829 File Offset: 0x00012A29
	public override void OnPrevWeapon()
	{
		this._zoom = -4f;
	}

	// Token: 0x06001F14 RID: 7956 RVA: 0x00014836 File Offset: 0x00012A36
	public override void OnNextWeapon()
	{
		this._zoom = 4f;
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x00096248 File Offset: 0x00094448
	public override void Update()
	{
		base.FireHandler.Update();
		if (this._scopeOpen)
		{
			if (!LevelCamera.IsZoomedIn || this._zoom != 0f)
			{
				WeaponInputHandler.ZoomIn(this._zoomInfo, this._weaponLogic.Decorator, this._zoom, true);
				this._zoom = 0f;
				global::EventHandler.Global.Fire(new GameEvents.PlayerZoomIn());
				GameState.Current.PlayerData.IsZoomedIn.Value = true;
			}
		}
		else if (LevelCamera.IsZoomedIn)
		{
			WeaponInputHandler.ZoomOut(this._zoomInfo, this._weaponLogic.Decorator);
			GameState.Current.PlayerData.IsZoomedIn.Value = false;
		}
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x00014843 File Offset: 0x00012A43
	public override bool CanChangeWeapon()
	{
		return !this._scopeOpen;
	}

	// Token: 0x06001F17 RID: 7959 RVA: 0x0001484E File Offset: 0x00012A4E
	public override void Stop()
	{
		base.FireHandler.Stop();
		if (this._scopeOpen)
		{
			this._scopeOpen = false;
			if (this._isLocal)
			{
				LevelCamera.ResetZoom();
			}
		}
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x0001476F File Offset: 0x0001296F
	public override void OnPrimaryFire(bool pressed)
	{
		base.FireHandler.OnTriggerPulled(pressed);
	}

	// Token: 0x04001A9D RID: 6813
	protected const float ZOOM = 4f;

	// Token: 0x04001A9E RID: 6814
	protected bool _scopeOpen;

	// Token: 0x04001A9F RID: 6815
	protected float _zoom;
}
