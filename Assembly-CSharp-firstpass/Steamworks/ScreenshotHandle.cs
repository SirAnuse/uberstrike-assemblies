using System;

namespace Steamworks
{
	// Token: 0x020001CA RID: 458
	public struct ScreenshotHandle : IEquatable<ScreenshotHandle>, IComparable<ScreenshotHandle>
	{
		// Token: 0x06000AEC RID: 2796 RVA: 0x00007C7D File Offset: 0x00005E7D
		public ScreenshotHandle(uint value)
		{
			this.m_ScreenshotHandle = value;
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x00007C93 File Offset: 0x00005E93
		public override string ToString()
		{
			return this.m_ScreenshotHandle.ToString();
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x00007CA0 File Offset: 0x00005EA0
		public override bool Equals(object other)
		{
			return other is ScreenshotHandle && this == (ScreenshotHandle)other;
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x00007CC1 File Offset: 0x00005EC1
		public override int GetHashCode()
		{
			return this.m_ScreenshotHandle.GetHashCode();
		}

		// Token: 0x06000AF1 RID: 2801 RVA: 0x00007CCE File Offset: 0x00005ECE
		public bool Equals(ScreenshotHandle other)
		{
			return this.m_ScreenshotHandle == other.m_ScreenshotHandle;
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x00007CDF File Offset: 0x00005EDF
		public int CompareTo(ScreenshotHandle other)
		{
			return this.m_ScreenshotHandle.CompareTo(other.m_ScreenshotHandle);
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x00007CF3 File Offset: 0x00005EF3
		public static bool operator ==(ScreenshotHandle x, ScreenshotHandle y)
		{
			return x.m_ScreenshotHandle == y.m_ScreenshotHandle;
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x00007D05 File Offset: 0x00005F05
		public static bool operator !=(ScreenshotHandle x, ScreenshotHandle y)
		{
			return !(x == y);
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x00007D11 File Offset: 0x00005F11
		public static explicit operator ScreenshotHandle(uint value)
		{
			return new ScreenshotHandle(value);
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x00007D19 File Offset: 0x00005F19
		public static explicit operator uint(ScreenshotHandle that)
		{
			return that.m_ScreenshotHandle;
		}

		// Token: 0x04000942 RID: 2370
		public static readonly ScreenshotHandle Invalid = new ScreenshotHandle(0u);

		// Token: 0x04000943 RID: 2371
		public uint m_ScreenshotHandle;
	}
}
