using System;

namespace Steamworks
{
	// Token: 0x020001B7 RID: 439
	public struct CGameID : IEquatable<CGameID>, IComparable<CGameID>
	{
		// Token: 0x060009FE RID: 2558 RVA: 0x00006D65 File Offset: 0x00004F65
		public CGameID(ulong GameID)
		{
			this.m_GameID = GameID;
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00006D6E File Offset: 0x00004F6E
		public CGameID(AppId_t nAppID)
		{
			this.m_GameID = 0UL;
			this.SetAppID(nAppID);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00006D7F File Offset: 0x00004F7F
		public CGameID(AppId_t nAppID, uint nModID)
		{
			this.m_GameID = 0UL;
			this.SetAppID(nAppID);
			this.SetType(CGameID.EGameIDType.k_EGameIDTypeGameMod);
			this.SetModID(nModID);
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x00006D9E File Offset: 0x00004F9E
		public bool IsSteamApp()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeApp;
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00006DA9 File Offset: 0x00004FA9
		public bool IsMod()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeGameMod;
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00006DB4 File Offset: 0x00004FB4
		public bool IsShortcut()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeShortcut;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00006DBF File Offset: 0x00004FBF
		public bool IsP2PFile()
		{
			return this.Type() == CGameID.EGameIDType.k_EGameIDTypeP2P;
		}

		// Token: 0x06000A05 RID: 2565 RVA: 0x00006DCA File Offset: 0x00004FCA
		public AppId_t AppID()
		{
			return new AppId_t((uint)(this.m_GameID & 16777215UL));
		}

		// Token: 0x06000A06 RID: 2566 RVA: 0x00006DDF File Offset: 0x00004FDF
		public CGameID.EGameIDType Type()
		{
			return (CGameID.EGameIDType)(this.m_GameID >> 24 & 255UL);
		}

		// Token: 0x06000A07 RID: 2567 RVA: 0x00006DF2 File Offset: 0x00004FF2
		public uint ModID()
		{
			return (uint)((long)this.m_GameID >> 32 & (long)-1);
		}

		// Token: 0x06000A08 RID: 2568 RVA: 0x0000FBE8 File Offset: 0x0000DDE8
		public bool IsValid()
		{
			switch (this.Type())
			{
			case CGameID.EGameIDType.k_EGameIDTypeApp:
				return this.AppID() != AppId_t.Invalid;
			case CGameID.EGameIDType.k_EGameIDTypeGameMod:
				return this.AppID() != AppId_t.Invalid && (this.ModID() & 2147483648u) != 0u;
			case CGameID.EGameIDType.k_EGameIDTypeShortcut:
				return (this.ModID() & 2147483648u) != 0u;
			case CGameID.EGameIDType.k_EGameIDTypeP2P:
				return this.AppID() == AppId_t.Invalid && (this.ModID() & 2147483648u) != 0u;
			default:
				return false;
			}
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00006E01 File Offset: 0x00005001
		public void Reset()
		{
			this.m_GameID = 0UL;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00006D65 File Offset: 0x00004F65
		public void Set(ulong GameID)
		{
			this.m_GameID = GameID;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00006E0B File Offset: 0x0000500B
		private void SetAppID(AppId_t other)
		{
			this.m_GameID = ((this.m_GameID & 18446744073692774400UL) | (((uint)other) & 16777215UL));
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x00006E2F File Offset: 0x0000502F
		private void SetType(CGameID.EGameIDType other)
		{
			this.m_GameID = ((this.m_GameID & 18446744069431361535UL) | ((ulong)((long)other & 255L) << 24));
		}

		// Token: 0x06000A0D RID: 2573 RVA: 0x00006E54 File Offset: 0x00005054
		private void SetModID(uint other)
		{
			this.m_GameID = (ulong)(((int)this.m_GameID & (int)-1) | ((int)other & -1) << (int)32);
		}

		// Token: 0x06000A0E RID: 2574 RVA: 0x00006E6E File Offset: 0x0000506E
		public override string ToString()
		{
			return this.m_GameID.ToString();
		}

		// Token: 0x06000A0F RID: 2575 RVA: 0x00006E7B File Offset: 0x0000507B
		public override bool Equals(object other)
		{
			return other is CGameID && this == (CGameID)other;
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00006E9C File Offset: 0x0000509C
		public override int GetHashCode()
		{
			return this.m_GameID.GetHashCode();
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00006EA9 File Offset: 0x000050A9
		public bool Equals(CGameID other)
		{
			return this.m_GameID == other.m_GameID;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00006EBA File Offset: 0x000050BA
		public int CompareTo(CGameID other)
		{
			return this.m_GameID.CompareTo(other.m_GameID);
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00006ECE File Offset: 0x000050CE
		public static bool operator ==(CGameID x, CGameID y)
		{
			return x.m_GameID == y.m_GameID;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00006EE0 File Offset: 0x000050E0
		public static bool operator !=(CGameID x, CGameID y)
		{
			return !(x == y);
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00006EEC File Offset: 0x000050EC
		public static explicit operator CGameID(ulong value)
		{
			return new CGameID(value);
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00006EF4 File Offset: 0x000050F4
		public static explicit operator ulong(CGameID that)
		{
			return that.m_GameID;
		}

		// Token: 0x04000919 RID: 2329
		public ulong m_GameID;

		// Token: 0x020001B8 RID: 440
		public enum EGameIDType
		{
			// Token: 0x0400091B RID: 2331
			k_EGameIDTypeApp,
			// Token: 0x0400091C RID: 2332
			k_EGameIDTypeGameMod,
			// Token: 0x0400091D RID: 2333
			k_EGameIDTypeShortcut,
			// Token: 0x0400091E RID: 2334
			k_EGameIDTypeP2P
		}
	}
}
