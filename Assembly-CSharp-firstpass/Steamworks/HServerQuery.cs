using System;

namespace Steamworks
{
	// Token: 0x020001C3 RID: 451
	public struct HServerQuery : IEquatable<HServerQuery>, IComparable<HServerQuery>
	{
		// Token: 0x06000AA1 RID: 2721 RVA: 0x00007810 File Offset: 0x00005A10
		public HServerQuery(int value)
		{
			this.m_HServerQuery = value;
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x00007826 File Offset: 0x00005A26
		public override string ToString()
		{
			return this.m_HServerQuery.ToString();
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x00007833 File Offset: 0x00005A33
		public override bool Equals(object other)
		{
			return other is HServerQuery && this == (HServerQuery)other;
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00007854 File Offset: 0x00005A54
		public override int GetHashCode()
		{
			return this.m_HServerQuery.GetHashCode();
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00007861 File Offset: 0x00005A61
		public bool Equals(HServerQuery other)
		{
			return this.m_HServerQuery == other.m_HServerQuery;
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00007872 File Offset: 0x00005A72
		public int CompareTo(HServerQuery other)
		{
			return this.m_HServerQuery.CompareTo(other.m_HServerQuery);
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x00007886 File Offset: 0x00005A86
		public static bool operator ==(HServerQuery x, HServerQuery y)
		{
			return x.m_HServerQuery == y.m_HServerQuery;
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x00007898 File Offset: 0x00005A98
		public static bool operator !=(HServerQuery x, HServerQuery y)
		{
			return !(x == y);
		}

		// Token: 0x06000AAA RID: 2730 RVA: 0x000078A4 File Offset: 0x00005AA4
		public static explicit operator HServerQuery(int value)
		{
			return new HServerQuery(value);
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x000078AC File Offset: 0x00005AAC
		public static explicit operator int(HServerQuery that)
		{
			return that.m_HServerQuery;
		}

		// Token: 0x04000936 RID: 2358
		public static readonly HServerQuery Invalid = new HServerQuery(-1);

		// Token: 0x04000937 RID: 2359
		public int m_HServerQuery;
	}
}
