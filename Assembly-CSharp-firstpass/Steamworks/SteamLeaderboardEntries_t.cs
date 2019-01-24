using System;

namespace Steamworks
{
	// Token: 0x020001D3 RID: 467
	public struct SteamLeaderboardEntries_t : IEquatable<SteamLeaderboardEntries_t>, IComparable<SteamLeaderboardEntries_t>
	{
		// Token: 0x06000B4E RID: 2894 RVA: 0x00008242 File Offset: 0x00006442
		public SteamLeaderboardEntries_t(ulong value)
		{
			this.m_SteamLeaderboardEntries = value;
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0000824B File Offset: 0x0000644B
		public override string ToString()
		{
			return this.m_SteamLeaderboardEntries.ToString();
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x00008258 File Offset: 0x00006458
		public override bool Equals(object other)
		{
			return other is SteamLeaderboardEntries_t && this == (SteamLeaderboardEntries_t)other;
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x00008279 File Offset: 0x00006479
		public override int GetHashCode()
		{
			return this.m_SteamLeaderboardEntries.GetHashCode();
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x00008286 File Offset: 0x00006486
		public bool Equals(SteamLeaderboardEntries_t other)
		{
			return this.m_SteamLeaderboardEntries == other.m_SteamLeaderboardEntries;
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x00008297 File Offset: 0x00006497
		public int CompareTo(SteamLeaderboardEntries_t other)
		{
			return this.m_SteamLeaderboardEntries.CompareTo(other.m_SteamLeaderboardEntries);
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x000082AB File Offset: 0x000064AB
		public static bool operator ==(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y)
		{
			return x.m_SteamLeaderboardEntries == y.m_SteamLeaderboardEntries;
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x000082BD File Offset: 0x000064BD
		public static bool operator !=(SteamLeaderboardEntries_t x, SteamLeaderboardEntries_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x000082C9 File Offset: 0x000064C9
		public static explicit operator SteamLeaderboardEntries_t(ulong value)
		{
			return new SteamLeaderboardEntries_t(value);
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x000082D1 File Offset: 0x000064D1
		public static explicit operator ulong(SteamLeaderboardEntries_t that)
		{
			return that.m_SteamLeaderboardEntries;
		}

		// Token: 0x04000953 RID: 2387
		public ulong m_SteamLeaderboardEntries;
	}
}
