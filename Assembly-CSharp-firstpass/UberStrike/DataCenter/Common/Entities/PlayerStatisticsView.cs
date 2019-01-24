using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001EA RID: 490
	[Serializable]
	public class PlayerStatisticsView
	{
		// Token: 0x06000CB2 RID: 3250 RVA: 0x000090A2 File Offset: 0x000072A2
		public PlayerStatisticsView()
		{
			this.PersonalRecord = new PlayerPersonalRecordStatisticsView();
			this.WeaponStatistics = new PlayerWeaponStatisticsView();
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x000107B8 File Offset: 0x0000E9B8
		public PlayerStatisticsView(int cmid, int splats, int splatted, long shots, long hits, int headshots, int nutshots, PlayerPersonalRecordStatisticsView personalRecord, PlayerWeaponStatisticsView weaponStatistics)
		{
			this.Cmid = cmid;
			this.Hits = hits;
			this.Level = 0;
			this.Shots = shots;
			this.Splats = splats;
			this.Splatted = splatted;
			this.Headshots = headshots;
			this.Nutshots = nutshots;
			this.Xp = 0;
			this.PersonalRecord = personalRecord;
			this.WeaponStatistics = weaponStatistics;
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x00010820 File Offset: 0x0000EA20
		public PlayerStatisticsView(int cmid, int splats, int splatted, long shots, long hits, int headshots, int nutshots, int xp, int level, PlayerPersonalRecordStatisticsView personalRecord, PlayerWeaponStatisticsView weaponStatistics)
		{
			this.Cmid = cmid;
			this.Hits = hits;
			this.Level = level;
			this.Shots = shots;
			this.Splats = splats;
			this.Splatted = splatted;
			this.Headshots = headshots;
			this.Nutshots = nutshots;
			this.Xp = xp;
			this.PersonalRecord = personalRecord;
			this.WeaponStatistics = weaponStatistics;
		}

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x000090C0 File Offset: 0x000072C0
		// (set) Token: 0x06000CB6 RID: 3254 RVA: 0x000090C8 File Offset: 0x000072C8
		public int Cmid { get; set; }

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x000090D1 File Offset: 0x000072D1
		// (set) Token: 0x06000CB8 RID: 3256 RVA: 0x000090D9 File Offset: 0x000072D9
		public int Splats { get; set; }

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x000090E2 File Offset: 0x000072E2
		// (set) Token: 0x06000CBA RID: 3258 RVA: 0x000090EA File Offset: 0x000072EA
		public int Splatted { get; set; }

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000CBB RID: 3259 RVA: 0x000090F3 File Offset: 0x000072F3
		// (set) Token: 0x06000CBC RID: 3260 RVA: 0x000090FB File Offset: 0x000072FB
		public long Shots { get; set; }

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000CBD RID: 3261 RVA: 0x00009104 File Offset: 0x00007304
		// (set) Token: 0x06000CBE RID: 3262 RVA: 0x0000910C File Offset: 0x0000730C
		public long Hits { get; set; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000CBF RID: 3263 RVA: 0x00009115 File Offset: 0x00007315
		// (set) Token: 0x06000CC0 RID: 3264 RVA: 0x0000911D File Offset: 0x0000731D
		public int Headshots { get; set; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x00009126 File Offset: 0x00007326
		// (set) Token: 0x06000CC2 RID: 3266 RVA: 0x0000912E File Offset: 0x0000732E
		public int Nutshots { get; set; }

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x00009137 File Offset: 0x00007337
		// (set) Token: 0x06000CC4 RID: 3268 RVA: 0x0000913F File Offset: 0x0000733F
		public int Xp { get; set; }

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x00009148 File Offset: 0x00007348
		// (set) Token: 0x06000CC6 RID: 3270 RVA: 0x00009150 File Offset: 0x00007350
		public int Level { get; set; }

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x00009159 File Offset: 0x00007359
		// (set) Token: 0x06000CC8 RID: 3272 RVA: 0x00009161 File Offset: 0x00007361
		public int TimeSpentInGame { get; set; }

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x0000916A File Offset: 0x0000736A
		// (set) Token: 0x06000CCA RID: 3274 RVA: 0x00009172 File Offset: 0x00007372
		public PlayerPersonalRecordStatisticsView PersonalRecord { get; set; }

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000CCB RID: 3275 RVA: 0x0000917B File Offset: 0x0000737B
		// (set) Token: 0x06000CCC RID: 3276 RVA: 0x00009183 File Offset: 0x00007383
		public PlayerWeaponStatisticsView WeaponStatistics { get; set; }

		// Token: 0x06000CCD RID: 3277 RVA: 0x00010888 File Offset: 0x0000EA88
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[PlayerStatisticsView: ");
			stringBuilder.Append("[Cmid: ");
			stringBuilder.Append(this.Cmid);
			stringBuilder.Append("][Hits: ");
			stringBuilder.Append(this.Hits);
			stringBuilder.Append("][Level: ");
			stringBuilder.Append(this.Level);
			stringBuilder.Append("][Shots: ");
			stringBuilder.Append(this.Shots);
			stringBuilder.Append("][Splats: ");
			stringBuilder.Append(this.Splats);
			stringBuilder.Append("][Splatted: ");
			stringBuilder.Append(this.Splatted);
			stringBuilder.Append("][Headshots: ");
			stringBuilder.Append(this.Headshots);
			stringBuilder.Append("][Nutshots: ");
			stringBuilder.Append(this.Nutshots);
			stringBuilder.Append("][Xp: ");
			stringBuilder.Append(this.Xp);
			stringBuilder.Append("]");
			stringBuilder.Append(this.PersonalRecord);
			stringBuilder.Append(this.WeaponStatistics);
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
