using System;
using UnityEngine;

// Token: 0x0200044B RID: 1099
public class GrenadeProjectile : Projectile
{
	// Token: 0x170006A6 RID: 1702
	// (get) Token: 0x06001F42 RID: 8002 RVA: 0x00014A15 File Offset: 0x00012C15
	// (set) Token: 0x06001F43 RID: 8003 RVA: 0x00014A1D File Offset: 0x00012C1D
	public bool Sticky { get; set; }

	// Token: 0x06001F44 RID: 8004 RVA: 0x0009655C File Offset: 0x0009475C
	protected override void Start()
	{
		base.Start();
		if (base.Detonator != null)
		{
			base.Detonator.Direction = Vector3.zero;
		}
		base.Rigidbody.useGravity = true;
		base.Rigidbody.AddRelativeTorque(UnityEngine.Random.insideUnitSphere.normalized * 10f);
	}

	// Token: 0x06001F45 RID: 8005 RVA: 0x000965B8 File Offset: 0x000947B8
	protected override void OnTriggerEnter(Collider c)
	{
		if (!base.IsProjectileExploded)
		{
			if (LayerUtil.IsLayerInMask(UberstrikeLayerMasks.GrenadeCollisionMask, c.gameObject.layer))
			{
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.ID, true);
				GameState.Current.Actions.RemoveProjectile(this.ID, true);
			}
			base.PlayBounceSound(c.transform.position);
		}
	}

	// Token: 0x06001F46 RID: 8006 RVA: 0x00096628 File Offset: 0x00094828
	protected override void OnCollisionEnter(Collision c)
	{
		if (!base.IsProjectileExploded)
		{
			if (LayerUtil.IsLayerInMask(UberstrikeLayerMasks.GrenadeCollisionMask, c.gameObject.layer))
			{
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.ID, true);
				GameState.Current.Actions.RemoveProjectile(this.ID, true);
			}
			else if (this.Sticky)
			{
				base.Rigidbody.isKinematic = true;
				base.collider.isTrigger = true;
				if (c.contacts.Length > 0)
				{
					base.transform.position = c.contacts[0].point + c.contacts[0].normal * base.collider.bounds.extents.sqrMagnitude;
				}
			}
			base.PlayBounceSound(c.transform.position);
		}
	}
}
