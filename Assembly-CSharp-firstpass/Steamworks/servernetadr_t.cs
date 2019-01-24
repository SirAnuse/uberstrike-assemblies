using System;

namespace Steamworks
{
	// Token: 0x020001B4 RID: 436
	public struct servernetadr_t
	{
		// Token: 0x060009D8 RID: 2520 RVA: 0x00006A4A File Offset: 0x00004C4A
		public void Init(uint ip, ushort usQueryPort, ushort usConnectionPort)
		{
			this.m_unIP = ip;
			this.m_usQueryPort = usQueryPort;
			this.m_usConnectionPort = usConnectionPort;
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x00006A61 File Offset: 0x00004C61
		public ushort GetQueryPort()
		{
			return this.m_usQueryPort;
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00006A69 File Offset: 0x00004C69
		public void SetQueryPort(ushort usPort)
		{
			this.m_usQueryPort = usPort;
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00006A72 File Offset: 0x00004C72
		public ushort GetConnectionPort()
		{
			return this.m_usConnectionPort;
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x00006A7A File Offset: 0x00004C7A
		public void SetConnectionPort(ushort usPort)
		{
			this.m_usConnectionPort = usPort;
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x00006A83 File Offset: 0x00004C83
		public uint GetIP()
		{
			return this.m_unIP;
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x00006A8B File Offset: 0x00004C8B
		public void SetIP(uint unIP)
		{
			this.m_unIP = unIP;
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x00006A94 File Offset: 0x00004C94
		public string GetConnectionAddressString()
		{
			return servernetadr_t.ToString(this.m_unIP, this.m_usConnectionPort);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00006AA7 File Offset: 0x00004CA7
		public string GetQueryAddressString()
		{
			return servernetadr_t.ToString(this.m_unIP, this.m_usQueryPort);
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0000FB74 File Offset: 0x0000DD74
		public static string ToString(uint unIP, ushort usPort)
		{
			return string.Format("{0}.{1}.{2}.{3}:{4}", new object[]
			{
				(ulong)(unIP >> 24) & 255UL,
				(ulong)(unIP >> 16) & 255UL,
				(ulong)(unIP >> 8) & 255UL,
				(ulong)unIP & 255UL,
				usPort
			});
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x00006ABA File Offset: 0x00004CBA
		public override bool Equals(object other)
		{
			return other is servernetadr_t && this == (servernetadr_t)other;
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00006ADB File Offset: 0x00004CDB
		public override int GetHashCode()
		{
			return this.m_unIP.GetHashCode() + this.m_usQueryPort.GetHashCode() + this.m_usConnectionPort.GetHashCode();
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x00006B00 File Offset: 0x00004D00
		public bool Equals(servernetadr_t other)
		{
			return this.m_unIP == other.m_unIP && this.m_usQueryPort == other.m_usQueryPort && this.m_usConnectionPort == other.m_usConnectionPort;
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x00006B38 File Offset: 0x00004D38
		public int CompareTo(servernetadr_t other)
		{
			return this.m_unIP.CompareTo(other.m_unIP) + this.m_usQueryPort.CompareTo(other.m_usQueryPort) + this.m_usConnectionPort.CompareTo(other.m_usConnectionPort);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x00006B72 File Offset: 0x00004D72
		public static bool operator <(servernetadr_t x, servernetadr_t y)
		{
			return x.m_unIP < y.m_unIP || (x.m_unIP == y.m_unIP && x.m_usQueryPort < y.m_usQueryPort);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x00006BB0 File Offset: 0x00004DB0
		public static bool operator >(servernetadr_t x, servernetadr_t y)
		{
			return x.m_unIP > y.m_unIP || (x.m_unIP == y.m_unIP && x.m_usQueryPort > y.m_usQueryPort);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00006BEE File Offset: 0x00004DEE
		public static bool operator ==(servernetadr_t x, servernetadr_t y)
		{
			return x.m_unIP == y.m_unIP && x.m_usQueryPort == y.m_usQueryPort && x.m_usConnectionPort == y.m_usConnectionPort;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00006C29 File Offset: 0x00004E29
		public static bool operator !=(servernetadr_t x, servernetadr_t y)
		{
			return !(x == y);
		}

		// Token: 0x04000914 RID: 2324
		private ushort m_usConnectionPort;

		// Token: 0x04000915 RID: 2325
		private ushort m_usQueryPort;

		// Token: 0x04000916 RID: 2326
		private uint m_unIP;
	}
}
