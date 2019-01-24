using System;

namespace Steamworks
{
	// Token: 0x020001B9 RID: 441
	public struct CSteamID : IEquatable<CSteamID>, IComparable<CSteamID>
	{
		// Token: 0x06000A17 RID: 2583 RVA: 0x00006EFD File Offset: 0x000050FD
		public CSteamID(AccountID_t unAccountID, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.m_SteamID = 0UL;
			this.Set(unAccountID, eUniverse, eAccountType);
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00006F10 File Offset: 0x00005110
		public CSteamID(AccountID_t unAccountID, uint unAccountInstance, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.m_SteamID = 0UL;
			this.InstancedSet(unAccountID, unAccountInstance, eUniverse, eAccountType);
		}

		// Token: 0x06000A19 RID: 2585 RVA: 0x00006F25 File Offset: 0x00005125
		public CSteamID(ulong ulSteamID)
		{
			this.m_SteamID = ulSteamID;
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00006F2E File Offset: 0x0000512E
		public void Set(AccountID_t unAccountID, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.SetAccountID(unAccountID);
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(eAccountType);
			if (eAccountType == EAccountType.k_EAccountTypeClan || eAccountType == EAccountType.k_EAccountTypeGameServer)
			{
				this.SetAccountInstance(0u);
			}
			else
			{
				this.SetAccountInstance(1u);
			}
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00006F66 File Offset: 0x00005166
		public void InstancedSet(AccountID_t unAccountID, uint unInstance, EUniverse eUniverse, EAccountType eAccountType)
		{
			this.SetAccountID(unAccountID);
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(eAccountType);
			this.SetAccountInstance(unInstance);
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00006F85 File Offset: 0x00005185
		public void Clear()
		{
			this.m_SteamID = 0UL;
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00006F8F File Offset: 0x0000518F
		public void CreateBlankAnonLogon(EUniverse eUniverse)
		{
			this.SetAccountID(new AccountID_t(0u));
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(EAccountType.k_EAccountTypeAnonGameServer);
			this.SetAccountInstance(0u);
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00006FB2 File Offset: 0x000051B2
		public void CreateBlankAnonUserLogon(EUniverse eUniverse)
		{
			this.SetAccountID(new AccountID_t(0u));
			this.SetEUniverse(eUniverse);
			this.SetEAccountType(EAccountType.k_EAccountTypeAnonUser);
			this.SetAccountInstance(0u);
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00006FD6 File Offset: 0x000051D6
		public bool BBlankAnonAccount()
		{
			return this.GetAccountID() == new AccountID_t(0u) && this.BAnonAccount() && this.GetUnAccountInstance() == 0u;
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x00007005 File Offset: 0x00005205
		public bool BGameServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeGameServer || this.GetEAccountType() == EAccountType.k_EAccountTypeAnonGameServer;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x0000701F File Offset: 0x0000521F
		public bool BPersistentGameServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeGameServer;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0000702A File Offset: 0x0000522A
		public bool BAnonGameServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeAnonGameServer;
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00007035 File Offset: 0x00005235
		public bool BContentServerAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeContentServer;
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x00007040 File Offset: 0x00005240
		public bool BClanAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeClan;
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x0000704B File Offset: 0x0000524B
		public bool BChatAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeChat;
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00007056 File Offset: 0x00005256
		public bool IsLobby()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeChat && (this.GetUnAccountInstance() & 262144u) != 0u;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00007079 File Offset: 0x00005279
		public bool BIndividualAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeIndividual || this.GetEAccountType() == EAccountType.k_EAccountTypeConsoleUser;
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x00007094 File Offset: 0x00005294
		public bool BAnonAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeAnonUser || this.GetEAccountType() == EAccountType.k_EAccountTypeAnonGameServer;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x000070AF File Offset: 0x000052AF
		public bool BAnonUserAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeAnonUser;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x000070BB File Offset: 0x000052BB
		public bool BConsoleUserAccount()
		{
			return this.GetEAccountType() == EAccountType.k_EAccountTypeConsoleUser;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x000070C7 File Offset: 0x000052C7
		public void SetAccountID(AccountID_t other)
		{
			this.m_SteamID = (ulong)((long)(this.m_SteamID & 18446744069414584320UL) | ((long)((uint)other) & (long)-1));
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x000070EA File Offset: 0x000052EA
		public void SetAccountInstance(uint other)
		{
			this.m_SteamID = ((this.m_SteamID & 18442240478377148415UL) | ((ulong)other & 1048575UL) << 32);
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x0000710F File Offset: 0x0000530F
		public void SetEAccountType(EAccountType other)
		{
			this.m_SteamID = ((this.m_SteamID & 18379190079298994175UL) | (ulong)((ulong)((long)other & 15L) << 52));
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00007131 File Offset: 0x00005331
		public void SetEUniverse(EUniverse other)
		{
			this.m_SteamID = ((this.m_SteamID & 72057594037927935UL) | (ulong)((ulong)((long)other & 255L) << 56));
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00007156 File Offset: 0x00005356
		public void ClearIndividualInstance()
		{
			if (this.BIndividualAccount())
			{
				this.SetAccountInstance(0u);
			}
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0000716A File Offset: 0x0000536A
		public bool HasNoIndividualInstance()
		{
			return this.BIndividualAccount() && this.GetUnAccountInstance() == 0u;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00007183 File Offset: 0x00005383
		public AccountID_t GetAccountID()
		{
			return new AccountID_t((uint)((long)this.m_SteamID & (long)-1));
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00007194 File Offset: 0x00005394
		public uint GetUnAccountInstance()
		{
			return (uint)(this.m_SteamID >> 32 & 1048575UL);
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x000071A7 File Offset: 0x000053A7
		public EAccountType GetEAccountType()
		{
			return (EAccountType)(this.m_SteamID >> 52 & 15UL);
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x000071B7 File Offset: 0x000053B7
		public EUniverse GetEUniverse()
		{
			return (EUniverse)(this.m_SteamID >> 56 & 255UL);
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x0000FCFC File Offset: 0x0000DEFC
		public bool IsValid()
		{
			return this.GetEAccountType() > EAccountType.k_EAccountTypeInvalid && this.GetEAccountType() < EAccountType.k_EAccountTypeMax && this.GetEUniverse() > EUniverse.k_EUniverseInvalid && this.GetEUniverse() < EUniverse.k_EUniverseMax && (this.GetEAccountType() != EAccountType.k_EAccountTypeIndividual || (!(this.GetAccountID() == new AccountID_t(0u)) && this.GetUnAccountInstance() <= 4u)) && (this.GetEAccountType() != EAccountType.k_EAccountTypeClan || (!(this.GetAccountID() == new AccountID_t(0u)) && this.GetUnAccountInstance() == 0u)) && (this.GetEAccountType() != EAccountType.k_EAccountTypeGameServer || !(this.GetAccountID() == new AccountID_t(0u)));
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x000071CA File Offset: 0x000053CA
		public override string ToString()
		{
			return this.m_SteamID.ToString();
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x000071D7 File Offset: 0x000053D7
		public override bool Equals(object other)
		{
			return other is CSteamID && this == (CSteamID)other;
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x000071F8 File Offset: 0x000053F8
		public override int GetHashCode()
		{
			return this.m_SteamID.GetHashCode();
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00007205 File Offset: 0x00005405
		public bool Equals(CSteamID other)
		{
			return this.m_SteamID == other.m_SteamID;
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00007216 File Offset: 0x00005416
		public int CompareTo(CSteamID other)
		{
			return this.m_SteamID.CompareTo(other.m_SteamID);
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0000722A File Offset: 0x0000542A
		public static bool operator ==(CSteamID x, CSteamID y)
		{
			return x.m_SteamID == y.m_SteamID;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0000723C File Offset: 0x0000543C
		public static bool operator !=(CSteamID x, CSteamID y)
		{
			return !(x == y);
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00007248 File Offset: 0x00005448
		public static explicit operator CSteamID(ulong value)
		{
			return new CSteamID(value);
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00007250 File Offset: 0x00005450
		public static explicit operator ulong(CSteamID that)
		{
			return that.m_SteamID;
		}

		// Token: 0x0400091F RID: 2335
		public static readonly CSteamID Nil = default(CSteamID);

		// Token: 0x04000920 RID: 2336
		public static readonly CSteamID OutofDateGS = new CSteamID(new AccountID_t(0u), 0u, EUniverse.k_EUniverseInvalid, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000921 RID: 2337
		public static readonly CSteamID LanModeGS = new CSteamID(new AccountID_t(0u), 0u, EUniverse.k_EUniversePublic, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000922 RID: 2338
		public static readonly CSteamID NotInitYetGS = new CSteamID(new AccountID_t(1u), 0u, EUniverse.k_EUniverseInvalid, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000923 RID: 2339
		public static readonly CSteamID NonSteamGS = new CSteamID(new AccountID_t(2u), 0u, EUniverse.k_EUniverseInvalid, EAccountType.k_EAccountTypeInvalid);

		// Token: 0x04000924 RID: 2340
		public ulong m_SteamID;
	}
}
