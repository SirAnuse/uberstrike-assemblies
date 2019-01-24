using System;
using Cmune.DataCenter.Common.Entities;

// Token: 0x02000260 RID: 608
public class ShopItemView
{
	// Token: 0x060010DB RID: 4315 RVA: 0x00067974 File Offset: 0x00065B74
	public ShopItemView(int itemId)
	{
		IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(itemId);
		this.Points = 0;
		this.Credits = 0;
		this.UnityItem = itemInShop;
		this.ItemId = itemId;
		this.Duration = BuyingDurationType.None;
	}

	// Token: 0x060010DC RID: 4316 RVA: 0x000679B8 File Offset: 0x00065BB8
	public ShopItemView(BundleItemView itemView)
	{
		IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(itemView.ItemId);
		this.Points = 0;
		this.Credits = 0;
		this.UnityItem = itemInShop;
		this.ItemId = itemView.ItemId;
		this.Duration = itemView.Duration;
	}

	// Token: 0x060010DD RID: 4317 RVA: 0x00067A0C File Offset: 0x00065C0C
	public ShopItemView(UberStrikeCurrencyType currency, int price)
	{
		if (currency != UberStrikeCurrencyType.Credits)
		{
			if (currency != UberStrikeCurrencyType.Points)
			{
				this.UnityItem = null;
				this.Points = 0;
				this.Credits = 0;
			}
			else
			{
				this.UnityItem = new PointsUnityItem(price);
				this.Credits = 0;
				this.Points = price;
			}
		}
		else
		{
			this.UnityItem = new CreditsUnityItem(price);
			this.Points = 0;
			this.Credits = price;
		}
		this.ItemId = 0;
		this.Duration = BuyingDurationType.None;
	}

	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x060010DE RID: 4318 RVA: 0x0000BB4F File Offset: 0x00009D4F
	// (set) Token: 0x060010DF RID: 4319 RVA: 0x0000BB57 File Offset: 0x00009D57
	public BuyingDurationType Duration { get; private set; }

	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x060010E0 RID: 4320 RVA: 0x0000BB60 File Offset: 0x00009D60
	// (set) Token: 0x060010E1 RID: 4321 RVA: 0x0000BB68 File Offset: 0x00009D68
	public IUnityItem UnityItem { get; private set; }

	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x060010E2 RID: 4322 RVA: 0x0000BB71 File Offset: 0x00009D71
	// (set) Token: 0x060010E3 RID: 4323 RVA: 0x0000BB79 File Offset: 0x00009D79
	public int ItemId { get; private set; }

	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x060010E4 RID: 4324 RVA: 0x0000BB82 File Offset: 0x00009D82
	// (set) Token: 0x060010E5 RID: 4325 RVA: 0x0000BB8A File Offset: 0x00009D8A
	public int Credits { get; private set; }

	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x060010E6 RID: 4326 RVA: 0x0000BB93 File Offset: 0x00009D93
	// (set) Token: 0x060010E7 RID: 4327 RVA: 0x0000BB9B File Offset: 0x00009D9B
	public int Points { get; private set; }
}
