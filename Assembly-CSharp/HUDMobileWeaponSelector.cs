using System;
using System.Collections.Generic;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000318 RID: 792
public class HUDMobileWeaponSelector : MonoBehaviour
{
	// Token: 0x06001625 RID: 5669 RVA: 0x0000EED2 File Offset: 0x0000D0D2
	private void OnEnable()
	{
		GameState.Current.PlayerData.LoadoutWeapons.Fire();
		GameState.Current.PlayerData.ActiveWeapon.Fire();
	}

	// Token: 0x06001626 RID: 5670 RVA: 0x0007B8CC File Offset: 0x00079ACC
	private void Start()
	{
		AutoMonoBehaviour<TouchInput>.Instance.Shooter.IgnoreRect(new Rect((float)Screen.width - 240f, 0f, 240f, 200f));
		this.slots.Add(this.meleeSlot, global::LoadoutSlotType.WeaponMelee);
		this.slots.Add(this.primarySlot, global::LoadoutSlotType.WeaponPrimary);
		this.slots.Add(this.secondarySlot, global::LoadoutSlotType.WeaponSecondary);
		this.slots.Add(this.tertiarySlot, global::LoadoutSlotType.WeaponTertiary);
		this.weapons.Add(UberstrikeItemClass.WeaponMelee, this.melee);
		this.weapons.Add(UberstrikeItemClass.WeaponMachinegun, this.machinegun);
		this.weapons.Add(UberstrikeItemClass.WeaponShotgun, this.shotgun);
		this.weapons.Add(UberstrikeItemClass.WeaponSniperRifle, this.sniper);
		this.weapons.Add(UberstrikeItemClass.WeaponCannon, this.cannon);
		this.weapons.Add(UberstrikeItemClass.WeaponSplattergun, this.splattergun);
		this.weapons.Add(UberstrikeItemClass.WeaponLauncher, this.launcher);
		this.scrollList.SelectedElement.AddEvent(delegate(GameObject el)
		{
			if (el != null && this.slots.ContainsKey(el))
			{
				GameInputKey key;
				switch (this.slots[el])
				{
				case global::LoadoutSlotType.WeaponMelee:
					key = GameInputKey.WeaponMelee;
					break;
				case global::LoadoutSlotType.WeaponPrimary:
					key = GameInputKey.Weapon1;
					break;
				case global::LoadoutSlotType.WeaponSecondary:
					key = GameInputKey.Weapon2;
					break;
				case global::LoadoutSlotType.WeaponTertiary:
					key = GameInputKey.Weapon3;
					break;
				default:
					Debug.LogError("Cannot switch to unknown slot!");
					return;
				}
				global::EventHandler.Global.Fire(new GlobalEvents.InputChanged(key, 1f));
			}
		}, this);
		GameState.Current.PlayerData.LoadoutWeapons.AddEventAndFire(new Action<Dictionary<global::LoadoutSlotType, IUnityItem>>(this.LoadWeaponList), this);
		GameState.Current.PlayerData.ActiveWeapon.AddEventAndFire(delegate(WeaponSlot el)
		{
			if (el != null)
			{
				this.scrollList.SpringToElement(this.ElementAtSlot(el.Slot), 100f);
			}
		}, this);
	}

	// Token: 0x06001627 RID: 5671 RVA: 0x0007BA30 File Offset: 0x00079C30
	private void LoadWeaponList(Dictionary<global::LoadoutSlotType, IUnityItem> loadoutWeapons)
	{
		if (loadoutWeapons == null)
		{
			return;
		}
		foreach (GameObject weapon in this.weapons.Values)
		{
			this.UnloadWeapon(weapon);
		}
		List<GameObject> list = new List<GameObject>();
		foreach (KeyValuePair<global::LoadoutSlotType, IUnityItem> keyValuePair in loadoutWeapons)
		{
			GameObject gameObject = this.ElementAtSlot(keyValuePair.Key);
			this.LoadWeapon(keyValuePair.Value.View.ItemClass, gameObject);
			if (keyValuePair.Value != null && gameObject != null)
			{
				list.Add(gameObject);
			}
		}
		this.scrollList.SetActiveElements(list);
	}

	// Token: 0x06001628 RID: 5672 RVA: 0x0000EEFC File Offset: 0x0000D0FC
	private void UnloadWeapon(GameObject weapon)
	{
		weapon.transform.parent = this.disableSlot.transform;
	}

	// Token: 0x06001629 RID: 5673 RVA: 0x0007BB30 File Offset: 0x00079D30
	private void LoadWeapon(UberstrikeItemClass weaponClass, GameObject slot)
	{
		if (this.weapons.ContainsKey(weaponClass))
		{
			this.weapons[weaponClass].transform.parent = slot.transform;
			this.weapons[weaponClass].transform.localPosition = Vector3.zero;
		}
	}

	// Token: 0x0600162A RID: 5674 RVA: 0x0007BB88 File Offset: 0x00079D88
	private GameObject ElementAtSlot(global::LoadoutSlotType slot)
	{
		switch (slot)
		{
		case global::LoadoutSlotType.WeaponMelee:
			return this.meleeSlot;
		case global::LoadoutSlotType.WeaponPrimary:
			return this.primarySlot;
		case global::LoadoutSlotType.WeaponSecondary:
			return this.secondarySlot;
		case global::LoadoutSlotType.WeaponTertiary:
			return this.tertiarySlot;
		default:
			return null;
		}
	}

	// Token: 0x0600162B RID: 5675 RVA: 0x0000EF14 File Offset: 0x0000D114
	public void Show(bool show)
	{
		this.scrollList.Panel.panel.alpha = (float)((!show) ? 0 : 1);
		this.selectorBackground.SetActive(show);
	}

	// Token: 0x040014E8 RID: 5352
	[SerializeField]
	private NGUIScrollList scrollList;

	// Token: 0x040014E9 RID: 5353
	[SerializeField]
	private GameObject melee;

	// Token: 0x040014EA RID: 5354
	[SerializeField]
	private GameObject machinegun;

	// Token: 0x040014EB RID: 5355
	[SerializeField]
	private GameObject shotgun;

	// Token: 0x040014EC RID: 5356
	[SerializeField]
	private GameObject sniper;

	// Token: 0x040014ED RID: 5357
	[SerializeField]
	private GameObject cannon;

	// Token: 0x040014EE RID: 5358
	[SerializeField]
	private GameObject splattergun;

	// Token: 0x040014EF RID: 5359
	[SerializeField]
	private GameObject launcher;

	// Token: 0x040014F0 RID: 5360
	[SerializeField]
	private GameObject meleeSlot;

	// Token: 0x040014F1 RID: 5361
	[SerializeField]
	private GameObject primarySlot;

	// Token: 0x040014F2 RID: 5362
	[SerializeField]
	private GameObject secondarySlot;

	// Token: 0x040014F3 RID: 5363
	[SerializeField]
	private GameObject tertiarySlot;

	// Token: 0x040014F4 RID: 5364
	[SerializeField]
	private GameObject disableSlot;

	// Token: 0x040014F5 RID: 5365
	[SerializeField]
	private GameObject selectorBackground;

	// Token: 0x040014F6 RID: 5366
	private Dictionary<GameObject, global::LoadoutSlotType> slots = new Dictionary<GameObject, global::LoadoutSlotType>();

	// Token: 0x040014F7 RID: 5367
	private Dictionary<UberstrikeItemClass, GameObject> weapons = new Dictionary<UberstrikeItemClass, GameObject>();
}
