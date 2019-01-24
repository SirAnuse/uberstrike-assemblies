using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200012F RID: 303
	[CallbackIdentity(113)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ClientGameServerDeny_t
	{
		// Token: 0x04000543 RID: 1347
		public const int k_iCallback = 113;

		// Token: 0x04000544 RID: 1348
		public uint m_uAppID;

		// Token: 0x04000545 RID: 1349
		public uint m_unGameServerIP;

		// Token: 0x04000546 RID: 1350
		public ushort m_usGameServerPort;

		// Token: 0x04000547 RID: 1351
		public ushort m_bSecure;

		// Token: 0x04000548 RID: 1352
		public uint m_uReason;
	}
}
