using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000370 RID: 880
	// (Invoke) Token: 0x060014A9 RID: 5289
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void SteamAPI_PostAPIResultInProcess_t(SteamAPICall_t callHandle, IntPtr pUnknown, uint unCallbackSize, int iCallbackNum);
}
