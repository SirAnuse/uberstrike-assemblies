using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public static class CmunePrefs
{
	// Token: 0x06001C29 RID: 7209 RVA: 0x00012B84 File Offset: 0x00010D84
	public static void Reset()
	{
		PlayerPrefs.DeleteAll();
	}

	// Token: 0x06001C2A RID: 7210 RVA: 0x0008F2E8 File Offset: 0x0008D4E8
	public static bool TryGetKey<T>(CmunePrefs.Key k, out T value)
	{
		if (PlayerPrefs.HasKey(k.ToString()))
		{
			value = CmunePrefs.ReadKey<T>(k, default(T));
			return true;
		}
		value = default(T);
		return false;
	}

	// Token: 0x06001C2B RID: 7211 RVA: 0x00012B8B File Offset: 0x00010D8B
	public static bool HasKey(CmunePrefs.Key k)
	{
		return PlayerPrefs.HasKey(k.ToString());
	}

	// Token: 0x06001C2C RID: 7212 RVA: 0x0008F334 File Offset: 0x0008D534
	public static T ReadKey<T>(CmunePrefs.Key k, T defaultValue)
	{
		T result = defaultValue;
		if (typeof(T) == typeof(bool))
		{
			result = (T)((object)(PlayerPrefs.GetInt(k.ToString(), (!(bool)((object)defaultValue)) ? 0 : 1) == 1));
		}
		else if (typeof(T) == typeof(int))
		{
			result = (T)((object)PlayerPrefs.GetInt(k.ToString(), (int)((object)defaultValue)));
		}
		else if (typeof(T) == typeof(float))
		{
			result = (T)((object)PlayerPrefs.GetFloat(k.ToString(), (float)((object)defaultValue)));
		}
		else if (typeof(T) == typeof(string))
		{
			result = (T)((object)PlayerPrefs.GetString(k.ToString(), (string)((object)defaultValue)));
		}
		else
		{
			Debug.LogError(string.Format("Key {0} couldn't be read because type {1} not supported.", k, typeof(T)));
		}
		return result;
	}

	// Token: 0x06001C2D RID: 7213 RVA: 0x0008F480 File Offset: 0x0008D680
	public static T ReadKey<T>(CmunePrefs.Key k)
	{
		return CmunePrefs.ReadKey<T>(k, default(T));
	}

	// Token: 0x06001C2E RID: 7214 RVA: 0x0008F49C File Offset: 0x0008D69C
	public static void WriteKey<T>(CmunePrefs.Key k, T val)
	{
		if (typeof(T) == typeof(bool))
		{
			PlayerPrefs.SetInt(k.ToString(), (!(bool)((object)val)) ? 0 : 1);
		}
		else if (typeof(T) == typeof(int))
		{
			PlayerPrefs.SetInt(k.ToString(), (int)((object)val));
		}
		else if (typeof(T) == typeof(float))
		{
			PlayerPrefs.SetFloat(k.ToString(), (float)((object)val));
		}
		else if (typeof(T) == typeof(string))
		{
			PlayerPrefs.SetString(k.ToString(), (string)((object)val));
		}
		else
		{
			Debug.LogError(string.Format("Key {0} couldn't be read because type {1} not supported.", k, typeof(T)));
		}
	}

	// Token: 0x020003C4 RID: 964
	public enum Key
	{
		// Token: 0x04001912 RID: 6418
		Player_Name = 50,
		// Token: 0x04001913 RID: 6419
		Player_Email,
		// Token: 0x04001914 RID: 6420
		Player_Password,
		// Token: 0x04001915 RID: 6421
		Player_AutoLogin = 54,
		// Token: 0x04001916 RID: 6422
		Options_VideoIsUsingCustom = 95,
		// Token: 0x04001917 RID: 6423
		Options_VideoMaxQueuedFrames,
		// Token: 0x04001918 RID: 6424
		Options_VideoTextureQuality,
		// Token: 0x04001919 RID: 6425
		Options_VideoVSyncCount,
		// Token: 0x0400191A RID: 6426
		Options_VideoAntiAliasing,
		// Token: 0x0400191B RID: 6427
		Options_VideoWaterMode = 101,
		// Token: 0x0400191C RID: 6428
		Options_VideoCurrentQualityLevel,
		// Token: 0x0400191D RID: 6429
		Options_VideoAdvancedWater,
		// Token: 0x0400191E RID: 6430
		Options_VideoBloomAndFlares,
		// Token: 0x0400191F RID: 6431
		Options_VideoColorCorrection,
		// Token: 0x04001920 RID: 6432
		Options_VideoMotionBlur,
		// Token: 0x04001921 RID: 6433
		Options_VideoPostProcessing = 118,
		// Token: 0x04001922 RID: 6434
		Options_VideoShowFps,
		// Token: 0x04001923 RID: 6435
		Options_InputXMouseSensitivity = 107,
		// Token: 0x04001924 RID: 6436
		Options_InputYMouseSensitivity,
		// Token: 0x04001925 RID: 6437
		Options_InputMouseRotationMaxX,
		// Token: 0x04001926 RID: 6438
		Options_InputMouseRotationMaxY,
		// Token: 0x04001927 RID: 6439
		Options_InputMouseRotationMinX,
		// Token: 0x04001928 RID: 6440
		Options_InputMouseRotationMinY,
		// Token: 0x04001929 RID: 6441
		Options_InputInvertMouse,
		// Token: 0x0400192A RID: 6442
		Options_GameplayAutoPickupEnabled,
		// Token: 0x0400192B RID: 6443
		Options_GameplayAutoEquipEnabled,
		// Token: 0x0400192C RID: 6444
		Options_GameplayRagdollEnabled,
		// Token: 0x0400192D RID: 6445
		Options_InputEnableGamepad,
		// Token: 0x0400192E RID: 6446
		Options_AudioEnabled = 120,
		// Token: 0x0400192F RID: 6447
		Options_AudioEffectsVolume,
		// Token: 0x04001930 RID: 6448
		Options_AudioMusicVolume,
		// Token: 0x04001931 RID: 6449
		Options_AudioMasterVolume,
		// Token: 0x04001932 RID: 6450
		Options_VideoHardcoreMode,
		// Token: 0x04001933 RID: 6451
		Options_VideoScreenRes,
		// Token: 0x04001934 RID: 6452
		Options_VideoIsFullscreen,
		// Token: 0x04001935 RID: 6453
		Keymap_None = 300,
		// Token: 0x04001936 RID: 6454
		Keymap_HorizontalLook,
		// Token: 0x04001937 RID: 6455
		Keymap_VerticalLook,
		// Token: 0x04001938 RID: 6456
		Keymap_Forward,
		// Token: 0x04001939 RID: 6457
		Keymap_Backward,
		// Token: 0x0400193A RID: 6458
		Keymap_Left,
		// Token: 0x0400193B RID: 6459
		Keymap_Right,
		// Token: 0x0400193C RID: 6460
		Keymap_Jump,
		// Token: 0x0400193D RID: 6461
		Keymap_Crouch,
		// Token: 0x0400193E RID: 6462
		Keymap_PrimaryFire,
		// Token: 0x0400193F RID: 6463
		Keymap_SecondaryFire,
		// Token: 0x04001940 RID: 6464
		Keymap_Weapon1,
		// Token: 0x04001941 RID: 6465
		Keymap_Weapon2,
		// Token: 0x04001942 RID: 6466
		Keymap_Weapon3,
		// Token: 0x04001943 RID: 6467
		Keymap_WeaponMelee = 315,
		// Token: 0x04001944 RID: 6468
		Keymap_QuickItem1,
		// Token: 0x04001945 RID: 6469
		Keymap_QuickItem2,
		// Token: 0x04001946 RID: 6470
		Keymap_QuickItem3,
		// Token: 0x04001947 RID: 6471
		Keymap_NextWeapon,
		// Token: 0x04001948 RID: 6472
		Keymap_PrevWeapon,
		// Token: 0x04001949 RID: 6473
		Keymap_Pause,
		// Token: 0x0400194A RID: 6474
		Keymap_Fullscreen,
		// Token: 0x0400194B RID: 6475
		Keymap_Tabscreen,
		// Token: 0x0400194C RID: 6476
		Keymap_Chat,
		// Token: 0x0400194D RID: 6477
		Keymap_Inventory,
		// Token: 0x0400194E RID: 6478
		Keymap_UseQuickItem,
		// Token: 0x0400194F RID: 6479
		Keymap_ChangeTeam,
		// Token: 0x04001950 RID: 6480
		Keymap_NextQuickItem,
		// Token: 0x04001951 RID: 6481
		Keymap_SendScreenshotToFacebook,
		// Token: 0x04001952 RID: 6482
		Shop_RecentlyUsedItems = 400,
		// Token: 0x04001953 RID: 6483
		App_ClientRegistered = 500
	}
}
