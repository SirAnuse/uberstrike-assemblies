using System;
using UberStrike.Core.Models.Views;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x02000256 RID: 598
public class QuickItemController : Singleton<QuickItemController>
{
	// Token: 0x0600107B RID: 4219 RVA: 0x000662F8 File Offset: 0x000644F8
	private QuickItemController()
	{
		this._quickItems = new QuickItem[LoadoutManager.QuickSlots.Length];
		this.Restriction = new QuickItemRestriction();
		global::EventHandler.Global.AddListener<GlobalEvents.InputChanged>(new Action<GlobalEvents.InputChanged>(this.OnInputChanged));
	}

	// Token: 0x17000400 RID: 1024
	// (get) Token: 0x0600107C RID: 4220 RVA: 0x0000B85C File Offset: 0x00009A5C
	// (set) Token: 0x0600107D RID: 4221 RVA: 0x0000B87B File Offset: 0x00009A7B
	public bool IsEnabled
	{
		get
		{
			return this._isEnabled && GameState.Current.PlayerData.IsAlive;
		}
		set
		{
			this._isEnabled = value;
		}
	}

	// Token: 0x17000401 RID: 1025
	// (get) Token: 0x0600107E RID: 4222 RVA: 0x0000B884 File Offset: 0x00009A84
	// (set) Token: 0x0600107F RID: 4223 RVA: 0x0000B88C File Offset: 0x00009A8C
	public bool IsConsumptionEnabled { get; set; }

	// Token: 0x17000402 RID: 1026
	// (get) Token: 0x06001080 RID: 4224 RVA: 0x0000B895 File Offset: 0x00009A95
	// (set) Token: 0x06001081 RID: 4225 RVA: 0x0000B89D File Offset: 0x00009A9D
	public int CurrentSlotIndex { get; private set; }

	// Token: 0x17000403 RID: 1027
	// (get) Token: 0x06001082 RID: 4226 RVA: 0x0000B8A6 File Offset: 0x00009AA6
	// (set) Token: 0x06001083 RID: 4227 RVA: 0x0000B8AE File Offset: 0x00009AAE
	public float NextCooldownFinishTime { get; set; }

	// Token: 0x17000404 RID: 1028
	// (get) Token: 0x06001084 RID: 4228 RVA: 0x0000B8B7 File Offset: 0x00009AB7
	// (set) Token: 0x06001085 RID: 4229 RVA: 0x0000B8BF File Offset: 0x00009ABF
	public QuickItemRestriction Restriction { get; private set; }

	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x06001086 RID: 4230 RVA: 0x0000B8C8 File Offset: 0x00009AC8
	public QuickItem[] QuickItems
	{
		get
		{
			return this._quickItems;
		}
	}

	// Token: 0x06001087 RID: 4231 RVA: 0x0006634C File Offset: 0x0006454C
	public void Initialize()
	{
		this.Clear();
		for (int i = 0; i < LoadoutManager.QuickSlots.Length; i++)
		{
			LoadoutSlotType slot = LoadoutManager.QuickSlots[i];
			InventoryItem inventoryItem;
			if (Singleton<LoadoutManager>.Instance.TryGetItemInSlot(slot, out inventoryItem))
			{
				GameObject quickItemObject = inventoryItem.Item.Create(Vector3.zero, Quaternion.identity);
				this.InitializeQuickItem(quickItemObject, slot, inventoryItem);
			}
			else
			{
				this.Restriction.InitializeSlot(i, null, 0);
			}
		}
		this.CurrentSlotIndex = ((!(this._quickItems[0] == null)) ? 0 : this.GetNextAvailableSlotIndex(0));
		GameData.Instance.OnQuickItemsChanged.Fire();
	}

	// Token: 0x06001088 RID: 4232 RVA: 0x000663F8 File Offset: 0x000645F8
	private void InitializeQuickItem(GameObject quickItemObject, LoadoutSlotType slot, InventoryItem inventoryItem)
	{
		int slotIndex = this.GetSlotIndex(slot);
		QuickItem component = quickItemObject.GetComponent<QuickItem>();
		if (component)
		{
			component.gameObject.SetActive(true);
			for (int i = 0; i < component.gameObject.transform.childCount; i++)
			{
				component.gameObject.transform.GetChild(i).gameObject.SetActive(false);
			}
			component.gameObject.name = inventoryItem.Item.Name;
			component.transform.parent = GameState.Current.Player.WeaponAttachPoint;
			if (component.rigidbody)
			{
				component.rigidbody.isKinematic = true;
			}
			ItemConfigurationUtil.CopyProperties<UberStrikeItemQuickView>(component.Configuration, inventoryItem.Item.View);
			ItemConfigurationUtil.CopyCustomProperties(inventoryItem.Item.View, component.Configuration);
			if (component.Configuration.RechargeTime <= 0)
			{
				int index = slotIndex;
				QuickItemBehaviour behaviour = component.Behaviour;
				behaviour.OnActivated = (Action)Delegate.Combine(behaviour.OnActivated, new Action(delegate()
				{
					this.UseConsumableItem(inventoryItem);
					this.Restriction.DecreaseUse(index);
					this.NextCooldownFinishTime = Time.time + 0.5f;
				}));
				this.Restriction.InitializeSlot(slotIndex, component, inventoryItem.AmountRemaining);
			}
			else
			{
				component.Behaviour.CurrentAmount = component.Configuration.AmountRemaining;
			}
			component.Behaviour.FocusKey = this.GetFocusKey(slot);
			IGrenadeProjectile grenadeProjectile = component as IGrenadeProjectile;
			if (grenadeProjectile != null)
			{
				grenadeProjectile.OnProjectileEmitted += delegate(IGrenadeProjectile p)
				{
					Singleton<ProjectileManager>.Instance.AddProjectile(p, Singleton<WeaponController>.Instance.NextProjectileId());
					GameState.Current.Actions.EmitQuickItem(p.Position, p.Velocity, inventoryItem.Item.View.ID, GameState.Current.PlayerData.Player.PlayerId, p.ID);
				};
			}
			if (this._quickItems[slotIndex])
			{
				UnityEngine.Object.Destroy(this._quickItems[slotIndex].gameObject);
			}
			this._quickItems[slotIndex] = component;
		}
		else
		{
			Debug.LogError("Failed to initialize QuickItem");
		}
		GameData.Instance.OnQuickItemsChanged.Fire();
	}

	// Token: 0x06001089 RID: 4233 RVA: 0x00066614 File Offset: 0x00064814
	private bool IsCastingOrCooldown()
	{
		foreach (QuickItem quickItem in this._quickItems)
		{
			if (quickItem != null && quickItem.Behaviour.IsCoolingDown)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600108A RID: 4234 RVA: 0x00066660 File Offset: 0x00064860
	private void UseQuickItem(int index)
	{
		if (!this.IsEnabled || this.IsCastingOrCooldown() || Time.time < this.NextCooldownFinishTime)
		{
			return;
		}
		if (this._quickItems != null && index >= 0 && this._quickItems[index] != null)
		{
			if (this._quickItems[index].Behaviour.Run() && GameState.Current.Player.Character != null)
			{
				AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.WeaponSwitch, 0UL);
			}
		}
		else
		{
			Debug.LogError("The QuickItem has no Behaviour: " + index);
		}
	}

	// Token: 0x0600108B RID: 4235 RVA: 0x00066718 File Offset: 0x00064918
	public void Update()
	{
		if (this._quickItems == null)
		{
			return;
		}
		for (int i = 0; i < this._quickItems.Length; i++)
		{
			if (!(this._quickItems[i] == null))
			{
				float chargingTimeRemaining = this._quickItems[i].Behaviour.ChargingTimeRemaining;
				if (this.recharges[i] != chargingTimeRemaining)
				{
					this.recharges[i] = chargingTimeRemaining;
				}
			}
		}
	}

	// Token: 0x0600108C RID: 4236 RVA: 0x0006678C File Offset: 0x0006498C
	private void OnInputChanged(GlobalEvents.InputChanged ev)
	{
		if (AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled && ev.IsDown && !LevelCamera.IsZoomedIn && this.IsEnabled)
		{
			GameInputKey key = ev.Key;
			switch (key)
			{
			case GameInputKey.UseQuickItem:
				this.UseQuickItem(this.CurrentSlotIndex);
				break;
			default:
				switch (key)
				{
				case GameInputKey.QuickItem1:
					this.UseQuickItem(0);
					break;
				case GameInputKey.QuickItem2:
					this.UseQuickItem(1);
					break;
				case GameInputKey.QuickItem3:
					this.UseQuickItem(2);
					break;
				}
				break;
			case GameInputKey.NextQuickItem:
				if (this._quickItems.Length > 0)
				{
					this.CurrentSlotIndex = this.GetNextAvailableSlotIndex(this.CurrentSlotIndex);
					GameData.Instance.OnQuickItemsChanged.Fire();
				}
				break;
			case GameInputKey.PrevQuickItem:
				if (this._quickItems.Length > 0)
				{
					this.CurrentSlotIndex = this.GetPrevAvailableSlotIndex(this.CurrentSlotIndex);
					GameData.Instance.OnQuickItemsChanged.Fire();
				}
				break;
			}
		}
		if (ev.Key == GameInputKey.UseQuickItem && !LevelCamera.IsZoomedIn && this.IsEnabled)
		{
			this.IsQuickItemMobilePushed = ev.IsDown;
		}
	}

	// Token: 0x0600108D RID: 4237 RVA: 0x000668D0 File Offset: 0x00064AD0
	private int GetNextAvailableSlotIndex(int currentSlot)
	{
		for (int num = (currentSlot + 1) % this._quickItems.Length; num != currentSlot; num = (num + 1) % this._quickItems.Length)
		{
			if (this._quickItems[num] != null)
			{
				return num;
			}
		}
		return currentSlot;
	}

	// Token: 0x0600108E RID: 4238 RVA: 0x0006691C File Offset: 0x00064B1C
	private int GetPrevAvailableSlotIndex(int currentSlot)
	{
		for (int num = (currentSlot - 1) % this._quickItems.Length; num != currentSlot; num = (num - 1) % this._quickItems.Length)
		{
			if (num < 0)
			{
				num = this._quickItems.Length - 1;
			}
			if (this._quickItems[num] != null)
			{
				return num;
			}
		}
		return currentSlot;
	}

	// Token: 0x0600108F RID: 4239 RVA: 0x00066978 File Offset: 0x00064B78
	private void UseConsumableItem(InventoryItem inventoryItem)
	{
		if (this.IsConsumptionEnabled)
		{
			ShopWebServiceClient.UseConsumableItem(PlayerDataManager.AuthToken, inventoryItem.Item.View.ID, null, null);
			inventoryItem.AmountRemaining--;
			if (inventoryItem.AmountRemaining == 0)
			{
				UnityRuntime.StartRoutine(Singleton<ItemManager>.Instance.StartGetInventory(false));
			}
		}
	}

	// Token: 0x06001090 RID: 4240 RVA: 0x000669D8 File Offset: 0x00064BD8
	private GameInputKey GetFocusKey(LoadoutSlotType slot)
	{
		switch (slot)
		{
		case LoadoutSlotType.QuickUseItem1:
			return GameInputKey.QuickItem1;
		case LoadoutSlotType.QuickUseItem2:
			return GameInputKey.QuickItem2;
		case LoadoutSlotType.QuickUseItem3:
			return GameInputKey.QuickItem3;
		default:
			return GameInputKey.None;
		}
	}

	// Token: 0x06001091 RID: 4241 RVA: 0x00066A0C File Offset: 0x00064C0C
	private int GetSlotIndex(LoadoutSlotType slot)
	{
		switch (slot)
		{
		case LoadoutSlotType.QuickUseItem1:
			return 0;
		case LoadoutSlotType.QuickUseItem2:
			return 1;
		case LoadoutSlotType.QuickUseItem3:
			return 2;
		default:
			return -1;
		}
	}

	// Token: 0x06001092 RID: 4242 RVA: 0x00003C87 File Offset: 0x00001E87
	internal void Reset()
	{
	}

	// Token: 0x06001093 RID: 4243 RVA: 0x00066A3C File Offset: 0x00064C3C
	internal void Clear()
	{
		for (int i = 0; i < this._quickItems.Length; i++)
		{
			if (this._quickItems[i] != null)
			{
				UnityEngine.Object.Destroy(this._quickItems[i].gameObject);
			}
			this._quickItems[i] = null;
		}
	}

	// Token: 0x04000E0C RID: 3596
	private const float CooldownTime = 0.5f;

	// Token: 0x04000E0D RID: 3597
	private QuickItem[] _quickItems;

	// Token: 0x04000E0E RID: 3598
	private bool _isEnabled;

	// Token: 0x04000E0F RID: 3599
	public bool IsQuickItemMobilePushed;

	// Token: 0x04000E10 RID: 3600
	private float[] recharges = new float[3];
}
