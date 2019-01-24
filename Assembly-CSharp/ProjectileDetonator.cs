using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class ProjectileDetonator
{
	// Token: 0x06002019 RID: 8217 RVA: 0x00099B4C File Offset: 0x00097D4C
	public ProjectileDetonator(float radius, float damage, int force, Vector3 direction, byte slot, int projectileId, int weaponId, UberstrikeItemClass weaponClass, DamageEffectType damageEffectFlag, float damageEffectValue)
	{
		this.Radius = radius;
		this.Damage = damage;
		this.Force = force;
		this.Direction = direction;
		this.Slot = slot;
		this.ProjectileID = projectileId;
		this.WeaponID = weaponId;
		this.WeaponClass = weaponClass;
		this.DamageEffectFlag = damageEffectFlag;
		this.DamageEffectValue = damageEffectValue;
	}

	// Token: 0x170006EA RID: 1770
	// (get) Token: 0x0600201A RID: 8218 RVA: 0x00015255 File Offset: 0x00013455
	// (set) Token: 0x0600201B RID: 8219 RVA: 0x0001525D File Offset: 0x0001345D
	public float Radius { get; private set; }

	// Token: 0x170006EB RID: 1771
	// (get) Token: 0x0600201C RID: 8220 RVA: 0x00015266 File Offset: 0x00013466
	// (set) Token: 0x0600201D RID: 8221 RVA: 0x0001526E File Offset: 0x0001346E
	public float Damage { get; private set; }

	// Token: 0x170006EC RID: 1772
	// (get) Token: 0x0600201E RID: 8222 RVA: 0x00015277 File Offset: 0x00013477
	// (set) Token: 0x0600201F RID: 8223 RVA: 0x0001527F File Offset: 0x0001347F
	public int Force { get; private set; }

	// Token: 0x170006ED RID: 1773
	// (get) Token: 0x06002020 RID: 8224 RVA: 0x00015288 File Offset: 0x00013488
	// (set) Token: 0x06002021 RID: 8225 RVA: 0x00015290 File Offset: 0x00013490
	public Vector3 Direction { get; set; }

	// Token: 0x170006EE RID: 1774
	// (get) Token: 0x06002022 RID: 8226 RVA: 0x00015299 File Offset: 0x00013499
	// (set) Token: 0x06002023 RID: 8227 RVA: 0x000152A1 File Offset: 0x000134A1
	public int WeaponID { get; private set; }

	// Token: 0x170006EF RID: 1775
	// (get) Token: 0x06002024 RID: 8228 RVA: 0x000152AA File Offset: 0x000134AA
	// (set) Token: 0x06002025 RID: 8229 RVA: 0x000152B2 File Offset: 0x000134B2
	public UberstrikeItemClass WeaponClass { get; private set; }

	// Token: 0x170006F0 RID: 1776
	// (get) Token: 0x06002026 RID: 8230 RVA: 0x000152BB File Offset: 0x000134BB
	// (set) Token: 0x06002027 RID: 8231 RVA: 0x000152C3 File Offset: 0x000134C3
	public int ProjectileID { get; private set; }

	// Token: 0x170006F1 RID: 1777
	// (get) Token: 0x06002028 RID: 8232 RVA: 0x000152CC File Offset: 0x000134CC
	// (set) Token: 0x06002029 RID: 8233 RVA: 0x000152D4 File Offset: 0x000134D4
	public DamageEffectType DamageEffectFlag { get; private set; }

	// Token: 0x170006F2 RID: 1778
	// (get) Token: 0x0600202A RID: 8234 RVA: 0x000152DD File Offset: 0x000134DD
	// (set) Token: 0x0600202B RID: 8235 RVA: 0x000152E5 File Offset: 0x000134E5
	public float DamageEffectValue { get; private set; }

	// Token: 0x170006F3 RID: 1779
	// (get) Token: 0x0600202C RID: 8236 RVA: 0x000152EE File Offset: 0x000134EE
	// (set) Token: 0x0600202D RID: 8237 RVA: 0x000152F6 File Offset: 0x000134F6
	public byte Slot { get; private set; }

	// Token: 0x0600202E RID: 8238 RVA: 0x00099BAC File Offset: 0x00097DAC
	public void Explode(Vector3 position)
	{
		ProjectileDetonator.Explode(position, this.ProjectileID, this.Damage, this.Direction, this.Radius, this.Force, this.Slot, this.WeaponID, this.WeaponClass, this.DamageEffectFlag, this.DamageEffectValue);
	}

	// Token: 0x0600202F RID: 8239 RVA: 0x00099BFC File Offset: 0x00097DFC
	public static void Explode(Vector3 position, int projectileId, float damage, Vector3 dir, float radius, int force, byte slot, int weaponId, UberstrikeItemClass weaponClass, DamageEffectType damageEffectFlag = DamageEffectType.None, float damageEffectValue = 0f)
	{
		Collider[] array = Physics.OverlapSphere(position, radius, UberstrikeLayerMasks.ExplosionMask);
		foreach (Collider collider in array)
		{
			BaseGameProp component = collider.transform.GetComponent<BaseGameProp>();
			if (component != null && component.RecieveProjectileDamage)
			{
				ProjectileDetonator.DoExplosionDamage(component, position, collider.bounds.center, projectileId, damage, dir, radius, force, slot, weaponId, weaponClass, damageEffectFlag, damageEffectValue);
			}
		}
		if (Vector3.Distance(position, GameState.Current.Player.transform.position) < radius)
		{
			ProjectileDetonator.DoExplosionDamage(GameState.Current.Player.Character, position, GameState.Current.Player.transform.position, projectileId, damage, dir, radius, force, slot, weaponId, weaponClass, damageEffectFlag, damageEffectValue);
		}
	}

	// Token: 0x06002030 RID: 8240 RVA: 0x00099CDC File Offset: 0x00097EDC
	private static void DoExplosionDamage(IShootable shootable, Vector3 explosionPoint, Vector3 hitPoint, int projectileId, float damage, Vector3 dir, float radius, int force, byte slot, int weaponId, UberstrikeItemClass weaponClass, DamageEffectType damageEffectFlag, float damageEffectValue)
	{
		RaycastHit raycastHit;
		if (!Physics.Linecast(explosionPoint, hitPoint, out raycastHit, UberstrikeLayerMasks.ProtectionMask) || raycastHit.transform == shootable.Transform || raycastHit.transform.GetComponent<BaseGameProp>() != null)
		{
			float num = (radius <= 1f) ? 0f : Mathf.Floor(Mathf.Clamp((hitPoint - explosionPoint).magnitude, 0f, radius));
			Vector3 vector = (hitPoint - explosionPoint).normalized;
			if (num < 0.01f)
			{
				vector = dir.normalized;
			}
			else if (Vector3.Angle(vector, Vector3.up) < 30f)
			{
				vector = Vector3.up;
				num = 0f;
			}
			short num2 = Convert.ToInt16(damage * (radius - num) / radius);
			Vector3 vector2 = vector;
			if (shootable.IsLocal)
			{
				vector2 *= (float)force;
				num2 /= 2;
			}
			shootable.ApplyDamage(new DamageInfo(num2)
			{
				Force = vector2,
				UpwardsForceMultiplier = 5f,
				Hitpoint = hitPoint,
				ProjectileID = projectileId,
				SlotId = slot,
				WeaponID = weaponId,
				WeaponClass = weaponClass,
				DamageEffectFlag = damageEffectFlag,
				DamageEffectValue = damageEffectValue,
				Distance = (byte)Mathf.Clamp(Mathf.CeilToInt(num), 0, 255)
			});
		}
	}

	// Token: 0x04001B41 RID: 6977
	private const float _upwardsForceMultiplier = 5f;
}
