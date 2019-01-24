using System;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000350 RID: 848
	public interface IEventDispatcher
	{
		// Token: 0x0600141C RID: 5148
		void OnEvent(byte id, byte[] data);
	}
}
