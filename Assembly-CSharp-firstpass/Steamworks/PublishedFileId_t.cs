using System;

namespace Steamworks
{
	// Token: 0x020001C6 RID: 454
	public struct PublishedFileId_t : IEquatable<PublishedFileId_t>, IComparable<PublishedFileId_t>
	{
		// Token: 0x06000AC0 RID: 2752 RVA: 0x000079E5 File Offset: 0x00005BE5
		public PublishedFileId_t(ulong value)
		{
			this.m_PublishedFileId = value;
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x000079FC File Offset: 0x00005BFC
		public override string ToString()
		{
			return this.m_PublishedFileId.ToString();
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00007A09 File Offset: 0x00005C09
		public override bool Equals(object other)
		{
			return other is PublishedFileId_t && this == (PublishedFileId_t)other;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00007A2A File Offset: 0x00005C2A
		public override int GetHashCode()
		{
			return this.m_PublishedFileId.GetHashCode();
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00007A37 File Offset: 0x00005C37
		public bool Equals(PublishedFileId_t other)
		{
			return this.m_PublishedFileId == other.m_PublishedFileId;
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00007A48 File Offset: 0x00005C48
		public int CompareTo(PublishedFileId_t other)
		{
			return this.m_PublishedFileId.CompareTo(other.m_PublishedFileId);
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x00007A5C File Offset: 0x00005C5C
		public static bool operator ==(PublishedFileId_t x, PublishedFileId_t y)
		{
			return x.m_PublishedFileId == y.m_PublishedFileId;
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x00007A6E File Offset: 0x00005C6E
		public static bool operator !=(PublishedFileId_t x, PublishedFileId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x00007A7A File Offset: 0x00005C7A
		public static explicit operator PublishedFileId_t(ulong value)
		{
			return new PublishedFileId_t(value);
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00007A82 File Offset: 0x00005C82
		public static explicit operator ulong(PublishedFileId_t that)
		{
			return that.m_PublishedFileId;
		}

		// Token: 0x0400093A RID: 2362
		public static readonly PublishedFileId_t Invalid = new PublishedFileId_t(0UL);

		// Token: 0x0400093B RID: 2363
		public ulong m_PublishedFileId;
	}
}
