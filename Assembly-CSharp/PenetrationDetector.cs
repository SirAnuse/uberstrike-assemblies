using System;
using UnityEngine;

// Token: 0x02000370 RID: 880
[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PenetrationDetector : MonoBehaviour
{
	// Token: 0x060018EB RID: 6379 RVA: 0x00010A3B File Offset: 0x0000EC3B
	private void OnTriggerEnter(Collider c)
	{
		if (!c.isTrigger)
		{
			base.Invoke("KillPlayer", 0f);
		}
	}

	// Token: 0x060018EC RID: 6380 RVA: 0x00085888 File Offset: 0x00083A88
	private void KillPlayer()
	{
		if (this.controller)
		{
			this.controller.transform.position -= 0.5f * this.controller.velocity.normalized;
		}
		GameState.Current.Actions.KillPlayer();
	}

	// Token: 0x04001753 RID: 5971
	[SerializeField]
	private CharacterController controller;
}
