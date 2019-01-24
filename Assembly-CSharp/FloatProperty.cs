using System;
using UnityEngine;

// Token: 0x020003E6 RID: 998
public class FloatProperty : Property<float>
{
	// Token: 0x06001D0E RID: 7438 RVA: 0x00013542 File Offset: 0x00011742
	public FloatProperty(float value = 0f, float min = -3.40282347E+38f, float max = 3.40282347E+38f)
	{
		this.Min = min;
		this.Max = max;
		this.Value = value;
	}

	// Token: 0x17000664 RID: 1636
	// (get) Token: 0x06001D0F RID: 7439 RVA: 0x0001355F File Offset: 0x0001175F
	// (set) Token: 0x06001D10 RID: 7440 RVA: 0x00013567 File Offset: 0x00011767
	public float Min { get; private set; }

	// Token: 0x17000665 RID: 1637
	// (get) Token: 0x06001D11 RID: 7441 RVA: 0x00013570 File Offset: 0x00011770
	// (set) Token: 0x06001D12 RID: 7442 RVA: 0x00013578 File Offset: 0x00011778
	public float Max { get; private set; }

	// Token: 0x17000666 RID: 1638
	// (get) Token: 0x06001D13 RID: 7443 RVA: 0x00013581 File Offset: 0x00011781
	// (set) Token: 0x06001D14 RID: 7444 RVA: 0x00013589 File Offset: 0x00011789
	public override float Value
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
