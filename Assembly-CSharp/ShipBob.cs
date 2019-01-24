using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class ShipBob : MonoBehaviour
{
	// Token: 0x06001B67 RID: 7015 RVA: 0x0008CFE4 File Offset: 0x0008B1E4
	private void Awake()
	{
		this._transform = base.transform;
		this.shipRotation = this._transform.localRotation.eulerAngles;
	}

	// Token: 0x06001B68 RID: 7016 RVA: 0x0008D018 File Offset: 0x0008B218
	private void Update()
	{
		this._transform.position = new Vector3(this._transform.position.x, this._transform.position.y + Mathf.Sin(Time.time) * this.moveAmount, this._transform.position.z);
		float num = Mathf.Sin(Time.time) * this.rotateAmount;
		this._transform.localRotation = Quaternion.Euler(this.shipRotation + new Vector3(num, num, num));
	}

	// Token: 0x0400186A RID: 6250
	[SerializeField]
	private float rotateAmount = 1f;

	// Token: 0x0400186B RID: 6251
	[SerializeField]
	private float moveAmount = 0.005f;

	// Token: 0x0400186C RID: 6252
	private Transform _transform;

	// Token: 0x0400186D RID: 6253
	private Vector3 shipRotation;
}
