using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000041 RID: 65
	[Serializable]
	public class CheckApplicationVersionView
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x00002050 File Offset: 0x00000250
		public CheckApplicationVersionView()
		{
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00002630 File Offset: 0x00000830
		public CheckApplicationVersionView(ApplicationView clienVersion, ApplicationView currentVersion)
		{
			this.ClientVersion = clienVersion;
			this.CurrentVersion = currentVersion;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00002646 File Offset: 0x00000846
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x0000264E File Offset: 0x0000084E
		public ApplicationView ClientVersion { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00002657 File Offset: 0x00000857
		// (set) Token: 0x060000BA RID: 186 RVA: 0x0000265F File Offset: 0x0000085F
		public ApplicationView CurrentVersion { get; set; }

		// Token: 0x060000BB RID: 187 RVA: 0x0000D34C File Offset: 0x0000B54C
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"[CheckApplicationVersionView: [ClientVersion: ",
				this.ClientVersion,
				"][CurrentVersion: ",
				this.CurrentVersion,
				"]]"
			});
		}
	}
}
