using System;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200031D RID: 797
	public interface ICryptographyPolicy
	{
		// Token: 0x0600124F RID: 4687
		string SHA256Encrypt(string inputString);

		// Token: 0x06001250 RID: 4688
		byte[] RijndaelEncrypt(byte[] inputClearText, string passPhrase, string initVector);

		// Token: 0x06001251 RID: 4689
		byte[] RijndaelDecrypt(byte[] inputCipherText, string passPhrase, string initVector);
	}
}
