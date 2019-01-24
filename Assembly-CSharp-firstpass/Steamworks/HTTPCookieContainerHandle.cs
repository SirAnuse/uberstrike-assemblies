using System;

namespace Steamworks
{
	// Token: 0x020001BD RID: 445
	public struct HTTPCookieContainerHandle : IEquatable<HTTPCookieContainerHandle>, IComparable<HTTPCookieContainerHandle>
	{
		// Token: 0x06000A61 RID: 2657 RVA: 0x00007448 File Offset: 0x00005648
		public HTTPCookieContainerHandle(uint value)
		{
			this.m_HTTPCookieContainerHandle = value;
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0000745E File Offset: 0x0000565E
		public override string ToString()
		{
			return this.m_HTTPCookieContainerHandle.ToString();
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0000746B File Offset: 0x0000566B
		public override bool Equals(object other)
		{
			return other is HTTPCookieContainerHandle && this == (HTTPCookieContainerHandle)other;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0000748C File Offset: 0x0000568C
		public override int GetHashCode()
		{
			return this.m_HTTPCookieContainerHandle.GetHashCode();
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x00007499 File Offset: 0x00005699
		public bool Equals(HTTPCookieContainerHandle other)
		{
			return this.m_HTTPCookieContainerHandle == other.m_HTTPCookieContainerHandle;
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x000074AA File Offset: 0x000056AA
		public int CompareTo(HTTPCookieContainerHandle other)
		{
			return this.m_HTTPCookieContainerHandle.CompareTo(other.m_HTTPCookieContainerHandle);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x000074BE File Offset: 0x000056BE
		public static bool operator ==(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y)
		{
			return x.m_HTTPCookieContainerHandle == y.m_HTTPCookieContainerHandle;
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x000074D0 File Offset: 0x000056D0
		public static bool operator !=(HTTPCookieContainerHandle x, HTTPCookieContainerHandle y)
		{
			return !(x == y);
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x000074DC File Offset: 0x000056DC
		public static explicit operator HTTPCookieContainerHandle(uint value)
		{
			return new HTTPCookieContainerHandle(value);
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x000074E4 File Offset: 0x000056E4
		public static explicit operator uint(HTTPCookieContainerHandle that)
		{
			return that.m_HTTPCookieContainerHandle;
		}

		// Token: 0x0400092B RID: 2347
		public static readonly HTTPCookieContainerHandle Invalid = new HTTPCookieContainerHandle(0u);

		// Token: 0x0400092C RID: 2348
		public uint m_HTTPCookieContainerHandle;
	}
}
