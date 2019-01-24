using System;
using UnityEngine;

// Token: 0x020003B4 RID: 948
public class TouchFinger
{
	// Token: 0x06001BCA RID: 7114 RVA: 0x00012683 File Offset: 0x00010883
	public TouchFinger()
	{
		this.Reset();
	}

	// Token: 0x06001BCB RID: 7115 RVA: 0x00012691 File Offset: 0x00010891
	public void Reset()
	{
		this.StartPos = Vector2.zero;
		this.LastPos = Vector2.zero;
		this.StartTouchTime = 0f;
		this.FingerId = -1;
	}

	// Token: 0x040018C5 RID: 6341
	public Vector2 StartPos;

	// Token: 0x040018C6 RID: 6342
	public Vector2 LastPos;

	// Token: 0x040018C7 RID: 6343
	public float StartTouchTime;

	// Token: 0x040018C8 RID: 6344
	public int FingerId;
}
