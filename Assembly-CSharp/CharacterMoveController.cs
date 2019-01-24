using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class CharacterMoveController
{
	// Token: 0x06001895 RID: 6293 RVA: 0x000840A0 File Offset: 0x000822A0
	public CharacterMoveController(CharacterController controller)
	{
		this._controller = controller;
		this._transform = this._controller.transform;
		global::EventHandler.Global.AddListener<GlobalEvents.InputChanged>(new Action<GlobalEvents.InputChanged>(this.OnInputChanged));
	}

	// Token: 0x14000011 RID: 17
	// (add) Token: 0x06001896 RID: 6294 RVA: 0x000106E9 File Offset: 0x0000E8E9
	// (remove) Token: 0x06001897 RID: 6295 RVA: 0x00010702 File Offset: 0x0000E902
	public event Action<float> CharacterLanded;

	// Token: 0x170005A5 RID: 1445
	// (get) Token: 0x06001898 RID: 6296 RVA: 0x0001071B File Offset: 0x0000E91B
	// (set) Token: 0x06001899 RID: 6297 RVA: 0x00010723 File Offset: 0x0000E923
	public bool IsJumpDisabled { get; set; }

	// Token: 0x170005A6 RID: 1446
	// (get) Token: 0x0600189A RID: 6298 RVA: 0x0001072C File Offset: 0x0000E92C
	public float PlayerHeight
	{
		get
		{
			return (!GameState.Current.PlayerData.Is(MoveStates.Ducked)) ? 2f : 1f;
		}
	}

	// Token: 0x170005A7 RID: 1447
	// (get) Token: 0x0600189B RID: 6299 RVA: 0x00010752 File Offset: 0x0000E952
	// (set) Token: 0x0600189C RID: 6300 RVA: 0x0001075A File Offset: 0x0000E95A
	public MovingPlatform Platform { get; set; }

	// Token: 0x170005A8 RID: 1448
	// (get) Token: 0x0600189D RID: 6301 RVA: 0x00010763 File Offset: 0x0000E963
	public Vector3 Velocity
	{
		get
		{
			return this._velocity;
		}
	}

	// Token: 0x170005A9 RID: 1449
	// (get) Token: 0x0600189E RID: 6302 RVA: 0x0001076B File Offset: 0x0000E96B
	// (set) Token: 0x0600189F RID: 6303 RVA: 0x00010773 File Offset: 0x0000E973
	public int WaterLevel { get; private set; }

	// Token: 0x170005AA RID: 1450
	// (get) Token: 0x060018A0 RID: 6304 RVA: 0x0001077C File Offset: 0x0000E97C
	// (set) Token: 0x060018A1 RID: 6305 RVA: 0x00010784 File Offset: 0x0000E984
	public bool IsGrounded { get; private set; }

	// Token: 0x170005AB RID: 1451
	// (get) Token: 0x060018A2 RID: 6306 RVA: 0x0001078D File Offset: 0x0000E98D
	public Bounds DebugEnvBounds
	{
		get
		{
			return this._currentEnviroment.EnviromentBounds;
		}
	}

	// Token: 0x060018A3 RID: 6307 RVA: 0x0001079A File Offset: 0x0000E99A
	public void Init()
	{
		if (LevelEnviroment.Instance != null)
		{
			this._currentEnviroment = LevelEnviroment.Instance.Settings;
		}
		else
		{
			Debug.LogWarning("You are trying to access the LevelEnvironment Instance that has not had Awake called.");
		}
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x000107CB File Offset: 0x0000E9CB
	public void Start()
	{
		this.Reset();
	}

	// Token: 0x060018A5 RID: 6309 RVA: 0x000107D3 File Offset: 0x0000E9D3
	public void UpdatePlayerMovement()
	{
		this.UpdateMovementStates();
		this.UpdateMovement();
	}

	// Token: 0x060018A6 RID: 6310 RVA: 0x000107E1 File Offset: 0x0000E9E1
	public void ResetDuckMode()
	{
		this._controller.height = 2f;
		this._controller.center = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x060018A7 RID: 6311 RVA: 0x00084108 File Offset: 0x00082308
	public static bool HasCollision(Vector3 pos, float height)
	{
		return Physics.CheckSphere(pos + Vector3.up * (height - 0.5f), 0.6f, UberstrikeLayerMasks.CrouchMask);
	}

	// Token: 0x060018A8 RID: 6312 RVA: 0x00084140 File Offset: 0x00082340
	public void ResetEnviroment()
	{
		this._currentEnviroment = LevelEnviroment.Instance.Settings;
		this._currentEnviroment.EnviromentBounds = default(Bounds);
		this._isOnLatter = false;
	}

	// Token: 0x060018A9 RID: 6313 RVA: 0x00010812 File Offset: 0x0000EA12
	public void SetEnviroment(EnviromentSettings settings, Bounds bounds)
	{
		this._currentEnviroment = settings;
		this._currentEnviroment.EnviromentBounds = new Bounds(bounds.center, bounds.size);
		this._isOnLatter = (this._currentEnviroment.Type == EnviromentSettings.TYPE.LATTER);
	}

	// Token: 0x060018AA RID: 6314 RVA: 0x00084178 File Offset: 0x00082378
	public float GetSpeedModifier()
	{
		float num = 0f;
		float num2 = (!Singleton<WeaponController>.Instance.IsSecondaryAction) ? 0f : 1.8f;
		float num3 = Singleton<PlayerDataManager>.Instance.GearWeight * 1.2f;
		float num4 = (!(GameState.Current.Player != null)) ? 0f : (GameState.Current.Player.DamageFactor * 7.6f);
		num += num2;
		num += num3;
		num += num4;
		if (this.WaterLevel > 0)
		{
			if (this.WaterLevel == 3)
			{
				num += 3.04f;
			}
			else
			{
				num += 1.52f;
			}
		}
		else if (this.IsGrounded && GameState.Current.PlayerData.Is(MoveStates.Ducked))
		{
			num += 1.748f;
		}
		return num;
	}

	// Token: 0x060018AB RID: 6315 RVA: 0x00084258 File Offset: 0x00082458
	private void UpdateMovementStates()
	{
		if (this._currentEnviroment.Type == EnviromentSettings.TYPE.LATTER && !this._currentEnviroment.EnviromentBounds.Intersects(this._controller.bounds))
		{
			this.ResetEnviroment();
		}
		if (this._currentEnviroment.Type == EnviromentSettings.TYPE.WATER)
		{
			this._currentEnviroment.CheckPlayerEnclosure(this.GetFeetPosition(), this.PlayerHeight, out this._waterEnclosure);
			int num = 1;
			if (this._waterEnclosure >= 0.8f)
			{
				num = 3;
			}
			else if (this._waterEnclosure >= 0.4f)
			{
				num = 2;
			}
			if (this.WaterLevel != num)
			{
				this.SetWaterlevel(num);
			}
		}
		else if (this.WaterLevel != 0)
		{
			this.SetWaterlevel(0);
		}
		if ((byte)(GameState.Current.PlayerData.KeyState & KeyState.Jump) == 0)
		{
			this._canJump = true;
		}
	}

	// Token: 0x060018AC RID: 6316 RVA: 0x0001084D File Offset: 0x0000EA4D
	private Vector3 GetFeetPosition()
	{
		return this._transform.position - new Vector3(0f, 1f, 0f);
	}

	// Token: 0x060018AD RID: 6317 RVA: 0x00084340 File Offset: 0x00082540
	public void ApplyForce(Vector3 v, CharacterMoveController.ForceType type)
	{
		if (this.useNewMethod)
		{
			this._externalForce = v * 0.035f * this.initialDamp;
		}
		else
		{
			this._externalForce = v * 0.035f;
		}
		this._externalForceType = type;
		this._hasExternalForce = true;
		this._externalForceTime = Time.realtimeSinceStartup + 4f;
	}

	// Token: 0x060018AE RID: 6318 RVA: 0x000843AC File Offset: 0x000825AC
	private void UpdateMovement()
	{
		this.CheckDuck();
		if (GameState.Current.PlayerData.Is(MoveStates.Flying))
		{
			this.FlyInAir();
		}
		else if (this.WaterLevel > 2)
		{
			this.MoveInWater();
		}
		else if (this._isOnLatter)
		{
			this.MoveOnLadder();
		}
		else if (this.IsGrounded)
		{
			this.MoveOnGround();
		}
		else if (this.WaterLevel == 2)
		{
			this.MoveOnWaterRim();
		}
		else
		{
			this.MoveInAir();
		}
		if (this._hasExternalForce)
		{
			if (this.useNewMethod)
			{
				if (this._externalForceType != CharacterMoveController.ForceType.None)
				{
					this._velocity = Vector3.zero;
					this._canJump = false;
					this._ungroundedCount = 6;
					GameState.Current.PlayerData.JumpingUpdate();
				}
				this._velocity += this._externalForce;
				this._externalForce *= this.dynamicDamp;
				this._hasExternalForce = (this._externalForce.sqrMagnitude > 0.01f);
				this._externalForceType = CharacterMoveController.ForceType.None;
			}
			else
			{
				CharacterMoveController.ForceType externalForceType = this._externalForceType;
				if (externalForceType != CharacterMoveController.ForceType.Additive)
				{
					if (externalForceType == CharacterMoveController.ForceType.Exclusive)
					{
						this._velocity = this._externalForce;
					}
				}
				else
				{
					this._velocity = Vector3.Scale(this._velocity, new Vector3(1f, 0.5f, 1f)) + this._externalForce;
				}
				this.Jump(this._velocity.y);
				this._externalForce = Vector2.zero;
				this._hasExternalForce = false;
			}
		}
		this._velocity[1] = Mathf.Clamp(this._velocity[1], -150f, 150f);
		this._collisionFlag = this._controller.Move(this._velocity * Time.fixedDeltaTime);
		this._velocity = this._controller.velocity;
		bool flag = (this._collisionFlag & CollisionFlags.Below) != CollisionFlags.None;
		if (flag)
		{
			this._externalForceTime = 0f;
		}
		if (this._externalForceTime < Time.realtimeSinceStartup)
		{
			Vector3 to = this.ClampHorizontally(this._velocity, 22.8f);
			this._velocity = Vector3.Lerp(this._velocity, to, Time.fixedDeltaTime * 3f);
		}
		GameState.Current.PlayerData.Velocity = this._velocity;
		if (flag)
		{
			if (this._ungroundedCount > 5 && this.CharacterLanded != null)
			{
				this.CharacterLanded(this._velocity.y);
				GameState.Current.PlayerData.LandingUpdate();
			}
			this._ungroundedCount = 0;
			this.IsGrounded = true;
		}
		else if (!this._canJump)
		{
			this._ungroundedCount++;
			this.IsGrounded = false;
		}
		else if (this._ungroundedCount > 5)
		{
			this.IsGrounded = false;
		}
		else
		{
			this._ungroundedCount++;
			this.IsGrounded = true;
		}
		GameState.Current.PlayerData.Set(MoveStates.Grounded, this.IsGrounded);
		if (this.IsGrounded)
		{
			GameState.Current.PlayerData.Set(MoveStates.Jumping, false);
		}
	}

	// Token: 0x060018AF RID: 6319 RVA: 0x00084708 File Offset: 0x00082908
	private Vector3 ClampHorizontally(Vector3 vector, float magnitudeMax)
	{
		float y = vector.y;
		vector.y = 0f;
		vector = vector.normalized * Mathf.Clamp(vector.magnitude, 0f, magnitudeMax);
		vector.y = y;
		return vector;
	}

	// Token: 0x060018B0 RID: 6320 RVA: 0x00084754 File Offset: 0x00082954
	private void OnInputChanged(GlobalEvents.InputChanged ev)
	{
		if (AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled && GameState.Current.Player != null && GameState.Current.Player.IsWalkingEnabled)
		{
			GameState.Current.PlayerData.Set(UserInput.GetkeyState(ev.Key), ev.IsDown);
		}
	}

	// Token: 0x060018B1 RID: 6321 RVA: 0x000847BC File Offset: 0x000829BC
	private void Reset()
	{
		this.SetWaterlevel(0);
		this._velocity = Vector3.zero;
		this._externalForceType = CharacterMoveController.ForceType.Additive;
		this._hasExternalForce = false;
		this._externalForce = Vector3.zero;
		this._canJump = true;
		this.IsGrounded = true;
		this._ungroundedCount = 0;
		this.Platform = null;
		this.IsJumpDisabled = false;
	}

	// Token: 0x060018B2 RID: 6322 RVA: 0x00084818 File Offset: 0x00082A18
	private void ApplyFriction()
	{
		Vector3 velocity = this._velocity;
		float magnitude = velocity.magnitude;
		if (magnitude == 0f)
		{
			return;
		}
		if (magnitude < 0.5f && this._acceleration.sqrMagnitude == 0f)
		{
			if (this._isOnLatter)
			{
				this._velocity[1] = 0f;
			}
			this._velocity[0] = 0f;
			this._velocity[2] = 0f;
		}
		else
		{
			float num = 0f;
			if (this.WaterLevel < 3)
			{
				if (this._isOnLatter || GameState.Current.PlayerData.Is(MoveStates.Grounded))
				{
					float num2 = Mathf.Max(this._currentEnviroment.StopSpeed, magnitude);
					num += num2 * this._currentEnviroment.GroundFriction;
				}
			}
			else if (this.WaterLevel > 0)
			{
				num += Mathf.Max(this._currentEnviroment.StopSpeed, magnitude) * this._currentEnviroment.WaterFriction * (float)this.WaterLevel / 3f;
			}
			if (GameState.Current.PlayerData.Is(MoveStates.Flying))
			{
				float num2 = Mathf.Max(this._currentEnviroment.StopSpeed, magnitude);
				num += num2 * this._currentEnviroment.FlyFriction;
			}
			num *= Time.deltaTime;
			float num3 = magnitude - num;
			if (num3 < 0f)
			{
				num3 = 0f;
			}
			num3 /= magnitude;
			this._velocity *= num3;
		}
	}

	// Token: 0x060018B3 RID: 6323 RVA: 0x000849AC File Offset: 0x00082BAC
	private void ApplyAcceleration(Vector3 wishdir, float wishspeed, float accel, bool clamp = false)
	{
		float num = Vector3.Dot(this._velocity, wishdir);
		float num2 = wishspeed - num;
		if (num2 <= 0f)
		{
			this._acceleration = Vector3.zero;
			return;
		}
		this._acceleration = accel * wishspeed * wishdir * Time.deltaTime;
		if (this.useNewMethod && this._hasExternalForce)
		{
			this._acceleration *= 0.1f;
		}
		Vector3 vector = this._velocity + this._acceleration;
		float magnitude = vector.magnitude;
		if (magnitude < wishspeed)
		{
			this._velocity += this._acceleration;
		}
		else if (clamp)
		{
			this._velocity = (this._velocity + this._acceleration).normalized * wishspeed;
			this._velocity[1] = vector[1];
		}
		else
		{
			this._velocity = (this._velocity + this._acceleration).normalized * magnitude;
		}
	}

	// Token: 0x060018B4 RID: 6324 RVA: 0x00084AD0 File Offset: 0x00082CD0
	private void CheckDuck()
	{
		if (this.WaterLevel < 3 && GameState.Current.PlayerData.Is(MoveStates.Grounded))
		{
			if (UserInput.IsPressed(KeyState.Crouch) && !GameState.Current.PlayerData.Is(MoveStates.Ducked))
			{
				GameState.Current.PlayerData.Set(MoveStates.Ducked, true);
				this._controller.height = 1f;
				this._controller.center = new Vector3(0f, -0.5f, 0f);
			}
			else if (!UserInput.IsPressed(KeyState.Crouch) && GameState.Current.PlayerData.Is(MoveStates.Ducked) && !CharacterMoveController.HasCollision(this.GetFeetPosition(), 2f))
			{
				GameState.Current.PlayerData.Set(MoveStates.Ducked, false);
				this._controller.height = 2f;
				this._controller.center = new Vector3(0f, 0f, 0f);
			}
		}
	}

	// Token: 0x060018B5 RID: 6325 RVA: 0x00010873 File Offset: 0x0000EA73
	private void Jump(float up)
	{
		this._canJump = false;
		this._ungroundedCount = 6;
		this._velocity.y = up;
		GameState.Current.PlayerData.JumpingUpdate();
	}

	// Token: 0x060018B6 RID: 6326 RVA: 0x00084BDC File Offset: 0x00082DDC
	private bool CheckJump()
	{
		if (this.IsJumpDisabled || GameState.Current.PlayerData.Is(MoveStates.Ducked) || (byte)(GameState.Current.PlayerData.KeyState & KeyState.Jump) == 0)
		{
			return false;
		}
		if (this._isOnLatter)
		{
			return true;
		}
		if (this._canJump)
		{
			this.Jump(15f);
			return true;
		}
		UserInput.HorizontalDirection.y = 0f;
		return false;
	}

	// Token: 0x060018B7 RID: 6327 RVA: 0x00084C58 File Offset: 0x00082E58
	private bool CheckWaterJump()
	{
		if ((byte)(GameState.Current.PlayerData.KeyState & KeyState.Jump) == 0 || (this._collisionFlag & CollisionFlags.Sides) == CollisionFlags.None)
		{
			return false;
		}
		if (!this._canJump)
		{
			UserInput.HorizontalDirection.y = 0f;
			return false;
		}
		this._velocity.y = 15f;
		return true;
	}

	// Token: 0x060018B8 RID: 6328 RVA: 0x00084CBC File Offset: 0x00082EBC
	private void FlyInAir()
	{
		this.ApplyFriction();
		Vector3 wishdir = Vector3.zero;
		if (UserInput.IsWalking)
		{
			wishdir = UserInput.Rotation * UserInput.HorizontalDirection;
		}
		if (UserInput.VerticalDirection.y != 0f)
		{
			wishdir.y = UserInput.VerticalDirection.y;
		}
		this.ApplyAcceleration(wishdir, 7.6f - this.GetSpeedModifier(), this._currentEnviroment.FlyAcceleration, false);
	}

	// Token: 0x060018B9 RID: 6329 RVA: 0x00084D34 File Offset: 0x00082F34
	private void MoveInWater()
	{
		this.ApplyFriction();
		Vector3 wishdir = Vector3.zero;
		if (UserInput.IsWalking)
		{
			wishdir = UserInput.Rotation * UserInput.HorizontalDirection;
		}
		if (UserInput.IsMovingVertically)
		{
			wishdir.y = UserInput.VerticalDirection.y;
		}
		this.ApplyAcceleration(wishdir, 7.6f - this.GetSpeedModifier(), this._currentEnviroment.WaterAcceleration, false);
		if (this._velocity[1] > -3f)
		{
			Vector3 ptr = _velocity;
			int index2;
			int index = index2 = 1;
			float num = ptr[index2];
			this._velocity[index] = num - this.Gravity * 0.1f;
		}
		else
		{
			this._velocity[1] = Mathf.Lerp(this._velocity[1], -3f, Time.deltaTime * 6f);
		}
	}

	// Token: 0x060018BA RID: 6330 RVA: 0x00084E10 File Offset: 0x00083010
	private void MoveOnLadder()
	{
		this.ApplyFriction();
		Vector3 wishdir = Vector3.zero;
		if (UserInput.IsWalking)
		{
			wishdir = UserInput.Rotation * UserInput.HorizontalDirection;
		}
		if (UserInput.IsMovingVertically)
		{
			wishdir.y = UserInput.VerticalDirection.y;
		}
		this.ApplyAcceleration(wishdir, 7.6f - this.GetSpeedModifier(), this._currentEnviroment.GroundAcceleration, false);
	}

	// Token: 0x060018BB RID: 6331 RVA: 0x00084E80 File Offset: 0x00083080
	private void MoveOnWaterRim()
	{
		this.ApplyFriction();
		Vector3 wishdir = Vector3.zero;
		if (UserInput.IsWalking)
		{
			wishdir = UserInput.Rotation * UserInput.HorizontalDirection;
		}
		if (UserInput.IsMovingDown)
		{
			wishdir.y = UserInput.VerticalDirection.y;
		}
		else if (UserInput.IsMovingUp && this._waterEnclosure > 0.8f)
		{
			wishdir.y = UserInput.VerticalDirection.y * 0.5f;
		}
		else
		{
			wishdir.y = 0f;
		}
		this.ApplyAcceleration(wishdir, 7.6f - this.GetSpeedModifier(), this._currentEnviroment.WaterAcceleration, true);
		if (this._waterEnclosure < 0.7f || !UserInput.IsMovingVertically)
		{
			if (this._velocity[1] > -3f)
			{
				Vector3 ptr = _velocity;
				int index2;
				int index = index2 = 1;
				float num = ptr[index2];
				this._velocity[index] = num - this.Gravity * 0.1f;
			}
			else
			{
				this._velocity[1] = Mathf.Lerp(this._velocity[1], -3f, Time.deltaTime * 6f);
			}
		}
		else if (this._velocity[1] > 0f && this._waterEnclosure < 0.8f)
		{
			this._velocity[1] = Mathf.Lerp(this._velocity[1], -1f, Time.deltaTime * 4f);
		}
		this.CheckWaterJump();
	}

	// Token: 0x060018BC RID: 6332 RVA: 0x0008501C File Offset: 0x0008321C
	private void MoveInAir()
	{
		this.ApplyFriction();
		Vector3 wishdir = UserInput.Rotation * UserInput.HorizontalDirection;
		wishdir[1] = 0f;
		this.ApplyAcceleration(wishdir, 7.6f - this.GetSpeedModifier(), this._currentEnviroment.AirAcceleration, false);
		Vector3 ptr = _velocity;
		int index2;
		int index = index2 = 1;
		float num = ptr[index2];
		this._velocity[index] = num - this.Gravity;
	}

	// Token: 0x060018BD RID: 6333 RVA: 0x0008508C File Offset: 0x0008328C
	private void MoveOnGround()
	{
		if (this.CheckJump())
		{
			if (this.WaterLevel > 1)
			{
				this.MoveInWater();
			}
			else
			{
				this.MoveInAir();
			}
			return;
		}
		this.ApplyFriction();
		Vector3 wishdir = GameState.Current.PlayerData.HorizontalRotation * UserInput.HorizontalDirection;
		wishdir[1] = 0f;
		if (wishdir.sqrMagnitude > 1f)
		{
			wishdir.Normalize();
		}
		this.ApplyAcceleration(wishdir, 7.6f - this.GetSpeedModifier(), this._currentEnviroment.GroundAcceleration, false);
		this._velocity[1] = -this.Gravity;
	}

	// Token: 0x060018BE RID: 6334 RVA: 0x0008513C File Offset: 0x0008333C
	private void SetWaterlevel(int level)
	{
		this.WaterLevel = level;
		GameState.Current.PlayerData.Set(MoveStates.Diving, level == 3);
		GameState.Current.PlayerData.Set(MoveStates.Swimming, level == 2);
		GameState.Current.PlayerData.Set(MoveStates.Wading, level == 1);
	}

	// Token: 0x170005AC RID: 1452
	// (get) Token: 0x060018BF RID: 6335 RVA: 0x0001089E File Offset: 0x0000EA9E
	private float Gravity
	{
		get
		{
			return ((!this.IsLowGravity) ? 1f : 0.4f) * this._currentEnviroment.Gravity * Time.deltaTime;
		}
	}

	// Token: 0x0400170F RID: 5903
	public const float HEIGHT_NORMAL = 2f;

	// Token: 0x04001710 RID: 5904
	public const float CENTER_OFFSET_NORMAL = 0f;

	// Token: 0x04001711 RID: 5905
	public const float HEIGHT_DUCKED = 1f;

	// Token: 0x04001712 RID: 5906
	public const float CENTER_OFFSET_DUCKED = -0.5f;

	// Token: 0x04001713 RID: 5907
	public const float POWERUP_HASTE_SCALE = 1.3f;

	// Token: 0x04001714 RID: 5908
	public const float PLAYER_WADE_SCALE = 0.2f;

	// Token: 0x04001715 RID: 5909
	public const float PLAYER_SWIM_SCALE = 0.4f;

	// Token: 0x04001716 RID: 5910
	public const float PLAYER_DUCK_SCALE = 0.23f;

	// Token: 0x04001717 RID: 5911
	public const float PLAYER_TERMINAL_GRAVITY = -100f;

	// Token: 0x04001718 RID: 5912
	public const float PLAYER_INITIAL_GRAVITY = -1f;

	// Token: 0x04001719 RID: 5913
	public const float PLAYER_ZOOM_SLOWDOWN = 1.8f;

	// Token: 0x0400171A RID: 5914
	public const float PLAYER_MIN_SCALE = 0.5f;

	// Token: 0x0400171B RID: 5915
	public const float JumpPadModifier = 0.035f;

	// Token: 0x0400171C RID: 5916
	public const float PlayerWalkSpeed = 7.6f;

	// Token: 0x0400171D RID: 5917
	public const float PlayerJumpSpeed = 15f;

	// Token: 0x0400171E RID: 5918
	public const float StrafeJumpMultiplier = 3f;

	// Token: 0x0400171F RID: 5919
	public bool IsLowGravity;

	// Token: 0x04001720 RID: 5920
	private readonly CharacterController _controller;

	// Token: 0x04001721 RID: 5921
	private readonly Transform _transform;

	// Token: 0x04001722 RID: 5922
	private EnviromentSettings _currentEnviroment;

	// Token: 0x04001723 RID: 5923
	private CollisionFlags _collisionFlag;

	// Token: 0x04001724 RID: 5924
	private Vector3 _acceleration;

	// Token: 0x04001725 RID: 5925
	public Vector3 _velocity;

	// Token: 0x04001726 RID: 5926
	private bool _isOnLatter;

	// Token: 0x04001727 RID: 5927
	private bool _canJump = true;

	// Token: 0x04001728 RID: 5928
	private int _ungroundedCount;

	// Token: 0x04001729 RID: 5929
	private float _waterEnclosure;

	// Token: 0x0400172A RID: 5930
	private CharacterMoveController.ForceType _externalForceType = CharacterMoveController.ForceType.Additive;

	// Token: 0x0400172B RID: 5931
	private Vector3 _externalForce;

	// Token: 0x0400172C RID: 5932
	private float _externalForceTime;

	// Token: 0x0400172D RID: 5933
	private bool _hasExternalForce;

	// Token: 0x0400172E RID: 5934
	private bool useNewMethod;

	// Token: 0x0400172F RID: 5935
	private float initialDamp = 0.035f;

	// Token: 0x04001730 RID: 5936
	private float dynamicDamp = 0.976f;

	// Token: 0x0200036C RID: 876
	public enum ForceType
	{
		// Token: 0x04001737 RID: 5943
		None,
		// Token: 0x04001738 RID: 5944
		Additive,
		// Token: 0x04001739 RID: 5945
		Exclusive
	}
}
