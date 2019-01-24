using System;
using System.Collections.Generic;
using UberStrike.Core.Models.Views;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x02000246 RID: 582
	[Serializable]
	public class UberstrikeLevelViewModel
	{
		// Token: 0x0600101B RID: 4123 RVA: 0x0000ACED File Offset: 0x00008EED
		public UberstrikeLevelViewModel()
		{
			this.Maps = new List<MapView>();
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x0600101C RID: 4124 RVA: 0x0000AD00 File Offset: 0x00008F00
		// (set) Token: 0x0600101D RID: 4125 RVA: 0x0000AD08 File Offset: 0x00008F08
		public List<MapView> Maps { get; set; }
	}
}
