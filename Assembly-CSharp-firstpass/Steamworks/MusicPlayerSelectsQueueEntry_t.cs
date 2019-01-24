using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000103 RID: 259
	[CallbackIdentity(4012)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerSelectsQueueEntry_t
	{
		// Token: 0x0400048B RID: 1163
		public const int k_iCallback = 4012;

		// Token: 0x0400048C RID: 1164
		public int nID;
	}
}
