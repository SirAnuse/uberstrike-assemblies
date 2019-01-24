using System;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002BF RID: 703
	public interface ICryptographyPolicy
	{
		// Token: 0x06001124 RID: 4388
		string SHA256Encrypt(string inputString);

		// Token: 0x06001125 RID: 4389
		byte[] RijndaelEncrypt(byte[] inputClearText, string passPhrase, string initVector);

		// Token: 0x06001126 RID: 4390
		byte[] RijndaelDecrypt(byte[] inputCipherText, string passPhrase, string initVector);
	}
}
