using System;
using System.Collections;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x0200036D RID: 877
[RequireComponent(typeof(CharacterController))]
public class LocalPlayer : MonoBehaviour
{
	// Token: 0x060018C1 RID: 6337 RVA: 0x000108CC File Offset: 0x0000EACC
	private void Awake()
	{
		this.MoveController = new CharacterMoveController(base.GetComponent<CharacterController>());
		this.MoveController.CharacterLanded += this.OnCharacterGrounded;
		this.IsWalkingEnabled = true;
	}

	// Token: 0x060018C2 RID: 6338 RVA: 0x000108FD File Offset: 0x0000EAFD
	private void OnEnable()
	{
		this.MoveController.Init();
		base.StartCoroutine(this.StartPlayerIdentification());
		base.StartCoroutine(this.StartUpdatePlayerPingTime(5));
	}

	// Token: 0x060018C3 RID: 6339 RVA: 0x00010925 File Offset: 0x0000EB25
	private void OnDisable()
	{
		Screen.lockCursor = false;
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = false;
	}

	// Token: 0x060018C4 RID: 6340 RVA: 0x00085190 File Offset: 0x00083390
	private void Update()
	{
		this._cameraTarget.localPosition = Vector3.Lerp(this._cameraTarget.localPosition, GameState.Current.PlayerData.CurrentOffset, 10f * Time.deltaTime);
		if (this._damageFactor != 0f)
		{
			if (this._damageFactorDuration > 0f)
			{
				this._damageFactorDuration -= Time.deltaTime;
			}
			if (this._damageFactorDuration <= 0f || !GameState.Current.PlayerData.IsAlive)
			{
				this._damageFactor = 0f;
				this._damageFactorDuration = 0f;
			}
		}
		this.UpdateCameraBob();
		if (AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled)
		{
			if (Screen.lockCursor)
			{
				UserInput.UpdateMouse();
			}
			UserInput.UpdateDirections();
			if (Screen.lockCursor)
			{
				this.UpdateRotation();
			}
		}
		else
		{
			UserInput.ResetDirection();
		}
	}

	// Token: 0x060018C5 RID: 6341 RVA: 0x00010938 File Offset: 0x0000EB38
	private void LateUpdate()
	{
		Singleton<WeaponController>.Instance.LateUpdate();
	}

	// Token: 0x060018C6 RID: 6342 RVA: 0x00010944 File Offset: 0x0000EB44
	private void UpdateRotation()
	{
		this._cameraTarget.localRotation = UserInput.Rotation;
	}

	// Token: 0x060018C7 RID: 6343 RVA: 0x00085284 File Offset: 0x00083484
	private IEnumerator StartPlayerIdentification()
	{
		for (;;)
		{
			yield return new WaitForSeconds(0.3f);
			if (!GameState.Current.IsPlayerPaused)
			{
				Vector3 start = GameState.Current.PlayerData.ShootingPoint + GameState.Current.Player.EyePosition;
				Vector3 end = start + GameState.Current.PlayerData.ShootingDirection * 1000f;
				RaycastHit hit;
				if (Physics.Linecast(start, end, out hit, UberstrikeLayerMasks.IdentificationMask))
				{
					CharacterHitArea hitArea = hit.collider.GetComponent<CharacterHitArea>();
					if (hitArea && hitArea.Shootable != null && !hitArea.Shootable.IsLocal)
					{
						CharacterConfig character = (CharacterConfig)hitArea.Shootable;
						character.AimTrigger.HudInfo.Show();
						GameState.Current.PlayerData.FocusedPlayerTeam.Value = character.Team;
						if (!this._didPlayTargetSound)
						{
							AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.FocusEnemy, 0UL, 1f, 1f);
							this._didPlayTargetSound = true;
						}
					}
					else
					{
						GameState.Current.PlayerData.FocusedPlayerTeam.Value = TeamID.NONE;
						this._didPlayTargetSound = false;
					}
				}
				else
				{
					GameState.Current.PlayerData.FocusedPlayerTeam.Value = TeamID.NONE;
					this._didPlayTargetSound = false;
				}
			}
		}
		yield break;
	}

	// Token: 0x060018C8 RID: 6344 RVA: 0x000852A0 File Offset: 0x000834A0
	private IEnumerator StartUpdatePlayerPingTime(int sec)
	{
		for (;;)
		{
			GameState.Current.PlayerData.SetPing((int)Singleton<GameStateController>.Instance.Client.Ping);
			yield return new WaitForSeconds((float)sec);
		}
		yield break;
	}

	// Token: 0x060018C9 RID: 6345 RVA: 0x000852C4 File Offset: 0x000834C4
	private void OnCharacterGrounded(float velocity)
	{
		if (GameState.Current.HasJoinedGame && GameState.Current.IsInGame && !WeaponFeedbackManager.IsBobbing && this._lastGrounded + 0.5f < Time.time && !GameState.Current.PlayerData.Is(MoveStates.Diving))
		{
			this._lastGrounded = Time.time;
			if (this.Character != null && this.Character.Avatar != null && this.Character.Avatar.Decorator != null)
			{
				this.Character.Avatar.Decorator.PlayFootSound(this.Character.WalkingSoundSpeed);
				if (velocity < -20f)
				{
					LevelCamera.DoLandFeedback(true);
				}
				else
				{
					LevelCamera.DoLandFeedback(false);
				}
			}
		}
	}

	// Token: 0x060018CA RID: 6346 RVA: 0x000853AC File Offset: 0x000835AC
	private void UpdateCameraBob()
	{
		MoveStates movementState = GameState.Current.PlayerData.MovementState;
		switch (movementState)
		{
		case MoveStates.Grounded:
			if (UserInput.IsWalking)
			{
				if (Singleton<WeaponController>.Instance.IsSecondaryAction)
				{
					WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.None);
				}
				else
				{
					WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.Run);
				}
			}
			else if (Singleton<WeaponController>.Instance.IsSecondaryAction)
			{
				WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.None);
			}
			else if (!UserInput.IsWalking || this.MoveController.Velocity.y < -300f)
			{
				WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.Idle);
			}
			break;
		default:
			if (movementState != (MoveStates.Grounded | MoveStates.Ducked))
			{
				if (movementState != MoveStates.Swimming)
				{
					if (!UserInput.IsWalking || this.MoveController.Velocity.y < -300f)
					{
						WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.None);
					}
				}
				else
				{
					WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.Swim);
				}
			}
			else if (UserInput.IsWalking)
			{
				if (Singleton<WeaponController>.Instance.IsSecondaryAction)
				{
					WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.None);
				}
				else
				{
					WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.Crouch);
				}
			}
			else if (Singleton<WeaponController>.Instance.IsSecondaryAction)
			{
				WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.None);
			}
			else
			{
				WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.Idle);
			}
			break;
		case MoveStates.Flying:
			WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.Fly);
			break;
		}
	}

	// Token: 0x060018CB RID: 6347 RVA: 0x00010956 File Offset: 0x0000EB56
	public void InitializeWeapons()
	{
		Singleton<WeaponController>.Instance.InitializeAllWeapons(this._weaponAttachPoint);
	}

	// Token: 0x060018CC RID: 6348 RVA: 0x00085510 File Offset: 0x00083710
	public void InitializePlayer()
	{
		try
		{
			this.InitializeWeapons();
			WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.None);
			LevelCamera.EnableLowPassFilter(false);
			this.UpdateRotation();
			this.MoveController.Start();
			this.MoveController.ResetDuckMode();
			Singleton<QuickItemController>.Instance.Reset();
			GameState.Current.PlayerData.InitializePlayer();
			this.DamageFactor = 0f;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	// Token: 0x060018CD RID: 6349 RVA: 0x00085590 File Offset: 0x00083790
	public void SpawnPlayerAt(Vector3 pos, Quaternion rot)
	{
		try
		{
			base.transform.position = pos + Vector3.up;
			this._cameraTarget.localRotation = rot;
			UserInput.SetRotation(rot.eulerAngles.y, 0f);
			LevelCamera.ResetFeedback();
			this.MoveController.ResetEnviroment();
			this.MoveController.Platform = null;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	// Token: 0x060018CE RID: 6350 RVA: 0x00010968 File Offset: 0x0000EB68
	public void SetCurrentCharacterConfig(CharacterConfig character)
	{
		this.Character = character;
	}

	// Token: 0x170005AD RID: 1453
	// (get) Token: 0x060018CF RID: 6351 RVA: 0x00010971 File Offset: 0x0000EB71
	// (set) Token: 0x060018D0 RID: 6352 RVA: 0x00010979 File Offset: 0x0000EB79
	public CharacterConfig Character { get; private set; }

	// Token: 0x170005AE RID: 1454
	// (get) Token: 0x060018D1 RID: 6353 RVA: 0x00010982 File Offset: 0x0000EB82
	// (set) Token: 0x060018D2 RID: 6354 RVA: 0x0001098A File Offset: 0x0000EB8A
	public float DamageFactor
	{
		get
		{
			return this._damageFactor;
		}
		set
		{
			this._damageFactor = Mathf.Clamp01(value);
			this._damageFactorDuration = this._damageFactor * 15f;
		}
	}

	// Token: 0x060018D3 RID: 6355 RVA: 0x000109AA File Offset: 0x0000EBAA
	public void SetEnabled(bool enabled)
	{
		base.gameObject.SetActive(enabled);
	}

	// Token: 0x170005AF RID: 1455
	// (get) Token: 0x060018D4 RID: 6356 RVA: 0x000109B8 File Offset: 0x0000EBB8
	// (set) Token: 0x060018D5 RID: 6357 RVA: 0x000109C0 File Offset: 0x0000EBC0
	public bool IsWalkingEnabled { get; set; }

	// Token: 0x170005B0 RID: 1456
	// (get) Token: 0x060018D6 RID: 6358 RVA: 0x000109C9 File Offset: 0x0000EBC9
	// (set) Token: 0x060018D7 RID: 6359 RVA: 0x000109D1 File Offset: 0x0000EBD1
	public bool EnableWeaponControl { get; set; }

	// Token: 0x170005B1 RID: 1457
	// (get) Token: 0x060018D8 RID: 6360 RVA: 0x000109DA File Offset: 0x0000EBDA
	// (set) Token: 0x060018D9 RID: 6361 RVA: 0x000109E2 File Offset: 0x0000EBE2
	public CharacterMoveController MoveController { get; private set; }

	// Token: 0x170005B2 RID: 1458
	// (get) Token: 0x060018DA RID: 6362 RVA: 0x000109EB File Offset: 0x0000EBEB
	public WeaponCamera WeaponCamera
	{
		get
		{
			return this._weaponCamera;
		}
	}

	// Token: 0x170005B3 RID: 1459
	// (get) Token: 0x060018DB RID: 6363 RVA: 0x000109F3 File Offset: 0x0000EBF3
	public Transform WeaponAttachPoint
	{
		get
		{
			return this._weaponAttachPoint;
		}
	}

	// Token: 0x170005B4 RID: 1460
	// (get) Token: 0x060018DC RID: 6364 RVA: 0x000109FB File Offset: 0x0000EBFB
	public Transform CameraTarget
	{
		get
		{
			return this._cameraTarget;
		}
	}

	// Token: 0x170005B5 RID: 1461
	// (get) Token: 0x060018DD RID: 6365 RVA: 0x00010A03 File Offset: 0x0000EC03
	public Vector3 EyePosition
	{
		get
		{
			return new Vector3(0f, -0.2f, 0f);
		}
	}

	// Token: 0x0400173A RID: 5946
	private const float RundownThreshold = -300f;

	// Token: 0x0400173B RID: 5947
	private const float GroundedThreshold = 0.5f;

	// Token: 0x0400173C RID: 5948
	[SerializeField]
	private Transform _cameraTarget;

	// Token: 0x0400173D RID: 5949
	[SerializeField]
	private Transform _weaponAttachPoint;

	// Token: 0x0400173E RID: 5950
	[SerializeField]
	private WeaponCamera _weaponCamera;

	// Token: 0x0400173F RID: 5951
	private bool _didPlayTargetSound;

	// Token: 0x04001740 RID: 5952
	private float _damageFactor;

	// Token: 0x04001741 RID: 5953
	private float _damageFactorDuration;

	// Token: 0x04001742 RID: 5954
	private float _lastGrounded;
}
