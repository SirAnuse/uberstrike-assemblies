using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000090 RID: 144
	public class ISteamMatchmakingRulesResponse
	{
		// Token: 0x060003F8 RID: 1016 RVA: 0x0000F018 File Offset: 0x0000D218
		public ISteamMatchmakingRulesResponse(ISteamMatchmakingRulesResponse.RulesResponded onRulesResponded, ISteamMatchmakingRulesResponse.RulesFailedToRespond onRulesFailedToRespond, ISteamMatchmakingRulesResponse.RulesRefreshComplete onRulesRefreshComplete)
		{
			if (onRulesResponded == null || onRulesFailedToRespond == null || onRulesRefreshComplete == null)
			{
				throw new ArgumentNullException();
			}
			this.m_RulesResponded = onRulesResponded;
			this.m_RulesFailedToRespond = onRulesFailedToRespond;
			this.m_RulesRefreshComplete = onRulesRefreshComplete;
			this.m_VTable = new ISteamMatchmakingRulesResponse.VTable
			{
				m_VTRulesResponded = new ISteamMatchmakingRulesResponse.InternalRulesResponded(this.InternalOnRulesResponded),
				m_VTRulesFailedToRespond = new ISteamMatchmakingRulesResponse.InternalRulesFailedToRespond(this.InternalOnRulesFailedToRespond),
				m_VTRulesRefreshComplete = new ISteamMatchmakingRulesResponse.InternalRulesRefreshComplete(this.InternalOnRulesRefreshComplete)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingRulesResponse.VTable)));
			Marshal.StructureToPtr(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000F0E0 File Offset: 0x0000D2E0
		~ISteamMatchmakingRulesResponse()
		{
			if (this.m_pVTable != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pVTable);
			}
			if (this.m_pGCHandle.IsAllocated)
			{
				this.m_pGCHandle.Free();
			}
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000403E File Offset: 0x0000223E
		private void InternalOnRulesResponded(string pchRule, string pchValue)
		{
			this.m_RulesResponded(pchRule, pchValue);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000404D File Offset: 0x0000224D
		private void InternalOnRulesFailedToRespond()
		{
			this.m_RulesFailedToRespond();
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000405A File Offset: 0x0000225A
		private void InternalOnRulesRefreshComplete()
		{
			this.m_RulesRefreshComplete();
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00004067 File Offset: 0x00002267
		public static explicit operator IntPtr(ISteamMatchmakingRulesResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x04000324 RID: 804
		private ISteamMatchmakingRulesResponse.VTable m_VTable;

		// Token: 0x04000325 RID: 805
		private IntPtr m_pVTable;

		// Token: 0x04000326 RID: 806
		private GCHandle m_pGCHandle;

		// Token: 0x04000327 RID: 807
		private ISteamMatchmakingRulesResponse.RulesResponded m_RulesResponded;

		// Token: 0x04000328 RID: 808
		private ISteamMatchmakingRulesResponse.RulesFailedToRespond m_RulesFailedToRespond;

		// Token: 0x04000329 RID: 809
		private ISteamMatchmakingRulesResponse.RulesRefreshComplete m_RulesRefreshComplete;

		// Token: 0x02000091 RID: 145
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x0400032A RID: 810
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingRulesResponse.InternalRulesResponded m_VTRulesResponded;

			// Token: 0x0400032B RID: 811
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingRulesResponse.InternalRulesFailedToRespond m_VTRulesFailedToRespond;

			// Token: 0x0400032C RID: 812
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingRulesResponse.InternalRulesRefreshComplete m_VTRulesRefreshComplete;
		}

		// Token: 0x02000092 RID: 146
		// (Invoke) Token: 0x06000400 RID: 1024
		public delegate void RulesResponded(string pchRule, string pchValue);

		// Token: 0x02000093 RID: 147
		// (Invoke) Token: 0x06000404 RID: 1028
		public delegate void RulesFailedToRespond();

		// Token: 0x02000094 RID: 148
		// (Invoke) Token: 0x06000408 RID: 1032
		public delegate void RulesRefreshComplete();

		// Token: 0x02000095 RID: 149
		// (Invoke) Token: 0x0600040C RID: 1036
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesResponded([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchRule, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchValue);

		// Token: 0x02000096 RID: 150
		// (Invoke) Token: 0x06000410 RID: 1040
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesFailedToRespond();

		// Token: 0x02000097 RID: 151
		// (Invoke) Token: 0x06000414 RID: 1044
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalRulesRefreshComplete();
	}
}
