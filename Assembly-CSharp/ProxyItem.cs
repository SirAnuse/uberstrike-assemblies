using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200025E RID: 606
public class ProxyItem : IUnityItem
{
	// Token: 0x060010C4 RID: 4292 RVA: 0x0006721C File Offset: 0x0006541C
	public ProxyItem(BaseUberStrikeItemView view)
	{
		this.View = view;
		if (UnityItemConfiguration.Instance.IsPrefabAvailable(this.View.PrefabName))
		{
			string text = UnityItemConfiguration.Instance.GetPrefabPath(view.PrefabName);
			text += "-Icon";
			this.m_Icon = Resources.Load<Texture2D>(text);
		}
		else if (this.View.ItemClass == UberstrikeItemClass.FunctionalGeneral)
		{
			this.m_Icon = UnityItemConfiguration.Instance.GetFunctionalItemIcon(this.View.ID);
		}
		else
		{
			this.m_Icon = UnityItemConfiguration.Instance.GetDefaultIcon(view.ItemClass);
		}
	}

	// Token: 0x17000411 RID: 1041
	// (get) Token: 0x060010C5 RID: 4293 RVA: 0x00004D4D File Offset: 0x00002F4D
	public bool Equippable
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000412 RID: 1042
	// (get) Token: 0x060010C6 RID: 4294 RVA: 0x0000BA77 File Offset: 0x00009C77
	public string Name
	{
		get
		{
			return this.View.Name;
		}
	}

	// Token: 0x17000413 RID: 1043
	// (get) Token: 0x060010C7 RID: 4295 RVA: 0x0000BA84 File Offset: 0x00009C84
	// (set) Token: 0x060010C8 RID: 4296 RVA: 0x0000BA8C File Offset: 0x00009C8C
	public bool IsLoaded { get; private set; }

	// Token: 0x17000414 RID: 1044
	// (get) Token: 0x060010C9 RID: 4297 RVA: 0x0000BA95 File Offset: 0x00009C95
	// (set) Token: 0x060010CA RID: 4298 RVA: 0x0000BA9D File Offset: 0x00009C9D
	public GameObject Prefab { get; private set; }

	// Token: 0x17000415 RID: 1045
	// (get) Token: 0x060010CB RID: 4299 RVA: 0x0000BAA6 File Offset: 0x00009CA6
	// (set) Token: 0x060010CC RID: 4300 RVA: 0x0000BAAE File Offset: 0x00009CAE
	public BaseUberStrikeItemView View { get; private set; }

	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060010CD RID: 4301 RVA: 0x0000BAB7 File Offset: 0x00009CB7
	public int CriticalStrikeBonus
	{
		get
		{
			if (this.View.ItemProperties.ContainsKey(ItemPropertyType.CritDamageBonus))
			{
				return this.View.ItemProperties[ItemPropertyType.CritDamageBonus];
			}
			return 0;
		}
	}

	// Token: 0x060010CE RID: 4302 RVA: 0x0000BAE2 File Offset: 0x00009CE2
	public void UpdateProxyItem(BaseUberStrikeItemView view)
	{
		this.View = view;
	}

	// Token: 0x060010CF RID: 4303 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Unload()
	{
	}

	// Token: 0x060010D0 RID: 4304 RVA: 0x000672C8 File Offset: 0x000654C8
	public GameObject Create(Vector3 position, Quaternion rotation)
	{
		if (UnityItemConfiguration.Instance.IsPrefabAvailable(this.View.PrefabName))
		{
			string prefabPath = UnityItemConfiguration.Instance.GetPrefabPath(this.View.PrefabName);
			Debug.Log(string.Concat(new object[]
			{
				"Create Item:",
				this.View.ID,
				", ",
				this.View.Name,
				", ",
				prefabPath
			}));
			UnityEngine.Object @object = Resources.Load<GameObject>(prefabPath);
			this.Prefab = (GameObject)@object;
		}
		else
		{
			Debug.Log(string.Concat(new object[]
			{
				"Create DEFAULT Item:",
				this.View.ID,
				", ",
				this.View.Name,
				", ",
				this.View.PrefabName
			}));
			this.Prefab = UnityItemConfiguration.Instance.GetDefaultItem(this.View.ItemClass);
		}
		if (this.View.ItemType == UberstrikeItemType.QuickUse)
		{
			QuickItem component = this.Prefab.GetComponent<QuickItem>();
			if (component != null && component.Sfx)
			{
				Singleton<QuickItemSfxController>.Instance.RegisterQuickItemEffect(component.Logic, component.Sfx);
			}
		}
		GameObject gameObject = null;
		if (this.Prefab != null)
		{
			if (this.View.ItemClass == UberstrikeItemClass.GearHolo)
			{
				HoloGearItem component2 = this.Prefab.GetComponent<HoloGearItem>();
				if (component2 && component2.Configuration.Avatar)
				{
					gameObject = (UnityEngine.Object.Instantiate(component2.Configuration.Avatar.gameObject) as GameObject);
				}
			}
			else
			{
				gameObject = (UnityEngine.Object.Instantiate(this.Prefab, position, rotation) as GameObject);
			}
			if (gameObject && this.View.ItemType == UberstrikeItemType.Weapon)
			{
				WeaponItem component3 = gameObject.GetComponent<WeaponItem>();
				if (component3)
				{
					ItemConfigurationUtil.CopyCustomProperties(this.View, component3.Configuration);
					if (this.View.ItemProperties.ContainsKey(ItemPropertyType.CritDamageBonus))
					{
						component3.Configuration.CriticalStrikeBonus = this.View.ItemProperties[ItemPropertyType.CritDamageBonus];
					}
					else
					{
						component3.Configuration.CriticalStrikeBonus = 0;
					}
				}
			}
		}
		else
		{
			Debug.LogError("Trying to create item prefab, but it was null. Item Name:" + this.View.Name);
		}
		this.IsLoaded = true;
		return gameObject;
	}

	// Token: 0x060010D1 RID: 4305 RVA: 0x0000BAEB File Offset: 0x00009CEB
	public void DrawIcon(Rect position)
	{
		GUI.DrawTexture(position, this.m_Icon);
	}

	// Token: 0x04000E29 RID: 3625
	private Texture2D m_Icon;
}
