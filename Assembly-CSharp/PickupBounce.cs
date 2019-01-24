using System;
using UnityEngine;

// Token: 0x02000288 RID: 648
public class PickupBounce : MonoBehaviour
{
	// Token: 0x060011EF RID: 4591 RVA: 0x0006A3CC File Offset: 0x000685CC
	private void Awake()
	{
		this.origPosY = base.transform.position.y;
		this.startOffset = UnityEngine.Random.value * 3f;
	}

	// Token: 0x060011F0 RID: 4592 RVA: 0x0006A404 File Offset: 0x00068604
	private void FixedUpdate()
	{
		base.transform.Rotate(new Vector3(0f, 2f, 0f));
		base.transform.position = new Vector3(base.transform.position.x, this.origPosY + Mathf.Sin((this.startOffset + Time.realtimeSinceStartup) * 4f) * 0.08f, base.transform.position.z);
	}

	// Token: 0x04000EDC RID: 3804
	private float origPosY;

	// Token: 0x04000EDD RID: 3805
	private float startOffset;
}
