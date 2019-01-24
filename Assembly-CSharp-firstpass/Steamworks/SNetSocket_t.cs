using System;

namespace Steamworks
{
	// Token: 0x020001C5 RID: 453
	public struct SNetSocket_t : IEquatable<SNetSocket_t>, IComparable<SNetSocket_t>
	{
		// Token: 0x06000AB6 RID: 2742 RVA: 0x0000794D File Offset: 0x00005B4D
		public SNetSocket_t(uint value)
		{
			this.m_SNetSocket = value;
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x00007956 File Offset: 0x00005B56
		public override string ToString()
		{
			return this.m_SNetSocket.ToString();
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00007963 File Offset: 0x00005B63
		public override bool Equals(object other)
		{
			return other is SNetSocket_t && this == (SNetSocket_t)other;
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x00007984 File Offset: 0x00005B84
		public override int GetHashCode()
		{
			return this.m_SNetSocket.GetHashCode();
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00007991 File Offset: 0x00005B91
		public bool Equals(SNetSocket_t other)
		{
			return this.m_SNetSocket == other.m_SNetSocket;
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x000079A2 File Offset: 0x00005BA2
		public int CompareTo(SNetSocket_t other)
		{
			return this.m_SNetSocket.CompareTo(other.m_SNetSocket);
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x000079B6 File Offset: 0x00005BB6
		public static bool operator ==(SNetSocket_t x, SNetSocket_t y)
		{
			return x.m_SNetSocket == y.m_SNetSocket;
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x000079C8 File Offset: 0x00005BC8
		public static bool operator !=(SNetSocket_t x, SNetSocket_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x000079D4 File Offset: 0x00005BD4
		public static explicit operator SNetSocket_t(uint value)
		{
			return new SNetSocket_t(value);
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x000079DC File Offset: 0x00005BDC
		public static explicit operator uint(SNetSocket_t that)
		{
			return that.m_SNetSocket;
		}

		// Token: 0x04000939 RID: 2361
		public uint m_SNetSocket;
	}
}
