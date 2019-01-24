using System;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002C0 RID: 704
	public class NullCryptographyPolicy : ICryptographyPolicy
	{
		// Token: 0x06001128 RID: 4392 RVA: 0x0000AE69 File Offset: 0x00009069
		public string SHA256Encrypt(string inputString)
		{
			return inputString;
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x0000AE69 File Offset: 0x00009069
		public byte[] RijndaelEncrypt(byte[] inputClearText, string passPhrase, string initVector)
		{
			return inputClearText;
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x0000AE69 File Offset: 0x00009069
		public byte[] RijndaelDecrypt(byte[] inputCipherText, string passPhrase, string initVector)
		{
			return inputCipherText;
		}
	}
}
