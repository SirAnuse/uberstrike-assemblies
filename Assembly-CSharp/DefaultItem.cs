using System;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200025C RID: 604
public class DefaultItem : IUnityItem
{
	// Token: 0x060010B6 RID: 4278 RVA: 0x00067000 File Offset: 0x00065200
	public DefaultItem(BaseUberStrikeItemView view)
	{
		this.View = view;
		switch (view.ItemType)
		{
		case UberstrikeItemType.Weapon:
			this._prefab = Singleton<ItemManager>.Instance.GetDefaultWeaponItem(view.ItemClass);
			break;
		case UberstrikeItemType.Gear:
			this._prefab = Singleton<ItemManager>.Instance.GetDefaultGearItem(view.ItemClass);
			break;
		}
		this._icon = UnityItemConfiguration.Instance.GetDefaultIcon(view.ItemClass);
	}

	// Token: 0x060010B7 RID: 4279 RVA: 0x0000BA42 File Offset: 0x00009C42
	public DefaultItem(GameObject prefab)
	{
		this._prefab = prefab;
	}

	// Token: 0x1700040C RID: 1036
	// (get) Token: 0x060010B8 RID: 4280 RVA: 0x00004D4D File Offset: 0x00002F4D
	public bool Equippable
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700040D RID: 1037
	// (get) Token: 0x060010B9 RID: 4281 RVA: 0x00004D4D File Offset: 0x00002F4D
	public bool IsLoaded
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700040E RID: 1038
	// (get) Token: 0x060010BA RID: 4282 RVA: 0x0000BA51 File Offset: 0x00009C51
	public GameObject Prefab
	{
		get
		{
			return this._prefab;
		}
	}

	// Token: 0x1700040F RID: 1039
	// (get) Token: 0x060010BB RID: 4283 RVA: 0x0000BA59 File Offset: 0x00009C59
	public string Name
	{
		get
		{
			return this.View.Name;
		}
	}

	// Token: 0x17000410 RID: 1040
	// (get) Token: 0x060010BC RID: 4284 RVA: 0x0000BA66 File Offset: 0x00009C66
	// (set) Token: 0x060010BD RID: 4285 RVA: 0x0000BA6E File Offset: 0x00009C6E
	public BaseUberStrikeItemView View { get; private set; }

	// Token: 0x060010BE RID: 4286 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Unload()
	{
	}

	// Token: 0x060010BF RID: 4287 RVA: 0x00067088 File Offset: 0x00065288
	public GameObject Create(Vector3 position, Quaternion rotation)
	{
		if (this._prefab)
		{
			return UnityEngine.Object.Instantiate(this._prefab.gameObject, position, rotation) as GameObject;
		}
		Debug.LogError("Failed to create default item: " + this.View.Name);
		return null;
	}

	// Token: 0x060010C0 RID: 4288 RVA: 0x000670D8 File Offset: 0x000652D8
	public void DrawIcon(Rect position)
	{
		Color color = GUI.color;
		GUI.color = color.SetAlpha((!GUI.enabled) ? 0.5f : 1f);
		GUI.DrawTexture(position, this._icon);
		GUI.color = color;
	}

	// Token: 0x04000E26 RID: 3622
	private Texture2D _icon;

	// Token: 0x04000E27 RID: 3623
	private GameObject _prefab;
}
