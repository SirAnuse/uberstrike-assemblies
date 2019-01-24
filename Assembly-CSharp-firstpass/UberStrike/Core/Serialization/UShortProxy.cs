using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000283 RID: 643
	public static class UShortProxy
	{
		// Token: 0x060010A5 RID: 4261 RVA: 0x00015600 File Offset: 0x00013800
		public static void Serialize(Stream bytes, ushort instance)
		{
			byte[] bytes2 = BitConverter.GetBytes(instance);
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x00015620 File Offset: 0x00013820
		public static ushort Deserialize(Stream bytes)
		{
			byte[] array = new byte[2];
			bytes.Read(array, 0, 2);
			return BitConverter.ToUInt16(array, 0);
		}
	}
}
