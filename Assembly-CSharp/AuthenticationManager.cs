using System;
using System.Collections;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using Steamworks;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UberStrike.Core.ViewModel;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x02000299 RID: 665
public class AuthenticationManager : Singleton<AuthenticationManager>
{
	// Token: 0x06001245 RID: 4677 RVA: 0x0000C9F4 File Offset: 0x0000ABF4
	private AuthenticationManager()
	{
		this._progress = new ProgressPopupDialog(LocalizedStrings.SettingUp, LocalizedStrings.ProcessingLogin, null);
	}

	// Token: 0x1700046C RID: 1132
	// (get) Token: 0x06001246 RID: 4678 RVA: 0x0000CA12 File Offset: 0x0000AC12
	// (set) Token: 0x06001247 RID: 4679 RVA: 0x0000CA1A File Offset: 0x0000AC1A
	public bool IsAuthComplete { get; private set; }

	// Token: 0x06001248 RID: 4680 RVA: 0x0000CA23 File Offset: 0x0000AC23
	public void SetAuthComplete(bool enabled)
	{
		this.IsAuthComplete = enabled;
	}

	// Token: 0x06001249 RID: 4681 RVA: 0x0006D55C File Offset: 0x0006B75C
	public void LoginByChannel()
	{
		string @string = PlayerPrefs.GetString("CurrentSteamUser", string.Empty);
		Debug.Log(string.Format("SteamWorks SteamID:{0}, PlayerPrefs SteamID:{1}", PlayerDataManager.SteamId, @string));
		if (string.IsNullOrEmpty(@string) || @string != PlayerDataManager.SteamId)
		{
			Debug.Log(string.Format("No SteamID saved. Using SteamWorks SteamID:{0}", PlayerDataManager.SteamId));
			PopupSystem.ShowMessage(string.Empty, "Have you played UberStrike before?", PopupSystem.AlertType.OKCancel, delegate()
			{
				UnityRuntime.StartRoutine(this.StartLoginMemberSteam(true));
			}, "No", delegate()
			{
				PopupSystem.ShowMessage(string.Empty, "Do you want to upgrade an UberStrike.com or Facebook account?\n\nNOTE: This will permenantly link your UberStrike account to this Steam ID", PopupSystem.AlertType.OKCancel, delegate()
				{
					UnityRuntime.StartRoutine(this.StartLoginMemberSteam(true));
				}, "No", delegate()
				{
					UnityRuntime.StartRoutine(this.StartLoginMemberSteam(false));
				}, "Yes");
			}, "Yes");
		}
		else
		{
			Debug.Log(string.Format("Login using saved SteamID:{0}", @string));
			UnityRuntime.StartRoutine(this.StartLoginMemberSteam(true));
		}
	}

	// Token: 0x0600124A RID: 4682 RVA: 0x0006D614 File Offset: 0x0006B814
	public IEnumerator StartLoginMemberEmail(string emailAddress, string password)
	{
		if (string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
		{
			this.ShowLoginErrorPopup(LocalizedStrings.Error, "Your login credentials are not correct. Please try to login again.");
			yield break;
		}
		this._progress.Text = "Authenticating Account";
		this._progress.Progress = 0.1f;
		PopupSystem.Show(this._progress);
		MemberAuthenticationResultView authenticationView = null;
		if (ApplicationDataManager.Channel == ChannelType.Steam)
		{
			yield return AuthenticationWebServiceClient.LinkSteamMember(emailAddress, password, PlayerDataManager.SteamId, SystemInfo.deviceUniqueIdentifier, delegate(MemberAuthenticationResultView ev)
			{
				authenticationView = ev;
				PlayerPrefs.SetString("CurrentSteamUser", PlayerDataManager.SteamId);
				PlayerPrefs.Save();
			}, delegate(Exception ex)
			{
			});
		}
		else
		{
			yield return AuthenticationWebServiceClient.LoginMemberEmail(emailAddress, password, ApplicationDataManager.Channel, SystemInfo.deviceUniqueIdentifier, delegate(MemberAuthenticationResultView ev)
			{
				authenticationView = ev;
			}, delegate(Exception ex)
			{
			});
		}
		if (authenticationView == null)
		{
			this.ShowLoginErrorPopup(LocalizedStrings.Error, "The login could not be processed. Please check your internet connection and try again.");
			yield break;
		}
		yield return UnityRuntime.StartRoutine(this.CompleteAuthentication(authenticationView, false));
		yield break;
	}

	// Token: 0x0600124B RID: 4683 RVA: 0x0006D64C File Offset: 0x0006B84C
	public IEnumerator StartLoginMemberSteam(bool directSteamLogin)
	{
		if (directSteamLogin)
		{
			this._progress.Text = "Authenticating with Steam";
			this._progress.Progress = 0.05f;
			PopupSystem.Show(this._progress);
			this.m_GetAuthSessionTicketResponse = Callback<GetAuthSessionTicketResponse_t>.Create(new Callback<GetAuthSessionTicketResponse_t>.DispatchDelegate(this.OnGetAuthSessionTicketResponse));
			byte[] ticket = new byte[1024];
			uint pcbTicket;
			HAuthTicket authTicket = SteamUser.GetAuthSessionTicket(ticket, 1024, out pcbTicket);
			int num = (int)pcbTicket;
			string authToken = num.ToString();
			string machineId = SystemInfo.deviceUniqueIdentifier;
			MemberAuthenticationResultView authenticationView = null;
			this._progress.Text = "Authenticating with UberStrike";
			this._progress.Progress = 0.1f;
			yield return AuthenticationWebServiceClient.LoginSteam(PlayerDataManager.SteamId, authToken, machineId, delegate(MemberAuthenticationResultView result)
			{
				authenticationView = result;
				PlayerPrefs.SetString("CurrentSteamUser", PlayerDataManager.SteamId);
				PlayerPrefs.Save();
			}, delegate(Exception error)
			{
				Debug.LogError("Account authentication error: " + error);
				this.ShowLoginErrorPopup(LocalizedStrings.Error, "There was an error logging you in. Please try again or contact us at http://support.cmune.com");
			});
			yield return UnityRuntime.StartRoutine(this.CompleteAuthentication(authenticationView, false));
		}
		else
		{
			PopupSystem.ClearAll();
			yield return PanelManager.Instance.OpenPanel(PanelType.Login);
		}
		yield break;
	}

	// Token: 0x0600124C RID: 4684 RVA: 0x0006D678 File Offset: 0x0006B878
	private void OnGetAuthSessionTicketResponse(GetAuthSessionTicketResponse_t pCallback)
	{
		Debug.Log(string.Concat(new object[]
		{
			"[",
			163,
			" - GetAuthSessionTicketResponse] - ",
			pCallback.m_hAuthTicket,
			" -- ",
			pCallback.m_eResult
		}));
	}

	// Token: 0x0600124D RID: 4685 RVA: 0x0006D6D8 File Offset: 0x0006B8D8
	private IEnumerator CompleteAuthentication(MemberAuthenticationResultView authView, bool isRegistrationLogin = false)
	{
		if (authView == null)
		{
			Debug.LogError("Account authentication error: MemberAuthenticationResultView was null, isRegistrationLogin: " + isRegistrationLogin);
			this.ShowLoginErrorPopup(LocalizedStrings.Error, "There was an error logging you in. Please try again or contact us at http://support.cmune.com");
			yield break;
		}
		if (authView.MemberAuthenticationResult == MemberAuthenticationResult.IsBanned || authView.MemberAuthenticationResult == MemberAuthenticationResult.IsIpBanned)
		{
			ApplicationDataManager.LockApplication(LocalizedStrings.YourAccountHasBeenBanned);
			yield break;
		}
		if (authView.MemberAuthenticationResult == MemberAuthenticationResult.InvalidEsns)
		{
			Debug.Log("Result: " + authView.MemberAuthenticationResult);
			this.ShowLoginErrorPopup(LocalizedStrings.Error, "Sorry this account is linked already.");
			yield break;
		}
		if (authView.MemberAuthenticationResult != MemberAuthenticationResult.Ok)
		{
			Debug.Log("Result: " + authView.MemberAuthenticationResult);
			this.ShowLoginErrorPopup(LocalizedStrings.Error, "Your login credentials are not correct. Please try to login again.");
			yield break;
		}
		Singleton<PlayerDataManager>.Instance.SetLocalPlayerMemberView(authView.MemberView);
		PlayerDataManager.AuthToken = authView.AuthToken;
		if (!PlayerDataManager.IsTestBuild)
		{
			PlayerDataManager.MagicHash = UberDaemon.Instance.GetMagicHash(authView.AuthToken);
			Debug.Log("Magic Hash:" + PlayerDataManager.MagicHash);
		}
		ApplicationDataManager.ServerDateTime = authView.ServerTime;
		global::EventHandler.Global.Fire(new GlobalEvents.Login(authView.MemberView.PublicProfile.AccessLevel));
		this._progress.Text = LocalizedStrings.LoadingFriendsList;
		this._progress.Progress = 0.2f;
		yield return UnityRuntime.StartRoutine(Singleton<CommsManager>.Instance.GetContactsByGroups());
		this._progress.Text = LocalizedStrings.LoadingCharacterData;
		this._progress.Progress = 0.3f;
		yield return ApplicationWebServiceClient.GetConfigurationData("4.7.1", delegate(ApplicationConfigurationView appConfigView)
		{
			XpPointsUtil.Config = appConfigView;
		}, delegate(Exception ex)
		{
			ApplicationDataManager.LockApplication(LocalizedStrings.ErrorLoadingData);
		});
		Singleton<PlayerDataManager>.Instance.SetPlayerStatisticsView(authView.PlayerStatisticsView);
		this._progress.Text = LocalizedStrings.LoadingMapData;
		this._progress.Progress = 0.5f;
		bool mapsLoadedSuccessfully = false;
		yield return ApplicationWebServiceClient.GetMaps("4.7.1", DefinitionType.StandardDefinition, delegate(List<MapView> callback)
		{
			mapsLoadedSuccessfully = Singleton<MapManager>.Instance.InitializeMapsToLoad(callback);
		}, delegate(Exception ex)
		{
			ApplicationDataManager.LockApplication(LocalizedStrings.ErrorLoadingMaps);
		});
		if (!mapsLoadedSuccessfully)
		{
			this.ShowLoginErrorPopup(LocalizedStrings.Error, LocalizedStrings.ErrorLoadingMapsSupport);
			PopupSystem.HideMessage(this._progress);
			yield break;
		}
		this._progress.Progress = 0.6f;
		this._progress.Text = LocalizedStrings.LoadingWeaponAndGear;
		yield return UnityRuntime.StartRoutine(Singleton<ItemManager>.Instance.StartGetShop());
		if (!Singleton<ItemManager>.Instance.ValidateItemMall())
		{
			PopupSystem.HideMessage(this._progress);
			yield break;
		}
		this._progress.Progress = 0.7f;
		this._progress.Text = LocalizedStrings.LoadingPlayerInventory;
		yield return UnityRuntime.StartRoutine(Singleton<ItemManager>.Instance.StartGetInventory(false));
		this._progress.Progress = 0.8f;
		this._progress.Text = LocalizedStrings.GettingPlayerLoadout;
		yield return UnityRuntime.StartRoutine(Singleton<PlayerDataManager>.Instance.StartGetLoadout());
		if (!Singleton<LoadoutManager>.Instance.ValidateLoadout())
		{
			this.ShowLoginErrorPopup(LocalizedStrings.ErrorGettingPlayerLoadout, LocalizedStrings.ErrorGettingPlayerLoadoutSupport);
			yield break;
		}
		this._progress.Progress = 0.85f;
		this._progress.Text = LocalizedStrings.LoadingPlayerStatistics;
		yield return UnityRuntime.StartRoutine(Singleton<PlayerDataManager>.Instance.StartGetMember());
		if (!Singleton<PlayerDataManager>.Instance.ValidateMemberData())
		{
			this.ShowLoginErrorPopup(LocalizedStrings.ErrorGettingPlayerStatistics, LocalizedStrings.ErrorPlayerStatisticsSupport);
			yield break;
		}
		this._progress.Progress = 0.9f;
		this._progress.Text = LocalizedStrings.LoadingClanData;
		yield return ClanWebServiceClient.GetMyClanId(PlayerDataManager.AuthToken, delegate(int id)
		{
			PlayerDataManager.ClanID = id;
		}, delegate(Exception ex)
		{
		});
		if (PlayerDataManager.ClanID > 0)
		{
			yield return ClanWebServiceClient.GetOwnClan(PlayerDataManager.AuthToken, PlayerDataManager.ClanID, delegate(ClanView ev)
			{
				Singleton<ClanDataManager>.Instance.SetClanData(ev);
			}, delegate(Exception ex)
			{
			});
		}
		GameState.Current.Avatar.SetDecorator(global::AvatarBuilder.CreateLocalAvatar());
		GameState.Current.Avatar.UpdateAllWeapons();
		yield return new WaitForEndOfFrame();
		Singleton<InboxManager>.Instance.Initialize();
		yield return new WaitForEndOfFrame();
		Singleton<BundleManager>.Instance.Initialize();
		yield return new WaitForEndOfFrame();
		PopupSystem.HideMessage(this._progress);
		if (!authView.IsAccountComplete)
		{
			PanelManager.Instance.OpenPanel(PanelType.CompleteAccount);
		}
		else
		{
			MenuPageManager.Instance.LoadPage(PageType.Home, false);
			this.IsAuthComplete = true;
		}
		Debug.LogWarning(string.Format("AuthToken:{0}, MagicHash:{1}", PlayerDataManager.AuthToken, PlayerDataManager.MagicHash));
		yield break;
	}

	// Token: 0x0600124E RID: 4686 RVA: 0x0000CA2C File Offset: 0x0000AC2C
	public void StartLogout()
	{
		UnityRuntime.StartRoutine(this.Logout());
	}

	// Token: 0x0600124F RID: 4687 RVA: 0x0006D710 File Offset: 0x0006B910
	private IEnumerator Logout()
	{
		if (GameState.Current.HasJoinedGame)
		{
			Singleton<GameStateController>.Instance.LeaveGame(false);
			yield return new WaitForSeconds(3f);
		}
		MenuPageManager.Instance.LoadPage(PageType.Home, false);
		MenuPageManager.Instance.UnloadCurrentPage();
		GlobalUIRibbon.Instance.Hide();
		if (GameState.Current.Avatar.Decorator != null)
		{
			global::AvatarBuilder.Destroy(GameState.Current.Avatar.Decorator.gameObject);
		}
		GameState.Current.Avatar.SetDecorator(null);
		Singleton<PlayerDataManager>.Instance.Dispose();
		Singleton<InventoryManager>.Instance.Dispose();
		Singleton<LoadoutManager>.Instance.Dispose();
		Singleton<ClanDataManager>.Instance.Dispose();
		Singleton<ChatManager>.Instance.Dispose();
		Singleton<InboxManager>.Instance.Dispose();
		Singleton<TransactionHistory>.Instance.Dispose();
		Singleton<BundleManager>.Instance.Dispose();
		Singleton<GameStateController>.Instance.ResetClient();
		AutoMonoBehaviour<CommConnectionManager>.Instance.Reconnect();
		InboxThread.Current = null;
		global::EventHandler.Global.Fire(new GlobalEvents.Logout());
		GameData.Instance.MainMenu.Value = MainMenuState.Logout;
		Application.Quit();
		yield break;
	}

	// Token: 0x06001250 RID: 4688 RVA: 0x0000CA3A File Offset: 0x0000AC3A
	private void ShowLoginErrorPopup(string title, string message)
	{
		Debug.Log("Login Error!");
		PopupSystem.HideMessage(this._progress);
		PopupSystem.ShowMessage(title, message, PopupSystem.AlertType.OK, delegate()
		{
			LoginPanelGUI.ErrorMessage = string.Empty;
			this.LoginByChannel();
		});
	}

	// Token: 0x04001289 RID: 4745
	private ProgressPopupDialog _progress;

	// Token: 0x0400128A RID: 4746
	private Callback<GetAuthSessionTicketResponse_t> m_GetAuthSessionTicketResponse;
}
