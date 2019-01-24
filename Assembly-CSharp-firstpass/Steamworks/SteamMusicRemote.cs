using System;

namespace Steamworks
{
	// Token: 0x020001A9 RID: 425
	public static class SteamMusicRemote
	{
		// Token: 0x060008DA RID: 2266 RVA: 0x00005AEE File Offset: 0x00003CEE
		public static bool RegisterSteamMusicRemote(string pchName)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_RegisterSteamMusicRemote(pchName);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00005AFB File Offset: 0x00003CFB
		public static bool DeregisterSteamMusicRemote()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_DeregisterSteamMusicRemote();
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00005B07 File Offset: 0x00003D07
		public static bool BIsCurrentMusicRemote()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_BIsCurrentMusicRemote();
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00005B13 File Offset: 0x00003D13
		public static bool BActivationSuccess(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_BActivationSuccess(bValue);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00005B20 File Offset: 0x00003D20
		public static bool SetDisplayName(string pchDisplayName)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_SetDisplayName(pchDisplayName);
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00005B2D File Offset: 0x00003D2D
		public static bool SetPNGIcon_64x64(byte[] pvBuffer, uint cbBufferLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_SetPNGIcon_64x64(pvBuffer, cbBufferLength);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00005B3B File Offset: 0x00003D3B
		public static bool EnablePlayPrevious(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnablePlayPrevious(bValue);
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00005B48 File Offset: 0x00003D48
		public static bool EnablePlayNext(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnablePlayNext(bValue);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00005B55 File Offset: 0x00003D55
		public static bool EnableShuffled(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnableShuffled(bValue);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00005B62 File Offset: 0x00003D62
		public static bool EnableLooped(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnableLooped(bValue);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00005B6F File Offset: 0x00003D6F
		public static bool EnableQueue(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnableQueue(bValue);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00005B7C File Offset: 0x00003D7C
		public static bool EnablePlaylists(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_EnablePlaylists(bValue);
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00005B89 File Offset: 0x00003D89
		public static bool UpdatePlaybackStatus(AudioPlayback_Status nStatus)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdatePlaybackStatus(nStatus);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00005B96 File Offset: 0x00003D96
		public static bool UpdateShuffled(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateShuffled(bValue);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00005BA3 File Offset: 0x00003DA3
		public static bool UpdateLooped(bool bValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateLooped(bValue);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00005BB0 File Offset: 0x00003DB0
		public static bool UpdateVolume(float flValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateVolume(flValue);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00005BBD File Offset: 0x00003DBD
		public static bool CurrentEntryWillChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_CurrentEntryWillChange();
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00005BC9 File Offset: 0x00003DC9
		public static bool CurrentEntryIsAvailable(bool bAvailable)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_CurrentEntryIsAvailable(bAvailable);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00005BD6 File Offset: 0x00003DD6
		public static bool UpdateCurrentEntryText(string pchText)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateCurrentEntryText(pchText);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00005BE3 File Offset: 0x00003DE3
		public static bool UpdateCurrentEntryElapsedSeconds(int nValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds(nValue);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00005BF0 File Offset: 0x00003DF0
		public static bool UpdateCurrentEntryCoverArt(byte[] pvBuffer, uint cbBufferLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_UpdateCurrentEntryCoverArt(pvBuffer, cbBufferLength);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00005BFE File Offset: 0x00003DFE
		public static bool CurrentEntryDidChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_CurrentEntryDidChange();
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x00005C0A File Offset: 0x00003E0A
		public static bool QueueWillChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_QueueWillChange();
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00005C16 File Offset: 0x00003E16
		public static bool ResetQueueEntries()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_ResetQueueEntries();
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x00005C22 File Offset: 0x00003E22
		public static bool SetQueueEntry(int nID, int nPosition, string pchEntryText)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_SetQueueEntry(nID, nPosition, pchEntryText);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00005C31 File Offset: 0x00003E31
		public static bool SetCurrentQueueEntry(int nID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_SetCurrentQueueEntry(nID);
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00005C3E File Offset: 0x00003E3E
		public static bool QueueDidChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_QueueDidChange();
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00005C4A File Offset: 0x00003E4A
		public static bool PlaylistWillChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_PlaylistWillChange();
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00005C56 File Offset: 0x00003E56
		public static bool ResetPlaylistEntries()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_ResetPlaylistEntries();
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00005C62 File Offset: 0x00003E62
		public static bool SetPlaylistEntry(int nID, int nPosition, string pchEntryText)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_SetPlaylistEntry(nID, nPosition, pchEntryText);
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00005C71 File Offset: 0x00003E71
		public static bool SetCurrentPlaylistEntry(int nID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_SetCurrentPlaylistEntry(nID);
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00005C7E File Offset: 0x00003E7E
		public static bool PlaylistDidChange()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusicRemote_PlaylistDidChange();
		}
	}
}
