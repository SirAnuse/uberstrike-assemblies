using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000271 RID: 625
	public static class DateTimeProxy
	{
		// Token: 0x06001079 RID: 4217 RVA: 0x00015040 File Offset: 0x00013240
		public static void Serialize(Stream bytes, DateTime instance)
		{
			byte[] bytes2 = BitConverter.GetBytes(instance.Ticks);
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x00015068 File Offset: 0x00013268
		public static DateTime Deserialize(Stream bytes)
		{
			byte[] array = new byte[8];
			bytes.Read(array, 0, 8);
			return new DateTime(BitConverter.ToInt64(array, 0));
		}
	}
}
