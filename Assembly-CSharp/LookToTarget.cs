using System;
using UnityEngine;

// Token: 0x020000D2 RID: 210
public class LookToTarget : MonoBehaviour
{
	// Token: 0x0600077C RID: 1916 RVA: 0x00006C47 File Offset: 0x00004E47
	private void Start()
	{
		this.transformComponent = base.transform;
	}

	// Token: 0x17000232 RID: 562
	// (get) Token: 0x0600077D RID: 1917 RVA: 0x00006C55 File Offset: 0x00004E55
	// (set) Token: 0x0600077E RID: 1918 RVA: 0x00006C5D File Offset: 0x00004E5D
	public Transform follow
	{
		get
		{
			return this._follow;
		}
		set
		{
			this._follow = value;
			base.enabled = (this._follow != null);
		}
	}

	// Token: 0x0600077F RID: 1919 RVA: 0x00033EF8 File Offset: 0x000320F8
	private void Update()
	{
		if (this._follow != null)
		{
			this.transformComponent.position = Vector3.Lerp(this.transformComponent.position, this._follow.position, Time.deltaTime);
			this.transformComponent.rotation = Quaternion.Slerp(this.transformComponent.rotation, Quaternion.LookRotation(this._follow.position - this.transformComponent.position), 0.8f * Time.deltaTime);
		}
		else
		{
			base.enabled = false;
		}
	}

	// Token: 0x04000684 RID: 1668
	private Transform _follow;

	// Token: 0x04000685 RID: 1669
	private Transform transformComponent;
}
