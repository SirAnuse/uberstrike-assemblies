using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000102 RID: 258
	[CallbackIdentity(4011)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerWantsVolume_t
	{
		// Token: 0x04000489 RID: 1161
		public const int k_iCallback = 4011;

		// Token: 0x0400048A RID: 1162
		public float m_flNewVolume;
	}
}
