using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000278 RID: 632
	public static class Int32Proxy
	{
		// Token: 0x0600108B RID: 4235 RVA: 0x00015278 File Offset: 0x00013478
		public static void Serialize(Stream bytes, int instance)
		{
			byte[] bytes2 = BitConverter.GetBytes(instance);
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x00015298 File Offset: 0x00013498
		public static int Deserialize(Stream bytes)
		{
			byte[] array = new byte[4];
			bytes.Read(array, 0, 4);
			return BitConverter.ToInt32(array, 0);
		}
	}
}
