using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B6 RID: 182
	[CallbackIdentity(342)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct JoinClanChatRoomCompletionResult_t
	{
		// Token: 0x04000379 RID: 889
		public const int k_iCallback = 342;

		// Token: 0x0400037A RID: 890
		public CSteamID m_steamIDClanChat;

		// Token: 0x0400037B RID: 891
		public EChatRoomEnterResponse m_eChatRoomEnterResponse;
	}
}
