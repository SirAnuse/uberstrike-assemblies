using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x0200033E RID: 830
	public static class Conversion
	{
		// Token: 0x06001383 RID: 4995 RVA: 0x00022DB8 File Offset: 0x00020FB8
		public static T[] ToArray<T>(ICollection<T> collection)
		{
			T[] array = new T[collection.Count];
			collection.CopyTo(array, 0);
			return array;
		}

		// Token: 0x06001384 RID: 4996 RVA: 0x00022DDC File Offset: 0x00020FDC
		public static Array ToArray(ICollection collection)
		{
			object[] array = new object[collection.Count];
			collection.CopyTo(array, 0);
			return array;
		}

		// Token: 0x06001385 RID: 4997 RVA: 0x00022E00 File Offset: 0x00021000
		public static T ToEnum<T>(string value)
		{
			if (typeof(T).IsEnum && !string.IsNullOrEmpty(value) && Enum.IsDefined(typeof(T), value))
			{
				return (T)((object)Enum.Parse(typeof(T), value));
			}
			return default(T);
		}

		// Token: 0x06001386 RID: 4998 RVA: 0x0000BFA7 File Offset: 0x0000A1A7
		public static float Deg2Rad(float angle)
		{
			return Mathf.Abs((angle % 360f + 360f) % 360f / 360f);
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x0000BFC7 File Offset: 0x0000A1C7
		public static byte Angle2Byte(float angle)
		{
			return (byte)(255f * Conversion.Deg2Rad(angle));
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x00022E60 File Offset: 0x00021060
		public static float Byte2Angle(byte angle)
		{
			float num = 360f * (float)angle;
			return num / 255f;
		}

		// Token: 0x06001389 RID: 5001 RVA: 0x0000BFD6 File Offset: 0x0000A1D6
		public static ushort Angle2Short(float angle)
		{
			return (ushort)(65535f * Conversion.Deg2Rad(angle));
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x00022E80 File Offset: 0x00021080
		public static float Short2Angle(ushort angle)
		{
			float num = 360f * (float)angle;
			return num / 65535f;
		}
	}
}
