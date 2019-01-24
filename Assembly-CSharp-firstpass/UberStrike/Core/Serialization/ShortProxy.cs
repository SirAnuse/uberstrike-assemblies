using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200027E RID: 638
	public static class ShortProxy
	{
		// Token: 0x0600109B RID: 4251 RVA: 0x00015230 File Offset: 0x00013430
		public static void Serialize(Stream bytes, short instance)
		{
			byte[] bytes2 = BitConverter.GetBytes(instance);
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x00015250 File Offset: 0x00013450
		public static short Deserialize(Stream bytes)
		{
			byte[] array = new byte[2];
			bytes.Read(array, 0, 2);
			return BitConverter.ToInt16(array, 0);
		}
	}
}
