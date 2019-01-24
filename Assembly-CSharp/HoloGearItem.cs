using System;
using UnityEngine;

// Token: 0x02000249 RID: 585
public class HoloGearItem : BaseUnityItem
{
	// Token: 0x170003D9 RID: 985
	// (get) Token: 0x06001023 RID: 4131 RVA: 0x0000B4B8 File Offset: 0x000096B8
	// (set) Token: 0x06001024 RID: 4132 RVA: 0x0000B4C0 File Offset: 0x000096C0
	public HoloGearItemConfiguration Configuration
	{
		get
		{
			return this._config;
		}
		set
		{
			this._config = value;
		}
	}

	// Token: 0x04000DEE RID: 3566
	[SerializeField]
	private HoloGearItemConfiguration _config;
}
