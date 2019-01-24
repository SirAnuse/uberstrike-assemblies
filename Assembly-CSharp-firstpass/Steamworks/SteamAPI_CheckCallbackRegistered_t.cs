using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200036F RID: 879
	// (Invoke) Token: 0x060014A5 RID: 5285
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void SteamAPI_CheckCallbackRegistered_t(int iCallbackNum);
}
