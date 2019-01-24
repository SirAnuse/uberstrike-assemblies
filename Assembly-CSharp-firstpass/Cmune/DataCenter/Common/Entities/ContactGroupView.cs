using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000048 RID: 72
	[Serializable]
	public class ContactGroupView
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x000027BD File Offset: 0x000009BD
		public ContactGroupView()
		{
			this.Contacts = new List<PublicProfileView>(0);
			this.GroupName = string.Empty;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000027DC File Offset: 0x000009DC
		public ContactGroupView(int groupID, string groupName, List<PublicProfileView> contacts)
		{
			this.GroupId = groupID;
			this.GroupName = groupName;
			this.Contacts = contacts;
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000027F9 File Offset: 0x000009F9
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00002801 File Offset: 0x00000A01
		public int GroupId { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x0000280A File Offset: 0x00000A0A
		// (set) Token: 0x060000EA RID: 234 RVA: 0x00002812 File Offset: 0x00000A12
		public string GroupName { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000EB RID: 235 RVA: 0x0000281B File Offset: 0x00000A1B
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00002823 File Offset: 0x00000A23
		public List<PublicProfileView> Contacts { get; set; }

		// Token: 0x060000ED RID: 237 RVA: 0x0000D4E8 File Offset: 0x0000B6E8
		public override string ToString()
		{
			string text = string.Concat(new object[]
			{
				"[Contact group: [Group ID: ",
				this.GroupId,
				"][Group Name :",
				this.GroupName,
				"][Contacts: "
			});
			foreach (PublicProfileView publicProfileView in this.Contacts)
			{
				text = text + "[Contact: " + publicProfileView.ToString() + "]";
			}
			text += "]]";
			return text;
		}
	}
}
