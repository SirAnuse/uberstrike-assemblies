using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000051 RID: 81
	[Serializable]
	public class GroupInvitationView
	{
		// Token: 0x06000175 RID: 373 RVA: 0x00002050 File Offset: 0x00000250
		public GroupInvitationView()
		{
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000D9F4 File Offset: 0x0000BBF4
		public GroupInvitationView(int inviterCmid, int groupId, int inviteeCmid, string message)
		{
			this.InviterCmid = inviterCmid;
			this.InviterName = string.Empty;
			this.GroupName = string.Empty;
			this.GroupTag = string.Empty;
			this.GroupId = groupId;
			this.GroupInvitationId = 0;
			this.InviteeCmid = inviteeCmid;
			this.InviteeName = string.Empty;
			this.Message = message;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000DA58 File Offset: 0x0000BC58
		public GroupInvitationView(int inviterCmid, string inviterName, string groupName, string groupTag, int groupId, int groupInvitationId, int inviteeCmid, string inviteeName, string message)
		{
			this.InviterCmid = inviterCmid;
			this.InviterName = inviterName;
			this.GroupName = groupName;
			this.GroupTag = groupTag;
			this.GroupId = groupId;
			this.GroupInvitationId = groupInvitationId;
			this.InviteeCmid = inviteeCmid;
			this.InviteeName = inviteeName;
			this.Message = message;
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00002CAF File Offset: 0x00000EAF
		// (set) Token: 0x06000179 RID: 377 RVA: 0x00002CB7 File Offset: 0x00000EB7
		public string InviterName { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600017A RID: 378 RVA: 0x00002CC0 File Offset: 0x00000EC0
		// (set) Token: 0x0600017B RID: 379 RVA: 0x00002CC8 File Offset: 0x00000EC8
		public int InviterCmid { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00002CD1 File Offset: 0x00000ED1
		// (set) Token: 0x0600017D RID: 381 RVA: 0x00002CD9 File Offset: 0x00000ED9
		public int GroupId { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00002CE2 File Offset: 0x00000EE2
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00002CEA File Offset: 0x00000EEA
		public string GroupName { get; set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00002CF3 File Offset: 0x00000EF3
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00002CFB File Offset: 0x00000EFB
		public string GroupTag { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000182 RID: 386 RVA: 0x00002D04 File Offset: 0x00000F04
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00002D0C File Offset: 0x00000F0C
		public int GroupInvitationId { get; set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00002D15 File Offset: 0x00000F15
		// (set) Token: 0x06000185 RID: 389 RVA: 0x00002D1D File Offset: 0x00000F1D
		public string InviteeName { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00002D26 File Offset: 0x00000F26
		// (set) Token: 0x06000187 RID: 391 RVA: 0x00002D2E File Offset: 0x00000F2E
		public int InviteeCmid { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00002D37 File Offset: 0x00000F37
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00002D3F File Offset: 0x00000F3F
		public string Message { get; set; }

		// Token: 0x0600018A RID: 394 RVA: 0x0000DAB0 File Offset: 0x0000BCB0
		public override string ToString()
		{
			string text = string.Concat(new object[]
			{
				"[GroupInvitationDisplayView: [InviterCmid: ",
				this.InviterCmid,
				"][InviterName: ",
				this.InviterName,
				"]"
			});
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[GroupName: ",
				this.GroupName,
				"][GroupTag: ",
				this.GroupTag,
				"][GroupId: ",
				this.GroupId,
				"]"
			});
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[GroupInvitationId:",
				this.GroupInvitationId,
				"][InviteeCmid:",
				this.InviteeCmid,
				"][InviteeName:",
				this.InviteeName,
				"]"
			});
			return text + "[Message:" + this.Message + "]]";
		}
	}
}
