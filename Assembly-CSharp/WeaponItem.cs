using System;
using UnityEngine;

// Token: 0x0200024E RID: 590
public class WeaponItem : BaseUnityItem
{
	// Token: 0x170003EB RID: 1003
	// (get) Token: 0x06001048 RID: 4168 RVA: 0x0000B5A8 File Offset: 0x000097A8
	// (set) Token: 0x06001049 RID: 4169 RVA: 0x0000B5B0 File Offset: 0x000097B0
	public WeaponItemConfiguration Configuration
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

	// Token: 0x04000DF9 RID: 3577
	[SerializeField]
	private WeaponItemConfiguration _config;
}
