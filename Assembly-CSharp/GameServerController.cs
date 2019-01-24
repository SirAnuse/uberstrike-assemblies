using System;
using System.Collections;

// Token: 0x020002B0 RID: 688
public class GameServerController : Singleton<GameServerController>
{
	// Token: 0x0600130D RID: 4877 RVA: 0x0000D028 File Offset: 0x0000B228
	private GameServerController()
	{
	}

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x0600130E RID: 4878 RVA: 0x0000D030 File Offset: 0x0000B230
	// (set) Token: 0x0600130F RID: 4879 RVA: 0x0000D038 File Offset: 0x0000B238
	public PhotonServer SelectedServer { get; set; }

	// Token: 0x06001310 RID: 4880 RVA: 0x0000D041 File Offset: 0x0000B241
	public void JoinFastestServer()
	{
		UnityRuntime.StartRoutine(this.StartJoiningBestGameServer());
	}

	// Token: 0x06001311 RID: 4881 RVA: 0x0000D04F File Offset: 0x0000B24F
	public void CreateOnFastestServer()
	{
		UnityRuntime.StartRoutine(this.StartCreatingOnBestGameServer());
	}

	// Token: 0x06001312 RID: 4882 RVA: 0x00070070 File Offset: 0x0006E270
	private IEnumerator StartJoiningBestGameServer()
	{
		if (Singleton<GameServerController>.Instance.SelectedServer == null)
		{
			ProgressPopupDialog _autoJoinPopup = PopupSystem.ShowProgress(LocalizedStrings.LoadingGameList, LocalizedStrings.FindingAServerToJoin, null);
			yield return UnityRuntime.StartRoutine(Singleton<GameServerManager>.Instance.StartUpdatingLatency(delegate(float progress)
			{
				_autoJoinPopup.Progress = progress;
			}));
			PhotonServer bestServer = Singleton<GameServerManager>.Instance.GetBestServer();
			if (bestServer == null)
			{
				PopupSystem.HideMessage(_autoJoinPopup);
				PopupSystem.ShowMessage("Could not find server", "No suitable server could be located! Please try again soon.");
				yield break;
			}
			Singleton<GameServerController>.Instance.SelectedServer = bestServer;
			PopupSystem.HideMessage(_autoJoinPopup);
		}
		MenuPageManager.Instance.LoadPage(PageType.Play, false);
		yield break;
	}

	// Token: 0x06001313 RID: 4883 RVA: 0x00070084 File Offset: 0x0006E284
	private IEnumerator StartCreatingOnBestGameServer()
	{
		if (Singleton<GameServerController>.Instance.SelectedServer == null)
		{
			ProgressPopupDialog _autoJoinPopup = PopupSystem.ShowProgress(LocalizedStrings.LoadingGameList, LocalizedStrings.FindingAServerToJoin, null);
			yield return UnityRuntime.StartRoutine(Singleton<GameServerManager>.Instance.StartUpdatingLatency(delegate(float progress)
			{
				_autoJoinPopup.Progress = progress;
			}));
			PhotonServer bestServer = Singleton<GameServerManager>.Instance.GetBestServer();
			if (bestServer == null)
			{
				PopupSystem.HideMessage(_autoJoinPopup);
				PopupSystem.ShowMessage("Could not find server", "No suitable server could be located! Please try again soon.");
				yield break;
			}
			Singleton<GameServerController>.Instance.SelectedServer = bestServer;
			PopupSystem.HideMessage(_autoJoinPopup);
		}
		PanelManager.Instance.OpenPanel(PanelType.CreateGame);
		yield break;
	}
}
