using System;
using UnityEngine;

// Token: 0x0200043B RID: 1083
public class WeaponTailSound : BaseWeaponEffect
{
	// Token: 0x06001ECC RID: 7884 RVA: 0x00095CE8 File Offset: 0x00093EE8
	private void Awake()
	{
		if (this._tailSound)
		{
			this._tailAudioSource = base.gameObject.AddComponent<AudioSource>();
			if (this._tailAudioSource)
			{
				this._tailAudioSource.clip = this._tailSound;
				this._tailAudioSource.playOnAwake = false;
			}
			this._tailSoundMaxLength = this._tailSound.length * 0.8f;
		}
		else
		{
			Debug.LogError("There is no audio clip signed for WeaponTailSound!");
		}
	}

	// Token: 0x06001ECD RID: 7885 RVA: 0x0001453D File Offset: 0x0001273D
	private void Update()
	{
		if (this._tailSoundLength > 0f)
		{
			if (this._headAnimation)
			{
				this._headAnimation.OnShoot();
			}
			this._tailSoundLength -= Time.deltaTime;
		}
	}

	// Token: 0x06001ECE RID: 7886 RVA: 0x0001457C File Offset: 0x0001277C
	public override void OnShoot()
	{
		if (this._tailAudioSource)
		{
			this._tailAudioSource.Stop();
		}
		this._tailSoundLength = this._tailSoundMaxLength;
	}

	// Token: 0x06001ECF RID: 7887 RVA: 0x000145A5 File Offset: 0x000127A5
	public override void OnPostShoot()
	{
		if (this._tailAudioSource)
		{
			this._tailAudioSource.Stop();
			this._tailAudioSource.Play();
		}
	}

	// Token: 0x06001ED0 RID: 7888 RVA: 0x000145CD File Offset: 0x000127CD
	public override void Hide()
	{
		if (this._tailAudioSource)
		{
			this._tailAudioSource.Stop();
		}
	}

	// Token: 0x06001ED1 RID: 7889 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x04001A81 RID: 6785
	[SerializeField]
	private AudioClip _tailSound;

	// Token: 0x04001A82 RID: 6786
	[SerializeField]
	private WeaponHeadAnimation _headAnimation;

	// Token: 0x04001A83 RID: 6787
	private AudioSource _tailAudioSource;

	// Token: 0x04001A84 RID: 6788
	private float _tailSoundLength;

	// Token: 0x04001A85 RID: 6789
	private float _tailSoundMaxLength;
}
