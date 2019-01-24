using System;

namespace Steamworks
{
	// Token: 0x020001BF RID: 447
	public struct SteamInventoryResult_t : IEquatable<SteamInventoryResult_t>, IComparable<SteamInventoryResult_t>
	{
		// Token: 0x06000A77 RID: 2679 RVA: 0x00007592 File Offset: 0x00005792
		public SteamInventoryResult_t(int value)
		{
			this.m_SteamInventoryResult_t = value;
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x000075A8 File Offset: 0x000057A8
		public override string ToString()
		{
			return this.m_SteamInventoryResult_t.ToString();
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x000075B5 File Offset: 0x000057B5
		public override bool Equals(object other)
		{
			return other is SteamInventoryResult_t && this == (SteamInventoryResult_t)other;
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x000075D6 File Offset: 0x000057D6
		public override int GetHashCode()
		{
			return this.m_SteamInventoryResult_t.GetHashCode();
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x000075E3 File Offset: 0x000057E3
		public bool Equals(SteamInventoryResult_t other)
		{
			return this.m_SteamInventoryResult_t == other.m_SteamInventoryResult_t;
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x000075F4 File Offset: 0x000057F4
		public int CompareTo(SteamInventoryResult_t other)
		{
			return this.m_SteamInventoryResult_t.CompareTo(other.m_SteamInventoryResult_t);
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x00007608 File Offset: 0x00005808
		public static bool operator ==(SteamInventoryResult_t x, SteamInventoryResult_t y)
		{
			return x.m_SteamInventoryResult_t == y.m_SteamInventoryResult_t;
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x0000761A File Offset: 0x0000581A
		public static bool operator !=(SteamInventoryResult_t x, SteamInventoryResult_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00007626 File Offset: 0x00005826
		public static explicit operator SteamInventoryResult_t(int value)
		{
			return new SteamInventoryResult_t(value);
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x0000762E File Offset: 0x0000582E
		public static explicit operator int(SteamInventoryResult_t that)
		{
			return that.m_SteamInventoryResult_t;
		}

		// Token: 0x0400092F RID: 2351
		public static readonly SteamInventoryResult_t Invalid = new SteamInventoryResult_t(-1);

		// Token: 0x04000930 RID: 2352
		public int m_SteamInventoryResult_t;
	}
}
