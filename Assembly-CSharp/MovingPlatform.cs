using System;
using UnityEngine;

// Token: 0x02000287 RID: 647
public class MovingPlatform : MonoBehaviour
{
	// Token: 0x060011EB RID: 4587 RVA: 0x0000C6BC File Offset: 0x0000A8BC
	private void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			this.lastPosition = base.transform.position;
			this.player = c.transform;
		}
	}

	// Token: 0x060011EC RID: 4588 RVA: 0x0000C6F0 File Offset: 0x0000A8F0
	private void OnTriggerExit(Collider c)
	{
		if (c.tag == "Player")
		{
			this.player = null;
		}
	}

	// Token: 0x060011ED RID: 4589 RVA: 0x0006A370 File Offset: 0x00068570
	private void LateUpdate()
	{
		if (this.player)
		{
			this.player.localPosition += base.transform.position - this.lastPosition;
			this.lastPosition = base.transform.position;
		}
	}

	// Token: 0x04000EDA RID: 3802
	private Transform player;

	// Token: 0x04000EDB RID: 3803
	private Vector3 lastPosition;
}
