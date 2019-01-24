using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200005A RID: 90
	[Serializable]
	public class MemberPositionUpdateView
	{
		// Token: 0x0600023C RID: 572 RVA: 0x00002050 File Offset: 0x00000250
		public MemberPositionUpdateView()
		{
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000032F6 File Offset: 0x000014F6
		public MemberPositionUpdateView(int groupId, string authToken, int memberCmid, GroupPosition position)
		{
			this.GroupId = groupId;
			this.AuthToken = authToken;
			this.MemberCmid = memberCmid;
			this.Position = position;
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600023E RID: 574 RVA: 0x0000331B File Offset: 0x0000151B
		// (set) Token: 0x0600023F RID: 575 RVA: 0x00003323 File Offset: 0x00001523
		public int GroupId { get; set; }

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000240 RID: 576 RVA: 0x0000332C File Offset: 0x0000152C
		// (set) Token: 0x06000241 RID: 577 RVA: 0x00003334 File Offset: 0x00001534
		public string AuthToken { get; set; }

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000242 RID: 578 RVA: 0x0000333D File Offset: 0x0000153D
		// (set) Token: 0x06000243 RID: 579 RVA: 0x00003345 File Offset: 0x00001545
		public int MemberCmid { get; set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000244 RID: 580 RVA: 0x0000334E File Offset: 0x0000154E
		// (set) Token: 0x06000245 RID: 581 RVA: 0x00003356 File Offset: 0x00001556
		public GroupPosition Position { get; set; }

		// Token: 0x06000246 RID: 582 RVA: 0x0000E108 File Offset: 0x0000C308
		public override string ToString()
		{
			string text = string.Concat(new object[]
			{
				"[MemberPositionUpdateView: [GroupId:",
				this.GroupId,
				"][AuthToken:",
				this.AuthToken,
				"][MemberCmid:",
				this.MemberCmid
			});
			string text2 = text;
			return string.Concat(new object[]
			{
				text2,
				"][Position:",
				this.Position,
				"]]"
			});
		}
	}
}
