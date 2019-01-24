using System;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200031E RID: 798
	public class NullCryptographyPolicy : ICryptographyPolicy
	{
		// Token: 0x06001253 RID: 4691 RVA: 0x0000AE69 File Offset: 0x00009069
		public string SHA256Encrypt(string inputString)
		{
			return inputString;
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x0000AE69 File Offset: 0x00009069
		public byte[] RijndaelEncrypt(byte[] inputClearText, string passPhrase, string initVector)
		{
			return inputClearText;
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x0000AE69 File Offset: 0x00009069
		public byte[] RijndaelDecrypt(byte[] inputCipherText, string passPhrase, string initVector)
		{
			return inputCipherText;
		}
	}
}
