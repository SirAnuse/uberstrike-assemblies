using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
[Serializable]
public class EnviromentSettings
{
	// Token: 0x060011C8 RID: 4552 RVA: 0x00069F9C File Offset: 0x0006819C
	public void CheckPlayerEnclosure(Vector3 position, float height, out float enclosure)
	{
		if (this.EnviromentBounds.Contains(position))
		{
			Vector3 origin = position + Vector3.up * height;
			float num;
			if (this.EnviromentBounds.IntersectRay(new Ray(origin, Vector3.down), out num))
			{
				enclosure = (height - num) / height;
			}
			else
			{
				enclosure = 0f;
			}
		}
		else
		{
			enclosure = 0f;
		}
	}

	// Token: 0x060011C9 RID: 4553 RVA: 0x0000C57C File Offset: 0x0000A77C
	public override string ToString()
	{
		return string.Format("Type: ", this.Type);
	}

	// Token: 0x04000EBC RID: 3772
	public EnviromentSettings.TYPE Type;

	// Token: 0x04000EBD RID: 3773
	public Bounds EnviromentBounds;

	// Token: 0x04000EBE RID: 3774
	public float GroundAcceleration = 15f;

	// Token: 0x04000EBF RID: 3775
	public float GroundFriction = 8f;

	// Token: 0x04000EC0 RID: 3776
	public float AirAcceleration = 3f;

	// Token: 0x04000EC1 RID: 3777
	public float WaterAcceleration = 6f;

	// Token: 0x04000EC2 RID: 3778
	public float WaterFriction = 2f;

	// Token: 0x04000EC3 RID: 3779
	public float FlyAcceleration = 8f;

	// Token: 0x04000EC4 RID: 3780
	public float FlyFriction = 3f;

	// Token: 0x04000EC5 RID: 3781
	public float SpectatorFriction = 5f;

	// Token: 0x04000EC6 RID: 3782
	public float StopSpeed = 8f;

	// Token: 0x04000EC7 RID: 3783
	public float Gravity = 50f;

	// Token: 0x02000280 RID: 640
	public enum TYPE
	{
		// Token: 0x04000EC9 RID: 3785
		NONE,
		// Token: 0x04000ECA RID: 3786
		WATER,
		// Token: 0x04000ECB RID: 3787
		SURFACE,
		// Token: 0x04000ECC RID: 3788
		LATTER
	}
}
