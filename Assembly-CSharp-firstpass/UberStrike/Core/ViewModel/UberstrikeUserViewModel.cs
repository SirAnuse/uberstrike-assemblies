using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x02000247 RID: 583
	[Serializable]
	public class UberstrikeUserViewModel
	{
		// Token: 0x1700039A RID: 922
		// (get) Token: 0x0600101F RID: 4127 RVA: 0x0000AD11 File Offset: 0x00008F11
		// (set) Token: 0x06001020 RID: 4128 RVA: 0x0000AD19 File Offset: 0x00008F19
		public MemberView CmuneMemberView { get; set; }

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06001021 RID: 4129 RVA: 0x0000AD22 File Offset: 0x00008F22
		// (set) Token: 0x06001022 RID: 4130 RVA: 0x0000AD2A File Offset: 0x00008F2A
		public UberstrikeMemberView UberstrikeMemberView { get; set; }
	}
}
