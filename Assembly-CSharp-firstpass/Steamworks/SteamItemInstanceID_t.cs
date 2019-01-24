using System;

namespace Steamworks
{
	// Token: 0x020001C1 RID: 449
	public struct SteamItemInstanceID_t : IEquatable<SteamItemInstanceID_t>, IComparable<SteamItemInstanceID_t>
	{
		// Token: 0x06000A8C RID: 2700 RVA: 0x000076CF File Offset: 0x000058CF
		public SteamItemInstanceID_t(ulong value)
		{
			this.m_SteamItemInstanceID_t = value;
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x000076E6 File Offset: 0x000058E6
		public override string ToString()
		{
			return this.m_SteamItemInstanceID_t.ToString();
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x000076F3 File Offset: 0x000058F3
		public override bool Equals(object other)
		{
			return other is SteamItemInstanceID_t && this == (SteamItemInstanceID_t)other;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x00007714 File Offset: 0x00005914
		public override int GetHashCode()
		{
			return this.m_SteamItemInstanceID_t.GetHashCode();
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00007721 File Offset: 0x00005921
		public bool Equals(SteamItemInstanceID_t other)
		{
			return this.m_SteamItemInstanceID_t == other.m_SteamItemInstanceID_t;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x00007732 File Offset: 0x00005932
		public int CompareTo(SteamItemInstanceID_t other)
		{
			return this.m_SteamItemInstanceID_t.CompareTo(other.m_SteamItemInstanceID_t);
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00007746 File Offset: 0x00005946
		public static bool operator ==(SteamItemInstanceID_t x, SteamItemInstanceID_t y)
		{
			return x.m_SteamItemInstanceID_t == y.m_SteamItemInstanceID_t;
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x00007758 File Offset: 0x00005958
		public static bool operator !=(SteamItemInstanceID_t x, SteamItemInstanceID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x00007764 File Offset: 0x00005964
		public static explicit operator SteamItemInstanceID_t(ulong value)
		{
			return new SteamItemInstanceID_t(value);
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x0000776C File Offset: 0x0000596C
		public static explicit operator ulong(SteamItemInstanceID_t that)
		{
			return that.m_SteamItemInstanceID_t;
		}

		// Token: 0x04000932 RID: 2354
		public static readonly SteamItemInstanceID_t Invalid = new SteamItemInstanceID_t(ulong.MaxValue);

		// Token: 0x04000933 RID: 2355
		public ulong m_SteamItemInstanceID_t;
	}
}
