using System;
using System.IO;
using UnityEngine;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200027D RID: 637
	public static class QuaternionProxy
	{
		// Token: 0x06001099 RID: 4249 RVA: 0x000153A4 File Offset: 0x000135A4
		public static void Serialize(Stream bytes, Quaternion instance)
		{
			bytes.Write(BitConverter.GetBytes(instance.x), 0, 4);
			bytes.Write(BitConverter.GetBytes(instance.y), 0, 4);
			bytes.Write(BitConverter.GetBytes(instance.z), 0, 4);
			bytes.Write(BitConverter.GetBytes(instance.w), 0, 4);
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x00015404 File Offset: 0x00013604
		public static Quaternion Deserialize(Stream bytes)
		{
			byte[] array = new byte[16];
			bytes.Read(array, 0, 16);
			return new Quaternion(BitConverter.ToSingle(array, 0), BitConverter.ToSingle(array, 4), BitConverter.ToSingle(array, 8), BitConverter.ToSingle(array, 12));
		}
	}
}
