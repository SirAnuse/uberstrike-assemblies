using System;
using System.Collections.Generic;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x0200023C RID: 572
	[Serializable]
	public class PlaySpanHashesViewModel
	{
		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000F9F RID: 3999 RVA: 0x0000A90A File Offset: 0x00008B0A
		// (set) Token: 0x06000FA0 RID: 4000 RVA: 0x0000A912 File Offset: 0x00008B12
		public string MerchTrans { get; set; }

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x0000A91B File Offset: 0x00008B1B
		// (set) Token: 0x06000FA2 RID: 4002 RVA: 0x0000A923 File Offset: 0x00008B23
		public Dictionary<decimal, string> Hashes { get; set; }
	}
}
