using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200006B RID: 107
	[Serializable]
	public class PrivateMessageView
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600033A RID: 826 RVA: 0x00003C29 File Offset: 0x00001E29
		// (set) Token: 0x0600033B RID: 827 RVA: 0x00003C31 File Offset: 0x00001E31
		public int PrivateMessageId { get; set; }

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00003C3A File Offset: 0x00001E3A
		// (set) Token: 0x0600033D RID: 829 RVA: 0x00003C42 File Offset: 0x00001E42
		public int FromCmid { get; set; }

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600033E RID: 830 RVA: 0x00003C4B File Offset: 0x00001E4B
		// (set) Token: 0x0600033F RID: 831 RVA: 0x00003C53 File Offset: 0x00001E53
		public string FromName { get; set; }

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00003C5C File Offset: 0x00001E5C
		// (set) Token: 0x06000341 RID: 833 RVA: 0x00003C64 File Offset: 0x00001E64
		public int ToCmid { get; set; }

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000342 RID: 834 RVA: 0x00003C6D File Offset: 0x00001E6D
		// (set) Token: 0x06000343 RID: 835 RVA: 0x00003C75 File Offset: 0x00001E75
		public DateTime DateSent { get; set; }

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000344 RID: 836 RVA: 0x00003C7E File Offset: 0x00001E7E
		// (set) Token: 0x06000345 RID: 837 RVA: 0x00003C86 File Offset: 0x00001E86
		public string ContentText { get; set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000346 RID: 838 RVA: 0x00003C8F File Offset: 0x00001E8F
		// (set) Token: 0x06000347 RID: 839 RVA: 0x00003C97 File Offset: 0x00001E97
		public bool IsRead { get; set; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x06000348 RID: 840 RVA: 0x00003CA0 File Offset: 0x00001EA0
		// (set) Token: 0x06000349 RID: 841 RVA: 0x00003CA8 File Offset: 0x00001EA8
		public bool HasAttachment { get; set; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x0600034A RID: 842 RVA: 0x00003CB1 File Offset: 0x00001EB1
		// (set) Token: 0x0600034B RID: 843 RVA: 0x00003CB9 File Offset: 0x00001EB9
		public bool IsDeletedBySender { get; set; }

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600034C RID: 844 RVA: 0x00003CC2 File Offset: 0x00001EC2
		// (set) Token: 0x0600034D RID: 845 RVA: 0x00003CCA File Offset: 0x00001ECA
		public bool IsDeletedByReceiver { get; set; }

		// Token: 0x0600034E RID: 846 RVA: 0x0000E510 File Offset: 0x0000C710
		public override string ToString()
		{
			string text = "[Private Message: ";
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[ID:",
				this.PrivateMessageId,
				"][From:",
				this.FromCmid,
				"][To:",
				this.ToCmid,
				"][Date:",
				this.DateSent,
				"]["
			});
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[Content:",
				this.ContentText,
				"][Is Read:",
				this.IsRead,
				"][Has attachment:",
				this.HasAttachment,
				"][Is deleted by sender:",
				this.IsDeletedBySender,
				"][Is deleted by receiver:",
				this.IsDeletedByReceiver,
				"]"
			});
			return text + "]";
		}
	}
}
