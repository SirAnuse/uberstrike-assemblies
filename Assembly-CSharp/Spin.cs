using System;
using UnityEngine;

// Token: 0x0200005F RID: 95
[AddComponentMenu("NGUI/Examples/Spin")]
public class Spin : MonoBehaviour
{
	// Token: 0x06000277 RID: 631 RVA: 0x00003D12 File Offset: 0x00001F12
	private void Start()
	{
		this.mTrans = base.transform;
		this.mRb = base.rigidbody;
	}

	// Token: 0x06000278 RID: 632 RVA: 0x00003D2C File Offset: 0x00001F2C
	private void Update()
	{
		if (this.mRb == null)
		{
			this.ApplyDelta(Time.deltaTime);
		}
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00003D4A File Offset: 0x00001F4A
	private void FixedUpdate()
	{
		if (this.mRb != null)
		{
			this.ApplyDelta(Time.deltaTime);
		}
	}

	// Token: 0x0600027A RID: 634 RVA: 0x00020F0C File Offset: 0x0001F10C
	public void ApplyDelta(float delta)
	{
		delta *= 360f;
		Quaternion rhs = Quaternion.Euler(this.rotationsPerSecond * delta);
		if (this.mRb == null)
		{
			this.mTrans.rotation = this.mTrans.rotation * rhs;
		}
		else
		{
			this.mRb.MoveRotation(this.mRb.rotation * rhs);
		}
	}

	// Token: 0x04000218 RID: 536
	public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);

	// Token: 0x04000219 RID: 537
	private Rigidbody mRb;

	// Token: 0x0400021A RID: 538
	private Transform mTrans;
}
