using System;
using System.Collections.Generic;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000421 RID: 1057
[RequireComponent(typeof(AudioSource))]
public abstract class BaseWeaponDecorator : MonoBehaviour
{
	// Token: 0x1700067A RID: 1658
	// (get) Token: 0x06001E0B RID: 7691 RVA: 0x00013F49 File Offset: 0x00012149
	// (set) Token: 0x06001E0C RID: 7692 RVA: 0x00013F51 File Offset: 0x00012151
	public bool IsEnabled
	{
		get
		{
			return this._isEnabled;
		}
		set
		{
			if (base.gameObject.activeSelf != value)
			{
				this._isEnabled = value;
				base.gameObject.SetActive(this._isEnabled);
				this.HideAllWeaponEffect();
			}
		}
	}

	// Token: 0x06001E0D RID: 7693 RVA: 0x00094438 File Offset: 0x00092638
	public void HideAllWeaponEffect()
	{
		if (this._effects != null)
		{
			foreach (BaseWeaponEffect baseWeaponEffect in this._effects)
			{
				baseWeaponEffect.Hide();
			}
		}
	}

	// Token: 0x1700067B RID: 1659
	// (get) Token: 0x06001E0E RID: 7694 RVA: 0x00013F82 File Offset: 0x00012182
	// (set) Token: 0x06001E0F RID: 7695 RVA: 0x0009449C File Offset: 0x0009269C
	public bool EnableShootAnimation
	{
		get
		{
			return this._isShootAnimationEnabled;
		}
		set
		{
			this._isShootAnimationEnabled = value;
			if (!this._isShootAnimationEnabled)
			{
				WeaponShootAnimation weaponShootAnimation = this._effects.Find((BaseWeaponEffect p) => p is WeaponShootAnimation) as WeaponShootAnimation;
				if (weaponShootAnimation)
				{
					this._effects.Remove(weaponShootAnimation);
					UnityEngine.Object.Destroy(weaponShootAnimation);
				}
			}
		}
	}

	// Token: 0x1700067C RID: 1660
	// (get) Token: 0x06001E10 RID: 7696 RVA: 0x00013F8A File Offset: 0x0001218A
	// (set) Token: 0x06001E11 RID: 7697 RVA: 0x00013F92 File Offset: 0x00012192
	public bool HasShootAnimation { get; private set; }

	// Token: 0x1700067D RID: 1661
	// (get) Token: 0x06001E12 RID: 7698 RVA: 0x00013F9B File Offset: 0x0001219B
	public Vector3 MuzzlePosition
	{
		get
		{
			return (!this._muzzlePosition) ? Vector3.zero : this._muzzlePosition.position;
		}
	}

	// Token: 0x1700067E RID: 1662
	// (get) Token: 0x06001E13 RID: 7699 RVA: 0x00013FC2 File Offset: 0x000121C2
	// (set) Token: 0x06001E14 RID: 7700 RVA: 0x00013FCA File Offset: 0x000121CA
	public Vector3 DefaultPosition
	{
		get
		{
			return this._defaultPosition;
		}
		set
		{
			this._defaultPosition = value;
			base.transform.localPosition = this._defaultPosition;
		}
	}

	// Token: 0x1700067F RID: 1663
	// (get) Token: 0x06001E15 RID: 7701 RVA: 0x00013FE4 File Offset: 0x000121E4
	// (set) Token: 0x06001E16 RID: 7702 RVA: 0x00013FF1 File Offset: 0x000121F1
	public Vector3 CurrentPosition
	{
		get
		{
			return base.transform.localPosition;
		}
		set
		{
			base.transform.localPosition = value;
		}
	}

	// Token: 0x17000680 RID: 1664
	// (get) Token: 0x06001E17 RID: 7703 RVA: 0x00013FFF File Offset: 0x000121FF
	// (set) Token: 0x06001E18 RID: 7704 RVA: 0x0001400C File Offset: 0x0001220C
	public Quaternion CurrentRotation
	{
		get
		{
			return base.transform.localRotation;
		}
		set
		{
			base.transform.localRotation = value;
		}
	}

	// Token: 0x17000681 RID: 1665
	// (get) Token: 0x06001E19 RID: 7705 RVA: 0x0001401A File Offset: 0x0001221A
	// (set) Token: 0x06001E1A RID: 7706 RVA: 0x00014022 File Offset: 0x00012222
	public Vector3 IronSightPosition
	{
		get
		{
			return this._ironSightPosition;
		}
		set
		{
			this._ironSightPosition = value;
		}
	}

	// Token: 0x17000682 RID: 1666
	// (get) Token: 0x06001E1B RID: 7707 RVA: 0x0001402B File Offset: 0x0001222B
	// (set) Token: 0x06001E1C RID: 7708 RVA: 0x00014033 File Offset: 0x00012233
	public Vector3 DefaultAngles { get; set; }

	// Token: 0x17000683 RID: 1667
	// (get) Token: 0x06001E1D RID: 7709 RVA: 0x0001403C File Offset: 0x0001223C
	// (set) Token: 0x06001E1E RID: 7710 RVA: 0x00014044 File Offset: 0x00012244
	public UberstrikeItemClass WeaponClass { get; set; }

	// Token: 0x17000684 RID: 1668
	// (get) Token: 0x06001E1F RID: 7711 RVA: 0x0001404D File Offset: 0x0001224D
	public MoveTrailrendererObject TrailRenderer
	{
		get
		{
			return this._trailRenderer;
		}
	}

	// Token: 0x17000685 RID: 1669
	// (get) Token: 0x06001E20 RID: 7712 RVA: 0x00014055 File Offset: 0x00012255
	// (set) Token: 0x06001E21 RID: 7713 RVA: 0x0001405D File Offset: 0x0001225D
	public bool IsMelee { get; protected set; }

	// Token: 0x06001E22 RID: 7714 RVA: 0x00094508 File Offset: 0x00092708
	protected virtual void Awake()
	{
		this._parent = base.transform.parent;
		this._mainAudioSource = base.GetComponent<AudioSource>();
		if (this._mainAudioSource)
		{
			this._mainAudioSource.priority = 0;
		}
		this._effects.AddRange(base.GetComponentsInChildren<BaseWeaponEffect>(true));
		if (this._muzzlePosition)
		{
			this._particles = this._muzzlePosition.GetComponent<ParticleSystem>();
		}
		this.HasShootAnimation = this._effects.Exists((BaseWeaponEffect e) => e is WeaponShootAnimation);
		this.InitEffectMap();
	}

	// Token: 0x06001E23 RID: 7715 RVA: 0x00014066 File Offset: 0x00012266
	protected virtual void Start()
	{
		this.HideAllWeaponEffect();
	}

	// Token: 0x06001E24 RID: 7716 RVA: 0x0001406E File Offset: 0x0001226E
	public BaseWeaponDecorator Clone()
	{
		return UnityEngine.Object.Instantiate(this) as BaseWeaponDecorator;
	}

	// Token: 0x06001E25 RID: 7717 RVA: 0x000945B8 File Offset: 0x000927B8
	public virtual void ShowShootEffect(RaycastHit[] hits)
	{
		if (this.IsEnabled)
		{
			if (this._muzzlePosition)
			{
				Vector3 position = this._muzzlePosition.position;
				for (int i = 0; i < hits.Length; i++)
				{
					Vector3 normalized = (hits[i].point - position).normalized;
					float distance = Vector3.Distance(position, hits[i].point);
					this.ShowImpactEffects(hits[i], normalized, position, distance, i == 0);
				}
			}
			foreach (BaseWeaponEffect baseWeaponEffect in this._effects)
			{
				baseWeaponEffect.OnShoot();
				baseWeaponEffect.OnHits(hits);
			}
			if (this._particles)
			{
				this._particles.Stop();
				this._particles.Play(this._isShootAnimationEnabled);
			}
			this.PlayShootSound();
		}
	}

	// Token: 0x06001E26 RID: 7718 RVA: 0x000946D4 File Offset: 0x000928D4
	public virtual void PostShoot()
	{
		if (this.IsEnabled && this._effects != null)
		{
			foreach (BaseWeaponEffect baseWeaponEffect in this._effects)
			{
				baseWeaponEffect.OnPostShoot();
			}
		}
	}

	// Token: 0x06001E27 RID: 7719 RVA: 0x0001407B File Offset: 0x0001227B
	protected virtual void ShowImpactEffects(RaycastHit hit, Vector3 direction, Vector3 muzzlePosition, float distance, bool playSound)
	{
		this.EmitImpactParticles(hit, direction, muzzlePosition, distance, playSound);
	}

	// Token: 0x06001E28 RID: 7720 RVA: 0x0001408A File Offset: 0x0001228A
	private static void Play3dAudioClip(AudioSource audioSource, AudioClip soundEffect)
	{
		BaseWeaponDecorator.Play3dAudioClip(audioSource, soundEffect, 0f);
	}

	// Token: 0x06001E29 RID: 7721 RVA: 0x00094744 File Offset: 0x00092944
	private static void Play3dAudioClip(AudioSource audioSource, AudioClip soundEffect, float delay)
	{
		try
		{
			audioSource.clip = soundEffect;
			ulong delay2 = (ulong)(delay * (float)audioSource.clip.frequency);
			audioSource.Play(delay2);
		}
		catch
		{
			Debug.LogError("Play3dAudioClip: " + soundEffect + " failed.");
		}
	}

	// Token: 0x06001E2A RID: 7722 RVA: 0x00014098 File Offset: 0x00012298
	public virtual void StopSound()
	{
		this._mainAudioSource.Stop();
	}

	// Token: 0x06001E2B RID: 7723 RVA: 0x000947A0 File Offset: 0x000929A0
	public void PlayShootSound()
	{
		if (this._mainAudioSource && this._shootSounds != null && this._shootSounds.Length > 0)
		{
			int num = UnityEngine.Random.Range(0, this._shootSounds.Length);
			AudioClip audioClip = this._shootSounds[num];
			if (audioClip)
			{
				this._mainAudioSource.volume = ((!ApplicationDataManager.ApplicationOptions.AudioEnabled) ? 0f : ApplicationDataManager.ApplicationOptions.AudioEffectsVolume);
				this._mainAudioSource.PlayOneShot(audioClip);
			}
		}
	}

	// Token: 0x06001E2C RID: 7724 RVA: 0x00094834 File Offset: 0x00092A34
	private void InitEffectMap()
	{
		this._effectMap = new Dictionary<string, SurfaceEffectType>();
		this._effectMap.Add("Wood", SurfaceEffectType.WoodEffect);
		this._effectMap.Add("SolidWood", SurfaceEffectType.WoodEffect);
		this._effectMap.Add("Stone", SurfaceEffectType.StoneEffect);
		this._effectMap.Add("Metal", SurfaceEffectType.MetalEffect);
		this._effectMap.Add("Sand", SurfaceEffectType.SandEffect);
		this._effectMap.Add("Grass", SurfaceEffectType.GrassEffect);
		this._effectMap.Add("Avatar", SurfaceEffectType.Splat);
		this._effectMap.Add("Water", SurfaceEffectType.WaterEffect);
		this._effectMap.Add("NoTarget", SurfaceEffectType.None);
		this._effectMap.Add("Cement", SurfaceEffectType.StoneEffect);
	}

	// Token: 0x06001E2D RID: 7725 RVA: 0x000140A5 File Offset: 0x000122A5
	public void SetSurfaceEffect(ParticleConfigurationType effect)
	{
		this._effectType = effect;
	}

	// Token: 0x06001E2E RID: 7726 RVA: 0x000140AE File Offset: 0x000122AE
	public virtual void PlayEquipSound()
	{
		AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.WeaponSwitch, 0UL);
	}

	// Token: 0x06001E2F RID: 7727 RVA: 0x000140C1 File Offset: 0x000122C1
	public virtual void PlayHitSound()
	{
		Debug.LogError("Not Implemented: Should play WeaponHit sound!");
	}

	// Token: 0x06001E30 RID: 7728 RVA: 0x000140CD File Offset: 0x000122CD
	public void PlayOutOfAmmoSound()
	{
		BaseWeaponDecorator.Play3dAudioClip(this._mainAudioSource, GameAudio.OutOfAmmoClick);
	}

	// Token: 0x06001E31 RID: 7729 RVA: 0x000948F8 File Offset: 0x00092AF8
	public void PlayImpactSoundAt(HitPoint point)
	{
		if (point == null)
		{
			return;
		}
		float num = (!this._muzzlePosition) ? 0f : this._muzzlePosition.position.y;
		float num2 = (!(GameState.Current.Map != null) || !GameState.Current.Map.HasWaterPlane) ? num : GameState.Current.Map.WaterPlaneHeight;
		if ((num > num2 && point.Point.y < num2) || (num < num2 && point.Point.y > num2))
		{
			Vector3 point2 = point.Point;
			point2.y = 0f;
			AutoMonoBehaviour<SfxManager>.Instance.PlayImpactSound("Water", point2);
		}
		else
		{
			this.EmitImpactSound(point.Tag, point.Point);
		}
	}

	// Token: 0x06001E32 RID: 7730 RVA: 0x000140DF File Offset: 0x000122DF
	protected virtual void EmitImpactSound(string impactType, Vector3 position)
	{
		AutoMonoBehaviour<SfxManager>.Instance.PlayImpactSound(impactType, position);
	}

	// Token: 0x06001E33 RID: 7731 RVA: 0x000949EC File Offset: 0x00092BEC
	protected void EmitImpactParticles(RaycastHit hit, Vector3 direction, Vector3 muzzlePosition, float distance, bool playSound)
	{
		string tag = TagUtil.GetTag(hit.collider);
		Vector3 point = hit.point;
		Vector3 hitNormal = hit.normal;
		SurfaceEffectType surface = SurfaceEffectType.Default;
		if (this._effectMap.TryGetValue(tag, out surface))
		{
			if (GameState.Current.Map != null && GameState.Current.Map.HasWaterPlane && ((this._muzzlePosition.position.y > GameState.Current.Map.WaterPlaneHeight && point.y < GameState.Current.Map.WaterPlaneHeight) || (this._muzzlePosition.position.y < GameState.Current.Map.WaterPlaneHeight && point.y > GameState.Current.Map.WaterPlaneHeight)))
			{
				surface = SurfaceEffectType.WaterEffect;
				hitNormal = Vector3.up;
				point.y = GameState.Current.Map.WaterPlaneHeight;
				if (!Mathf.Approximately(direction.y, 0f))
				{
					point.x = (GameState.Current.Map.WaterPlaneHeight - hit.point.y) / direction.y * direction.x + hit.point.x;
					point.z = (GameState.Current.Map.WaterPlaneHeight - hit.point.y) / direction.y * direction.z + hit.point.z;
				}
			}
			ParticleEffectController.ShowHitEffect(this._effectType, surface, direction, point, hitNormal, muzzlePosition, distance, ref this._trailRenderer, this._parent);
		}
	}

	// Token: 0x06001E34 RID: 7732 RVA: 0x000140ED File Offset: 0x000122ED
	public void SetMuzzlePosition(Transform muzzle)
	{
		this._muzzlePosition = muzzle;
	}

	// Token: 0x06001E35 RID: 7733 RVA: 0x000140F6 File Offset: 0x000122F6
	public void SetWeaponSounds(AudioClip[] sounds)
	{
		if (sounds != null)
		{
			this._shootSounds = new AudioClip[sounds.Length];
			sounds.CopyTo(this._shootSounds, 0);
		}
	}

	// Token: 0x04001A1A RID: 6682
	[SerializeField]
	private Transform _muzzlePosition;

	// Token: 0x04001A1B RID: 6683
	[SerializeField]
	private AudioClip[] _shootSounds;

	// Token: 0x04001A1C RID: 6684
	private Vector3 _defaultPosition;

	// Token: 0x04001A1D RID: 6685
	private Vector3 _ironSightPosition;

	// Token: 0x04001A1E RID: 6686
	private ParticleConfigurationType _effectType;

	// Token: 0x04001A1F RID: 6687
	private MoveTrailrendererObject _trailRenderer;

	// Token: 0x04001A20 RID: 6688
	private Transform _parent;

	// Token: 0x04001A21 RID: 6689
	private ParticleSystem _particles;

	// Token: 0x04001A22 RID: 6690
	private bool _isEnabled = true;

	// Token: 0x04001A23 RID: 6691
	private bool _isShootAnimationEnabled;

	// Token: 0x04001A24 RID: 6692
	protected AudioSource _mainAudioSource;

	// Token: 0x04001A25 RID: 6693
	private Dictionary<string, SurfaceEffectType> _effectMap;

	// Token: 0x04001A26 RID: 6694
	private List<BaseWeaponEffect> _effects = new List<BaseWeaponEffect>();
}
