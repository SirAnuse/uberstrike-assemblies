using System;

namespace Steamworks
{
	// Token: 0x020001C8 RID: 456
	public struct UGCFileWriteStreamHandle_t : IEquatable<UGCFileWriteStreamHandle_t>, IComparable<UGCFileWriteStreamHandle_t>
	{
		// Token: 0x06000AD6 RID: 2774 RVA: 0x00007B31 File Offset: 0x00005D31
		public UGCFileWriteStreamHandle_t(ulong value)
		{
			this.m_UGCFileWriteStreamHandle = value;
		}

		// Token: 0x06000AD8 RID: 2776 RVA: 0x00007B48 File Offset: 0x00005D48
		public override string ToString()
		{
			return this.m_UGCFileWriteStreamHandle.ToString();
		}

		// Token: 0x06000AD9 RID: 2777 RVA: 0x00007B55 File Offset: 0x00005D55
		public override bool Equals(object other)
		{
			return other is UGCFileWriteStreamHandle_t && this == (UGCFileWriteStreamHandle_t)other;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x00007B76 File Offset: 0x00005D76
		public override int GetHashCode()
		{
			return this.m_UGCFileWriteStreamHandle.GetHashCode();
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x00007B83 File Offset: 0x00005D83
		public bool Equals(UGCFileWriteStreamHandle_t other)
		{
			return this.m_UGCFileWriteStreamHandle == other.m_UGCFileWriteStreamHandle;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x00007B94 File Offset: 0x00005D94
		public int CompareTo(UGCFileWriteStreamHandle_t other)
		{
			return this.m_UGCFileWriteStreamHandle.CompareTo(other.m_UGCFileWriteStreamHandle);
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x00007BA8 File Offset: 0x00005DA8
		public static bool operator ==(UGCFileWriteStreamHandle_t x, UGCFileWriteStreamHandle_t y)
		{
			return x.m_UGCFileWriteStreamHandle == y.m_UGCFileWriteStreamHandle;
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00007BBA File Offset: 0x00005DBA
		public static bool operator !=(UGCFileWriteStreamHandle_t x, UGCFileWriteStreamHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000ADF RID: 2783 RVA: 0x00007BC6 File Offset: 0x00005DC6
		public static explicit operator UGCFileWriteStreamHandle_t(ulong value)
		{
			return new UGCFileWriteStreamHandle_t(value);
		}

		// Token: 0x06000AE0 RID: 2784 RVA: 0x00007BCE File Offset: 0x00005DCE
		public static explicit operator ulong(UGCFileWriteStreamHandle_t that)
		{
			return that.m_UGCFileWriteStreamHandle;
		}

		// Token: 0x0400093E RID: 2366
		public static readonly UGCFileWriteStreamHandle_t Invalid = new UGCFileWriteStreamHandle_t(ulong.MaxValue);

		// Token: 0x0400093F RID: 2367
		public ulong m_UGCFileWriteStreamHandle;
	}
}
