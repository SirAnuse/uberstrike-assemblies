using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000326 RID: 806
public class HUDButtons : MonoBehaviour
{
	// Token: 0x0600167B RID: 5755 RVA: 0x0007CB78 File Offset: 0x0007AD78
	private void Start()
	{
		this.continueButton.gameObject.SetActive(false);
		this.respawnButton.gameObject.SetActive(false);
		this.changeTeamButton.gameObject.SetActive(false);
		GameData.Instance.PlayerState.AddEventAndFire(delegate(PlayerStateId el)
		{
			bool flag = el == PlayerStateId.Paused;
			bool flag2 = el == PlayerStateId.Killed;
			bool flag3 = GameState.Current.GameMode == GameModeType.None;
			this.respawnButton.gameObject.SetActive(flag2 && flag3);
			this.continueButton.gameObject.SetActive(flag);
			this.changeTeamButton.gameObject.SetActive(flag && GameStateHelper.CanChangeTeam());
			this.loadoutButton.gameObject.SetActive(flag || flag2);
			this.loadoutButtonLabel.text = ((!flag || flag3) ? "Loadout" : "Chat");
		}, this);
		GameData.Instance.OnRespawnCountdown.AddEvent(delegate(int el)
		{
			bool flag = el == 0;
			this.respawnButton.gameObject.SetActive(flag);
			this.changeTeamButton.gameObject.SetActive(flag && GameStateHelper.CanChangeTeam());
		}, this);
		this.continueButton.OnClicked = delegate()
		{
			if (PanelManager.Instance != null && (PanelManager.Instance.IsPanelOpen(PanelType.Options) || PanelManager.Instance.IsPanelOpen(PanelType.Help)))
			{
				return;
			}
			InputManager.SkipFrame = Time.frameCount;
			GameState.Current.PlayerState.PopState(true);
			global::EventHandler.Global.Fire(new GameEvents.PlayerUnpause());
			GamePageManager.Instance.UnloadCurrentPage();
		};
		this.respawnButton.OnClicked = delegate()
		{
			RenderSettingsController.Instance.ResetInterpolation();
			if (PanelManager.Instance != null && (PanelManager.Instance.IsPanelOpen(PanelType.Options) || PanelManager.Instance.IsPanelOpen(PanelType.Help)))
			{
				return;
			}
			this.respawnButton.gameObject.SetActive(false);
			this.changeTeamButton.gameObject.SetActive(false);
			if (GameState.Current.GameMode == GameModeType.None)
			{
				GameStateHelper.RespawnLocalPlayerAtRandom();
				GameState.Current.PlayerState.SetState(PlayerStateId.Playing);
			}
			else
			{
				GameState.Current.Actions.RequestRespawn();
			}
			GamePageManager.Instance.UnloadCurrentPage();
		};
		this.changeTeamButton.OnClicked = delegate()
		{
			this.respawnButton.gameObject.SetActive(false);
			this.changeTeamButton.gameObject.SetActive(false);
			GamePageManager.Instance.UnloadCurrentPage();
			GameData.Instance.OnNotification.Fire("Changing Team...");
			GameState.Current.Actions.ChangeTeam();
			if (GameData.Instance.PlayerState.Value == PlayerStateId.Killed)
			{
				GameState.Current.Actions.RequestRespawn();
			}
		};
		this.loadoutButton.OnClicked = delegate()
		{
			if (GamePageManager.IsCurrentPage(IngamePageType.None))
			{
				if (GameState.Current.IsSinglePlayer)
				{
					GamePageManager.Instance.LoadPage(IngamePageType.PausedOffline);
				}
				else if (!GameState.Current.IsMatchRunning || !GameState.Current.PlayerData.IsAlive)
				{
					GamePageManager.Instance.LoadPage(IngamePageType.PausedWaiting);
				}
				else
				{
					GamePageManager.Instance.LoadPage(IngamePageType.Paused);
				}
			}
			else
			{
				GamePageManager.Instance.UnloadCurrentPage();
			}
		};
	}

	// Token: 0x0600167C RID: 5756 RVA: 0x0007CC70 File Offset: 0x0007AE70
	private void OnEnable()
	{
		this.continueButton.gameObject.SetActive(false);
		this.respawnButton.gameObject.SetActive(false);
		this.changeTeamButton.gameObject.SetActive(false);
		this.loadoutButton.gameObject.SetActive(false);
		GameData.Instance.PlayerState.Fire();
	}

	// Token: 0x04001558 RID: 5464
	[SerializeField]
	private UIEventReceiver continueButton;

	// Token: 0x04001559 RID: 5465
	[SerializeField]
	private UIEventReceiver respawnButton;

	// Token: 0x0400155A RID: 5466
	[SerializeField]
	private UIEventReceiver changeTeamButton;

	// Token: 0x0400155B RID: 5467
	[SerializeField]
	private UIEventReceiver loadoutButton;

	// Token: 0x0400155C RID: 5468
	[SerializeField]
	private UILabel loadoutButtonLabel;
}
