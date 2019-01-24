using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200033A RID: 826
public class HUDWeaponFeedback : MonoBehaviour
{
	// Token: 0x06001708 RID: 5896 RVA: 0x0000F159 File Offset: 0x0000D359
	private void OnEnable()
	{
		GameState.Current.PlayerData.ActiveWeapon.Fire();
	}

	// Token: 0x06001709 RID: 5897 RVA: 0x0000F83E File Offset: 0x0000DA3E
	private void Start()
	{
		GameState.Current.PlayerData.ActiveWeapon.AddEventAndFire(new Action<WeaponSlot>(this.HandleSelectedLoadoutChanged), this);
	}

	// Token: 0x0600170A RID: 5898 RVA: 0x0007F218 File Offset: 0x0007D418
	private void HandleSelectedLoadoutChanged(WeaponSlot weapon)
	{
		if (weapon != null)
		{
			LoadoutSlotType slot = weapon.Slot;
			if (!GameState.Current.PlayerData.LoadoutWeapons.Value.ContainsKey(slot))
			{
				return;
			}
			this.feedbackLabel.text = GameState.Current.PlayerData.LoadoutWeapons.Value[slot].Name;
			base.StopAllCoroutines();
			base.StartCoroutine(this.FadeAnimation());
		}
	}

	// Token: 0x0600170B RID: 5899 RVA: 0x0007F290 File Offset: 0x0007D490
	private IEnumerator FadeAnimation()
	{
		TweenAlpha.Begin(this.feedbackLabel.gameObject, this.fadeInTime, 1f);
		yield return new WaitForSeconds(this.onScreenTime);
		TweenAlpha.Begin(this.feedbackLabel.gameObject, this.fadeOutTime, 0f);
		yield break;
	}

	// Token: 0x040015FE RID: 5630
	[SerializeField]
	private float onScreenTime = 2.5f;

	// Token: 0x040015FF RID: 5631
	[SerializeField]
	private float fadeInTime = 0.2f;

	// Token: 0x04001600 RID: 5632
	[SerializeField]
	private float fadeOutTime = 1f;

	// Token: 0x04001601 RID: 5633
	[SerializeField]
	private UILabel feedbackLabel;
}
