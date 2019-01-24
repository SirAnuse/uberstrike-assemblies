using System;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200046C RID: 1132
public class WeaponSlot
{
	// Token: 0x06002059 RID: 8281 RVA: 0x0001542B File Offset: 0x0001362B
	public WeaponSlot(global::LoadoutSlotType slot, IUnityItem item, Transform attachPoint, IWeaponController controller)
	{
		this.UnityItem = item;
		this.View = (item.View as UberStrikeItemWeaponView);
		this.Slot = slot;
		this.Initialize(controller, attachPoint);
	}

	// Token: 0x17000700 RID: 1792
	// (get) Token: 0x0600205A RID: 8282 RVA: 0x0001545B File Offset: 0x0001365B
	// (set) Token: 0x0600205B RID: 8283 RVA: 0x00015463 File Offset: 0x00013663
	public global::LoadoutSlotType Slot { get; private set; }

	// Token: 0x17000701 RID: 1793
	// (get) Token: 0x0600205C RID: 8284 RVA: 0x0001546C File Offset: 0x0001366C
	// (set) Token: 0x0600205D RID: 8285 RVA: 0x00015474 File Offset: 0x00013674
	public BaseWeaponLogic Logic { get; private set; }

	// Token: 0x17000702 RID: 1794
	// (get) Token: 0x0600205E RID: 8286 RVA: 0x0001547D File Offset: 0x0001367D
	// (set) Token: 0x0600205F RID: 8287 RVA: 0x00015485 File Offset: 0x00013685
	public BaseWeaponDecorator Decorator { get; private set; }

	// Token: 0x17000703 RID: 1795
	// (get) Token: 0x06002060 RID: 8288 RVA: 0x0001548E File Offset: 0x0001368E
	// (set) Token: 0x06002061 RID: 8289 RVA: 0x00015496 File Offset: 0x00013696
	public IUnityItem UnityItem { get; private set; }

	// Token: 0x17000704 RID: 1796
	// (get) Token: 0x06002062 RID: 8290 RVA: 0x0001549F File Offset: 0x0001369F
	// (set) Token: 0x06002063 RID: 8291 RVA: 0x000154A7 File Offset: 0x000136A7
	public WeaponItem Item { get; private set; }

	// Token: 0x17000705 RID: 1797
	// (get) Token: 0x06002064 RID: 8292 RVA: 0x000154B0 File Offset: 0x000136B0
	// (set) Token: 0x06002065 RID: 8293 RVA: 0x000154B8 File Offset: 0x000136B8
	public UberStrikeItemWeaponView View { get; private set; }

	// Token: 0x17000706 RID: 1798
	// (get) Token: 0x06002066 RID: 8294 RVA: 0x000154C1 File Offset: 0x000136C1
	// (set) Token: 0x06002067 RID: 8295 RVA: 0x000154C9 File Offset: 0x000136C9
	public WeaponInputHandler InputHandler { get; private set; }

	// Token: 0x17000707 RID: 1799
	// (get) Token: 0x06002068 RID: 8296 RVA: 0x000154D2 File Offset: 0x000136D2
	public bool HasWeapon
	{
		get
		{
			return this.Item != null;
		}
	}

	// Token: 0x06002069 RID: 8297 RVA: 0x0009AB68 File Offset: 0x00098D68
	private void Initialize(IWeaponController controller, Transform attachPoint)
	{
		this.CreateWeaponLogic(this.View, controller);
		this.CreateWeaponInputHandler(this.Item, this.Logic, this.Decorator, controller.IsLocal);
		this.ConfigureWeaponDecorator(attachPoint);
		if (controller.IsLocal)
		{
			this.Decorator.EnableShootAnimation = true;
			this.Decorator.IronSightPosition = this.Item.Configuration.IronSightPosition;
		}
		else
		{
			this.Decorator.EnableShootAnimation = false;
			this.Decorator.DefaultPosition = Vector3.zero;
		}
	}

	// Token: 0x0600206A RID: 8298 RVA: 0x0009ABFC File Offset: 0x00098DFC
	private void CreateWeaponLogic(UberStrikeItemWeaponView view, IWeaponController controller)
	{
		switch (view.ItemClass)
		{
		case UberstrikeItemClass.WeaponMelee:
			this.Decorator = this.InstantiateWeaponDecorator(view.ID);
			this.Item = this.Decorator.GetComponent<WeaponItem>();
			this.Logic = new MeleeWeapon(this.Item, this.Decorator as MeleeWeaponDecorator, controller);
			return;
		case UberstrikeItemClass.WeaponMachinegun:
			this.Decorator = this.InstantiateWeaponDecorator(view.ID);
			this.Item = this.Decorator.GetComponent<WeaponItem>();
			if (view.ProjectilesPerShot > 1)
			{
				this.Logic = new InstantMultiHitWeapon(this.Item, this.Decorator, view.ProjectilesPerShot, controller, view);
			}
			else
			{
				this.Logic = new InstantHitWeapon(this.Item, this.Decorator, controller, view);
			}
			return;
		case UberstrikeItemClass.WeaponShotgun:
			this.Decorator = this.InstantiateWeaponDecorator(view.ID);
			this.Item = this.Decorator.GetComponent<WeaponItem>();
			this.Logic = new InstantMultiHitWeapon(this.Item, this.Decorator, view.ProjectilesPerShot, controller, view);
			return;
		case UberstrikeItemClass.WeaponSniperRifle:
			this.Decorator = this.InstantiateWeaponDecorator(view.ID);
			this.Item = this.Decorator.GetComponent<WeaponItem>();
			this.Logic = new InstantHitWeapon(this.Item, this.Decorator, controller, view);
			return;
		case UberstrikeItemClass.WeaponCannon:
		case UberstrikeItemClass.WeaponSplattergun:
		case UberstrikeItemClass.WeaponLauncher:
		{
			ProjectileWeaponDecorator projectileWeaponDecorator = this.CreateProjectileWeaponDecorator(view.ID, view.MissileTimeToDetonate);
			this.Item = projectileWeaponDecorator.GetComponent<WeaponItem>();
			this.Logic = new ProjectileWeapon(this.Item, projectileWeaponDecorator, controller, view);
			this.Decorator = projectileWeaponDecorator;
			return;
		}
		}
		throw new Exception("Failed to create weapon logic!");
	}

	// Token: 0x0600206B RID: 8299 RVA: 0x0009ADC8 File Offset: 0x00098FC8
	private ProjectileWeaponDecorator CreateProjectileWeaponDecorator(int itemId, int missileTimeToDetonate)
	{
		IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(itemId);
		GameObject gameObject = itemInShop.Create(Vector3.zero, Quaternion.identity);
		ProjectileWeaponDecorator component = gameObject.GetComponent<ProjectileWeaponDecorator>();
		if (component)
		{
			component.SetMissileTimeOut((float)missileTimeToDetonate / 1000f);
		}
		return component;
	}

	// Token: 0x0600206C RID: 8300 RVA: 0x0009AE14 File Offset: 0x00099014
	private BaseWeaponDecorator InstantiateWeaponDecorator(int itemId)
	{
		IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(itemId);
		GameObject gameObject = itemInShop.Create(Vector3.zero, Quaternion.identity);
		return gameObject.GetComponent<BaseWeaponDecorator>();
	}

	// Token: 0x0600206D RID: 8301 RVA: 0x0009AE44 File Offset: 0x00099044
	private void ConfigureWeaponDecorator(Transform parent)
	{
		if (this.Decorator)
		{
			this.Decorator.IsEnabled = false;
			this.Decorator.transform.parent = parent;
			this.Decorator.DefaultPosition = this.Item.Configuration.Position;
			this.Decorator.DefaultAngles = this.Item.Configuration.Rotation;
			this.Decorator.CurrentPosition = this.Item.Configuration.Position;
			this.Decorator.gameObject.name = this.Slot + " " + this.View.ItemClass;
			this.Decorator.WeaponClass = this.View.ItemClass;
			this.Decorator.SetSurfaceEffect(this.Item.Configuration.ParticleEffect);
			LayerUtil.SetLayerRecursively(this.Decorator.transform, parent.gameObject.layer);
		}
		else
		{
			Debug.LogError("Failed to configure WeaponDecorator!");
		}
	}

	// Token: 0x0600206E RID: 8302 RVA: 0x0009AF60 File Offset: 0x00099160
	private void CreateWeaponInputHandler(WeaponItem item, IWeaponLogic logic, BaseWeaponDecorator decorator, bool isLocal)
	{
		switch (this.View.WeaponSecondaryAction)
		{
		case 1:
		{
			ZoomInfo zoomInfo = new ZoomInfo((float)this.View.DefaultZoomMultiplier, (float)this.View.MinZoomMultiplier, (float)this.View.MaxZoomMultiplier);
			this.InputHandler = new SniperRifleInputHandler(logic, isLocal, zoomInfo, this.View);
			break;
		}
		case 2:
		{
			ZoomInfo zoomInfo2 = new ZoomInfo((float)this.View.DefaultZoomMultiplier, (float)this.View.MinZoomMultiplier, (float)this.View.MaxZoomMultiplier);
			this.InputHandler = new IronsightInputHandler(logic, isLocal, zoomInfo2, this.View);
			break;
		}
		case 3:
			this.InputHandler = new DefaultWeaponInputHandler(logic, isLocal, this.View, new GrenadeExplosionHander());
			break;
		case 4:
			this.InputHandler = new MinigunInputHandler(logic, isLocal, decorator as MinigunWeaponDecorator, this.View);
			break;
		default:
			this.InputHandler = new DefaultWeaponInputHandler(logic, isLocal, this.View, null);
			break;
		}
	}

	// Token: 0x17000708 RID: 1800
	// (get) Token: 0x0600206F RID: 8303 RVA: 0x0009B078 File Offset: 0x00099278
	public byte SlotId
	{
		get
		{
			switch (this.Slot)
			{
			case global::LoadoutSlotType.WeaponPrimary:
				return 1;
			case global::LoadoutSlotType.WeaponSecondary:
				return 2;
			case global::LoadoutSlotType.WeaponTertiary:
				return 3;
			default:
				return 0;
			}
		}
	}
}
