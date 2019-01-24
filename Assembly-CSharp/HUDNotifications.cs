using System;
using System.Collections;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200032E RID: 814
public class HUDNotifications : MonoBehaviour
{
	// Token: 0x060016B0 RID: 5808 RVA: 0x0007DDA0 File Offset: 0x0007BFA0
	private void Start()
	{
		GameData.Instance.OnNotification.AddEvent(delegate(string el)
		{
			this.Show(el, string.Empty, 1f);
		}, this);
		GameData.Instance.OnNotificationFull.AddEvent(delegate(string el1, string el2, float duration)
		{
			this.Show(el1, el2, duration);
		}, this);
		GameData.Instance.GameState.AddEventAndFire(delegate(GameStateId el)
		{
			if (el == GameStateId.PrepareNextRound)
			{
				this.Show(this.GetGameModeName(), this.GetGameModeHint(), 0f);
			}
			else if (el == GameStateId.MatchRunning)
			{
				this.Show(string.Empty, "Fight!", 1f);
			}
			else
			{
				this.Hide(false);
			}
		}, this);
		GameData.Instance.OnPlayerKilled.AddEvent(new Action<GameActorInfo, GameActorInfo, UberstrikeItemClass, BodyPart>(this.OnPlayerKilled), this);
		this.panel.alpha = 0f;
	}

	// Token: 0x060016B1 RID: 5809 RVA: 0x0007DE30 File Offset: 0x0007C030
	private void OnPlayerKilled(GameActorInfo shooter, GameActorInfo target, UberstrikeItemClass weapon, BodyPart bodyPart)
	{
		if (target == null)
		{
			return;
		}
		if (shooter != null && shooter.Cmid == PlayerDataManager.Cmid && target.Cmid != PlayerDataManager.Cmid)
		{
			bool flag = Time.time < this.lastKillTime + 10f;
			this.killCounter = ((!flag) ? 1 : (this.killCounter + 1));
			this.lastKillTime = Time.time;
			if (weapon == UberstrikeItemClass.WeaponMelee)
			{
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.Smackdown, 0UL, 1f, 1f);
			}
			else if (bodyPart == BodyPart.Head)
			{
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.HeadShot, 0UL, 1f, 1f);
			}
			else if (bodyPart == BodyPart.Nuts)
			{
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.GotNutshotKill, 0UL, 1f, 1f);
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.NutShot, 0UL, 1f, 1f);
			}
			string textBig = string.Empty;
			if (this.killCounter == 2)
			{
				textBig = "DOUBLE KILL";
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.DoubleKill, 1000UL, 1f, 1f);
			}
			else if (this.killCounter == 3)
			{
				textBig = "TRIPLE KILL";
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.TripleKill, 1000UL, 1f, 1f);
			}
			else if (this.killCounter == 4)
			{
				textBig = "QUAD KILL";
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.QuadKill, 1000UL, 1f, 1f);
			}
			else if (this.killCounter == 5)
			{
				textBig = "MEGA KILL";
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MegaKill, 1000UL, 1f, 1f);
			}
			else if (this.killCounter > 5)
			{
				textBig = "UBER KILL";
				if (this.killCounter == 6)
				{
					AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.UberKill, 1000UL, 1f, 1f);
				}
			}
			this.Show(textBig, "You killed " + target.PlayerName, 1f);
		}
	}

	// Token: 0x060016B2 RID: 5810 RVA: 0x0007E068 File Offset: 0x0007C268
	private string GetGameModeName()
	{
		switch (GameState.Current.GameMode)
		{
		case GameModeType.DeathMatch:
			return LocalizedStrings.DeathMatch;
		case GameModeType.TeamDeathMatch:
			return LocalizedStrings.TeamDeathMatch;
		case GameModeType.EliminationMode:
			return LocalizedStrings.TeamElimination;
		default:
			return string.Empty;
		}
	}

	// Token: 0x060016B3 RID: 5811 RVA: 0x0000F44B File Offset: 0x0000D64B
	private string GetGameModeHint()
	{
		if (GameState.Current.GameMode == GameModeType.DeathMatch)
		{
			return "Get as many kills as you can before the time runs out";
		}
		return "Get as many kills for your team as you can\nbefore the time runs out";
	}

	// Token: 0x060016B4 RID: 5812 RVA: 0x0000F468 File Offset: 0x0000D668
	public void Hide(bool immediate = false)
	{
		base.StopAllCoroutines();
		if (immediate)
		{
			this.panel.alpha = 0f;
		}
		else
		{
			base.StartCoroutine(this.HideCrt(this.defaultFadeOutSpeed));
		}
	}

	// Token: 0x060016B5 RID: 5813 RVA: 0x0000F49E File Offset: 0x0000D69E
	public void Show(string textBig, string textSmall, float duration = 1f)
	{
		this.Show(textBig, textSmall, this.defaultFadeInSpeed, this.defaultFadeOutSpeed, duration);
	}

	// Token: 0x060016B6 RID: 5814 RVA: 0x0000F4B5 File Offset: 0x0000D6B5
	public void Show(string textBig, string textSmall, float fadeInSpeed, float fadeOutSpeed, float duration = 1f)
	{
		base.StopAllCoroutines();
		base.StartCoroutine(this.ShowCrt(textBig, textSmall, fadeInSpeed, fadeOutSpeed, duration));
	}

	// Token: 0x060016B7 RID: 5815 RVA: 0x0007E0B0 File Offset: 0x0007C2B0
	public IEnumerator ShowCrt(string textBig, string textSmall, float fadeInSpeed, float fadeOutSpeed, float duration)
	{
		if (this.labelBig.text != textBig || this.labelSmall.text != textSmall)
		{
			this.panel.alpha = 0f;
		}
		this.labelBig.text = textBig;
		this.labelSmall.text = textSmall;
		while (this.panel.alpha < 1f)
		{
			this.panel.alpha = Mathf.MoveTowards(this.panel.alpha, 1f, Time.deltaTime * fadeInSpeed);
			yield return 0;
		}
		if (duration > 0f)
		{
			yield return new WaitForSeconds(duration);
			yield return base.StartCoroutine(this.HideCrt(fadeOutSpeed));
		}
		yield break;
	}

	// Token: 0x060016B8 RID: 5816 RVA: 0x0007E118 File Offset: 0x0007C318
	private IEnumerator HideCrt(float fadeOutSpeed)
	{
		while (this.panel.alpha > 0f)
		{
			this.panel.alpha = Mathf.MoveTowards(this.panel.alpha, 0f, Time.deltaTime * fadeOutSpeed);
			yield return 0;
		}
		yield break;
	}

	// Token: 0x040015A0 RID: 5536
	[SerializeField]
	private UIPanel panel;

	// Token: 0x040015A1 RID: 5537
	[SerializeField]
	private UILabel labelBig;

	// Token: 0x040015A2 RID: 5538
	[SerializeField]
	private UILabel labelSmall;

	// Token: 0x040015A3 RID: 5539
	[SerializeField]
	private float defaultFadeInSpeed = 20f;

	// Token: 0x040015A4 RID: 5540
	[SerializeField]
	private float defaultFadeOutSpeed = 5f;

	// Token: 0x040015A5 RID: 5541
	private float lastKillTime;

	// Token: 0x040015A6 RID: 5542
	private int killCounter;
}
