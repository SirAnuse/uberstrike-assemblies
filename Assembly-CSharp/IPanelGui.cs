using System;

// Token: 0x020001CF RID: 463
public interface IPanelGui
{
	// Token: 0x06000CE4 RID: 3300
	void Show();

	// Token: 0x06000CE5 RID: 3301
	void Hide();

	// Token: 0x17000330 RID: 816
	// (get) Token: 0x06000CE6 RID: 3302
	bool IsEnabled { get; }
}
