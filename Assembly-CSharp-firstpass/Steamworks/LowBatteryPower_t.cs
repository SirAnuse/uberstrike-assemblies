using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000146 RID: 326
	[CallbackIdentity(702)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LowBatteryPower_t
	{
		// Token: 0x0400058F RID: 1423
		public const int k_iCallback = 702;

		// Token: 0x04000590 RID: 1424
		public byte m_nMinutesBatteryLeft;
	}
}
