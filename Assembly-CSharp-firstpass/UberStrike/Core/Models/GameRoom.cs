using System;

namespace UberStrike.Core.Models
{
	// Token: 0x02000223 RID: 547
	[Serializable]
	public class GameRoom
	{
		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000E31 RID: 3633 RVA: 0x00009D04 File Offset: 0x00007F04
		// (set) Token: 0x06000E32 RID: 3634 RVA: 0x00009D0C File Offset: 0x00007F0C
		public ConnectionAddress Server { get; set; }

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000E33 RID: 3635 RVA: 0x00009D15 File Offset: 0x00007F15
		// (set) Token: 0x06000E34 RID: 3636 RVA: 0x00009D1D File Offset: 0x00007F1D
		public int Number { get; set; }

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000E35 RID: 3637 RVA: 0x00009D26 File Offset: 0x00007F26
		// (set) Token: 0x06000E36 RID: 3638 RVA: 0x00009D2E File Offset: 0x00007F2E
		public int MapId { get; set; }
	}
}
