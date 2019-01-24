using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F7 RID: 247
	[CallbackIdentity(4002)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct VolumeHasChanged_t
	{
		// Token: 0x0400047B RID: 1147
		public const int k_iCallback = 4002;

		// Token: 0x0400047C RID: 1148
		public float m_flNewVolume;
	}
}
