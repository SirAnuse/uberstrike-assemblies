using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000044 RID: 68
	[Serializable]
	public class ClanMemberView
	{
		// Token: 0x060000C7 RID: 199 RVA: 0x00002050 File Offset: 0x00000250
		public ClanMemberView()
		{
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000026C2 File Offset: 0x000008C2
		public ClanMemberView(string name, int cmid, GroupPosition position, DateTime joiningDate, DateTime lastLogin)
		{
			this.Cmid = cmid;
			this.Name = name;
			this.Position = position;
			this.JoiningDate = joiningDate;
			this.Lastlogin = lastLogin;
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x000026EF File Offset: 0x000008EF
		// (set) Token: 0x060000CA RID: 202 RVA: 0x000026F7 File Offset: 0x000008F7
		public string Name { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00002700 File Offset: 0x00000900
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00002708 File Offset: 0x00000908
		public int Cmid { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00002711 File Offset: 0x00000911
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00002719 File Offset: 0x00000919
		public GroupPosition Position { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00002722 File Offset: 0x00000922
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x0000272A File Offset: 0x0000092A
		public DateTime JoiningDate { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00002733 File Offset: 0x00000933
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x0000273B File Offset: 0x0000093B
		public DateTime Lastlogin { get; set; }

		// Token: 0x060000D3 RID: 211 RVA: 0x0000D390 File Offset: 0x0000B590
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"[Clan member: [Name: ",
				this.Name,
				"][Cmid: ",
				this.Cmid,
				"][Position: ",
				this.Position,
				"][JoiningDate: ",
				this.JoiningDate,
				"][Lastlogin: ",
				this.Lastlogin,
				"]]"
			});
		}
	}
}
