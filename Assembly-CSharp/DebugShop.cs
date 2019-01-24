using System;
using UnityEngine;

// Token: 0x020000E4 RID: 228
public class DebugShop : IDebugPage
{
	// Token: 0x17000246 RID: 582
	// (get) Token: 0x060007D2 RID: 2002 RVA: 0x00006F64 File Offset: 0x00005164
	public string Title
	{
		get
		{
			return "Shop";
		}
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x00035E34 File Offset: 0x00034034
	public void Draw()
	{
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.scroll1 = GUILayout.BeginScrollView(this.scroll1, new GUILayoutOption[]
		{
			GUILayout.Width((float)(Screen.width / 3))
		});
		GUILayout.Label("SHOP", new GUILayoutOption[0]);
		foreach (IUnityItem unityItem in Singleton<ItemManager>.Instance.ShopItems)
		{
			GUILayout.Label(unityItem.View.ID + ": " + unityItem.Name, new GUILayoutOption[0]);
		}
		GUILayout.EndScrollView();
		this.scroll2 = GUILayout.BeginScrollView(this.scroll2, new GUILayoutOption[]
		{
			GUILayout.Width((float)(Screen.width / 3))
		});
		GUILayout.Label("INVENTORY", new GUILayoutOption[0]);
		foreach (InventoryItem inventoryItem in Singleton<InventoryManager>.Instance.InventoryItems)
		{
			GUILayout.Label(string.Concat(new object[]
			{
				inventoryItem.Item.View.ID,
				": ",
				inventoryItem.Item.Name,
				", Amount: ",
				inventoryItem.AmountRemaining,
				", Days: ",
				inventoryItem.DaysRemaining
			}), new GUILayoutOption[0]);
		}
		GUILayout.EndScrollView();
		this.scroll3 = GUILayout.BeginScrollView(this.scroll3, new GUILayoutOption[]
		{
			GUILayout.Width((float)(Screen.width / 3))
		});
		GUILayout.Label("LOADOUT", new GUILayoutOption[0]);
		GUILayout.EndScrollView();
		GUILayout.EndHorizontal();
	}

	// Token: 0x040006B5 RID: 1717
	private Vector2 scroll1;

	// Token: 0x040006B6 RID: 1718
	private Vector2 scroll2;

	// Token: 0x040006B7 RID: 1719
	private Vector2 scroll3;
}
