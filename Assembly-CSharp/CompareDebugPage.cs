using System;
using System.Collections.Generic;

// Token: 0x020000E9 RID: 233
public class CompareDebugPage : IComparer<IDebugPage>
{
	// Token: 0x060007E2 RID: 2018 RVA: 0x00006FDE File Offset: 0x000051DE
	public int Compare(IDebugPage a, IDebugPage b)
	{
		return a.Title.CompareTo(b.Title);
	}
}
