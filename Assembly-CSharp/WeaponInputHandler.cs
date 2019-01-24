using System;
using UnityEngine;

// Token: 0x02000446 RID: 1094
public abstract class WeaponInputHandler
{
	// Token: 0x06001F19 RID: 7961 RVA: 0x0001487D File Offset: 0x00012A7D
	protected WeaponInputHandler(IWeaponLogic logic, bool isLocal)
	{
		this._isLocal = isLocal;
		this._weaponLogic = logic;
	}

	// Token: 0x1700069D RID: 1693
	// (get) Token: 0x06001F1A RID: 7962 RVA: 0x00014893 File Offset: 0x00012A93
	// (set) Token: 0x06001F1B RID: 7963 RVA: 0x0001489B File Offset: 0x00012A9B
	public IWeaponFireHandler FireHandler { get; protected set; }

	// Token: 0x06001F1C RID: 7964 RVA: 0x0009630C File Offset: 0x0009450C
	protected static void ZoomIn(ZoomInfo zoomInfo, BaseWeaponDecorator weapon, float zoom, bool hideWeapon)
	{
		if (weapon)
		{
			if (!LevelCamera.IsZoomedIn)
			{
				AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.SniperScopeIn, 0UL);
			}
			else if (zoom < 0f && zoomInfo.CurrentMultiplier != zoomInfo.MinMultiplier)
			{
				AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.SniperZoomIn, 0UL);
			}
			else if (zoom > 0f && zoomInfo.CurrentMultiplier != zoomInfo.MaxMultiplier)
			{
				AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.SniperZoomOut, 0UL);
			}
			zoomInfo.CurrentMultiplier = Mathf.Clamp(zoomInfo.CurrentMultiplier + zoom, zoomInfo.MinMultiplier, zoomInfo.MaxMultiplier);
			LevelCamera.DoZoomIn(75f / zoomInfo.CurrentMultiplier, 20f, hideWeapon);
			UserInput.ZoomSpeed = 0.5f;
		}
	}

	// Token: 0x06001F1D RID: 7965 RVA: 0x000963E4 File Offset: 0x000945E4
	protected static void ZoomOut(ZoomInfo zoomInfo, BaseWeaponDecorator weapon)
	{
		LevelCamera.DoZoomOut(75f, 10f);
		UserInput.ZoomSpeed = 1f;
		if (zoomInfo != null)
		{
			zoomInfo.CurrentMultiplier = zoomInfo.DefaultMultiplier;
		}
		if (weapon)
		{
			AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.SniperScopeOut, 0UL);
		}
	}

	// Token: 0x06001F1E RID: 7966
	public abstract void OnPrimaryFire(bool pressed);

	// Token: 0x06001F1F RID: 7967
	public abstract void OnSecondaryFire(bool pressed);

	// Token: 0x06001F20 RID: 7968
	public abstract void OnPrevWeapon();

	// Token: 0x06001F21 RID: 7969
	public abstract void OnNextWeapon();

	// Token: 0x06001F22 RID: 7970
	public abstract void Update();

	// Token: 0x06001F23 RID: 7971
	public abstract bool CanChangeWeapon();

	// Token: 0x06001F24 RID: 7972 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void Stop()
	{
	}

	// Token: 0x04001AA0 RID: 6816
	protected bool _isLocal;

	// Token: 0x04001AA1 RID: 6817
	protected IWeaponLogic _weaponLogic;

	// Token: 0x04001AA2 RID: 6818
	protected ZoomInfo _zoomInfo;
}
