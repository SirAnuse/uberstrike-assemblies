using System;
using System.Collections.Generic;

// Token: 0x020003FF RID: 1023
public class CommUserNameComparer : Comparer<CommUser>
{
	// Token: 0x06001D64 RID: 7524 RVA: 0x00013898 File Offset: 0x00011A98
	public override int Compare(CommUser f1, CommUser f2)
	{
		return CommUserComparer.UserNameCompare(f1, f2);
	}
}
