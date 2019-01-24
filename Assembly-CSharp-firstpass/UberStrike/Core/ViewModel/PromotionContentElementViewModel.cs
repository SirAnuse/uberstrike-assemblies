using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Types;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x0200023E RID: 574
	public class PromotionContentElementViewModel
	{
		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000FA9 RID: 4009 RVA: 0x0000A94E File Offset: 0x00008B4E
		// (set) Token: 0x06000FAA RID: 4010 RVA: 0x0000A956 File Offset: 0x00008B56
		public int PromotionContentElementId { get; set; }

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000FAB RID: 4011 RVA: 0x0000A95F File Offset: 0x00008B5F
		// (set) Token: 0x06000FAC RID: 4012 RVA: 0x0000A967 File Offset: 0x00008B67
		public ChannelType ChannelType { get; set; }

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000FAD RID: 4013 RVA: 0x0000A970 File Offset: 0x00008B70
		// (set) Token: 0x06000FAE RID: 4014 RVA: 0x0000A978 File Offset: 0x00008B78
		public ChannelElement ChannelElement { get; set; }

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000FAF RID: 4015 RVA: 0x0000A981 File Offset: 0x00008B81
		// (set) Token: 0x06000FB0 RID: 4016 RVA: 0x0000A989 File Offset: 0x00008B89
		public string Filename { get; set; }

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000FB1 RID: 4017 RVA: 0x0000A992 File Offset: 0x00008B92
		// (set) Token: 0x06000FB2 RID: 4018 RVA: 0x0000A99A File Offset: 0x00008B9A
		public string FilenameTitle { get; set; }

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000FB3 RID: 4019 RVA: 0x0000A9A3 File Offset: 0x00008BA3
		// (set) Token: 0x06000FB4 RID: 4020 RVA: 0x0000A9AB File Offset: 0x00008BAB
		public int PromotionContentId { get; set; }

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000FB5 RID: 4021 RVA: 0x0000A9B4 File Offset: 0x00008BB4
		// (set) Token: 0x06000FB6 RID: 4022 RVA: 0x0000A9BC File Offset: 0x00008BBC
		public string AnchorLink { get; set; }
	}
}
