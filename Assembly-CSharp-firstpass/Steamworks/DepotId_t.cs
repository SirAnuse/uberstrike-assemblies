using System;

namespace Steamworks
{
	// Token: 0x020001CD RID: 461
	public struct DepotId_t : IEquatable<DepotId_t>, IComparable<DepotId_t>
	{
		// Token: 0x06000B0C RID: 2828 RVA: 0x00007E5F File Offset: 0x0000605F
		public DepotId_t(uint value)
		{
			this.m_DepotId = value;
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x00007E75 File Offset: 0x00006075
		public override string ToString()
		{
			return this.m_DepotId.ToString();
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x00007E82 File Offset: 0x00006082
		public override bool Equals(object other)
		{
			return other is DepotId_t && this == (DepotId_t)other;
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x00007EA3 File Offset: 0x000060A3
		public override int GetHashCode()
		{
			return this.m_DepotId.GetHashCode();
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x00007EB0 File Offset: 0x000060B0
		public bool Equals(DepotId_t other)
		{
			return this.m_DepotId == other.m_DepotId;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x00007EC1 File Offset: 0x000060C1
		public int CompareTo(DepotId_t other)
		{
			return this.m_DepotId.CompareTo(other.m_DepotId);
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x00007ED5 File Offset: 0x000060D5
		public static bool operator ==(DepotId_t x, DepotId_t y)
		{
			return x.m_DepotId == y.m_DepotId;
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x00007EE7 File Offset: 0x000060E7
		public static bool operator !=(DepotId_t x, DepotId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x00007EF3 File Offset: 0x000060F3
		public static explicit operator DepotId_t(uint value)
		{
			return new DepotId_t(value);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x00007EFB File Offset: 0x000060FB
		public static explicit operator uint(DepotId_t that)
		{
			return that.m_DepotId;
		}

		// Token: 0x04000947 RID: 2375
		public static readonly DepotId_t Invalid = new DepotId_t(0u);

		// Token: 0x04000948 RID: 2376
		public uint m_DepotId;
	}
}
