using System;

// Token: 0x020003FE RID: 1022
public static class CommUserComparer
{
	// Token: 0x06001D62 RID: 7522 RVA: 0x0001387C File Offset: 0x00011A7C
	public static int UserNameCompare(CommUser f1, CommUser f2)
	{
		return string.Compare(f1.ShortName, f2.ShortName, true);
	}
}
