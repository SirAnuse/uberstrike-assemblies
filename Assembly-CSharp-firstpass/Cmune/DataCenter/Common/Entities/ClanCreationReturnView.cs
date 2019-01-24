using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000043 RID: 67
	[Serializable]
	public class ClanCreationReturnView
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x000026A0 File Offset: 0x000008A0
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x000026A8 File Offset: 0x000008A8
		public int ResultCode { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x000026B1 File Offset: 0x000008B1
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x000026B9 File Offset: 0x000008B9
		public ClanView ClanView { get; set; }
	}
}
