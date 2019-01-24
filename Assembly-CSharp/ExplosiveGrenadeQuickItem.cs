using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000268 RID: 616
public class ExplosiveGrenadeQuickItem : QuickItem, IProjectile, IGrenadeProjectile
{
	// Token: 0x14000002 RID: 2
	// (add) Token: 0x06001112 RID: 4370 RVA: 0x0000BD08 File Offset: 0x00009F08
	// (remove) Token: 0x06001113 RID: 4371 RVA: 0x0000BD21 File Offset: 0x00009F21
	private event Action<Collider> OnTriggerEnterEvent;

	// Token: 0x14000003 RID: 3
	// (add) Token: 0x06001114 RID: 4372 RVA: 0x0000BD3A File Offset: 0x00009F3A
	// (remove) Token: 0x06001115 RID: 4373 RVA: 0x0000BD53 File Offset: 0x00009F53
	private event Action<Collision> OnCollisionEnterEvent;

	// Token: 0x14000004 RID: 4
	// (add) Token: 0x06001116 RID: 4374 RVA: 0x0000BD6C File Offset: 0x00009F6C
	// (remove) Token: 0x06001117 RID: 4375 RVA: 0x0000BD85 File Offset: 0x00009F85
	public event Action<IGrenadeProjectile> OnProjectileExploded;

	// Token: 0x14000005 RID: 5
	// (add) Token: 0x06001118 RID: 4376 RVA: 0x0000BD9E File Offset: 0x00009F9E
	// (remove) Token: 0x06001119 RID: 4377 RVA: 0x0000BDB7 File Offset: 0x00009FB7
	public event Action<IGrenadeProjectile> OnProjectileEmitted;

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x0600111A RID: 4378 RVA: 0x0000BDD0 File Offset: 0x00009FD0
	public ParticleEmitter Smoke
	{
		get
		{
			return this._smoke;
		}
	}

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x0600111B RID: 4379 RVA: 0x0000BDD8 File Offset: 0x00009FD8
	public ParticleEmitter DeployedEffect
	{
		get
		{
			return this._deployedEffect;
		}
	}

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x0600111C RID: 4380 RVA: 0x0000BDE0 File Offset: 0x00009FE0
	public Renderer Renderer
	{
		get
		{
			return this._renderer;
		}
	}

	// Token: 0x17000430 RID: 1072
	// (get) Token: 0x0600111D RID: 4381 RVA: 0x0000BDE8 File Offset: 0x00009FE8
	// (set) Token: 0x0600111E RID: 4382 RVA: 0x0000BDF0 File Offset: 0x00009FF0
	public override QuickItemConfiguration Configuration
	{
		get
		{
			return this._config;
		}
		set
		{
			this._config = (ExplosiveGrenadeConfiguration)value;
		}
	}

	// Token: 0x0600111F RID: 4383 RVA: 0x00068354 File Offset: 0x00066554
	protected override void OnActivated()
	{
		Vector3 vector = GameState.Current.PlayerData.ShootingPoint + GameState.Current.Player.EyePosition;
		Vector3 position = vector + GameState.Current.PlayerData.ShootingDirection * 2f;
		Vector3 velocity = GameState.Current.PlayerData.ShootingDirection * (float)this._config.Speed;
		float distance = 2f;
		RaycastHit raycastHit;
		if (Physics.Raycast(vector, GameState.Current.PlayerData.ShootingDirection * 2f, out raycastHit, distance, UberstrikeLayerMasks.LocalRocketMask))
		{
			ExplosiveGrenadeQuickItem explosiveGrenadeQuickItem = this.Throw(raycastHit.point, Vector3.zero) as ExplosiveGrenadeQuickItem;
			explosiveGrenadeQuickItem.machine.PopAllStates();
			ExplosiveGrenadeQuickItem explosiveGrenadeQuickItem2 = explosiveGrenadeQuickItem;
			explosiveGrenadeQuickItem2.OnProjectileExploded = (Action<IGrenadeProjectile>)Delegate.Combine(explosiveGrenadeQuickItem2.OnProjectileExploded, new Action<IGrenadeProjectile>(delegate(IGrenadeProjectile p)
			{
				ProjectileDetonator.Explode(p.Position, p.ID, (float)this._config.Damage, Vector3.up, (float)this._config.SplashRadius, 5, 5, this.Configuration.ID, UberstrikeItemClass.WeaponLauncher, DamageEffectType.None, 0f);
			}));
			Singleton<ProjectileManager>.Instance.RemoveProjectile(explosiveGrenadeQuickItem.ID, true);
			GameState.Current.Actions.RemoveProjectile(explosiveGrenadeQuickItem.ID, true);
		}
		else
		{
			IGrenadeProjectile grenadeProjectile = this.Throw(position, velocity);
			grenadeProjectile.OnProjectileExploded += delegate(IGrenadeProjectile p)
			{
				ProjectileDetonator.Explode(p.Position, p.ID, (float)this._config.Damage, Vector3.up, (float)this._config.SplashRadius, 5, 5, this.Configuration.ID, UberstrikeItemClass.WeaponLauncher, DamageEffectType.None, 0f);
			};
		}
	}

	// Token: 0x06001120 RID: 4384 RVA: 0x00068494 File Offset: 0x00066694
	public IGrenadeProjectile Throw(Vector3 position, Vector3 velocity)
	{
		ExplosiveGrenadeQuickItem explosiveGrenadeQuickItem = UnityEngine.Object.Instantiate(this) as ExplosiveGrenadeQuickItem;
		if (explosiveGrenadeQuickItem)
		{
			explosiveGrenadeQuickItem.gameObject.SetActive(true);
			for (int i = 0; i < explosiveGrenadeQuickItem.transform.childCount; i++)
			{
				explosiveGrenadeQuickItem.transform.GetChild(i).gameObject.SetActive(true);
			}
			explosiveGrenadeQuickItem.Position = position;
			explosiveGrenadeQuickItem.Velocity = velocity;
			explosiveGrenadeQuickItem.collider.material.bounciness = this._config.Bounciness;
			explosiveGrenadeQuickItem.machine.RegisterState(1, new ExplosiveGrenadeQuickItem.FlyingState(explosiveGrenadeQuickItem));
			explosiveGrenadeQuickItem.machine.RegisterState(2, new ExplosiveGrenadeQuickItem.DeployedState(explosiveGrenadeQuickItem));
			explosiveGrenadeQuickItem.machine.PushState(1);
		}
		if (this.OnProjectileEmitted != null)
		{
			this.OnProjectileEmitted(explosiveGrenadeQuickItem);
		}
		return explosiveGrenadeQuickItem;
	}

	// Token: 0x06001121 RID: 4385 RVA: 0x0000BDFE File Offset: 0x00009FFE
	public void SetLayer(UberstrikeLayer layer)
	{
		LayerUtil.SetLayerRecursively(base.transform, layer);
	}

	// Token: 0x06001122 RID: 4386 RVA: 0x0000BE0C File Offset: 0x0000A00C
	private void Update()
	{
		this.machine.Update();
	}

	// Token: 0x06001123 RID: 4387 RVA: 0x00068568 File Offset: 0x00066768
	private void OnGUI()
	{
		if (base.Behaviour.IsCoolingDown && base.Behaviour.FocusTimeRemaining > 0f)
		{
			float num = Mathf.Clamp((float)Screen.height * 0.03f, 10f, 40f);
			float num2 = num * 10f;
			GUI.Label(new Rect(((float)Screen.width - num2) * 0.5f, (float)(Screen.height / 2 + 20), num2, num), "Charging Grenade", BlueStonez.label_interparkbold_16pt);
			GUITools.DrawWarmupBar(new Rect(((float)Screen.width - num2) * 0.5f, (float)(Screen.height / 2 + 50), num2, num), base.Behaviour.FocusTimeTotal - base.Behaviour.FocusTimeRemaining, base.Behaviour.FocusTimeTotal);
		}
	}

	// Token: 0x06001124 RID: 4388 RVA: 0x0000BE19 File Offset: 0x0000A019
	private void OnTriggerEnter(Collider c)
	{
		if (this.OnTriggerEnterEvent != null)
		{
			this.OnTriggerEnterEvent(c);
		}
	}

	// Token: 0x06001125 RID: 4389 RVA: 0x0000BE32 File Offset: 0x0000A032
	private void OnCollisionEnter(Collision c)
	{
		if (this.OnCollisionEnterEvent != null)
		{
			this.OnCollisionEnterEvent(c);
		}
	}

	// Token: 0x06001126 RID: 4390 RVA: 0x00068634 File Offset: 0x00066834
	public Vector3 Explode()
	{
		Vector3 result = Vector3.zero;
		try
		{
			if (this._explosionSound != null)
			{
				AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(this._explosionSound, base.transform.position, 1f);
			}
			if (this._explosionSfx)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(this._explosionSfx) as GameObject;
				if (gameObject)
				{
					gameObject.transform.position = base.transform.position;
					SelfDestroy selfDestroy = gameObject.AddComponent<SelfDestroy>();
					if (selfDestroy)
					{
						selfDestroy.SetDelay(2f);
					}
				}
			}
			else
			{
				ParticleEffectController.ShowExplosionEffect(ParticleConfigurationType.LauncherDefault, SurfaceEffectType.None, base.transform.position, Vector3.up);
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

	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x06001127 RID: 4391 RVA: 0x0000BE4B File Offset: 0x0000A04B
	// (set) Token: 0x06001128 RID: 4392 RVA: 0x0000BE53 File Offset: 0x0000A053
	public int ID { get; set; }

	// Token: 0x06001129 RID: 4393 RVA: 0x0000BE5C File Offset: 0x0000A05C
	public void Destroy()
	{
		if (!this._isDestroyed)
		{
			this._isDestroyed = true;
			base.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x0600112A RID: 4394 RVA: 0x0000BE87 File Offset: 0x0000A087
	// (set) Token: 0x0600112B RID: 4395 RVA: 0x0000BEAE File Offset: 0x0000A0AE
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

	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x0600112C RID: 4396 RVA: 0x0000BECC File Offset: 0x0000A0CC
	// (set) Token: 0x0600112D RID: 4397 RVA: 0x0000BEF3 File Offset: 0x0000A0F3
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

	// Token: 0x04000E57 RID: 3671
	[SerializeField]
	private Renderer _renderer;

	// Token: 0x04000E58 RID: 3672
	[SerializeField]
	private ParticleEmitter _smoke;

	// Token: 0x04000E59 RID: 3673
	[SerializeField]
	private ParticleEmitter _deployedEffect;

	// Token: 0x04000E5A RID: 3674
	[SerializeField]
	private AudioClip _explosionSound;

	// Token: 0x04000E5B RID: 3675
	[SerializeField]
	private GameObject _explosionSfx;

	// Token: 0x04000E5C RID: 3676
	[SerializeField]
	private ExplosiveGrenadeConfiguration _config;

	// Token: 0x04000E5D RID: 3677
	private StateMachine machine = new StateMachine();

	// Token: 0x04000E5E RID: 3678
	private bool _isDestroyed;

	// Token: 0x02000269 RID: 617
	private class FlyingState : IState
	{
		// Token: 0x06001130 RID: 4400 RVA: 0x0000BF11 File Offset: 0x0000A111
		public FlyingState(ExplosiveGrenadeQuickItem behaviour)
		{
			this.behaviour = behaviour;
		}

		// Token: 0x06001131 RID: 4401 RVA: 0x00068790 File Offset: 0x00066990
		public void OnEnter()
		{
			this._timeOut = Time.time + (float)this.behaviour._config.LifeTime;
			ExplosiveGrenadeQuickItem explosiveGrenadeQuickItem = this.behaviour;
			explosiveGrenadeQuickItem.OnCollisionEnterEvent = (Action<Collision>)Delegate.Combine(explosiveGrenadeQuickItem.OnCollisionEnterEvent, new Action<Collision>(this.OnCollisionEnterEvent));
			if (!this.behaviour._config.IsSticky)
			{
				ExplosiveGrenadeQuickItem explosiveGrenadeQuickItem2 = this.behaviour;
				explosiveGrenadeQuickItem2.OnTriggerEnterEvent = (Action<Collider>)Delegate.Combine(explosiveGrenadeQuickItem2.OnTriggerEnterEvent, new Action<Collider>(this.OnTriggerEnterEvent));
			}
			GameObject gameObject = this.behaviour.gameObject;
			if (gameObject && GameState.Current.Avatar.Decorator && gameObject.collider)
			{
				Collider collider = gameObject.collider;
				foreach (CharacterHitArea characterHitArea in GameState.Current.Avatar.Decorator.HitAreas)
				{
					if (gameObject.activeSelf && characterHitArea.gameObject.activeSelf)
					{
						Physics.IgnoreCollision(collider, characterHitArea.collider);
					}
				}
			}
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x000688C0 File Offset: 0x00066AC0
		public void OnExit()
		{
			ExplosiveGrenadeQuickItem explosiveGrenadeQuickItem = this.behaviour;
			explosiveGrenadeQuickItem.OnCollisionEnterEvent = (Action<Collision>)Delegate.Remove(explosiveGrenadeQuickItem.OnCollisionEnterEvent, new Action<Collision>(this.OnCollisionEnterEvent));
			if (!this.behaviour._config.IsSticky)
			{
				ExplosiveGrenadeQuickItem explosiveGrenadeQuickItem2 = this.behaviour;
				explosiveGrenadeQuickItem2.OnTriggerEnterEvent = (Action<Collider>)Delegate.Remove(explosiveGrenadeQuickItem2.OnTriggerEnterEvent, new Action<Collider>(this.OnTriggerEnterEvent));
			}
		}

		// Token: 0x06001133 RID: 4403 RVA: 0x0000BF20 File Offset: 0x0000A120
		public void OnUpdate()
		{
			if (this._timeOut < Time.time)
			{
				this.behaviour.machine.PopState(true);
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.behaviour.ID, true);
			}
		}

		// Token: 0x06001134 RID: 4404 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnResume()
		{
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x00068930 File Offset: 0x00066B30
		private void OnCollisionEnterEvent(Collision c)
		{
			if (LayerUtil.IsLayerInMask(UberstrikeLayerMasks.GrenadeCollisionMask, c.gameObject.layer))
			{
				this.behaviour.machine.PopState(true);
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.behaviour.ID, true);
				GameState.Current.Actions.RemoveProjectile(this.behaviour.ID, true);
			}
			else if (this.behaviour._config.IsSticky)
			{
				if (c.contacts.Length > 0)
				{
					this.behaviour.transform.position = c.contacts[0].point + c.contacts[0].normal * this.behaviour.collider.bounds.extents.sqrMagnitude;
				}
				this.behaviour.machine.PopState(true);
				this.behaviour.machine.PushState(2);
			}
			this.PlayBounceSound(c.transform.position);
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x00068A58 File Offset: 0x00066C58
		private void OnTriggerEnterEvent(Collider c)
		{
			if (LayerUtil.IsLayerInMask(UberstrikeLayerMasks.GrenadeCollisionMask, c.gameObject.layer))
			{
				this.behaviour.machine.PopState(true);
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.behaviour.ID, true);
				GameState.Current.Actions.RemoveProjectile(this.behaviour.ID, true);
			}
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x00068AC8 File Offset: 0x00066CC8
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

		// Token: 0x04000E64 RID: 3684
		private ExplosiveGrenadeQuickItem behaviour;

		// Token: 0x04000E65 RID: 3685
		private float _timeOut;
	}

	// Token: 0x0200026A RID: 618
	private class DeployedState : IState
	{
		// Token: 0x06001138 RID: 4408 RVA: 0x0000BF59 File Offset: 0x0000A159
		public DeployedState(ExplosiveGrenadeQuickItem behaviour)
		{
			this.behaviour = behaviour;
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x00068B04 File Offset: 0x00066D04
		public void OnEnter()
		{
			this._timeOut = Time.time + (float)this.behaviour._config.LifeTime;
			ExplosiveGrenadeQuickItem explosiveGrenadeQuickItem = this.behaviour;
			explosiveGrenadeQuickItem.OnTriggerEnterEvent = (Action<Collider>)Delegate.Combine(explosiveGrenadeQuickItem.OnTriggerEnterEvent, new Action<Collider>(this.OnTriggerEnterEvent));
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

		// Token: 0x0600113A RID: 4410 RVA: 0x00003C87 File Offset: 0x00001E87
		public void OnResume()
		{
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x0000BF68 File Offset: 0x0000A168
		public void OnExit()
		{
			ExplosiveGrenadeQuickItem explosiveGrenadeQuickItem = this.behaviour;
			explosiveGrenadeQuickItem.OnTriggerEnterEvent = (Action<Collider>)Delegate.Remove(explosiveGrenadeQuickItem.OnTriggerEnterEvent, new Action<Collider>(this.OnTriggerEnterEvent));
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x00068BD8 File Offset: 0x00066DD8
		private void OnTriggerEnterEvent(Collider c)
		{
			if (LayerUtil.IsLayerInMask(UberstrikeLayerMasks.GrenadeCollisionMask, c.gameObject.layer))
			{
				this.behaviour.machine.PopState(true);
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.behaviour.ID, true);
				GameState.Current.Actions.RemoveProjectile(this.behaviour.ID, true);
			}
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x0000BF91 File Offset: 0x0000A191
		public void OnUpdate()
		{
			if (this._timeOut < Time.time)
			{
				this.behaviour.machine.PopState(true);
				Singleton<ProjectileManager>.Instance.RemoveProjectile(this.behaviour.ID, true);
			}
		}

		// Token: 0x04000E66 RID: 3686
		private ExplosiveGrenadeQuickItem behaviour;

		// Token: 0x04000E67 RID: 3687
		private float _timeOut;
	}
}
