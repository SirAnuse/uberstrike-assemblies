using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001DC RID: 476
	public class LastIpView
	{
		// Token: 0x06000BB2 RID: 2994 RVA: 0x000086B6 File Offset: 0x000068B6
		public LastIpView(long ip, DateTime lastConnectionDate, List<LinkedMemberView> linkedMembers, BannedIpView bannedIpView)
		{
			this.Ip = ip;
			this.LastConnectionDate = lastConnectionDate;
			this.LinkedMembers = linkedMembers;
			this.BannedIpView = bannedIpView;
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x000086DB File Offset: 0x000068DB
		// (set) Token: 0x06000BB4 RID: 2996 RVA: 0x000086E3 File Offset: 0x000068E3
		public long Ip { get; private set; }

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000BB5 RID: 2997 RVA: 0x000086EC File Offset: 0x000068EC
		// (set) Token: 0x06000BB6 RID: 2998 RVA: 0x000086F4 File Offset: 0x000068F4
		public DateTime LastConnectionDate { get; private set; }

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000BB7 RID: 2999 RVA: 0x000086FD File Offset: 0x000068FD
		// (set) Token: 0x06000BB8 RID: 3000 RVA: 0x00008705 File Offset: 0x00006905
		public List<LinkedMemberView> LinkedMembers { get; private set; }

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000BB9 RID: 3001 RVA: 0x0000870E File Offset: 0x0000690E
		// (set) Token: 0x06000BBA RID: 3002 RVA: 0x00008716 File Offset: 0x00006916
		public BannedIpView BannedIpView { get; private set; }
	}
}
