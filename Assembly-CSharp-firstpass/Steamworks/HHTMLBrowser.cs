using System;

namespace Steamworks
{
	// Token: 0x020001BC RID: 444
	public struct HHTMLBrowser : IEquatable<HHTMLBrowser>, IComparable<HHTMLBrowser>
	{
		// Token: 0x06000A56 RID: 2646 RVA: 0x000073A3 File Offset: 0x000055A3
		public HHTMLBrowser(uint value)
		{
			this.m_HHTMLBrowser = value;
		}

		// Token: 0x06000A58 RID: 2648 RVA: 0x000073B9 File Offset: 0x000055B9
		public override string ToString()
		{
			return this.m_HHTMLBrowser.ToString();
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x000073C6 File Offset: 0x000055C6
		public override bool Equals(object other)
		{
			return other is HHTMLBrowser && this == (HHTMLBrowser)other;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x000073E7 File Offset: 0x000055E7
		public override int GetHashCode()
		{
			return this.m_HHTMLBrowser.GetHashCode();
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x000073F4 File Offset: 0x000055F4
		public bool Equals(HHTMLBrowser other)
		{
			return this.m_HHTMLBrowser == other.m_HHTMLBrowser;
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x00007405 File Offset: 0x00005605
		public int CompareTo(HHTMLBrowser other)
		{
			return this.m_HHTMLBrowser.CompareTo(other.m_HHTMLBrowser);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x00007419 File Offset: 0x00005619
		public static bool operator ==(HHTMLBrowser x, HHTMLBrowser y)
		{
			return x.m_HHTMLBrowser == y.m_HHTMLBrowser;
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x0000742B File Offset: 0x0000562B
		public static bool operator !=(HHTMLBrowser x, HHTMLBrowser y)
		{
			return !(x == y);
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x00007437 File Offset: 0x00005637
		public static explicit operator HHTMLBrowser(uint value)
		{
			return new HHTMLBrowser(value);
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0000743F File Offset: 0x0000563F
		public static explicit operator uint(HHTMLBrowser that)
		{
			return that.m_HHTMLBrowser;
		}

		// Token: 0x04000929 RID: 2345
		public static readonly HHTMLBrowser Invalid = new HHTMLBrowser(0u);

		// Token: 0x0400092A RID: 2346
		public uint m_HHTMLBrowser;
	}
}
