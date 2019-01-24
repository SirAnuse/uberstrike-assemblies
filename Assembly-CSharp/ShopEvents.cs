using System;
using UberStrike.Core.Types;

// Token: 0x02000133 RID: 307
public static class ShopEvents
{
	// Token: 0x02000134 RID: 308
	public class ShopHighlightSlot
	{
		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x0000731A File Offset: 0x0000551A
		// (set) Token: 0x06000855 RID: 2133 RVA: 0x00007322 File Offset: 0x00005522
		public global::LoadoutSlotType SlotType { get; set; }
	}

	// Token: 0x02000135 RID: 309
	public class SelectShopArea
	{
		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x0000732B File Offset: 0x0000552B
		// (set) Token: 0x06000858 RID: 2136 RVA: 0x00007333 File Offset: 0x00005533
		public ShopArea ShopArea { get; set; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x0000733C File Offset: 0x0000553C
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x00007344 File Offset: 0x00005544
		public UberstrikeItemClass ItemClass { get; set; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x0000734D File Offset: 0x0000554D
		// (set) Token: 0x0600085C RID: 2140 RVA: 0x00007355 File Offset: 0x00005555
		public UberstrikeItemType ItemType { get; set; }
	}

	// Token: 0x02000136 RID: 310
	public class SelectLoadoutArea
	{
		// Token: 0x17000272 RID: 626
		// (get) Token: 0x0600085E RID: 2142 RVA: 0x0000735E File Offset: 0x0000555E
		// (set) Token: 0x0600085F RID: 2143 RVA: 0x00007366 File Offset: 0x00005566
		public LoadoutArea Area { get; set; }
	}

	// Token: 0x02000137 RID: 311
	public class LoadoutAreaChanged
	{
		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x0000736F File Offset: 0x0000556F
		// (set) Token: 0x06000862 RID: 2146 RVA: 0x00007377 File Offset: 0x00005577
		public LoadoutArea Area { get; set; }
	}

	// Token: 0x02000138 RID: 312
	public class SelectShopItem
	{
		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x00007380 File Offset: 0x00005580
		// (set) Token: 0x06000865 RID: 2149 RVA: 0x00007388 File Offset: 0x00005588
		public IUnityItem Item { get; set; }
	}

	// Token: 0x02000139 RID: 313
	public class RefreshCurrentItemList
	{
		// Token: 0x06000866 RID: 2150 RVA: 0x00007391 File Offset: 0x00005591
		public RefreshCurrentItemList()
		{
			this.UseCurrentSelection = true;
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x000073A0 File Offset: 0x000055A0
		public RefreshCurrentItemList(UberstrikeItemClass itemClass, UberstrikeItemType itemType)
		{
			this.UseCurrentSelection = false;
			this.ItemClass = itemClass;
			this.ItemType = itemType;
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x000073BD File Offset: 0x000055BD
		// (set) Token: 0x06000869 RID: 2153 RVA: 0x000073C5 File Offset: 0x000055C5
		public bool UseCurrentSelection { get; private set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x000073CE File Offset: 0x000055CE
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x000073D6 File Offset: 0x000055D6
		public UberstrikeItemClass ItemClass { get; private set; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x000073DF File Offset: 0x000055DF
		// (set) Token: 0x0600086D RID: 2157 RVA: 0x000073E7 File Offset: 0x000055E7
		public UberstrikeItemType ItemType { get; private set; }
	}
}
