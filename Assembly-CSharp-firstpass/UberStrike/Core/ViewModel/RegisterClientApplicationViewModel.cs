using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x02000240 RID: 576
	[Serializable]
	public class RegisterClientApplicationViewModel
	{
		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000FC5 RID: 4037 RVA: 0x0000AA2B File Offset: 0x00008C2B
		// (set) Token: 0x06000FC6 RID: 4038 RVA: 0x0000AA33 File Offset: 0x00008C33
		public ApplicationRegistrationResult Result { get; set; }

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000FC7 RID: 4039 RVA: 0x0000AA3C File Offset: 0x00008C3C
		// (set) Token: 0x06000FC8 RID: 4040 RVA: 0x0000AA44 File Offset: 0x00008C44
		public ICollection<int> ItemsAttributed { get; set; }
	}
}
