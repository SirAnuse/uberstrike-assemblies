using System;
using System.Collections;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class MeleeWeapon : BaseWeaponLogic
{
	// Token: 0x0600200D RID: 8205 RVA: 0x00015224 File Offset: 0x00013424
	public MeleeWeapon(WeaponItem item, MeleeWeaponDecorator decorator, IWeaponController controller) : base(item, controller)
	{
		this._decorator = decorator;
	}

	// Token: 0x170006E6 RID: 1766
	// (get) Token: 0x0600200E RID: 8206 RVA: 0x00015235 File Offset: 0x00013435
	public override BaseWeaponDecorator Decorator
	{
		get
		{
			return this._decorator;
		}
	}

	// Token: 0x170006E7 RID: 1767
	// (get) Token: 0x0600200F RID: 8207 RVA: 0x0001523D File Offset: 0x0001343D
	public override float HitDelay
	{
		get
		{
			return 0.2f;
		}
	}

	// Token: 0x06002010 RID: 8208 RVA: 0x000996D8 File Offset: 0x000978D8
	public override void Shoot(Ray ray, out CmunePairList<BaseGameProp, ShotPoint> hits)
	{
		Vector3 origin = ray.origin;
		origin.y -= 0.1f;
		ray.origin = origin;
		hits = null;
		float radius = 1f;
		int layerMask = (!base.Controller.IsLocal) ? UberstrikeLayerMasks.ShootMaskRemotePlayer : UberstrikeLayerMasks.ShootMask;
		float distance = 1f;
		RaycastHit[] array = Physics.SphereCastAll(ray, radius, distance, layerMask);
		int projectileId = base.Controller.NextProjectileId();
		if (array != null && array.Length > 0)
		{
			hits = new CmunePairList<BaseGameProp, ShotPoint>();
			float num = float.PositiveInfinity;
			RaycastHit hit = array[0];
			foreach (RaycastHit raycastHit in array)
			{
				Vector3 rhs = raycastHit.point - ray.origin;
				if (Vector3.Dot(ray.direction, rhs) > 0f && raycastHit.distance < num)
				{
					num = raycastHit.distance;
					hit = raycastHit;
				}
			}
			if (hit.collider)
			{
				BaseGameProp component = hit.collider.GetComponent<BaseGameProp>();
				if (component != null)
				{
					hits.Add(component, new ShotPoint(hit.point, projectileId));
				}
				if (this._decorator)
				{
					this._decorator.StartCoroutine(this.StartShowingEffect(hit, ray.origin, this.HitDelay));
				}
			}
		}
		else if (this._decorator)
		{
			this._decorator.ShowShootEffect(new RaycastHit[0]);
		}
		this.EmitWaterImpactParticles(ray, radius);
		base.OnHits(hits);
	}

	// Token: 0x06002011 RID: 8209 RVA: 0x00099898 File Offset: 0x00097A98
	private IEnumerator StartShowingEffect(RaycastHit hit, Vector3 origin, float delay)
	{
		if (this._decorator)
		{
			this._decorator.ShowShootEffect(new RaycastHit[]
			{
				hit
			});
		}
		yield return new WaitForSeconds(delay);
		this.Decorator.PlayImpactSoundAt(new HitPoint(hit.point, TagUtil.GetTag(hit.collider)));
		yield break;
	}

	// Token: 0x06002012 RID: 8210 RVA: 0x000998D0 File Offset: 0x00097AD0
	private void EmitWaterImpactParticles(Ray ray, float radius)
	{
		Vector3 origin = ray.origin;
		Vector3 vector = origin + ray.direction * radius;
		if (GameState.Current.Map != null && GameState.Current.Map.HasWaterPlane && ((origin.y > GameState.Current.Map.WaterPlaneHeight && vector.y < GameState.Current.Map.WaterPlaneHeight) || (origin.y < GameState.Current.Map.WaterPlaneHeight && vector.y > GameState.Current.Map.WaterPlaneHeight)))
		{
			Vector3 hitPoint = vector;
			hitPoint.y = GameState.Current.Map.WaterPlaneHeight;
			if (!Mathf.Approximately(ray.direction.y, 0f))
			{
				hitPoint.x = (GameState.Current.Map.WaterPlaneHeight - vector.y) / ray.direction.y * ray.direction.x + vector.x;
				hitPoint.z = (GameState.Current.Map.WaterPlaneHeight - vector.y) / ray.direction.y * ray.direction.z + vector.z;
			}
			MoveTrailrendererObject trailRenderer = this.Decorator.TrailRenderer;
			ParticleEffectController.ShowHitEffect(ParticleConfigurationType.MeleeDefault, SurfaceEffectType.WaterEffect, Vector3.up, hitPoint, Vector3.up, origin, 1f, ref trailRenderer, this.Decorator.transform);
		}
	}

	// Token: 0x04001B39 RID: 6969
	private MeleeWeaponDecorator _decorator;
}
