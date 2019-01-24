using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000197 RID: 407
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SteamControllerState_t
	{
		// Token: 0x040008FC RID: 2300
		public uint unPacketNum;

		// Token: 0x040008FD RID: 2301
		public ulong ulButtons;

		// Token: 0x040008FE RID: 2302
		public short sLeftPadX;

		// Token: 0x040008FF RID: 2303
		public short sLeftPadY;

		// Token: 0x04000900 RID: 2304
		public short sRightPadX;

		// Token: 0x04000901 RID: 2305
		public short sRightPadY;
	}
}
