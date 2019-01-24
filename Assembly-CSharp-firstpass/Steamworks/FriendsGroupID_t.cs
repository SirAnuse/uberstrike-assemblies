using System;

namespace Steamworks
{
	// Token: 0x020001BB RID: 443
	public struct FriendsGroupID_t : IEquatable<FriendsGroupID_t>, IComparable<FriendsGroupID_t>
	{
		// Token: 0x06000A4B RID: 2635 RVA: 0x000072FE File Offset: 0x000054FE
		public FriendsGroupID_t(short value)
		{
			this.m_FriendsGroupID_t = value;
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x00007314 File Offset: 0x00005514
		public override string ToString()
		{
			return this.m_FriendsGroupID_t.ToString();
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00007321 File Offset: 0x00005521
		public override bool Equals(object other)
		{
			return other is FriendsGroupID_t && this == (FriendsGroupID_t)other;
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x00007342 File Offset: 0x00005542
		public override int GetHashCode()
		{
			return this.m_FriendsGroupID_t.GetHashCode();
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0000734F File Offset: 0x0000554F
		public bool Equals(FriendsGroupID_t other)
		{
			return this.m_FriendsGroupID_t == other.m_FriendsGroupID_t;
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00007360 File Offset: 0x00005560
		public int CompareTo(FriendsGroupID_t other)
		{
			return this.m_FriendsGroupID_t.CompareTo(other.m_FriendsGroupID_t);
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x00007374 File Offset: 0x00005574
		public static bool operator ==(FriendsGroupID_t x, FriendsGroupID_t y)
		{
			return x.m_FriendsGroupID_t == y.m_FriendsGroupID_t;
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x00007386 File Offset: 0x00005586
		public static bool operator !=(FriendsGroupID_t x, FriendsGroupID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000A54 RID: 2644 RVA: 0x00007392 File Offset: 0x00005592
		public static explicit operator FriendsGroupID_t(short value)
		{
			return new FriendsGroupID_t(value);
		}

		// Token: 0x06000A55 RID: 2645 RVA: 0x0000739A File Offset: 0x0000559A
		public static explicit operator short(FriendsGroupID_t that)
		{
			return that.m_FriendsGroupID_t;
		}

		// Token: 0x04000927 RID: 2343
		public static readonly FriendsGroupID_t Invalid = new FriendsGroupID_t(-1);

		// Token: 0x04000928 RID: 2344
		public short m_FriendsGroupID_t;
	}
}
