using System;

namespace Steamworks
{
	// Token: 0x020001C4 RID: 452
	public struct SNetListenSocket_t : IEquatable<SNetListenSocket_t>, IComparable<SNetListenSocket_t>
	{
		// Token: 0x06000AAC RID: 2732 RVA: 0x000078B5 File Offset: 0x00005AB5
		public SNetListenSocket_t(uint value)
		{
			this.m_SNetListenSocket = value;
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x000078BE File Offset: 0x00005ABE
		public override string ToString()
		{
			return this.m_SNetListenSocket.ToString();
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x000078CB File Offset: 0x00005ACB
		public override bool Equals(object other)
		{
			return other is SNetListenSocket_t && this == (SNetListenSocket_t)other;
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x000078EC File Offset: 0x00005AEC
		public override int GetHashCode()
		{
			return this.m_SNetListenSocket.GetHashCode();
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x000078F9 File Offset: 0x00005AF9
		public bool Equals(SNetListenSocket_t other)
		{
			return this.m_SNetListenSocket == other.m_SNetListenSocket;
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x0000790A File Offset: 0x00005B0A
		public int CompareTo(SNetListenSocket_t other)
		{
			return this.m_SNetListenSocket.CompareTo(other.m_SNetListenSocket);
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0000791E File Offset: 0x00005B1E
		public static bool operator ==(SNetListenSocket_t x, SNetListenSocket_t y)
		{
			return x.m_SNetListenSocket == y.m_SNetListenSocket;
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00007930 File Offset: 0x00005B30
		public static bool operator !=(SNetListenSocket_t x, SNetListenSocket_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0000793C File Offset: 0x00005B3C
		public static explicit operator SNetListenSocket_t(uint value)
		{
			return new SNetListenSocket_t(value);
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x00007944 File Offset: 0x00005B44
		public static explicit operator uint(SNetListenSocket_t that)
		{
			return that.m_SNetListenSocket;
		}

		// Token: 0x04000938 RID: 2360
		public uint m_SNetListenSocket;
	}
}
