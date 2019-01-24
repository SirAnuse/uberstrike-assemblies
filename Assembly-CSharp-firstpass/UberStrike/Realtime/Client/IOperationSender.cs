using System;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000352 RID: 850
	public interface IOperationSender
	{
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600141E RID: 5150
		// (remove) Token: 0x0600141F RID: 5151
		event RemoteProcedureCall SendOperation;
	}
}
