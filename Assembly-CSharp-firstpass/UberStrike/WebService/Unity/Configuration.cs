using System;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002C1 RID: 705
	public static class Configuration
	{
		// Token: 0x04000CA0 RID: 3232
		public static string WebserviceBaseUrl = "http://localhost:9000/";

		// Token: 0x04000CA1 RID: 3233
		public static string EncryptionInitVector = string.Empty;

		// Token: 0x04000CA2 RID: 3234
		public static string EncryptionPassPhrase = string.Empty;

		// Token: 0x04000CA3 RID: 3235
		public static Action<string> RequestLogger;

		// Token: 0x04000CA4 RID: 3236
		public static bool SimulateWebservicesFail = false;
	}
}
