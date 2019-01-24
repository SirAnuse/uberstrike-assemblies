using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E3 RID: 483
	public class MapVersionView
	{
		// Token: 0x06000C32 RID: 3122 RVA: 0x00008BD2 File Offset: 0x00006DD2
		public MapVersionView(string fileName, DateTime lastUpdatedDate)
		{
			this.FileName = fileName;
			this.LastUpdatedDate = lastUpdatedDate;
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000C33 RID: 3123 RVA: 0x00008BE8 File Offset: 0x00006DE8
		// (set) Token: 0x06000C34 RID: 3124 RVA: 0x00008BF0 File Offset: 0x00006DF0
		public string FileName { get; private set; }

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000C35 RID: 3125 RVA: 0x00008BF9 File Offset: 0x00006DF9
		// (set) Token: 0x06000C36 RID: 3126 RVA: 0x00008C01 File Offset: 0x00006E01
		public DateTime LastUpdatedDate { get; set; }
	}
}
