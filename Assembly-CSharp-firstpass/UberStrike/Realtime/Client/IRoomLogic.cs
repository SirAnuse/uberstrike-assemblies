using System;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000353 RID: 851
	public interface IRoomLogic : IEventDispatcher
	{
		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06001420 RID: 5152
		IOperationSender Operations { get; }
	}
}
