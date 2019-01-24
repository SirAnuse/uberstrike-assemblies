using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
[RequireComponent(typeof(BoxCollider))]
public class WaterGate : SecretDoor
{
	// Token: 0x0600121B RID: 4635 RVA: 0x0006AC90 File Offset: 0x00068E90
	private void Awake()
	{
		this._state = WaterGate.DoorState.Closed;
		foreach (WaterGate.DoorElement doorElement in this._elements)
		{
			doorElement.ClosedPosition = doorElement.Element.transform.localPosition;
		}
		this._doorID = base.transform.position.GetHashCode();
	}

	// Token: 0x0600121C RID: 4636 RVA: 0x0000C870 File Offset: 0x0000AA70
	public override void Open()
	{
		GameState.Current.Actions.OpenDoor(this.DoorID);
		this.OpenDoor();
	}

	// Token: 0x0600121D RID: 4637 RVA: 0x0006ACF4 File Offset: 0x00068EF4
	private void OpenDoor()
	{
		switch (this._state)
		{
		case WaterGate.DoorState.Closed:
			this._state = WaterGate.DoorState.Opening;
			this._currentTime = 0f;
			break;
		case WaterGate.DoorState.Open:
			this._timeToClose = Time.time + 2f;
			break;
		case WaterGate.DoorState.Closing:
			this._state = WaterGate.DoorState.Opening;
			this._currentTime = this._maxTime - this._currentTime;
			break;
		}
		if (base.audio)
		{
			base.audio.Play();
		}
	}

	// Token: 0x0600121E RID: 4638 RVA: 0x0000C892 File Offset: 0x0000AA92
	private void OnEnable()
	{
		global::EventHandler.Global.AddListener<GameEvents.DoorOpened>(new Action<GameEvents.DoorOpened>(this.OnDoorOpenedEvent));
	}

	// Token: 0x0600121F RID: 4639 RVA: 0x0000C8AA File Offset: 0x0000AAAA
	private void OnDisable()
	{
		global::EventHandler.Global.RemoveListener<GameEvents.DoorOpened>(new Action<GameEvents.DoorOpened>(this.OnDoorOpenedEvent));
	}

	// Token: 0x06001220 RID: 4640 RVA: 0x0000C8C2 File Offset: 0x0000AAC2
	private void OnDoorOpenedEvent(GameEvents.DoorOpened ev)
	{
		if (this.DoorID == ev.DoorID)
		{
			this.OpenDoor();
		}
	}

	// Token: 0x06001221 RID: 4641 RVA: 0x0000C8DB File Offset: 0x0000AADB
	private void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			this.Open();
		}
	}

	// Token: 0x06001222 RID: 4642 RVA: 0x0000C8F8 File Offset: 0x0000AAF8
	private void OnTriggerStay(Collider c)
	{
		if (c.tag == "Player")
		{
			this._timeToClose = Time.time + 2f;
		}
	}

	// Token: 0x06001223 RID: 4643 RVA: 0x0006AD90 File Offset: 0x00068F90
	private void Update()
	{
		if (this._state == WaterGate.DoorState.Opening)
		{
			this._currentTime += Time.deltaTime;
			foreach (WaterGate.DoorElement doorElement in this._elements)
			{
				doorElement.Element.transform.localPosition = Vector3.Lerp(doorElement.ClosedPosition, doorElement.OpenPosition, this._currentTime / this._maxTime);
			}
			if (this._currentTime >= this._maxTime)
			{
				this._state = WaterGate.DoorState.Open;
				this._timeToClose = Time.time + 2f;
				if (base.audio)
				{
					base.audio.Stop();
				}
			}
		}
		else if (this._state == WaterGate.DoorState.Open)
		{
			if (this._timeToClose < Time.time)
			{
				this._state = WaterGate.DoorState.Closing;
				this._currentTime = 0f;
				if (base.audio)
				{
					base.audio.Play();
				}
			}
		}
		else if (this._state == WaterGate.DoorState.Closing)
		{
			this._currentTime += Time.deltaTime;
			foreach (WaterGate.DoorElement doorElement2 in this._elements)
			{
				doorElement2.Element.transform.localPosition = Vector3.Lerp(doorElement2.OpenPosition, doorElement2.ClosedPosition, this._currentTime / this._maxTime);
			}
			if (this._currentTime >= this._maxTime)
			{
				this._state = WaterGate.DoorState.Closed;
				if (base.audio)
				{
					base.audio.Stop();
				}
			}
		}
	}

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x06001224 RID: 4644 RVA: 0x0000C920 File Offset: 0x0000AB20
	public int DoorID
	{
		get
		{
			return this._doorID;
		}
	}

	// Token: 0x04000EFC RID: 3836
	[SerializeField]
	private float _maxTime = 1f;

	// Token: 0x04000EFD RID: 3837
	[SerializeField]
	private WaterGate.DoorElement[] _elements;

	// Token: 0x04000EFE RID: 3838
	private WaterGate.DoorState _state;

	// Token: 0x04000EFF RID: 3839
	private float _currentTime;

	// Token: 0x04000F00 RID: 3840
	private float _timeToClose;

	// Token: 0x04000F01 RID: 3841
	private int _doorID;

	// Token: 0x02000292 RID: 658
	private enum DoorState
	{
		// Token: 0x04000F03 RID: 3843
		Closed,
		// Token: 0x04000F04 RID: 3844
		Opening,
		// Token: 0x04000F05 RID: 3845
		Open,
		// Token: 0x04000F06 RID: 3846
		Closing
	}

	// Token: 0x02000293 RID: 659
	[Serializable]
	public class DoorElement
	{
		// Token: 0x04000F07 RID: 3847
		[HideInInspector]
		public Vector3 ClosedPosition;

		// Token: 0x04000F08 RID: 3848
		[HideInInspector]
		public Quaternion ClosedRotation;

		// Token: 0x04000F09 RID: 3849
		public GameObject Element;

		// Token: 0x04000F0A RID: 3850
		public Vector3 OpenPosition;
	}
}
