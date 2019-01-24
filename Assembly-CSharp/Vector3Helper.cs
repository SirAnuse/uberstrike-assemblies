using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public static class Vector3Helper
{
	// Token: 0x060015C5 RID: 5573 RVA: 0x0000E9BE File Offset: 0x0000CBBE
	public static Vector3 SetX(this Vector3 vector, float x)
	{
		return new Vector3(x, vector.y, vector.z);
	}

	// Token: 0x060015C6 RID: 5574 RVA: 0x0000E9D4 File Offset: 0x0000CBD4
	public static Vector3 SetY(this Vector3 vector, float y)
	{
		return new Vector3(vector.x, y, vector.z);
	}

	// Token: 0x060015C7 RID: 5575 RVA: 0x0000E9EA File Offset: 0x0000CBEA
	public static Vector3 SetZ(this Vector3 vector, float z)
	{
		return new Vector3(vector.x, vector.y, z);
	}

	// Token: 0x060015C8 RID: 5576 RVA: 0x0000EA00 File Offset: 0x0000CC00
	public static Vector3 Add(this Vector3 vector, float x, float y, float z)
	{
		return new Vector3(vector.x + x, vector.y + y, vector.z + z);
	}

	// Token: 0x060015C9 RID: 5577 RVA: 0x0000EA22 File Offset: 0x0000CC22
	public static Vector3 AddX(this Vector3 vector, float x)
	{
		return new Vector3(vector.x + x, vector.y, vector.z);
	}

	// Token: 0x060015CA RID: 5578 RVA: 0x0000EA40 File Offset: 0x0000CC40
	public static Vector3 AddY(this Vector3 vector, float y)
	{
		return new Vector3(vector.x, vector.y + y, vector.z);
	}

	// Token: 0x060015CB RID: 5579 RVA: 0x0000EA5E File Offset: 0x0000CC5E
	public static Vector3 AddZ(this Vector3 vector, float z)
	{
		return new Vector3(vector.x, vector.y, vector.z + z);
	}
}
