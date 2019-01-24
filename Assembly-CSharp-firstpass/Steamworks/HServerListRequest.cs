using System;

namespace Steamworks
{
	// Token: 0x020001C2 RID: 450
	public struct HServerListRequest : IEquatable<HServerListRequest>
	{
		// Token: 0x06000A97 RID: 2711 RVA: 0x00007775 File Offset: 0x00005975
		public HServerListRequest(IntPtr value)
		{
			this.m_HServerListRequest = value;
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x0000778F File Offset: 0x0000598F
		public override string ToString()
		{
			return this.m_HServerListRequest.ToString();
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x0000779C File Offset: 0x0000599C
		public override bool Equals(object other)
		{
			return other is HServerListRequest && this == (HServerListRequest)other;
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x000077BD File Offset: 0x000059BD
		public override int GetHashCode()
		{
			return this.m_HServerListRequest.GetHashCode();
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x000077CA File Offset: 0x000059CA
		public bool Equals(HServerListRequest other)
		{
			return this.m_HServerListRequest == other.m_HServerListRequest;
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x000077DE File Offset: 0x000059DE
		public static bool operator ==(HServerListRequest x, HServerListRequest y)
		{
			return x.m_HServerListRequest == y.m_HServerListRequest;
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x000077F3 File Offset: 0x000059F3
		public static bool operator !=(HServerListRequest x, HServerListRequest y)
		{
			return !(x == y);
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x000077FF File Offset: 0x000059FF
		public static explicit operator HServerListRequest(IntPtr value)
		{
			return new HServerListRequest(value);
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00007807 File Offset: 0x00005A07
		public static explicit operator IntPtr(HServerListRequest that)
		{
			return that.m_HServerListRequest;
		}

		// Token: 0x04000934 RID: 2356
		public static readonly HServerListRequest Invalid = new HServerListRequest(IntPtr.Zero);

		// Token: 0x04000935 RID: 2357
		public IntPtr m_HServerListRequest;
	}
}
