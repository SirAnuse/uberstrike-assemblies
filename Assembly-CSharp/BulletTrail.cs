using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class BulletTrail : BaseWeaponEffect
{
	// Token: 0x06001E68 RID: 7784 RVA: 0x0009520C File Offset: 0x0009340C
	private void Awake()
	{
		this._animation = base.GetComponentInChildren<Animation>();
		if (this._animation)
		{
			this._clip = this._animation[this._animation.clip.name];
			this._clip.wrapMode = WrapMode.Once;
			this._trailDuration = this._clip.length;
			this._animation.playAutomatically = false;
		}
		this._renderers = base.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in this._renderers)
		{
			renderer.enabled = false;
		}
	}

	// Token: 0x06001E69 RID: 7785 RVA: 0x000952B4 File Offset: 0x000934B4
	public override void OnShoot()
	{
		foreach (Renderer renderer in this._renderers)
		{
			renderer.enabled = true;
		}
		if (this._animation)
		{
			float speed = this._trailDuration / this._clip.length;
			this._clip.speed = speed;
			this._animation.Play();
		}
		base.StartCoroutine(this.StartTrailEffect(this._trailDuration));
	}

	// Token: 0x06001E6A RID: 7786 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001E6B RID: 7787 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void Hide()
	{
	}

	// Token: 0x06001E6C RID: 7788 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x06001E6D RID: 7789 RVA: 0x00095338 File Offset: 0x00093538
	private IEnumerator StartTrailEffect(float time)
	{
		yield return new WaitForSeconds(time);
		foreach (Renderer r in this._renderers)
		{
			r.enabled = false;
		}
		yield break;
	}

	// Token: 0x04001A4E RID: 6734
	private Animation _animation;

	// Token: 0x04001A4F RID: 6735
	private AnimationState _clip;

	// Token: 0x04001A50 RID: 6736
	private float _trailDuration = 0.1f;

	// Token: 0x04001A51 RID: 6737
	private Renderer[] _renderers = new Renderer[0];
}
