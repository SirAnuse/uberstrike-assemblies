using System;
using UberStrike.Core.Models.Views;

// Token: 0x02000442 RID: 1090
public class DefaultWeaponInputHandler : WeaponInputHandler
{
	// Token: 0x06001EF8 RID: 7928 RVA: 0x00095E44 File Offset: 0x00094044
	public DefaultWeaponInputHandler(IWeaponLogic logic, bool isLocal, UberStrikeItemWeaponView view, IWeaponFireHandler secondaryFireHandler = null) : base(logic, isLocal)
	{
		if (view.HasAutomaticFire)
		{
			base.FireHandler = new FullAutoFireHandler(logic.Decorator, WeaponConfigurationHelper.GetRateOfFire(view));
		}
		else
		{
			base.FireHandler = new SemiAutoFireHandler(logic.Decorator, WeaponConfigurationHelper.GetRateOfFire(view));
		}
		this._secondaryFireHandler = secondaryFireHandler;
	}

	// Token: 0x06001EF9 RID: 7929 RVA: 0x0001476F File Offset: 0x0001296F
	public override void OnPrimaryFire(bool pressed)
	{
		base.FireHandler.OnTriggerPulled(pressed);
	}

	// Token: 0x06001EFA RID: 7930 RVA: 0x0001477D File Offset: 0x0001297D
	public override void OnSecondaryFire(bool pressed)
	{
		if (this._secondaryFireHandler != null)
		{
			this._secondaryFireHandler.OnTriggerPulled(pressed);
		}
	}

	// Token: 0x06001EFB RID: 7931 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPrevWeapon()
	{
	}

	// Token: 0x06001EFC RID: 7932 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnNextWeapon()
	{
	}

	// Token: 0x06001EFD RID: 7933 RVA: 0x00014796 File Offset: 0x00012996
	public override void Update()
	{
		base.FireHandler.Update();
	}

	// Token: 0x06001EFE RID: 7934 RVA: 0x00004D4D File Offset: 0x00002F4D
	public override bool CanChangeWeapon()
	{
		return true;
	}

	// Token: 0x06001EFF RID: 7935 RVA: 0x000147A3 File Offset: 0x000129A3
	public override void Stop()
	{
		base.FireHandler.Stop();
	}

	// Token: 0x04001A95 RID: 6805
	private IWeaponFireHandler _secondaryFireHandler;
}
