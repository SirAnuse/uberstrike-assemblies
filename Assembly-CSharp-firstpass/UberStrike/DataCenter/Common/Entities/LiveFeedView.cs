using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001DE RID: 478
	[Serializable]
	public class LiveFeedView
	{
		// Token: 0x06000BC0 RID: 3008 RVA: 0x00008757 File Offset: 0x00006957
		public LiveFeedView()
		{
			this.Date = DateTime.UtcNow;
			this.Priority = 0;
			this.Description = string.Empty;
			this.Url = string.Empty;
			this.LivedFeedId = 0;
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0000878E File Offset: 0x0000698E
		public LiveFeedView(DateTime date, int priority, string description, string url, int liveFeedId)
		{
			this.Date = date;
			this.Priority = priority;
			this.Description = description;
			this.Url = url;
			this.LivedFeedId = liveFeedId;
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x000087BB File Offset: 0x000069BB
		// (set) Token: 0x06000BC3 RID: 3011 RVA: 0x000087C3 File Offset: 0x000069C3
		public DateTime Date { get; set; }

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x000087CC File Offset: 0x000069CC
		// (set) Token: 0x06000BC5 RID: 3013 RVA: 0x000087D4 File Offset: 0x000069D4
		public int Priority { get; set; }

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x000087DD File Offset: 0x000069DD
		// (set) Token: 0x06000BC7 RID: 3015 RVA: 0x000087E5 File Offset: 0x000069E5
		public string Description { get; set; }

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x000087EE File Offset: 0x000069EE
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x000087F6 File Offset: 0x000069F6
		public string Url { get; set; }

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x000087FF File Offset: 0x000069FF
		// (set) Token: 0x06000BCB RID: 3019 RVA: 0x00008807 File Offset: 0x00006A07
		public int LivedFeedId { get; set; }
	}
}
