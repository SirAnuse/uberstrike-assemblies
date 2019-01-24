using System;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x0200023B RID: 571
	[Serializable]
	public class MemberAuthenticationViewModel
	{
		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000F9A RID: 3994 RVA: 0x0000A8E8 File Offset: 0x00008AE8
		// (set) Token: 0x06000F9B RID: 3995 RVA: 0x0000A8F0 File Offset: 0x00008AF0
		public MemberAuthenticationResult MemberAuthenticationResult { get; set; }

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000F9C RID: 3996 RVA: 0x0000A8F9 File Offset: 0x00008AF9
		// (set) Token: 0x06000F9D RID: 3997 RVA: 0x0000A901 File Offset: 0x00008B01
		public MemberView MemberView { get; set; }
	}
}
