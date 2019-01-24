using System;
using UnityEngine;

// Token: 0x0200027B RID: 635
[RequireComponent(typeof(Collider))]
public class DoorBehaviour : MonoBehaviour
{
	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x060011B7 RID: 4535 RVA: 0x0000C47D File Offset: 0x0000A67D
	public int DoorID
	{
		get
		{
			return this._doorID;
		}
	}

	// Token: 0x060011B8 RID: 4536 RVA: 0x00069BF4 File Offset: 0x00067DF4
	private void Awake()
	{
		foreach (DoorBehaviour.DoorElement doorElement in this._elements)
		{
			doorElement.Element.SetDoorLogic(this);
			doorElement.ClosedPosition = doorElement.Element.transform.localPosition;
		}
		this._doorID = base.transform.position.GetHashCode();
	}

	// Token: 0x060011B9 RID: 4537 RVA: 0x0000C485 File Offset: 0x0000A685
	private void OnEnable()
	{
		global::EventHandler.Global.AddListener<GameEvents.DoorOpened>(new Action<GameEvents.DoorOpened>(this.OnDoorOpenedEvent));
	}

	// Token: 0x060011BA RID: 4538 RVA: 0x0000C49D File Offset: 0x0000A69D
	private void OnDisable()
	{
		global::EventHandler.Global.RemoveListener<GameEvents.DoorOpened>(new Action<GameEvents.DoorOpened>(this.OnDoorOpenedEvent));
	}

	// Token: 0x060011BB RID: 4539 RVA: 0x0000C4B5 File Offset: 0x0000A6B5
	private void OnDoorOpenedEvent(GameEvents.DoorOpened ev)
	{
		if (this.DoorID == ev.DoorID)
		{
			this.OpenDoor();
		}
	}

	// Token: 0x060011BC RID: 4540 RVA: 0x0000C4CE File Offset: 0x0000A6CE
	private void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			this.Open();
		}
	}

	// Token: 0x060011BD RID: 4541 RVA: 0x0000C4EB File Offset: 0x0000A6EB
	private void OnTriggerStay(Collider c)
	{
		if (c.tag == "Player")
		{
			this._timeToClose = Time.time + 2f;
		}
	}

	// Token: 0x060011BE RID: 4542 RVA: 0x00069C5C File Offset: 0x00067E5C
	private void OpenDoor()
	{
		switch (this._state)
		{
		case DoorBehaviour.DoorState.Closed:
			this._state = DoorBehaviour.DoorState.Opening;
			this._currentTime = 0f;
			if (base.audio)
			{
				base.audio.Play();
			}
			break;
		case DoorBehaviour.DoorState.Open:
			this._timeToClose = Time.time + 2f;
			break;
		case DoorBehaviour.DoorState.Closing:
			this._state = DoorBehaviour.DoorState.Opening;
			this._currentTime = this._maxTime - this._currentTime;
			break;
		}
	}

	// Token: 0x060011BF RID: 4543 RVA: 0x0000C513 File Offset: 0x0000A713
	public void Open()
	{
		GameState.Current.Actions.OpenDoor(this.DoorID);
		this.OpenDoor();
	}

	// Token: 0x060011C0 RID: 4544 RVA: 0x0000C535 File Offset: 0x0000A735
	public void Close()
	{
		this._state = DoorBehaviour.DoorState.Closing;
		this._currentTime = 0f;
		if (base.audio)
		{
			base.audio.Play();
		}
	}

	// Token: 0x060011C1 RID: 4545 RVA: 0x00069CF8 File Offset: 0x00067EF8
	private void Update()
	{
		float num = this._maxTime;
		if (this._maxTime == 0f)
		{
			num = 1f;
		}
		if (this._state == DoorBehaviour.DoorState.Opening)
		{
			this._currentTime += Time.deltaTime;
			foreach (DoorBehaviour.DoorElement doorElement in this._elements)
			{
				doorElement.Element.transform.localPosition = Vector3.Lerp(doorElement.ClosedPosition, doorElement.OpenPosition, this._currentTime / num);
			}
			if (this._currentTime >= num)
			{
				this._state = DoorBehaviour.DoorState.Open;
				this._timeToClose = Time.time + 2f;
				if (base.audio)
				{
					base.audio.Stop();
				}
			}
		}
		else if (this._state == DoorBehaviour.DoorState.Open)
		{
			if (this._maxTime != 0f && this._timeToClose < Time.time)
			{
				this._state = DoorBehaviour.DoorState.Closing;
				this._currentTime = 0f;
				if (base.audio)
				{
					base.audio.Play();
				}
			}
		}
		else if (this._state == DoorBehaviour.DoorState.Closing)
		{
			this._currentTime += Time.deltaTime;
			foreach (DoorBehaviour.DoorElement doorElement2 in this._elements)
			{
				doorElement2.Element.transform.localPosition = Vector3.Lerp(doorElement2.OpenPosition, doorElement2.ClosedPosition, this._currentTime / num);
			}
			if (this._currentTime >= num)
			{
				this._state = DoorBehaviour.DoorState.Closed;
				if (base.audio)
				{
					base.audio.Stop();
				}
			}
		}
	}

	// Token: 0x04000EAC RID: 3756
	[SerializeField]
	private DoorBehaviour.DoorElement[] _elements;

	// Token: 0x04000EAD RID: 3757
	[SerializeField]
	private float _maxTime = 1f;

	// Token: 0x04000EAE RID: 3758
	private DoorBehaviour.DoorState _state;

	// Token: 0x04000EAF RID: 3759
	private float _currentTime;

	// Token: 0x04000EB0 RID: 3760
	private float _timeToClose;

	// Token: 0x04000EB1 RID: 3761
	private int _doorID;

	// Token: 0x0200027C RID: 636
	private enum DoorState
	{
		// Token: 0x04000EB3 RID: 3763
		Closed,
		// Token: 0x04000EB4 RID: 3764
		Opening,
		// Token: 0x04000EB5 RID: 3765
		Open,
		// Token: 0x04000EB6 RID: 3766
		Closing
	}

	// Token: 0x0200027D RID: 637
	[Serializable]
	public class DoorElement
	{
		// Token: 0x04000EB7 RID: 3767
		[HideInInspector]
		public Vector3 ClosedPosition;

		// Token: 0x04000EB8 RID: 3768
		[HideInInspector]
		public Quaternion ClosedRotation;

		// Token: 0x04000EB9 RID: 3769
		public DoorTrigger Element;

		// Token: 0x04000EBA RID: 3770
		public Vector3 OpenPosition;
	}
}
