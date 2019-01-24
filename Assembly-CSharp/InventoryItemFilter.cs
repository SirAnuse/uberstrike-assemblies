using System;

// Token: 0x020001F7 RID: 503
public class InventoryItemFilter : IShopItemFilter
{
	// Token: 0x06000E24 RID: 3620 RVA: 0x00061034 File Offset: 0x0005F234
	public bool CanPass(IUnityItem item)
	{
		return !Singleton<LoadoutManager>.Instance.IsItemEquipped(item.View.ID) && item.View.PrefabName != "LutzDefaultGearHead" && item.View.PrefabName != "LutzDefaultGearGloves" && item.View.PrefabName != "LutzDefaultGearUpperBody" && item.View.PrefabName != "LutzDefaultGearLowerBody" && item.View.PrefabName != "LutzDefaultGearBoots" && item.Name != "Privateer License";
	}
}
