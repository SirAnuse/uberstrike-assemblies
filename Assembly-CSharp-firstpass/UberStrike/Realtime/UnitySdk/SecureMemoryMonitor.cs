using System;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200034A RID: 842
	public class SecureMemoryMonitor
	{
		// Token: 0x060013D7 RID: 5079 RVA: 0x00002050 File Offset: 0x00000250
		private SecureMemoryMonitor()
		{
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060013D9 RID: 5081 RVA: 0x0000C318 File Offset: 0x0000A518
		// (remove) Token: 0x060013DA RID: 5082 RVA: 0x0000C331 File Offset: 0x0000A531
		private event Action _sender;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060013DB RID: 5083 RVA: 0x0000C318 File Offset: 0x0000A518
		// (remove) Token: 0x060013DC RID: 5084 RVA: 0x0000C331 File Offset: 0x0000A531
		internal event Action AddToMonitor
		{
			add
			{
				this._sender = (Action)Delegate.Combine(this._sender, value);
			}
			remove
			{
				this._sender = (Action)Delegate.Remove(this._sender, value);
			}
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x0000C34A File Offset: 0x0000A54A
		public void PerformCheck()
		{
			if (this._sender != null)
			{
				this._sender();
			}
		}

		// Token: 0x04000E26 RID: 3622
		public static readonly SecureMemoryMonitor Instance = new SecureMemoryMonitor();
	}
}
