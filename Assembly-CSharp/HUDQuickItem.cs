using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000333 RID: 819
public class HUDQuickItem : MonoBehaviour
{
	// Token: 0x060016D3 RID: 5843 RVA: 0x0007E5C8 File Offset: 0x0007C7C8
	public void SetQuickItem(QuickItem item, bool selected)
	{
		base.gameObject.SetActive(item != null);
		if (item == null)
		{
			return;
		}
		this.ammo.enabled = (item.Logic == QuickItemLogic.AmmoPack);
		this.armor.enabled = (item.Logic == QuickItemLogic.ArmorPack);
		this.health.enabled = (item.Logic == QuickItemLogic.HealthPack);
		this.offensiveGrenade.enabled = (item.Logic == QuickItemLogic.ExplosiveGrenade);
		this.springGrenade.enabled = (item.Logic == QuickItemLogic.SpringGrenade);
		this.amount.text = item.Behaviour.CurrentAmount.ToString();
		this.SetCooldown(item.Behaviour.CooldownProgress, selected);
	}

	// Token: 0x060016D4 RID: 5844 RVA: 0x0007E688 File Offset: 0x0007C888
	public void SetCooldown(float progress, bool selected)
	{
		bool enabled = progress != 0f && progress != 1f;
		this.cooldown.enabled = enabled;
		this.cooldown.fillAmount = progress;
		this.ammo.fillAmount = progress;
		this.ammo.alpha = ((!selected) ? 0.35f : 1f);
		this.armor.fillAmount = progress;
		this.armor.alpha = ((!selected) ? 0.35f : 1f);
		this.health.fillAmount = progress;
		this.health.alpha = ((!selected) ? 0.35f : 1f);
		this.offensiveGrenade.fillAmount = progress;
		this.offensiveGrenade.alpha = ((!selected) ? 0.35f : 1f);
		this.springGrenade.fillAmount = progress;
		this.springGrenade.alpha = ((!selected) ? 0.35f : 1f);
		this.amount.alpha = ((!selected) ? 0.35f : 1f);
	}

	// Token: 0x040015C8 RID: 5576
	[SerializeField]
	private UISprite cooldown;

	// Token: 0x040015C9 RID: 5577
	[SerializeField]
	private UILabel amount;

	// Token: 0x040015CA RID: 5578
	[SerializeField]
	private UISprite ammo;

	// Token: 0x040015CB RID: 5579
	[SerializeField]
	private UISprite armor;

	// Token: 0x040015CC RID: 5580
	[SerializeField]
	private UISprite health;

	// Token: 0x040015CD RID: 5581
	[SerializeField]
	private UISprite offensiveGrenade;

	// Token: 0x040015CE RID: 5582
	[SerializeField]
	private UISprite springGrenade;

	// Token: 0x040015CF RID: 5583
	public UIEventReceiver actionButton;
}
