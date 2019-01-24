using System;
using UnityEngine;

// Token: 0x02000219 RID: 537
public class BaseGameProp : MonoBehaviour, IShootable
{
	// Token: 0x1700036D RID: 877
	// (get) Token: 0x06000ED1 RID: 3793 RVA: 0x0000AB2F File Offset: 0x00008D2F
	public bool RecieveProjectileDamage
	{
		get
		{
			return this._recieveProjectileDamage;
		}
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x00004D4D File Offset: 0x00002F4D
	public virtual bool IsVulnerable
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06000ED3 RID: 3795 RVA: 0x00003C84 File Offset: 0x00001E84
	public virtual bool IsLocal
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000370 RID: 880
	// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x0000AB37 File Offset: 0x00008D37
	public Transform Transform
	{
		get
		{
			return base.transform;
		}
	}

	// Token: 0x06000ED5 RID: 3797 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void ApplyDamage(DamageInfo damageInfo)
	{
	}

	// Token: 0x06000ED6 RID: 3798 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void ApplyForce(Vector3 position, Vector3 force)
	{
	}

	// Token: 0x04000D3F RID: 3391
	[SerializeField]
	protected bool _recieveProjectileDamage = true;
}
