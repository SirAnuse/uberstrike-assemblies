using System;
using UnityEngine;

// Token: 0x020003E5 RID: 997
public class IntegerProperty : Property<int>
{
	// Token: 0x06001D07 RID: 7431 RVA: 0x000134E1 File Offset: 0x000116E1
	public IntegerProperty(int value = 0, int min = -2147483648, int max = 2147483647)
	{
		this.Min = min;
		this.Max = max;
		this.Value = value;
	}

	// Token: 0x17000661 RID: 1633
	// (get) Token: 0x06001D08 RID: 7432 RVA: 0x000134FE File Offset: 0x000116FE
	// (set) Token: 0x06001D09 RID: 7433 RVA: 0x00013506 File Offset: 0x00011706
	public int Min { get; private set; }

	// Token: 0x17000662 RID: 1634
	// (get) Token: 0x06001D0A RID: 7434 RVA: 0x0001350F File Offset: 0x0001170F
	// (set) Token: 0x06001D0B RID: 7435 RVA: 0x00013517 File Offset: 0x00011717
	public int Max { get; private set; }

	// Token: 0x17000663 RID: 1635
	// (get) Token: 0x06001D0C RID: 7436 RVA: 0x00013520 File Offset: 0x00011720
	// (set) Token: 0x06001D0D RID: 7437 RVA: 0x00013528 File Offset: 0x00011728
	public override int Value
	{
		get
		{
			return base.Value;
		}
		set
		{
			base.Value = Mathf.Clamp(value, this.Min, this.Max);
		}
	}
}
