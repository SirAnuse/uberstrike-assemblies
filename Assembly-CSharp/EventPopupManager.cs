using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200015D RID: 349
public class EventPopupManager : Singleton<EventPopupManager>
{
	// Token: 0x06000943 RID: 2371 RVA: 0x00007CD1 File Offset: 0x00005ED1
	private EventPopupManager()
	{
		this.popups = new Queue<IPopupDialog>();
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x00007CE4 File Offset: 0x00005EE4
	public void AddEventPopup(IPopupDialog popup)
	{
		this.popups.Enqueue(popup);
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x00007CF2 File Offset: 0x00005EF2
	public void ShowNextPopup(int delay = 0)
	{
		if (this.popups.Count > 0)
		{
			UnityRuntime.StartRoutine(this.ShowPopup(this.popups.Dequeue(), delay));
		}
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x0003AC2C File Offset: 0x00038E2C
	private IEnumerator ShowPopup(IPopupDialog popup, int delay)
	{
		yield return new WaitForSeconds((float)delay);
		PopupSystem.Show(popup);
		yield break;
	}

	// Token: 0x0400097D RID: 2429
	private Queue<IPopupDialog> popups;
}
