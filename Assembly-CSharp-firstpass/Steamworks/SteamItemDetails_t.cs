using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000190 RID: 400
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamItemDetails_t
	{
		// Token: 0x040008C9 RID: 2249
		public SteamItemInstanceID_t m_itemId;

		// Token: 0x040008CA RID: 2250
		public SteamItemDef_t m_iDefinition;

		// Token: 0x040008CB RID: 2251
		public ushort m_unQuantity;

		// Token: 0x040008CC RID: 2252
		public ushort m_unFlags;
	}
}
