using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200001A RID: 26
	public enum MemberMergeResult
	{
		// Token: 0x040000B0 RID: 176
		Ok,
		// Token: 0x040000B1 RID: 177
		CmidNotFound,
		// Token: 0x040000B2 RID: 178
		CmidAlreadyLinkedToEsns = 3,
		// Token: 0x040000B3 RID: 179
		EsnsAlreadyLinkedToCmid,
		// Token: 0x040000B4 RID: 180
		InvalidData
	}
}
