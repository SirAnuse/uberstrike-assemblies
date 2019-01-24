using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000105 RID: 261
	[CallbackIdentity(4114)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerWantsPlayingRepeatStatus_t
	{
		// Token: 0x0400048F RID: 1167
		public const int k_iCallback = 4114;

		// Token: 0x04000490 RID: 1168
		public int m_nPlayingRepeatStatus;
	}
}
