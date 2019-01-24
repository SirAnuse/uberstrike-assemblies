using System;

namespace Steamworks
{
	// Token: 0x020001BA RID: 442
	public struct HAuthTicket : IEquatable<HAuthTicket>, IComparable<HAuthTicket>
	{
		// Token: 0x06000A40 RID: 2624 RVA: 0x00007259 File Offset: 0x00005459
		public HAuthTicket(uint value)
		{
			this.m_HAuthTicket = value;
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x0000726F File Offset: 0x0000546F
		public override string ToString()
		{
			return this.m_HAuthTicket.ToString();
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x0000727C File Offset: 0x0000547C
		public override bool Equals(object other)
		{
			return other is HAuthTicket && this == (HAuthTicket)other;
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0000729D File Offset: 0x0000549D
		public override int GetHashCode()
		{
			return this.m_HAuthTicket.GetHashCode();
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x000072AA File Offset: 0x000054AA
		public bool Equals(HAuthTicket other)
		{
			return this.m_HAuthTicket == other.m_HAuthTicket;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x000072BB File Offset: 0x000054BB
		public int CompareTo(HAuthTicket other)
		{
			return this.m_HAuthTicket.CompareTo(other.m_HAuthTicket);
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x000072CF File Offset: 0x000054CF
		public static bool operator ==(HAuthTicket x, HAuthTicket y)
		{
			return x.m_HAuthTicket == y.m_HAuthTicket;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x000072E1 File Offset: 0x000054E1
		public static bool operator !=(HAuthTicket x, HAuthTicket y)
		{
			return !(x == y);
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x000072ED File Offset: 0x000054ED
		public static explicit operator HAuthTicket(uint value)
		{
			return new HAuthTicket(value);
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x000072F5 File Offset: 0x000054F5
		public static explicit operator uint(HAuthTicket that)
		{
			return that.m_HAuthTicket;
		}

		// Token: 0x04000925 RID: 2341
		public static readonly HAuthTicket Invalid = new HAuthTicket(0u);

		// Token: 0x04000926 RID: 2342
		public uint m_HAuthTicket;
	}
}
