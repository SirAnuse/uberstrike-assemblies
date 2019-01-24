using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200042F RID: 1071
public class MuzzleFlash : BaseWeaponEffect
{
	// Token: 0x06001E80 RID: 7808 RVA: 0x000955A4 File Offset: 0x000937A4
	private void Awake()
	{
		this._animation = base.GetComponentInChildren<Animation>();
		if (this._animation)
		{
			this._clip = this._animation[this._animation.clip.name];
			this._clip.wrapMode = WrapMode.Once;
			this._flashDuration = this._clip.length;
			this._animation.playAutomatically = false;
		}
		this._muzzleFlashEnd = 0f;
		this._renderers.AddRange(base.GetComponentsInChildren<Renderer>());
		foreach (Renderer renderer in this._renderers)
		{
			renderer.enabled = false;
		}
	}

	// Token: 0x06001E81 RID: 7809 RVA: 0x00095680 File Offset: 0x00093880
	public override void Hide()
	{
		this._muzzleFlashEnd = 0f;
		if (this._clip)
		{
			this._clip.normalizedTime = 1f;
		}
		foreach (Renderer renderer in this._renderers)
		{
			renderer.enabled = false;
		}
	}

	// Token: 0x06001E82 RID: 7810 RVA: 0x00095708 File Offset: 0x00093908
	public override void OnShoot()
	{
		foreach (Renderer renderer in this._renderers)
		{
			renderer.enabled = true;
		}
		base.transform.localRotation = Quaternion.Euler(0f, 0f, (float)UnityEngine.Random.Range(0, 360));
		if (this._animation)
		{
			float speed = this._clip.length / this._flashDuration;
			this._clip.speed = speed;
			this._clip.time = 0f;
			this._animation.Play();
		}
		this._muzzleFlashEnd = Time.time + this._flashDuration;
	}

	// Token: 0x06001E83 RID: 7811 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001E84 RID: 7812 RVA: 0x000957E8 File Offset: 0x000939E8
	private void Update()
	{
		if (this._muzzleFlashEnd < Time.time)
		{
			foreach (Renderer renderer in this._renderers)
			{
				renderer.enabled = false;
			}
		}
	}

	// Token: 0x06001E85 RID: 7813 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x04001A63 RID: 6755
	private float _muzzleFlashEnd;

	// Token: 0x04001A64 RID: 6756
	private Animation _animation;

	// Token: 0x04001A65 RID: 6757
	private AnimationState _clip;

	// Token: 0x04001A66 RID: 6758
	private float _flashDuration = 0.1f;

	// Token: 0x04001A67 RID: 6759
	private List<Renderer> _renderers = new List<Renderer>();
}
