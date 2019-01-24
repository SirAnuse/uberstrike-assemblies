using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000339 RID: 825
public class HUDStatusPanel : MonoBehaviour
{
	// Token: 0x1700054D RID: 1357
	// (get) Token: 0x060016F3 RID: 5875 RVA: 0x0000F70F File Offset: 0x0000D90F
	// (set) Token: 0x060016F4 RID: 5876 RVA: 0x0000F717 File Offset: 0x0000D917
	private int RemainingSeconds
	{
		get
		{
			return this.remainingSeconds;
		}
		set
		{
			if (this.remainingSeconds != value)
			{
				this.remainingSeconds = Mathf.Max(value, 0);
				this.timerLabel.text = this.GetClockString(this.remainingSeconds);
				this.OnUpdateRemainingSeconds();
			}
		}
	}

	// Token: 0x1700054E RID: 1358
	// (set) Token: 0x060016F5 RID: 5877 RVA: 0x0007ED40 File Offset: 0x0007CF40
	private int KillsRemaining
	{
		set
		{
			int num = Mathf.Max(value, 0);
			if (this.remainingKillsRounds != num)
			{
				this.remainingKillsRounds = value;
				this.statusLabel.text = this.GetRemainingKillString(value);
			}
		}
	}

	// Token: 0x060016F6 RID: 5878 RVA: 0x0000F74F File Offset: 0x0000D94F
	private void OnEnable()
	{
		GameState.Current.PlayerData.Team.Fire();
		global::EventHandler.Global.AddListener<GameEvents.MatchCountdown>(new Action<GameEvents.MatchCountdown>(this.OnMatchStartCountdownEvent));
	}

	// Token: 0x060016F7 RID: 5879 RVA: 0x0000F77B File Offset: 0x0000D97B
	private void OnDisable()
	{
		global::EventHandler.Global.RemoveListener<GameEvents.MatchCountdown>(new Action<GameEvents.MatchCountdown>(this.OnMatchStartCountdownEvent));
	}

	// Token: 0x060016F8 RID: 5880 RVA: 0x0007ED7C File Offset: 0x0007CF7C
	private void Start()
	{
		this.countDownLabel.gameObject.SetActive(false);
		GameState.Current.PlayerData.RemainingTime.AddEventAndFire(delegate(int el)
		{
			this.RemainingSeconds = el;
		}, this);
		GameState.Current.PlayerData.RemainingKills.AddEventAndFire(delegate(int el)
		{
			this.KillsRemaining = el;
		}, this);
		GameState.Current.PlayerData.Team.AddEventAndFire(delegate(TeamID el)
		{
			this.blueBgr.color = ((el != TeamID.BLUE) ? GUIUtils.ColorBlue.SetAlpha(0.3137255f) : GUIUtils.ColorBlue.SetAlpha(1f));
			this.redBgr.color = ((el != TeamID.RED) ? GUIUtils.ColorRed.SetAlpha(0.3137255f) : GUIUtils.ColorRed.SetAlpha(1f));
			this.blueTriangle.enabled = (el == TeamID.BLUE);
			this.redTriangle.enabled = (el == TeamID.RED);
			this.SetupGameMode(GameState.Current.IsTeamGame);
		}, this);
	}

	// Token: 0x060016F9 RID: 5881 RVA: 0x0007EE00 File Offset: 0x0007D000
	private void SetupGameMode(bool isTeamGame)
	{
		this.scores.SetActive(isTeamGame);
		if (isTeamGame)
		{
			GameState.Current.PlayerData.BlueTeamScore.AddEventAndFire(delegate(int el)
			{
				this.blueLabel.text = el.ToString();
			}, this);
			GameState.Current.PlayerData.RedTeamScore.AddEventAndFire(delegate(int el)
			{
				this.redLabel.text = el.ToString();
			}, this);
		}
	}

	// Token: 0x060016FA RID: 5882 RVA: 0x0007EE64 File Offset: 0x0007D064
	private void OnMatchStartCountdownEvent(GameEvents.MatchCountdown ev)
	{
		this.scores.SetActive(ev.Countdown < 1);
		this.timerLabel.gameObject.SetActive(ev.Countdown < 1);
		this.statusLabel.text = LocalizedStrings.StartsInCaps;
		this.countDownLabel.text = ev.Countdown.ToString();
		UITweener.Begin<TweenScale>(this.countDownLabel.gameObject, 0.5f);
		UITweener.Begin<TweenAlpha>(this.countDownLabel.gameObject, 0.25f);
		this.countDownLabel.gameObject.SetActive(ev.Countdown > 0);
	}

	// Token: 0x060016FB RID: 5883 RVA: 0x0007EF0C File Offset: 0x0007D10C
	private void OnUpdateRemainingSeconds()
	{
		if (this.remainingSeconds > HUDStatusPanel.WARNING_TIME_LOW_VALUE || this.remainingSeconds <= 0)
		{
			this.StopPulse();
			return;
		}
		UITweener.Begin<TweenScale>(this.timerLabel.gameObject, 0.5f);
		switch (this.RemainingSeconds)
		{
		case 1:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown1, 0UL, 1f, 1f);
			break;
		case 2:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown2, 0UL, 1f, 1f);
			break;
		case 3:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown3, 0UL, 1f, 1f);
			break;
		case 4:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown4, 0UL, 1f, 1f);
			break;
		case 5:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown5, 0UL, 1f, 1f);
			break;
		}
	}

	// Token: 0x060016FC RID: 5884 RVA: 0x0000F793 File Offset: 0x0000D993
	private void StopPulse()
	{
		if (this.timerTween.enabled)
		{
			this.timerTween.Reset();
			this.timerTween.enabled = false;
		}
	}

	// Token: 0x060016FD RID: 5885 RVA: 0x0007F01C File Offset: 0x0007D21C
	public void IsOnPaused(bool isPaused)
	{
		SpringPosition.Begin(this.mainPanel.gameObject, new Vector3(0f, (!isPaused) ? 0f : -60f, 0f), 10f).onFinished = delegate(SpringPosition el)
		{
			el.enabled = false;
		};
	}

	// Token: 0x060016FE RID: 5886 RVA: 0x0000F7BC File Offset: 0x0000D9BC
	private string GetRemainingKillString(int remainingKills)
	{
		if (remainingKills > 1)
		{
			return string.Format(LocalizedStrings.NKillsLeft, remainingKills);
		}
		return LocalizedStrings.OneKillLeft;
	}

	// Token: 0x060016FF RID: 5887 RVA: 0x0007F084 File Offset: 0x0007D284
	private string GetRemainingRoundsString(int remainingRounds)
	{
		if (remainingRounds != 1)
		{
			return string.Format(LocalizedStrings.NRoundsLeft, remainingRounds);
		}
		if (GameState.Current.ScoreBlue > GameState.Current.ScoreRed)
		{
			return string.Format(LocalizedStrings.FinalRoundX, LocalizedStrings.BlueCaps);
		}
		if (GameState.Current.ScoreRed > GameState.Current.ScoreBlue)
		{
			return string.Format(LocalizedStrings.FinalRoundX, LocalizedStrings.RedCaps);
		}
		return LocalizedStrings.FinalRoundCaps;
	}

	// Token: 0x06001700 RID: 5888 RVA: 0x0007F100 File Offset: 0x0007D300
	private string GetClockString(int remainingSeconds)
	{
		int num = remainingSeconds / 60;
		int num2 = remainingSeconds % 60;
		string str = (num < 10) ? ("0" + num) : num.ToString();
		string str2 = (num2 < 10) ? ("0" + num2) : num2.ToString();
		return str + ":" + str2;
	}

	// Token: 0x040015EE RID: 5614
	[SerializeField]
	private GameObject scores;

	// Token: 0x040015EF RID: 5615
	[SerializeField]
	private UILabel timerLabel;

	// Token: 0x040015F0 RID: 5616
	[SerializeField]
	private UILabel statusLabel;

	// Token: 0x040015F1 RID: 5617
	[SerializeField]
	private UILabel blueLabel;

	// Token: 0x040015F2 RID: 5618
	[SerializeField]
	private UILabel redLabel;

	// Token: 0x040015F3 RID: 5619
	[SerializeField]
	private UILabel countDownLabel;

	// Token: 0x040015F4 RID: 5620
	[SerializeField]
	private UISprite blueBgr;

	// Token: 0x040015F5 RID: 5621
	[SerializeField]
	private UISprite redBgr;

	// Token: 0x040015F6 RID: 5622
	[SerializeField]
	private UISprite blueTriangle;

	// Token: 0x040015F7 RID: 5623
	[SerializeField]
	private UISprite redTriangle;

	// Token: 0x040015F8 RID: 5624
	[SerializeField]
	private UITweener timerTween;

	// Token: 0x040015F9 RID: 5625
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x040015FA RID: 5626
	private static int WARNING_TIME_LOW_VALUE = 30;

	// Token: 0x040015FB RID: 5627
	private int remainingSeconds;

	// Token: 0x040015FC RID: 5628
	private int remainingKillsRounds;
}
