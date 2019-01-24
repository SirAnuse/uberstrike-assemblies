using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x0200023D RID: 573
	[Serializable]
	public class PointDepositsViewModel
	{
		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000FA4 RID: 4004 RVA: 0x0000A92C File Offset: 0x00008B2C
		// (set) Token: 0x06000FA5 RID: 4005 RVA: 0x0000A934 File Offset: 0x00008B34
		public List<PointDepositView> PointDeposits { get; set; }

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x0000A93D File Offset: 0x00008B3D
		// (set) Token: 0x06000FA7 RID: 4007 RVA: 0x0000A945 File Offset: 0x00008B45
		public int TotalCount { get; set; }
	}
}
