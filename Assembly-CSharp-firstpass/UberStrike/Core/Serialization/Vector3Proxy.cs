using System;
using System.IO;
using UnityEngine;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002BC RID: 700
	public static class Vector3Proxy
	{
		// Token: 0x0600111C RID: 4380 RVA: 0x0000ADED File Offset: 0x00008FED
		public static void Serialize(Stream bytes, Vector3 instance)
		{
			bytes.Write(BitConverter.GetBytes(instance.x), 0, 4);
			bytes.Write(BitConverter.GetBytes(instance.y), 0, 4);
			bytes.Write(BitConverter.GetBytes(instance.z), 0, 4);
		}

		// Token: 0x0600111D RID: 4381 RVA: 0x0001B1AC File Offset: 0x000193AC
		public static Vector3 Deserialize(Stream bytes)
		{
			byte[] array = new byte[12];
			bytes.Read(array, 0, 12);
			return new Vector3(BitConverter.ToSingle(array, 0), BitConverter.ToSingle(array, 4), BitConverter.ToSingle(array, 8));
		}
	}
}
