using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200003E RID: 62
	[Serializable]
	public class BugView
	{
		// Token: 0x0600007C RID: 124 RVA: 0x00002050 File Offset: 0x00000250
		public BugView()
		{
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002456 File Offset: 0x00000656
		public BugView(string subject, string content)
		{
			this.Subject = subject.Trim();
			this.Content = content.Trim();
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00002476 File Offset: 0x00000676
		// (set) Token: 0x0600007F RID: 127 RVA: 0x0000247E File Offset: 0x0000067E
		public string Content { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002487 File Offset: 0x00000687
		// (set) Token: 0x06000081 RID: 129 RVA: 0x0000248F File Offset: 0x0000068F
		public string Subject { get; set; }

		// Token: 0x06000082 RID: 130 RVA: 0x0000D308 File Offset: 0x0000B508
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"[Bug: [Subject: ",
				this.Subject,
				"][Content :",
				this.Content,
				"]]"
			});
		}
	}
}
