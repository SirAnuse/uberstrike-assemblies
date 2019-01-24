using System;
using UnityEngine;

// Token: 0x0200027A RID: 634
[RequireComponent(typeof(Collider))]
public class DeathArea : MonoBehaviour
{
	// Token: 0x060011B4 RID: 4532 RVA: 0x0000C421 File Offset: 0x0000A621
	private void Awake()
	{
		if (base.collider)
		{
			base.collider.isTrigger = true;
		}
	}

	// Token: 0x060011B5 RID: 4533 RVA: 0x0000C43F File Offset: 0x0000A63F
	private void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			GameState.Current.Actions.KillPlayer();
		}
	}
}
