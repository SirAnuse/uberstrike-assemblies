using System;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002BE RID: 702
	public static class Cryptography
	{
		// Token: 0x06001121 RID: 4385 RVA: 0x0000AE3E File Offset: 0x0000903E
		public static string SHA256Encrypt(string inputString)
		{
			return Cryptography.Policy.SHA256Encrypt(inputString);
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x0000AE4B File Offset: 0x0000904B
		public static byte[] RijndaelEncrypt(byte[] inputClearText, string passPhrase, string initVector)
		{
			return Cryptography.Policy.RijndaelEncrypt(inputClearText, passPhrase, initVector);
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x0000AE5A File Offset: 0x0000905A
		public static byte[] RijndaelDecrypt(byte[] inputCipherText, string passPhrase, string initVector)
		{
			return Cryptography.Policy.RijndaelDecrypt(inputCipherText, passPhrase, initVector);
		}

		// Token: 0x04000C9F RID: 3231
		public static ICryptographyPolicy Policy = new NullCryptographyPolicy();
	}
}
