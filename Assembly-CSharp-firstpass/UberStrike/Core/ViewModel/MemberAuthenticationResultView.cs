using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x0200023A RID: 570
	[Serializable]
	public class MemberAuthenticationResultView
	{
		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000F8B RID: 3979 RVA: 0x0000A871 File Offset: 0x00008A71
		// (set) Token: 0x06000F8C RID: 3980 RVA: 0x0000A879 File Offset: 0x00008A79
		public MemberAuthenticationResult MemberAuthenticationResult { get; set; }

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000F8D RID: 3981 RVA: 0x0000A882 File Offset: 0x00008A82
		// (set) Token: 0x06000F8E RID: 3982 RVA: 0x0000A88A File Offset: 0x00008A8A
		public MemberView MemberView { get; set; }

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000F8F RID: 3983 RVA: 0x0000A893 File Offset: 0x00008A93
		// (set) Token: 0x06000F90 RID: 3984 RVA: 0x0000A89B File Offset: 0x00008A9B
		public PlayerStatisticsView PlayerStatisticsView { get; set; }

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000F91 RID: 3985 RVA: 0x0000A8A4 File Offset: 0x00008AA4
		// (set) Token: 0x06000F92 RID: 3986 RVA: 0x0000A8AC File Offset: 0x00008AAC
		public DateTime ServerTime { get; set; }

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000F93 RID: 3987 RVA: 0x0000A8B5 File Offset: 0x00008AB5
		// (set) Token: 0x06000F94 RID: 3988 RVA: 0x0000A8BD File Offset: 0x00008ABD
		public bool IsAccountComplete { get; set; }

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x0000A8C6 File Offset: 0x00008AC6
		// (set) Token: 0x06000F96 RID: 3990 RVA: 0x0000A8CE File Offset: 0x00008ACE
		public LuckyDrawUnityView LuckyDraw { get; set; }

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000F97 RID: 3991 RVA: 0x0000A8D7 File Offset: 0x00008AD7
		// (set) Token: 0x06000F98 RID: 3992 RVA: 0x0000A8DF File Offset: 0x00008ADF
		public string AuthToken { get; set; }
	}
}
