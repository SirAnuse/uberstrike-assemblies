using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000331 RID: 817
public class HUDPickup : MonoBehaviour
{
	// Token: 0x060016C9 RID: 5833 RVA: 0x0000F53A File Offset: 0x0000D73A
	private void Start()
	{
		this.panel.alpha = 0f;
		GameData.Instance.OnItemPickup.AddEvent(delegate(string itemName, PickUpMessageType el)
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this.ShowCrt(itemName, el));
		}, this);
	}

	// Token: 0x060016CA RID: 5834 RVA: 0x0007E3D0 File Offset: 0x0007C5D0
	private IEnumerator ShowCrt(string itemName, PickUpMessageType item)
	{
		if (this.lastItem == item && Time.time <= this.lastTime + this.pickupMiltiplicationMaxTime)
		{
			this.lastCount++;
		}
		else
		{
			this.lastCount = 1;
		}
		this.lastTime = Time.time;
		this.lastItem = item;
		this.panel.alpha = 1f;
		if (this.lastCount > 1)
		{
			this.label.text = itemName + " x " + this.lastCount;
		}
		else
		{
			this.label.text = itemName;
		}
		yield return new WaitForSeconds(this.showDuration);
		while (this.panel.alpha > 0f)
		{
			this.panel.alpha = Mathf.MoveTowards(this.panel.alpha, 0f, Time.deltaTime * this.fadeoutSpeed);
			yield return 0;
		}
		yield break;
	}

	// Token: 0x040015B9 RID: 5561
	[SerializeField]
	private UIPanel panel;

	// Token: 0x040015BA RID: 5562
	[SerializeField]
	private UILabel label;

	// Token: 0x040015BB RID: 5563
	[SerializeField]
	private float pickupMiltiplicationMaxTime = 3f;

	// Token: 0x040015BC RID: 5564
	[SerializeField]
	private float showDuration = 2f;

	// Token: 0x040015BD RID: 5565
	[SerializeField]
	private float fadeoutSpeed = 1f;

	// Token: 0x040015BE RID: 5566
	private int lastCount;

	// Token: 0x040015BF RID: 5567
	private float lastTime;

	// Token: 0x040015C0 RID: 5568
	private PickUpMessageType lastItem;
}
