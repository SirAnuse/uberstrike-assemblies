using System;
using UnityEngine;

// Token: 0x0200020E RID: 526
public class PlayerLeadAudio
{
	// Token: 0x1700036C RID: 876
	// (get) Token: 0x06000E8D RID: 3725 RVA: 0x0000A912 File Offset: 0x00008B12
	// (set) Token: 0x06000E8E RID: 3726 RVA: 0x0000A91A File Offset: 0x00008B1A
	public PlayerLeadAudio.LeadState CurrentLead { get; private set; }

	// Token: 0x06000E8F RID: 3727 RVA: 0x0000A923 File Offset: 0x00008B23
	public void Reset()
	{
		this.CurrentLead = PlayerLeadAudio.LeadState.Tied;
		this.lastKillsLeftPlayed = 0;
	}

	// Token: 0x06000E90 RID: 3728 RVA: 0x0006278C File Offset: 0x0006098C
	public void UpdateLeadStatus(int myKills, int otherKills, bool playAudio = true)
	{
		PlayerLeadAudio.LeadState currentLead = this.CurrentLead;
		if (myKills > otherKills)
		{
			this.CurrentLead = PlayerLeadAudio.LeadState.Me;
		}
		else if (otherKills == myKills)
		{
			this.CurrentLead = PlayerLeadAudio.LeadState.Tied;
		}
		else
		{
			this.CurrentLead = PlayerLeadAudio.LeadState.Others;
		}
		if (currentLead == this.CurrentLead || !playAudio)
		{
			return;
		}
		switch (this.CurrentLead)
		{
		case PlayerLeadAudio.LeadState.Tied:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.TiedLead, 500UL, 1f, 1f);
			return;
		case PlayerLeadAudio.LeadState.Me:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.TakenLead, 500UL, 1f, 1f);
			return;
		case PlayerLeadAudio.LeadState.Others:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.LostLead, 500UL, 1f, 1f);
			return;
		default:
			return;
		}
	}

	// Token: 0x06000E91 RID: 3729 RVA: 0x00062848 File Offset: 0x00060A48
	public void PlayKillsLeftAudio(int killsLeft)
	{
		if (this.lastKillsLeftPlayed == killsLeft)
			return;
        switch (killsLeft)
        {
            case 1:
                AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.KillLeft1, 2000UL, 1f, 1f);
                break;
            case 2:
                AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.KillLeft2, 2000UL, 1f, 1f);
                break;
            case 3:
                AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.KillLeft3, 2000UL, 1f, 1f);
                break;
            case 4:
                AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.KillLeft4, 2000UL, 1f, 1f);
                break;
            case 5:
                AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.KillLeft5, 2000UL, 1f, 1f);
                break;
            default:
                break;
        }
		this.lastKillsLeftPlayed = killsLeft;
	}

	// Token: 0x04000D32 RID: 3378
	private int lastKillsLeftPlayed;

	// Token: 0x0200020F RID: 527
	public enum LeadState
	{
		// Token: 0x04000D35 RID: 3381
		Tied,
		// Token: 0x04000D36 RID: 3382
		Me,
		// Token: 0x04000D37 RID: 3383
		Others
	}
}
