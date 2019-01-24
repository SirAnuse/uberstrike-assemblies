using System;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200031C RID: 796
	public static class Cryptography
	{
		// Token: 0x0600124C RID: 4684 RVA: 0x0000BC2E File Offset: 0x00009E2E
		public static string SHA256Encrypt(string inputString)
		{
			return Cryptography.Policy.SHA256Encrypt(inputString);
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x0000BC3B File Offset: 0x00009E3B
		public static byte[] RijndaelEncrypt(byte[] inputClearText, string passPhrase, string initVector)
		{
			return Cryptography.Policy.RijndaelEncrypt(inputClearText, passPhrase, initVector);
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x0000BC4A File Offset: 0x00009E4A
		public static byte[] RijndaelDecrypt(byte[] inputCipherText, string passPhrase, string initVector)
		{
			return Cryptography.Policy.RijndaelDecrypt(inputCipherText, passPhrase, initVector);
		}

		// Token: 0x04000D1D RID: 3357
		public static ICryptographyPolicy Policy = new NullCryptographyPolicy();
	}
}
