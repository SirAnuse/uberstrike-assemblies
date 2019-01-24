using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x0200032A RID: 810
public class HUDJoinButtons : MonoBehaviour
{
	// Token: 0x06001696 RID: 5782 RVA: 0x0007D624 File Offset: 0x0007B824
	private void Start()
	{
		this.spectate.gameObject.SetActive(PlayerDataManager.AccessLevel >= MemberAccessLevel.QA);
		GameData.Instance.OnEndOfMatchTimer.AddEvent(delegate()
		{
			this.panel.gameObject.SetActive(true);
		}, this);
		this.joinBlue.OnClicked = delegate()
		{
			GamePageManager.Instance.UnloadCurrentPage();
			GameState.Current.Actions.JoinTeam(TeamID.BLUE);
		};
		this.joinRed.OnClicked = delegate()
		{
			GamePageManager.Instance.UnloadCurrentPage();
			GameState.Current.Actions.JoinTeam(TeamID.RED);
		};
		this.join.OnClicked = delegate()
		{
			GamePageManager.Instance.UnloadCurrentPage();
			GameState.Current.Actions.JoinTeam(TeamID.NONE);
		};
		this.spectate.OnClicked = delegate()
		{
			GamePageManager.Instance.UnloadCurrentPage();
			GameState.Current.PlayerData.Team = new Property<TeamID>(TeamID.NONE);
			GameState.Current.Actions.JoinAsSpectator();
		};
	}

	// Token: 0x06001697 RID: 5783 RVA: 0x0007D708 File Offset: 0x0007B908
	private void OnEnable()
	{
		bool isTeamGame = GameState.Current.IsTeamGame;
		if (GameState.Current.MatchState.CurrentStateId != GameStateId.PregameLoadout)
		{
			this.panel.gameObject.SetActive(false);
		}
		this.joinBlue.gameObject.SetActive(isTeamGame);
		this.joinRed.gameObject.SetActive(isTeamGame);
		this.join.gameObject.SetActive(!isTeamGame);
		foreach (UISprite uisprite in this.blueBars)
		{
			uisprite.enabled = isTeamGame;
		}
		foreach (UISprite uisprite2 in this.redBars)
		{
			uisprite2.enabled = isTeamGame;
		}
		foreach (UISprite uisprite3 in this.bars)
		{
			uisprite3.enabled = !isTeamGame;
		}
	}

	// Token: 0x06001698 RID: 5784 RVA: 0x0007D808 File Offset: 0x0007BA08
	private void Update()
	{
		if (GameState.Current.IsTeamGame)
		{
			int value = Mathf.CeilToInt((float)GameState.Current.RoomData.PlayerLimit / 2f);
			this.joinBlue.GetComponent<UIButton>().isEnabled = GameState.Current.CanJoinBlueTeam;
			int blueTeamPlayerCount = GameState.Current.BlueTeamPlayerCount;
			int num = Mathf.Clamp(value, 0, this.blueBars.Length);
			for (int i = 0; i < this.blueBars.Length; i++)
			{
				this.blueBars[i].enabled = (i < num);
				this.blueBars[i].color = ((i >= blueTeamPlayerCount) ? GUIUtils.ColorBlack : GUIUtils.ColorBlue);
			}
			this.joinRed.GetComponent<UIButton>().isEnabled = GameState.Current.CanJoinRedTeam;
			int redTeamPlayerCount = GameState.Current.RedTeamPlayerCount;
			int num2 = Mathf.Clamp(value, 0, this.redBars.Length);
			for (int j = 0; j < this.redBars.Length; j++)
			{
				this.redBars[j].enabled = (j < num2);
				this.redBars[j].color = ((j >= redTeamPlayerCount) ? GUIUtils.ColorBlack : GUIUtils.ColorRed);
			}
		}
		else
		{
			int playerLimit = GameState.Current.RoomData.PlayerLimit;
			int count = GameState.Current.Players.Count;
			for (int k = 0; k < this.bars.Length; k++)
			{
				this.bars[k].enabled = (k < playerLimit);
				this.bars[k].color = ((k >= count) ? GUIUtils.ColorBlack : GUIUtils.ColorBlue);
			}
		}
	}

	// Token: 0x0400157C RID: 5500
	[SerializeField]
	private UIPanel panel;

	// Token: 0x0400157D RID: 5501
	[SerializeField]
	private UIEventReceiver joinBlue;

	// Token: 0x0400157E RID: 5502
	[SerializeField]
	private UIEventReceiver joinRed;

	// Token: 0x0400157F RID: 5503
	[SerializeField]
	private UIEventReceiver join;

	// Token: 0x04001580 RID: 5504
	[SerializeField]
	private UIEventReceiver spectate;

	// Token: 0x04001581 RID: 5505
	[SerializeField]
	private UISprite[] blueBars;

	// Token: 0x04001582 RID: 5506
	[SerializeField]
	private UISprite[] redBars;

	// Token: 0x04001583 RID: 5507
	[SerializeField]
	private UISprite[] bars;
}
