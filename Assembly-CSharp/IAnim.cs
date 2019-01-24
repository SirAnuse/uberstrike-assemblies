using System;

// Token: 0x02000236 RID: 566
public interface IAnim : IUpdatable
{
	// Token: 0x170003A3 RID: 931
	// (get) Token: 0x06000F96 RID: 3990
	// (set) Token: 0x06000F97 RID: 3991
	bool IsAnimating { get; set; }

	// Token: 0x170003A4 RID: 932
	// (get) Token: 0x06000F98 RID: 3992
	// (set) Token: 0x06000F99 RID: 3993
	float Duration { get; set; }

	// Token: 0x170003A5 RID: 933
	// (get) Token: 0x06000F9A RID: 3994
	// (set) Token: 0x06000F9B RID: 3995
	float StartTime { get; set; }

	// Token: 0x06000F9C RID: 3996
	void Start();

	// Token: 0x06000F9D RID: 3997
	void Stop();
}
