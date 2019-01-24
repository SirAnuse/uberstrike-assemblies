using System;
using UnityEngine;

// Token: 0x02000170 RID: 368
public abstract class PageGUI : MonoBehaviour
{
	// Token: 0x170002B8 RID: 696
	// (get) Token: 0x060009CB RID: 2507 RVA: 0x0000821E File Offset: 0x0000641E
	// (set) Token: 0x060009CC RID: 2508 RVA: 0x00008226 File Offset: 0x00006426
	public bool IsOnGUIEnabled { get; set; }

	// Token: 0x060009CD RID: 2509
	public abstract void DrawGUI(Rect rect);

	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x060009CE RID: 2510 RVA: 0x0000822F File Offset: 0x0000642F
	public string Title
	{
		get
		{
			return this._title;
		}
	}

	// Token: 0x040009F2 RID: 2546
	[SerializeField]
	private string _title;
}
