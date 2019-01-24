using System;
using UnityEngine;

// Token: 0x020000B9 RID: 185
public class CameraCollisionDetector
{
	// Token: 0x1700021D RID: 541
	// (get) Token: 0x06000710 RID: 1808 RVA: 0x000066CA File Offset: 0x000048CA
	public float Distance
	{
		get
		{
			return this._collidedDistance;
		}
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x00031780 File Offset: 0x0002F980
	public bool Detect(Vector3 from, Vector3 to, Vector3 right)
	{
		this._collidedDistance = Vector3.Distance(from, to);
		if ((Time.frameCount & 1) == 0)
		{
			to -= right * this.Offset;
			this._lHitResult = Physics.Linecast(from, to, out this._lRaycastInfo, this.LayerMask);
		}
		else
		{
			to += right * this.Offset;
			this._rHitResult = Physics.Linecast(from, to, out this._rRaycastInfo, this.LayerMask);
		}
		if (this._lHitResult)
		{
			float num = Vector3.Distance(this._lRaycastInfo.point, from);
			if (num < this._collidedDistance)
			{
				this._collidedDistance = num;
			}
		}
		if (this._rHitResult)
		{
			float num2 = Vector3.Distance(this._rRaycastInfo.point, from);
			if (num2 < this._collidedDistance)
			{
				this._collidedDistance = num2;
			}
		}
		return this._lHitResult || this._rHitResult;
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x0003187C File Offset: 0x0002FA7C
	public void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		if (this._lHitResult)
		{
			Gizmos.DrawWireSphere(this._lRaycastInfo.point, 0.1f);
		}
		if (this._rHitResult)
		{
			Gizmos.DrawWireSphere(this._rRaycastInfo.point, 0.1f);
		}
	}

	// Token: 0x04000608 RID: 1544
	private bool _lHitResult;

	// Token: 0x04000609 RID: 1545
	private bool _rHitResult;

	// Token: 0x0400060A RID: 1546
	private RaycastHit _lRaycastInfo;

	// Token: 0x0400060B RID: 1547
	private RaycastHit _rRaycastInfo;

	// Token: 0x0400060C RID: 1548
	private float _collidedDistance;

	// Token: 0x0400060D RID: 1549
	public float Offset;

	// Token: 0x0400060E RID: 1550
	public int LayerMask;
}
