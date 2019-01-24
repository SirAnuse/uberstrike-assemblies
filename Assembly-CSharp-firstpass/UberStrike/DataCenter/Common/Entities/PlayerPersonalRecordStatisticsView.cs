using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E9 RID: 489
	[Serializable]
	public class PlayerPersonalRecordStatisticsView
	{
		// Token: 0x06000C8F RID: 3215 RVA: 0x00002050 File Offset: 0x00000250
		public PlayerPersonalRecordStatisticsView()
		{
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x00010564 File Offset: 0x0000E764
		public PlayerPersonalRecordStatisticsView(int mostHeadshots, int mostNutshots, int mostConsecutiveSnipes, int mostXPEarned, int mostSplats, int mostDamageDealt, int mostDamageReceived, int mostArmorPickedUp, int mostHealthPickedUp, int mostMeleeSplats, int mostMachinegunSplats, int mostShotgunSplats, int mostSniperSplats, int mostSplattergunSplats, int mostCannonSplats, int mostLauncherSplats)
		{
			this.MostArmorPickedUp = mostArmorPickedUp;
			this.MostCannonSplats = mostCannonSplats;
			this.MostConsecutiveSnipes = mostConsecutiveSnipes;
			this.MostDamageDealt = mostDamageDealt;
			this.MostDamageReceived = mostDamageReceived;
			this.MostHeadshots = mostHeadshots;
			this.MostHealthPickedUp = mostHealthPickedUp;
			this.MostLauncherSplats = mostLauncherSplats;
			this.MostMachinegunSplats = mostMachinegunSplats;
			this.MostMeleeSplats = mostMeleeSplats;
			this.MostNutshots = mostNutshots;
			this.MostShotgunSplats = mostShotgunSplats;
			this.MostSniperSplats = mostSniperSplats;
			this.MostSplats = mostSplats;
			this.MostSplattergunSplats = mostSplattergunSplats;
			this.MostXPEarned = mostXPEarned;
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000C91 RID: 3217 RVA: 0x00008F92 File Offset: 0x00007192
		// (set) Token: 0x06000C92 RID: 3218 RVA: 0x00008F9A File Offset: 0x0000719A
		public int MostHeadshots { get; set; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000C93 RID: 3219 RVA: 0x00008FA3 File Offset: 0x000071A3
		// (set) Token: 0x06000C94 RID: 3220 RVA: 0x00008FAB File Offset: 0x000071AB
		public int MostNutshots { get; set; }

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000C95 RID: 3221 RVA: 0x00008FB4 File Offset: 0x000071B4
		// (set) Token: 0x06000C96 RID: 3222 RVA: 0x00008FBC File Offset: 0x000071BC
		public int MostConsecutiveSnipes { get; set; }

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000C97 RID: 3223 RVA: 0x00008FC5 File Offset: 0x000071C5
		// (set) Token: 0x06000C98 RID: 3224 RVA: 0x00008FCD File Offset: 0x000071CD
		public int MostXPEarned { get; set; }

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000C99 RID: 3225 RVA: 0x00008FD6 File Offset: 0x000071D6
		// (set) Token: 0x06000C9A RID: 3226 RVA: 0x00008FDE File Offset: 0x000071DE
		public int MostSplats { get; set; }

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x00008FE7 File Offset: 0x000071E7
		// (set) Token: 0x06000C9C RID: 3228 RVA: 0x00008FEF File Offset: 0x000071EF
		public int MostDamageDealt { get; set; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x00008FF8 File Offset: 0x000071F8
		// (set) Token: 0x06000C9E RID: 3230 RVA: 0x00009000 File Offset: 0x00007200
		public int MostDamageReceived { get; set; }

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x00009009 File Offset: 0x00007209
		// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x00009011 File Offset: 0x00007211
		public int MostArmorPickedUp { get; set; }

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x0000901A File Offset: 0x0000721A
		// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x00009022 File Offset: 0x00007222
		public int MostHealthPickedUp { get; set; }

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x0000902B File Offset: 0x0000722B
		// (set) Token: 0x06000CA4 RID: 3236 RVA: 0x00009033 File Offset: 0x00007233
		public int MostMeleeSplats { get; set; }

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x0000903C File Offset: 0x0000723C
		// (set) Token: 0x06000CA6 RID: 3238 RVA: 0x00009044 File Offset: 0x00007244
		public int MostMachinegunSplats { get; set; }

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x0000904D File Offset: 0x0000724D
		// (set) Token: 0x06000CA8 RID: 3240 RVA: 0x00009055 File Offset: 0x00007255
		public int MostShotgunSplats { get; set; }

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x0000905E File Offset: 0x0000725E
		// (set) Token: 0x06000CAA RID: 3242 RVA: 0x00009066 File Offset: 0x00007266
		public int MostSniperSplats { get; set; }

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x0000906F File Offset: 0x0000726F
		// (set) Token: 0x06000CAC RID: 3244 RVA: 0x00009077 File Offset: 0x00007277
		public int MostSplattergunSplats { get; set; }

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x00009080 File Offset: 0x00007280
		// (set) Token: 0x06000CAE RID: 3246 RVA: 0x00009088 File Offset: 0x00007288
		public int MostCannonSplats { get; set; }

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x00009091 File Offset: 0x00007291
		// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x00009099 File Offset: 0x00007299
		public int MostLauncherSplats { get; set; }

		// Token: 0x06000CB1 RID: 3249 RVA: 0x000105F4 File Offset: 0x0000E7F4
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[PlayerPersonalRecordStatisticsView: ");
			stringBuilder.Append("[MostArmorPickedUp: ");
			stringBuilder.Append(this.MostArmorPickedUp);
			stringBuilder.Append("][MostCannonSplats: ");
			stringBuilder.Append(this.MostCannonSplats);
			stringBuilder.Append("][MostConsecutiveSnipes: ");
			stringBuilder.Append(this.MostConsecutiveSnipes);
			stringBuilder.Append("][MostDamageDealt: ");
			stringBuilder.Append(this.MostDamageDealt);
			stringBuilder.Append("][MostDamageReceived: ");
			stringBuilder.Append(this.MostDamageReceived);
			stringBuilder.Append("][MostHeadshots: ");
			stringBuilder.Append(this.MostHeadshots);
			stringBuilder.Append("][MostHealthPickedUp: ");
			stringBuilder.Append(this.MostHealthPickedUp);
			stringBuilder.Append("][MostLauncherSplats: ");
			stringBuilder.Append(this.MostLauncherSplats);
			stringBuilder.Append("][MostMachinegunSplats: ");
			stringBuilder.Append(this.MostMachinegunSplats);
			stringBuilder.Append("][MostMeleeSplats: ");
			stringBuilder.Append(this.MostMeleeSplats);
			stringBuilder.Append("][MostNutshots: ");
			stringBuilder.Append(this.MostNutshots);
			stringBuilder.Append("][MostShotgunSplats: ");
			stringBuilder.Append(this.MostShotgunSplats);
			stringBuilder.Append("][MostSniperSplats: ");
			stringBuilder.Append(this.MostSniperSplats);
			stringBuilder.Append("][MostSplats: ");
			stringBuilder.Append(this.MostSplats);
			stringBuilder.Append("][MostSplattergunSplats: ");
			stringBuilder.Append(this.MostSplattergunSplats);
			stringBuilder.Append("][MostXPEarned: ");
			stringBuilder.Append(this.MostXPEarned);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
