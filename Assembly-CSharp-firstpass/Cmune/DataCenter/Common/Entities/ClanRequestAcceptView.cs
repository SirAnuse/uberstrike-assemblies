using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000045 RID: 69
	[Serializable]
	public class ClanRequestAcceptView
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00002744 File Offset: 0x00000944
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000274C File Offset: 0x0000094C
		public int ActionResult { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00002755 File Offset: 0x00000955
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000275D File Offset: 0x0000095D
		public int ClanRequestId { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00002766 File Offset: 0x00000966
		// (set) Token: 0x060000DA RID: 218 RVA: 0x0000276E File Offset: 0x0000096E
		public ClanView ClanView { get; set; }
	}
}
