using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000227 RID: 551
public class WeaponPickupItem : PickupItem
{
	// Token: 0x06000F39 RID: 3897 RVA: 0x00003C84 File Offset: 0x00001E84
	protected override bool OnPlayerPickup()
	{
		return false;
	}

	// Token: 0x06000F3A RID: 3898 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRemotePickup()
	{
	}

	// Token: 0x04000D78 RID: 3448
	[SerializeField]
	private UberstrikeItemClass _weaponType;
}
