using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200003B RID: 59
	public class BannedIpView
	{
		// Token: 0x0600002C RID: 44 RVA: 0x0000D000 File Offset: 0x0000B200
		public BannedIpView(int bannedIpId, long ipAddress, DateTime? bannedUntil, DateTime banningDate, int sourceCmid, string sourceName, int targetCmid, string targetName, string reason)
		{
			this.BannedIpId = bannedIpId;
			this.IpAddress = ipAddress;
			this.BannedUntil = bannedUntil;
			this.BanningDate = banningDate;
			this.SourceCmid = sourceCmid;
			this.SourceName = sourceName;
			this.TargetCmid = targetCmid;
			this.TargetName = targetName;
			this.Reason = reason;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000021E1 File Offset: 0x000003E1
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000021E9 File Offset: 0x000003E9
		public int BannedIpId { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000021F2 File Offset: 0x000003F2
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000021FA File Offset: 0x000003FA
		public long IpAddress { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002203 File Offset: 0x00000403
		// (set) Token: 0x06000032 RID: 50 RVA: 0x0000220B File Offset: 0x0000040B
		public DateTime? BannedUntil { get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002214 File Offset: 0x00000414
		// (set) Token: 0x06000034 RID: 52 RVA: 0x0000221C File Offset: 0x0000041C
		public DateTime BanningDate { get; private set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002225 File Offset: 0x00000425
		// (set) Token: 0x06000036 RID: 54 RVA: 0x0000222D File Offset: 0x0000042D
		public int SourceCmid { get; private set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002236 File Offset: 0x00000436
		// (set) Token: 0x06000038 RID: 56 RVA: 0x0000223E File Offset: 0x0000043E
		public string SourceName { get; private set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002247 File Offset: 0x00000447
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000224F File Offset: 0x0000044F
		public int TargetCmid { get; private set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002258 File Offset: 0x00000458
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002260 File Offset: 0x00000460
		public string TargetName { get; private set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002269 File Offset: 0x00000469
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002271 File Offset: 0x00000471
		public string Reason { get; set; }
	}
}
