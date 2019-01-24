using System;
using Cmune.DataCenter.Common.Entities;

// Token: 0x0200010F RID: 271
public class BundleUnityView
{
	// Token: 0x060007ED RID: 2029 RVA: 0x00007044 File Offset: 0x00005244
	public BundleUnityView(BundleView bundleView)
	{
		this.BundleView = bundleView;
		this.Icon = new DynamicTexture(this.BundleView.IconUrl, false);
		this.Image = new DynamicTexture(this.BundleView.ImageUrl, false);
	}

	// Token: 0x1700024B RID: 587
	// (get) Token: 0x060007EE RID: 2030 RVA: 0x00007081 File Offset: 0x00005281
	// (set) Token: 0x060007EF RID: 2031 RVA: 0x00007089 File Offset: 0x00005289
	public BundleView BundleView { get; private set; }

	// Token: 0x1700024C RID: 588
	// (get) Token: 0x060007F0 RID: 2032 RVA: 0x00007092 File Offset: 0x00005292
	// (set) Token: 0x060007F1 RID: 2033 RVA: 0x0000709A File Offset: 0x0000529A
	public string CurrencySymbol { get; set; }

	// Token: 0x1700024D RID: 589
	// (get) Token: 0x060007F2 RID: 2034 RVA: 0x000070A3 File Offset: 0x000052A3
	// (set) Token: 0x060007F3 RID: 2035 RVA: 0x000070AB File Offset: 0x000052AB
	public string Price { get; set; }

	// Token: 0x1700024E RID: 590
	// (get) Token: 0x060007F4 RID: 2036 RVA: 0x000070B4 File Offset: 0x000052B4
	// (set) Token: 0x060007F5 RID: 2037 RVA: 0x000070BC File Offset: 0x000052BC
	public DynamicTexture Icon { get; private set; }

	// Token: 0x1700024F RID: 591
	// (get) Token: 0x060007F6 RID: 2038 RVA: 0x000070C5 File Offset: 0x000052C5
	// (set) Token: 0x060007F7 RID: 2039 RVA: 0x000070CD File Offset: 0x000052CD
	public DynamicTexture Image { get; private set; }

	// Token: 0x17000250 RID: 592
	// (get) Token: 0x060007F8 RID: 2040 RVA: 0x000070D6 File Offset: 0x000052D6
	// (set) Token: 0x060007F9 RID: 2041 RVA: 0x000070DE File Offset: 0x000052DE
	public bool IsOwned { get; set; }

	// Token: 0x17000251 RID: 593
	// (get) Token: 0x060007FA RID: 2042 RVA: 0x000070E7 File Offset: 0x000052E7
	public bool IsValid
	{
		get
		{
			return !string.IsNullOrEmpty(this.Price);
		}
	}

	// Token: 0x17000252 RID: 594
	// (get) Token: 0x060007FB RID: 2043 RVA: 0x000070F7 File Offset: 0x000052F7
	public BundleCategoryType Category
	{
		get
		{
			return this.BundleView.Category;
		}
	}
}
