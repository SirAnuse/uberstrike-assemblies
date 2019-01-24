using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200007A RID: 122
	public class ISteamMatchmakingServerListResponse
	{
		// Token: 0x060003A4 RID: 932 RVA: 0x0000ECB4 File Offset: 0x0000CEB4
		public ISteamMatchmakingServerListResponse(ISteamMatchmakingServerListResponse.ServerResponded onServerResponded, ISteamMatchmakingServerListResponse.ServerFailedToRespond onServerFailedToRespond, ISteamMatchmakingServerListResponse.RefreshComplete onRefreshComplete)
		{
			if (onServerResponded == null || onServerFailedToRespond == null || onRefreshComplete == null)
			{
				throw new ArgumentNullException();
			}
			this.m_ServerResponded = onServerResponded;
			this.m_ServerFailedToRespond = onServerFailedToRespond;
			this.m_RefreshComplete = onRefreshComplete;
			this.m_VTable = new ISteamMatchmakingServerListResponse.VTable
			{
				m_VTServerResponded = new ISteamMatchmakingServerListResponse.InternalServerResponded(this.InternalOnServerResponded),
				m_VTServerFailedToRespond = new ISteamMatchmakingServerListResponse.InternalServerFailedToRespond(this.InternalOnServerFailedToRespond),
				m_VTRefreshComplete = new ISteamMatchmakingServerListResponse.InternalRefreshComplete(this.InternalOnRefreshComplete)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingServerListResponse.VTable)));
			Marshal.StructureToPtr(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0000ED7C File Offset: 0x0000CF7C
		~ISteamMatchmakingServerListResponse()
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

		// Token: 0x060003A6 RID: 934 RVA: 0x00003FA5 File Offset: 0x000021A5
		private void InternalOnServerResponded(HServerListRequest hRequest, int iServer)
		{
			this.m_ServerResponded(hRequest, iServer);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00003FB4 File Offset: 0x000021B4
		private void InternalOnServerFailedToRespond(HServerListRequest hRequest, int iServer)
		{
			this.m_ServerFailedToRespond(hRequest, iServer);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00003FC3 File Offset: 0x000021C3
		private void InternalOnRefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response)
		{
			this.m_RefreshComplete(hRequest, response);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00003FD2 File Offset: 0x000021D2
		public static explicit operator IntPtr(ISteamMatchmakingServerListResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x0400030B RID: 779
		private ISteamMatchmakingServerListResponse.VTable m_VTable;

		// Token: 0x0400030C RID: 780
		private IntPtr m_pVTable;

		// Token: 0x0400030D RID: 781
		private GCHandle m_pGCHandle;

		// Token: 0x0400030E RID: 782
		private ISteamMatchmakingServerListResponse.ServerResponded m_ServerResponded;

		// Token: 0x0400030F RID: 783
		private ISteamMatchmakingServerListResponse.ServerFailedToRespond m_ServerFailedToRespond;

		// Token: 0x04000310 RID: 784
		private ISteamMatchmakingServerListResponse.RefreshComplete m_RefreshComplete;

		// Token: 0x0200007B RID: 123
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x04000311 RID: 785
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingServerListResponse.InternalServerResponded m_VTServerResponded;

			// Token: 0x04000312 RID: 786
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingServerListResponse.InternalServerFailedToRespond m_VTServerFailedToRespond;

			// Token: 0x04000313 RID: 787
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingServerListResponse.InternalRefreshComplete m_VTRefreshComplete;
		}

		// Token: 0x0200007C RID: 124
		// (Invoke) Token: 0x060003AC RID: 940
		public delegate void ServerResponded(HServerListRequest hRequest, int iServer);

		// Token: 0x0200007D RID: 125
		// (Invoke) Token: 0x060003B0 RID: 944
		public delegate void ServerFailedToRespond(HServerListRequest hRequest, int iServer);

		// Token: 0x0200007E RID: 126
		// (Invoke) Token: 0x060003B4 RID: 948
		public delegate void RefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response);

		// Token: 0x0200007F RID: 127
		// (Invoke) Token: 0x060003B8 RID: 952
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerResponded(HServerListRequest hRequest, int iServer);

		// Token: 0x02000080 RID: 128
		// (Invoke) Token: 0x060003BC RID: 956
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerFailedToRespond(HServerListRequest hRequest, int iServer);

		// Token: 0x02000081 RID: 129
		// (Invoke) Token: 0x060003C0 RID: 960
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalRefreshComplete(HServerListRequest hRequest, EMatchMakingServerResponse response);
	}
}
