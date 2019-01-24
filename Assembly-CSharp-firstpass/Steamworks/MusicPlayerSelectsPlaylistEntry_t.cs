using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000104 RID: 260
	[CallbackIdentity(4013)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerSelectsPlaylistEntry_t
	{
		// Token: 0x0400048D RID: 1165
		public const int k_iCallback = 4013;

		// Token: 0x0400048E RID: 1166
		public int nID;
	}
}
