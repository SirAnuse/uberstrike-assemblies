using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
[RequireComponent(typeof(Animation))]
public class WeaponHeadAnimation : BaseWeaponEffect
{
	// Token: 0x06001EAF RID: 7855 RVA: 0x00095AE4 File Offset: 0x00093CE4
	private void Awake()
	{
		this._animation = base.GetComponent<Animation>();
		if (this._animation && this._animation.clip)
		{
			this._animation.playAutomatically = false;
			this._animState = this._animation[this._animation.clip.name];
		}
	}

	// Token: 0x06001EB0 RID: 7856 RVA: 0x00095B50 File Offset: 0x00093D50
	private void Update()
	{
		if (this._speed > 0f)
		{
			if (this._animState)
			{
				this._animState.speed = this._speed;
			}
			this._speed = Mathf.Lerp(this._speed, -0.1f, Time.deltaTime);
		}
		else if (this._animation.isPlaying)
		{
			this._animation.Stop();
		}
	}

	// Token: 0x06001EB1 RID: 7857 RVA: 0x00095BCC File Offset: 0x00093DCC
	public override void OnShoot()
	{
		this._speed = 1f;
		if (this._animation)
		{
			if (!this._animation.isPlaying)
			{
				this._animation.Play();
			}
		}
		else
		{
			Debug.LogError("No animation for weapon head!");
		}
	}

	// Token: 0x06001EB2 RID: 7858 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001EB3 RID: 7859 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x06001EB4 RID: 7860 RVA: 0x0001444C File Offset: 0x0001264C
	public override void Hide()
	{
		if (this._animation && this._animation.isPlaying)
		{
			this._animation.Stop();
		}
	}

	// Token: 0x06001EB5 RID: 7861 RVA: 0x00014479 File Offset: 0x00012679
	public void SetSpeed(float speed)
	{
		this._speed = speed;
	}

	// Token: 0x04001A79 RID: 6777
	private Animation _animation;

	// Token: 0x04001A7A RID: 6778
	private AnimationState _animState;

	// Token: 0x04001A7B RID: 6779
	private float _speed;
}
