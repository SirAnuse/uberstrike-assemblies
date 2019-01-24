using System;

namespace Steamworks
{
	// Token: 0x020001B5 RID: 437
	public struct HSteamPipe : IEquatable<HSteamPipe>, IComparable<HSteamPipe>
	{
		// Token: 0x060009EA RID: 2538 RVA: 0x00006C35 File Offset: 0x00004E35
		public HSteamPipe(int value)
		{
			this.m_HSteamPipe = value;
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x00006C3E File Offset: 0x00004E3E
		public override string ToString()
		{
			return this.m_HSteamPipe.ToString();
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x00006C4B File Offset: 0x00004E4B
		public override bool Equals(object other)
		{
			return other is HSteamPipe && this == (HSteamPipe)other;
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x00006C6C File Offset: 0x00004E6C
		public override int GetHashCode()
		{
			return this.m_HSteamPipe.GetHashCode();
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x00006C79 File Offset: 0x00004E79
		public bool Equals(HSteamPipe other)
		{
			return this.m_HSteamPipe == other.m_HSteamPipe;
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x00006C8A File Offset: 0x00004E8A
		public int CompareTo(HSteamPipe other)
		{
			return this.m_HSteamPipe.CompareTo(other.m_HSteamPipe);
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x00006C9E File Offset: 0x00004E9E
		public static bool operator ==(HSteamPipe x, HSteamPipe y)
		{
			return x.m_HSteamPipe == y.m_HSteamPipe;
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x00006CB0 File Offset: 0x00004EB0
		public static bool operator !=(HSteamPipe x, HSteamPipe y)
		{
			return !(x == y);
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00006CBC File Offset: 0x00004EBC
		public static explicit operator HSteamPipe(int value)
		{
			return new HSteamPipe(value);
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x00006CC4 File Offset: 0x00004EC4
		public static explicit operator int(HSteamPipe that)
		{
			return that.m_HSteamPipe;
		}

		// Token: 0x04000917 RID: 2327
		public int m_HSteamPipe;
	}
}
