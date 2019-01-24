using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001DD RID: 477
	public class LinkedMemberView
	{
		// Token: 0x06000BBB RID: 3003 RVA: 0x0000871F File Offset: 0x0000691F
		public LinkedMemberView(int cmid, string name)
		{
			this.Cmid = cmid;
			this.Name = name;
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000BBC RID: 3004 RVA: 0x00008735 File Offset: 0x00006935
		// (set) Token: 0x06000BBD RID: 3005 RVA: 0x0000873D File Offset: 0x0000693D
		public int Cmid { get; private set; }

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x00008746 File Offset: 0x00006946
		// (set) Token: 0x06000BBF RID: 3007 RVA: 0x0000874E File Offset: 0x0000694E
		public string Name { get; private set; }
	}
}
