using System;

namespace Steamworks
{
	// Token: 0x020001CE RID: 462
	public struct ManifestId_t : IEquatable<ManifestId_t>, IComparable<ManifestId_t>
	{
		// Token: 0x06000B17 RID: 2839 RVA: 0x00007F04 File Offset: 0x00006104
		public ManifestId_t(ulong value)
		{
			this.m_SteamAPICall = value;
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x00007F1B File Offset: 0x0000611B
		public override string ToString()
		{
			return this.m_SteamAPICall.ToString();
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x00007F28 File Offset: 0x00006128
		public override bool Equals(object other)
		{
			return other is ManifestId_t && this == (ManifestId_t)other;
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x00007F49 File Offset: 0x00006149
		public override int GetHashCode()
		{
			return this.m_SteamAPICall.GetHashCode();
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x00007F56 File Offset: 0x00006156
		public bool Equals(ManifestId_t other)
		{
			return this.m_SteamAPICall == other.m_SteamAPICall;
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x00007F67 File Offset: 0x00006167
		public int CompareTo(ManifestId_t other)
		{
			return this.m_SteamAPICall.CompareTo(other.m_SteamAPICall);
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x00007F7B File Offset: 0x0000617B
		public static bool operator ==(ManifestId_t x, ManifestId_t y)
		{
			return x.m_SteamAPICall == y.m_SteamAPICall;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x00007F8D File Offset: 0x0000618D
		public static bool operator !=(ManifestId_t x, ManifestId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x00007F99 File Offset: 0x00006199
		public static explicit operator ManifestId_t(ulong value)
		{
			return new ManifestId_t(value);
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00007FA1 File Offset: 0x000061A1
		public static explicit operator ulong(ManifestId_t that)
		{
			return that.m_SteamAPICall;
		}

		// Token: 0x04000949 RID: 2377
		public static readonly ManifestId_t Invalid = new ManifestId_t(0UL);

		// Token: 0x0400094A RID: 2378
		public ulong m_SteamAPICall;
	}
}
