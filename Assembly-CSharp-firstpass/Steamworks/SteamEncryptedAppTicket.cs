using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A2 RID: 162
	public static class SteamEncryptedAppTicket
	{
		// Token: 0x06000440 RID: 1088 RVA: 0x00004210 File Offset: 0x00002410
		public static bool BDecryptTicket(byte[] rgubTicketEncrypted, uint cubTicketEncrypted, byte[] rgubTicketDecrypted, ref uint pcubTicketDecrypted, byte[] rgubKey, int cubKey)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.BDecryptTicket(rgubTicketEncrypted, cubTicketEncrypted, rgubTicketDecrypted, ref pcubTicketDecrypted, rgubKey, cubKey);
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00004224 File Offset: 0x00002424
		public static bool BIsTicketForApp(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, AppId_t nAppID)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.BIsTicketForApp(rgubTicketDecrypted, cubTicketDecrypted, nAppID);
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00004233 File Offset: 0x00002433
		public static uint GetTicketIssueTime(byte[] rgubTicketDecrypted, uint cubTicketDecrypted)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.GetTicketIssueTime(rgubTicketDecrypted, cubTicketDecrypted);
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00004241 File Offset: 0x00002441
		public static void GetTicketSteamID(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, out CSteamID psteamID)
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.GetTicketSteamID(rgubTicketDecrypted, cubTicketDecrypted, out psteamID);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00004250 File Offset: 0x00002450
		public static uint GetTicketAppID(byte[] rgubTicketDecrypted, uint cubTicketDecrypted)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.GetTicketAppID(rgubTicketDecrypted, cubTicketDecrypted);
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0000425E File Offset: 0x0000245E
		public static bool BUserOwnsAppInTicket(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, AppId_t nAppID)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.BUserOwnsAppInTicket(rgubTicketDecrypted, cubTicketDecrypted, nAppID);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x0000426D File Offset: 0x0000246D
		public static bool BUserIsVacBanned(byte[] rgubTicketDecrypted, uint cubTicketDecrypted)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.BUserIsVacBanned(rgubTicketDecrypted, cubTicketDecrypted);
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0000F698 File Offset: 0x0000D898
		public static byte[] GetUserVariableData(byte[] rgubTicketDecrypted, uint cubTicketDecrypted, out uint pcubUserData)
		{
			InteropHelp.TestIfPlatformSupported();
			IntPtr userVariableData = NativeMethods.GetUserVariableData(rgubTicketDecrypted, cubTicketDecrypted, out pcubUserData);
			byte[] array = new byte[pcubUserData];
			Marshal.Copy(userVariableData, array, 0, (int)pcubUserData);
			return array;
		}
	}
}
