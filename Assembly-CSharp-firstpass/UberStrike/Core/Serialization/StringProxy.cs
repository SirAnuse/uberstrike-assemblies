using System;
using System.IO;
using System.Text;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000281 RID: 641
	public static class StringProxy
	{
		// Token: 0x060010A1 RID: 4257 RVA: 0x00015570 File Offset: 0x00013770
		public static void Serialize(Stream bytes, string instance)
		{
			if (string.IsNullOrEmpty(instance))
			{
				UShortProxy.Serialize(bytes, 0);
			}
			else
			{
				UShortProxy.Serialize(bytes, (ushort)instance.Length);
				byte[] bytes2 = Encoding.Unicode.GetBytes(instance);
				bytes.Write(bytes2, 0, bytes2.Length);
			}
		}

		// Token: 0x060010A2 RID: 4258 RVA: 0x000155B8 File Offset: 0x000137B8
		public static string Deserialize(Stream bytes)
		{
			ushort num = UShortProxy.Deserialize(bytes);
			if (num > 0)
			{
				byte[] array = new byte[(int)(num * 2)];
				bytes.Read(array, 0, array.Length);
				return Encoding.Unicode.GetString(array, 0, array.Length);
			}
			return string.Empty;
		}
	}
}
