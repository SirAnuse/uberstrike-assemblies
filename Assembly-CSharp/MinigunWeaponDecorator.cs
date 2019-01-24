using System;
using UnityEngine;

// Token: 0x02000426 RID: 1062
public class MinigunWeaponDecorator : BaseWeaponDecorator
{
	// Token: 0x17000688 RID: 1672
	// (get) Token: 0x06001E4B RID: 7755 RVA: 0x00014179 File Offset: 0x00012379
	public float MaxWarmUpTime
	{
		get
		{
			return this._maxWarmUpTime;
		}
	}

	// Token: 0x17000689 RID: 1673
	// (get) Token: 0x06001E4C RID: 7756 RVA: 0x00014181 File Offset: 0x00012381
	public float MaxWarmDownTime
	{
		get
		{
			return this._maxWarmDownTime;
		}
	}

	// Token: 0x06001E4D RID: 7757 RVA: 0x00094F28 File Offset: 0x00093128
	protected override void Awake()
	{
		base.Awake();
		if (this._warmUpSound == null)
		{
			throw new MissingReferenceException("MinigunWeaponDecorator - _warmUpSound is NULL");
		}
		if (this._warmDownSound == null)
		{
			throw new MissingReferenceException("MinigunWeaponDecorator - _warmDownSound is NULL");
		}
		this.InitAudioSource();
		this._headAnim = base.GetComponentInChildren<WeaponHeadAnimation>();
	}

	// Token: 0x06001E4E RID: 7758 RVA: 0x00094F88 File Offset: 0x00093188
	private void InitAudioSource()
	{
		if (this._duringShootSound)
		{
			this._duringShootAudioSource = base.gameObject.AddComponent<AudioSource>();
			if (this._duringShootAudioSource)
			{
				this._duringShootAudioSource.loop = true;
				this._duringShootAudioSource.priority = 0;
				this._duringShootAudioSource.playOnAwake = false;
				this._duringShootAudioSource.clip = this._duringShootSound;
			}
		}
		this._warmUpAudioSource = base.gameObject.AddComponent<AudioSource>();
		if (this._warmUpAudioSource)
		{
			this._warmUpAudioSource.priority = 0;
			this._warmUpAudioSource.playOnAwake = false;
			this._maxWarmUpTime = this._warmUpSound.length;
			this._warmUpAudioSource.clip = this._warmUpSound;
		}
		if (this._warmDownSound)
		{
			this._warmDownAudioSource = base.gameObject.AddComponent<AudioSource>();
			if (this._warmDownAudioSource)
			{
				this._warmDownAudioSource.priority = 0;
				this._warmDownAudioSource.playOnAwake = false;
				this._maxWarmDownTime = this._warmDownSound.length;
				this._warmDownAudioSource.clip = this._warmDownSound;
			}
		}
	}

	// Token: 0x06001E4F RID: 7759 RVA: 0x00014189 File Offset: 0x00012389
	public override void ShowShootEffect(RaycastHit[] hits)
	{
		base.ShowShootEffect(hits);
	}

	// Token: 0x06001E50 RID: 7760 RVA: 0x000950C4 File Offset: 0x000932C4
	public void PlayWindUpSound(float time)
	{
		if (this._warmDownAudioSource)
		{
			this._warmDownAudioSource.Stop();
		}
		if (this._warmUpAudioSource)
		{
			this._warmUpAudioSource.time = time;
			this._warmUpAudioSource.Play();
		}
	}

	// Token: 0x06001E51 RID: 7761 RVA: 0x00095114 File Offset: 0x00093314
	public void PlayWindDownSound(float time)
	{
		if (this._duringShootAudioSource)
		{
			this._duringShootAudioSource.Stop();
		}
		if (this._warmUpAudioSource)
		{
			this._warmUpAudioSource.Stop();
		}
		if (this._warmDownAudioSource)
		{
			this._warmDownAudioSource.time = time;
			this._warmDownAudioSource.Play();
		}
	}

	// Token: 0x06001E52 RID: 7762 RVA: 0x00014192 File Offset: 0x00012392
	public void PlayDuringSound()
	{
		if (!this._duringShootAudioSource.isPlaying)
		{
			this._duringShootAudioSource.Play();
		}
	}

	// Token: 0x06001E53 RID: 7763 RVA: 0x000141AF File Offset: 0x000123AF
	public override void StopSound()
	{
		base.StopSound();
		this._duringShootAudioSource.Stop();
	}

	// Token: 0x06001E54 RID: 7764 RVA: 0x000141C2 File Offset: 0x000123C2
	public void SpinWeaponHead()
	{
		if (this._headAnim)
		{
			this._headAnim.OnShoot();
		}
	}

	// Token: 0x04001A3F RID: 6719
	[SerializeField]
	private AudioClip _duringShootSound;

	// Token: 0x04001A40 RID: 6720
	[SerializeField]
	private AudioClip _warmUpSound;

	// Token: 0x04001A41 RID: 6721
	[SerializeField]
	private AudioClip _warmDownSound;

	// Token: 0x04001A42 RID: 6722
	private AudioSource _warmUpAudioSource;

	// Token: 0x04001A43 RID: 6723
	private AudioSource _warmDownAudioSource;

	// Token: 0x04001A44 RID: 6724
	private AudioSource _duringShootAudioSource;

	// Token: 0x04001A45 RID: 6725
	private WeaponHeadAnimation _headAnim;

	// Token: 0x04001A46 RID: 6726
	private float _maxWarmUpTime;

	// Token: 0x04001A47 RID: 6727
	private float _maxWarmDownTime;
}
