using System;

namespace Steamworks
{
	// Token: 0x020001BE RID: 446
	public struct HTTPRequestHandle : IEquatable<HTTPRequestHandle>, IComparable<HTTPRequestHandle>
	{
		// Token: 0x06000A6C RID: 2668 RVA: 0x000074ED File Offset: 0x000056ED
		public HTTPRequestHandle(uint value)
		{
			this.m_HTTPRequestHandle = value;
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x00007503 File Offset: 0x00005703
		public override string ToString()
		{
			return this.m_HTTPRequestHandle.ToString();
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x00007510 File Offset: 0x00005710
		public override bool Equals(object other)
		{
			return other is HTTPRequestHandle && this == (HTTPRequestHandle)other;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x00007531 File Offset: 0x00005731
		public override int GetHashCode()
		{
			return this.m_HTTPRequestHandle.GetHashCode();
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0000753E File Offset: 0x0000573E
		public bool Equals(HTTPRequestHandle other)
		{
			return this.m_HTTPRequestHandle == other.m_HTTPRequestHandle;
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0000754F File Offset: 0x0000574F
		public int CompareTo(HTTPRequestHandle other)
		{
			return this.m_HTTPRequestHandle.CompareTo(other.m_HTTPRequestHandle);
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00007563 File Offset: 0x00005763
		public static bool operator ==(HTTPRequestHandle x, HTTPRequestHandle y)
		{
			return x.m_HTTPRequestHandle == y.m_HTTPRequestHandle;
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x00007575 File Offset: 0x00005775
		public static bool operator !=(HTTPRequestHandle x, HTTPRequestHandle y)
		{
			return !(x == y);
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00007581 File Offset: 0x00005781
		public static explicit operator HTTPRequestHandle(uint value)
		{
			return new HTTPRequestHandle(value);
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00007589 File Offset: 0x00005789
		public static explicit operator uint(HTTPRequestHandle that)
		{
			return that.m_HTTPRequestHandle;
		}

		// Token: 0x0400092D RID: 2349
		public static readonly HTTPRequestHandle Invalid = new HTTPRequestHandle(0u);

		// Token: 0x0400092E RID: 2350
		public uint m_HTTPRequestHandle;
	}
}
