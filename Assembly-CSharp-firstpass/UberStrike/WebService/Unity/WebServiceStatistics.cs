using System;
using System.Collections.Generic;

namespace UberStrike.WebService.Unity
{
	// Token: 0x02000318 RID: 792
	public static class WebServiceStatistics
	{
		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06001217 RID: 4631 RVA: 0x0000B979 File Offset: 0x00009B79
		// (set) Token: 0x06001218 RID: 4632 RVA: 0x0000B980 File Offset: 0x00009B80
		public static long TotalBytesIn { get; private set; }

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06001219 RID: 4633 RVA: 0x0000B988 File Offset: 0x00009B88
		// (set) Token: 0x0600121A RID: 4634 RVA: 0x0000B98F File Offset: 0x00009B8F
		public static long TotalBytesOut { get; private set; }

		// Token: 0x0600121B RID: 4635 RVA: 0x0001E1F0 File Offset: 0x0001C3F0
		public static void RecordWebServiceBegin(string method, int bytes)
		{
			WebServiceStatistics.Statistics statistics = WebServiceStatistics.GetStatistics(method);
			statistics.Counter++;
			statistics.OutgoingBytes += bytes;
			WebServiceStatistics.TotalBytesOut += (long)bytes;
			statistics.LastCall = DateTime.UtcNow;
		}

		// Token: 0x0600121C RID: 4636 RVA: 0x0001E238 File Offset: 0x0001C438
		public static void RecordWebServiceEnd(string method, int bytes, bool success)
		{
			WebServiceStatistics.Statistics statistics = WebServiceStatistics.GetStatistics(method);
			statistics.IncomingBytes += bytes;
			WebServiceStatistics.TotalBytesIn += (long)bytes;
			if (!success)
			{
				statistics.FailCounter++;
			}
			statistics.Time = (float)DateTime.UtcNow.Subtract(statistics.LastCall).TotalSeconds;
		}

		// Token: 0x0600121D RID: 4637 RVA: 0x0001E2A0 File Offset: 0x0001C4A0
		private static WebServiceStatistics.Statistics GetStatistics(string method)
		{
			WebServiceStatistics.Statistics statistics;
			if (!WebServiceStatistics.Data.TryGetValue(method, out statistics))
			{
				statistics = new WebServiceStatistics.Statistics();
				WebServiceStatistics.Data[method] = statistics;
			}
			return statistics;
		}

		// Token: 0x04000D09 RID: 3337
		public static bool IsEnabled = true;

		// Token: 0x04000D0A RID: 3338
		public static readonly Dictionary<string, WebServiceStatistics.Statistics> Data = new Dictionary<string, WebServiceStatistics.Statistics>();

		// Token: 0x02000319 RID: 793
		public class Statistics
		{
			// Token: 0x0600121E RID: 4638 RVA: 0x0000B997 File Offset: 0x00009B97
			public Statistics()
			{
				this.LastCall = DateTime.UtcNow;
			}

			// Token: 0x170003A6 RID: 934
			// (get) Token: 0x0600121F RID: 4639 RVA: 0x0000B9AA File Offset: 0x00009BAA
			// (set) Token: 0x06001220 RID: 4640 RVA: 0x0000B9B2 File Offset: 0x00009BB2
			public int Counter { get; set; }

			// Token: 0x170003A7 RID: 935
			// (get) Token: 0x06001221 RID: 4641 RVA: 0x0000B9BB File Offset: 0x00009BBB
			// (set) Token: 0x06001222 RID: 4642 RVA: 0x0000B9C3 File Offset: 0x00009BC3
			public int IncomingBytes { get; set; }

			// Token: 0x170003A8 RID: 936
			// (get) Token: 0x06001223 RID: 4643 RVA: 0x0000B9CC File Offset: 0x00009BCC
			// (set) Token: 0x06001224 RID: 4644 RVA: 0x0000B9D4 File Offset: 0x00009BD4
			public int OutgoingBytes { get; set; }

			// Token: 0x170003A9 RID: 937
			// (get) Token: 0x06001225 RID: 4645 RVA: 0x0000B9DD File Offset: 0x00009BDD
			// (set) Token: 0x06001226 RID: 4646 RVA: 0x0000B9E5 File Offset: 0x00009BE5
			public int FailCounter { get; set; }

			// Token: 0x170003AA RID: 938
			// (get) Token: 0x06001227 RID: 4647 RVA: 0x0000B9EE File Offset: 0x00009BEE
			// (set) Token: 0x06001228 RID: 4648 RVA: 0x0000B9F6 File Offset: 0x00009BF6
			public float Time { get; set; }

			// Token: 0x170003AB RID: 939
			// (get) Token: 0x06001229 RID: 4649 RVA: 0x0000B9FF File Offset: 0x00009BFF
			// (set) Token: 0x0600122A RID: 4650 RVA: 0x0000BA07 File Offset: 0x00009C07
			internal DateTime LastCall { get; set; }

			// Token: 0x0600122B RID: 4651 RVA: 0x0001E2D4 File Offset: 0x0001C4D4
			public override string ToString()
			{
				return string.Format("\tcount:{0}({1}) | time:{2:N2} | data:{3:F0}/{4:F0}", new object[]
				{
					this.Counter,
					this.FailCounter,
					this.Time,
					(float)this.IncomingBytes / 1024f,
					(float)this.OutgoingBytes / 1024f
				});
			}
		}
	}
}
