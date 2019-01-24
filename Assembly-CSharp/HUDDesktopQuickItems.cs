using System;
using UnityEngine;

// Token: 0x0200030D RID: 781
public class HUDDesktopQuickItems : MonoBehaviour
{
	// Token: 0x060015EE RID: 5614 RVA: 0x0000EBFE File Offset: 0x0000CDFE
	private void Start()
	{
		GameData.Instance.OnQuickItemsChanged.AddEventAndFire(delegate()
		{
			QuickItem[] quickItems = Singleton<QuickItemController>.Instance.QuickItems;
			int currentSlotIndex = Singleton<QuickItemController>.Instance.CurrentSlotIndex;
			this.item0.SetQuickItem((quickItems.Length <= 0) ? null : quickItems[0], 0 == currentSlotIndex);
			this.item1.SetQuickItem((quickItems.Length <= 1) ? null : quickItems[1], 1 == currentSlotIndex);
			this.item2.SetQuickItem((quickItems.Length <= 2) ? null : quickItems[2], 2 == currentSlotIndex);
		}, this);
		GameData.Instance.OnQuickItemsCooldown.AddEventAndFire(delegate(int index, float progress)
		{
			int currentSlotIndex = Singleton<QuickItemController>.Instance.CurrentSlotIndex;
			if (index == 0)
			{
				this.item0.SetCooldown(progress, 0 == currentSlotIndex);
			}
			else if (index == 1)
			{
				this.item1.SetCooldown(progress, 1 == currentSlotIndex);
			}
			else if (index == 2)
			{
				this.item2.SetCooldown(progress, 2 == currentSlotIndex);
			}
		}, this);
	}

	// Token: 0x060015EF RID: 5615 RVA: 0x0000EC38 File Offset: 0x0000CE38
	private void OnEnable()
	{
		GameData.Instance.OnQuickItemsChanged.Fire();
	}

	// Token: 0x040014B5 RID: 5301
	[SerializeField]
	private HUDQuickItem item0;

	// Token: 0x040014B6 RID: 5302
	[SerializeField]
	private HUDQuickItem item1;

	// Token: 0x040014B7 RID: 5303
	[SerializeField]
	private HUDQuickItem item2;
}
