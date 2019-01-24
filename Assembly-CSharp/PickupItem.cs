using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000222 RID: 546
[RequireComponent(typeof(BoxCollider))]
public class PickupItem : MonoBehaviour
{
	// Token: 0x17000387 RID: 903
	// (get) Token: 0x06000F0D RID: 3853 RVA: 0x0000AD1C File Offset: 0x00008F1C
	// (set) Token: 0x06000F0E RID: 3854 RVA: 0x0000AD24 File Offset: 0x00008F24
	public bool IsAvailable
	{
		get
		{
			return this._isAvailable;
		}
		protected set
		{
			this._isAvailable = value;
		}
	}

	// Token: 0x06000F0F RID: 3855 RVA: 0x00063D20 File Offset: 0x00061F20
	protected virtual void Awake()
	{
		this._collider = base.GetComponent<Collider>();
		if (this._pickupItem)
		{
			this._renderers = this._pickupItem.GetComponentsInChildren<MeshRenderer>(true);
		}
		else
		{
			this._renderers = new MeshRenderer[0];
		}
		this._collider.isTrigger = true;
		if (this._emitter)
		{
			this._emitter.emit = false;
		}
		base.gameObject.layer = 2;
	}

	// Token: 0x06000F10 RID: 3856 RVA: 0x00063DA0 File Offset: 0x00061FA0
	private void OnEnable()
	{
		this.IsAvailable = true;
		this._pickupID = PickupItem.AddInstance(this);
		foreach (MeshRenderer renderer in this._renderers)
		{
			renderer.enabled = true;
		}
		global::EventHandler.Global.AddListener<GameEvents.PickupItemChanged>(new Action<GameEvents.PickupItemChanged>(this.OnRemotePickupEvent));
		global::EventHandler.Global.AddListener<GameEvents.PickupItemReset>(new Action<GameEvents.PickupItemReset>(this.OnResetEvent));
	}

	// Token: 0x06000F11 RID: 3857 RVA: 0x0000AD2D File Offset: 0x00008F2D
	private void OnDisable()
	{
		global::EventHandler.Global.RemoveListener<GameEvents.PickupItemChanged>(new Action<GameEvents.PickupItemChanged>(this.OnRemotePickupEvent));
		global::EventHandler.Global.RemoveListener<GameEvents.PickupItemReset>(new Action<GameEvents.PickupItemReset>(this.OnResetEvent));
	}

	// Token: 0x06000F12 RID: 3858 RVA: 0x0000AD5B File Offset: 0x00008F5B
	private void OnResetEvent(GameEvents.PickupItemReset ev)
	{
		base.StopAllCoroutines();
		this.SetItemAvailable(true);
	}

	// Token: 0x06000F13 RID: 3859 RVA: 0x0000AD6A File Offset: 0x00008F6A
	private void OnRemotePickupEvent(GameEvents.PickupItemChanged ev)
	{
		if (this.PickupID == ev.Id)
		{
			if (!ev.Enable && this.IsAvailable)
			{
				this.OnRemotePickup();
			}
			this.SetItemAvailable(ev.Enable);
		}
	}

	// Token: 0x06000F14 RID: 3860 RVA: 0x00003C87 File Offset: 0x00001E87
	protected virtual void OnRemotePickup()
	{
	}

	// Token: 0x06000F15 RID: 3861 RVA: 0x00063E14 File Offset: 0x00062014
	private void OnTriggerEnter(Collider c)
	{
		if (this.IsAvailable && c.tag == "Player" && GameState.Current.PlayerData.IsAlive && GameState.Current.IsMatchRunning && this.OnPlayerPickup())
		{
			this.SetItemAvailable(false);
		}
	}

	// Token: 0x06000F16 RID: 3862 RVA: 0x0000ADA5 File Offset: 0x00008FA5
	protected void PlayLocalPickupSound(AudioClip audioClip)
	{
		AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(audioClip, 0UL);
	}

	// Token: 0x06000F17 RID: 3863 RVA: 0x0000ADB4 File Offset: 0x00008FB4
	protected void PlayRemotePickupSound(AudioClip audioClip, Vector3 position)
	{
		AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(audioClip, position, 1f);
	}

	// Token: 0x06000F18 RID: 3864 RVA: 0x00063E78 File Offset: 0x00062078
	protected IEnumerator StartHidingPickupForSeconds(int seconds)
	{
		this.IsAvailable = false;
		ParticleEffectController.ShowPickUpEffect(this._pickupItem.position, 100);
		foreach (MeshRenderer r in this._renderers)
		{
			if (r != null)
			{
				r.enabled = false;
			}
		}
		if (seconds > 0)
		{
			yield return new WaitForSeconds((float)seconds);
			ParticleEffectController.ShowPickUpEffect(this._pickupItem.position, 5);
			yield return new WaitForSeconds(1f);
			foreach (MeshRenderer r2 in this._renderers)
			{
				r2.enabled = true;
			}
			this.IsAvailable = true;
		}
		else
		{
			base.enabled = false;
			yield return new WaitForSeconds(2f);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		yield break;
	}

	// Token: 0x06000F19 RID: 3865 RVA: 0x00063EA4 File Offset: 0x000620A4
	public void SetItemAvailable(bool isVisible)
	{
		if (isVisible)
		{
			ParticleEffectController.ShowPickUpEffect(this._pickupItem.position, 5);
		}
		else if (this.IsAvailable)
		{
			ParticleEffectController.ShowPickUpEffect(this._pickupItem.position, 100);
		}
		foreach (MeshRenderer renderer in this._renderers)
		{
			if (renderer)
			{
				renderer.enabled = isVisible;
			}
		}
		this.IsAvailable = isVisible;
	}

	// Token: 0x06000F1A RID: 3866 RVA: 0x00004D4D File Offset: 0x00002F4D
	protected virtual bool OnPlayerPickup()
	{
		return true;
	}

	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06000F1B RID: 3867 RVA: 0x00004D4D File Offset: 0x00002F4D
	protected virtual bool CanPlayerPickup
	{
		get
		{
			return true;
		}
	}

	// Token: 0x17000389 RID: 905
	// (get) Token: 0x06000F1C RID: 3868 RVA: 0x0000ADC7 File Offset: 0x00008FC7
	// (set) Token: 0x06000F1D RID: 3869 RVA: 0x0000ADCF File Offset: 0x00008FCF
	public int PickupID
	{
		get
		{
			return this._pickupID;
		}
		set
		{
			this._pickupID = value;
		}
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x06000F1E RID: 3870 RVA: 0x0000ADD8 File Offset: 0x00008FD8
	public int RespawnTime
	{
		get
		{
			return this._respawnTime;
		}
	}

	// Token: 0x06000F1F RID: 3871 RVA: 0x0000ADE0 File Offset: 0x00008FE0
	public static void Reset()
	{
		PickupItem._instanceCounter = 0;
		PickupItem._instances.Clear();
		PickupItem._pickupRespawnDurations.Clear();
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x0000ADFC File Offset: 0x00008FFC
	public static int GetInstanceCounter()
	{
		return PickupItem._instanceCounter;
	}

	// Token: 0x06000F21 RID: 3873 RVA: 0x0000AE03 File Offset: 0x00009003
	public static List<ushort> GetRespawnDurations()
	{
		return PickupItem._pickupRespawnDurations;
	}

	// Token: 0x06000F22 RID: 3874 RVA: 0x00063F24 File Offset: 0x00062124
	private static int AddInstance(PickupItem i)
	{
		int num = PickupItem._instanceCounter++;
		PickupItem._instances[num] = i;
		PickupItem._pickupRespawnDurations.Add((ushort)i.RespawnTime);
		return num;
	}

	// Token: 0x06000F23 RID: 3875 RVA: 0x00063F60 File Offset: 0x00062160
	public static PickupItem GetInstance(int id)
	{
		PickupItem result = null;
		PickupItem._instances.TryGetValue(id, out result);
		return result;
	}

	// Token: 0x04000D5A RID: 3418
	[SerializeField]
	protected int _respawnTime = 20;

	// Token: 0x04000D5B RID: 3419
	[SerializeField]
	private ParticleEmitter _emitter;

	// Token: 0x04000D5C RID: 3420
	[SerializeField]
	protected Transform _pickupItem;

	// Token: 0x04000D5D RID: 3421
	protected MeshRenderer[] _renderers;

	// Token: 0x04000D5E RID: 3422
	private bool _isAvailable;

	// Token: 0x04000D5F RID: 3423
	private int _pickupID;

	// Token: 0x04000D60 RID: 3424
	private Collider _collider;

	// Token: 0x04000D61 RID: 3425
	private static int _instanceCounter = 0;

	// Token: 0x04000D62 RID: 3426
	private static Dictionary<int, PickupItem> _instances = new Dictionary<int, PickupItem>();

	// Token: 0x04000D63 RID: 3427
	private static List<ushort> _pickupRespawnDurations = new List<ushort>();
}
