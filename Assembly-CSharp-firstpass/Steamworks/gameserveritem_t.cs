using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x020001B3 RID: 435
	[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 372)]
	public class gameserveritem_t
	{
		// Token: 0x060009CE RID: 2510 RVA: 0x00006900 File Offset: 0x00004B00
		public string GetGameDir()
		{
			return Encoding.UTF8.GetString(this.m_szGameDir, 0, Array.IndexOf<byte>(this.m_szGameDir, 0));
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0000691F File Offset: 0x00004B1F
		public void SetGameDir(string dir)
		{
			this.m_szGameDir = Encoding.UTF8.GetBytes(dir + '\0');
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0000693D File Offset: 0x00004B3D
		public string GetMap()
		{
			return Encoding.UTF8.GetString(this.m_szMap, 0, Array.IndexOf<byte>(this.m_szMap, 0));
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0000695C File Offset: 0x00004B5C
		public void SetMap(string map)
		{
			this.m_szMap = Encoding.UTF8.GetBytes(map + '\0');
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0000697A File Offset: 0x00004B7A
		public string GetGameDescription()
		{
			return Encoding.UTF8.GetString(this.m_szGameDescription, 0, Array.IndexOf<byte>(this.m_szGameDescription, 0));
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x00006999 File Offset: 0x00004B99
		public void SetGameDescription(string desc)
		{
			this.m_szGameDescription = Encoding.UTF8.GetBytes(desc + '\0');
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x000069B7 File Offset: 0x00004BB7
		public string GetServerName()
		{
			if (this.m_szServerName[0] == 0)
			{
				return this.m_NetAdr.GetConnectionAddressString();
			}
			return Encoding.UTF8.GetString(this.m_szServerName, 0, Array.IndexOf<byte>(this.m_szServerName, 0));
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x000069EF File Offset: 0x00004BEF
		public void SetServerName(string name)
		{
			this.m_szServerName = Encoding.UTF8.GetBytes(name + '\0');
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x00006A0D File Offset: 0x00004C0D
		public string GetGameTags()
		{
			return Encoding.UTF8.GetString(this.m_szGameTags, 0, Array.IndexOf<byte>(this.m_szGameTags, 0));
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x00006A2C File Offset: 0x00004C2C
		public void SetGameTags(string tags)
		{
			this.m_szGameTags = Encoding.UTF8.GetBytes(tags + '\0');
		}

		// Token: 0x04000902 RID: 2306
		public servernetadr_t m_NetAdr;

		// Token: 0x04000903 RID: 2307
		public int m_nPing;

		// Token: 0x04000904 RID: 2308
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bHadSuccessfulResponse;

		// Token: 0x04000905 RID: 2309
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bDoNotRefresh;

		// Token: 0x04000906 RID: 2310
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private byte[] m_szGameDir;

		// Token: 0x04000907 RID: 2311
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private byte[] m_szMap;

		// Token: 0x04000908 RID: 2312
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		private byte[] m_szGameDescription;

		// Token: 0x04000909 RID: 2313
		public uint m_nAppID;

		// Token: 0x0400090A RID: 2314
		public int m_nPlayers;

		// Token: 0x0400090B RID: 2315
		public int m_nMaxPlayers;

		// Token: 0x0400090C RID: 2316
		public int m_nBotPlayers;

		// Token: 0x0400090D RID: 2317
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bPassword;

		// Token: 0x0400090E RID: 2318
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSecure;

		// Token: 0x0400090F RID: 2319
		public uint m_ulTimeLastPlayed;

		// Token: 0x04000910 RID: 2320
		public int m_nServerVersion;

		// Token: 0x04000911 RID: 2321
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		private byte[] m_szServerName;

		// Token: 0x04000912 RID: 2322
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		private byte[] m_szGameTags;

		// Token: 0x04000913 RID: 2323
		public CSteamID m_steamID;
	}
}
