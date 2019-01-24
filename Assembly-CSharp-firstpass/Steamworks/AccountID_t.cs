using System;

namespace Steamworks
{
	// Token: 0x020001CB RID: 459
	public struct AccountID_t : IEquatable<AccountID_t>, IComparable<AccountID_t>
	{
		// Token: 0x06000AF7 RID: 2807 RVA: 0x00007D22 File Offset: 0x00005F22
		public AccountID_t(uint value)
		{
			this.m_AccountID = value;
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x00007D2B File Offset: 0x00005F2B
		public override string ToString()
		{
			return this.m_AccountID.ToString();
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x00007D38 File Offset: 0x00005F38
		public override bool Equals(object other)
		{
			return other is AccountID_t && this == (AccountID_t)other;
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x00007D59 File Offset: 0x00005F59
		public override int GetHashCode()
		{
			return this.m_AccountID.GetHashCode();
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x00007D66 File Offset: 0x00005F66
		public bool Equals(AccountID_t other)
		{
			return this.m_AccountID == other.m_AccountID;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x00007D77 File Offset: 0x00005F77
		public int CompareTo(AccountID_t other)
		{
			return this.m_AccountID.CompareTo(other.m_AccountID);
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x00007D8B File Offset: 0x00005F8B
		public static bool operator ==(AccountID_t x, AccountID_t y)
		{
			return x.m_AccountID == y.m_AccountID;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x00007D9D File Offset: 0x00005F9D
		public static bool operator !=(AccountID_t x, AccountID_t y)
		{
			return !(x == y);
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x00007DA9 File Offset: 0x00005FA9
		public static explicit operator AccountID_t(uint value)
		{
			return new AccountID_t(value);
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x00007DB1 File Offset: 0x00005FB1
		public static explicit operator uint(AccountID_t that)
		{
			return that.m_AccountID;
		}

		// Token: 0x04000944 RID: 2372
		public uint m_AccountID;
	}
}
