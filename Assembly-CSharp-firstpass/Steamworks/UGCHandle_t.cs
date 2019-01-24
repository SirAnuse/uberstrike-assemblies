using System;

namespace Steamworks
{
	// Token: 0x020001C9 RID: 457
	public struct UGCHandle_t : IEquatable<UGCHandle_t>, IComparable<UGCHandle_t>
	{
		// Token: 0x06000AE1 RID: 2785 RVA: 0x00007BD7 File Offset: 0x00005DD7
		public UGCHandle_t(ulong value)
		{
			this.m_UGCHandle = value;
		}

		// Token: 0x06000AE3 RID: 2787 RVA: 0x00007BEE File Offset: 0x00005DEE
		public override string ToString()
		{
			return this.m_UGCHandle.ToString();
		}

		// Token: 0x06000AE4 RID: 2788 RVA: 0x00007BFB File Offset: 0x00005DFB
		public override bool Equals(object other)
		{
			return other is UGCHandle_t && this == (UGCHandle_t)other;
		}

		// Token: 0x06000AE5 RID: 2789 RVA: 0x00007C1C File Offset: 0x00005E1C
		public override int GetHashCode()
		{
			return this.m_UGCHandle.GetHashCode();
		}

		// Token: 0x06000AE6 RID: 2790 RVA: 0x00007C29 File Offset: 0x00005E29
		public bool Equals(UGCHandle_t other)
		{
			return this.m_UGCHandle == other.m_UGCHandle;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00007C3A File Offset: 0x00005E3A
		public int CompareTo(UGCHandle_t other)
		{
			return this.m_UGCHandle.CompareTo(other.m_UGCHandle);
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x00007C4E File Offset: 0x00005E4E
		public static bool operator ==(UGCHandle_t x, UGCHandle_t y)
		{
			return x.m_UGCHandle == y.m_UGCHandle;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x00007C60 File Offset: 0x00005E60
		public static bool operator !=(UGCHandle_t x, UGCHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x00007C6C File Offset: 0x00005E6C
		public static explicit operator UGCHandle_t(ulong value)
		{
			return new UGCHandle_t(value);
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00007C74 File Offset: 0x00005E74
		public static explicit operator ulong(UGCHandle_t that)
		{
			return that.m_UGCHandle;
		}

		// Token: 0x04000940 RID: 2368
		public static readonly UGCHandle_t Invalid = new UGCHandle_t(ulong.MaxValue);

		// Token: 0x04000941 RID: 2369
		public ulong m_UGCHandle;
	}
}
