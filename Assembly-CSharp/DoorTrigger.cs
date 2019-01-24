using System;
using UnityEngine;

// Token: 0x0200027E RID: 638
public class DoorTrigger : BaseGameProp
{
	// Token: 0x060011C4 RID: 4548 RVA: 0x0000C564 File Offset: 0x0000A764
	private void Awake()
	{
		base.gameObject.layer = 21;
	}

	// Token: 0x060011C5 RID: 4549 RVA: 0x0000C573 File Offset: 0x0000A773
	public void SetDoorLogic(DoorBehaviour logic)
	{
		this._doorLogic = logic;
	}

	// Token: 0x060011C6 RID: 4550 RVA: 0x00069ECC File Offset: 0x000680CC
	public override void ApplyDamage(DamageInfo shot)
	{
		if (this._doorLogic)
		{
			this._doorLogic.Open();
		}
		else
		{
			Debug.LogError("The DoorCollider " + base.gameObject.name + " is not assigned to a DoorMechanism!");
		}
	}

	// Token: 0x04000EBB RID: 3771
	private DoorBehaviour _doorLogic;
}
