using System;
using System.Collections;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000297 RID: 663
public static class ApplicationDataManager
{
	// Token: 0x0600122C RID: 4652 RVA: 0x0006D314 File Offset: 0x0006B514
	static ApplicationDataManager()
	{
		try
		{
			ApplicationDataManager.ImagePath = (ApplicationDataManager.WebServiceBaseUrl = File.ReadAllText(Path.Combine(Application.dataPath, ".uberstrok")));
		}
		catch
		{
			ApplicationDataManager.LockApplication("Failed to load '.uberstrok' host config.");
		}
        try
        {
            string hsbPath = Path.Combine(Application.dataPath, "HSB.ogg");
            string url = "file:///" + hsbPath;
            WWW hsb = new WWW(url);
            
            // delay until it's loaded.
            // probably not the most efficient way of dealing with things?
            while (hsb.progress < 1) ;
            if (hsb.progress >= 1)
                GameAudio.HomeSceneBackground = hsb.audioClip;
        }
        catch
        {

        }
		ApplicationDataManager.IsDebug = true;
		ApplicationDataManager.applicationDateTime = 0f;
		ApplicationDataManager.serverDateTime = DateTime.Now;
		ApplicationDataManager.WebPlayerHasResult = false;
		ApplicationDataManager.ApplicationOptions = new ApplicationOptions();
	}

	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x0600122D RID: 4653 RVA: 0x0000C92B File Offset: 0x0000AB2B
	public static ChannelType Channel
	{
		get
		{
			return ChannelType.Steam;
		}
	}

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x0600122E RID: 4654 RVA: 0x0000C92F File Offset: 0x0000AB2F
	// (set) Token: 0x0600122F RID: 4655 RVA: 0x0000C936 File Offset: 0x0000AB36
	public static ApplicationOptions ApplicationOptions { get; private set; }

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x06001230 RID: 4656 RVA: 0x0000C93E File Offset: 0x0000AB3E
	// (set) Token: 0x06001231 RID: 4657 RVA: 0x0000C945 File Offset: 0x0000AB45
	public static bool IsOnline { get; set; }

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x06001232 RID: 4658 RVA: 0x0000C94D File Offset: 0x0000AB4D
	public static bool IsMobile
	{
		get
		{
			return Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android;
		}
	}

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x06001233 RID: 4659 RVA: 0x0000C966 File Offset: 0x0000AB66
	public static bool IsDesktop
	{
		get
		{
			return Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer;
		}
	}

	// Token: 0x17000467 RID: 1127
	// (get) Token: 0x06001234 RID: 4660 RVA: 0x0000C97E File Offset: 0x0000AB7E
	// (set) Token: 0x06001235 RID: 4661 RVA: 0x0000C985 File Offset: 0x0000AB85
	public static LocaleType CurrentLocale { get; set; }

	// Token: 0x06001236 RID: 4662 RVA: 0x0000C98D File Offset: 0x0000AB8D
	public static void LockApplication(string message = "An error occured that forced UberStrike to halt.")
	{
		PopupSystem.ClearAll();
		PopupSystem.ShowMessage(LocalizedStrings.Error, message, PopupSystem.AlertType.OK, new Action(Application.Quit));
	}

	// Token: 0x06001237 RID: 4663 RVA: 0x0000C9AC File Offset: 0x0000ABAC
	public static void RefreshWallet()
	{
		UnityRuntime.StartRoutine(ApplicationDataManager.StartRefreshWalletInventory());
	}

	// Token: 0x06001238 RID: 4664 RVA: 0x0006D38C File Offset: 0x0006B58C
	public static void OpenUrl(string title, string url)
	{
		if (Application.isWebPlayer)
		{
			Application.ExternalCall("displayMessage", new object[]
			{
				title,
				url
			});
		}
		else
		{
			if (Screen.fullScreen && Application.platform != RuntimePlatform.WindowsPlayer)
			{
				ScreenResolutionManager.IsFullScreen = false;
			}
			Application.OpenURL(url);
		}
	}

	// Token: 0x06001239 RID: 4665 RVA: 0x0006D3E4 File Offset: 0x0006B5E4
	public static void OpenBuyCredits()
	{
		ChannelType channel = ApplicationDataManager.Channel;
		if (channel != ChannelType.Steam)
		{
			ApplicationDataManager.LoadBuyCreditsPage();
			Debug.LogWarning("Buying credits might not be supported on channel: " + ApplicationDataManager.Channel);
		}
		else
		{
			ApplicationDataManager.LoadBuyCreditsPage();
		}
	}

	// Token: 0x0600123A RID: 4666 RVA: 0x0006D434 File Offset: 0x0006B634
	private static void LoadBuyCreditsPage()
	{
		if (!GameState.Current.HasJoinedGame)
		{
			GameData.Instance.MainMenu.Value = MainMenuState.None;
			MenuPageManager.Instance.LoadPage(PageType.Shop, false);
		}
		global::EventHandler.Global.Fire(new ShopEvents.SelectShopArea
		{
			ShopArea = ShopArea.Credits
		});
	}

	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x0600123B RID: 4667 RVA: 0x0006D484 File Offset: 0x0006B684
	public static string FrameRate
	{
		get
		{
			int num = Mathf.Max(Mathf.RoundToInt(Time.smoothDeltaTime * 1000f), 1);
			return string.Format("{0} ({1}ms)", 1000 / num, num);
		}
	}

	// Token: 0x0600123C RID: 4668 RVA: 0x0006D4C4 File Offset: 0x0006B6C4
	private static IEnumerator StartRefreshWalletInventory()
	{
		yield return UnityRuntime.StartRoutine(Singleton<PlayerDataManager>.Instance.StartGetMemberWallet());
		yield return UnityRuntime.StartRoutine(Singleton<ItemManager>.Instance.StartGetInventory(true));
		yield break;
	}

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x0600123D RID: 4669 RVA: 0x0000C9B9 File Offset: 0x0000ABB9
	// (set) Token: 0x0600123E RID: 4670 RVA: 0x0000C9D1 File Offset: 0x0000ABD1
	public static DateTime ServerDateTime
	{
		get
		{
			return ApplicationDataManager.serverDateTime.AddSeconds((double)(Time.time - ApplicationDataManager.applicationDateTime));
		}
		set
		{
			ApplicationDataManager.serverDateTime = value;
			ApplicationDataManager.applicationDateTime = Time.realtimeSinceStartup;
		}
	}

	// Token: 0x04001278 RID: 4728
	public const string HeaderFilename = "UberStrikeHeader";

	// Token: 0x04001279 RID: 4729
	public const string MainFilename = "UberStrikeMain";

	// Token: 0x0400127A RID: 4730
	public const string StandaloneFilename = "UberStrike";

	// Token: 0x0400127B RID: 4731
	public const string Version = "4.7.1";

	// Token: 0x0400127C RID: 4732
	public const int MinimalWidth = 989;

	// Token: 0x0400127D RID: 4733
	public const int MinimalHeight = 560;

	// Token: 0x0400127E RID: 4734
	public static string WebServiceBaseUrl;

	// Token: 0x0400127F RID: 4735
	public static string ImagePath;

	// Token: 0x04001280 RID: 4736
	public static bool IsDebug;

	// Token: 0x04001281 RID: 4737
	private static float applicationDateTime;

	// Token: 0x04001282 RID: 4738
	private static DateTime serverDateTime;

	// Token: 0x04001283 RID: 4739
	public static bool WebPlayerHasResult;
}
