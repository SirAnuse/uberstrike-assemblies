using System;
using System.Collections;
using Cmune.Core.Models.Views;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Types;
using UberStrike.DataCenter.Common.Entities;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x0200022C RID: 556
public class GlobalSceneLoader : MonoBehaviour
{
	// Token: 0x1700038F RID: 911
	// (get) Token: 0x06000F42 RID: 3906 RVA: 0x0000AE8D File Offset: 0x0000908D
	// (set) Token: 0x06000F43 RID: 3907 RVA: 0x0000AE94 File Offset: 0x00009094
	public static string ErrorMessage { get; private set; }

	// Token: 0x17000390 RID: 912
	// (get) Token: 0x06000F44 RID: 3908 RVA: 0x0000AE9C File Offset: 0x0000909C
	public static bool IsError
	{
		get
		{
			return !string.IsNullOrEmpty(GlobalSceneLoader.ErrorMessage);
		}
	}

	// Token: 0x17000391 RID: 913
	// (get) Token: 0x06000F45 RID: 3909 RVA: 0x0000AEAB File Offset: 0x000090AB
	// (set) Token: 0x06000F46 RID: 3910 RVA: 0x0000AEB2 File Offset: 0x000090B2
	public static bool IsInitialised { get; set; }

	// Token: 0x17000392 RID: 914
	// (get) Token: 0x06000F47 RID: 3911 RVA: 0x0000AEBA File Offset: 0x000090BA
	// (set) Token: 0x06000F48 RID: 3912 RVA: 0x0000AEC1 File Offset: 0x000090C1
	public static float GlobalSceneProgress { get; private set; }

	// Token: 0x17000393 RID: 915
	// (get) Token: 0x06000F49 RID: 3913 RVA: 0x0000AEC9 File Offset: 0x000090C9
	// (set) Token: 0x06000F4A RID: 3914 RVA: 0x0000AED0 File Offset: 0x000090D0
	public static bool IsGlobalSceneLoaded { get; private set; }

	// Token: 0x17000394 RID: 916
	// (get) Token: 0x06000F4B RID: 3915 RVA: 0x0000AED8 File Offset: 0x000090D8
	// (set) Token: 0x06000F4C RID: 3916 RVA: 0x0000AEDF File Offset: 0x000090DF
	public static float ItemAssetBundleProgress { get; private set; }

	// Token: 0x17000395 RID: 917
	// (get) Token: 0x06000F4D RID: 3917 RVA: 0x0000AEE7 File Offset: 0x000090E7
	// (set) Token: 0x06000F4E RID: 3918 RVA: 0x0000AEEE File Offset: 0x000090EE
	public static bool IsItemAssetBundleLoaded { get; private set; }

	// Token: 0x17000396 RID: 918
	// (get) Token: 0x06000F4F RID: 3919 RVA: 0x0000AEF6 File Offset: 0x000090F6
	// (set) Token: 0x06000F50 RID: 3920 RVA: 0x0000AEFD File Offset: 0x000090FD
	public static bool IsItemAssetBundleDownloading { get; private set; }

	// Token: 0x06000F51 RID: 3921 RVA: 0x0000AF05 File Offset: 0x00009105
	private void Awake()
	{
		PopupSkin.Initialize(this.popupSkin);
		this._blackTexture = new Texture2D(1, 1, TextureFormat.RGB24, false);
		this._color = Color.black;
	}

	// Token: 0x06000F52 RID: 3922 RVA: 0x00064580 File Offset: 0x00062780
	private void OnGUI()
	{
		GUI.depth = 8;
		GUI.color = this._color;
		GUI.DrawTexture(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), this._blackTexture);
		GUI.color = Color.white;
	}

	// Token: 0x06000F53 RID: 3923 RVA: 0x000645D0 File Offset: 0x000627D0
	private IEnumerator Start()
	{
		Application.runInBackground = true;
		Application.LoadLevel("Menu");
		Configuration.WebserviceBaseUrl = ApplicationDataManager.WebServiceBaseUrl;
		yield return base.StartCoroutine(this.BeginAuthenticateApplication());
		GlobalSceneLoader.GlobalSceneProgress = 1f;
		GlobalSceneLoader.IsGlobalSceneLoaded = true;
		GlobalSceneLoader.ItemAssetBundleProgress = 1f;
		GlobalSceneLoader.IsItemAssetBundleLoaded = true;
		this.InitializeGlobalScene();
		yield return new WaitForSeconds(1f);
		for (float f = 0f; f < 1f; f += Time.deltaTime)
		{
			yield return new WaitForEndOfFrame();
			this._color.a = 1f - f / 1f;
		}
		Debug.Log("Start LoginByChannel");
		if (PlayerDataManager.IsTestBuild)
		{
			PopupSystem.ShowMessage("Warning", "This is a test build, do not distribute!", PopupSystem.AlertType.OK, delegate()
			{
				Singleton<AuthenticationManager>.Instance.LoginByChannel();
			});
		}
		else
		{
			Singleton<AuthenticationManager>.Instance.LoginByChannel();
		}
		yield return new WaitForSeconds(1f);
		UnityEngine.Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x06000F54 RID: 3924 RVA: 0x000645EC File Offset: 0x000627EC
	private void InitializeGlobalScene()
	{
		ApplicationDataManager.CurrentLocale = LocaleType.en_US;
		ApplicationDataManager.ApplicationOptions.Initialize();
		base.StartCoroutine(GUITools.StartScreenSizeListener(1f));
		if (ApplicationDataManager.ApplicationOptions.IsUsingCustom)
		{
			QualitySettings.masterTextureLimit = ApplicationDataManager.ApplicationOptions.VideoTextureQuality;
			QualitySettings.vSyncCount = ApplicationDataManager.ApplicationOptions.VideoVSyncCount;
			QualitySettings.antiAliasing = ApplicationDataManager.ApplicationOptions.VideoAntiAliasing;
		}
		else
		{
			QualitySettings.SetQualityLevel(ApplicationDataManager.ApplicationOptions.VideoQualityLevel);
		}
		AutoMonoBehaviour<SfxManager>.Instance.EnableAudio(ApplicationDataManager.ApplicationOptions.AudioEnabled);
		AutoMonoBehaviour<SfxManager>.Instance.UpdateMasterVolume();
		AutoMonoBehaviour<SfxManager>.Instance.UpdateMusicVolume();
		AutoMonoBehaviour<SfxManager>.Instance.UpdateEffectsVolume();
		AutoMonoBehaviour<InputManager>.Instance.ReadAllKeyMappings();
	}

	// Token: 0x06000F55 RID: 3925 RVA: 0x000646A8 File Offset: 0x000628A8
	private IEnumerator BeginAuthenticateApplication()
	{
		Debug.Log("BeginAuthenticateApplication " + Configuration.WebserviceBaseUrl);
		yield return ApplicationWebServiceClient.AuthenticateApplication("4.7.1", ApplicationDataManager.Channel, string.Empty, delegate(AuthenticateApplicationView callback)
		{
			this.OnAuthenticateApplication(callback);
		}, delegate(Exception exception)
		{
			this.OnAuthenticateApplicationException(exception);
		});
		Debug.Log("Connected to : " + Configuration.WebserviceBaseUrl);
		yield break;
	}

	// Token: 0x06000F56 RID: 3926 RVA: 0x000646C4 File Offset: 0x000628C4
	private void OnAuthenticateApplication(AuthenticateApplicationView ev)
	{
		try
		{
			GlobalSceneLoader.IsInitialised = true;
			if (ev != null && ev.IsEnabled)
			{
				Configuration.EncryptionInitVector = ev.EncryptionInitVector;
				Configuration.EncryptionPassPhrase = ev.EncryptionPassPhrase;
				ApplicationDataManager.IsOnline = true;
				if (!this.UseTestPhotonServers)
				{
					Singleton<GameServerManager>.Instance.CommServer = new PhotonServer(ev.CommServer);
					Singleton<GameServerManager>.Instance.AddPhotonGameServers(ev.GameServers.FindAll((PhotonView i) => i.UsageType == PhotonUsageType.All));
				}
				else
				{
					Singleton<GameServerManager>.Instance.CommServer = new PhotonServer(this.TestCommServer, PhotonUsageType.CommServer);
					Singleton<GameServerManager>.Instance.AddTestPhotonGameServer(1000, new PhotonServer(this.TestGameServer, PhotonUsageType.All));
				}
				if (ev.WarnPlayer)
				{
					this.HandleVersionWarning();
				}
			}
			else
			{
				Debug.Log(string.Concat(new object[]
				{
					"OnAuthenticateApplication failed with 4.7.1/",
					ApplicationDataManager.Channel,
					": ",
					GlobalSceneLoader.ErrorMessage
				}));
				GlobalSceneLoader.ErrorMessage = "Please update.";
				this.HandleVersionError();
			}
		}
		catch (Exception ex)
		{
			GlobalSceneLoader.ErrorMessage = ex.Message + " " + ex.StackTrace;
			Debug.LogError(string.Concat(new object[]
			{
				"OnAuthenticateApplication crashed with 4.7.1/",
				ApplicationDataManager.Channel,
				": ",
				GlobalSceneLoader.ErrorMessage
			}));
			this.HandleApplicationAuthenticationError("There was a problem loading UberStrike. Please check your internet connection and try again.");
		}
	}

	// Token: 0x06000F57 RID: 3927 RVA: 0x0006486C File Offset: 0x00062A6C
	private void OnAuthenticateApplicationException(Exception exception)
	{
		GlobalSceneLoader.ErrorMessage = exception.Message;
		Debug.LogError(string.Concat(new object[]
		{
			"An exception occurred while authenticating the application with 4.7.1/",
			ApplicationDataManager.Channel,
			": ",
			exception.Message
		}));
		this.HandleApplicationAuthenticationError("There was a problem loading UberStrike. Please check your internet connection and try again.");
	}

	// Token: 0x06000F58 RID: 3928 RVA: 0x0000AF2C File Offset: 0x0000912C
	private void RetryAuthentiateApplication()
	{
		GlobalSceneLoader.ErrorMessage = string.Empty;
		base.StartCoroutine(this.BeginAuthenticateApplication());
	}

	// Token: 0x06000F59 RID: 3929 RVA: 0x000648C8 File Offset: 0x00062AC8
	private void HandleApplicationAuthenticationError(string message)
	{
		ChannelType channel = ApplicationDataManager.Channel;
		switch (channel)
		{
		case ChannelType.IPhone:
		case ChannelType.IPad:
		case ChannelType.Android:
			PopupSystem.ShowError(LocalizedStrings.Error, message, PopupSystem.AlertType.OK, new Action(this.RetryAuthentiateApplication));
			break;
		default:
			if (channel != ChannelType.WebPortal && channel != ChannelType.WebFacebook)
			{
				PopupSystem.ShowError(LocalizedStrings.Error, message + "This client type is not supported.", PopupSystem.AlertType.OK, new Action(Application.Quit));
			}
			else
			{
				PopupSystem.ShowError(LocalizedStrings.Error, message, PopupSystem.AlertType.None);
			}
			break;
		}
	}

	// Token: 0x06000F5A RID: 3930 RVA: 0x00064958 File Offset: 0x00062B58
	private void HandleConfigurationMissingError(string message)
	{
		ChannelType channel = ApplicationDataManager.Channel;
		switch (channel)
		{
		case ChannelType.IPhone:
		case ChannelType.IPad:
		case ChannelType.Android:
			PopupSystem.ShowError(LocalizedStrings.Error, message, PopupSystem.AlertType.OK, new Action(Application.Quit));
			break;
		default:
			if (channel != ChannelType.WebPortal && channel != ChannelType.WebFacebook)
			{
				PopupSystem.ShowError(LocalizedStrings.Error, message + "This client type is not supported.", PopupSystem.AlertType.OK, new Action(Application.Quit));
			}
			else
			{
				PopupSystem.ShowError(LocalizedStrings.Error, message, PopupSystem.AlertType.None);
			}
			break;
		}
	}

	// Token: 0x06000F5B RID: 3931 RVA: 0x000649E8 File Offset: 0x00062BE8
	private void HandleVersionWarning()
	{
		ChannelType channel = ApplicationDataManager.Channel;
		switch (channel)
		{
		case ChannelType.IPhone:
		case ChannelType.IPad:
			PopupSystem.ShowError("Warning", "Your UberStrike client is out of date. Click OK to update from the App Store.", PopupSystem.AlertType.OKCancel, new Action(this.OpenIosAppStoreUpdatesPage), new Action(Singleton<AuthenticationManager>.Instance.LoginByChannel));
			break;
		case ChannelType.Android:
			PopupSystem.ShowError("Warning", "Your UberStrike client is out of date. Click OK to update from our website.", PopupSystem.AlertType.OKCancel, new Action(this.OpenAndroidAppStoreUpdatesPage), new Action(Singleton<AuthenticationManager>.Instance.LoginByChannel));
			break;
		default:
			if (channel != ChannelType.WebPortal && channel != ChannelType.WebFacebook)
			{
				PopupSystem.ShowError(LocalizedStrings.Error, "Your UberStrike client is not supported. Please update from our website.\n(Invalid Channel: " + ApplicationDataManager.Channel + ")", PopupSystem.AlertType.OK);
			}
			else
			{
				PopupSystem.ShowError("Warning", "Your UberStrike client is out of date. You should refresh your browser.", PopupSystem.AlertType.OK, new Action(Singleton<AuthenticationManager>.Instance.LoginByChannel));
			}
			break;
		}
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x00064AD4 File Offset: 0x00062CD4
	private void HandleVersionError()
	{
		ChannelType channel = ApplicationDataManager.Channel;
		switch (channel)
		{
		case ChannelType.IPhone:
		case ChannelType.IPad:
			PopupSystem.ShowError(LocalizedStrings.Error, "Your UberStrike client is out of date. Please update from the App Store.", PopupSystem.AlertType.OK, new Action(this.OpenIosAppStoreUpdatesPage));
			break;
		case ChannelType.Android:
			PopupSystem.ShowError(LocalizedStrings.Error, "Your UberStrike client is out of date. Please update from our website.", PopupSystem.AlertType.OK, new Action(this.OpenAndroidAppStoreUpdatesPage));
			break;
		default:
			if (channel != ChannelType.WebPortal && channel != ChannelType.WebFacebook)
			{
				PopupSystem.ShowError(LocalizedStrings.Error, "Your UberStrike client is not supported. Please update from our website.\n(Invalid Channel: " + ApplicationDataManager.Channel + ")", PopupSystem.AlertType.OK);
			}
			else
			{
				PopupSystem.ShowError(LocalizedStrings.Error, "Your UberStrike client is out of date. Please refresh your browser.", PopupSystem.AlertType.None);
			}
			break;
		}
	}

	// Token: 0x06000F5D RID: 3933 RVA: 0x0000AF45 File Offset: 0x00009145
	private void OpenIosAppStoreUpdatesPage()
	{
		ApplicationDataManager.OpenUrl(string.Empty, "itms-apps://itunes.com/apps/uberstrike");
	}

	// Token: 0x06000F5E RID: 3934 RVA: 0x0000AF56 File Offset: 0x00009156
	private void OpenAndroidAppStoreUpdatesPage()
	{
		ApplicationDataManager.OpenUrl(string.Empty, "market://details?id=com.cmune.uberstrike.android");
	}

	// Token: 0x04000D83 RID: 3459
	private const float FadeTime = 1f;

	// Token: 0x04000D84 RID: 3460
	[SerializeField]
	private bool UseTestPhotonServers;

	// Token: 0x04000D85 RID: 3461
	[SerializeField]
	private string TestCommServer;

	// Token: 0x04000D86 RID: 3462
	[SerializeField]
	private string TestGameServer;

	// Token: 0x04000D87 RID: 3463
	[SerializeField]
	private GUISkin popupSkin;

	// Token: 0x04000D88 RID: 3464
	private Texture2D _blackTexture;

	// Token: 0x04000D89 RID: 3465
	private Color _color;
}
