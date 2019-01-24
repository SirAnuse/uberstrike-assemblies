using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000002 RID: 2
[RequireComponent(typeof(Animator))]
public class AvatarAnimationController : MonoBehaviour
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000002 RID: 2 RVA: 0x000020DF File Offset: 0x000002DF
	// (set) Token: 0x06000003 RID: 3 RVA: 0x000020E7 File Offset: 0x000002E7
	public Animator Animator { get; private set; }

	// Token: 0x06000004 RID: 4 RVA: 0x000020F0 File Offset: 0x000002F0
	private void Awake()
	{
		this.Animator = base.GetComponent<Animator>();
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00015514 File Offset: 0x00013714
	private void OnEnable()
	{
		this._AnchorChest = base.transform.Find("Hips/Spine/Chest/Anchor_Chest");
		this._IKAnchor = base.transform.Find("IK_Anchor");
		if (this._IKAnchor)
		{
			this._IKRightHand = this._IKAnchor.transform.Find("IK_Hand_R");
			this._IKLeftHand = this._IKAnchor.transform.Find("IK_Hand_R/IK_Hand_L");
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000020FE File Offset: 0x000002FE
	public void SetCharacter(ICharacterState state)
	{
		this.state = state;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002107 File Offset: 0x00000307
	public void Jump()
	{
		this.jumpTrigger = true;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002110 File Offset: 0x00000310
	public void Shoot()
	{
		this.shootTrigger = true;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002119 File Offset: 0x00000319
	public bool IsLayerEnabled(AvatarAnimationController.AnimationLayer layer)
	{
		return (this.animationLayerMask & 1 << (int)layer) != 0;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000212E File Offset: 0x0000032E
	public void EnableLayer(AvatarAnimationController.AnimationLayer layer, bool enable)
	{
		if (enable)
		{
			this.animationLayerMask |= 1 << (int)layer;
		}
		else
		{
			this.animationLayerMask &= ~(1 << (int)layer);
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00015594 File Offset: 0x00013794
	private void Update()
	{
		this.Animator.SetInteger(AvatarAnimationController.ControlFields.GearType, this.gearTrigger);
		if (this.state != null)
		{
			float value = Vector3.Magnitude(new Vector3(this.state.Velocity.x, 0f, this.state.Velocity.z));
			bool value2 = false;
			bool value3 = false;
			if (Mathf.DeltaAngle(this.state.HorizontalRotation.eulerAngles.y, this.turnAround) > 45f)
			{
				value2 = true;
				this.turnAround = this.state.HorizontalRotation.eulerAngles.y;
			}
			else if (Mathf.DeltaAngle(this.state.HorizontalRotation.eulerAngles.y, this.turnAround) < -45f)
			{
				value3 = true;
				this.turnAround = this.state.HorizontalRotation.eulerAngles.y;
			}
			Vector3 vector = Quaternion.Inverse(this.state.HorizontalRotation) * this.state.Velocity;
			if (this.state.KeyState != KeyState.Still)
			{
				Vector3 zero = Vector3.zero;
				float value4 = 0f;
				if ((byte)(this.state.KeyState & KeyState.Forward) != 0)
				{
					zero.z += 1f;
				}
				if ((byte)(this.state.KeyState & KeyState.Backward) != 0)
				{
					zero.z -= 1f;
				}
				if ((byte)(this.state.KeyState & KeyState.Left) != 0)
				{
					zero.x += 1f;
				}
				if ((byte)(this.state.KeyState & KeyState.Right) != 0)
				{
					zero.x -= 1f;
				}
				zero.Normalize();
				if (zero.magnitude > 0f)
				{
					value4 = Quaternion.LookRotation(zero).eulerAngles.y;
				}
				this.Animator.SetFloat(AvatarAnimationController.ControlFields.Direction, value4, 0.2f, Time.fixedDeltaTime);
			}
			this.Animator.SetFloat(AvatarAnimationController.ControlFields.WalkingSpeed, value);
			this.Animator.SetFloat(AvatarAnimationController.ControlFields.SpeedZ, vector.z);
			this.Animator.SetFloat(AvatarAnimationController.ControlFields.SpeedX, vector.x);
			this.Animator.SetFloat(AvatarAnimationController.ControlFields.TurnAround, this.turnAround);
			this.Animator.SetBool(AvatarAnimationController.ControlFields.IsShooting, this.state.Player.IsFiring || this.shootTrigger);
			this.Animator.SetBool(AvatarAnimationController.ControlFields.IsGrounded, (byte)(this.state.MovementState & MoveStates.Grounded) != 0);
			this.Animator.SetBool(AvatarAnimationController.ControlFields.IsJumping, this.jumpTrigger);
			this.Animator.SetBool(AvatarAnimationController.ControlFields.IsPaused, this.state.Player.Is(PlayerStates.Paused));
			this.Animator.SetBool(AvatarAnimationController.ControlFields.IsSquatting, this.state.Is(MoveStates.Ducked));
			this.Animator.SetBool(AvatarAnimationController.ControlFields.IsWalking, (byte)(this.state.KeyState & KeyState.Walking) != 0);
			this.Animator.SetBool(AvatarAnimationController.ControlFields.IsSwimming, (byte)(this.state.MovementState & (MoveStates.Swimming | MoveStates.Diving)) != 0);
			this.Animator.SetBool(AvatarAnimationController.ControlFields.IsTurningLeft, value2);
			this.Animator.SetBool(AvatarAnimationController.ControlFields.IsTurningRight, value3);
			float num = this.state.VerticalRotation;
			if (num > 180f)
			{
				num -= 360f;
			}
			num = Mathf.Clamp(num, -70f, 70f);
			Vector3 localEulerAngles = this._IKAnchor.transform.localEulerAngles;
			localEulerAngles.x = num;
			this._IKAnchor.transform.localEulerAngles = localEulerAngles;
		}
		this.EnableLayer(AvatarAnimationController.AnimationLayer.Shop, !GameState.Current.IsMultiplayer);
		if (!GameState.Current.IsMultiplayer && !this.Animator.GetCurrentAnimatorStateInfo(2).IsTag("ShopIdle"))
		{
			this.EnableLayer(AvatarAnimationController.AnimationLayer.Weapons, false);
		}
		else
		{
			this.EnableLayer(AvatarAnimationController.AnimationLayer.Weapons, true);
		}
		this.UpdateLayerWeight(AvatarAnimationController.AnimationLayer.Weapons, true);
		this.UpdateLayerWeight(AvatarAnimationController.AnimationLayer.Shop, false);
		this.shootTrigger = false;
		this.jumpTrigger = false;
		this.gearTrigger = 0;
		this.Animator.SetBool(AvatarAnimationController.ControlFields.WeaponSwitch, this.weaponSwitch);
		if (this.weaponSwitch)
		{
			this.weaponSwitch = false;
		}
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00015A44 File Offset: 0x00013C44
	private void OnAnimatorIK()
	{
		if (this._AnchorChest && this._IKAnchor)
		{
			this._IKAnchor.transform.position = this._AnchorChest.transform.position;
		}
		if (this._IKLeftHand && this._IKRightHand)
		{
			bool flag = this.Animator.GetCurrentAnimatorStateInfo(1).IsTag("IK");
			bool flag2 = this.Animator.GetCurrentAnimatorStateInfo(1).IsTag("Melee");
			bool flag3 = this.IsLayerEnabled(AvatarAnimationController.AnimationLayer.Weapons);
			float layerWeight = this.Animator.GetLayerWeight(1);
			if (flag3 && (flag || flag2))
			{
				this._LookAtWeight = Mathf.Lerp(this._LookAtWeight, 1f, Time.deltaTime * 10f);
			}
			else
			{
				this._LookAtWeight = Mathf.Lerp(this._LookAtWeight, 0f, Time.deltaTime * 15f);
			}
			Vector3 position = this._IKLeftHand.transform.position;
			position.y += 0.2f;
			this.Animator.SetLookAtPosition(position);
			this.Animator.SetLookAtWeight(layerWeight * this._LookAtWeight);
			if (flag3 && flag)
			{
				this._IKWeight = Mathf.Lerp(this._IKWeight, 1f, Time.deltaTime * 10f);
			}
			else
			{
				this._IKWeight = Mathf.Lerp(this._IKWeight, 0f, Time.deltaTime * 15f);
			}
			float weight = layerWeight * this._IKWeight;
			this.SetIK(AvatarIKGoal.LeftHand, this._IKLeftHand.transform, weight);
			this.SetIK(AvatarIKGoal.RightHand, this._IKRightHand.transform, weight);
		}
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002168 File Offset: 0x00000368
	private void SetIK(AvatarIKGoal goal, Transform goalTransform, float weight)
	{
		this.Animator.SetIKPositionWeight(goal, weight);
		this.Animator.SetIKRotationWeight(goal, weight);
		this.Animator.SetIKPosition(goal, goalTransform.position);
		this.Animator.SetIKRotation(goal, goalTransform.rotation);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00015C20 File Offset: 0x00013E20
	private void UpdateLayerWeight(AvatarAnimationController.AnimationLayer layer, bool smooth = false)
	{
		float num = (float)((!this.IsLayerEnabled(layer)) ? 0 : 1);
		if (smooth)
		{
			float weight = Mathf.Lerp(this.Animator.GetLayerWeight((int)layer), num, Time.deltaTime * 7.5f);
			this.Animator.SetLayerWeight((int)layer, weight);
		}
		else
		{
			this.Animator.SetLayerWeight((int)layer, num);
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00015C88 File Offset: 0x00013E88
	public void TriggerGearAnimation(UberstrikeItemClass itemClass)
	{
		this.ChangeWeaponType((UberstrikeItemClass)0);
		switch (itemClass)
		{
		case UberstrikeItemClass.GearBoots:
			this.gearTrigger = 5;
			break;
		case UberstrikeItemClass.GearHead:
		case UberstrikeItemClass.GearFace:
			this.gearTrigger = 1;
			break;
		case UberstrikeItemClass.GearUpperBody:
		case UberstrikeItemClass.GearHolo:
			this.gearTrigger = 3;
			break;
		case UberstrikeItemClass.GearLowerBody:
			this.gearTrigger = 4;
			break;
		case UberstrikeItemClass.GearGloves:
			this.gearTrigger = 2;
			break;
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00015D18 File Offset: 0x00013F18
	public void ChangeWeaponType(UberstrikeItemClass itemClass)
	{
		if (this.Animator != null)
		{
			this.weaponSwitch = true;
			switch (itemClass)
			{
			case UberstrikeItemClass.WeaponMelee:
				this.Animator.SetInteger(AvatarAnimationController.ControlFields.WeaponClass, 1);
				return;
			case UberstrikeItemClass.WeaponMachinegun:
			case UberstrikeItemClass.WeaponCannon:
			case UberstrikeItemClass.WeaponSplattergun:
			case UberstrikeItemClass.WeaponLauncher:
				this.Animator.SetInteger(AvatarAnimationController.ControlFields.WeaponClass, 3);
				return;
			case UberstrikeItemClass.WeaponShotgun:
				this.Animator.SetInteger(AvatarAnimationController.ControlFields.WeaponClass, 4);
				return;
			case UberstrikeItemClass.WeaponSniperRifle:
				this.Animator.SetInteger(AvatarAnimationController.ControlFields.WeaponClass, 2);
				return;
			}
			this.Animator.SetInteger(AvatarAnimationController.ControlFields.WeaponClass, 0);
		}
	}

	// Token: 0x04000001 RID: 1
	private const float IK_FADE_IN_SPEED = 10f;

	// Token: 0x04000002 RID: 2
	private const float IK_FADE_OUT_SPEED = 15f;

	// Token: 0x04000003 RID: 3
	private const int TURN_THRESHOLD = 45;

	// Token: 0x04000004 RID: 4
	private Transform _AnchorChest;

	// Token: 0x04000005 RID: 5
	private Transform _IKAnchor;

	// Token: 0x04000006 RID: 6
	private Transform _IKLeftHand;

	// Token: 0x04000007 RID: 7
	private Transform _IKRightHand;

	// Token: 0x04000008 RID: 8
	private float _IKWeight;

	// Token: 0x04000009 RID: 9
	private float _LookAtWeight;

	// Token: 0x0400000A RID: 10
	private ICharacterState state;

	// Token: 0x0400000B RID: 11
	private int gearTrigger;

	// Token: 0x0400000C RID: 12
	private bool jumpTrigger;

	// Token: 0x0400000D RID: 13
	private bool shootTrigger;

	// Token: 0x0400000E RID: 14
	private bool weaponSwitch;

	// Token: 0x0400000F RID: 15
	private float nextRandomUpdate;

	// Token: 0x04000010 RID: 16
	private float turnAround;

	// Token: 0x04000011 RID: 17
	private int animationLayerMask = 6;

	// Token: 0x02000003 RID: 3
	public enum AnimationLayer
	{
		// Token: 0x04000014 RID: 20
		Base,
		// Token: 0x04000015 RID: 21
		Weapons,
		// Token: 0x04000016 RID: 22
		Shop,
		// Token: 0x04000017 RID: 23
		Dance
	}

	// Token: 0x02000004 RID: 4
	private class ControlFields
	{
		// Token: 0x04000018 RID: 24
		public static readonly int SpeedZ = Animator.StringToHash("SpeedZ");

		// Token: 0x04000019 RID: 25
		public static readonly int SpeedX = Animator.StringToHash("SpeedX");

		// Token: 0x0400001A RID: 26
		public static readonly int IsSquatting = Animator.StringToHash("IsSquatting");

		// Token: 0x0400001B RID: 27
		public static readonly int IsPaused = Animator.StringToHash("IsPaused");

		// Token: 0x0400001C RID: 28
		public static readonly int WalkingSpeed = Animator.StringToHash("WalkingSpeed");

		// Token: 0x0400001D RID: 29
		public static readonly int TurnAround = Animator.StringToHash("TurnAround");

		// Token: 0x0400001E RID: 30
		public static readonly int IsSwimming = Animator.StringToHash("IsSwimming");

		// Token: 0x0400001F RID: 31
		public static readonly int IsWalking = Animator.StringToHash("IsWalking");

		// Token: 0x04000020 RID: 32
		public static readonly int IsJumping = Animator.StringToHash("IsJumping");

		// Token: 0x04000021 RID: 33
		public static readonly int IsGrounded = Animator.StringToHash("IsGrounded");

		// Token: 0x04000022 RID: 34
		public static readonly int Direction = Animator.StringToHash("Direction");

		// Token: 0x04000023 RID: 35
		public static readonly int IsShooting = Animator.StringToHash("IsShooting");

		// Token: 0x04000024 RID: 36
		public static readonly int WeaponClass = Animator.StringToHash("WeaponClass");

		// Token: 0x04000025 RID: 37
		public static readonly int WeaponSwitch = Animator.StringToHash("WeaponSwitch");

		// Token: 0x04000026 RID: 38
		public static readonly int IsTurningLeft = Animator.StringToHash("IsTurningLeft");

		// Token: 0x04000027 RID: 39
		public static readonly int IsTurningRight = Animator.StringToHash("IsTurningRight");

		// Token: 0x04000028 RID: 40
		public static readonly int Random = Animator.StringToHash("Random");

		// Token: 0x04000029 RID: 41
		public static readonly int GearType = Animator.StringToHash("GearType");

		// Token: 0x0400002A RID: 42
		public static readonly int IsDance = Animator.StringToHash("IsDance");
	}

	// Token: 0x02000005 RID: 5
	private class AnimationStates
	{
		// Token: 0x0400002B RID: 43
		public static readonly int Shooting = Animator.StringToHash("Weapons.Shooting");

		// Token: 0x0400002C RID: 44
		public static readonly int Jump = Animator.StringToHash("Base.Jumping.Jump");

		// Token: 0x0400002D RID: 45
		public static readonly int Idle = Animator.StringToHash("Base.Idle");
	}
}
