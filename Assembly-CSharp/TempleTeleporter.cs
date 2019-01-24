using System;
using UnityEngine;

// Token: 0x0200028F RID: 655
[RequireComponent(typeof(BoxCollider))]
public class TempleTeleporter : SecretDoor
{
	// Token: 0x0600120D RID: 4621 RVA: 0x0006A9EC File Offset: 0x00068BEC
	private void Awake()
	{
		this._audios = base.GetComponents<AudioSource>();
		this._particles.emit = false;
		foreach (Renderer renderer in this._visuals)
		{
			renderer.enabled = false;
		}
		this._doorID = base.transform.position.GetHashCode();
	}

	// Token: 0x0600120E RID: 4622 RVA: 0x0000C7B0 File Offset: 0x0000A9B0
	private void OnEnable()
	{
		global::EventHandler.Global.AddListener<GameEvents.DoorOpened>(new Action<GameEvents.DoorOpened>(this.OnDoorOpenedEvent));
	}

	// Token: 0x0600120F RID: 4623 RVA: 0x0000C7C8 File Offset: 0x0000A9C8
	private void OnDisable()
	{
		global::EventHandler.Global.RemoveListener<GameEvents.DoorOpened>(new Action<GameEvents.DoorOpened>(this.OnDoorOpenedEvent));
	}

	// Token: 0x06001210 RID: 4624 RVA: 0x0006AA50 File Offset: 0x00068C50
	private void Update()
	{
		if (this._timeOut < Time.time)
		{
			foreach (AudioSource audioSource in this._audios)
			{
				audioSource.Stop();
			}
			this._particles.emit = false;
			foreach (Renderer renderer in this._visuals)
			{
				renderer.enabled = false;
			}
			base.enabled = false;
		}
	}

	// Token: 0x06001211 RID: 4625 RVA: 0x0006AAD4 File Offset: 0x00068CD4
	private void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player" && this._timeOut > Time.time)
		{
			this._timeOut = 0f;
			GameState.Current.Player.SpawnPlayerAt(this._spawnpoint.position, this._spawnpoint.rotation);
		}
	}

	// Token: 0x06001212 RID: 4626 RVA: 0x0000C7E0 File Offset: 0x0000A9E0
	private void OnDoorOpenedEvent(GameEvents.DoorOpened ev)
	{
		if (this.DoorID == ev.DoorID)
		{
			this.OpenDoor();
		}
	}

	// Token: 0x06001213 RID: 4627 RVA: 0x0000C7F9 File Offset: 0x0000A9F9
	public override void Open()
	{
		if (GameState.Current.HasJoinedGame)
		{
			GameState.Current.Actions.OpenDoor(this.DoorID);
		}
		this.OpenDoor();
	}

	// Token: 0x06001214 RID: 4628 RVA: 0x0006AB38 File Offset: 0x00068D38
	private void OpenDoor()
	{
		base.enabled = true;
		this._particles.emit = true;
		foreach (Renderer renderer in this._visuals)
		{
			renderer.enabled = true;
		}
		this._timeOut = Time.time + this._activationTime;
		foreach (AudioSource audioSource in this._audios)
		{
			audioSource.Play();
		}
	}

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x06001215 RID: 4629 RVA: 0x0000C82A File Offset: 0x0000AA2A
	public int DoorID
	{
		get
		{
			return this._doorID;
		}
	}

	// Token: 0x04000EF4 RID: 3828
	[SerializeField]
	private float _activationTime = 15f;

	// Token: 0x04000EF5 RID: 3829
	[SerializeField]
	private Renderer[] _visuals;

	// Token: 0x04000EF6 RID: 3830
	[SerializeField]
	private Transform _spawnpoint;

	// Token: 0x04000EF7 RID: 3831
	[SerializeField]
	private ParticleEmitter _particles;

	// Token: 0x04000EF8 RID: 3832
	private int _doorID;

	// Token: 0x04000EF9 RID: 3833
	private float _timeOut;

	// Token: 0x04000EFA RID: 3834
	private AudioSource[] _audios;
}
