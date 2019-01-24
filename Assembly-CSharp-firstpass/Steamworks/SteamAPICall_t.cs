using System;

namespace Steamworks
{
	// Token: 0x020001CF RID: 463
	public struct SteamAPICall_t : IEquatable<SteamAPICall_t>, IComparable<SteamAPICall_t>
	{
		// Token: 0x06000B22 RID: 2850 RVA: 0x00007FAA File Offset: 0x000061AA
		public SteamAPICall_t(ulong value)
		{
			this.m_SteamAPICall = value;
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00007FC1 File Offset: 0x000061C1
		public override string ToString()
		{
			return this.m_SteamAPICall.ToString();
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x00007FCE File Offset: 0x000061CE
		public override bool Equals(object other)
		{
			return other is SteamAPICall_t && this == (SteamAPICall_t)other;
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x00007FEF File Offset: 0x000061EF
		public override int GetHashCode()
		{
			return this.m_SteamAPICall.GetHashCode();
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x00007FFC File Offset: 0x000061FC
		public bool Equals(SteamAPICall_t other)
		{
			return this.m_SteamAPICall == other.m_SteamAPICall;
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0000800D File Offset: 0x0000620D
		public int CompareTo(SteamAPICall_t other)
		{
			return this.m_SteamAPICall.CompareTo(other.m_SteamAPICall);
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x00008021 File Offset: 0x00006221
		public static bool operator ==(SteamAPICall_t x, SteamAPICall_t y)
		{
			return x.m_SteamAPICall == y.m_SteamAPICall;
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x00008033 File Offset: 0x00006233
		public static bool operator !=(SteamAPICall_t x, SteamAPICall_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0000803F File Offset: 0x0000623F
		public static explicit operator SteamAPICall_t(ulong value)
		{
			return new SteamAPICall_t(value);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x00008047 File Offset: 0x00006247
		public static explicit operator ulong(SteamAPICall_t that)
		{
			return that.m_SteamAPICall;
		}

		// Token: 0x0400094B RID: 2379
		public static readonly SteamAPICall_t Invalid = new SteamAPICall_t(0UL);

		// Token: 0x0400094C RID: 2380
		public ulong m_SteamAPICall;
	}
}
