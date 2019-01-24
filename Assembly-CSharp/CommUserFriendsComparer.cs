using System;
using System.Collections.Generic;

// Token: 0x02000400 RID: 1024
public class CommUserFriendsComparer : Comparer<CommUser>
{
	// Token: 0x06001D66 RID: 7526 RVA: 0x0009284C File Offset: 0x00090A4C
	public override int Compare(CommUser f1, CommUser f2)
	{
		if ((f1.IsFriend || f1.IsClanMember || f1.IsFacebookFriend) && (f2.IsFriend || f2.IsClanMember || f2.IsFacebookFriend))
		{
			return CommUserComparer.UserNameCompare(f1, f2);
		}
		if (f2.IsFriend || f2.IsClanMember || f2.IsFacebookFriend)
		{
			return 1;
		}
		if (f1.IsFriend || f1.IsClanMember || f1.IsFacebookFriend)
		{
			return -1;
		}
		return CommUserComparer.UserNameCompare(f1, f2);
	}
}
