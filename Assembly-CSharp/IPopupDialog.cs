using System;

// Token: 0x020001E1 RID: 481
public interface IPopupDialog
{
	// Token: 0x17000347 RID: 839
	// (get) Token: 0x06000D8F RID: 3471
	// (set) Token: 0x06000D90 RID: 3472
	string Text { get; set; }

	// Token: 0x17000348 RID: 840
	// (get) Token: 0x06000D91 RID: 3473
	// (set) Token: 0x06000D92 RID: 3474
	string Title { get; set; }

	// Token: 0x17000349 RID: 841
	// (get) Token: 0x06000D93 RID: 3475
	GuiDepth Depth { get; }

	// Token: 0x06000D94 RID: 3476
	void OnGUI();

	// Token: 0x06000D95 RID: 3477
	void OnHide();
}
