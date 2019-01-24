using System;
using System.Collections.Generic;

// Token: 0x02000401 RID: 1025
public class CommUserPresenceComparer : Comparer<CommUser>
{
	// Token: 0x06001D68 RID: 7528 RVA: 0x000138A1 File Offset: 0x00011AA1
	public override int Compare(CommUser f1, CommUser f2)
	{
		if (f1.PresenceIndex == f2.PresenceIndex)
		{
			return CommUserComparer.UserNameCompare(f1, f2);
		}
		if (f1.PresenceIndex == PresenceType.Offline)
		{
			return 1;
		}
		if (f2.PresenceIndex == PresenceType.Offline)
		{
			return -1;
		}
		return CommUserComparer.UserNameCompare(f1, f2);
	}
}
