using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200024B RID: 587
	public static class BooleanProxy
	{
		// Token: 0x0600102D RID: 4141 RVA: 0x00011E74 File Offset: 0x00010074
		public static void Serialize(Stream bytes, bool instance)
		{
			byte[] bytes2 = BitConverter.GetBytes(instance);
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x00011E94 File Offset: 0x00010094
		public static bool Deserialize(Stream bytes)
		{
			byte[] array = new byte[1];
			bytes.Read(array, 0, 1);
			return BitConverter.ToBoolean(array, 0);
		}
	}
}
