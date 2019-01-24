using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Types;
using UnityEngine;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000230 RID: 560
	public abstract class BaseUberStrikeItemView
	{
		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000F0E RID: 3854
		public abstract UberstrikeItemType ItemType { get; }

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000F0F RID: 3855 RVA: 0x0000A490 File Offset: 0x00008690
		// (set) Token: 0x06000F10 RID: 3856 RVA: 0x0000A498 File Offset: 0x00008698
		public UberstrikeItemClass ItemClass
		{
			get
			{
				return this._itemClass;
			}
			set
			{
				this._itemClass = value;
			}
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000F11 RID: 3857 RVA: 0x0000A4A1 File Offset: 0x000086A1
		// (set) Token: 0x06000F12 RID: 3858 RVA: 0x0000A4A9 File Offset: 0x000086A9
		public int ID { get; set; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000F13 RID: 3859 RVA: 0x0000A4B2 File Offset: 0x000086B2
		// (set) Token: 0x06000F14 RID: 3860 RVA: 0x0000A4BA File Offset: 0x000086BA
		public string Name { get; set; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000F15 RID: 3861 RVA: 0x0000A4C3 File Offset: 0x000086C3
		// (set) Token: 0x06000F16 RID: 3862 RVA: 0x0000A4CB File Offset: 0x000086CB
		public string PrefabName { get; set; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000F17 RID: 3863 RVA: 0x0000A4D4 File Offset: 0x000086D4
		// (set) Token: 0x06000F18 RID: 3864 RVA: 0x0000A4DC File Offset: 0x000086DC
		public string Description { get; set; }

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06000F19 RID: 3865 RVA: 0x0000A4E5 File Offset: 0x000086E5
		// (set) Token: 0x06000F1A RID: 3866 RVA: 0x0000A4ED File Offset: 0x000086ED
		public int LevelLock { get; set; }

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x06000F1B RID: 3867 RVA: 0x0000A4F6 File Offset: 0x000086F6
		// (set) Token: 0x06000F1C RID: 3868 RVA: 0x0000A4FE File Offset: 0x000086FE
		public int MaxDurationDays { get; set; }

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x0000A507 File Offset: 0x00008707
		// (set) Token: 0x06000F1E RID: 3870 RVA: 0x0000A50F File Offset: 0x0000870F
		public bool IsConsumable { get; set; }

		// Token: 0x17000322 RID: 802
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x0000A518 File Offset: 0x00008718
		// (set) Token: 0x06000F20 RID: 3872 RVA: 0x0000A520 File Offset: 0x00008720
		public ICollection<ItemPrice> Prices { get; set; }

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x0000A529 File Offset: 0x00008729
		public bool IsForSale
		{
			get
			{
				return this.Prices != null && this.Prices.Count > 0;
			}
		}

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000F22 RID: 3874 RVA: 0x0000A547 File Offset: 0x00008747
		// (set) Token: 0x06000F23 RID: 3875 RVA: 0x0000A54F File Offset: 0x0000874F
		public ItemShopHighlightType ShopHighlightType { get; set; }

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000F24 RID: 3876 RVA: 0x0000A558 File Offset: 0x00008758
		// (set) Token: 0x06000F25 RID: 3877 RVA: 0x0000A560 File Offset: 0x00008760
		public Dictionary<string, string> CustomProperties { get; set; }

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000F26 RID: 3878 RVA: 0x0000A569 File Offset: 0x00008769
		// (set) Token: 0x06000F27 RID: 3879 RVA: 0x0000A571 File Offset: 0x00008771
		public Dictionary<ItemPropertyType, int> ItemProperties { get; set; }

		// Token: 0x04000BFC RID: 3068
		[SerializeField]
		private UberstrikeItemClass _itemClass;
	}
}
