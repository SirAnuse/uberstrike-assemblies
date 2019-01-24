using System;
using System.Collections;
using System.Collections.Generic;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x0200044F RID: 1103
public class WeaponController : Singleton<WeaponController>, IWeaponController
{
	// Token: 0x06001F6E RID: 8046 RVA: 0x00096CDC File Offset: 0x00094EDC
	private WeaponController()
	{
		this._weapons = new WeaponSlot[4];
		this._currentSlotID = new CircularInteger(0, 3);
		this.IsEnabled = true;
		global::EventHandler.Global.AddListener<GlobalEvents.InputChanged>(new Action<GlobalEvents.InputChanged>(this.OnInputChanged));
	}

	// Token: 0x170006B2 RID: 1714
	// (get) Token: 0x06001F6F RID: 8047 RVA: 0x00014B73 File Offset: 0x00012D73
	public Dictionary<global::LoadoutSlotType, IUnityItem> LoadoutWeapons
	{
		get
		{
			return this._loadoutWeapons;
		}
	}

	// Token: 0x170006B3 RID: 1715
	// (get) Token: 0x06001F70 RID: 8048 RVA: 0x00014B7B File Offset: 0x00012D7B
	// (set) Token: 0x06001F71 RID: 8049 RVA: 0x00014B83 File Offset: 0x00012D83
	private WeaponSlot _currentSlot
	{
		get
		{
			return this._weapon_current;
		}
		set
		{
			this._weapon_current = value;
			GameState.Current.PlayerData.ActiveWeapon.Value = this._weapon_current;
		}
	}

	// Token: 0x06001F72 RID: 8050 RVA: 0x00096D3C File Offset: 0x00094F3C
	public void LateUpdate()
	{
		if (this._holsterTime > 0f)
		{
			this._holsterTime = Mathf.Max(this._holsterTime - Time.deltaTime, 0f);
		}
		if (this._currentSlot != this._weapons[this._currentSlotID.Current] && this._holsterTime == 0f)
		{
			this._currentSlot = this._weapons[this._currentSlotID.Current];
			this.PutdownCurrentWeapon();
			GameState.Current.PlayerData.SwitchWeaponSlot(this._currentSlotID.Current);
			if (this._currentSlot.Logic != null && this._currentSlot.Decorator != null)
			{
				WeaponFeedbackManager.Instance.PickUp(this._currentSlot);
				this._currentSlot.Decorator.PlayEquipSound();
			}
		}
		if (this.CheckPerformShotConditions() && this._currentSlot != null && this._currentSlot.HasWeapon)
		{
			this._currentSlot.InputHandler.Update();
		}
	}

	// Token: 0x06001F73 RID: 8051 RVA: 0x00014BA6 File Offset: 0x00012DA6
	private void SetSlotWeapon(global::LoadoutSlotType slot, IUnityItem weapon)
	{
		if (weapon != null)
		{
			this._loadoutWeapons[slot] = weapon;
		}
		else if (this._loadoutWeapons.ContainsKey(slot))
		{
			this._loadoutWeapons.Remove(slot);
		}
	}

	// Token: 0x06001F74 RID: 8052 RVA: 0x00096E58 File Offset: 0x00095058
	public void NextWeapon()
	{
		if (!this.HasAnyWeapon)
		{
			return;
		}
		int num = this._currentSlotID.Current;
		int next = this._currentSlotID.Next;
		while (this._weapons[next] == null)
		{
			next = this._currentSlotID.Next;
		}
		if (next != num)
		{
			if (this._currentSlot != null && this._currentSlot.InputHandler != null)
			{
				this._currentSlot.InputHandler.Stop();
				this._currentSlot = null;
			}
			GameState.Current.PlayerData.NextActiveWeapon.Value = this._weapons[next];
		}
	}

	// Token: 0x06001F75 RID: 8053 RVA: 0x00096EFC File Offset: 0x000950FC
	public void PrevWeapon()
	{
		if (!this.HasAnyWeapon)
		{
			return;
		}
		int num = this._currentSlotID.Current;
		int prev = this._currentSlotID.Prev;
		while (this._weapons[prev] == null)
		{
			prev = this._currentSlotID.Prev;
		}
		if (prev != num)
		{
			if (this._currentSlot != null && this._currentSlot.InputHandler != null)
			{
				this._currentSlot.InputHandler.Stop();
				this._currentSlot = null;
			}
			GameState.Current.PlayerData.NextActiveWeapon.Value = this._weapons[prev];
		}
	}

	// Token: 0x06001F76 RID: 8054 RVA: 0x00096FA0 File Offset: 0x000951A0
	public void ShowFirstWeapon()
	{
		this._currentSlotID.Reset();
		if (!this.HasAnyWeapon)
		{
			return;
		}
		if (this._currentSlot != null && this._currentSlot.InputHandler != null)
		{
			this._currentSlot.InputHandler.Stop();
			this._currentSlot = null;
		}
		int next = this._currentSlotID.Next;
		while (this._weapons[next] == null)
		{
			next = this._currentSlotID.Next;
		}
	}

	// Token: 0x06001F77 RID: 8055 RVA: 0x00097020 File Offset: 0x00095220
	public bool CheckWeapons(List<int> weaponIds)
	{
		if (this._weapons.Length != weaponIds.Count)
		{
			return false;
		}
		for (int i = 0; i < weaponIds.Count; i++)
		{
			if (this._weapons[i] == null && weaponIds[i] != 0)
			{
				return false;
			}
			if (this._weapons[i] != null && this._weapons[i].View.ID != weaponIds[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06001F78 RID: 8056 RVA: 0x00014BDE File Offset: 0x00012DDE
	public void PutdownCurrentWeapon()
	{
		WeaponFeedbackManager.Instance.PutDown(false);
	}

	// Token: 0x06001F79 RID: 8057 RVA: 0x00014BEB File Offset: 0x00012DEB
	public void PickupCurrentWeapon()
	{
		if (this._currentSlot != null)
		{
			WeaponFeedbackManager.Instance.PickUp(this._currentSlot);
		}
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x00014C08 File Offset: 0x00012E08
	public bool CheckAmmoCount()
	{
		return AmmoDepot.HasAmmoOfClass(this._currentSlot.View.ItemClass);
	}

	// Token: 0x06001F7B RID: 8059 RVA: 0x000970A4 File Offset: 0x000952A4
	public bool Shoot()
	{
		bool result = false;
		if (this.IsWeaponReady)
		{
			if (this.CheckAmmoCount())
			{
				this._currentSlot.InputHandler.FireHandler.RegisterShot();
				if (!GameFlags.IsFlagSet(GameFlags.GAME_FLAGS.QuickSwitch, GameState.Current.RoomData.GameFlags))
				{
					this._holsterTime = WeaponConfigurationHelper.GetRateOfFire(this._currentSlot.View);
				}
				Ray ray = new Ray(GameState.Current.PlayerData.ShootingPoint + GameState.Current.Player.EyePosition, GameState.Current.PlayerData.ShootingDirection);
				CmunePairList<BaseGameProp, ShotPoint> cmunePairList;
				this._currentSlot.Logic.Shoot(ray, out cmunePairList);
				if (!this._currentSlot.Decorator.HasShootAnimation)
				{
					WeaponFeedbackManager.Instance.Fire();
				}
				AmmoDepot.UseAmmoOfClass(this._currentSlot.View.ItemClass, this._currentSlot.Logic.AmmoCountPerShot);
				GameState.Current.PlayerData.WeaponFired.Value = this._currentSlot;
				result = true;
			}
			else
			{
				this._currentSlot.Decorator.PlayOutOfAmmoSound();
				GameData.Instance.OnNotificationFull.Fire(string.Empty, "Out of ammo!", 1f);
			}
		}
		return result;
	}

	// Token: 0x06001F7C RID: 8060 RVA: 0x00014C1F File Offset: 0x00012E1F
	public WeaponSlot GetPrimaryWeapon()
	{
		return this._weapons[1];
	}

	// Token: 0x06001F7D RID: 8061 RVA: 0x00014C29 File Offset: 0x00012E29
	public WeaponSlot GetCurrentWeapon()
	{
		return this._currentSlot;
	}

	// Token: 0x06001F7E RID: 8062 RVA: 0x000971EC File Offset: 0x000953EC
	public void InitializeAllWeapons(Transform attachPoint)
	{
		for (int i = 0; i < this._weapons.Length; i++)
		{
			if (this._weapons[i] != null && this._weapons[i].Decorator != null)
			{
				UnityEngine.Object.Destroy(this._weapons[i].Decorator.gameObject);
			}
			this._weapons[i] = null;
		}
		for (int j = 0; j < LoadoutManager.WeaponSlots.Length; j++)
		{
			global::LoadoutSlotType slot = LoadoutManager.WeaponSlots[j];
			InventoryItem inventoryItem;
			if (Singleton<LoadoutManager>.Instance.TryGetItemInSlot(slot, out inventoryItem))
			{
				WeaponSlot weaponSlot = new WeaponSlot(slot, inventoryItem.Item, attachPoint, this);
				this.AddGameLogicToWeapon(weaponSlot);
				this._weapons[j] = weaponSlot;
				AmmoDepot.SetMaxAmmoForType(inventoryItem.Item.View.ItemClass, ((UberStrikeItemWeaponView)inventoryItem.Item.View).MaxAmmo);
				AmmoDepot.SetStartAmmoForType(inventoryItem.Item.View.ItemClass, ((UberStrikeItemWeaponView)inventoryItem.Item.View).StartAmmo);
				this.SetSlotWeapon(slot, inventoryItem.Item);
			}
			else
			{
				this.SetSlotWeapon(slot, null);
			}
		}
		GameState.Current.PlayerData.LoadoutWeapons.Value = this.LoadoutWeapons;
		Singleton<QuickItemController>.Instance.Initialize();
		this.Reset();
	}

	// Token: 0x06001F7F RID: 8063 RVA: 0x00014C31 File Offset: 0x00012E31
	public void Reset()
	{
		AmmoDepot.Reset();
		this._currentSlotID.SetRange(0, 3);
		this._currentSlot = null;
		this.ShowFirstWeapon();
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x00003C87 File Offset: 0x00001E87
	public void UpdateWeaponDecorator(IUnityItem item)
	{
	}

	// Token: 0x06001F81 RID: 8065 RVA: 0x00097344 File Offset: 0x00095544
	public bool HasWeaponOfClass(UberstrikeItemClass itemClass)
	{
		for (int i = 0; i < 4; i++)
		{
			WeaponSlot weaponSlot = this._weapons[i];
			if (weaponSlot != null && weaponSlot.HasWeapon && weaponSlot.View.ItemClass == itemClass)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001F82 RID: 8066 RVA: 0x00014C52 File Offset: 0x00012E52
	public void StopInputHandler()
	{
		if (this._currentSlot != null)
		{
			this._currentSlot.InputHandler.Stop();
		}
	}

	// Token: 0x06001F83 RID: 8067 RVA: 0x00097394 File Offset: 0x00095594
	public int NextProjectileId()
	{
		return ProjectileManager.CreateGlobalProjectileID(this.PlayerNumber, ++this._projectileId);
	}

	// Token: 0x170006B4 RID: 1716
	// (get) Token: 0x06001F84 RID: 8068 RVA: 0x00014C6F File Offset: 0x00012E6F
	public byte PlayerNumber
	{
		get
		{
			return GameState.Current.PlayerData.Player.PlayerId;
		}
	}

	// Token: 0x170006B5 RID: 1717
	// (get) Token: 0x06001F85 RID: 8069 RVA: 0x00014C85 File Offset: 0x00012E85
	public int Cmid
	{
		get
		{
			return PlayerDataManager.Cmid;
		}
	}

	// Token: 0x170006B6 RID: 1718
	// (get) Token: 0x06001F86 RID: 8070 RVA: 0x00004D4D File Offset: 0x00002F4D
	public bool IsLocal
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170006B7 RID: 1719
	// (get) Token: 0x06001F87 RID: 8071 RVA: 0x000973C0 File Offset: 0x000955C0
	public bool HasAnyWeapon
	{
		get
		{
			foreach (WeaponSlot weaponSlot in this._weapons)
			{
				if (weaponSlot != null)
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x06001F88 RID: 8072 RVA: 0x000973F8 File Offset: 0x000955F8
	private int GetWeaponCount()
	{
		int num = 0;
		foreach (WeaponSlot weaponSlot in this._weapons)
		{
			if (weaponSlot != null)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x170006B8 RID: 1720
	// (get) Token: 0x06001F89 RID: 8073 RVA: 0x00014C8C File Offset: 0x00012E8C
	public BaseWeaponDecorator CurrentWeapon
	{
		get
		{
			if (this.IsWeaponValid)
			{
				return this._currentSlot.Decorator;
			}
			return null;
		}
	}

	// Token: 0x170006B9 RID: 1721
	// (get) Token: 0x06001F8A RID: 8074 RVA: 0x00014CA6 File Offset: 0x00012EA6
	public bool IsWeaponValid
	{
		get
		{
			return this._currentSlot != null && this._currentSlot.Logic != null && this._currentSlot.Decorator != null;
		}
	}

	// Token: 0x170006BA RID: 1722
	// (get) Token: 0x06001F8B RID: 8075 RVA: 0x00014CD7 File Offset: 0x00012ED7
	public bool IsWeaponReady
	{
		get
		{
			return this.IsWeaponValid && this._currentSlot.InputHandler.FireHandler.CanShoot && this._currentSlot.Logic.IsWeaponActive;
		}
	}

	// Token: 0x170006BB RID: 1723
	// (get) Token: 0x06001F8C RID: 8076 RVA: 0x00014D11 File Offset: 0x00012F11
	public bool IsSecondaryAction
	{
		get
		{
			return this._currentSlot != null && !this._currentSlot.InputHandler.CanChangeWeapon();
		}
	}

	// Token: 0x170006BC RID: 1724
	// (get) Token: 0x06001F8D RID: 8077 RVA: 0x00014D34 File Offset: 0x00012F34
	// (set) Token: 0x06001F8E RID: 8078 RVA: 0x00014D3C File Offset: 0x00012F3C
	public bool IsEnabled { get; set; }

	// Token: 0x170006BD RID: 1725
	// (get) Token: 0x06001F8F RID: 8079 RVA: 0x00014D45 File Offset: 0x00012F45
	public global::LoadoutSlotType CurrentSlot
	{
		get
		{
			return (this._currentSlot == null) ? global::LoadoutSlotType.None : this._currentSlot.Slot;
		}
	}

	// Token: 0x06001F90 RID: 8080 RVA: 0x00097434 File Offset: 0x00095634
	private void OnInputChanged(GlobalEvents.InputChanged ev)
	{
		if (AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled && this.CheckPerformShotConditions())
		{
			switch (ev.Key)
			{
			case GameInputKey.PrimaryFire:
				this.OnPrimaryFire(ev);
				break;
			case GameInputKey.SecondaryFire:
				this.OnSecondaryFire(ev);
				break;
			case GameInputKey.Weapon1:
				this.OnSelectWeapon(ev, global::LoadoutSlotType.WeaponPrimary);
				break;
			case GameInputKey.Weapon2:
				this.OnSelectWeapon(ev, global::LoadoutSlotType.WeaponSecondary);
				break;
			case GameInputKey.Weapon3:
				this.OnSelectWeapon(ev, global::LoadoutSlotType.WeaponTertiary);
				break;
			case GameInputKey.WeaponMelee:
				this.OnSelectWeapon(ev, global::LoadoutSlotType.WeaponMelee);
				break;
			case GameInputKey.NextWeapon:
				this.OnNextWeapon(ev);
				break;
			case GameInputKey.PrevWeapon:
				this.OnPrevWeapon(ev);
				break;
			}
		}
	}

	// Token: 0x06001F91 RID: 8081 RVA: 0x00097508 File Offset: 0x00095708
	private void OnSelectWeapon(GlobalEvents.InputChanged ev, global::LoadoutSlotType slotType)
	{
		if (ev.IsDown && !LevelCamera.IsZoomedIn && slotType != this._weapons[this._currentSlotID.Current].Slot && this.GetWeaponCount() > 1)
		{
			for (int i = 0; i < this._weapons.Length; i++)
			{
				if (this._weapons[i] != null && this._weapons[i].Slot == slotType && this._weapons[i] != this._currentSlot)
				{
					if (this._currentSlot != null)
					{
						this._currentSlot.InputHandler.Stop();
						this._currentSlot = null;
					}
					this._currentSlotID.Current = i;
					GameState.Current.PlayerData.NextActiveWeapon.Value = this._weapons[i];
				}
			}
		}
	}

	// Token: 0x06001F92 RID: 8082 RVA: 0x000975EC File Offset: 0x000957EC
	private void OnPrevWeapon(GlobalEvents.InputChanged ev)
	{
		if ((this._currentSlot == null || (ev.IsDown && this._currentSlot.InputHandler.CanChangeWeapon())) && GUITools.SaveClickIn(0.2f))
		{
			GUITools.Clicked();
			this.NextWeapon();
		}
		else if (this._currentSlot != null && ev.IsDown)
		{
			this._currentSlot.InputHandler.OnPrevWeapon();
		}
	}

	// Token: 0x06001F93 RID: 8083 RVA: 0x0009766C File Offset: 0x0009586C
	private void OnNextWeapon(GlobalEvents.InputChanged ev)
	{
		if ((this._currentSlot == null || (ev.IsDown && this._currentSlot.InputHandler.CanChangeWeapon())) && GUITools.SaveClickIn(0.2f))
		{
			GUITools.Clicked();
			this.PrevWeapon();
		}
		else if (this._currentSlot != null && ev.IsDown)
		{
			this._currentSlot.InputHandler.OnNextWeapon();
		}
	}

	// Token: 0x06001F94 RID: 8084 RVA: 0x000976EC File Offset: 0x000958EC
	private void OnPrimaryFire(GlobalEvents.InputChanged ev)
	{
		if (ev.IsDown)
		{
			if (this._currentSlot != null && this._currentSlot.HasWeapon)
			{
				this._currentSlot.InputHandler.OnPrimaryFire(true);
			}
		}
		else if (this._currentSlot != null)
		{
			this._currentSlot.InputHandler.OnPrimaryFire(false);
		}
	}

	// Token: 0x06001F95 RID: 8085 RVA: 0x00097754 File Offset: 0x00095954
	private void OnSecondaryFire(GlobalEvents.InputChanged ev)
	{
		if (GameState.Current.PlayerData.IsAlive && this.IsEnabled && this._currentSlot != null && this._currentSlot.HasWeapon)
		{
			this._currentSlot.InputHandler.OnSecondaryFire(ev.IsDown);
		}
	}

	// Token: 0x06001F96 RID: 8086 RVA: 0x000977B4 File Offset: 0x000959B4
	private bool CheckPerformShotConditions()
	{
		return this.IsEnabled && GameState.Current.Player != null && GameState.Current.Player.EnableWeaponControl && !GameState.Current.IsPlayerPaused && !GameState.Current.IsPlayerDead;
	}

	// Token: 0x06001F97 RID: 8087 RVA: 0x00097814 File Offset: 0x00095A14
	private IEnumerator StartHidingWeapon(GameObject weapon, bool destroy)
	{
		for (float time = 0f; time < 2f; time += Time.deltaTime)
		{
			yield return new WaitForEndOfFrame();
		}
		if (destroy)
		{
			UnityEngine.Object.Destroy(weapon);
		}
		yield break;
	}

	// Token: 0x06001F98 RID: 8088 RVA: 0x00097844 File Offset: 0x00095A44
	private IEnumerator StartApplyDamage(WeaponSlot slot, float delay, CmunePairList<BaseGameProp, ShotPoint> hits)
	{
		yield return new WaitForSeconds(delay);
		this.ApplyDamage(slot, hits);
		yield break;
	}

	// Token: 0x06001F99 RID: 8089 RVA: 0x0009788C File Offset: 0x00095A8C
	private void ApplyDamage(WeaponSlot slot, CmunePairList<BaseGameProp, ShotPoint> hits)
	{
		foreach (KeyValuePair<BaseGameProp, ShotPoint> keyValuePair in hits)
		{
			DamageInfo damageInfo = new DamageInfo(Convert.ToInt16(slot.View.DamagePerProjectile * keyValuePair.Value.Count))
			{
				Bullets = (byte)keyValuePair.Value.Count,
				Force = GameState.Current.Player.WeaponCamera.transform.forward * (float)(slot.View.DamagePerProjectile * keyValuePair.Value.Count),
				UpwardsForceMultiplier = 10f,
				Hitpoint = keyValuePair.Value.MidPoint,
				ProjectileID = keyValuePair.Value.ProjectileId,
				SlotId = slot.SlotId,
				WeaponID = slot.View.ID,
				WeaponClass = slot.View.ItemClass,
				CriticalStrikeBonus = WeaponConfigurationHelper.GetCriticalStrikeBonus(slot.View)
			};
			if (keyValuePair.Key != null)
			{
				keyValuePair.Key.ApplyDamage(damageInfo);
			}
		}
	}

	// Token: 0x06001F9A RID: 8090 RVA: 0x000979E8 File Offset: 0x00095BE8
	private void AddGameLogicToWeapon(WeaponSlot weapon)
	{
		float movement = WeaponConfigurationHelper.GetRecoilMovement(weapon.View);
		float kickback = WeaponConfigurationHelper.GetRecoilKickback(weapon.View);
		global::LoadoutSlotType slot = weapon.Slot;
		if (weapon.Logic is ProjectileWeapon)
		{
			ProjectileWeapon w = weapon.Logic as ProjectileWeapon;
			w.OnProjectileShoot += delegate(ProjectileInfo p)
			{
				ProjectileDetonator projectileDetonator = new ProjectileDetonator(WeaponConfigurationHelper.GetSplashRadius(weapon.View), (float)weapon.View.DamagePerProjectile, weapon.View.DamageKnockback, p.Direction, weapon.SlotId, p.Id, weapon.View.ID, weapon.View.ItemClass, w.Config.DamageEffectFlag, w.Config.DamageEffectValue);
				if (p.Projectile != null)
				{
					p.Projectile.Detonator = projectileDetonator;
					if (weapon.View.ItemClass != UberstrikeItemClass.WeaponSplattergun)
					{
						GameState.Current.Actions.EmitProjectile(p.Position, p.Direction, slot, p.Id, false);
					}
				}
				else
				{
					projectileDetonator.Explode(p.Position);
					if (weapon.View.ItemClass != UberstrikeItemClass.WeaponSplattergun)
					{
						GameState.Current.Actions.EmitProjectile(p.Position, p.Direction, slot, p.Id, true);
					}
				}
				if (weapon.View.ItemClass != UberstrikeItemClass.WeaponSplattergun)
				{
					if (w.HasProjectileLimit)
					{
						Singleton<ProjectileManager>.Instance.AddLimitedProjectile(p.Projectile, p.Id, w.MaxConcurrentProjectiles);
					}
					else
					{
						Singleton<ProjectileManager>.Instance.AddProjectile(p.Projectile, p.Id);
					}
				}
				LevelCamera.DoFeedback(LevelCamera.FeedbackType.ShootWeapon, Vector3.back, 0f, movement / 8f, 0.1f, 0.3f, kickback / 3f, Vector3.left);
			};
		}
		else if (weapon.Logic is MeleeWeapon)
		{
			float delay = weapon.Logic.HitDelay;
			weapon.Logic.OnTargetHit += delegate(CmunePairList<BaseGameProp, ShotPoint> h)
			{
				if (!weapon.View.HasAutomaticFire)
				{
					GameState.Current.Actions.SingleBulletFire();
				}
				if (h != null)
				{
					UnityRuntime.StartRoutine(this.StartApplyDamage(weapon, delay, h));
				}
				LevelCamera.DoFeedback(LevelCamera.FeedbackType.ShootWeapon, Vector3.back, 0f, movement / 8f, 0.1f, 0.3f, kickback / 3f, Vector3.left);
			};
		}
		else
		{
			weapon.Logic.OnTargetHit += delegate(CmunePairList<BaseGameProp, ShotPoint> h)
			{
				if (!weapon.View.HasAutomaticFire)
				{
					GameState.Current.Actions.SingleBulletFire();
				}
				if (h != null)
				{
					this.ApplyDamage(weapon, h);
				}
				LevelCamera.DoFeedback(LevelCamera.FeedbackType.ShootWeapon, Vector3.back, 0f, movement / 8f, 0.1f, 0.3f, kickback / 3f, Vector3.left);
			};
		}
	}

	// Token: 0x04001AC8 RID: 6856
	private const float _upwardsForceMultiplier = 10f;

	// Token: 0x04001AC9 RID: 6857
	public Property<global::LoadoutSlotType> SelectedLoadout = new Property<global::LoadoutSlotType>();

	// Token: 0x04001ACA RID: 6858
	private Dictionary<global::LoadoutSlotType, IUnityItem> _loadoutWeapons = new Dictionary<global::LoadoutSlotType, IUnityItem>();

	// Token: 0x04001ACB RID: 6859
	private WeaponSlot[] _weapons;

	// Token: 0x04001ACC RID: 6860
	private float _holsterTime;

	// Token: 0x04001ACD RID: 6861
	private CircularInteger _currentSlotID;

	// Token: 0x04001ACE RID: 6862
	private WeaponSlot _weapon_current;

	// Token: 0x04001ACF RID: 6863
	private int _projectileId;
}
