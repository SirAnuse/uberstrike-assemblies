using System;
using System.Collections.Generic;
using Cmune.Core.Models.Views;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001D6 RID: 470
	[Serializable]
	public class AuthenticateApplicationView
	{
		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000B6C RID: 2924 RVA: 0x000083EF File Offset: 0x000065EF
		// (set) Token: 0x06000B6D RID: 2925 RVA: 0x000083F7 File Offset: 0x000065F7
		public List<PhotonView> GameServers { get; set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000B6E RID: 2926 RVA: 0x00008400 File Offset: 0x00006600
		// (set) Token: 0x06000B6F RID: 2927 RVA: 0x00008408 File Offset: 0x00006608
		public PhotonView CommServer { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000B70 RID: 2928 RVA: 0x00008411 File Offset: 0x00006611
		// (set) Token: 0x06000B71 RID: 2929 RVA: 0x00008419 File Offset: 0x00006619
		public bool WarnPlayer { get; set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000B72 RID: 2930 RVA: 0x00008422 File Offset: 0x00006622
		// (set) Token: 0x06000B73 RID: 2931 RVA: 0x0000842A File Offset: 0x0000662A
		public bool IsEnabled { get; set; }

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000B74 RID: 2932 RVA: 0x00008433 File Offset: 0x00006633
		// (set) Token: 0x06000B75 RID: 2933 RVA: 0x0000843B File Offset: 0x0000663B
		public string EncryptionInitVector { get; set; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000B76 RID: 2934 RVA: 0x00008444 File Offset: 0x00006644
		// (set) Token: 0x06000B77 RID: 2935 RVA: 0x0000844C File Offset: 0x0000664C
		public string EncryptionPassPhrase { get; set; }
	}
}
