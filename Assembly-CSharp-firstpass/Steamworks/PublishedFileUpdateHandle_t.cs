using System;

namespace Steamworks
{
	// Token: 0x020001C7 RID: 455
	public struct PublishedFileUpdateHandle_t : IEquatable<PublishedFileUpdateHandle_t>, IComparable<PublishedFileUpdateHandle_t>
	{
		// Token: 0x06000ACB RID: 2763 RVA: 0x00007A8B File Offset: 0x00005C8B
		public PublishedFileUpdateHandle_t(ulong value)
		{
			this.m_PublishedFileUpdateHandle = value;
		}

		// Token: 0x06000ACD RID: 2765 RVA: 0x00007AA2 File Offset: 0x00005CA2
		public override string ToString()
		{
			return this.m_PublishedFileUpdateHandle.ToString();
		}

		// Token: 0x06000ACE RID: 2766 RVA: 0x00007AAF File Offset: 0x00005CAF
		public override bool Equals(object other)
		{
			return other is PublishedFileUpdateHandle_t && this == (PublishedFileUpdateHandle_t)other;
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x00007AD0 File Offset: 0x00005CD0
		public override int GetHashCode()
		{
			return this.m_PublishedFileUpdateHandle.GetHashCode();
		}

		// Token: 0x06000AD0 RID: 2768 RVA: 0x00007ADD File Offset: 0x00005CDD
		public bool Equals(PublishedFileUpdateHandle_t other)
		{
			return this.m_PublishedFileUpdateHandle == other.m_PublishedFileUpdateHandle;
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x00007AEE File Offset: 0x00005CEE
		public int CompareTo(PublishedFileUpdateHandle_t other)
		{
			return this.m_PublishedFileUpdateHandle.CompareTo(other.m_PublishedFileUpdateHandle);
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x00007B02 File Offset: 0x00005D02
		public static bool operator ==(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y)
		{
			return x.m_PublishedFileUpdateHandle == y.m_PublishedFileUpdateHandle;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x00007B14 File Offset: 0x00005D14
		public static bool operator !=(PublishedFileUpdateHandle_t x, PublishedFileUpdateHandle_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x00007B20 File Offset: 0x00005D20
		public static explicit operator PublishedFileUpdateHandle_t(ulong value)
		{
			return new PublishedFileUpdateHandle_t(value);
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00007B28 File Offset: 0x00005D28
		public static explicit operator ulong(PublishedFileUpdateHandle_t that)
		{
			return that.m_PublishedFileUpdateHandle;
		}

		// Token: 0x0400093C RID: 2364
		public static readonly PublishedFileUpdateHandle_t Invalid = new PublishedFileUpdateHandle_t(ulong.MaxValue);

		// Token: 0x0400093D RID: 2365
		public ulong m_PublishedFileUpdateHandle;
	}
}
