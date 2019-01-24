using System;
using System.IO;
using UnityEngine;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000270 RID: 624
	public static class ColorProxy
	{
		// Token: 0x06001077 RID: 4215 RVA: 0x0000AD45 File Offset: 0x00008F45
		public static void Serialize(Stream bytes, Color instance)
		{
			bytes.Write(BitConverter.GetBytes(instance.r), 0, 4);
			bytes.Write(BitConverter.GetBytes(instance.g), 0, 4);
			bytes.Write(BitConverter.GetBytes(instance.b), 0, 4);
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x00015004 File Offset: 0x00013204
		public static Color Deserialize(Stream bytes)
		{
			byte[] array = new byte[12];
			bytes.Read(array, 0, 12);
			return new Color(BitConverter.ToSingle(array, 0), BitConverter.ToSingle(array, 4), BitConverter.ToSingle(array, 8));
		}
	}
}
