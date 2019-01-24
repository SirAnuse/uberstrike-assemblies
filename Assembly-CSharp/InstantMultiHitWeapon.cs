using System;
using System.Collections.Generic;
using UberStrike.Core.Models.Views;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000465 RID: 1125
public class InstantMultiHitWeapon : BaseWeaponLogic
{
	// Token: 0x0600200A RID: 8202 RVA: 0x000151FB File Offset: 0x000133FB
	public InstantMultiHitWeapon(WeaponItem item, BaseWeaponDecorator decorator, int shotGauge, IWeaponController controller, UberStrikeItemWeaponView view) : base(item, controller)
	{
		this.ShotgunGauge = shotGauge;
		this._view = view;
		this._decorator = decorator;
	}

	// Token: 0x170006E5 RID: 1765
	// (get) Token: 0x0600200B RID: 8203 RVA: 0x0001521C File Offset: 0x0001341C
	public override BaseWeaponDecorator Decorator
	{
		get
		{
			return this._decorator;
		}
	}

	// Token: 0x0600200C RID: 8204 RVA: 0x000994D4 File Offset: 0x000976D4
	public override void Shoot(Ray ray, out CmunePairList<BaseGameProp, ShotPoint> hits)
	{
		Dictionary<BaseGameProp, ShotPoint> dictionary = new Dictionary<BaseGameProp, ShotPoint>(this.ShotgunGauge);
		HitPoint hitPoint = null;
		RaycastHit[] array = new RaycastHit[this.ShotgunGauge];
		int projectileId = base.Controller.NextProjectileId();
		int num = 1000;
		for (int i = 0; i < this.ShotgunGauge; i++)
		{
			Vector3 direction = WeaponDataManager.ApplyDispersion(ray.direction, this._view, false);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray.origin, direction, out raycastHit, (float)num, (!base.Controller.IsLocal) ? UberstrikeLayerMasks.ShootMaskRemotePlayer : UberstrikeLayerMasks.ShootMask))
			{
				if (hitPoint == null)
				{
					hitPoint = new HitPoint(raycastHit.point, TagUtil.GetTag(raycastHit.collider));
				}
				BaseGameProp component = raycastHit.collider.GetComponent<BaseGameProp>();
				if (component)
				{
					ShotPoint shotPoint;
					if (dictionary.TryGetValue(component, out shotPoint))
					{
						shotPoint.AddPoint(raycastHit.point);
					}
					else
					{
						dictionary.Add(component, new ShotPoint(raycastHit.point, projectileId));
					}
				}
				array[i] = raycastHit;
			}
			else
			{
				array[i].point = ray.origin + ray.direction * 1000f;
				array[i].normal = raycastHit.normal;
			}
		}
		this.Decorator.PlayImpactSoundAt(hitPoint);
		hits = new CmunePairList<BaseGameProp, ShotPoint>(dictionary.Count);
		foreach (KeyValuePair<BaseGameProp, ShotPoint> keyValuePair in dictionary)
		{
			hits.Add(keyValuePair.Key, keyValuePair.Value);
		}
		if (this.Decorator)
		{
			this.Decorator.ShowShootEffect(array);
		}
		base.OnHits(hits);
	}

	// Token: 0x04001B36 RID: 6966
	private UberStrikeItemWeaponView _view;

	// Token: 0x04001B37 RID: 6967
	private int ShotgunGauge;

	// Token: 0x04001B38 RID: 6968
	private BaseWeaponDecorator _decorator;
}
