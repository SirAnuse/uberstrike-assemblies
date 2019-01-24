using System;

namespace Steamworks
{
	// Token: 0x020001D4 RID: 468
	public struct SteamLeaderboard_t : IEquatable<SteamLeaderboard_t>, IComparable<SteamLeaderboard_t>
	{
		// Token: 0x06000B58 RID: 2904 RVA: 0x000082DA File Offset: 0x000064DA
		public SteamLeaderboard_t(ulong value)
		{
			this.m_SteamLeaderboard = value;
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x000082E3 File Offset: 0x000064E3
		public override string ToString()
		{
			return this.m_SteamLeaderboard.ToString();
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x000082F0 File Offset: 0x000064F0
		public override bool Equals(object other)
		{
			return other is SteamLeaderboard_t && this == (SteamLeaderboard_t)other;
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x00008311 File Offset: 0x00006511
		public override int GetHashCode()
		{
			return this.m_SteamLeaderboard.GetHashCode();
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x0000831E File Offset: 0x0000651E
		public bool Equals(SteamLeaderboard_t other)
		{
			return this.m_SteamLeaderboard == other.m_SteamLeaderboard;
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0000832F File Offset: 0x0000652F
		public int CompareTo(SteamLeaderboard_t other)
		{
			return this.m_SteamLeaderboard.CompareTo(other.m_SteamLeaderboard);
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x00008343 File Offset: 0x00006543
		public static bool operator ==(SteamLeaderboard_t x, SteamLeaderboard_t y)
		{
			return x.m_SteamLeaderboard == y.m_SteamLeaderboard;
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x00008355 File Offset: 0x00006555
		public static bool operator !=(SteamLeaderboard_t x, SteamLeaderboard_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x00008361 File Offset: 0x00006561
		public static explicit operator SteamLeaderboard_t(ulong value)
		{
			return new SteamLeaderboard_t(value);
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x00008369 File Offset: 0x00006569
		public static explicit operator ulong(SteamLeaderboard_t that)
		{
			return that.m_SteamLeaderboard;
		}

		// Token: 0x04000954 RID: 2388
		public ulong m_SteamLeaderboard;
	}
}
