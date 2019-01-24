using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000365 RID: 869
public class CharacterConfig : MonoBehaviour, IShootable
{
	// Token: 0x17000590 RID: 1424
	// (get) Token: 0x06001847 RID: 6215 RVA: 0x00010458 File Offset: 0x0000E658
	// (set) Token: 0x06001848 RID: 6216 RVA: 0x00010460 File Offset: 0x0000E660
	public ICharacterState State { get; private set; }

	// Token: 0x17000591 RID: 1425
	// (get) Token: 0x06001849 RID: 6217 RVA: 0x00010469 File Offset: 0x0000E669
	// (set) Token: 0x0600184A RID: 6218 RVA: 0x00010471 File Offset: 0x0000E671
	public global::Avatar Avatar { get; private set; }

	// Token: 0x17000592 RID: 1426
	// (get) Token: 0x0600184B RID: 6219 RVA: 0x0001047A File Offset: 0x0000E67A
	public bool IsLocal
	{
		get
		{
			return this._isLocalPlayer;
		}
	}

	// Token: 0x17000593 RID: 1427
	// (get) Token: 0x0600184C RID: 6220 RVA: 0x00010482 File Offset: 0x0000E682
	public Transform Transform
	{
		get
		{
			return this._transform;
		}
	}

	// Token: 0x17000594 RID: 1428
	// (get) Token: 0x0600184D RID: 6221 RVA: 0x0001048A File Offset: 0x0000E68A
	private bool IsMe
	{
		get
		{
			return this.State.Player.Cmid == PlayerDataManager.Cmid;
		}
	}

	// Token: 0x17000595 RID: 1429
	// (get) Token: 0x0600184E RID: 6222 RVA: 0x000104A3 File Offset: 0x0000E6A3
	public bool IsVulnerable
	{
		get
		{
			return this._isVulnerableAfter < Time.time;
		}
	}

	// Token: 0x17000596 RID: 1430
	// (get) Token: 0x0600184F RID: 6223 RVA: 0x000104B2 File Offset: 0x0000E6B2
	// (set) Token: 0x06001850 RID: 6224 RVA: 0x000104BA File Offset: 0x0000E6BA
	public bool IsDead { get; private set; }

	// Token: 0x17000597 RID: 1431
	// (get) Token: 0x06001851 RID: 6225 RVA: 0x000104C3 File Offset: 0x0000E6C3
	// (set) Token: 0x06001852 RID: 6226 RVA: 0x000104CB File Offset: 0x0000E6CB
	public float TimeLastGrounded { get; private set; }

	// Token: 0x17000598 RID: 1432
	// (get) Token: 0x06001853 RID: 6227 RVA: 0x000104D4 File Offset: 0x0000E6D4
	// (set) Token: 0x06001854 RID: 6228 RVA: 0x000104DC File Offset: 0x0000E6DC
	public WeaponSimulator WeaponSimulator { get; private set; }

	// Token: 0x17000599 RID: 1433
	// (get) Token: 0x06001855 RID: 6229 RVA: 0x000104E5 File Offset: 0x0000E6E5
	// (set) Token: 0x06001856 RID: 6230 RVA: 0x000104ED File Offset: 0x0000E6ED
	public SoundSimulator SoundSimulator { get; private set; }

	// Token: 0x1700059A RID: 1434
	// (get) Token: 0x06001857 RID: 6231 RVA: 0x000104F6 File Offset: 0x0000E6F6
	public TeamID Team
	{
		get
		{
			return (this.State == null) ? TeamID.NONE : this.State.Player.TeamID;
		}
	}

	// Token: 0x1700059B RID: 1435
	// (get) Token: 0x06001858 RID: 6232 RVA: 0x00010519 File Offset: 0x0000E719
	public CharacterTrigger AimTrigger
	{
		get
		{
			return this._aimTrigger;
		}
	}

	// Token: 0x06001859 RID: 6233 RVA: 0x00010521 File Offset: 0x0000E721
	private void Awake()
	{
		this.WeaponSimulator = new WeaponSimulator(this);
		this.SoundSimulator = new SoundSimulator(this);
		this._transform = base.transform;
	}

	// Token: 0x0600185A RID: 6234 RVA: 0x000827B8 File Offset: 0x000809B8
	private void Update()
	{
		if (this.State != null && !this.IsDead && this._transform != null)
		{
			this._transform.localPosition = this.State.Position;
			this._transform.localRotation = this.State.HorizontalRotation;
			this.WeaponSimulator.Update();
			this.SoundSimulator.Update();
		}
	}

	// Token: 0x0600185B RID: 6235 RVA: 0x00010547 File Offset: 0x0000E747
	private void OnDestroy()
	{
		if (this.Avatar != null)
		{
			this.Avatar.OnDecoratorChanged -= this.OnDecoratorUpdated;
		}
	}

	// Token: 0x0600185C RID: 6236 RVA: 0x00082830 File Offset: 0x00080A30
	public void OnJump()
	{
		ICharacterState state = this.State;
		state.MovementState |= (MoveStates.Grounded | MoveStates.Jumping);
		if (this.Avatar.Decorator)
		{
			this.Avatar.Decorator.PlayJumpSound();
			if (this.Avatar.Decorator.AnimationController)
			{
				this.Avatar.Decorator.AnimationController.Jump();
			}
			RaycastHit raycastHit;
			if (Physics.Raycast(this._transform.position, Vector3.down, out raycastHit, 3f, UberstrikeLayerMasks.ProtectionMask))
			{
				ParticleEffectController.ShowJumpEffect(raycastHit.point, raycastHit.normal);
			}
		}
	}

	// Token: 0x0600185D RID: 6237 RVA: 0x000828E4 File Offset: 0x00080AE4
	public void Initialize(ICharacterState state, global::Avatar avatar)
	{
		this.State = state;
		this.State.OnDeltaUpdate += this.OnDeltaUpdate;
		this._transform.position = this.State.Position;
		if (!this.State.Player.IsAlive)
		{
			Debug.Log("Initialize as dead player at " + this.State.Position);
		}
		base.gameObject.name = string.Format("Player{0}_{1}", this.State.Player.Cmid, this.State.Player.PlayerName);
		this.SetAvatar(avatar);
		this.WeaponSimulator.UpdateWeapons((int)this.State.Player.CurrentWeaponSlot, this.State.Player.Weapons);
	}

	// Token: 0x0600185E RID: 6238 RVA: 0x000829C8 File Offset: 0x00080BC8
	public void Reset()
	{
		this.IsDead = false;
		this.Avatar.CleanupRagdoll();
		this.WeaponSimulator.UpdateWeaponSlot((int)this.State.Player.CurrentWeaponSlot, !this._isLocalPlayer);
		this.Update();
		this._isVulnerableAfter = Time.time + 2f;
	}

	// Token: 0x0600185F RID: 6239 RVA: 0x00082A24 File Offset: 0x00080C24
	private void OnDeltaUpdate(GameActorInfoDelta update)
	{
		foreach (GameActorInfoDelta.Keys keys in update.Changes.Keys)
		{
			GameActorInfoDelta.Keys keys2 = keys;
			switch (keys2)
			{
			case GameActorInfoDelta.Keys.CurrentWeaponSlot:
				this.WeaponSimulator.UpdateWeaponSlot((int)this.State.Player.CurrentWeaponSlot, true);
				break;
			default:
				if (keys2 == GameActorInfoDelta.Keys.Weapons)
				{
					this.WeaponSimulator.UpdateWeapons((int)this.State.Player.CurrentWeaponSlot, this.State.Player.Weapons);
					this.WeaponSimulator.UpdateWeaponSlot((int)this.State.Player.CurrentWeaponSlot, !this.IsLocal);
					if (this.IsLocal && !Singleton<WeaponController>.Instance.CheckWeapons(GameState.Current.PlayerData.Player.Weapons))
					{
						GameState.Current.Player.InitializeWeapons();
					}
				}
				break;
			case GameActorInfoDelta.Keys.Gear:
				if (!this.IsLocal)
				{
					this.Avatar.Loadout.UpdateGearSlots(this.State.Player.Gear);
				}
				break;
			case GameActorInfoDelta.Keys.Health:
				this.Avatar.Decorator.HudInformation.SetHealthBarValue((float)this.State.Player.Health / 100f);
				break;
			}
		}
	}

	// Token: 0x06001860 RID: 6240 RVA: 0x00082BC8 File Offset: 0x00080DC8
	public void ApplyDamage(DamageInfo damageInfo)
	{
		if (damageInfo.Damage > 0)
		{
			this._lastShotInfo = damageInfo;
			if (this.State.Player.IsAlive)
			{
				if (damageInfo.IsExplosion)
				{
					GameState.Current.Actions.ExplosionHitDamage(this.State.Player.Cmid, (ushort)damageInfo.Damage, damageInfo.Force, damageInfo.SlotId, damageInfo.Distance);
				}
				else
				{
					GameState.Current.Actions.DirectHitDamage(this.State.Player.Cmid, (ushort)damageInfo.Damage, damageInfo.BodyPart, damageInfo.Force, damageInfo.SlotId, damageInfo.Bullets);
				}
				this.PlayDamageSound();
				if (!this.IsLocal && (this.State.Player.TeamID == TeamID.NONE || this.State.Player.TeamID != GameState.Current.PlayerData.Player.TeamID))
				{
					GameState.Current.PlayerData.AppliedDamage.Value = damageInfo;
					this.ShowDamageFeedback(damageInfo);
				}
			}
		}
	}

	// Token: 0x06001861 RID: 6241 RVA: 0x00082CF8 File Offset: 0x00080EF8
	public virtual void ApplyForce(Vector3 position, Vector3 force)
	{
		if (this.IsLocal)
		{
			GameState.Current.Player.MoveController.ApplyForce(force, CharacterMoveController.ForceType.Additive);
		}
		else
		{
			GameState.Current.Actions.PlayerHitFeeback(this.State.Player.Cmid, force);
		}
	}

	// Token: 0x1700059C RID: 1436
	// (get) Token: 0x06001862 RID: 6242 RVA: 0x0001056B File Offset: 0x0000E76B
	public float WalkingSoundSpeed
	{
		get
		{
			return 0.3157895f;
		}
	}

	// Token: 0x1700059D RID: 1437
	// (get) Token: 0x06001863 RID: 6243 RVA: 0x00010572 File Offset: 0x0000E772
	public float DiveSoundSpeed
	{
		get
		{
			return 1.6f;
		}
	}

	// Token: 0x1700059E RID: 1438
	// (get) Token: 0x06001864 RID: 6244 RVA: 0x00010579 File Offset: 0x0000E779
	public float SwimSoundSpeed
	{
		get
		{
			return 1.2f;
		}
	}

	// Token: 0x06001865 RID: 6245 RVA: 0x00082D50 File Offset: 0x00080F50
	private void SetAvatar(global::Avatar avatar)
	{
		if (this.Avatar != null)
		{
			this.Avatar.OnDecoratorChanged -= this.OnDecoratorUpdated;
		}
		this.Avatar = avatar;
		this.Avatar.OnDecoratorChanged += this.OnDecoratorUpdated;
		this.OnDecoratorUpdated();
	}

	// Token: 0x06001866 RID: 6246 RVA: 0x00082DA4 File Offset: 0x00080FA4
	private void OnDecoratorUpdated()
	{
		if (this.Avatar.Decorator)
		{
			try
			{
				this.Avatar.Decorator.renderer.receiveShadows = false;
				this.Avatar.Decorator.renderer.castShadows = true;
				this.Avatar.Decorator.transform.parent = this._transform;
				this.Avatar.Decorator.SetPosition(new Vector3(0f, -1.05f, 0f), Quaternion.identity);
				this.Avatar.Decorator.HudInformation.SetCharacterInfo(this.State.Player);
				this.Avatar.Decorator.HudInformation.SetHealthBarValue((float)this.State.Player.Health / 100f);
				this.Avatar.Decorator.CurrentFootStep = ((!(GameState.Current.Map != null)) ? FootStepSoundType.Rock : GameState.Current.Map.DefaultFootStep);
				foreach (CharacterHitArea characterHitArea in this.Avatar.Decorator.HitAreas)
				{
					if (characterHitArea)
					{
						characterHitArea.Shootable = this;
					}
				}
				Color skinColor = (!this._isLocalPlayer) ? this.State.Player.SkinColor : PlayerDataManager.SkinColor;
				this.Avatar.Decorator.Configuration.SetSkinColor(skinColor);
				this.WeaponSimulator.UpdateWeaponSlot((int)this.State.Player.CurrentWeaponSlot, !this._isLocalPlayer);
				if (this.Avatar.Decorator.AnimationController)
				{
					this.Avatar.Decorator.AnimationController.SetCharacter(this.State);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}

	// Token: 0x06001867 RID: 6247 RVA: 0x00082FBC File Offset: 0x000811BC
	internal void Destroy()
	{
		try
		{
			Singleton<ProjectileManager>.Instance.RemoveAllProjectilesFromPlayer(this.State.Player.PlayerId);
			Singleton<QuickItemSfxController>.Instance.DestroytSfxFromPlayer(this.State.Player.PlayerId);
			if (this.State != null)
			{
				this.State.OnDeltaUpdate -= this.OnDeltaUpdate;
			}
			this.Avatar.CleanupRagdoll();
			if (this.Avatar.Decorator != null && this.IsLocal)
			{
				this.Avatar.Decorator.transform.parent = null;
			}
			if (base.gameObject != null)
			{
				global::AvatarBuilder.Destroy(base.gameObject);
			}
		}
		catch (Exception message)
		{
			Debug.LogError(message);
		}
	}

	// Token: 0x06001868 RID: 6248 RVA: 0x000830A0 File Offset: 0x000812A0
	private void PlayDamageSound()
	{
		if (this.IsLocal)
		{
			if (this.State.Player.ArmorPoints > 0)
			{
				AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.LocalPlayerHitArmorRemaining, 0UL);
			}
			else if (this.State.Player.Health < 25)
			{
				AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.LocalPlayerHitNoArmorLowHealth, 0UL);
			}
			else
			{
				AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.LocalPlayerHitNoArmor, 0UL);
			}
		}
	}

	// Token: 0x06001869 RID: 6249 RVA: 0x00083124 File Offset: 0x00081324
	private void ShowDamageFeedback(DamageInfo shot)
	{
		PlayerDamageEffect playerDamageEffect = UnityEngine.Object.Instantiate(this._damageFeedback, shot.Hitpoint, (shot.Force.magnitude <= 0f) ? Quaternion.identity : Quaternion.LookRotation(shot.Force)) as PlayerDamageEffect;
		if (playerDamageEffect)
		{
			playerDamageEffect.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
			playerDamageEffect.Show(shot);
		}
	}

	// Token: 0x0600186A RID: 6250 RVA: 0x000831A8 File Offset: 0x000813A8
	internal void SetDead(Vector3 direction, BodyPart bodyPart = BodyPart.Body, int target = 0, UberstrikeItemClass itemClass = UberstrikeItemClass.WeaponMachinegun)
	{
		this.IsDead = true;
		if (this._transform)
		{
			this._transform.position = this.State.Position;
		}
		Singleton<QuickItemSfxController>.Instance.DestroytSfxFromPlayer(this.State.Player.PlayerId);
		if (this.Avatar.Decorator)
		{
			this.Avatar.Decorator.HudInformation.Hide();
			this.Avatar.Decorator.PlayDieSound();
		}
		if (!this._isLocalPlayer)
		{
			this.Avatar.HideWeapons();
		}
		DamageInfo damageInfo = new DamageInfo(direction, bodyPart);
		damageInfo.WeaponClass = itemClass;
		if (PlayerDataManager.Cmid == target && (itemClass == UberstrikeItemClass.WeaponCannon || itemClass == UberstrikeItemClass.WeaponLauncher))
		{
			damageInfo.Force = direction.normalized;
			damageInfo.Damage = ((this._lastShotInfo == null) ? Convert.ToInt16(100) : this._lastShotInfo.Damage);
		}
		this.Avatar.SpawnRagdoll(damageInfo);
	}

	// Token: 0x040016F6 RID: 5878
	private Transform _transform;

	// Token: 0x040016F7 RID: 5879
	private DamageInfo _lastShotInfo;

	// Token: 0x040016F8 RID: 5880
	private float _isVulnerableAfter;

	// Token: 0x040016F9 RID: 5881
	[SerializeField]
	private bool _isLocalPlayer;

	// Token: 0x040016FA RID: 5882
	[SerializeField]
	private PlayerDamageEffect _damageFeedback;

	// Token: 0x040016FB RID: 5883
	[SerializeField]
	private CharacterTrigger _aimTrigger;

	// Token: 0x040016FC RID: 5884
	[SerializeField]
	private PlayerDropPickupItem _playerDropWeapon;
}
