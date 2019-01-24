using System;
using UnityEngine;

namespace UberStrike.Core.Models
{
	// Token: 0x020001EF RID: 495
	public struct ShortVector3
	{
		// Token: 0x06000D31 RID: 3377 RVA: 0x000094B0 File Offset: 0x000076B0
		public ShortVector3(Vector3 value)
		{
			this.value = value;
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000D32 RID: 3378 RVA: 0x000094B9 File Offset: 0x000076B9
		public float x
		{
			get
			{
				return this.value.x;
			}
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000D33 RID: 3379 RVA: 0x000094C6 File Offset: 0x000076C6
		public float y
		{
			get
			{
				return this.value.y;
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x000094D3 File Offset: 0x000076D3
		public float z
		{
			get
			{
				return this.value.z;
			}
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x000094E0 File Offset: 0x000076E0
		public static implicit operator Vector3(ShortVector3 value)
		{
			return value.value;
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x000094E9 File Offset: 0x000076E9
		public static implicit operator ShortVector3(Vector3 value)
		{
			return new ShortVector3(value);
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x000094F1 File Offset: 0x000076F1
		public static ShortVector3 operator *(ShortVector3 vector, float value)
		{
			vector.value.x = vector.value.x * value;
			vector.value.y = vector.value.y * value;
			vector.value.z = vector.value.z * value;
			return vector;
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x00010E1C File Offset: 0x0000F01C
		public static ShortVector3 operator +(ShortVector3 vector, ShortVector3 value)
		{
			vector.value.x = vector.value.x + value.value.x;
			vector.value.y = vector.value.y + value.value.y;
			vector.value.z = vector.value.z + value.value.z;
			return vector;
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x00010E88 File Offset: 0x0000F088
		public static ShortVector3 operator -(ShortVector3 vector, ShortVector3 value)
		{
			vector.value.x = vector.value.x - value.value.x;
			vector.value.y = vector.value.y - value.value.y;
			vector.value.z = vector.value.z - value.value.z;
			return vector;
		}

		// Token: 0x04000A21 RID: 2593
		private Vector3 value;
	}
}
