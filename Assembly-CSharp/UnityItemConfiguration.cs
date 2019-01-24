using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020002E4 RID: 740
public class UnityItemConfiguration : MonoBehaviour
{
	// Token: 0x17000517 RID: 1303
	// (get) Token: 0x0600153A RID: 5434 RVA: 0x0000E374 File Offset: 0x0000C574
	// (set) Token: 0x0600153B RID: 5435 RVA: 0x0000E37B File Offset: 0x0000C57B
	public static UnityItemConfiguration Instance { get; private set; }

	// Token: 0x17000518 RID: 1304
	// (get) Token: 0x0600153C RID: 5436 RVA: 0x0000E383 File Offset: 0x0000C583
	public static bool Exists
	{
		get
		{
			return UnityItemConfiguration.Instance != null;
		}
	}

	// Token: 0x0600153D RID: 5437 RVA: 0x00077CD8 File Offset: 0x00075ED8
	private void Awake()
	{
		UnityItemConfiguration.Instance = this;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(this.m_ItemPrefabXml.text);
		XmlNodeList xmlNodeList = xmlDocument.DocumentElement.SelectNodes("/ItemAssetBundle/Item");
		this.m_AvailablePrefabs = new Dictionary<string, string>();
		foreach (object obj in xmlNodeList)
		{
			XmlNode xmlNode = (XmlNode)obj;
			string text = xmlNode.Attributes.GetNamedItem("Prefab").Value;
			text = text.Replace(".prefab", string.Empty).Replace("Assets/", string.Empty);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
			this.m_AvailablePrefabs[fileNameWithoutExtension] = text;
		}
	}

	// Token: 0x0600153E RID: 5438 RVA: 0x00077DBC File Offset: 0x00075FBC
	public GameObject GetDefaultItem(UberstrikeItemClass itemClass)
	{
		if (this.UnityItemsDefaultGears.Exists((GearItem i) => i.TestItemClass == itemClass))
		{
			return this.UnityItemsDefaultGears.Find((GearItem i) => i.TestItemClass == itemClass).gameObject;
		}
		if (this.UnityItemsDefaultWeapons.Exists((WeaponItem i) => i.TestItemClass == itemClass))
		{
			return this.UnityItemsDefaultWeapons.Find((WeaponItem i) => i.TestItemClass == itemClass).gameObject;
		}
		Debug.LogError("Couldn't find default item with class: " + itemClass);
		return null;
	}

	// Token: 0x0600153F RID: 5439 RVA: 0x00077E64 File Offset: 0x00076064
	public string GetPrefabPath(string prefabName)
	{
		string empty = string.Empty;
		if (this.m_AvailablePrefabs.TryGetValue(prefabName, out empty))
		{
			return empty;
		}
		return string.Empty;
	}

	// Token: 0x06001540 RID: 5440 RVA: 0x0000E390 File Offset: 0x0000C590
	public bool IsPrefabAvailable(string prefabName)
	{
		return this.m_AvailablePrefabs.ContainsKey(prefabName);
	}

	// Token: 0x06001541 RID: 5441 RVA: 0x00077E94 File Offset: 0x00076094
	public bool Contains(string prefabName)
	{
		return this.UnityItemsDefaultGears.Find((GearItem item) => item.name.Equals(prefabName)) || this.UnityItemsDefaultWeapons.Find((WeaponItem item) => item.name.Equals(prefabName));
	}

	// Token: 0x06001542 RID: 5442 RVA: 0x00077EF0 File Offset: 0x000760F0
	public Texture2D GetDefaultIcon(UberstrikeItemClass itemClass)
	{
		switch (itemClass)
		{
		case UberstrikeItemClass.WeaponMelee:
			return this.DefaultWeaponIcons.Find((Texture2D icon) => icon.name.Contains("Melee"));
		case UberstrikeItemClass.WeaponMachinegun:
			return this.DefaultWeaponIcons.Find((Texture2D icon) => icon.name.Contains("Machine"));
		case UberstrikeItemClass.WeaponShotgun:
			return this.DefaultWeaponIcons.Find((Texture2D icon) => icon.name.Contains("Shot"));
		case UberstrikeItemClass.WeaponSniperRifle:
			return this.DefaultWeaponIcons.Find((Texture2D icon) => icon.name.Contains("Sniper"));
		case UberstrikeItemClass.WeaponCannon:
			return this.DefaultWeaponIcons.Find((Texture2D icon) => icon.name.Contains("Cannon"));
		case UberstrikeItemClass.WeaponSplattergun:
			return this.DefaultWeaponIcons.Find((Texture2D icon) => icon.name.Contains("Splatter"));
		case UberstrikeItemClass.WeaponLauncher:
			return this.DefaultWeaponIcons.Find((Texture2D icon) => icon.name.Contains("Launcher"));
		}
		return null;
	}

	// Token: 0x06001543 RID: 5443 RVA: 0x0007804C File Offset: 0x0007624C
	public Texture2D GetFunctionalItemIcon(int itemId)
	{
		UnityItemConfiguration.FunctionalItemHolder functionalItemHolder = this.UnityItemsFunctional.Find((UnityItemConfiguration.FunctionalItemHolder holder) => holder.ItemId == itemId);
		if (functionalItemHolder == null)
		{
			Debug.LogWarning("Failed to find icon for functional item with id: " + itemId);
			return null;
		}
		return functionalItemHolder.Icon;
	}

	// Token: 0x040013F4 RID: 5108
	[SerializeField]
	private TextAsset m_ItemPrefabXml;

	// Token: 0x040013F5 RID: 5109
	public List<GearItem> UnityItemsDefaultGears;

	// Token: 0x040013F6 RID: 5110
	public List<WeaponItem> UnityItemsDefaultWeapons;

	// Token: 0x040013F7 RID: 5111
	public List<UnityItemConfiguration.FunctionalItemHolder> UnityItemsFunctional;

	// Token: 0x040013F8 RID: 5112
	public List<Texture2D> DefaultWeaponIcons;

	// Token: 0x040013F9 RID: 5113
	private Dictionary<string, string> m_AvailablePrefabs;

	// Token: 0x020002E5 RID: 741
	[Serializable]
	public class FunctionalItemHolder
	{
		// Token: 0x04001402 RID: 5122
		public string Name;

		// Token: 0x04001403 RID: 5123
		public Texture2D Icon;

		// Token: 0x04001404 RID: 5124
		public int ItemId;
	}
}
