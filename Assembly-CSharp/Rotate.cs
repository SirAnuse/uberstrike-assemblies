using System;
using UnityEngine;

// Token: 0x020003F7 RID: 1015
public class Rotate : MonoBehaviour
{
	// Token: 0x06001D3E RID: 7486 RVA: 0x00013750 File Offset: 0x00011950
	private void Start()
	{
		this._t = base.transform;
	}

	// Token: 0x06001D3F RID: 7487 RVA: 0x0001375E File Offset: 0x0001195E
	private void Update()
	{
		this._t.Rotate(Vector3.up, Time.deltaTime * 2f, Space.Self);
	}

	// Token: 0x06001D40 RID: 7488 RVA: 0x00091D00 File Offset: 0x0008FF00
	private void OnDrawGizmos()
	{
		if (!this._t)
		{
			this._t = base.transform;
		}
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(this._t.position, this._t.forward);
	}

	// Token: 0x040019C0 RID: 6592
	private Transform _t;
}
