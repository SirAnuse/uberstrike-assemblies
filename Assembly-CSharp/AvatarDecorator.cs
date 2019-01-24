using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class AvatarDecorator : MonoBehaviour
{
	// Token: 0x17000583 RID: 1411
	// (get) Token: 0x0600180A RID: 6154 RVA: 0x0001028C File Offset: 0x0000E48C
	// (set) Token: 0x0600180B RID: 6155 RVA: 0x00010294 File Offset: 0x0000E494
	public Animation Animation { get; private set; }

	// Token: 0x17000584 RID: 1412
	// (get) Token: 0x0600180C RID: 6156 RVA: 0x0001029D File Offset: 0x0000E49D
	// (set) Token: 0x0600180D RID: 6157 RVA: 0x000102A5 File Offset: 0x0000E4A5
	public Animator Animator { get; private set; }

	// Token: 0x17000585 RID: 1413
	// (get) Token: 0x0600180E RID: 6158 RVA: 0x000102AE File Offset: 0x0000E4AE
	// (set) Token: 0x0600180F RID: 6159 RVA: 0x000102B6 File Offset: 0x0000E4B6
	public AvatarAnimationController AnimationController { get; private set; }

	// Token: 0x17000586 RID: 1414
	// (get) Token: 0x06001810 RID: 6160 RVA: 0x000102BF File Offset: 0x0000E4BF
	// (set) Token: 0x06001811 RID: 6161 RVA: 0x000102C7 File Offset: 0x0000E4C7
	public FootStepSoundType CurrentFootStep { get; set; }

	// Token: 0x17000587 RID: 1415
	// (get) Token: 0x06001812 RID: 6162 RVA: 0x000102D0 File Offset: 0x0000E4D0
	// (set) Token: 0x06001813 RID: 6163 RVA: 0x000102D8 File Offset: 0x0000E4D8
	public AvatarHudInformation HudInformation { get; private set; }

	// Token: 0x17000588 RID: 1416
	// (get) Token: 0x06001814 RID: 6164 RVA: 0x000102E1 File Offset: 0x0000E4E1
	// (set) Token: 0x06001815 RID: 6165 RVA: 0x000102E9 File Offset: 0x0000E4E9
	public AvatarDecoratorConfig Configuration { get; private set; }

	// Token: 0x17000589 RID: 1417
	// (get) Token: 0x06001816 RID: 6166 RVA: 0x000102F2 File Offset: 0x0000E4F2
	// (set) Token: 0x06001817 RID: 6167 RVA: 0x000102FA File Offset: 0x0000E4FA
	public CharacterHitArea[] HitAreas
	{
		get
		{
			return this._hitAreas;
		}
		set
		{
			this._hitAreas = value;
		}
	}

	// Token: 0x1700058A RID: 1418
	// (get) Token: 0x06001818 RID: 6168 RVA: 0x00010303 File Offset: 0x0000E503
	// (set) Token: 0x06001819 RID: 6169 RVA: 0x0001030B File Offset: 0x0000E50B
	public Transform WeaponAttachPoint
	{
		get
		{
			return this._weaponAttachPoint;
		}
		set
		{
			this._weaponAttachPoint = value;
		}
	}

	// Token: 0x0600181A RID: 6170 RVA: 0x00081CA0 File Offset: 0x0007FEA0
	private void Awake()
	{
		this._transform = base.transform;
		this._audio = base.GetComponent<AudioSource>();
		this.Animator = base.GetComponent<Animator>();
		this.AnimationController = base.GetComponent<AvatarAnimationController>();
		this.HudInformation = base.GetComponentInChildren<AvatarHudInformation>();
		this.Configuration = base.GetComponent<AvatarDecoratorConfig>();
	}

	// Token: 0x0600181B RID: 6171 RVA: 0x0000BDFE File Offset: 0x00009FFE
	public void SetLayers(UberstrikeLayer layer)
	{
		LayerUtil.SetLayerRecursively(base.transform, layer);
	}

	// Token: 0x0600181C RID: 6172 RVA: 0x00010314 File Offset: 0x0000E514
	public Transform GetBone(BoneIndex bone)
	{
		return this.Configuration.GetBone(bone);
	}

	// Token: 0x0600181D RID: 6173 RVA: 0x00010322 File Offset: 0x0000E522
	public void SetPosition(Vector3 position, Quaternion rotation)
	{
		base.transform.localPosition = position;
		base.transform.localRotation = rotation;
	}

	// Token: 0x0600181E RID: 6174 RVA: 0x0001033C File Offset: 0x0000E53C
	public void PlayFootSound(float walkingSpeed)
	{
		this.PlayFootSound(walkingSpeed, this.CurrentFootStep);
	}

	// Token: 0x0600181F RID: 6175 RVA: 0x0001034B File Offset: 0x0000E54B
	public void PlayJumpSound()
	{
		this._nextFootStepTime = Time.time + 0.3f;
	}

	// Token: 0x06001820 RID: 6176 RVA: 0x00081CF8 File Offset: 0x0007FEF8
	public void PlayFootSound(float walkingSpeed, FootStepSoundType sound)
	{
		if (this._nextFootStepTime < Time.time)
		{
			this._nextFootStepTime = Time.time + walkingSpeed;
			this._audio.clip = AutoMonoBehaviour<SfxManager>.Instance.GetFootStepAudioClip(sound);
			AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(this._audio.clip, this._transform.position, 1f);
		}
	}

	// Token: 0x06001821 RID: 6177 RVA: 0x00081D60 File Offset: 0x0007FF60
	public void PlayDieSound()
	{
		int num = UnityEngine.Random.Range(0, 3);
		AudioClip clip = GameAudio.NormalKill1;
		switch (num)
		{
		case 0:
			clip = GameAudio.NormalKill1;
			break;
		case 1:
			clip = GameAudio.NormalKill2;
			break;
		case 3:
			clip = GameAudio.NormalKill3;
			break;
		}
		AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(clip, this._transform.position, 1f);
	}

	// Token: 0x040016CD RID: 5837
	[SerializeField]
	private CharacterHitArea[] _hitAreas;

	// Token: 0x040016CE RID: 5838
	[SerializeField]
	private Transform _weaponAttachPoint;

	// Token: 0x040016CF RID: 5839
	private float _nextFootStepTime;

	// Token: 0x040016D0 RID: 5840
	private AudioSource _audio;

	// Token: 0x040016D1 RID: 5841
	private Transform _transform;
}
