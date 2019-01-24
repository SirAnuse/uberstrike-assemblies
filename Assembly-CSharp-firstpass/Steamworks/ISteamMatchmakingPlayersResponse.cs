using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000088 RID: 136
	public class ISteamMatchmakingPlayersResponse
	{
		// Token: 0x060003D9 RID: 985 RVA: 0x0000EEEC File Offset: 0x0000D0EC
		public ISteamMatchmakingPlayersResponse(ISteamMatchmakingPlayersResponse.AddPlayerToList onAddPlayerToList, ISteamMatchmakingPlayersResponse.PlayersFailedToRespond onPlayersFailedToRespond, ISteamMatchmakingPlayersResponse.PlayersRefreshComplete onPlayersRefreshComplete)
		{
			if (onAddPlayerToList == null || onPlayersFailedToRespond == null || onPlayersRefreshComplete == null)
			{
				throw new ArgumentNullException();
			}
			this.m_AddPlayerToList = onAddPlayerToList;
			this.m_PlayersFailedToRespond = onPlayersFailedToRespond;
			this.m_PlayersRefreshComplete = onPlayersRefreshComplete;
			this.m_VTable = new ISteamMatchmakingPlayersResponse.VTable
			{
				m_VTAddPlayerToList = new ISteamMatchmakingPlayersResponse.InternalAddPlayerToList(this.InternalOnAddPlayerToList),
				m_VTPlayersFailedToRespond = new ISteamMatchmakingPlayersResponse.InternalPlayersFailedToRespond(this.InternalOnPlayersFailedToRespond),
				m_VTPlayersRefreshComplete = new ISteamMatchmakingPlayersResponse.InternalPlayersRefreshComplete(this.InternalOnPlayersRefreshComplete)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ISteamMatchmakingPlayersResponse.VTable)));
			Marshal.StructureToPtr(this.m_VTable, this.m_pVTable, false);
			this.m_pGCHandle = GCHandle.Alloc(this.m_pVTable, GCHandleType.Pinned);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000EFB4 File Offset: 0x0000D1B4
		~ISteamMatchmakingPlayersResponse()
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

		// Token: 0x060003DB RID: 987 RVA: 0x00004007 File Offset: 0x00002207
		private void InternalOnAddPlayerToList(string pchName, int nScore, float flTimePlayed)
		{
			this.m_AddPlayerToList(pchName, nScore, flTimePlayed);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00004017 File Offset: 0x00002217
		private void InternalOnPlayersFailedToRespond()
		{
			this.m_PlayersFailedToRespond();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00004024 File Offset: 0x00002224
		private void InternalOnPlayersRefreshComplete()
		{
			this.m_PlayersRefreshComplete();
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00004031 File Offset: 0x00002231
		public static explicit operator IntPtr(ISteamMatchmakingPlayersResponse that)
		{
			return that.m_pGCHandle.AddrOfPinnedObject();
		}

		// Token: 0x0400031B RID: 795
		private ISteamMatchmakingPlayersResponse.VTable m_VTable;

		// Token: 0x0400031C RID: 796
		private IntPtr m_pVTable;

		// Token: 0x0400031D RID: 797
		private GCHandle m_pGCHandle;

		// Token: 0x0400031E RID: 798
		private ISteamMatchmakingPlayersResponse.AddPlayerToList m_AddPlayerToList;

		// Token: 0x0400031F RID: 799
		private ISteamMatchmakingPlayersResponse.PlayersFailedToRespond m_PlayersFailedToRespond;

		// Token: 0x04000320 RID: 800
		private ISteamMatchmakingPlayersResponse.PlayersRefreshComplete m_PlayersRefreshComplete;

		// Token: 0x02000089 RID: 137
		[StructLayout(LayoutKind.Sequential)]
		private class VTable
		{
			// Token: 0x04000321 RID: 801
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPlayersResponse.InternalAddPlayerToList m_VTAddPlayerToList;

			// Token: 0x04000322 RID: 802
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPlayersResponse.InternalPlayersFailedToRespond m_VTPlayersFailedToRespond;

			// Token: 0x04000323 RID: 803
			[NonSerialized]
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public ISteamMatchmakingPlayersResponse.InternalPlayersRefreshComplete m_VTPlayersRefreshComplete;
		}

		// Token: 0x0200008A RID: 138
		// (Invoke) Token: 0x060003E1 RID: 993
		public delegate void AddPlayerToList([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, int nScore, float flTimePlayed);

		// Token: 0x0200008B RID: 139
		// (Invoke) Token: 0x060003E5 RID: 997
		public delegate void PlayersFailedToRespond();

		// Token: 0x0200008C RID: 140
		// (Invoke) Token: 0x060003E9 RID: 1001
		public delegate void PlayersRefreshComplete();

		// Token: 0x0200008D RID: 141
		// (Invoke) Token: 0x060003ED RID: 1005
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalAddPlayerToList([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, int nScore, float flTimePlayed);

		// Token: 0x0200008E RID: 142
		// (Invoke) Token: 0x060003F1 RID: 1009
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalPlayersFailedToRespond();

		// Token: 0x0200008F RID: 143
		// (Invoke) Token: 0x060003F5 RID: 1013
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void InternalPlayersRefreshComplete();
	}
}
