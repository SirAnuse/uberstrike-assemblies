using System;

namespace Steamworks
{
	// Token: 0x020001D1 RID: 465
	public struct UGCUpdateHandle_t : IEquatable<UGCUpdateHandle_t>, IComparable<UGCUpdateHandle_t>
	{
		// Token: 0x06000B38 RID: 2872 RVA: 0x000080F6 File Offset: 0x000062F6
		public UGCUpdateHandle_t(ulong value)
		{
			this.m_UGCQueryHandle = value;
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0000810D File Offset: 0x0000630D
		public override string ToString()
		{
			return this.m_UGCQueryHandle.ToString();
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0000811A File Offset: 0x0000631A
		public override bool Equals(object other)
		{
			return other is UGCUpdateHandle_t && this == (UGCUpdateHandle_t)other;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0000813B File Offset: 0x0000633B
		public override int GetHashCode()
		{
			return this.m_UGCQueryHandle.GetHashCode();
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x00008148 File Offset: 0x00006348
		public bool Equals(UGCUpdateHandle_t other)
		{
			return this.m_UGCQueryHandle == other.m_UGCQueryHandle;
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x00008159 File Offset: 0x00006359
		public int CompareTo(UGCUpdateHandle_t other)
		{
			return this.m_UGCQueryHandle.CompareTo(other.m_UGCQueryHandle);
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0000816D File Offset: 0x0000636D
		public static bool operator ==(UGCUpdateHandle_t x, UGCUpdateHandle_t y)
		{
			return x.m_UGCQueryHandle == y.m_UGCQueryHandle;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0000817F File Offset: 0x0000637F
		public static bool operator !=(UGCUpdateHandle_t x, UGCUpdateHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0000818B File Offset: 0x0000638B
		public static explicit operator UGCUpdateHandle_t(ulong value)
		{
			return new UGCUpdateHandle_t(value);
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x00008193 File Offset: 0x00006393
		public static explicit operator ulong(UGCUpdateHandle_t that)
		{
			return that.m_UGCQueryHandle;
		}

		// Token: 0x0400094F RID: 2383
		public static readonly UGCUpdateHandle_t Invalid = new UGCUpdateHandle_t(ulong.MaxValue);

		// Token: 0x04000950 RID: 2384
		public ulong m_UGCQueryHandle;
	}
}
