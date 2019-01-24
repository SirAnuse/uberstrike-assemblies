using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000196 RID: 406
	public struct MatchMakingKeyValuePair_t
	{
		// Token: 0x06000727 RID: 1831 RVA: 0x0000427B File Offset: 0x0000247B
		private MatchMakingKeyValuePair_t(string strKey, string strValue)
		{
			this.m_szKey = strKey;
			this.m_szValue = strValue;
		}

		// Token: 0x040008FA RID: 2298
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szKey;

		// Token: 0x040008FB RID: 2299
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szValue;
	}
}
