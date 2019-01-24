using System;

// Token: 0x02000226 RID: 550
public class PlayerDropPickupItem : PickupItem
{
	// Token: 0x06000F36 RID: 3894 RVA: 0x00003C84 File Offset: 0x00001E84
	protected override bool OnPlayerPickup()
	{
		return false;
	}

	// Token: 0x06000F37 RID: 3895 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRemotePickup()
	{
	}
}
