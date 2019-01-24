using System;
using System.Collections.Generic;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E0 RID: 480
	public class MapClusterView
	{
		// Token: 0x06000C0D RID: 3085 RVA: 0x00008A39 File Offset: 0x00006C39
		public MapClusterView(string appVersion, List<MapInfoView> maps)
		{
			this.ApplicationVersion = appVersion;
			this.Maps = maps;
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x00008A4F File Offset: 0x00006C4F
		// (set) Token: 0x06000C0F RID: 3087 RVA: 0x00008A57 File Offset: 0x00006C57
		public string ApplicationVersion { get; private set; }

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000C10 RID: 3088 RVA: 0x00008A60 File Offset: 0x00006C60
		// (set) Token: 0x06000C11 RID: 3089 RVA: 0x00008A68 File Offset: 0x00006C68
		public List<MapInfoView> Maps { get; private set; }
	}
}
