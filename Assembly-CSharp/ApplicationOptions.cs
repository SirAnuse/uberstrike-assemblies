using System;
using UnityEngine;

// Token: 0x0200010E RID: 270
public class ApplicationOptions
{
	// Token: 0x060007EB RID: 2027 RVA: 0x0003662C File Offset: 0x0003482C
	public void Initialize()
	{
		string @string = PlayerPrefs.GetString("Version", "Invalid");
		bool flag = false;
		if ("4.7.1" != @string)
		{
			flag = true;
			CmunePrefs.Reset();
			QualitySettings.SetQualityLevel(2, true);
			PlayerPrefs.SetString("Version", "4.7.1");
		}
		Application.targetFrameRate = -1;
		QualitySettings.maxQueuedFrames = -1;
		this.IsUsingCustom = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_VideoIsUsingCustom, this.IsUsingCustom);
		this.VideoWaterMode = CmunePrefs.ReadKey<int>(CmunePrefs.Key.Options_VideoWaterMode, this.VideoWaterMode);
		if ((Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) && this.VideoWaterMode == 2)
		{
			this.VideoWaterMode = 1;
		}
		this.VideoTextureQuality = CmunePrefs.ReadKey<int>(CmunePrefs.Key.Options_VideoTextureQuality, this.VideoTextureQuality);
		this.VideoVSyncCount = CmunePrefs.ReadKey<int>(CmunePrefs.Key.Options_VideoVSyncCount, this.VideoVSyncCount);
		this.VideoAntiAliasing = CmunePrefs.ReadKey<int>(CmunePrefs.Key.Options_VideoAntiAliasing, this.VideoAntiAliasing);
		this.VideoQualityLevel = CmunePrefs.ReadKey<int>(CmunePrefs.Key.Options_VideoCurrentQualityLevel, this.VideoQualityLevel);
		this.VideoBloomAndFlares = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_VideoBloomAndFlares, this.VideoBloomAndFlares);
		this.VideoVignetting = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_VideoColorCorrection, this.VideoVignetting);
		this.VideoMotionBlur = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_VideoMotionBlur, this.VideoMotionBlur);
		this.VideoShowFps = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_VideoShowFps, this.VideoShowFps);
		this.VideoPostProcessing = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_VideoPostProcessing, this.VideoPostProcessing);
		this.IsFullscreen = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_VideoIsFullscreen, true);
		this.ScreenResolution = CmunePrefs.ReadKey<int>(CmunePrefs.Key.Options_VideoScreenRes, ScreenResolutionManager.CurrentResolutionIndex);
		this.InputXMouseSensitivity = Mathf.Clamp(CmunePrefs.ReadKey<float>(CmunePrefs.Key.Options_InputXMouseSensitivity, 3f), 1f, 10f);
		this.InputYMouseSensitivity = Mathf.Clamp(CmunePrefs.ReadKey<float>(CmunePrefs.Key.Options_InputYMouseSensitivity, 3f), 1f, 10f);
		this.InputMouseRotationMaxX = CmunePrefs.ReadKey<float>(CmunePrefs.Key.Options_InputMouseRotationMaxX, 360f);
		this.InputMouseRotationMaxY = CmunePrefs.ReadKey<float>(CmunePrefs.Key.Options_InputMouseRotationMaxY, 90f);
		this.InputMouseRotationMinX = CmunePrefs.ReadKey<float>(CmunePrefs.Key.Options_InputMouseRotationMinX, -360f);
		this.InputMouseRotationMinY = CmunePrefs.ReadKey<float>(CmunePrefs.Key.Options_InputMouseRotationMinY, -90f);
		this.InputInvertMouse = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_InputInvertMouse, false);
		bool flag2 = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_InputEnableGamepad, false);
		AutoMonoBehaviour<InputManager>.Instance.IsGamepadEnabled = (Input.GetJoystickNames().Length > 0 && flag2);
		this.GameplayAutoPickupEnabled = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_GameplayAutoPickupEnabled, true);
		this.GameplayAutoEquipEnabled = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_GameplayAutoEquipEnabled, false);
		this.AudioEnabled = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Options_AudioEnabled, true);
		this.AudioEffectsVolume = CmunePrefs.ReadKey<float>(CmunePrefs.Key.Options_AudioEffectsVolume, 0.7f);
		this.AudioMusicVolume = CmunePrefs.ReadKey<float>(CmunePrefs.Key.Options_AudioMusicVolume, 0.5f);
		this.AudioMasterVolume = CmunePrefs.ReadKey<float>(CmunePrefs.Key.Options_AudioMasterVolume, 0.5f);
		if (flag)
		{
			this.SaveApplicationOptions();
		}
	}

	// Token: 0x060007EC RID: 2028 RVA: 0x000368E0 File Offset: 0x00034AE0
	public void SaveApplicationOptions()
	{
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_VideoIsUsingCustom, this.IsUsingCustom);
		CmunePrefs.WriteKey<int>(CmunePrefs.Key.Options_VideoTextureQuality, this.VideoTextureQuality);
		CmunePrefs.WriteKey<int>(CmunePrefs.Key.Options_VideoVSyncCount, this.VideoVSyncCount);
		CmunePrefs.WriteKey<int>(CmunePrefs.Key.Options_VideoAntiAliasing, this.VideoAntiAliasing);
		CmunePrefs.WriteKey<int>(CmunePrefs.Key.Options_VideoWaterMode, this.VideoWaterMode);
		CmunePrefs.WriteKey<int>(CmunePrefs.Key.Options_VideoCurrentQualityLevel, this.VideoQualityLevel);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_VideoBloomAndFlares, this.VideoBloomAndFlares);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_VideoColorCorrection, this.VideoVignetting);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_VideoMotionBlur, this.VideoMotionBlur);
		CmunePrefs.WriteKey<int>(CmunePrefs.Key.Options_VideoScreenRes, this.ScreenResolution);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_VideoIsFullscreen, this.IsFullscreen);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_VideoShowFps, this.VideoShowFps);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_VideoPostProcessing, this.VideoPostProcessing);
		CmunePrefs.WriteKey<float>(CmunePrefs.Key.Options_InputXMouseSensitivity, this.InputXMouseSensitivity);
		CmunePrefs.WriteKey<float>(CmunePrefs.Key.Options_InputYMouseSensitivity, this.InputYMouseSensitivity);
		CmunePrefs.WriteKey<float>(CmunePrefs.Key.Options_InputMouseRotationMaxX, this.InputMouseRotationMaxX);
		CmunePrefs.WriteKey<float>(CmunePrefs.Key.Options_InputMouseRotationMaxY, this.InputMouseRotationMaxY);
		CmunePrefs.WriteKey<float>(CmunePrefs.Key.Options_InputMouseRotationMinX, this.InputMouseRotationMinX);
		CmunePrefs.WriteKey<float>(CmunePrefs.Key.Options_InputMouseRotationMinY, this.InputMouseRotationMinY);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_InputInvertMouse, this.InputInvertMouse);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_InputEnableGamepad, AutoMonoBehaviour<InputManager>.Instance.IsGamepadEnabled);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_GameplayAutoPickupEnabled, this.GameplayAutoPickupEnabled);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_GameplayAutoEquipEnabled, this.GameplayAutoEquipEnabled);
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Options_AudioEnabled, this.AudioEnabled);
		CmunePrefs.WriteKey<float>(CmunePrefs.Key.Options_AudioEffectsVolume, this.AudioEffectsVolume);
		CmunePrefs.WriteKey<float>(CmunePrefs.Key.Options_AudioMusicVolume, this.AudioMusicVolume);
		CmunePrefs.WriteKey<float>(CmunePrefs.Key.Options_AudioMasterVolume, this.AudioMasterVolume);
	}

	// Token: 0x0400084E RID: 2126
	public bool IsRagdollShootable;

	// Token: 0x0400084F RID: 2127
	public bool IsUsingCustom;

	// Token: 0x04000850 RID: 2128
	public int VideoQualityLevel = 2;

	// Token: 0x04000851 RID: 2129
	public int VideoTextureQuality = 4;

	// Token: 0x04000852 RID: 2130
	public int VideoVSyncCount;

	// Token: 0x04000853 RID: 2131
	public int VideoAntiAliasing;

	// Token: 0x04000854 RID: 2132
	public int VideoWaterMode = 1;

	// Token: 0x04000855 RID: 2133
	public int ScreenResolution;

	// Token: 0x04000856 RID: 2134
	public bool IsFullscreen;

	// Token: 0x04000857 RID: 2135
	public bool VideoBloomAndFlares;

	// Token: 0x04000858 RID: 2136
	public bool VideoVignetting;

	// Token: 0x04000859 RID: 2137
	public bool VideoMotionBlur;

	// Token: 0x0400085A RID: 2138
	public bool VideoShowFps;

	// Token: 0x0400085B RID: 2139
	public bool VideoPostProcessing = true;

	// Token: 0x0400085C RID: 2140
	public float InputXMouseSensitivity = 3f;

	// Token: 0x0400085D RID: 2141
	public float InputYMouseSensitivity = 3f;

	// Token: 0x0400085E RID: 2142
	public float InputMouseRotationMaxX = 360f;

	// Token: 0x0400085F RID: 2143
	public float InputMouseRotationMaxY = 90f;

	// Token: 0x04000860 RID: 2144
	public float InputMouseRotationMinX = -360f;

	// Token: 0x04000861 RID: 2145
	public float InputMouseRotationMinY = -90f;

	// Token: 0x04000862 RID: 2146
	public bool InputInvertMouse;

	// Token: 0x04000863 RID: 2147
	public float TouchLookSensitivity = 1f;

	// Token: 0x04000864 RID: 2148
	public float TouchMoveSensitivity = 1f;

	// Token: 0x04000865 RID: 2149
	public bool UseMultiTouch;

	// Token: 0x04000866 RID: 2150
	public bool GameplayAutoPickupEnabled = true;

	// Token: 0x04000867 RID: 2151
	public bool GameplayAutoEquipEnabled;

	// Token: 0x04000868 RID: 2152
	public float CameraFovMax = 65f;

	// Token: 0x04000869 RID: 2153
	public float CameraFovMin = 5f;

	// Token: 0x0400086A RID: 2154
	public bool AudioEnabled = true;

	// Token: 0x0400086B RID: 2155
	public float AudioEffectsVolume = 0.7f;

	// Token: 0x0400086C RID: 2156
	public float AudioMusicVolume = 0.5f;

	// Token: 0x0400086D RID: 2157
	public float AudioMasterVolume = 0.7f;
}
