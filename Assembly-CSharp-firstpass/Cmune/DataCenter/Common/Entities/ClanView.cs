using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000047 RID: 71
	[Serializable]
	public class ClanView : BasicClanView
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x00002799 File Offset: 0x00000999
		public ClanView()
		{
			this.Members = new List<ClanMemberView>();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000D420 File Offset: 0x0000B620
		public ClanView(int groupId, int membersCount, string description, string name, string motto, string address, DateTime foundingDate, string picture, GroupType type, DateTime lastUpdated, string tag, int membersLimit, GroupColor colorStyle, GroupFontStyle fontStyle, int applicationId, int ownerCmid, string ownerName, List<ClanMemberView> members) : base(groupId, membersCount, description, name, motto, address, foundingDate, picture, type, lastUpdated, tag, membersLimit, colorStyle, fontStyle, applicationId, ownerCmid, ownerName)
		{
			this.Members = members;
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x000027AC File Offset: 0x000009AC
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x000027B4 File Offset: 0x000009B4
		public List<ClanMemberView> Members { get; set; }

		// Token: 0x060000E4 RID: 228 RVA: 0x0000D45C File Offset: 0x0000B65C
		public override string ToString()
		{
			string text = "[Clan: " + base.ToString();
			text += "[Members:";
			foreach (ClanMemberView clanMemberView in this.Members)
			{
				text += clanMemberView.ToString();
			}
			text += "]";
			return text;
		}
	}
}
