using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000280 RID: 640
	public static class SingleProxy
	{
		// Token: 0x0600109F RID: 4255 RVA: 0x00015528 File Offset: 0x00013728
		public static void Serialize(Stream bytes, float instance)
		{
			byte[] bytes2 = BitConverter.GetBytes(instance);
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		// Token: 0x060010A0 RID: 4256 RVA: 0x00015548 File Offset: 0x00013748
		public static float Deserialize(Stream bytes)
		{
			byte[] array = new byte[4];
			bytes.Read(array, 0, 4);
			return BitConverter.ToSingle(array, 0);
		}
	}
}
