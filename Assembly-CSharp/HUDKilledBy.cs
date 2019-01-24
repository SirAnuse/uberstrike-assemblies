using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200032B RID: 811
public class HUDKilledBy : MonoBehaviour
{
	// Token: 0x0600169F RID: 5791 RVA: 0x0007D9D0 File Offset: 0x0007BBD0
	private void Start()
	{
		GameData.Instance.OnPlayerKilled.AddEvent(delegate(GameActorInfo shooter, GameActorInfo target, UberstrikeItemClass weapon, BodyPart body)
		{
			if (target == null || target.Cmid != PlayerDataManager.Cmid)
			{
				return;
			}
			this.panel.alpha = 1f;
			if (shooter == null || shooter.Cmid == PlayerDataManager.Cmid)
			{
				this.nameLabel.text = LocalizedStrings.CongratulationsYouKilledYourself;
				this.healthArmorAligner.gameObject.SetActive(false);
			}
			else
			{
				this.nameLabel.text = "Killed by " + shooter.PlayerName;
				this.healthArmorAligner.gameObject.SetActive(true);
				this.healthLabel.text = Mathf.Clamp((int)shooter.Health, 0, 200).ToString();
				this.armorLabel.text = Mathf.Clamp((int)shooter.ArmorPoints, 0, 200).ToString();
				this.healthArmorAligner.Reposition();
			}
			this.respawnCountdown.gameObject.SetActive(false);
			this.respawnLabel.gameObject.SetActive(false);
		}, this);
		GameData.Instance.PlayerState.AddEvent(delegate(PlayerStateId el)
		{
			this.panel.alpha = (float)((el != PlayerStateId.Killed) ? 0 : 1);
		}, this);
		this.panel.alpha = 0f;
		GameData.Instance.OnRespawnCountdown.AddEvent(delegate(int el)
		{
			this.respawnCountdown.gameObject.SetActive(el > 0);
			this.respawnLabel.gameObject.SetActive(el > 0);
			if (el > 0)
			{
				this.respawnCountdown.text = el.ToString();
				UITweener.Begin<TweenScale>(this.respawnCountdown.gameObject, 0.5f);
				UITweener.Begin<TweenAlpha>(this.respawnCountdown.gameObject, 0.25f);
			}
		}, this);
	}

	// Token: 0x04001588 RID: 5512
	[SerializeField]
	private UIPanel panel;

	// Token: 0x04001589 RID: 5513
	[SerializeField]
	private UILabel nameLabel;

	// Token: 0x0400158A RID: 5514
	[SerializeField]
	private UIHorizontalAligner healthArmorAligner;

	// Token: 0x0400158B RID: 5515
	[SerializeField]
	private UILabel healthLabel;

	// Token: 0x0400158C RID: 5516
	[SerializeField]
	private UILabel armorLabel;

	// Token: 0x0400158D RID: 5517
	[SerializeField]
	private UIHorizontalAligner weaponAligner;

	// Token: 0x0400158E RID: 5518
	[SerializeField]
	private UILabel weaponNameLabel;

	// Token: 0x0400158F RID: 5519
	[SerializeField]
	private UILabel respawnLabel;

	// Token: 0x04001590 RID: 5520
	[SerializeField]
	private UILabel respawnCountdown;
}
