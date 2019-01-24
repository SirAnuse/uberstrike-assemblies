using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001FA RID: 506
	[Serializable]
	public class UberstrikeMemberView
	{
		// Token: 0x06000D88 RID: 3464 RVA: 0x00002050 File Offset: 0x00000250
		public UberstrikeMemberView()
		{
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x00009769 File Offset: 0x00007969
		public UberstrikeMemberView(PlayerCardView playerCardView, PlayerStatisticsView playerStatisticsView)
		{
			this.PlayerCardView = playerCardView;
			this.PlayerStatisticsView = playerStatisticsView;
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000D8A RID: 3466 RVA: 0x0000977F File Offset: 0x0000797F
		// (set) Token: 0x06000D8B RID: 3467 RVA: 0x00009787 File Offset: 0x00007987
		public PlayerCardView PlayerCardView { get; set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000D8C RID: 3468 RVA: 0x00009790 File Offset: 0x00007990
		// (set) Token: 0x06000D8D RID: 3469 RVA: 0x00009798 File Offset: 0x00007998
		public PlayerStatisticsView PlayerStatisticsView { get; set; }

		// Token: 0x06000D8E RID: 3470 RVA: 0x000115A8 File Offset: 0x0000F7A8
		public override string ToString()
		{
			string str = "[Uberstrike member view: ";
			if (this.PlayerCardView != null)
			{
				str += this.PlayerCardView.ToString();
			}
			else
			{
				str += "null";
			}
			if (this.PlayerStatisticsView != null)
			{
				str += this.PlayerStatisticsView.ToString();
			}
			else
			{
				str += "null";
			}
			return str + "]";
		}
	}
}
