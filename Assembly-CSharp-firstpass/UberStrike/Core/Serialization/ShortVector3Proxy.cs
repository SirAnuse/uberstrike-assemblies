using System;
using System.IO;
using UberStrike.Core.Models;
using UnityEngine;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200027F RID: 639
	public static class ShortVector3Proxy
	{
		// Token: 0x0600109D RID: 4253 RVA: 0x00015448 File Offset: 0x00013648
		public static void Serialize(Stream bytes, ShortVector3 instance)
		{
			bytes.Write(BitConverter.GetBytes((short)Mathf.Clamp(instance.x * 100f, -32768f, 32767f)), 0, 2);
			bytes.Write(BitConverter.GetBytes((short)Mathf.Clamp(instance.y * 100f, -32768f, 32767f)), 0, 2);
			bytes.Write(BitConverter.GetBytes((short)Mathf.Clamp(instance.z * 100f, -32768f, 32767f)), 0, 2);
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x000154D4 File Offset: 0x000136D4
		public static ShortVector3 Deserialize(Stream bytes)
		{
			byte[] array = new byte[6];
			bytes.Read(array, 0, 6);
			return new Vector3(0.01f * (float)BitConverter.ToInt16(array, 0), 0.01f * (float)BitConverter.ToInt16(array, 2), 0.01f * (float)BitConverter.ToInt16(array, 4));
		}
	}
}
