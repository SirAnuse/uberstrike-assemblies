using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x0200046B RID: 1131
public class WeaponSimulator : IWeaponController
{
	// Token: 0x06002047 RID: 8263 RVA: 0x0009A424 File Offset: 0x00098624
	public WeaponSimulator(CharacterConfig character)
	{
		this.character = character;
		this.weaponSlots = new WeaponSlot[4];
		this.CurrentSlotIndex = -1;
	}

	// Token: 0x06002048 RID: 8264 RVA: 0x0009A488 File Offset: 0x00098688
	public Vector3 ShootingPoint(ICharacterState state)
	{
		Vector3 b = ((byte)(this.character.State.MovementState & MoveStates.Ducked) != 0) ? this.CrouchingOffset : this.StandingOffset;
		return state.Position + b;
	}

	// Token: 0x170006FC RID: 1788
	// (get) Token: 0x06002049 RID: 8265 RVA: 0x00003C84 File Offset: 0x00001E84
	public bool IsLocal
	{
		get
		{
			return false;
		}
	}

	// Token: 0x0600204A RID: 8266 RVA: 0x0009A4CC File Offset: 0x000986CC
	public void Update()
	{
		if (this.character.Avatar != null && this.character.State != null && this.character.State.Player.IsAlive && !this.character.IsLocal && this.character.State.Player.IsFiring)
		{
			this.Shoot(this.character.State);
		}
	}

	// Token: 0x0600204B RID: 8267 RVA: 0x0009A550 File Offset: 0x00098750
	public void Shoot(ICharacterState state)
	{
		if (state != null && this._nextShootTime < Time.time && this._currentSlot != null && (!(this._currentSlot.Logic is ProjectileWeapon) || this._currentSlot.View.ItemClass == UberstrikeItemClass.WeaponSplattergun))
		{
			this._nextShootTime = Time.time + WeaponConfigurationHelper.GetRateOfFire(this._currentSlot.View);
			this.BeginShooting();
			CmunePairList<BaseGameProp, ShotPoint> cmunePairList;
			this._currentSlot.Logic.Shoot(new Ray(this.ShootingPoint(state) + GameState.Current.Player.EyePosition, this.ShootingDirection(state)), out cmunePairList);
			this.EndShooting();
		}
	}

	// Token: 0x0600204C RID: 8268 RVA: 0x0009A60C File Offset: 0x0009880C
	public IProjectile EmitProjectile(int actorID, byte playerNumber, Vector3 origin, Vector3 direction, global::LoadoutSlotType slot, int projectileId, bool explode)
	{
		IProjectile result = null;
		if (this.character.Avatar.Decorator != null)
		{
			this.character.Avatar.Decorator.AnimationController.Shoot();
		}
		this.BeginShooting();
		switch (slot)
		{
		case global::LoadoutSlotType.WeaponPrimary:
			result = this.ShootProjectileFromSlot(1, origin, direction, projectileId, explode, actorID);
			break;
		case global::LoadoutSlotType.WeaponSecondary:
			result = this.ShootProjectileFromSlot(2, origin, direction, projectileId, explode, actorID);
			break;
		case global::LoadoutSlotType.WeaponTertiary:
			result = this.ShootProjectileFromSlot(3, origin, direction, projectileId, explode, actorID);
			break;
		}
		this.EndShooting();
		return result;
	}

	// Token: 0x0600204D RID: 8269 RVA: 0x0009A6B8 File Offset: 0x000988B8
	private void BeginShooting()
	{
		foreach (CharacterHitArea characterHitArea in this.character.Avatar.Decorator.HitAreas)
		{
			characterHitArea.gameObject.layer = 2;
		}
	}

	// Token: 0x0600204E RID: 8270 RVA: 0x0009A700 File Offset: 0x00098900
	private void EndShooting()
	{
		foreach (CharacterHitArea characterHitArea in this.character.Avatar.Decorator.HitAreas)
		{
			characterHitArea.gameObject.layer = this.character.Avatar.Decorator.gameObject.layer;
		}
	}

	// Token: 0x0600204F RID: 8271 RVA: 0x0009A760 File Offset: 0x00098960
	private IProjectile ShootProjectileFromSlot(int slot, Vector3 origin, Vector3 direction, int projectileID, bool explode, int actorID)
	{
		if (this.weaponSlots.Length > slot && this.weaponSlots[slot] != null)
		{
			ProjectileWeapon projectileWeapon = this.weaponSlots[slot].Logic as ProjectileWeapon;
			if (projectileWeapon != null)
			{
				projectileWeapon.Decorator.PlayShootSound();
				if (!explode)
				{
					return projectileWeapon.EmitProjectile(new Ray(origin, direction), projectileID, actorID);
				}
				projectileWeapon.ShowExplosionEffect(origin, Vector3.up, direction, projectileID);
			}
		}
		return null;
	}

	// Token: 0x170006FD RID: 1789
	// (get) Token: 0x06002050 RID: 8272 RVA: 0x000153BA File Offset: 0x000135BA
	// (set) Token: 0x06002051 RID: 8273 RVA: 0x000153C2 File Offset: 0x000135C2
	public int CurrentSlotIndex { get; private set; }

	// Token: 0x06002052 RID: 8274 RVA: 0x0009A7DC File Offset: 0x000989DC
	public void UpdateWeaponSlot(int slotIndex, bool showWeapon)
	{
		this.CurrentSlotIndex = slotIndex;
		switch (slotIndex)
		{
		case 0:
			this._currentSlot = this.weaponSlots[0];
			if (showWeapon)
			{
				this.character.Avatar.ShowWeapon(global::LoadoutSlotType.WeaponMelee);
			}
			break;
		case 1:
			this._currentSlot = this.weaponSlots[1];
			if (showWeapon)
			{
				this.character.Avatar.ShowWeapon(global::LoadoutSlotType.WeaponPrimary);
			}
			break;
		case 2:
			this._currentSlot = this.weaponSlots[2];
			if (showWeapon)
			{
				this.character.Avatar.ShowWeapon(global::LoadoutSlotType.WeaponSecondary);
			}
			break;
		case 3:
			this._currentSlot = this.weaponSlots[3];
			if (showWeapon)
			{
				this.character.Avatar.ShowWeapon(global::LoadoutSlotType.WeaponTertiary);
			}
			break;
		}
	}

	// Token: 0x06002053 RID: 8275 RVA: 0x0009A8B8 File Offset: 0x00098AB8
	public void UpdateWeapons(int currentWeaponSlot, IList<int> weaponItemIds)
	{
		if (this.character.Avatar != null)
		{
			IUnityItem[] array = new IUnityItem[]
			{
				Singleton<ItemManager>.Instance.GetItemInShop((weaponItemIds == null || weaponItemIds.Count <= 0) ? 0 : weaponItemIds[0]),
				Singleton<ItemManager>.Instance.GetItemInShop((weaponItemIds == null || weaponItemIds.Count <= 1) ? 0 : weaponItemIds[1]),
				Singleton<ItemManager>.Instance.GetItemInShop((weaponItemIds == null || weaponItemIds.Count <= 2) ? 0 : weaponItemIds[2]),
				Singleton<ItemManager>.Instance.GetItemInShop((weaponItemIds == null || weaponItemIds.Count <= 3) ? 0 : weaponItemIds[3])
			};
			global::LoadoutSlotType[] array2 = new global::LoadoutSlotType[]
			{
				global::LoadoutSlotType.WeaponMelee,
				global::LoadoutSlotType.WeaponPrimary,
				global::LoadoutSlotType.WeaponSecondary,
				global::LoadoutSlotType.WeaponTertiary
			};
			int num = -1;
			for (int i = 0; i < this.weaponSlots.Length; i++)
			{
				if (this.weaponSlots[i] != null && this.weaponSlots[i].Decorator != null)
				{
					UnityEngine.Object.Destroy(this.weaponSlots[i].Decorator.gameObject);
				}
				if (array[i] != null && this.character.Avatar.Decorator.WeaponAttachPoint)
				{
					WeaponSlot weaponSlot = new WeaponSlot(array2[i], array[i], this.character.Avatar.Decorator.WeaponAttachPoint, this);
					if (weaponSlot.Decorator)
					{
						if (num < 0)
						{
							num = i;
						}
						this.character.Avatar.AssignWeapon(array2[i], weaponSlot.Decorator, weaponSlot.UnityItem);
					}
					else
					{
						Debug.LogError("WeaponDecorator is NULL!");
					}
					this.weaponSlots[i] = weaponSlot;
				}
				else
				{
					this.weaponSlots[i] = null;
				}
			}
			if (this.CurrentSlotIndex >= 0 && this.weaponSlots[this.CurrentSlotIndex] != null && this.weaponSlots[this.CurrentSlotIndex].Decorator != null)
			{
				this.weaponSlots[this.CurrentSlotIndex].Decorator.IsEnabled = true;
			}
		}
	}

	// Token: 0x06002054 RID: 8276 RVA: 0x000153CB File Offset: 0x000135CB
	public void UpdateWeaponDecorator(IUnityItem item)
	{
		this.UpdateWeapons((int)this.character.State.Player.CurrentWeaponSlot, this.character.State.Player.Weapons);
	}

	// Token: 0x06002055 RID: 8277 RVA: 0x0009AAFC File Offset: 0x00098CFC
	public int NextProjectileId()
	{
		return ProjectileManager.CreateGlobalProjectileID(this.PlayerNumber, ++this._projectileId);
	}

	// Token: 0x170006FE RID: 1790
	// (get) Token: 0x06002056 RID: 8278 RVA: 0x000153FD File Offset: 0x000135FD
	public int Cmid
	{
		get
		{
			return this.character.State.Player.Cmid;
		}
	}

	// Token: 0x170006FF RID: 1791
	// (get) Token: 0x06002057 RID: 8279 RVA: 0x00015414 File Offset: 0x00013614
	public byte PlayerNumber
	{
		get
		{
			return this.character.State.Player.PlayerId;
		}
	}

	// Token: 0x06002058 RID: 8280 RVA: 0x0009AB28 File Offset: 0x00098D28
	public Vector3 ShootingDirection(ICharacterState state)
	{
		return Quaternion.Euler(state.VerticalRotation, state.HorizontalRotation.eulerAngles.y, 0f) * Vector3.forward;
	}

	// Token: 0x04001B5D RID: 7005
	private CharacterConfig character;

	// Token: 0x04001B5E RID: 7006
	private float _nextShootTime;

	// Token: 0x04001B5F RID: 7007
	private WeaponSlot _currentSlot;

	// Token: 0x04001B60 RID: 7008
	private WeaponSlot[] weaponSlots;

	// Token: 0x04001B61 RID: 7009
	private int _projectileId;

	// Token: 0x04001B62 RID: 7010
	public Vector3 StandingOffset = new Vector3(0f, 0.65f, 0f);

	// Token: 0x04001B63 RID: 7011
	public Vector3 CrouchingOffset = new Vector3(0f, 0.1f, 0f);
}
