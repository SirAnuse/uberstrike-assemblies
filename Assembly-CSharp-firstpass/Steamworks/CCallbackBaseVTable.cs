using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000074 RID: 116
	[StructLayout(LayoutKind.Sequential)]
	internal class CCallbackBaseVTable
	{
		// Token: 0x04000307 RID: 775
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public CCallbackBaseVTable.RunCRDel m_RunCallResult;

		// Token: 0x04000308 RID: 776
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public CCallbackBaseVTable.RunCBDel m_RunCallback;

		// Token: 0x04000309 RID: 777
		[NonSerialized]
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public CCallbackBaseVTable.GetCallbackSizeBytesDel m_GetCallbackSizeBytes;

		// Token: 0x02000075 RID: 117
		// (Invoke) Token: 0x06000394 RID: 916
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void RunCBDel(IntPtr pvParam);

		// Token: 0x02000076 RID: 118
		// (Invoke) Token: 0x06000398 RID: 920
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void RunCRDel(IntPtr pvParam, [MarshalAs(UnmanagedType.I1)] bool bIOFailure, ulong hSteamAPICall);

		// Token: 0x02000077 RID: 119
		// (Invoke) Token: 0x0600039C RID: 924
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate int GetCallbackSizeBytesDel();
	}
}
