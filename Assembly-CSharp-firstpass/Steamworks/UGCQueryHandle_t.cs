using System;

namespace Steamworks
{
	// Token: 0x020001D0 RID: 464
	public struct UGCQueryHandle_t : IEquatable<UGCQueryHandle_t>, IComparable<UGCQueryHandle_t>
	{
		// Token: 0x06000B2D RID: 2861 RVA: 0x00008050 File Offset: 0x00006250
		public UGCQueryHandle_t(ulong value)
		{
			this.m_UGCQueryHandle = value;
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x00008067 File Offset: 0x00006267
		public override string ToString()
		{
			return this.m_UGCQueryHandle.ToString();
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x00008074 File Offset: 0x00006274
		public override bool Equals(object other)
		{
			return other is UGCQueryHandle_t && this == (UGCQueryHandle_t)other;
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x00008095 File Offset: 0x00006295
		public override int GetHashCode()
		{
			return this.m_UGCQueryHandle.GetHashCode();
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x000080A2 File Offset: 0x000062A2
		public bool Equals(UGCQueryHandle_t other)
		{
			return this.m_UGCQueryHandle == other.m_UGCQueryHandle;
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x000080B3 File Offset: 0x000062B3
		public int CompareTo(UGCQueryHandle_t other)
		{
			return this.m_UGCQueryHandle.CompareTo(other.m_UGCQueryHandle);
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x000080C7 File Offset: 0x000062C7
		public static bool operator ==(UGCQueryHandle_t x, UGCQueryHandle_t y)
		{
			return x.m_UGCQueryHandle == y.m_UGCQueryHandle;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x000080D9 File Offset: 0x000062D9
		public static bool operator !=(UGCQueryHandle_t x, UGCQueryHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x000080E5 File Offset: 0x000062E5
		public static explicit operator UGCQueryHandle_t(ulong value)
		{
			return new UGCQueryHandle_t(value);
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x000080ED File Offset: 0x000062ED
		public static explicit operator ulong(UGCQueryHandle_t that)
		{
			return that.m_UGCQueryHandle;
		}

		// Token: 0x0400094D RID: 2381
		public static readonly UGCQueryHandle_t Invalid = new UGCQueryHandle_t(ulong.MaxValue);

		// Token: 0x0400094E RID: 2382
		public ulong m_UGCQueryHandle;
	}
}
