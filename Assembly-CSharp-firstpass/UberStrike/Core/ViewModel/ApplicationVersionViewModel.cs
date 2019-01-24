using System;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x0200022F RID: 559
	public class ApplicationVersionViewModel
	{
		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000EFA RID: 3834 RVA: 0x0000A3F7 File Offset: 0x000085F7
		// (set) Token: 0x06000EFB RID: 3835 RVA: 0x0000A3FF File Offset: 0x000085FF
		public int ApplicationVersionId { get; set; }

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000EFC RID: 3836 RVA: 0x0000A408 File Offset: 0x00008608
		// (set) Token: 0x06000EFD RID: 3837 RVA: 0x0000A410 File Offset: 0x00008610
		public string Version { get; set; }

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000EFE RID: 3838 RVA: 0x0000A419 File Offset: 0x00008619
		// (set) Token: 0x06000EFF RID: 3839 RVA: 0x0000A421 File Offset: 0x00008621
		public string WebPlayerFileName { get; set; }

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000F00 RID: 3840 RVA: 0x0000A42A File Offset: 0x0000862A
		// (set) Token: 0x06000F01 RID: 3841 RVA: 0x0000A432 File Offset: 0x00008632
		public ChannelType Channel { get; set; }

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000F02 RID: 3842 RVA: 0x0000A43B File Offset: 0x0000863B
		// (set) Token: 0x06000F03 RID: 3843 RVA: 0x0000A443 File Offset: 0x00008643
		public DateTime ModificationDate { get; set; }

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000F04 RID: 3844 RVA: 0x0000A44C File Offset: 0x0000864C
		// (set) Token: 0x06000F05 RID: 3845 RVA: 0x0000A454 File Offset: 0x00008654
		public bool IsEnabled { get; set; }

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000F06 RID: 3846 RVA: 0x0000A45D File Offset: 0x0000865D
		// (set) Token: 0x06000F07 RID: 3847 RVA: 0x0000A465 File Offset: 0x00008665
		public bool WarnPlayer { get; set; }

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000F08 RID: 3848 RVA: 0x0000A46E File Offset: 0x0000866E
		// (set) Token: 0x06000F09 RID: 3849 RVA: 0x0000A476 File Offset: 0x00008676
		public int PhotonClusterId { get; set; }

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000F0A RID: 3850 RVA: 0x0000A47F File Offset: 0x0000867F
		// (set) Token: 0x06000F0B RID: 3851 RVA: 0x0000A487 File Offset: 0x00008687
		public string PhotonClusterName { get; set; }

		// Token: 0x06000F0C RID: 3852 RVA: 0x00011D94 File Offset: 0x0000FF94
		public bool IsValid(out string invalidStates)
		{
			bool flag = !string.IsNullOrEmpty(this.Version) && this.Channel > (ChannelType)(-1) && this.ModificationDate > DateTime.MinValue && this.PhotonClusterId > 0;
			invalidStates = string.Empty;
			if (!flag)
			{
				invalidStates = "Invalid Model, unknown version";
			}
			return flag;
		}
	}
}
