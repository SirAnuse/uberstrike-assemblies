using System;
using UnityEngine;

// Token: 0x0200033C RID: 828
public class HUDWeaponScrollItem : MonoBehaviour
{
	// Token: 0x17000551 RID: 1361
	// (set) Token: 0x06001713 RID: 5907 RVA: 0x0000F872 File Offset: 0x0000DA72
	public string WeaponName
	{
		set
		{
			this.weaponName.text = value;
		}
	}

	// Token: 0x04001605 RID: 5637
	[SerializeField]
	private UILabel weaponName;
}
