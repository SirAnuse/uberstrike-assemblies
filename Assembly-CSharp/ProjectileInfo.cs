using System;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class ProjectileInfo
{
	// Token: 0x06001F25 RID: 7973 RVA: 0x000148A4 File Offset: 0x00012AA4
	public ProjectileInfo(int id, Ray ray)
	{
		this.Id = id;
		this.Position = ray.origin;
		this.Direction = ray.direction;
	}

	// Token: 0x1700069E RID: 1694
	// (get) Token: 0x06001F26 RID: 7974 RVA: 0x000148CD File Offset: 0x00012ACD
	// (set) Token: 0x06001F27 RID: 7975 RVA: 0x000148D5 File Offset: 0x00012AD5
	public int Id { get; set; }

	// Token: 0x1700069F RID: 1695
	// (get) Token: 0x06001F28 RID: 7976 RVA: 0x000148DE File Offset: 0x00012ADE
	// (set) Token: 0x06001F29 RID: 7977 RVA: 0x000148E6 File Offset: 0x00012AE6
	public Vector3 Position { get; set; }

	// Token: 0x170006A0 RID: 1696
	// (get) Token: 0x06001F2A RID: 7978 RVA: 0x000148EF File Offset: 0x00012AEF
	// (set) Token: 0x06001F2B RID: 7979 RVA: 0x000148F7 File Offset: 0x00012AF7
	public Vector3 Direction { get; set; }

	// Token: 0x170006A1 RID: 1697
	// (get) Token: 0x06001F2C RID: 7980 RVA: 0x00014900 File Offset: 0x00012B00
	// (set) Token: 0x06001F2D RID: 7981 RVA: 0x00014908 File Offset: 0x00012B08
	public Projectile Projectile { get; set; }
}
