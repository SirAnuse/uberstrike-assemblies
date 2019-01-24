using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000279 RID: 633
	public static class Int64Proxy
	{
		// Token: 0x0600108D RID: 4237 RVA: 0x000152C0 File Offset: 0x000134C0
		public static void Serialize(Stream bytes, long instance)
		{
			byte[] bytes2 = BitConverter.GetBytes(instance);
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x000152E0 File Offset: 0x000134E0
		public static long Deserialize(Stream bytes)
		{
			byte[] array = new byte[8];
			bytes.Read(array, 0, 8);
			return BitConverter.ToInt64(array, 0);
		}
	}
}
