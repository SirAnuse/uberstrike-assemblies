using System;

namespace Steamworks
{
	// Token: 0x020001A8 RID: 424
	public static class SteamMusic
	{
		// Token: 0x060008D1 RID: 2257 RVA: 0x00005A81 File Offset: 0x00003C81
		public static bool BIsEnabled()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_BIsEnabled();
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00005A8D File Offset: 0x00003C8D
		public static bool BIsPlaying()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_BIsPlaying();
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00005A99 File Offset: 0x00003C99
		public static AudioPlayback_Status GetPlaybackStatus()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_GetPlaybackStatus();
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00005AA5 File Offset: 0x00003CA5
		public static void Play()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_Play();
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00005AB1 File Offset: 0x00003CB1
		public static void Pause()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_Pause();
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00005ABD File Offset: 0x00003CBD
		public static void PlayPrevious()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_PlayPrevious();
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00005AC9 File Offset: 0x00003CC9
		public static void PlayNext()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_PlayNext();
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00005AD5 File Offset: 0x00003CD5
		public static void SetVolume(float flVolume)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMusic_SetVolume(flVolume);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x00005AE2 File Offset: 0x00003CE2
		public static float GetVolume()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMusic_GetVolume();
		}
	}
}
