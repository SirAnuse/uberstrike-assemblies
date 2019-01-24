using System;

namespace Steamworks
{
	// Token: 0x020001C0 RID: 448
	public struct SteamItemDef_t : IEquatable<SteamItemDef_t>, IComparable<SteamItemDef_t>
	{
		// Token: 0x06000A82 RID: 2690 RVA: 0x00007637 File Offset: 0x00005837
		public SteamItemDef_t(int value)
		{
			this.m_SteamItemDef_t = value;
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x00007640 File Offset: 0x00005840
		public override string ToString()
		{
			return this.m_SteamItemDef_t.ToString();
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0000764D File Offset: 0x0000584D
		public override bool Equals(object other)
		{
			return other is SteamItemDef_t && this == (SteamItemDef_t)other;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x0000766E File Offset: 0x0000586E
		public override int GetHashCode()
		{
			return this.m_SteamItemDef_t.GetHashCode();
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x0000767B File Offset: 0x0000587B
		public bool Equals(SteamItemDef_t other)
		{
			return this.m_SteamItemDef_t == other.m_SteamItemDef_t;
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x0000768C File Offset: 0x0000588C
		public int CompareTo(SteamItemDef_t other)
		{
			return this.m_SteamItemDef_t.CompareTo(other.m_SteamItemDef_t);
		}

		// Token: 0x06000A88 RID: 2696 RVA: 0x000076A0 File Offset: 0x000058A0
		public static bool operator ==(SteamItemDef_t x, SteamItemDef_t y)
		{
			return x.m_SteamItemDef_t == y.m_SteamItemDef_t;
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x000076B2 File Offset: 0x000058B2
		public static bool operator !=(SteamItemDef_t x, SteamItemDef_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x000076BE File Offset: 0x000058BE
		public static explicit operator SteamItemDef_t(int value)
		{
			return new SteamItemDef_t(value);
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x000076C6 File Offset: 0x000058C6
		public static explicit operator int(SteamItemDef_t that)
		{
			return that.m_SteamItemDef_t;
		}

		// Token: 0x04000931 RID: 2353
		public int m_SteamItemDef_t;
	}
}
