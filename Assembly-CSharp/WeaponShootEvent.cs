using System;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class WeaponShootEvent
{
	// Token: 0x06000723 RID: 1827 RVA: 0x0000678B File Offset: 0x0000498B
	public WeaponShootEvent(Vector3 force, float noise, float angle)
	{
		this.Force = force;
		this.Noise = noise;
		this.Angle = angle;
	}

	// Token: 0x04000624 RID: 1572
	public Vector3 Force;

	// Token: 0x04000625 RID: 1573
	public float Noise;

	// Token: 0x04000626 RID: 1574
	public float Angle;
}
