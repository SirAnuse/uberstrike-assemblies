using System;
using UnityEngine;

// Token: 0x0200028C RID: 652
[RequireComponent(typeof(Collider))]
public class SpawnPlayer : MonoBehaviour
{
	// Token: 0x060011FF RID: 4607 RVA: 0x0006A69C File Offset: 0x0006889C
	private void Awake()
	{
		this._transform = base.transform;
		this._startPosition = (this._currentPosition = this._transform.localPosition);
	}

	// Token: 0x06001200 RID: 4608 RVA: 0x0006A6D0 File Offset: 0x000688D0
	private void Update()
	{
		this._currentPosition.y = this._startPosition.y + Mathf.Sin(Time.time * this._velocity) * this._amplitude;
		this._transform.localPosition = this._currentPosition;
	}

	// Token: 0x06001201 RID: 4609 RVA: 0x0006A720 File Offset: 0x00068920
	private void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player" && this._nextTeleport < Time.time)
		{
			this._nextTeleport = Time.time + 5f;
			GameState.Current.Player.SpawnPlayerAt(this._spawnTo.position, this._spawnTo.rotation);
		}
	}

	// Token: 0x04000EE6 RID: 3814
	[SerializeField]
	private float _amplitude = 20f;

	// Token: 0x04000EE7 RID: 3815
	[SerializeField]
	private float _velocity = 0.1f;

	// Token: 0x04000EE8 RID: 3816
	[SerializeField]
	private Vector3 _startPosition;

	// Token: 0x04000EE9 RID: 3817
	private Vector3 _currentPosition;

	// Token: 0x04000EEA RID: 3818
	[SerializeField]
	private Transform _spawnTo;

	// Token: 0x04000EEB RID: 3819
	private Transform _transform;

	// Token: 0x04000EEC RID: 3820
	private float _nextTeleport;
}
