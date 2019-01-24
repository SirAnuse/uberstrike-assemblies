using System;
using UnityEngine;

// Token: 0x02000462 RID: 1122
public class ShotPoint
{
	// Token: 0x06001FFB RID: 8187 RVA: 0x0001511A File Offset: 0x0001331A
	public ShotPoint(Vector3 point, int projectileId)
	{
		this.AddPoint(point);
		this.ProjectileId = projectileId;
	}

	// Token: 0x170006DF RID: 1759
	// (get) Token: 0x06001FFC RID: 8188 RVA: 0x00015130 File Offset: 0x00013330
	// (set) Token: 0x06001FFD RID: 8189 RVA: 0x00015138 File Offset: 0x00013338
	public int ProjectileId { get; private set; }

	// Token: 0x170006E0 RID: 1760
	// (get) Token: 0x06001FFE RID: 8190 RVA: 0x00015141 File Offset: 0x00013341
	// (set) Token: 0x06001FFF RID: 8191 RVA: 0x00015149 File Offset: 0x00013349
	public int Count { get; private set; }

	// Token: 0x06002000 RID: 8192 RVA: 0x00015152 File Offset: 0x00013352
	public void AddPoint(Vector3 point)
	{
		this._aggregatedPoint += point;
		this.Count++;
	}

	// Token: 0x170006E1 RID: 1761
	// (get) Token: 0x06002001 RID: 8193 RVA: 0x00015174 File Offset: 0x00013374
	public Vector3 MidPoint
	{
		get
		{
			return this._aggregatedPoint / (float)this.Count;
		}
	}

	// Token: 0x04001B2E RID: 6958
	private Vector3 _aggregatedPoint;
}
