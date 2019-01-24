using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200003C RID: 60
	[Serializable]
	public class BasicClanView
	{
		// Token: 0x0600003F RID: 63 RVA: 0x00002050 File Offset: 0x00000250
		public BasicClanView()
		{
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000D058 File Offset: 0x0000B258
		public BasicClanView(int groupId, int membersCount, string description, string name, string motto, string address, DateTime foundingDate, string picture, GroupType type, DateTime lastUpdated, string tag, int membersLimit, GroupColor colorStyle, GroupFontStyle fontStyle, int applicationId, int ownerCmid, string ownerName)
		{
			this.SetClan(groupId, membersCount, description, name, motto, address, foundingDate, picture, type, lastUpdated, tag, membersLimit, colorStyle, fontStyle, applicationId, ownerCmid, ownerName);
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000041 RID: 65 RVA: 0x0000227A File Offset: 0x0000047A
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002282 File Offset: 0x00000482
		public int GroupId { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000228B File Offset: 0x0000048B
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002293 File Offset: 0x00000493
		public int MembersCount { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000045 RID: 69 RVA: 0x0000229C File Offset: 0x0000049C
		// (set) Token: 0x06000046 RID: 70 RVA: 0x000022A4 File Offset: 0x000004A4
		public string Description { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000022AD File Offset: 0x000004AD
		// (set) Token: 0x06000048 RID: 72 RVA: 0x000022B5 File Offset: 0x000004B5
		public string Name { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000022BE File Offset: 0x000004BE
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000022C6 File Offset: 0x000004C6
		public string Motto { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000022CF File Offset: 0x000004CF
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000022D7 File Offset: 0x000004D7
		public string Address { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000022E0 File Offset: 0x000004E0
		// (set) Token: 0x0600004E RID: 78 RVA: 0x000022E8 File Offset: 0x000004E8
		public DateTime FoundingDate { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000022F1 File Offset: 0x000004F1
		// (set) Token: 0x06000050 RID: 80 RVA: 0x000022F9 File Offset: 0x000004F9
		public string Picture { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002302 File Offset: 0x00000502
		// (set) Token: 0x06000052 RID: 82 RVA: 0x0000230A File Offset: 0x0000050A
		public GroupType Type { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002313 File Offset: 0x00000513
		// (set) Token: 0x06000054 RID: 84 RVA: 0x0000231B File Offset: 0x0000051B
		public DateTime LastUpdated { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002324 File Offset: 0x00000524
		// (set) Token: 0x06000056 RID: 86 RVA: 0x0000232C File Offset: 0x0000052C
		public string Tag { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002335 File Offset: 0x00000535
		// (set) Token: 0x06000058 RID: 88 RVA: 0x0000233D File Offset: 0x0000053D
		public int MembersLimit { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002346 File Offset: 0x00000546
		// (set) Token: 0x0600005A RID: 90 RVA: 0x0000234E File Offset: 0x0000054E
		public GroupColor ColorStyle { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002357 File Offset: 0x00000557
		// (set) Token: 0x0600005C RID: 92 RVA: 0x0000235F File Offset: 0x0000055F
		public GroupFontStyle FontStyle { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002368 File Offset: 0x00000568
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00002370 File Offset: 0x00000570
		public int ApplicationId { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002379 File Offset: 0x00000579
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002381 File Offset: 0x00000581
		public int OwnerCmid { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000061 RID: 97 RVA: 0x0000238A File Offset: 0x0000058A
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00002392 File Offset: 0x00000592
		public string OwnerName { get; set; }

		// Token: 0x06000063 RID: 99 RVA: 0x0000D090 File Offset: 0x0000B290
		public void SetClan(int groupId, int membersCount, string description, string name, string motto, string address, DateTime foundingDate, string picture, GroupType type, DateTime lastUpdated, string tag, int membersLimit, GroupColor colorStyle, GroupFontStyle fontStyle, int applicationId, int ownerCmid, string ownerName)
		{
			this.GroupId = groupId;
			this.MembersCount = membersCount;
			this.Description = description;
			this.Name = name;
			this.Motto = motto;
			this.Address = address;
			this.FoundingDate = foundingDate;
			this.Picture = picture;
			this.Type = type;
			this.LastUpdated = lastUpdated;
			this.Tag = tag;
			this.MembersLimit = membersLimit;
			this.ColorStyle = colorStyle;
			this.FontStyle = fontStyle;
			this.ApplicationId = applicationId;
			this.OwnerCmid = ownerCmid;
			this.OwnerName = ownerName;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000D124 File Offset: 0x0000B324
		public override string ToString()
		{
			string text = string.Concat(new object[]
			{
				"[Clan: [Id: ",
				this.GroupId,
				"][Members count: ",
				this.MembersCount,
				"][Description: ",
				this.Description,
				"]"
			});
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"[Name: ",
				this.Name,
				"][Motto: ",
				this.Name,
				"][Address: ",
				this.Address,
				"]"
			});
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[Creation date: ",
				this.FoundingDate,
				"][Picture: ",
				this.Picture,
				"][Type: ",
				this.Type,
				"][Last updated: ",
				this.LastUpdated,
				"]"
			});
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[Tag: ",
				this.Tag,
				"][Members limit: ",
				this.MembersLimit,
				"][Color style: ",
				this.ColorStyle,
				"][Font style: ",
				this.FontStyle,
				"]"
			});
			text2 = text;
			return string.Concat(new object[]
			{
				text2,
				"[Application Id: ",
				this.ApplicationId,
				"][Owner Cmid: ",
				this.OwnerCmid,
				"][Owner name: ",
				this.OwnerName,
				"]]"
			});
		}
	}
}
