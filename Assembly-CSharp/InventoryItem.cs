using System;
using UnityEngine;

// Token: 0x0200024A RID: 586
public class InventoryItem
{
	// Token: 0x06001025 RID: 4133 RVA: 0x0000B4C9 File Offset: 0x000096C9
	public InventoryItem(IUnityItem item)
	{
		this._item = item;
	}

	// Token: 0x170003DA RID: 986
	// (get) Token: 0x06001026 RID: 4134 RVA: 0x0000B4D8 File Offset: 0x000096D8
	public IUnityItem Item
	{
		get
		{
			return this._item;
		}
	}

	// Token: 0x170003DB RID: 987
	// (get) Token: 0x06001027 RID: 4135 RVA: 0x00065CD0 File Offset: 0x00063ED0
	public int DaysRemaining
	{
		get
		{
			return (this.IsPermanent || this.ExpirationDate == null) ? 0 : Mathf.CeilToInt((float)this.ExpirationDate.Value.Subtract(ApplicationDataManager.ServerDateTime).TotalHours / 24f);
		}
	}

	// Token: 0x170003DC RID: 988
	// (get) Token: 0x06001028 RID: 4136 RVA: 0x0000B4E0 File Offset: 0x000096E0
	// (set) Token: 0x06001029 RID: 4137 RVA: 0x0000B4E8 File Offset: 0x000096E8
	public int AmountRemaining { get; set; }

	// Token: 0x170003DD RID: 989
	// (get) Token: 0x0600102A RID: 4138 RVA: 0x0000B4F1 File Offset: 0x000096F1
	// (set) Token: 0x0600102B RID: 4139 RVA: 0x0000B4F9 File Offset: 0x000096F9
	public bool IsPermanent { get; set; }

	// Token: 0x170003DE RID: 990
	// (get) Token: 0x0600102C RID: 4140 RVA: 0x0000B502 File Offset: 0x00009702
	// (set) Token: 0x0600102D RID: 4141 RVA: 0x0000B50A File Offset: 0x0000970A
	public DateTime? ExpirationDate { get; set; }

	// Token: 0x170003DF RID: 991
	// (get) Token: 0x0600102E RID: 4142 RVA: 0x0000B513 File Offset: 0x00009713
	// (set) Token: 0x0600102F RID: 4143 RVA: 0x0000B51B File Offset: 0x0000971B
	public bool IsHighlighted { get; set; }

	// Token: 0x170003E0 RID: 992
	// (get) Token: 0x06001030 RID: 4144 RVA: 0x0000B524 File Offset: 0x00009724
	public bool IsValid
	{
		get
		{
			return this.IsPermanent || this.DaysRemaining > 0;
		}
	}

	// Token: 0x04000DEF RID: 3567
	private IUnityItem _item;
}
