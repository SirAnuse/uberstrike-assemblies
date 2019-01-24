using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200006D RID: 109
	[Serializable]
	public class PublicProfileView
	{
		// Token: 0x06000358 RID: 856 RVA: 0x0000E62C File Offset: 0x0000C82C
		public PublicProfileView()
		{
			this.Cmid = 0;
			this.Name = string.Empty;
			this.IsChatDisabled = false;
			this.AccessLevel = MemberAccessLevel.Default;
			this.GroupTag = string.Empty;
			this.LastLoginDate = DateTime.UtcNow;
			this.EmailAddressStatus = EmailAddressStatus.Unverified;
			this.FacebookId = string.Empty;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000E688 File Offset: 0x0000C888
		public PublicProfileView(int cmid, string name, MemberAccessLevel accesLevel, bool isChatDisabled, DateTime lastLoginDate, EmailAddressStatus emailAddressStatus, string facebookId)
		{
			this.SetPublicProfile(cmid, name, accesLevel, isChatDisabled, string.Empty, lastLoginDate, emailAddressStatus, facebookId);
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000E6B4 File Offset: 0x0000C8B4
		public PublicProfileView(int cmid, string name, MemberAccessLevel accesLevel, bool isChatDisabled, string groupTag, DateTime lastLoginDate, EmailAddressStatus emailAddressStatus, string facebookId)
		{
			this.SetPublicProfile(cmid, name, accesLevel, isChatDisabled, groupTag, lastLoginDate, emailAddressStatus, facebookId);
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x0600035B RID: 859 RVA: 0x00003D17 File Offset: 0x00001F17
		// (set) Token: 0x0600035C RID: 860 RVA: 0x00003D1F File Offset: 0x00001F1F
		public int Cmid { get; set; }

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00003D28 File Offset: 0x00001F28
		// (set) Token: 0x0600035E RID: 862 RVA: 0x00003D30 File Offset: 0x00001F30
		public string Name { get; set; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x0600035F RID: 863 RVA: 0x00003D39 File Offset: 0x00001F39
		// (set) Token: 0x06000360 RID: 864 RVA: 0x00003D41 File Offset: 0x00001F41
		public bool IsChatDisabled { get; set; }

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000361 RID: 865 RVA: 0x00003D4A File Offset: 0x00001F4A
		// (set) Token: 0x06000362 RID: 866 RVA: 0x00003D52 File Offset: 0x00001F52
		public MemberAccessLevel AccessLevel { get; set; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000363 RID: 867 RVA: 0x00003D5B File Offset: 0x00001F5B
		// (set) Token: 0x06000364 RID: 868 RVA: 0x00003D63 File Offset: 0x00001F63
		public string GroupTag { get; set; }

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000365 RID: 869 RVA: 0x00003D6C File Offset: 0x00001F6C
		// (set) Token: 0x06000366 RID: 870 RVA: 0x00003D74 File Offset: 0x00001F74
		public DateTime LastLoginDate { get; set; }

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00003D7D File Offset: 0x00001F7D
		// (set) Token: 0x06000368 RID: 872 RVA: 0x00003D85 File Offset: 0x00001F85
		public EmailAddressStatus EmailAddressStatus { get; set; }

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000369 RID: 873 RVA: 0x00003D8E File Offset: 0x00001F8E
		// (set) Token: 0x0600036A RID: 874 RVA: 0x00003D96 File Offset: 0x00001F96
		public string FacebookId { get; set; }

		// Token: 0x0600036B RID: 875 RVA: 0x00003D9F File Offset: 0x00001F9F
		private void SetPublicProfile(int cmid, string name, MemberAccessLevel accesLevel, bool isChatDisabled, string groupTag, DateTime lastLoginDate, EmailAddressStatus emailAddressStatus, string facebookId)
		{
			this.Cmid = cmid;
			this.Name = name;
			this.AccessLevel = accesLevel;
			this.IsChatDisabled = isChatDisabled;
			this.GroupTag = groupTag;
			this.LastLoginDate = lastLoginDate;
			this.EmailAddressStatus = emailAddressStatus;
			this.FacebookId = facebookId;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0000E6DC File Offset: 0x0000C8DC
		public override string ToString()
		{
			string text = "[Public profile: ";
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[Member name:",
				this.Name,
				"][CMID:",
				this.Cmid,
				"][Is banned from chat: ",
				this.IsChatDisabled,
				"]"
			});
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[Access level:",
				this.AccessLevel,
				"][Group tag: ",
				this.GroupTag,
				"][Last login date: ",
				this.LastLoginDate,
				"]]"
			});
			text2 = text;
			return string.Concat(new object[]
			{
				text2,
				"[EmailAddressStatus:",
				this.EmailAddressStatus,
				"][FacebookId: ",
				this.FacebookId,
				"]"
			});
		}
	}
}
