using System;
using System.Collections;
using UberStrike.Core.Models.Views;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000469 RID: 1129
public class ProjectileWeapon : BaseWeaponLogic
{
	// Token: 0x06002031 RID: 8241 RVA: 0x00099E58 File Offset: 0x00098058
	public ProjectileWeapon(WeaponItem item, ProjectileWeaponDecorator decorator, IWeaponController controller, UberStrikeItemWeaponView view) : base(item, controller)
	{
		this._view = view;
		this._decorator = decorator;
		this.MaxConcurrentProjectiles = item.Configuration.MaxConcurrentProjectiles;
		this.MinProjectileDistance = item.Configuration.MinProjectileDistance;
		this.ExplosionType = item.Configuration.ParticleEffect;
	}

	// Token: 0x1400002E RID: 46
	// (add) Token: 0x06002032 RID: 8242 RVA: 0x000152FF File Offset: 0x000134FF
	// (remove) Token: 0x06002033 RID: 8243 RVA: 0x00015318 File Offset: 0x00013518
	public event Action<ProjectileInfo> OnProjectileShoot;

	// Token: 0x170006F4 RID: 1780
	// (get) Token: 0x06002034 RID: 8244 RVA: 0x00015331 File Offset: 0x00013531
	public override BaseWeaponDecorator Decorator
	{
		get
		{
			return this._decorator;
		}
	}

	// Token: 0x170006F5 RID: 1781
	// (get) Token: 0x06002035 RID: 8245 RVA: 0x00015339 File Offset: 0x00013539
	// (set) Token: 0x06002036 RID: 8246 RVA: 0x00015341 File Offset: 0x00013541
	public int MaxConcurrentProjectiles { get; private set; }

	// Token: 0x170006F6 RID: 1782
	// (get) Token: 0x06002037 RID: 8247 RVA: 0x0001534A File Offset: 0x0001354A
	// (set) Token: 0x06002038 RID: 8248 RVA: 0x00015352 File Offset: 0x00013552
	public int MinProjectileDistance { get; private set; }

	// Token: 0x170006F7 RID: 1783
	// (get) Token: 0x06002039 RID: 8249 RVA: 0x0001535B File Offset: 0x0001355B
	public override int AmmoCountPerShot
	{
		get
		{
			return this._view.ProjectilesPerShot;
		}
	}

	// Token: 0x170006F8 RID: 1784
	// (get) Token: 0x0600203A RID: 8250 RVA: 0x00015368 File Offset: 0x00013568
	public bool HasProjectileLimit
	{
		get
		{
			return this.MaxConcurrentProjectiles > 0;
		}
	}

	// Token: 0x170006F9 RID: 1785
	// (get) Token: 0x0600203B RID: 8251 RVA: 0x00015373 File Offset: 0x00013573
	// (set) Token: 0x0600203C RID: 8252 RVA: 0x0001537B File Offset: 0x0001357B
	public ParticleConfigurationType ExplosionType { get; private set; }

	// Token: 0x0600203D RID: 8253 RVA: 0x00099EB0 File Offset: 0x000980B0
	public override void Shoot(Ray ray, out CmunePairList<BaseGameProp, ShotPoint> hits)
	{
		hits = null;
		RaycastHit raycastHit;
		if (this.MinProjectileDistance > 0 && Physics.Raycast(ray.origin, ray.direction, out raycastHit, (float)this.MinProjectileDistance, UberstrikeLayerMasks.LocalRocketMask))
		{
			int num = base.Controller.NextProjectileId();
			hits = new CmunePairList<BaseGameProp, ShotPoint>(1);
			hits.Add(null, new ShotPoint(raycastHit.point, num));
			this.ShowExplosionEffect(raycastHit.point, raycastHit.normal, ray.direction, num);
			if (this.OnProjectileShoot != null)
			{
				this.OnProjectileShoot(new ProjectileInfo(num, new Ray(raycastHit.point, -ray.direction)));
			}
		}
		else
		{
			if (this._decorator)
			{
				this._decorator.ShowShootEffect(new RaycastHit[0]);
			}
			UnityRuntime.StartRoutine(this.EmitProjectile(ray));
		}
	}

	// Token: 0x0600203E RID: 8254 RVA: 0x00015384 File Offset: 0x00013584
	public void ShowExplosionEffect(Vector3 position, Vector3 normal, Vector3 direction, int projectileId)
	{
		if (this._decorator)
		{
			this._decorator.ShowExplosionEffect(position, normal, this.ExplosionType);
		}
	}

	// Token: 0x0600203F RID: 8255 RVA: 0x00099FA0 File Offset: 0x000981A0
	private IEnumerator EmitProjectile(Ray ray)
	{
		if (this.AmmoCountPerShot > 1)
		{
			float angle = (float)(360 / this.AmmoCountPerShot);
			for (int i = 0; i < this.AmmoCountPerShot; i++)
			{
				if (this._decorator)
				{
					int shotCount = base.Controller.NextProjectileId();
					ray.origin = this._decorator.MuzzlePosition + Quaternion.AngleAxis(angle * (float)i, this._decorator.transform.forward) * this._decorator.transform.up * 0.2f;
					Projectile p = this.EmitProjectile(ray, shotCount, base.Controller.Cmid);
					if (p && this.OnProjectileShoot != null)
					{
						this.OnProjectileShoot(new ProjectileInfo(shotCount, ray)
						{
							Projectile = p
						});
					}
					yield return new WaitForSeconds(0.2f);
				}
			}
		}
		else
		{
			int shotCount2 = base.Controller.NextProjectileId();
			Projectile p2 = this.EmitProjectile(ray, shotCount2, base.Controller.Cmid);
			if (p2 && this.OnProjectileShoot != null)
			{
				this.OnProjectileShoot(new ProjectileInfo(shotCount2, ray)
				{
					Projectile = p2
				});
			}
		}
		yield break;
	}

	// Token: 0x06002040 RID: 8256 RVA: 0x00099FCC File Offset: 0x000981CC
	public Projectile EmitProjectile(Ray ray, int projectileID, int cmid)
	{
		if (this._decorator && this._decorator.Missle)
		{
			Vector3 muzzlePosition = this._decorator.MuzzlePosition;
			Quaternion rotation = Quaternion.LookRotation(ray.direction);
			Projectile projectile = UnityEngine.Object.Instantiate(this._decorator.Missle, muzzlePosition, rotation) as Projectile;
			if (projectile)
			{
				if (projectile is GrenadeProjectile)
				{
					GrenadeProjectile grenadeProjectile = projectile as GrenadeProjectile;
					grenadeProjectile.Sticky = base.Config.Sticky;
				}
				projectile.transform.parent = ProjectileManager.Container.transform;
				projectile.gameObject.tag = "Prop";
				projectile.ExplosionEffect = this.ExplosionType;
				projectile.TimeOut = this._decorator.MissileTimeOut;
				projectile.SetExplosionSound(this._decorator.ExplosionSound);
				projectile.transform.position = ray.origin + (float)this.MinProjectileDistance * ray.direction;
				if (base.Controller.IsLocal)
				{
					projectile.gameObject.layer = 26;
				}
				else
				{
					projectile.gameObject.layer = 24;
				}
				CharacterConfig characterConfig;
				if (GameState.Current != null && GameState.Current.TryGetPlayerAvatar(cmid, out characterConfig) && characterConfig.Avatar.Decorator && projectile.gameObject.activeSelf)
				{
					foreach (CharacterHitArea characterHitArea in characterConfig.Avatar.Decorator.HitAreas)
					{
						if (characterHitArea.gameObject.activeInHierarchy)
						{
							Physics.IgnoreCollision(projectile.gameObject.collider, characterHitArea.collider);
						}
					}
				}
				projectile.MoveInDirection(ray.direction * WeaponConfigurationHelper.GetProjectileSpeed(this._view));
				return projectile;
			}
		}
		return null;
	}

	// Token: 0x04001B4C RID: 6988
	private UberStrikeItemWeaponView _view;

	// Token: 0x04001B4D RID: 6989
	private ProjectileWeaponDecorator _decorator;
}
