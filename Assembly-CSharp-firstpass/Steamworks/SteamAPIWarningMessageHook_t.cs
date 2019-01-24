using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x0200036E RID: 878
	// (Invoke) Token: 0x060014A1 RID: 5281
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void SteamAPIWarningMessageHook_t(int nSeverity, StringBuilder pchDebugText);
}
