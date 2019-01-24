using System;

namespace Steamworks
{
	// Token: 0x020001B6 RID: 438
	public struct HSteamUser : IEquatable<HSteamUser>, IComparable<HSteamUser>
	{
		// Token: 0x060009F4 RID: 2548 RVA: 0x00006CCD File Offset: 0x00004ECD
		public HSteamUser(int value)
		{
			this.m_HSteamUser = value;
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00006CD6 File Offset: 0x00004ED6
		public override string ToString()
		{
			return this.m_HSteamUser.ToString();
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00006CE3 File Offset: 0x00004EE3
		public override bool Equals(object other)
		{
			return other is HSteamUser && this == (HSteamUser)other;
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00006D04 File Offset: 0x00004F04
		public override int GetHashCode()
		{
			return this.m_HSteamUser.GetHashCode();
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00006D11 File Offset: 0x00004F11
		public bool Equals(HSteamUser other)
		{
			return this.m_HSteamUser == other.m_HSteamUser;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00006D22 File Offset: 0x00004F22
		public int CompareTo(HSteamUser other)
		{
			return this.m_HSteamUser.CompareTo(other.m_HSteamUser);
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00006D36 File Offset: 0x00004F36
		public static bool operator ==(HSteamUser x, HSteamUser y)
		{
			return x.m_HSteamUser == y.m_HSteamUser;
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00006D48 File Offset: 0x00004F48
		public static bool operator !=(HSteamUser x, HSteamUser y)
		{
			return !(x == y);
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00006D54 File Offset: 0x00004F54
		public static explicit operator HSteamUser(int value)
		{
			return new HSteamUser(value);
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00006D5C File Offset: 0x00004F5C
		public static explicit operator int(HSteamUser that)
		{
			return that.m_HSteamUser;
		}

		// Token: 0x04000918 RID: 2328
		public int m_HSteamUser;
	}
}
