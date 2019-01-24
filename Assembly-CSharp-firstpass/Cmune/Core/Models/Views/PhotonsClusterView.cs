using System;
using System.Collections.Generic;

namespace Cmune.Core.Models.Views
{
	// Token: 0x02000066 RID: 102
	public class PhotonsClusterView
	{
		// Token: 0x06000309 RID: 777 RVA: 0x00003A5A File Offset: 0x00001C5A
		public PhotonsClusterView(int photonsClusterId, string name, string description, List<PhotonView> photons)
		{
			this.PhotonsClusterId = photonsClusterId;
			this.Name = name;
			this.Description = description;
			this.Photons = photons;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00003A7F File Offset: 0x00001C7F
		public PhotonsClusterView(int photonsClusterId, string name, List<PhotonView> photons) : this(photonsClusterId, name, string.Empty, photons)
		{
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600030B RID: 779 RVA: 0x00003A8F File Offset: 0x00001C8F
		// (set) Token: 0x0600030C RID: 780 RVA: 0x00003A97 File Offset: 0x00001C97
		public int PhotonsClusterId { get; set; }

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600030D RID: 781 RVA: 0x00003AA0 File Offset: 0x00001CA0
		// (set) Token: 0x0600030E RID: 782 RVA: 0x00003AA8 File Offset: 0x00001CA8
		public string Name { get; set; }

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600030F RID: 783 RVA: 0x00003AB1 File Offset: 0x00001CB1
		// (set) Token: 0x06000310 RID: 784 RVA: 0x00003AB9 File Offset: 0x00001CB9
		public string Description { get; set; }

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000311 RID: 785 RVA: 0x00003AC2 File Offset: 0x00001CC2
		// (set) Token: 0x06000312 RID: 786 RVA: 0x00003ACA File Offset: 0x00001CCA
		public List<PhotonView> Photons { get; set; }
	}
}
