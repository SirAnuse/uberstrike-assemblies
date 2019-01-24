using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000082 RID: 130
	public class ISteamMatchmakingPingResponse
	{
		// Token: 0x060003C3 RID: 963 RVA: 0x0000EDE0 File Offset: 0x0000CFE0
		public ISteamMatchmakingPingResponse(ISteamMatchmakingPingResponse.ServerResponded onServerResponded, ISteamMatchmakingPingResponse.ServerFailedToRespond onServerFailedToRespond)
		{
			if (onServerResponded == null || onServerFailedToRespond == null)
			{
				throw new ArgumentNullException();
			}
			this.m_ServerResponded = onServerResponded;
			this.m_ServerFailedToRespond = onServerFailedToRespond;
			this.m_VTable = new ISteamMatchmakingPingResponse.VTable
			{
				m_VTServerResponded = new ISteamMatchmakingPingResponse.InternalServerResponded(this.InternalOnServerResponded),
				m_VTServerFailedToRespond = new ISteamMatchmakingPingResponse.InternalServerFailedToRespond(this.InternalOnServerFailedToRespond)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingPingResponse.VTable)));
			Marshal.StructureToPtr(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0000EE88 File Offset: 0x0000D088
		~ISteamMatchmakingPingResponse()
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

		// Token: 0x060003C5 RID: 965 RVA: 0x00003FDF File Offset: 0x000021DF
		private void InternalOnServerResponded(gameserveritem_t server)
		{
			this.m_ServerResponded(server);
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00003FED File Offset: 0x000021ED
		private void InternalOnServerFailedToRespond()
		{
			this.m_ServerFailedToRespond();
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00003FFA File Offset: 0x000021FA
		public static explicit operator IntPtr(ISteamMatchmakingPingResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x04000314 RID: 788
		private ISteamMatchmakingPingResponse.VTable m_VTable;

		// Token: 0x04000315 RID: 789
		private IntPtr m_pVTable;

		// Token: 0x04000316 RID: 790
		private GCHandle m_pGCHandle;

		// Token: 0x04000317 RID: 791
		private ISteamMatchmakingPingResponse.ServerResponded m_ServerResponded;

		// Token: 0x04000318 RID: 792
		private ISteamMatchmakingPingResponse.ServerFailedToRespond m_ServerFailedToRespond;

		// Token: 0x02000083 RID: 131
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x04000319 RID: 793
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPingResponse.InternalServerResponded m_VTServerResponded;

			// Token: 0x0400031A RID: 794
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPingResponse.InternalServerFailedToRespond m_VTServerFailedToRespond;
		}

		// Token: 0x02000084 RID: 132
		// (Invoke) Token: 0x060003CA RID: 970
		public delegate void ServerResponded(gameserveritem_t server);

		// Token: 0x02000085 RID: 133
		// (Invoke) Token: 0x060003CE RID: 974
		public delegate void ServerFailedToRespond();

		// Token: 0x02000086 RID: 134
		// (Invoke) Token: 0x060003D2 RID: 978
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerResponded(gameserveritem_t server);

		// Token: 0x02000087 RID: 135
		// (Invoke) Token: 0x060003D6 RID: 982
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate void InternalServerFailedToRespond();
	}
}
