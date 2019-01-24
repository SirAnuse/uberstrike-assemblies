using System;
using System.Collections.Generic;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000371 RID: 881
	// (Invoke) Token: 0x060014AD RID: 5293
	public delegate bool RemoteProcedureCall(byte customOpCode, Dictionary<byte, object> customOpParameters, bool sendReliable = true, byte channelId = 0, bool encryption = false);
}
