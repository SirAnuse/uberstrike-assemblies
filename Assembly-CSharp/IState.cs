using System;

// Token: 0x0200040E RID: 1038
public interface IState
{
	// Token: 0x06001D87 RID: 7559
	void OnEnter();

	// Token: 0x06001D88 RID: 7560
	void OnResume();

	// Token: 0x06001D89 RID: 7561
	void OnExit();

	// Token: 0x06001D8A RID: 7562
	void OnUpdate();
}
