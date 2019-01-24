using System;
using System.Collections.Generic;
using Cmune.Core.Models.Views;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x02000233 RID: 563
	[Serializable]
	public class GameApplicationView
	{
		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000F35 RID: 3893 RVA: 0x0000A5CF File Offset: 0x000087CF
		// (set) Token: 0x06000F36 RID: 3894 RVA: 0x0000A5D7 File Offset: 0x000087D7
		public string Version { get; set; }

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000F37 RID: 3895 RVA: 0x0000A5E0 File Offset: 0x000087E0
		// (set) Token: 0x06000F38 RID: 3896 RVA: 0x0000A5E8 File Offset: 0x000087E8
		public List<PhotonView> GameServers { get; set; }

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x0000A5F1 File Offset: 0x000087F1
		// (set) Token: 0x06000F3A RID: 3898 RVA: 0x0000A5F9 File Offset: 0x000087F9
		public PhotonView CommServer { get; set; }

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000F3B RID: 3899 RVA: 0x0000A602 File Offset: 0x00008802
		// (set) Token: 0x06000F3C RID: 3900 RVA: 0x0000A60A File Offset: 0x0000880A
		public string SupportUrl { get; set; }

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x0000A613 File Offset: 0x00008813
		// (set) Token: 0x06000F3E RID: 3902 RVA: 0x0000A61B File Offset: 0x0000881B
		public string EncryptionInitVector { get; set; }

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x0000A624 File Offset: 0x00008824
		// (set) Token: 0x06000F40 RID: 3904 RVA: 0x0000A62C File Offset: 0x0000882C
		public string EncryptionPassPhrase { get; set; }
	}
}
