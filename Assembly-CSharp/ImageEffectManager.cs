using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002BB RID: 699
public class ImageEffectManager
{
	// Token: 0x0600135B RID: 4955 RVA: 0x0000D2EF File Offset: 0x0000B4EF
	public void ApplyMotionBlur(float time)
	{
		if (this._effects.ContainsKey(ImageEffectManager.ImageEffectType.MotionBlur))
		{
			this.EnableEffect(ImageEffectManager.ImageEffectType.MotionBlur, time);
		}
	}

	// Token: 0x0600135C RID: 4956 RVA: 0x0000D30A File Offset: 0x0000B50A
	public void ApplyMotionBlur(float time, float intensity)
	{
		if (this._effects.ContainsKey(ImageEffectManager.ImageEffectType.MotionBlur))
		{
			this.EnableEffect(ImageEffectManager.ImageEffectType.MotionBlur, time, intensity);
		}
	}

	// Token: 0x0600135D RID: 4957 RVA: 0x0000D326 File Offset: 0x0000B526
	public void ApplyWhiteout(float time)
	{
		if (this._effects.ContainsKey(ImageEffectManager.ImageEffectType.BloomAndLensFlares))
		{
			this.EnableEffect(ImageEffectManager.ImageEffectType.BloomAndLensFlares, time);
		}
	}

	// Token: 0x0600135E RID: 4958 RVA: 0x0000D341 File Offset: 0x0000B541
	public void AddEffect(ImageEffectManager.ImageEffectType imageEffectType, MonoBehaviour monoBehaviour)
	{
		this._effects[imageEffectType] = monoBehaviour;
		this._effectsParameters[imageEffectType] = new ImageEffectManager.ImageEffectParameters();
	}

	// Token: 0x0600135F RID: 4959 RVA: 0x0000D361 File Offset: 0x0000B561
	public void Clear()
	{
		this._effects.Clear();
	}

	// Token: 0x06001360 RID: 4960 RVA: 0x00070DB8 File Offset: 0x0006EFB8
	public void Update()
	{
		if (ApplicationDataManager.ApplicationOptions.VideoMotionBlur)
		{
			ImageEffectManager.ImageEffectParameters imageEffectParameters;
			if (this._effectsParameters.TryGetValue(ImageEffectManager.ImageEffectType.MotionBlur, out imageEffectParameters) && imageEffectParameters != null && imageEffectParameters.EffectEnable)
			{
				if (imageEffectParameters.ActiveTime > 0f)
				{
					imageEffectParameters.ChangeActiveTime(-Time.deltaTime);
					if (imageEffectParameters.ActiveTime < 0f)
					{
						imageEffectParameters.SetTimedEnable(false);
					}
				}
				if (imageEffectParameters.PermanentEnable)
				{
					((MotionBlur)this._effects[ImageEffectManager.ImageEffectType.MotionBlur]).blurAmount = 0.5f;
				}
				else if (imageEffectParameters.TimedEnable)
				{
					float num = this._effectsParameters[ImageEffectManager.ImageEffectType.MotionBlur].BaseIntencity;
					num = ((num <= 0f) ? 0.5f : num);
					((MotionBlur)this._effects[ImageEffectManager.ImageEffectType.MotionBlur]).blurAmount = this._effectsParameters[ImageEffectManager.ImageEffectType.MotionBlur].ActiveTime / this._effectsParameters[ImageEffectManager.ImageEffectType.MotionBlur].TotalTime * num;
				}
			}
		}
		else if (this._effects.ContainsKey(ImageEffectManager.ImageEffectType.MotionBlur))
		{
			this._effects[ImageEffectManager.ImageEffectType.MotionBlur].enabled = false;
		}
		if (this._effects.ContainsKey(ImageEffectManager.ImageEffectType.ColorCorrectionCurves))
		{
			this._effects[ImageEffectManager.ImageEffectType.ColorCorrectionCurves].enabled = ApplicationDataManager.ApplicationOptions.VideoVignetting;
		}
		if (this._effects.ContainsKey(ImageEffectManager.ImageEffectType.BloomAndLensFlares))
		{
			this._effects[ImageEffectManager.ImageEffectType.BloomAndLensFlares].enabled = ApplicationDataManager.ApplicationOptions.VideoBloomAndFlares;
		}
	}

	// Token: 0x06001361 RID: 4961 RVA: 0x0000D36E File Offset: 0x0000B56E
	public void EnableEffect(ImageEffectManager.ImageEffectType imageEffectType)
	{
		this.EnableEffect(imageEffectType, -1f, -1f);
	}

	// Token: 0x06001362 RID: 4962 RVA: 0x0000D381 File Offset: 0x0000B581
	public void EnableEffect(ImageEffectManager.ImageEffectType imageEffectType, float time)
	{
		this.EnableEffect(imageEffectType, time, -1f);
	}

	// Token: 0x06001363 RID: 4963 RVA: 0x00070F48 File Offset: 0x0006F148
	public void EnableEffect(ImageEffectManager.ImageEffectType imageEffectType, float duration, float intensity)
	{
		if (this._effects.ContainsKey(imageEffectType) && this._effectsParameters.ContainsKey(imageEffectType))
		{
			this._effects[imageEffectType].enabled = true;
			if (imageEffectType == ImageEffectManager.ImageEffectType.BloomAndLensFlares)
			{
				this._effectsParameters[imageEffectType].SetBaseIntensity(((BloomAndLensFlares)this._effects[ImageEffectManager.ImageEffectType.BloomAndLensFlares]).bloomIntensity);
			}
			if (intensity > 0f)
			{
				this._effectsParameters[imageEffectType].SetBaseIntensity(intensity);
			}
			if (duration > 0f)
			{
				this._effectsParameters[imageEffectType].SetTotalAndActiveTime(duration);
				this._effectsParameters[imageEffectType].SetTimedEnable(true);
			}
			else
			{
				this._effectsParameters[imageEffectType].SetPermanentEnable(true);
			}
			this._currentEffect = imageEffectType;
		}
		else
		{
			Debug.LogError("You're trying to enable an effect that hasn't been initialized. Check the components on MainCamera in the level.");
		}
	}

	// Token: 0x06001364 RID: 4964 RVA: 0x00071030 File Offset: 0x0006F230
	public void DisableEffect(ImageEffectManager.ImageEffectType imageEffectType)
	{
		if (this._effects.ContainsKey(imageEffectType) && this._effectsParameters.ContainsKey(imageEffectType))
		{
			this._effects[imageEffectType].enabled = false;
			this._effectsParameters[imageEffectType].SetPermanentEnable(false);
			this._currentEffect = ImageEffectManager.ImageEffectType.None;
		}
	}

	// Token: 0x06001365 RID: 4965 RVA: 0x0007108C File Offset: 0x0006F28C
	public void DisableEffectInstant(ImageEffectManager.ImageEffectType imageEffectType)
	{
		if (this._effects.ContainsKey(imageEffectType) && this._effectsParameters.ContainsKey(imageEffectType))
		{
			this._effects[imageEffectType].enabled = false;
			this._effectsParameters[imageEffectType].SetPermanentEnable(false);
			this._effectsParameters[imageEffectType].SetTimedEnable(false);
			this._currentEffect = ImageEffectManager.ImageEffectType.None;
		}
	}

	// Token: 0x06001366 RID: 4966 RVA: 0x000710F8 File Offset: 0x0006F2F8
	public void DisableAllEffects()
	{
		foreach (ImageEffectManager.ImageEffectType imageEffectType in this._effectsParameters.Keys)
		{
			this.DisableEffectInstant(imageEffectType);
		}
	}

	// Token: 0x1700049E RID: 1182
	// (get) Token: 0x06001367 RID: 4967 RVA: 0x0000D390 File Offset: 0x0000B590
	public ImageEffectManager.ImageEffectType CurrentEffect
	{
		get
		{
			return this._currentEffect;
		}
	}

	// Token: 0x04001335 RID: 4917
	private const float _motionBlurMaxValue = 0.5f;

	// Token: 0x04001336 RID: 4918
	private ImageEffectManager.ImageEffectType _currentEffect;

	// Token: 0x04001337 RID: 4919
	private Dictionary<ImageEffectManager.ImageEffectType, MonoBehaviour> _effects = new Dictionary<ImageEffectManager.ImageEffectType, MonoBehaviour>();

	// Token: 0x04001338 RID: 4920
	private Dictionary<ImageEffectManager.ImageEffectType, ImageEffectManager.ImageEffectParameters> _effectsParameters = new Dictionary<ImageEffectManager.ImageEffectType, ImageEffectManager.ImageEffectParameters>();

	// Token: 0x020002BC RID: 700
	public enum ImageEffectType
	{
		// Token: 0x0400133A RID: 4922
		None,
		// Token: 0x0400133B RID: 4923
		ColorCorrectionCurves,
		// Token: 0x0400133C RID: 4924
		BloomAndLensFlares,
		// Token: 0x0400133D RID: 4925
		MotionBlur
	}

	// Token: 0x020002BD RID: 701
	private class ImageEffectParameters
	{
		// Token: 0x06001369 RID: 4969 RVA: 0x0000D398 File Offset: 0x0000B598
		public void SetPermanentEnable(bool value)
		{
			this._permanentEnable = value;
		}

		// Token: 0x0600136A RID: 4970 RVA: 0x0000D3A1 File Offset: 0x0000B5A1
		public void SetTimedEnable(bool value)
		{
			this._timedEnable = value;
		}

		// Token: 0x0600136B RID: 4971 RVA: 0x0000D3AA File Offset: 0x0000B5AA
		public void SetBaseIntensity(float value)
		{
			this._baseIntencity = value;
		}

		// Token: 0x0600136C RID: 4972 RVA: 0x0000D3B3 File Offset: 0x0000B5B3
		public void SetTotalTime(float value)
		{
			this._totalTime = value;
		}

		// Token: 0x0600136D RID: 4973 RVA: 0x0000D3BC File Offset: 0x0000B5BC
		public void SetActiveTime(float value)
		{
			this._activeTime = value;
		}

		// Token: 0x0600136E RID: 4974 RVA: 0x0000D3C5 File Offset: 0x0000B5C5
		public void SetTotalAndActiveTime(float time)
		{
			this.SetActiveTime(time);
			this.SetTotalTime(time);
		}

		// Token: 0x0600136F RID: 4975 RVA: 0x0000D3D5 File Offset: 0x0000B5D5
		public void ChangeActiveTime(float change)
		{
			this._activeTime += change;
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06001370 RID: 4976 RVA: 0x0000D3E5 File Offset: 0x0000B5E5
		public bool PermanentEnable
		{
			get
			{
				return this._permanentEnable;
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06001371 RID: 4977 RVA: 0x0000D3ED File Offset: 0x0000B5ED
		public bool TimedEnable
		{
			get
			{
				return this._timedEnable;
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06001372 RID: 4978 RVA: 0x0000D3F5 File Offset: 0x0000B5F5
		public bool EffectEnable
		{
			get
			{
				return this._permanentEnable || this._timedEnable;
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06001373 RID: 4979 RVA: 0x0000D40B File Offset: 0x0000B60B
		public float BaseIntencity
		{
			get
			{
				return this._baseIntencity;
			}
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06001374 RID: 4980 RVA: 0x0000D413 File Offset: 0x0000B613
		public float TotalTime
		{
			get
			{
				return this._totalTime;
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06001375 RID: 4981 RVA: 0x0000D41B File Offset: 0x0000B61B
		public float ActiveTime
		{
			get
			{
				return this._activeTime;
			}
		}

		// Token: 0x0400133E RID: 4926
		private bool _permanentEnable;

		// Token: 0x0400133F RID: 4927
		private bool _timedEnable;

		// Token: 0x04001340 RID: 4928
		private float _baseIntencity;

		// Token: 0x04001341 RID: 4929
		private float _totalTime;

		// Token: 0x04001342 RID: 4930
		private float _activeTime;
	}
}
