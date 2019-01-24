using System;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200034B RID: 843
	public static class SystemTime
	{
		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x060013DE RID: 5086 RVA: 0x0000C362 File Offset: 0x0000A562
		public static int Running
		{
			get
			{
				return Environment.TickCount & int.MaxValue;
			}
		}
	}
}
