using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000130 RID: 304
	[CallbackIdentity(117)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct IPCFailure_t
	{
		// Token: 0x04000549 RID: 1353
		public const int k_iCallback = 117;

		// Token: 0x0400054A RID: 1354
		public byte m_eFailureType;

		// Token: 0x02000131 RID: 305
		public enum EFailureType
		{
			// Token: 0x0400054C RID: 1356
			k_EFailureFlushedCallbackQueue,
			// Token: 0x0400054D RID: 1357
			k_EFailurePipeFail
		}
	}
}
