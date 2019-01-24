using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000046 RID: 70
	[Serializable]
	public class ClanRequestDeclineView
	{
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00002777 File Offset: 0x00000977
		// (set) Token: 0x060000DD RID: 221 RVA: 0x0000277F File Offset: 0x0000097F
		public int ActionResult { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00002788 File Offset: 0x00000988
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00002790 File Offset: 0x00000990
		public int ClanRequestId { get; set; }
	}
}
