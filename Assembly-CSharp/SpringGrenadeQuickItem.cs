using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000274 RID: 628
public class SpringGrenadeQuickItem : QuickItem, IProjectile, IGrenadeProjectile
{
	// Token: 0x14000008 RID: 8
	// (add) Token: 0x0600117B RID: 4475 RVA: 0x0000C10D File Offset: 0x0000A30D
	// (remove) Token: 0x0600117C RID: 4476 RVA: 0x0000C126 File Offset: 0x0000A326
	private event Action<Collider> OnTriggerEnterEvent;

	// Token: 0x14000009 RID: 9
	// (add) Token: 0x0600117D RID: 4477 RVA: 0x0000C13F File Offset: 0x0000A33F
	// (remove) Token: 0x0600117E RID: 4478 RVA: 0x0000C158 File Offset: 0x0000A358
	private event Action<Collision> OnCollisionEnterEvent;

	// Token: 0x1400000A RID: 10
	// (add) Token: 0x0600117F RID: 4479 RVA: 0x0000C171 File Offset: 0x0000A371
	// (remove) Token: 0x06001180 RID: 4480 RVA: 0x0000C18A File Offset: 0x0000A38A
	public event Action<IGrenadeProjectile> OnProjectileExploded;

	// Token: 0x1400000B RID: 11
	// (add) Token: 0x06001181 RID: 4481 RVA: 0x0000C1A3 File Offset: 0x0000A3A3
	// (remove) Token: 0x06001182 RID: 4482 RVA: 0x0000C1BC File Offset: 0x0000A3BC
	public event Action<IGrenadeProjectile> OnProjectileEmitted;

	// Token: 0x1400000C RID: 12
	// (add) Token: 0x06001183 RID: 4483 RVA: 0x0000C1D5 File Offset: 0x0000A3D5
	// (remove) Token: 0x06001184 RID: 4484 RVA: 0x0000C1EE File Offset: 0x0000A3EE
	public event Action<int, Vector3> OnExploded;

	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x06001185 RID: 4485 RVA: 0x0000C207 File Offset: 0x0000A407
	public ParticleEmitter Smoke
	{
		get
		{
			return this._smoke;
		}
	}

	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x06001186 RID: 4486 RVA: 0x0000C20F File Offset: 0x0000A40F
	public ParticleEmitter DeployedEffect
	{
		get
		{
			return this._deployedEffect;
		}
	}

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x06001187 RID: 4487 RVA: 0x0000C217 File Offset: 0x0000A417
	public Renderer Renderer
	{
		get
		{
			return this._renderer;
		}
	}

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x06001188 RID: 4488 RVA: 0x0000C21F File Offset: 0x0000A41F
	// (set) Token: 0x06001189 RID: 4489 RVA: 0x0000C227 File Offset: 0x0000A427
	public override QuickItemConfiguration Configuration
	{
		get
		{
			return this._config;
		}
		set
		{
			this._config = (SpringGrenadeConfiguration)value;
		}
	}

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x0600118A RID: 4490 RVA: 0x0000C235 File Offset: 0x0000A435
	// (set) Token: 0x0600118B RID: 4491 RVA: 0x0000C23D File Offset: 0x0000A43D
	public AudioClip ExplosionSound { get; set; }

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x0600118C RID: 4492 RVA: 0x0000C246 File Offset: 0x0000A446
	public AudioClip JumpSound
	{
		get
		{
			return this._sound;
		}
	}

	// Token: 0x0600118D RID: 4493 RVA: 0x000693EC File Offset: 0x000675EC
	protected override void OnActivated()
	{
		Vector3 vector = GameState.Current.PlayerData.ShootingPoint + GameState.Current.Player.EyePosition;
		Vector3 position = vector + GameState.Current.PlayerData.ShootingDirection * 2f;
		Vector3 velocity = GameState.Current.PlayerData.ShootingDirection * (float)this._config.Speed;
		float distance = 2f;
		RaycastHit raycastHit;
		if (Physics.Raycast(vector, GameState.Current.PlayerData.ShootingDirection * 2f, out raycastHit, distance, UberstrikeLayerMasks.LocalRocketMask))
		{
			SpringGrenadeQuickItem springGrenadeQuickItem = this.Throw(raycastHit.point, Vector3.zero) as SpringGrenadeQuickItem;
			springGrenadeQuickItem.machine.PopAllStates();
			GameState.Current.Player.MoveController.ApplyForce(this._config.JumpDirection.normalized * (float)this._config.Force, CharacterMoveController.ForceType.Additive);
			AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(this.JumpSound, 0UL);
			base.StartCoroutine(this.DestroyDelayed(springGrenadeQuickItem.ID));
		}
		else
		{
			IGrenadeProjectile grenadeProjectile = this.Throw(position, velocity);
			grenadeProjectile.OnProjectileExploded += delegate(IGrenadeProjectile p)
			{
				Collider[] array = Physics.OverlapSphere(p.Position, 2f, UberstrikeLayerMasks.ExplosionMask);
				foreach (Collider collider in array)
				{
					CharacterHitArea component = collider.gameObject.GetComponent<CharacterHitArea>();
					if (component != null && component.RecieveProjectileDamage)
					{
						component.Shootable.ApplyForce(component.transform.position, this._config.JumpDirection.normalized * (float)this._config.Force);
					}
				}
			};
		}
	}

	// Token: 0x0600118E RID: 4494 RVA: 0x0006953C File Offset: 0x0006773C
	private IEnumerator DestroyDelayed(int projectileId)
	{
		yield return new WaitForSeconds(0.2f);
		Singleton<ProjectileManager>.Instance.RemoveProjectile(projectileId, true);
		GameState.Current.Actions.RemoveProjectile(projectileId, true);
		yield break;
	}

	// Token: 0x0600118F RID: 4495 RVA: 0x00069560 File Offset: 0x00067760
	public IGrenadeProjectile Throw(Vector3 position, Vector3 velocity)
	{
		SpringGrenadeQuickItem springGrenadeQuickItem = UnityEngine.Object.Instantiate(this) as SpringGrenadeQuickItem;
		springGrenadeQuickItem.gameObject.SetActive(true);
		for (int i = 0; i < springGrenadeQuickItem.gameObject.transform.childCount; i++)
		{
			springGrenadeQuickItem.gameObject.transform.GetChild(i).gameObject.SetActive(true);
		}
		if (springGrenadeQuickItem.rigidbody)
		{
			springGrenadeQuickItem.rigidbody.isKinematic = false;
		}
		springGrenadeQuickItem.Position = position;
		springGrenadeQuickItem.Velocity = velocity;
		springGrenadeQuickItem.machine.RegisterState(SpringGrenadeQuickItem.SpringGrenadeState.Flying, new SpringGrenadeQuickItem.FlyingState(springGrenadeQuickItem));
		springGrenadeQuickItem.machine.RegisterState(SpringGrenadeQuickItem.SpringGrenadeState.Deployed, new SpringGrenadeQuickItem.DeployedState(springGrenadeQuickItem));
		springGrenadeQuickItem.machine.PushState(SpringGrenadeQuickItem.SpringGrenadeState.Flying);
		if (this.OnProjectileEmitted != null)
		{
			this.OnProjectileEmitted(springGrenadeQuickItem);
		}
		return springGrenadeQuickItem;
	}

	// Token: 0x06001190 RID: 4496 RVA: 0x0000BDFE File Offset: 0x00009FFE
	public void SetLayer(UberstrikeLayer layer)
	{
		LayerUtil.SetLayerRecursively(base.transform, layer);
	}

	// Token: 0x06001191 RID: 4497 RVA: 0x0000C24E File Offset: 0x0000A44E
	private void Update()
	{
		this.machine.Update();
	}

	// Token: 0x06001192 RID: 4498 RVA: 0x0000C25B File Offset: 0x0000A45B
	private void OnTriggerEnter(Collider c)
	{
		if (this.OnTriggerEnterEvent != null)
		{
			this.OnTriggerEnterEvent(c);
		}
	}

	// Token: 0x06001193 RID: 4499 RVA: 0x0000C274 File Offset: 0x0000A474
	private void OnCollisionEnter(Collision c)
	{
		if (this.OnCollisionEnterEvent != null)
		{
			this.OnCollisionEnterEvent(c);
		}
	}

	// Token: 0x06001194 RID: 4500 RVA: 0x00069634 File Offset: 0x00067834
	public Vector3 Explode()
	{
		Vector3 result = Vector3.zero;
		try
		{
			if (this.OnExploded != null)
			{
				this.OnExploded(this.ID, base.transform.position);
			}
			if (this.OnProjectileExploded != null)
			{
				this.OnProjectileExploded(this);
			}
			result = base.transform.position;
			this.Destroy();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return result;
	}

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x06001195 RID: 4501 RVA: 0x0000C28D File Offset: 0x0000A48D
	// (set) Token: 0x06001196 RID: 4502 RVA: 0x0000C295 File Offset: 0x0000A495
	public int ID { get; set; }

	// Token: 0x06001197 RID: 4503 RVA: 0x0000C29E File Offset: 0x0000A49E
	public void Destroy()
	{
		if (!this._isDestroyed)
		{
			this._isDestroyed = true;
			base.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x06001198 RID: 4504 RVA: 0x0000BE87 File Offset: 0x0000A087
	// (set) Token: 0x06001199 RID: 4505 RVA: 0x0000BEAE File Offset: 0x0000A0AE
	public Vector3 Position
	{
		get
		{
			return (!base.transform) ? Vector3.zero : base.transform.position;
		}
		private set
		{
			if (base.transform)
			{
				base.transform.position = value;
			}
		}
	}

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x0600119A RID: 4506 RVA: 0x0000BECC File Offset: 0x0000A0CC
	// (set) Token: 0x0600119B RID: 4507 RVA: 0x0000BEF3 File Offset: 0x0000A0F3
	public Vector3 Velocity
	{
		get
		{
			return (!base.rigidbody) ? Vector3.zero : base.rigidbody.velocity;
		}
		private set
		{
			if (base.rigidbody)
			{
				base.rigidbody.velocity = value;
			}
		}
	}

	// Token: 0x04000E92 RID: 3730
	[SerializeField]
	private AudioClip _sound;

	// Token: 0x04000E93 RID: 3731
	[SerializeField]
	private Renderer _renderer;

	// Token: 0x04000E94 RID: 3732
	[SerializeField]
	private ParticleEmitter _smoke;

	// Token: 0x04000E95 RID: 3733
	[SerializeField]
	private ParticleEmitter _deployedEffect;

	// Token: 0x04000E96 RID: 3734
	[SerializeField]
	private SpringGrenadeConfiguration _config;

	// Token: 0x04000E97 RID: 3735
	private StateMachine<SpringGrenadeQuickItem.SpringGrenadeState> machine = new StateMachine<SpringGrenadeQuickItem.SpringGrenadeState>();

	// Token: 0x04000E98 RID: 3736
	private bool _isDestroyed;

	// Token: 0x02000275 RID: 629
	private enum SpringGrenadeState
	{
		// Token: 0x04000EA1 RID: 3745
		Flying = 1,
		// Token: 0x04000EA2 RID: 3746
		Deployed
	}

	// Token: 0x02000276 RID: 630
	private class FlyingState : IState
	{
		// Token: 0x0600119D RID: 4509 RVA: 0x0000C2C9 File Offset: 0x0000A4C9
		public FlyingState(SpringGrenadeQuickItem behaviour)
		{
			this.behaviour = behaviour;
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x0006975C File Offset: 0x0006795C
		public void OnEnter()
		{
			this._timeOut = Time.time + (float)this.behaviour._config.LifeTime;
			SpringGrenadeQuickItem springGrenadeQuickItem = this.behaviour;
			springGrenadeQuickItem.OnCollisionEnterEvent = (Action<Collision>)Delegate.Combine(springGrenadeQuickItem.OnCollisionEnterEvent, new Action<Collision>(this.OnCollisionEnterEvent));
			GameObject gameObject = this.behaviour.gameObject;
			if (gameObject && GameState.Current.Avatar.Decorator && gameObject.collider)
			{
				Collider collider = gameObject.collider;
				foreach (CharacterHitArea characterHitArea in GameState.Current.Avatar.Decorator.HitAreas)
				{
					if (gameObject.activeInHierarchy && characterHitArea.gameObject.activeInHierarchy)
					{
						Physics.IgnoreCollision(collider, characterHitArea.collider);
					}
				}
			}
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnResume()
		{
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x0000C2D8 File Offset: 0x0000A4D8
		public void OnExit()
		{
			SpringGrenadeQuickItem springGrenadeQuickItem = this.behaviour;
			springGrenadeQuickItem.OnCollisionEnterEvent = (Action<Collision>)Delegate.Remove(springGrenadeQuickItem.OnCollisionEnterEvent, new Action<Collision>(this.OnCollisionEnterEvent));
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x0000C301 File Offset: 0x0000A501
		public void OnUpdate()
		{
			if (this._timeOut < Time.time)
			{
				this.behaviour.machine.PopState(true);
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.behaviour.ID, true);
			}
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x00069850 File Offset: 0x00067A50
		private void OnCollisionEnterEvent(Collision c)
		{
			if (LayerUtil.IsLayerInMask(UberstrikeLayerMasks.GrenadeCollisionMask, c.gameObject.layer))
			{
				this.behaviour.machine.PopState(true);
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.behaviour.ID, true);
				GameState.Current.Actions.RemoveProjectile(this.behaviour.ID, true);
			}
			else if (!(c.transform.tag == "MovableObject"))
			{
				if (this.behaviour._config.IsSticky)
				{
					if (c.contacts.Length > 0)
					{
						this.behaviour.transform.position = c.contacts[0].point + c.contacts[0].normal * this.behaviour.collider.bounds.extents.sqrMagnitude;
					}
					this.behaviour.machine.PopState(true);
					this.behaviour.machine.PushState(SpringGrenadeQuickItem.SpringGrenadeState.Deployed);
				}
			}
			this.PlayBounceSound(c.transform.position);
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x00068AC8 File Offset: 0x00066CC8
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

		// Token: 0x04000EA3 RID: 3747
		private SpringGrenadeQuickItem behaviour;

		// Token: 0x04000EA4 RID: 3748
		private float _timeOut;
	}

	// Token: 0x02000277 RID: 631
	private class DeployedState : IState
	{
		// Token: 0x060011A4 RID: 4516 RVA: 0x0000C33A File Offset: 0x0000A53A
		public DeployedState(SpringGrenadeQuickItem behaviour)
		{
			this.behaviour = behaviour;
			behaviour.OnProjectileExploded = null;
		}

		// Token: 0x060011A5 RID: 4517 RVA: 0x00069994 File Offset: 0x00067B94
		public void OnEnter()
		{
			this._timeOut = Time.time + (float)this.behaviour._config.LifeTime;
			SpringGrenadeQuickItem springGrenadeQuickItem = this.behaviour;
			springGrenadeQuickItem.OnTriggerEnterEvent = (Action<Collider>)Delegate.Combine(springGrenadeQuickItem.OnTriggerEnterEvent, new Action<Collider>(this.OnTriggerEnterEvent));
			if (this.behaviour.rigidbody)
			{
				this.behaviour.rigidbody.isKinematic = true;
			}
			if (this.behaviour.collider)
			{
				UnityEngine.Object.Destroy(this.behaviour.collider);
			}
			this.behaviour.gameObject.layer = 2;
			if (this.behaviour.DeployedEffect)
			{
				this.behaviour.DeployedEffect.emit = true;
			}
		}

		// Token: 0x060011A6 RID: 4518 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnResume()
		{
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x0000C350 File Offset: 0x0000A550
		public void OnExit()
		{
			SpringGrenadeQuickItem springGrenadeQuickItem = this.behaviour;
			springGrenadeQuickItem.OnTriggerEnterEvent = (Action<Collider>)Delegate.Remove(springGrenadeQuickItem.OnTriggerEnterEvent, new Action<Collider>(this.OnTriggerEnterEvent));
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x00069A68 File Offset: 0x00067C68
		public void OnTriggerEnterEvent(Collider c)
		{
			if (TagUtil.GetTag(c) == "Player")
			{
				this.behaviour.machine.PopState(true);
				GameState.Current.Player.MoveController.ApplyForce(this.behaviour._config.JumpDirection.normalized * (float)this.behaviour._config.Force, CharacterMoveController.ForceType.Additive);
				AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(this.behaviour.JumpSound, 0UL);
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.behaviour.ID, true);
				GameState.Current.Actions.RemoveProjectile(this.behaviour.ID, true);
			}
			else if (this.behaviour.collider.gameObject.layer == 20)
			{
				AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(GameAudio.JumpPad, this.behaviour.transform.position, 1f);
			}
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x0000C379 File Offset: 0x0000A579
		public void OnUpdate()
		{
			if (this._timeOut < Time.time)
			{
				this.behaviour.machine.PopState(true);
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.behaviour.ID, true);
			}
		}

		// Token: 0x04000EA5 RID: 3749
		private SpringGrenadeQuickItem behaviour;

		// Token: 0x04000EA6 RID: 3750
		private float _timeOut;
	}
}
