using System;
using System.Reflection;
using UnityEngine;

// Token: 0x0200039E RID: 926
public class RenderSettingsController : MonoBehaviour
{
	// Token: 0x17000619 RID: 1561
	// (get) Token: 0x06001B5B RID: 7003 RVA: 0x0008CABC File Offset: 0x0008ACBC
	public static RenderSettingsController Instance
	{
		get
		{
			if (RenderSettingsController._instance == null)
			{
				object @lock = RenderSettingsController._lock;
				lock (@lock)
				{
					if (RenderSettingsController._instance == null)
					{
						ConstructorInfo constructor = typeof(RenderSettingsController).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);
						if (constructor == null || constructor.IsAssembly)
						{
							throw new Exception(string.Format("A private or protected constructor is missing for '{0}'.", typeof(RenderSettingsController).Name));
						}
						RenderSettingsController._instance = (RenderSettingsController)constructor.Invoke(null);
					}
				}
			}
			return RenderSettingsController._instance;
		}
	}

	// Token: 0x06001B5C RID: 7004 RVA: 0x0008CB7C File Offset: 0x0008AD7C
	private void OnEnable()
	{
		RenderSettingsController._instance = this;
		this.fogMode = RenderSettings.fogMode;
		this.fogColor = RenderSettings.fogColor;
		this.fogStart = RenderSettings.fogStartDistance;
		this.fogEnd = RenderSettings.fogEndDistance;
		if (this.simpleWater != null)
		{
			this.simpleWater.SetActive(ApplicationDataManager.IsMobile);
		}
		if (this.advancedWater != null)
		{
			this.advancedWater.SetActive(!ApplicationDataManager.IsMobile);
		}
		this.EnableImageEffects();
		if (null == this.underWaterEffect)
		{
			this.underWaterEffect = Camera.main.gameObject.AddComponent<UnderWaterEffect>();
			if (this.underWaterEffect)
			{
				this.underWaterEffect.enabled = false;
				this.underWaterEffect.shader = Shader.Find("CMune/Under Water Effect");
				this.underWaterEffect.textureRamp = (Texture)Resources.Load("ImageEffects/Underwater_ColorRamp");
			}
		}
		if (null == this.vignetteEffect && !ApplicationDataManager.IsMobile)
		{
			this.vignetteEffect = Camera.main.gameObject.AddComponent<Vignetting>();
			if (this.vignetteEffect)
			{
				this.vignetteEffect.enabled = false;
				this.vignetteEffect.vignetteShader = Shader.Find("CMune/Vignetting");
				this.vignetteEffect.chromAberrationShader = Shader.Find("CMune/ChromaticAberration");
				this.vignetteEffect.separableBlurShader = Shader.Find("CMune/SeparableBlur");
				this.vignetteEffect.blurSpread = 4f;
				this.vignetteEffect.intensity = 0f;
			}
		}
		this.ResetInterpolation();
	}

	// Token: 0x06001B5D RID: 7005 RVA: 0x0001220A File Offset: 0x0001040A
	private void OnDisable()
	{
		this.ResetInterpolation();
	}

	// Token: 0x06001B5E RID: 7006 RVA: 0x0008CD2C File Offset: 0x0008AF2C
	public void EnableImageEffects()
	{
		foreach (MonoBehaviour monoBehaviour in this.simpleImageEffects)
		{
			monoBehaviour.enabled = ApplicationDataManager.IsMobile;
		}
		foreach (PostEffectsBase postEffectsBase in this.advancedImageEffects)
		{
			postEffectsBase.enabled = (!ApplicationDataManager.IsMobile && ApplicationDataManager.ApplicationOptions.VideoPostProcessing);
		}
	}

	// Token: 0x06001B5F RID: 7007 RVA: 0x0008CDA8 File Offset: 0x0008AFA8
	public void DisableImageEffects()
	{
		foreach (MonoBehaviour monoBehaviour in this.simpleImageEffects)
		{
			monoBehaviour.enabled = false;
		}
		foreach (PostEffectsBase postEffectsBase in this.advancedImageEffects)
		{
			postEffectsBase.enabled = false;
		}
		if (this.underWaterEffect)
		{
			this.underWaterEffect.enabled = false;
		}
		if (this.vignetteEffect)
		{
			this.vignetteEffect.enabled = false;
		}
		this.interpolationValue = 0f;
	}

	// Token: 0x06001B60 RID: 7008 RVA: 0x0008CE4C File Offset: 0x0008B04C
	private void Update()
	{
		if (GameState.Current.MatchState.CurrentStateId != GameStateId.None)
		{
			if (GameState.Current.PlayerData.IsUnderWater)
			{
				this.interpolationValue += Time.deltaTime;
				RenderSettings.fogMode = FogMode.Linear;
			}
			else
			{
				this.interpolationValue -= Time.deltaTime;
				RenderSettings.fogMode = this.fogMode;
			}
			this.interpolationValue = Mathf.Clamp01(this.interpolationValue);
			this.UpdateSettings(this.interpolationValue);
		}
	}

	// Token: 0x06001B61 RID: 7009 RVA: 0x0008CED8 File Offset: 0x0008B0D8
	private void UpdateSettings(float value)
	{
		float num = Mathf.Clamp01(value * 3f);
		bool flag = 0f < value;
		if (this.underWaterEffect)
		{
			this.underWaterEffect.enabled = flag;
			this.underWaterEffect.Weight = num;
		}
		if (this.vignetteEffect)
		{
			bool flag2 = flag && ApplicationDataManager.ApplicationOptions.VideoPostProcessing;
			this.vignetteEffect.enabled = flag2;
			if (flag2)
			{
				float num2 = Mathf.Sin(value * 3.14159274f);
				this.vignetteEffect.blur = 5f * num2 + value;
				this.vignetteEffect.chromaticAberration = (5f * num2 + value) * 10f;
			}
		}
		RenderSettings.fogColor = Color.Lerp(this.fogColor, this.underwaterFogColor, num);
		RenderSettings.fogStartDistance = Mathf.Lerp(this.fogStart, 10f, num);
		RenderSettings.fogEndDistance = Mathf.Lerp(this.fogEnd, 100f, num);
	}

	// Token: 0x06001B62 RID: 7010 RVA: 0x00012212 File Offset: 0x00010412
	public void ResetInterpolation()
	{
		this.interpolationValue = 0f;
		this.UpdateSettings(this.interpolationValue);
	}

	// Token: 0x04001856 RID: 6230
	private const float UNDERWATER_FOG_START = 10f;

	// Token: 0x04001857 RID: 6231
	private const float UNDERWATER_FOG_END = 100f;

	// Token: 0x04001858 RID: 6232
	private const float FADE_SPEED = 3f;

	// Token: 0x04001859 RID: 6233
	private const float TRANSITION_STRENGTH = 5f;

	// Token: 0x0400185A RID: 6234
	private const float CHROMATIC_ABERRATION = 10f;

	// Token: 0x0400185B RID: 6235
	private static volatile RenderSettingsController _instance;

	// Token: 0x0400185C RID: 6236
	private static object _lock = new object();

	// Token: 0x0400185D RID: 6237
	private float interpolationValue;

	// Token: 0x0400185E RID: 6238
	private float fogStart;

	// Token: 0x0400185F RID: 6239
	private float fogEnd;

	// Token: 0x04001860 RID: 6240
	private Color fogColor;

	// Token: 0x04001861 RID: 6241
	private FogMode fogMode;

	// Token: 0x04001862 RID: 6242
	private UnderWaterEffect underWaterEffect;

	// Token: 0x04001863 RID: 6243
	private Vignetting vignetteEffect;

	// Token: 0x04001864 RID: 6244
	[SerializeField]
	private Color underwaterFogColor;

	// Token: 0x04001865 RID: 6245
	[SerializeField]
	private GameObject advancedWater;

	// Token: 0x04001866 RID: 6246
	[SerializeField]
	private GameObject simpleWater;

	// Token: 0x04001867 RID: 6247
	[SerializeField]
	private MonoBehaviour[] simpleImageEffects;

	// Token: 0x04001868 RID: 6248
	[SerializeField]
	private PostEffectsBase[] advancedImageEffects;
}
