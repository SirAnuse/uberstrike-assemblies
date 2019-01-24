using System;
using UnityEngine;

// Token: 0x020001D0 RID: 464
public abstract class PanelGuiBase : MonoBehaviour, IPanelGui
{
	// Token: 0x06000CE8 RID: 3304 RVA: 0x00009986 File Offset: 0x00007B86
	public virtual void Show()
	{
		base.enabled = true;
	}

	// Token: 0x06000CE9 RID: 3305 RVA: 0x000098D0 File Offset: 0x00007AD0
	public virtual void Hide()
	{
		base.enabled = false;
	}

	// Token: 0x17000331 RID: 817
	// (get) Token: 0x06000CEA RID: 3306 RVA: 0x00007D4D File Offset: 0x00005F4D
	public bool IsEnabled
	{
		get
		{
			return base.enabled;
		}
	}
}
