using System;

namespace Steamworks
{
	// Token: 0x020001CC RID: 460
	public struct AppId_t : IEquatable<AppId_t>, IComparable<AppId_t>
	{
		// Token: 0x06000B01 RID: 2817 RVA: 0x00007DBA File Offset: 0x00005FBA
		public AppId_t(uint value)
		{
			this.m_AppId = value;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x00007DD0 File Offset: 0x00005FD0
		public override string ToString()
		{
			return this.m_AppId.ToString();
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x00007DDD File Offset: 0x00005FDD
		public override bool Equals(object other)
		{
			return other is AppId_t && this == (AppId_t)other;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x00007DFE File Offset: 0x00005FFE
		public override int GetHashCode()
		{
			return this.m_AppId.GetHashCode();
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x00007E0B File Offset: 0x0000600B
		public bool Equals(AppId_t other)
		{
			return this.m_AppId == other.m_AppId;
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x00007E1C File Offset: 0x0000601C
		public int CompareTo(AppId_t other)
		{
			return this.m_AppId.CompareTo(other.m_AppId);
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x00007E30 File Offset: 0x00006030
		public static bool operator ==(AppId_t x, AppId_t y)
		{
			return x.m_AppId == y.m_AppId;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x00007E42 File Offset: 0x00006042
		public static bool operator !=(AppId_t x, AppId_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x00007E4E File Offset: 0x0000604E
		public static explicit operator AppId_t(uint value)
		{
			return new AppId_t(value);
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x00007E56 File Offset: 0x00006056
		public static explicit operator uint(AppId_t that)
		{
			return that.m_AppId;
		}

		// Token: 0x04000945 RID: 2373
		public static readonly AppId_t Invalid = new AppId_t(0u);

		// Token: 0x04000946 RID: 2374
		public uint m_AppId;
	}
}
