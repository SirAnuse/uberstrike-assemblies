using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000050 RID: 80
	[Serializable]
	public class GroupCreationView
	{
		// Token: 0x0600015F RID: 351 RVA: 0x00002050 File Offset: 0x00000250
		public GroupCreationView()
		{
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000D840 File Offset: 0x0000BA40
		public GroupCreationView(string name, string description, string motto, string address, bool hasPicture, int applicationId, string authToken, string tag, string locale)
		{
			this.Name = name;
			this.Description = description;
			this.Motto = motto;
			this.Address = address;
			this.HasPicture = hasPicture;
			this.ApplicationId = applicationId;
			this.AuthToken = authToken;
			this.Tag = tag;
			this.Locale = locale;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000D898 File Offset: 0x0000BA98
		public GroupCreationView(string name, string motto, int applicationId, string authToken, string tag, string locale)
		{
			this.Name = name;
			this.Description = string.Empty;
			this.Motto = motto;
			this.Address = string.Empty;
			this.HasPicture = false;
			this.ApplicationId = applicationId;
			this.AuthToken = authToken;
			this.Tag = tag;
			this.Locale = locale;
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00002C16 File Offset: 0x00000E16
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00002C1E File Offset: 0x00000E1E
		public string Name { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00002C27 File Offset: 0x00000E27
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00002C2F File Offset: 0x00000E2F
		public string Description { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00002C38 File Offset: 0x00000E38
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00002C40 File Offset: 0x00000E40
		public string Motto { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00002C49 File Offset: 0x00000E49
		// (set) Token: 0x06000169 RID: 361 RVA: 0x00002C51 File Offset: 0x00000E51
		public string Address { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00002C5A File Offset: 0x00000E5A
		// (set) Token: 0x0600016B RID: 363 RVA: 0x00002C62 File Offset: 0x00000E62
		public bool HasPicture { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00002C6B File Offset: 0x00000E6B
		// (set) Token: 0x0600016D RID: 365 RVA: 0x00002C73 File Offset: 0x00000E73
		public int ApplicationId { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00002C7C File Offset: 0x00000E7C
		// (set) Token: 0x0600016F RID: 367 RVA: 0x00002C84 File Offset: 0x00000E84
		public string AuthToken { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00002C8D File Offset: 0x00000E8D
		// (set) Token: 0x06000171 RID: 369 RVA: 0x00002C95 File Offset: 0x00000E95
		public string Tag { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000172 RID: 370 RVA: 0x00002C9E File Offset: 0x00000E9E
		// (set) Token: 0x06000173 RID: 371 RVA: 0x00002CA6 File Offset: 0x00000EA6
		public string Locale { get; set; }

		// Token: 0x06000174 RID: 372 RVA: 0x0000D8F8 File Offset: 0x0000BAF8
		public override string ToString()
		{
			string text = string.Concat(new string[]
			{
				"[GroupCreationView: [name:",
				this.Name,
				"][description:",
				this.Description,
				"][Motto:",
				this.Motto,
				"]"
			});
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[Address:",
				this.Address,
				"][Has picture:",
				this.HasPicture,
				"][Application Id:",
				this.ApplicationId,
				"][AuthToken:",
				this.AuthToken,
				"]"
			});
			text2 = text;
			return string.Concat(new string[]
			{
				text2,
				"[Tag:",
				this.Tag,
				"][Locale:",
				this.Locale,
				"]"
			});
		}
	}
}
