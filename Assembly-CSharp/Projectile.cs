using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200044C RID: 1100
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public abstract class Projectile : MonoBehaviour, IProjectile
{
	// Token: 0x170006A7 RID: 1703
	// (get) Token: 0x06001F48 RID: 8008 RVA: 0x00014A26 File Offset: 0x00012C26
	// (set) Token: 0x06001F49 RID: 8009 RVA: 0x00014A2E File Offset: 0x00012C2E
	public ParticleConfigurationType ExplosionEffect { get; set; }

	// Token: 0x170006A8 RID: 1704
	// (get) Token: 0x06001F4A RID: 8010 RVA: 0x00014A37 File Offset: 0x00012C37
	public Rigidbody Rigidbody
	{
		get
		{
			return this._rigidbody;
		}
	}

	// Token: 0x170006A9 RID: 1705
	// (get) Token: 0x06001F4B RID: 8011 RVA: 0x00014A3F File Offset: 0x00012C3F
	// (set) Token: 0x06001F4C RID: 8012 RVA: 0x00014A47 File Offset: 0x00012C47
	public ProjectileDetonator Detonator { get; set; }

	// Token: 0x170006AA RID: 1706
	// (get) Token: 0x06001F4D RID: 8013 RVA: 0x00014A50 File Offset: 0x00012C50
	// (set) Token: 0x06001F4E RID: 8014 RVA: 0x00014A58 File Offset: 0x00012C58
	public bool IsProjectileExploded { get; protected set; }

	// Token: 0x170006AB RID: 1707
	// (get) Token: 0x06001F4F RID: 8015 RVA: 0x00014A61 File Offset: 0x00012C61
	// (set) Token: 0x06001F50 RID: 8016 RVA: 0x00014A69 File Offset: 0x00012C69
	public float TimeOut { get; set; }

	// Token: 0x170006AC RID: 1708
	// (get) Token: 0x06001F51 RID: 8017 RVA: 0x00014A72 File Offset: 0x00012C72
	// (set) Token: 0x06001F52 RID: 8018 RVA: 0x00014A7A File Offset: 0x00012C7A
	public int ID { get; set; }

	// Token: 0x06001F53 RID: 8019 RVA: 0x00096720 File Offset: 0x00094920
	protected virtual void Awake()
	{
		this._rigidbody = base.GetComponent<Rigidbody>();
		this._source = base.GetComponent<AudioSource>();
		if (this._collider == null && this._trigger == null)
		{
			Debug.LogError("The Projectile " + base.gameObject.name + " has not assigned Collider or Trigger! Check your Inspector settings.");
		}
		if (this._collider && this._collider.isTrigger)
		{
			Debug.LogError("The Projectile " + base.gameObject.name + " has a Collider attached that is configured as Trigger! Check your Inspector settings.");
		}
		if (this._trigger && !this._trigger.isTrigger)
		{
			Debug.LogError("The Projectile " + base.gameObject.name + " has a Trigger attached that is configured as Collider! Check your Inspector settings.");
		}
		this._transform = base.transform;
		this._positionSign = Mathf.Sign(this._transform.position.y);
	}

	// Token: 0x06001F54 RID: 8020 RVA: 0x00096830 File Offset: 0x00094A30
	protected virtual void Start()
	{
		if (GameState.Current.Map != null && GameState.Current.Map.HasWaterPlane)
		{
			this._positionSign = Mathf.Sign(this._transform.position.y - GameState.Current.Map.WaterPlaneHeight);
		}
		base.StartCoroutine(this.StartTimeout());
	}

	// Token: 0x06001F55 RID: 8021 RVA: 0x00014A83 File Offset: 0x00012C83
	public void MoveInDirection(Vector3 direction)
	{
		this.Rigidbody.isKinematic = false;
		this.Rigidbody.velocity = direction;
	}

	// Token: 0x06001F56 RID: 8022 RVA: 0x000968A4 File Offset: 0x00094AA4
	protected virtual IEnumerator StartTimeout()
	{
		yield return new WaitForSeconds((this.TimeOut <= 0f) ? 30f : this.TimeOut);
		Singleton<ProjectileManager>.Instance.RemoveProjectile(this.ID, true);
		yield break;
	}

	// Token: 0x06001F57 RID: 8023
	protected abstract void OnTriggerEnter(Collider c);

	// Token: 0x06001F58 RID: 8024
	protected abstract void OnCollisionEnter(Collision c);

	// Token: 0x06001F59 RID: 8025 RVA: 0x000968C0 File Offset: 0x00094AC0
	protected virtual void Update()
	{
		if (GameState.Current.Map != null && GameState.Current.Map.HasWaterPlane && this._positionSign != Mathf.Sign(this._transform.position.y - GameState.Current.Map.WaterPlaneHeight))
		{
			this._positionSign = Mathf.Sign(this._transform.position.y - GameState.Current.Map.WaterPlaneHeight);
			ParticleEffectController.ProjectileWaterRipplesEffect(this.ExplosionEffect, this._transform.position);
		}
	}

	// Token: 0x06001F5A RID: 8026 RVA: 0x00096970 File Offset: 0x00094B70
	protected void Explode(Vector3 point, Vector3 normal, string tag)
	{
		this.Destroy();
		if (this.Detonator != null)
		{
			this.Detonator.Explode(point);
		}
		Singleton<ExplosionManager>.Instance.PlayExplosionSound(point, this._explosionSound);
		Singleton<ExplosionManager>.Instance.ShowExplosionEffect(point, normal, tag, this.ExplosionEffect);
		if (this._showHeatwave)
		{
			ParticleEffectController.ShowHeatwaveEffect(base.transform.position);
		}
		if (this._explosionEffect)
		{
			UnityEngine.Object.Instantiate(this._explosionEffect, point, Quaternion.LookRotation(normal));
		}
	}

	// Token: 0x06001F5B RID: 8027 RVA: 0x00014A9D File Offset: 0x00012C9D
	public void Destroy()
	{
		if (!this.IsProjectileExploded)
		{
			this.IsProjectileExploded = true;
			base.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x170006AD RID: 1709
	// (get) Token: 0x06001F5C RID: 8028 RVA: 0x00014AC8 File Offset: 0x00012CC8
	protected int CollisionMask
	{
		get
		{
			if (base.gameObject && base.gameObject.layer == 24)
			{
				return UberstrikeLayerMasks.RemoteRocketMask;
			}
			return UberstrikeLayerMasks.LocalRocketMask;
		}
	}

	// Token: 0x06001F5D RID: 8029 RVA: 0x00014AF7 File Offset: 0x00012CF7
	public void SetExplosionSound(AudioClip clip)
	{
		this._explosionSound = clip;
	}

	// Token: 0x06001F5E RID: 8030 RVA: 0x00068AC8 File Offset: 0x00066CC8
	protected void PlayBounceSound(Vector3 position)
	{
		AudioClip clip = GameAudio.LauncherBounce1;
		int num = UnityEngine.Random.Range(0, 2);
		if (num > 0)
		{
			clip = GameAudio.LauncherBounce2;
		}
		AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(clip, position, 1f);
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x000969FC File Offset: 0x00094BFC
	public Vector3 Explode()
	{
		Vector3 vector = Vector3.zero;
		try
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position - base.transform.forward, base.transform.forward, out raycastHit, 2f, this.CollisionMask))
			{
				vector = raycastHit.point - base.transform.forward * 0.01f;
				this.Explode(vector, raycastHit.normal, TagUtil.GetTag(raycastHit.collider));
			}
			else
			{
				vector = base.transform.position;
				this.Explode(vector, -base.transform.forward, string.Empty);
			}
		}
		catch (Exception message)
		{
			Debug.LogWarning(message);
		}
		return vector;
	}

	// Token: 0x04001AB1 RID: 6833
	public const int DefaultTimeout = 30;

	// Token: 0x04001AB2 RID: 6834
	[SerializeField]
	private Collider _trigger;

	// Token: 0x04001AB3 RID: 6835
	[SerializeField]
	private Collider _collider;

	// Token: 0x04001AB4 RID: 6836
	[SerializeField]
	private bool _showHeatwave;

	// Token: 0x04001AB5 RID: 6837
	[SerializeField]
	private GameObject _explosionEffect;

	// Token: 0x04001AB6 RID: 6838
	private Rigidbody _rigidbody;

	// Token: 0x04001AB7 RID: 6839
	protected AudioSource _source;

	// Token: 0x04001AB8 RID: 6840
	private float _positionSign;

	// Token: 0x04001AB9 RID: 6841
	private Transform _transform;

	// Token: 0x04001ABA RID: 6842
	protected AudioClip _explosionSound;
}
