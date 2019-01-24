using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000314 RID: 788
public class HUDMobileQuickItems : MonoBehaviour
{
	// Token: 0x0600160F RID: 5647 RVA: 0x0000EDF4 File Offset: 0x0000CFF4
	private void OnEnable()
	{
		GameData.Instance.OnQuickItemsChanged.Fire();
		this.UpdateActiveItemsInView();
	}

	// Token: 0x06001610 RID: 5648 RVA: 0x0007B4F4 File Offset: 0x000796F4
	private void Start()
	{
		AutoMonoBehaviour<TouchInput>.Instance.Shooter.IgnoreRect(new Rect((float)Screen.width - 240f, 200f, 240f, 100f));
		this.slot1.actionButton.OnClicked = delegate()
		{
			this.FireActiveQuickItem(this.slot1);
		};
		this.slot2.actionButton.OnClicked = delegate()
		{
			this.FireActiveQuickItem(this.slot2);
		};
		this.slot3.actionButton.OnClicked = delegate()
		{
			this.FireActiveQuickItem(this.slot3);
		};
		this.availableSlots.Add(this.slot1.gameObject);
		this.availableSlots.Add(this.slot2.gameObject);
		this.availableSlots.Add(this.slot3.gameObject);
		GameData.Instance.OnQuickItemsChanged.AddEventAndFire(delegate()
		{
			QuickItem[] quickItems = Singleton<QuickItemController>.Instance.QuickItems;
			int currentSlotIndex = Singleton<QuickItemController>.Instance.CurrentSlotIndex;
			this.slot1.SetQuickItem((quickItems.Length <= 0) ? null : quickItems[0], 0 == currentSlotIndex);
			this.slot2.SetQuickItem((quickItems.Length <= 1) ? null : quickItems[1], 1 == currentSlotIndex);
			this.slot3.SetQuickItem((quickItems.Length <= 2) ? null : quickItems[2], 2 == currentSlotIndex);
		}, this);
		this.UpdateActiveItemsInView();
		GameData.Instance.OnQuickItemsCooldown.AddEventAndFire(delegate(int index, float progress)
		{
			int currentSlotIndex = Singleton<QuickItemController>.Instance.CurrentSlotIndex;
			if (index == 0)
			{
				this.slot1.SetCooldown(progress, 0 == currentSlotIndex);
			}
			else if (index == 1)
			{
				this.slot2.SetCooldown(progress, 1 == currentSlotIndex);
			}
			else if (index == 2)
			{
				this.slot3.SetCooldown(progress, 2 == currentSlotIndex);
			}
		}, this);
	}

	// Token: 0x06001611 RID: 5649 RVA: 0x0007B604 File Offset: 0x00079804
	private void UpdateActiveItemsInView()
	{
		List<GameObject> activeSlots = new List<GameObject>();
		this.availableSlots.ForEach(delegate(GameObject el)
		{
			if (el.activeInHierarchy)
			{
				activeSlots.Add(el);
			}
		});
		this.scrollList.SetActiveElements(activeSlots);
		this.selectorBackground.SetActive(activeSlots.Count > 1);
	}

	// Token: 0x06001612 RID: 5650 RVA: 0x0007B664 File Offset: 0x00079864
	private void FireActiveQuickItem(HUDQuickItem item)
	{
		switch (this.GetSlotIndex(item))
		{
		case 0:
			global::EventHandler.Global.Fire(new GlobalEvents.InputChanged(GameInputKey.QuickItem1, 1f));
			break;
		case 1:
			global::EventHandler.Global.Fire(new GlobalEvents.InputChanged(GameInputKey.QuickItem2, 1f));
			break;
		case 2:
			global::EventHandler.Global.Fire(new GlobalEvents.InputChanged(GameInputKey.QuickItem3, 1f));
			break;
		}
	}

	// Token: 0x06001613 RID: 5651 RVA: 0x0000EE0B File Offset: 0x0000D00B
	private int GetSlotIndex(HUDQuickItem item)
	{
		if (this.availableSlots.Contains(item.gameObject))
		{
			return this.availableSlots.IndexOf(item.gameObject);
		}
		return -1;
	}

	// Token: 0x040014D9 RID: 5337
	[SerializeField]
	private NGUIScrollList scrollList;

	// Token: 0x040014DA RID: 5338
	[SerializeField]
	private HUDQuickItem slot1;

	// Token: 0x040014DB RID: 5339
	[SerializeField]
	private HUDQuickItem slot2;

	// Token: 0x040014DC RID: 5340
	[SerializeField]
	private HUDQuickItem slot3;

	// Token: 0x040014DD RID: 5341
	[SerializeField]
	private GameObject selectorBackground;

	// Token: 0x040014DE RID: 5342
	private List<GameObject> availableSlots = new List<GameObject>();
}
