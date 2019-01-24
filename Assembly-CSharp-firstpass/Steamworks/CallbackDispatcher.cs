using System;
using UnityEngine;

namespace Steamworks
{
	// Token: 0x0200006E RID: 110
	public static class CallbackDispatcher
	{
		// Token: 0x0600036D RID: 877 RVA: 0x00003DDE File Offset: 0x00001FDE
		public static void ExceptionHandler(Exception e)
		{
			Debug.LogException(e);
		}
	}
}
