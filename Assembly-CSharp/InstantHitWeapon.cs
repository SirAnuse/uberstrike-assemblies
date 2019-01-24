using System;
using UberStrike.Core.Models.Views;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000464 RID: 1124
public class InstantHitWeapon : BaseWeaponLogic
{
	// Token: 0x06002007 RID: 8199 RVA: 0x000151C0 File Offset: 0x000133C0
	public InstantHitWeapon(WeaponItem item, BaseWeaponDecorator decorator, IWeaponController controller, UberStrikeItemWeaponView view) : base(item, controller)
	{
		this._view = view;
		this._decorator = decorator;
		this._supportIronSight = (view.WeaponSecondaryAction == 2);
	}

	// Token: 0x170006E4 RID: 1764
	// (get) Token: 0x06002008 RID: 8200 RVA: 0x000151F3 File Offset: 0x000133F3
	public override BaseWeaponDecorator Decorator
	{
		get
		{
			return this._decorator;
		}
	}

	// Token: 0x06002009 RID: 8201 RVA: 0x000993A8 File Offset: 0x000975A8
	public override void Shoot(Ray ray, out CmunePairList<BaseGameProp, ShotPoint> hits)
	{
		hits = null;
		Vector3 direction = WeaponDataManager.ApplyDispersion(ray.direction, this._view, this._supportIronSight);
		int projectileId = base.Controller.NextProjectileId();
		RaycastHit raycastHit;
		if (Physics.Raycast(ray.origin, direction, out raycastHit, 1000f, (!base.Controller.IsLocal) ? UberstrikeLayerMasks.ShootMaskRemotePlayer : UberstrikeLayerMasks.ShootMask))
		{
			HitPoint point = new HitPoint(raycastHit.point, TagUtil.GetTag(raycastHit.collider));
			BaseGameProp component = raycastHit.collider.GetComponent<BaseGameProp>();
			if (component)
			{
				hits = new CmunePairList<BaseGameProp, ShotPoint>(1);
				hits.Add(component, new ShotPoint(raycastHit.point, projectileId));
			}
			this.Decorator.PlayImpactSoundAt(point);
		}
		else
		{
			raycastHit.point = ray.origin + ray.direction * 1000f;
		}
		if (this.Decorator)
		{
			this.Decorator.ShowShootEffect(new RaycastHit[]
			{
				raycastHit
			});
		}
		base.OnHits(hits);
	}

	// Token: 0x04001B33 RID: 6963
	private UberStrikeItemWeaponView _view;

	// Token: 0x04001B34 RID: 6964
	private BaseWeaponDecorator _decorator;

	// Token: 0x04001B35 RID: 6965
	private bool _supportIronSight;
}
