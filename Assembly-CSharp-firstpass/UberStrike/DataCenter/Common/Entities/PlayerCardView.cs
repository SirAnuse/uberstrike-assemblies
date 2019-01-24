using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E6 RID: 486
	[Serializable]
	public class PlayerCardView : IComparable
	{
		// Token: 0x06000C50 RID: 3152 RVA: 0x00008CFA File Offset: 0x00006EFA
		public PlayerCardView()
		{
			this.Name = string.Empty;
			this.Precision = string.Empty;
			this.TagName = string.Empty;
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x00008D23 File Offset: 0x00006F23
		public PlayerCardView(int cmid, int splats, int splatted, long shots, long hits)
		{
			this.Cmid = cmid;
			this.Splats = splats;
			this.Splatted = splatted;
			this.Shots = shots;
			this.Hits = hits;
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00008D50 File Offset: 0x00006F50
		public PlayerCardView(int cmid, string name, int splats, int splatted, string precision, int ranking, string tagName)
		{
			this.Cmid = cmid;
			this.Name = name;
			this.Splats = splats;
			this.Splatted = splatted;
			this.Precision = precision;
			this.Ranking = ranking;
			this.TagName = tagName;
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x00008D8D File Offset: 0x00006F8D
		public PlayerCardView(string name, int splats, int splatted, string precision, int ranking, string tagName)
		{
			this.Name = name;
			this.Splats = splats;
			this.Splatted = splatted;
			this.Precision = precision;
			this.Ranking = ranking;
			this.TagName = tagName;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00010324 File Offset: 0x0000E524
		public PlayerCardView(int cmid, string name, int splats, int splatted, string precision, int ranking, long shots, long hits, string tagName)
		{
			this.Cmid = cmid;
			this.Name = name;
			this.Splats = splats;
			this.Splatted = splatted;
			this.Precision = precision;
			this.Ranking = ranking;
			this.Shots = shots;
			this.Hits = hits;
			this.TagName = tagName;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0001037C File Offset: 0x0000E57C
		public PlayerCardView(string name, int splats, int splatted, string precision, int ranking, long shots, long hits, string tagName)
		{
			this.Name = name;
			this.Splats = splats;
			this.Splatted = splatted;
			this.Precision = precision;
			this.Ranking = ranking;
			this.Shots = shots;
			this.Hits = hits;
			this.TagName = tagName;
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000C56 RID: 3158 RVA: 0x00008DC2 File Offset: 0x00006FC2
		// (set) Token: 0x06000C57 RID: 3159 RVA: 0x00008DCA File Offset: 0x00006FCA
		public string Name { get; set; }

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x06000C58 RID: 3160 RVA: 0x00008DD3 File Offset: 0x00006FD3
		// (set) Token: 0x06000C59 RID: 3161 RVA: 0x00008DDB File Offset: 0x00006FDB
		public int Cmid { get; set; }

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000C5A RID: 3162 RVA: 0x00008DE4 File Offset: 0x00006FE4
		// (set) Token: 0x06000C5B RID: 3163 RVA: 0x00008DEC File Offset: 0x00006FEC
		public int Splats { get; set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000C5C RID: 3164 RVA: 0x00008DF5 File Offset: 0x00006FF5
		// (set) Token: 0x06000C5D RID: 3165 RVA: 0x00008DFD File Offset: 0x00006FFD
		public int Splatted { get; set; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x00008E06 File Offset: 0x00007006
		// (set) Token: 0x06000C5F RID: 3167 RVA: 0x00008E0E File Offset: 0x0000700E
		public string Precision { get; set; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000C60 RID: 3168 RVA: 0x00008E17 File Offset: 0x00007017
		// (set) Token: 0x06000C61 RID: 3169 RVA: 0x00008E1F File Offset: 0x0000701F
		public int Ranking { get; set; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000C62 RID: 3170 RVA: 0x00008E28 File Offset: 0x00007028
		// (set) Token: 0x06000C63 RID: 3171 RVA: 0x00008E30 File Offset: 0x00007030
		public long Shots { get; set; }

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000C64 RID: 3172 RVA: 0x00008E39 File Offset: 0x00007039
		// (set) Token: 0x06000C65 RID: 3173 RVA: 0x00008E41 File Offset: 0x00007041
		public long Hits { get; set; }

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000C66 RID: 3174 RVA: 0x00008E4A File Offset: 0x0000704A
		// (set) Token: 0x06000C67 RID: 3175 RVA: 0x00008E52 File Offset: 0x00007052
		public string TagName { get; set; }

		// Token: 0x06000C68 RID: 3176 RVA: 0x000103CC File Offset: 0x0000E5CC
		public int CompareTo(object obj)
		{
			if (obj is PlayerCardView)
			{
				PlayerCardView playerCardView = obj as PlayerCardView;
				return -(playerCardView.Ranking - this.Ranking);
			}
			throw new ArgumentOutOfRangeException("Parameter is not of the good type");
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x00010404 File Offset: 0x0000E604
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"[Player: [Name: ",
				this.Name,
				"][Cmid: ",
				this.Cmid,
				"][Splats: ",
				this.Splats,
				"][Shots: ",
				this.Shots,
				"][Hits: ",
				this.Hits,
				"][Splatted: ",
				this.Splatted,
				"][Precision: ",
				this.Precision,
				"][Ranking: ",
				this.Ranking,
				"][TagName: ",
				this.TagName,
				"]]"
			});
		}
	}
}
