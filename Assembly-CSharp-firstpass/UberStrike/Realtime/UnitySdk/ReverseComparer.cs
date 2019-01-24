using System;
using System.Collections.Generic;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200033C RID: 828
	public sealed class ReverseComparer<T> : IComparer<T>
	{
		// Token: 0x0600137E RID: 4990 RVA: 0x0000BF74 File Offset: 0x0000A174
		public ReverseComparer() : this(null)
		{
		}

		// Token: 0x0600137F RID: 4991 RVA: 0x0000BF7D File Offset: 0x0000A17D
		public ReverseComparer(IComparer<T> inner)
		{
			this.inner = (inner ?? Comparer<T>.Default);
		}

		// Token: 0x06001380 RID: 4992 RVA: 0x0000BF98 File Offset: 0x0000A198
		int IComparer<T>.Compare(T x, T y)
		{
			return this.inner.Compare(y, x);
		}

		// Token: 0x04000E05 RID: 3589
		private readonly IComparer<T> inner;
	}
}
