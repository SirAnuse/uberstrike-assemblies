using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200014A RID: 330
	[CallbackIdentity(714)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GamepadTextInputDismissed_t
	{
		// Token: 0x04000596 RID: 1430
		public const int k_iCallback = 714;

		// Token: 0x04000597 RID: 1431
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSubmitted;

		// Token: 0x04000598 RID: 1432
		public uint m_unSubmittedText;
	}
}
