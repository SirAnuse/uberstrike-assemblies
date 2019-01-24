using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200004F RID: 79
	public class EpinView
	{
		// Token: 0x06000154 RID: 340 RVA: 0x00002B94 File Offset: 0x00000D94
		public EpinView(int epinId, string pin, bool isRedeemed, int batchId, bool isRetired)
		{
			this.EpinId = epinId;
			this.Pin = pin;
			this.IsRedeemed = isRedeemed;
			this.BatchId = batchId;
			this.IsRetired = isRetired;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000155 RID: 341 RVA: 0x00002BC1 File Offset: 0x00000DC1
		// (set) Token: 0x06000156 RID: 342 RVA: 0x00002BC9 File Offset: 0x00000DC9
		public int EpinId { get; private set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00002BD2 File Offset: 0x00000DD2
		// (set) Token: 0x06000158 RID: 344 RVA: 0x00002BDA File Offset: 0x00000DDA
		public string Pin { get; private set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000159 RID: 345 RVA: 0x00002BE3 File Offset: 0x00000DE3
		// (set) Token: 0x0600015A RID: 346 RVA: 0x00002BEB File Offset: 0x00000DEB
		public bool IsRedeemed { get; private set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600015B RID: 347 RVA: 0x00002BF4 File Offset: 0x00000DF4
		// (set) Token: 0x0600015C RID: 348 RVA: 0x00002BFC File Offset: 0x00000DFC
		public int BatchId { get; private set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00002C05 File Offset: 0x00000E05
		// (set) Token: 0x0600015E RID: 350 RVA: 0x00002C0D File Offset: 0x00000E0D
		public bool IsRetired { get; private set; }
	}
}
