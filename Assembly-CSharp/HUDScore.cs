using System;
using System.Collections;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000336 RID: 822
public class HUDScore : MonoBehaviour
{
	// Token: 0x060016E5 RID: 5861 RVA: 0x0007EA34 File Offset: 0x0007CC34
	private void OnEnable()
	{
		int num = (GameState.Current.PlayerData.Team != TeamID.BLUE) ? GameState.Current.ScoreRed : GameState.Current.ScoreBlue;
		int num2 = (GameState.Current.PlayerData.Team != TeamID.BLUE) ? GameState.Current.ScoreBlue : GameState.Current.ScoreRed;
		this.panel.gameObject.SetActive(true);
		this.blueLabel.text = GameState.Current.ScoreBlue.ToString();
		this.redLabel.text = GameState.Current.ScoreRed.ToString();
		bool isTeamGame = GameState.Current.IsTeamGame;
		this.blueLabel.enabled = isTeamGame;
		this.blueBgr.enabled = isTeamGame;
		this.redLabel.enabled = isTeamGame;
		this.redBgr.enabled = isTeamGame;
		if (isTeamGame)
		{
			if (num > num2)
			{
				this.titleLabel.text = "Your Team Won!";
			}
			else if (num < num2)
			{
				this.titleLabel.text = "Your Team Lost";
			}
			else
			{
				this.titleLabel.text = "Draw";
			}
		}
		else
		{
			List<GameActorInfo> list = new List<GameActorInfo>(GameState.Current.Players.Values);
			int maxScore = list.Reduce((GameActorInfo player, int prev) => Mathf.Max((int)player.Kills, prev), int.MinValue);
			List<GameActorInfo> list2 = list.FindAll((GameActorInfo el) => (int)el.Kills == maxScore);
			string str = string.Empty;
			list2.ForEach(delegate(GameActorInfo el)
			{
				str = str + el.PlayerName + " ";
			});
			this.titleLabel.text = str + "won!";
		}
		base.StartCoroutine(this.Wait5Seconds());
	}

	// Token: 0x060016E6 RID: 5862 RVA: 0x0007EC30 File Offset: 0x0007CE30
	private IEnumerator Wait5Seconds()
	{
		for (int i = 5; i > 0; i--)
		{
			this.timerLabel.text = i.ToString();
			UITweener.Begin<TweenScale>(this.timerLabel.gameObject, 0.5f);
			UITweener.Begin<TweenAlpha>(this.timerLabel.gameObject, 0.25f);
			yield return new WaitForSeconds(1f);
		}
		this.panel.gameObject.SetActive(false);
		GameData.Instance.OnEndOfMatchTimer.Fire();
		yield break;
	}

	// Token: 0x040015E0 RID: 5600
	[SerializeField]
	private UIPanel panel;

	// Token: 0x040015E1 RID: 5601
	[SerializeField]
	private UILabel timerLabel;

	// Token: 0x040015E2 RID: 5602
	[SerializeField]
	private UILabel blueLabel;

	// Token: 0x040015E3 RID: 5603
	[SerializeField]
	private UISprite blueBgr;

	// Token: 0x040015E4 RID: 5604
	[SerializeField]
	private UILabel redLabel;

	// Token: 0x040015E5 RID: 5605
	[SerializeField]
	private UISprite redBgr;

	// Token: 0x040015E6 RID: 5606
	[SerializeField]
	private UILabel titleLabel;
}
