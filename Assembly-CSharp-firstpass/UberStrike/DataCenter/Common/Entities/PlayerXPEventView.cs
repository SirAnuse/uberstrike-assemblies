using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001EC RID: 492
	[Serializable]
	public class PlayerXPEventView
	{
		// Token: 0x06000D09 RID: 3337 RVA: 0x00002050 File Offset: 0x00000250
		public PlayerXPEventView()
		{
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x00009368 File Offset: 0x00007568
		public PlayerXPEventView(string name, decimal xpMultiplier)
		{
			this.Name = name;
			this.XPMultiplier = xpMultiplier;
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x0000937E File Offset: 0x0000757E
		public PlayerXPEventView(int playerXPEventId, string name, decimal xpMultiplier) : this(name, xpMultiplier)
		{
			this.PlayerXPEventId = playerXPEventId;
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000D0C RID: 3340 RVA: 0x0000938F File Offset: 0x0000758F
		// (set) Token: 0x06000D0D RID: 3341 RVA: 0x00009397 File Offset: 0x00007597
		public int PlayerXPEventId { get; set; }

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000D0E RID: 3342 RVA: 0x000093A0 File Offset: 0x000075A0
		// (set) Token: 0x06000D0F RID: 3343 RVA: 0x000093A8 File Offset: 0x000075A8
		public string Name { get; set; }

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000D10 RID: 3344 RVA: 0x000093B1 File Offset: 0x000075B1
		// (set) Token: 0x06000D11 RID: 3345 RVA: 0x000093B9 File Offset: 0x000075B9
		public decimal XPMultiplier { get; set; }

		// Token: 0x06000D12 RID: 3346 RVA: 0x00010DA0 File Offset: 0x0000EFA0
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[PlayerXPEventView: ");
			stringBuilder.Append("[PlayerXPEventId: ");
			stringBuilder.Append(this.PlayerXPEventId);
			stringBuilder.Append("][Name: ");
			stringBuilder.Append(this.Name);
			stringBuilder.Append("][XPMultiplier: ");
			stringBuilder.Append(this.XPMultiplier);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
