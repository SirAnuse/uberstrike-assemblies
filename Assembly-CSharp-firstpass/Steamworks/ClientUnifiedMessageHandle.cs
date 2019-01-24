using System;

namespace Steamworks
{
	// Token: 0x020001D2 RID: 466
	public struct ClientUnifiedMessageHandle : IEquatable<ClientUnifiedMessageHandle>, IComparable<ClientUnifiedMessageHandle>
	{
		// Token: 0x06000B43 RID: 2883 RVA: 0x0000819C File Offset: 0x0000639C
		public ClientUnifiedMessageHandle(ulong value)
		{
			this.m_ClientUnifiedMessageHandle = value;
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x000081B3 File Offset: 0x000063B3
		public override string ToString()
		{
			return this.m_ClientUnifiedMessageHandle.ToString();
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x000081C0 File Offset: 0x000063C0
		public override bool Equals(object other)
		{
			return other is ClientUnifiedMessageHandle && this == (ClientUnifiedMessageHandle)other;
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x000081E1 File Offset: 0x000063E1
		public override int GetHashCode()
		{
			return this.m_ClientUnifiedMessageHandle.GetHashCode();
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x000081EE File Offset: 0x000063EE
		public bool Equals(ClientUnifiedMessageHandle other)
		{
			return this.m_ClientUnifiedMessageHandle == other.m_ClientUnifiedMessageHandle;
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x000081FF File Offset: 0x000063FF
		public int CompareTo(ClientUnifiedMessageHandle other)
		{
			return this.m_ClientUnifiedMessageHandle.CompareTo(other.m_ClientUnifiedMessageHandle);
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x00008213 File Offset: 0x00006413
		public static bool operator ==(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y)
		{
			return x.m_ClientUnifiedMessageHandle == y.m_ClientUnifiedMessageHandle;
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x00008225 File Offset: 0x00006425
		public static bool operator !=(ClientUnifiedMessageHandle x, ClientUnifiedMessageHandle y)
		{
			return !(x == y);
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x00008231 File Offset: 0x00006431
		public static explicit operator ClientUnifiedMessageHandle(ulong value)
		{
			return new ClientUnifiedMessageHandle(value);
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x00008239 File Offset: 0x00006439
		public static explicit operator ulong(ClientUnifiedMessageHandle that)
		{
			return that.m_ClientUnifiedMessageHandle;
		}

		// Token: 0x04000951 RID: 2385
		public static readonly ClientUnifiedMessageHandle Invalid = new ClientUnifiedMessageHandle(0UL);

		// Token: 0x04000952 RID: 2386
		public ulong m_ClientUnifiedMessageHandle;
	}
}
