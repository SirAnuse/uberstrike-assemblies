using System;
using System.Collections.Generic;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class Avatar
{
	// Token: 0x060017E8 RID: 6120 RVA: 0x000815C8 File Offset: 0x0007F7C8
	public Avatar(Loadout loadout, bool local)
	{
		this._isLocal = local;
		this._weapons = new Dictionary<global::LoadoutSlotType, BaseWeaponDecorator>();
		this.SetLoadout(loadout);
	}

	// Token: 0x1400000E RID: 14
	// (add) Token: 0x060017E9 RID: 6121 RVA: 0x0001019E File Offset: 0x0000E39E
	// (remove) Token: 0x060017EA RID: 6122 RVA: 0x000101B7 File Offset: 0x0000E3B7
	public event Action OnDecoratorChanged = delegate()
	{
	};

	// Token: 0x1700057B RID: 1403
	// (get) Token: 0x060017EB RID: 6123 RVA: 0x000101D0 File Offset: 0x0000E3D0
	// (set) Token: 0x060017EC RID: 6124 RVA: 0x000101D8 File Offset: 0x0000E3D8
	public Loadout Loadout { get; private set; }

	// Token: 0x1700057C RID: 1404
	// (get) Token: 0x060017ED RID: 6125 RVA: 0x000101E1 File Offset: 0x0000E3E1
	// (set) Token: 0x060017EE RID: 6126 RVA: 0x000101E9 File Offset: 0x0000E3E9
	public AvatarDecorator Decorator { get; private set; }

	// Token: 0x1700057D RID: 1405
	// (get) Token: 0x060017EF RID: 6127 RVA: 0x000101F2 File Offset: 0x0000E3F2
	// (set) Token: 0x060017F0 RID: 6128 RVA: 0x000101FA File Offset: 0x0000E3FA
	public AvatarDecoratorConfig Ragdoll { get; private set; }

	// Token: 0x060017F1 RID: 6129 RVA: 0x00010203 File Offset: 0x0000E403
	public void SetDecorator(AvatarDecorator decorator)
	{
		this.Decorator = decorator;
		this.OnDecoratorChanged();
	}

	// Token: 0x060017F2 RID: 6130 RVA: 0x00081618 File Offset: 0x0007F818
	public void SetLoadout(Loadout loadout)
	{
		if (this.Loadout != null)
		{
			this.Loadout.ClearAllSlots();
			this.Loadout.OnGearChanged -= this.RebuildDecorator;
			this.Loadout.OnWeaponChanged -= this.UpdateWeapon;
		}
		this.Loadout = loadout;
		this.Loadout.OnGearChanged += this.RebuildDecorator;
		this.Loadout.OnWeaponChanged += this.UpdateWeapon;
		this.RebuildDecorator();
	}

	// Token: 0x060017F3 RID: 6131 RVA: 0x000816A4 File Offset: 0x0007F8A4
	public void RebuildDecorator()
	{
		if (!this.Decorator)
		{
			return;
		}
		AvatarGearParts avatarGear = this.Loadout.GetAvatarGear();
		if (this._isLocal)
		{
			global::AvatarBuilder.UpdateLocalAvatar(avatarGear);
		}
		else
		{
			this.SetDecorator(global::AvatarBuilder.UpdateRemoteAvatar(this.Decorator, avatarGear, Color.white));
		}
	}

	// Token: 0x060017F4 RID: 6132 RVA: 0x000816FC File Offset: 0x0007F8FC
	public void CleanupRagdoll()
	{
		if (this.Ragdoll)
		{
			global::AvatarBuilder.Destroy(this.Ragdoll.gameObject);
			this.Ragdoll = null;
			if (this.Decorator && this.Decorator.gameObject)
			{
				this.Decorator.gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x060017F5 RID: 6133 RVA: 0x00081768 File Offset: 0x0007F968
	public void SpawnRagdoll(DamageInfo damageInfo)
	{
		AvatarGearParts ragdollGear = this.Loadout.GetRagdollGear();
		this.Ragdoll = global::AvatarBuilder.InstantiateRagdoll(ragdollGear, this.Decorator.Configuration.GetSkinColor());
		try
		{
			ragdollGear.DestroyGearParts();
			this.Ragdoll.transform.position = this.Decorator.transform.position;
			this.Ragdoll.transform.rotation = this.Decorator.transform.rotation;
			AvatarDecoratorConfig.CopyBones(this.Decorator.Configuration, this.Ragdoll);
			foreach (ArrowProjectile arrowProjectile in this.Decorator.GetComponentsInChildren<ArrowProjectile>(true))
			{
				Vector3 localPosition = arrowProjectile.transform.localPosition;
				Quaternion localRotation = arrowProjectile.transform.localRotation;
				arrowProjectile.transform.parent = this.Ragdoll.GetBone(BoneIndex.Hips);
				arrowProjectile.transform.localPosition = localPosition;
				arrowProjectile.transform.localRotation = localRotation;
			}
			foreach (Rigidbody rigidbody in this.Ragdoll.GetComponentsInChildren<Rigidbody>(true))
			{
				if (rigidbody.gameObject.GetComponent<RagdollBodyPart>() == null)
				{
					rigidbody.gameObject.AddComponent<RagdollBodyPart>();
				}
			}
			this.Ragdoll.ApplyDamageToRagdoll(damageInfo);
			this.Decorator.gameObject.SetActive(false);
		}
		catch (Exception message)
		{
			Debug.LogWarning(message);
		}
	}

	// Token: 0x060017F6 RID: 6134 RVA: 0x00010217 File Offset: 0x0000E417
	public void UpdateAllWeapons()
	{
		this.UpdateWeapon(global::LoadoutSlotType.WeaponMelee);
		this.UpdateWeapon(global::LoadoutSlotType.WeaponPrimary);
		this.UpdateWeapon(global::LoadoutSlotType.WeaponSecondary);
		this.UpdateWeapon(global::LoadoutSlotType.WeaponTertiary);
	}

	// Token: 0x060017F7 RID: 6135 RVA: 0x00081908 File Offset: 0x0007FB08
	private void UpdateWeapon(global::LoadoutSlotType slot)
	{
		IUnityItem unityItem;
		if (this.Loadout.TryGetItem(slot, out unityItem) && this.Decorator && this.Decorator.WeaponAttachPoint)
		{
			GameObject gameObject = unityItem.Create(this.Decorator.WeaponAttachPoint.position, this.Decorator.WeaponAttachPoint.rotation);
			if (gameObject)
			{
				this.AssignWeapon(slot, gameObject.GetComponent<BaseWeaponDecorator>(), unityItem);
			}
		}
	}

	// Token: 0x060017F8 RID: 6136 RVA: 0x00081990 File Offset: 0x0007FB90
	public void AssignWeapon(global::LoadoutSlotType slot, BaseWeaponDecorator weapon, IUnityItem item)
	{
		if (weapon)
		{
			BaseWeaponDecorator baseWeaponDecorator;
			if (this._weapons.TryGetValue(slot, out baseWeaponDecorator) && baseWeaponDecorator)
			{
				UnityEngine.Object.Destroy(baseWeaponDecorator.gameObject);
			}
			this._weapons[slot] = weapon;
			weapon.transform.parent = this.Decorator.WeaponAttachPoint;
			foreach (Transform transform in weapon.gameObject.transform.GetComponentsInChildren<Transform>(true))
			{
				if (transform.gameObject.name == "Head")
				{
					transform.gameObject.name = "WeaponHead";
				}
			}
			LayerUtil.SetLayerRecursively(weapon.gameObject.transform, this.Decorator.gameObject.layer);
			weapon.transform.localPosition = Vector3.zero;
			weapon.transform.localRotation = Quaternion.identity;
			weapon.IsEnabled = (slot == this.CurrentWeaponSlot);
			weapon.WeaponClass = item.View.ItemClass;
		}
		else
		{
			this.UnassignWeapon(slot);
		}
	}

	// Token: 0x1700057E RID: 1406
	// (get) Token: 0x060017F9 RID: 6137 RVA: 0x00010237 File Offset: 0x0000E437
	// (set) Token: 0x060017FA RID: 6138 RVA: 0x0001023F File Offset: 0x0000E43F
	public global::LoadoutSlotType CurrentWeaponSlot { get; private set; }

	// Token: 0x060017FB RID: 6139 RVA: 0x00081AB4 File Offset: 0x0007FCB4
	public void UnassignWeapon(global::LoadoutSlotType slot)
	{
		this.CurrentWeaponSlot = slot;
		BaseWeaponDecorator baseWeaponDecorator;
		if (this._weapons.TryGetValue(slot, out baseWeaponDecorator) && baseWeaponDecorator)
		{
			UnityEngine.Object.Destroy(baseWeaponDecorator.gameObject);
		}
		this._weapons.Remove(slot);
	}

	// Token: 0x060017FC RID: 6140 RVA: 0x00081B00 File Offset: 0x0007FD00
	public void ShowWeapon(global::LoadoutSlotType slot)
	{
		this.CurrentWeaponSlot = slot;
		foreach (KeyValuePair<global::LoadoutSlotType, BaseWeaponDecorator> keyValuePair in this._weapons)
		{
			if (keyValuePair.Value)
			{
				keyValuePair.Value.IsEnabled = (slot == keyValuePair.Key);
				if (slot == keyValuePair.Key)
				{
					this.Decorator.AnimationController.ChangeWeaponType(keyValuePair.Value.WeaponClass);
				}
			}
		}
	}

	// Token: 0x060017FD RID: 6141 RVA: 0x00081BAC File Offset: 0x0007FDAC
	public void ShowFirstWeapon()
	{
		foreach (KeyValuePair<global::LoadoutSlotType, BaseWeaponDecorator> keyValuePair in this._weapons)
		{
			if (keyValuePair.Value)
			{
				this.ShowWeapon(keyValuePair.Key);
				break;
			}
		}
	}

	// Token: 0x060017FE RID: 6142 RVA: 0x00081C24 File Offset: 0x0007FE24
	public void HideWeapons()
	{
		foreach (BaseWeaponDecorator baseWeaponDecorator in this._weapons.Values)
		{
			if (baseWeaponDecorator)
			{
				baseWeaponDecorator.IsEnabled = false;
			}
		}
		this.Decorator.AnimationController.ChangeWeaponType((UberstrikeItemClass)0);
	}

	// Token: 0x040016BF RID: 5823
	private bool _isLocal;

	// Token: 0x040016C0 RID: 5824
	private Dictionary<global::LoadoutSlotType, BaseWeaponDecorator> _weapons;
}
