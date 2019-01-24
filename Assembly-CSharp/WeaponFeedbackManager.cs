using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000456 RID: 1110
public class WeaponFeedbackManager : MonoBehaviour
{
	// Token: 0x170006C2 RID: 1730
	// (get) Token: 0x06001FAF RID: 8111 RVA: 0x00014D86 File Offset: 0x00012F86
	// (set) Token: 0x06001FB0 RID: 8112 RVA: 0x00014D8D File Offset: 0x00012F8D
	public static WeaponFeedbackManager Instance { get; private set; }

	// Token: 0x06001FB1 RID: 8113 RVA: 0x00014D95 File Offset: 0x00012F95
	private void Awake()
	{
		WeaponFeedbackManager.Instance = this;
		this._bobManager = new WeaponFeedbackManager.WeaponBobManager();
	}

	// Token: 0x06001FB2 RID: 8114 RVA: 0x00014DA8 File Offset: 0x00012FA8
	private void OnEnable()
	{
		this._dip.Reset();
		this._fire.Reset();
		this.CurrentWeaponMode = WeaponFeedbackManager.WeaponMode.PutDown;
	}

	// Token: 0x06001FB3 RID: 8115 RVA: 0x00014DC7 File Offset: 0x00012FC7
	private void Update()
	{
		if (this._putDownWeaponState != null)
		{
			this._putDownWeaponState.Update();
		}
		if (this._pickupWeaponState != null)
		{
			this._pickupWeaponState.Update();
		}
	}

	// Token: 0x06001FB4 RID: 8116 RVA: 0x0009802C File Offset: 0x0009622C
	private Quaternion CalculateBobDip()
	{
		if (this._dip.time <= this._dip.Duration)
		{
			this._dip.HandleFeedback();
		}
		else if (this._needLerp)
		{
			this._angleX = Mathf.Lerp(this._angleX, 0f, Time.deltaTime * 9f);
			this._angleY = Mathf.Lerp(this._angleY, 0f, Time.deltaTime * 9f);
			if (this._angleX < 0.01f && this._angleY < 0.01f)
			{
				this._time = 0f;
				this._needLerp = false;
			}
		}
		else
		{
			float num = Mathf.Sin(this._bobManager.Data.Frequency * this._time);
			this._angleX = Mathf.Abs(this._bobManager.Data.XAmplitude * num);
			this._angleY = this._bobManager.Data.YAmplitude * num * this._sign;
			this._time += Time.deltaTime;
		}
		return Quaternion.Euler(this._angleX, this._angleY, 0f);
	}

	// Token: 0x06001FB5 RID: 8117 RVA: 0x00098174 File Offset: 0x00096374
	public static void SetBobMode(LevelCamera.BobMode mode)
	{
		if (WeaponFeedbackManager.Instance && WeaponFeedbackManager.Instance._bobManager.Mode != mode)
		{
			WeaponFeedbackManager.Instance._bobManager.Mode = mode;
			if (mode == LevelCamera.BobMode.Run)
			{
				WeaponFeedbackManager.Instance._needLerp = false;
				WeaponFeedbackManager.Instance._sign = (float)((!AutoMonoBehaviour<InputManager>.Instance.IsDown(GameInputKey.Right)) ? 1 : -1);
				WeaponFeedbackManager.Instance._time = Mathf.Asin(WeaponFeedbackManager.Instance._angleX / WeaponFeedbackManager.Instance._bobManager.Data.XAmplitude) / WeaponFeedbackManager.Instance._bobManager.Data.Frequency;
			}
			else
			{
				WeaponFeedbackManager.Instance._needLerp = true;
			}
		}
	}

	// Token: 0x170006C3 RID: 1731
	// (get) Token: 0x06001FB6 RID: 8118 RVA: 0x00014DF5 File Offset: 0x00012FF5
	public static bool IsBobbing
	{
		get
		{
			return WeaponFeedbackManager.Instance && WeaponFeedbackManager.Instance._bobManager.Mode != LevelCamera.BobMode.None;
		}
	}

	// Token: 0x06001FB7 RID: 8119 RVA: 0x00098244 File Offset: 0x00096444
	public void LandingDip()
	{
		if (this._fire.time > 0f && this._fire.time < this._fire.Duration)
		{
			return;
		}
		if (this.CurrentWeaponMode != WeaponFeedbackManager.WeaponMode.PutDown)
		{
			this._dip.time = 0f;
			this._dip.angle = this.WeaponDip.angle;
			this._dip.noise = this.WeaponDip.noise;
			this._dip.strength = this.WeaponDip.strength;
			this._dip.timeToPeak = this.WeaponDip.timeToPeak;
			this._dip.timeToEnd = this.WeaponDip.timeToEnd;
			this._dip.direction = Vector3.down;
			this._dip.rotationAxis = Vector3.right;
		}
	}

	// Token: 0x06001FB8 RID: 8120 RVA: 0x0009832C File Offset: 0x0009652C
	public void Fire()
	{
		if (this.CurrentWeaponMode != WeaponFeedbackManager.WeaponMode.PutDown)
		{
			this._fire.noise = this.WeaponFire.noise;
			this._fire.strength = this.WeaponFire.strength;
			this._fire.timeToPeak = this.WeaponFire.timeToPeak;
			this._fire.timeToEnd = this.WeaponFire.timeToEnd;
			this._fire.direction = Vector3.back;
			this._fire.rotationAxis = Vector3.left;
			this._fire.recoilTime = this.WeaponFire.recoilTime;
			if (this._dip.time < this._dip.Duration)
			{
				this._dip.Reset();
			}
			if (this._fire.time > this._fire.recoilTime && this._fire.time < this._fire.Duration)
			{
				this._fire.time = this.WeaponFire.timeToPeak / 3f;
				this._fire.angle = this.WeaponFire.angle / 3f;
			}
			else if (this._fire.time >= this._fire.Duration)
			{
				this._fire.time = 0f;
				this._fire.angle = this.WeaponFire.angle;
			}
		}
	}

	// Token: 0x06001FB9 RID: 8121 RVA: 0x000984B0 File Offset: 0x000966B0
	public void PutDown(bool destroy = false)
	{
		if (this._pickupWeaponState != null && this._pickupWeaponState.IsValid)
		{
			this.PutDownWeapon(this._pickupWeaponState.Weapon, this._pickupWeaponState.Decorator, destroy);
			this._pickupWeaponState = null;
		}
	}

	// Token: 0x06001FBA RID: 8122 RVA: 0x000984FC File Offset: 0x000966FC
	public void PickUp(WeaponSlot slot)
	{
		if (this._pickupWeaponState != null && this._pickupWeaponState.IsValid)
		{
			if (this._pickupWeaponState.Weapon == slot.Logic)
			{
				return;
			}
			this.PutDownWeapon(this._pickupWeaponState.Weapon, this._pickupWeaponState.Decorator, false);
		}
		else if (this._pickupWeaponState == null && this._putDownWeaponState != null && this._putDownWeaponState.Weapon == slot.Logic)
		{
			this._putDownWeaponState.Finish();
		}
		this._pickupWeaponState = new WeaponFeedbackManager.PickUpState(slot.Logic, slot.Decorator);
		this.WeaponFire.recoilTime = WeaponConfigurationHelper.GetRateOfFire(slot.View);
		this.WeaponFire.strength = WeaponConfigurationHelper.GetRecoilMovement(slot.View);
		this.WeaponFire.angle = WeaponConfigurationHelper.GetRecoilKickback(slot.View);
	}

	// Token: 0x06001FBB RID: 8123 RVA: 0x00014E21 File Offset: 0x00013021
	public void BeginIronSight()
	{
		if (!this._isIronSight)
		{
			this.IsIronSighted = true;
		}
	}

	// Token: 0x06001FBC RID: 8124 RVA: 0x00014E35 File Offset: 0x00013035
	public void EndIronSight()
	{
		this.IsIronSighted = false;
	}

	// Token: 0x06001FBD RID: 8125 RVA: 0x00014E3E File Offset: 0x0001303E
	public void ResetIronSight()
	{
		this.IsIronSighted = false;
		if (this._pickupWeaponState != null)
		{
			this._pickupWeaponState.Reset();
		}
		if (this._putDownWeaponState != null)
		{
			this._putDownWeaponState.Reset();
		}
	}

	// Token: 0x170006C4 RID: 1732
	// (get) Token: 0x06001FBE RID: 8126 RVA: 0x00014E73 File Offset: 0x00013073
	// (set) Token: 0x06001FBF RID: 8127 RVA: 0x00014E7B File Offset: 0x0001307B
	public bool IsIronSighted
	{
		get
		{
			return this._isIronSight;
		}
		private set
		{
			this._isIronSight = value;
			GameState.Current.PlayerData.IsIronSighted.Value = value;
		}
	}

	// Token: 0x06001FC0 RID: 8128 RVA: 0x00014E99 File Offset: 0x00013099
	private void PutDownWeapon(BaseWeaponLogic weapon, BaseWeaponDecorator decorator, bool destroy = false)
	{
		if (this._putDownWeaponState != null)
		{
			this._putDownWeaponState.Finish();
		}
		this._putDownWeaponState = new WeaponFeedbackManager.PutDownState(weapon, decorator, destroy);
	}

	// Token: 0x170006C5 RID: 1733
	// (get) Token: 0x06001FC1 RID: 8129 RVA: 0x00014EBF File Offset: 0x000130BF
	// (set) Token: 0x06001FC2 RID: 8130 RVA: 0x00014EC7 File Offset: 0x000130C7
	public WeaponFeedbackManager.WeaponMode CurrentWeaponMode
	{
		get
		{
			return this._currentWeaponMode;
		}
		private set
		{
			this._currentWeaponMode = value;
		}
	}

	// Token: 0x06001FC3 RID: 8131 RVA: 0x000985F4 File Offset: 0x000967F4
	public void SetFireFeedback(WeaponFeedbackManager.FeedbackData data)
	{
		this.WeaponFire.angle = data.angle;
		this.WeaponFire.noise = data.noise;
		this.WeaponFire.strength = data.strength;
		this.WeaponFire.timeToEnd = data.timeToEnd;
		this.WeaponFire.timeToPeak = data.timeToPeak;
		this.WeaponFire.recoilTime = data.recoilTime;
	}

	// Token: 0x170006C6 RID: 1734
	// (get) Token: 0x06001FC4 RID: 8132 RVA: 0x00014ED0 File Offset: 0x000130D0
	public bool _isWeaponInIronSightPosition
	{
		get
		{
			return this._isIronSight && this._isIronSightPosDone;
		}
	}

	// Token: 0x04001AEB RID: 6891
	private WeaponFeedbackManager.WeaponMode _currentWeaponMode;

	// Token: 0x04001AEC RID: 6892
	private WeaponFeedbackManager.WeaponState _pickupWeaponState;

	// Token: 0x04001AED RID: 6893
	private WeaponFeedbackManager.WeaponState _putDownWeaponState;

	// Token: 0x04001AEE RID: 6894
	private WeaponFeedbackManager.WeaponBobManager _bobManager;

	// Token: 0x04001AEF RID: 6895
	public WeaponFeedbackManager.FeedbackData WeaponDip;

	// Token: 0x04001AF0 RID: 6896
	public WeaponFeedbackManager.FeedbackData WeaponFire;

	// Token: 0x04001AF1 RID: 6897
	protected WeaponFeedbackManager.Feedback _fire;

	// Token: 0x04001AF2 RID: 6898
	protected WeaponFeedbackManager.Feedback _dip;

	// Token: 0x04001AF3 RID: 6899
	private bool _needLerp;

	// Token: 0x04001AF4 RID: 6900
	public WeaponFeedbackManager.WeaponAnimData WeaponAnimation;

	// Token: 0x04001AF5 RID: 6901
	private float _angleY;

	// Token: 0x04001AF6 RID: 6902
	private float _angleX;

	// Token: 0x04001AF7 RID: 6903
	private float _time;

	// Token: 0x04001AF8 RID: 6904
	private float _sign;

	// Token: 0x04001AF9 RID: 6905
	[SerializeField]
	private Transform _pivotPoint;

	// Token: 0x04001AFA RID: 6906
	private bool _isIronSight;

	// Token: 0x04001AFB RID: 6907
	private bool _isIronSightPosDone;

	// Token: 0x02000457 RID: 1111
	private class WeaponBobManager
	{
		// Token: 0x06001FC5 RID: 8133 RVA: 0x00098668 File Offset: 0x00096868
		public WeaponBobManager()
		{
			this._bobData = new Dictionary<LevelCamera.BobMode, WeaponFeedbackManager.WeaponBobManager.BobData>();
			foreach (object obj in Enum.GetValues(typeof(LevelCamera.BobMode)))
			{
				LevelCamera.BobMode key = (LevelCamera.BobMode)((int)obj);
				switch (key)
				{
				case LevelCamera.BobMode.Walk:
					this._bobData[key] = new WeaponFeedbackManager.WeaponBobManager.BobData(0.5f, 3f, 6f);
					continue;
				case LevelCamera.BobMode.Run:
					this._bobData[key] = new WeaponFeedbackManager.WeaponBobManager.BobData(1f, 3f, 8f);
					continue;
				case LevelCamera.BobMode.Crouch:
					this._bobData[key] = new WeaponFeedbackManager.WeaponBobManager.BobData(0.5f, 3f, 12f);
					continue;
				}
				this._bobData[key] = new WeaponFeedbackManager.WeaponBobManager.BobData(0f, 0f, 0f);
			}
			this._data = this._bobData[LevelCamera.BobMode.Idle];
		}

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06001FC6 RID: 8134 RVA: 0x00014EE6 File Offset: 0x000130E6
		public WeaponFeedbackManager.WeaponBobManager.BobData Data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06001FC7 RID: 8135 RVA: 0x00014EEE File Offset: 0x000130EE
		// (set) Token: 0x06001FC8 RID: 8136 RVA: 0x00014EF6 File Offset: 0x000130F6
		public LevelCamera.BobMode Mode
		{
			get
			{
				return this._bobMode;
			}
			set
			{
				if (this._bobMode != value)
				{
					this._bobMode = value;
					this._data = this._bobData[value];
				}
			}
		}

		// Token: 0x04001AFD RID: 6909
		private readonly Dictionary<LevelCamera.BobMode, WeaponFeedbackManager.WeaponBobManager.BobData> _bobData;

		// Token: 0x04001AFE RID: 6910
		private LevelCamera.BobMode _bobMode;

		// Token: 0x04001AFF RID: 6911
		private WeaponFeedbackManager.WeaponBobManager.BobData _data;

		// Token: 0x02000458 RID: 1112
		public struct BobData
		{
			// Token: 0x06001FC9 RID: 8137 RVA: 0x00014F1D File Offset: 0x0001311D
			public BobData(float xamp, float yamp, float freq)
			{
				this._xAmplitude = xamp;
				this._yAmplitude = yamp;
				this._frequency = freq;
			}

			// Token: 0x170006C9 RID: 1737
			// (get) Token: 0x06001FCA RID: 8138 RVA: 0x00014F34 File Offset: 0x00013134
			public float XAmplitude
			{
				get
				{
					return this._xAmplitude;
				}
			}

			// Token: 0x170006CA RID: 1738
			// (get) Token: 0x06001FCB RID: 8139 RVA: 0x00014F3C File Offset: 0x0001313C
			public float YAmplitude
			{
				get
				{
					return this._yAmplitude;
				}
			}

			// Token: 0x170006CB RID: 1739
			// (get) Token: 0x06001FCC RID: 8140 RVA: 0x00014F44 File Offset: 0x00013144
			public float Frequency
			{
				get
				{
					return this._frequency;
				}
			}

			// Token: 0x04001B00 RID: 6912
			private float _xAmplitude;

			// Token: 0x04001B01 RID: 6913
			private float _yAmplitude;

			// Token: 0x04001B02 RID: 6914
			private float _frequency;
		}
	}

	// Token: 0x02000459 RID: 1113
	public enum WeaponMode
	{
		// Token: 0x04001B04 RID: 6916
		Primary,
		// Token: 0x04001B05 RID: 6917
		Second,
		// Token: 0x04001B06 RID: 6918
		PutDown
	}

	// Token: 0x0200045A RID: 1114
	private abstract class WeaponState
	{
		// Token: 0x06001FCD RID: 8141 RVA: 0x00014F4C File Offset: 0x0001314C
		protected WeaponState(BaseWeaponLogic weapon, BaseWeaponDecorator decorator)
		{
			this._time = 0f;
			this._weapon = weapon;
			this._decorator = decorator;
			this._isRunning = (this._weapon != null);
		}

		// Token: 0x06001FCE RID: 8142
		public abstract void Update();

		// Token: 0x06001FCF RID: 8143
		public abstract void Finish();

		// Token: 0x06001FD0 RID: 8144 RVA: 0x00014F7F File Offset: 0x0001317F
		public void Reset()
		{
			this._pivotOffset = new Vector3(0f, 0f, 0.2f);
		}

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06001FD1 RID: 8145 RVA: 0x00014F9B File Offset: 0x0001319B
		public Vector3 PivotVector
		{
			get
			{
				return this._pivotOffset + ((!WeaponFeedbackManager.Instance._isIronSight) ? this.Decorator.DefaultPosition : this.Decorator.IronSightPosition);
			}
		}

		// Token: 0x06001FD2 RID: 8146 RVA: 0x00014FD2 File Offset: 0x000131D2
		public virtual bool CanTransit(WeaponFeedbackManager.WeaponMode mode)
		{
			return WeaponFeedbackManager.Instance.CurrentWeaponMode != mode;
		}

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06001FD3 RID: 8147 RVA: 0x00014FE4 File Offset: 0x000131E4
		public bool IsRunning
		{
			get
			{
				return this._isRunning;
			}
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06001FD4 RID: 8148 RVA: 0x00014FEC File Offset: 0x000131EC
		public bool IsValid
		{
			get
			{
				return this._weapon != null && this._decorator != null;
			}
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x06001FD5 RID: 8149 RVA: 0x00015008 File Offset: 0x00013208
		public BaseWeaponDecorator Decorator
		{
			get
			{
				return this._decorator;
			}
		}

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x06001FD6 RID: 8150 RVA: 0x00015010 File Offset: 0x00013210
		public BaseWeaponLogic Weapon
		{
			get
			{
				return this._weapon;
			}
		}

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06001FD7 RID: 8151 RVA: 0x00015018 File Offset: 0x00013218
		public Vector3 TargetPosition
		{
			get
			{
				return this._targetPosition;
			}
		}

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x06001FD8 RID: 8152 RVA: 0x00015020 File Offset: 0x00013220
		public Quaternion TargetRotation
		{
			get
			{
				return this._targetRotation;
			}
		}

		// Token: 0x04001B07 RID: 6919
		protected bool _isRunning;

		// Token: 0x04001B08 RID: 6920
		protected float _time;

		// Token: 0x04001B09 RID: 6921
		private BaseWeaponLogic _weapon;

		// Token: 0x04001B0A RID: 6922
		private BaseWeaponDecorator _decorator;

		// Token: 0x04001B0B RID: 6923
		protected Vector3 _pivotOffset;

		// Token: 0x04001B0C RID: 6924
		protected float _currentRotation;

		// Token: 0x04001B0D RID: 6925
		protected float _transitionTime;

		// Token: 0x04001B0E RID: 6926
		protected Vector3 _targetPosition;

		// Token: 0x04001B0F RID: 6927
		protected Quaternion _targetRotation;
	}

	// Token: 0x0200045B RID: 1115
	private class PickUpState : WeaponFeedbackManager.WeaponState
	{
		// Token: 0x06001FD9 RID: 8153 RVA: 0x000987A8 File Offset: 0x000969A8
		public PickUpState(BaseWeaponLogic weapon, BaseWeaponDecorator decorator) : base(weapon, decorator)
		{
			this._transitionTime = Mathf.Max(WeaponFeedbackManager.Instance.WeaponAnimation.PickUpDuration, (float)(weapon.Config.SwitchDelayMilliSeconds / 1000));
			if (decorator.IsMelee)
			{
				this._currentRotation = -90f;
				if (base.Decorator)
				{
					base.Decorator.CurrentRotation = Quaternion.Euler(0f, 0f, this._currentRotation);
					base.Decorator.CurrentPosition = decorator.DefaultPosition;
					base.Decorator.IsEnabled = true;
				}
			}
			else
			{
				this._currentRotation = WeaponFeedbackManager.Instance.WeaponAnimation.PutDownAngles;
				this._pivotOffset = -WeaponFeedbackManager.Instance._pivotPoint.localPosition;
				if (base.Decorator)
				{
					base.Decorator.CurrentRotation = Quaternion.Euler(WeaponFeedbackManager.Instance.WeaponAnimation.PutDownAngles, 0f, 0f);
					base.Decorator.CurrentPosition = Quaternion.AngleAxis(this._currentRotation, Vector3.right) * base.PivotVector;
					base.Decorator.IsEnabled = true;
				}
			}
			LevelCamera.ResetZoom();
		}

		// Token: 0x06001FDA RID: 8154 RVA: 0x000988F0 File Offset: 0x00096AF0
		public override void Update()
		{
			if (base.IsValid)
			{
				if (base.IsRunning)
				{
					if (this._time <= this._transitionTime)
					{
						this._currentRotation = Mathf.Lerp(this._currentRotation, WeaponFeedbackManager.Instance.WeaponAnimation.PickUpAngles, this._time / this._transitionTime);
						if (base.Decorator.IsMelee)
						{
							this._targetPosition = base.Decorator.DefaultPosition;
							this._targetRotation = Quaternion.Euler(0f, 0f, this._currentRotation);
						}
						else
						{
							this._targetPosition = Quaternion.AngleAxis(this._currentRotation, Vector3.right) * base.PivotVector;
							this._targetRotation = Quaternion.Euler(this._currentRotation + base.Decorator.DefaultAngles.x, base.Decorator.DefaultAngles.y, base.Decorator.DefaultAngles.z);
						}
						if (!WeaponFeedbackManager.Instance._isIronSight)
						{
							base.Decorator.CurrentPosition = this._targetPosition;
							base.Decorator.CurrentRotation = this._targetRotation;
						}
						this._time += Time.deltaTime;
					}
					if (this._time > this._transitionTime * 0.25f)
					{
						base.Weapon.IsWeaponActive = true;
					}
					if (this._time > this._transitionTime)
					{
						this.Finish();
					}
				}
				if (this._time > this._transitionTime * 0.25f)
				{
					if (WeaponFeedbackManager.Instance._isIronSight)
					{
						this._pivotOffset = Vector3.Lerp(this._pivotOffset, Vector2.zero, Time.deltaTime * 20f);
						if (base.Decorator.CurrentPosition == base.Decorator.IronSightPosition)
						{
							WeaponFeedbackManager.Instance._isIronSightPosDone = true;
						}
						else
						{
							WeaponFeedbackManager.Instance._isIronSightPosDone = false;
						}
					}
					else
					{
						this._pivotOffset = Vector3.Lerp(this._pivotOffset, new Vector3(0f, 0f, 0.2f), Time.deltaTime * 10f);
					}
					if (WeaponFeedbackManager.Instance._fire.time < WeaponFeedbackManager.Instance._fire.Duration)
					{
						if (!base.IsRunning)
						{
							if (!WeaponFeedbackManager.Instance._isIronSight && this._pivotOffset == new Vector3(0f, 0f, 0.2f))
							{
								WeaponFeedbackManager.Instance._fire.HandleFeedback();
								base.Decorator.CurrentPosition = this._targetPosition + WeaponFeedbackManager.Instance._fire.PositionOffset;
								base.Decorator.CurrentRotation = this._targetRotation * WeaponFeedbackManager.Instance._fire.RotationOffset;
							}
							else
							{
								base.Decorator.CurrentPosition = base.PivotVector + WeaponFeedbackManager.Instance._dip.PositionOffset;
								base.Decorator.CurrentRotation = this._targetRotation * WeaponFeedbackManager.Instance._dip.RotationOffset;
							}
							this._isFiring = true;
						}
					}
					else
					{
						if (this._isFiring)
						{
							this._isFiring = false;
							WeaponFeedbackManager.Instance._time = 0f;
							WeaponFeedbackManager.Instance._angleX = 0f;
							WeaponFeedbackManager.Instance._angleY = 0f;
						}
						Quaternion quaternion = Quaternion.identity;
						if (WeaponFeedbackManager.Instance._isIronSight && WeaponFeedbackManager.Instance._dip.PositionOffset == Vector3.zero)
						{
							quaternion = Quaternion.identity;
						}
						else
						{
							quaternion = WeaponFeedbackManager.Instance.CalculateBobDip();
						}
						if (!base.Decorator.IsMelee)
						{
							base.Decorator.CurrentPosition = quaternion * base.PivotVector + WeaponFeedbackManager.Instance._dip.PositionOffset;
							base.Decorator.CurrentRotation = this._targetRotation * WeaponFeedbackManager.Instance._dip.RotationOffset * quaternion;
						}
						else
						{
							base.Decorator.CurrentRotation = this._targetRotation * WeaponFeedbackManager.Instance._dip.RotationOffset * quaternion;
						}
					}
				}
			}
		}

		// Token: 0x06001FDB RID: 8155 RVA: 0x00098D6C File Offset: 0x00096F6C
		public override void Finish()
		{
			if (this._isRunning)
			{
				this._isRunning = false;
				if (base.Weapon != null)
				{
					base.Weapon.IsWeaponActive = true;
					WeaponFeedbackManager.Instance._currentWeaponMode = WeaponFeedbackManager.WeaponMode.Primary;
				}
				if (base.Decorator.IsMelee)
				{
					this._targetRotation = Quaternion.Euler(0f, 0f, WeaponFeedbackManager.Instance.WeaponAnimation.PickUpAngles);
					this._targetPosition = base.Decorator.DefaultPosition;
				}
				else
				{
					this._targetRotation = Quaternion.Euler(WeaponFeedbackManager.Instance.WeaponAnimation.PickUpAngles + base.Decorator.DefaultAngles.x, base.Decorator.DefaultAngles.y, base.Decorator.DefaultAngles.z);
					this._targetPosition = Quaternion.AngleAxis(WeaponFeedbackManager.Instance.WeaponAnimation.PickUpAngles, Vector3.right) * base.PivotVector;
				}
			}
		}

		// Token: 0x06001FDC RID: 8156 RVA: 0x00015028 File Offset: 0x00013228
		public override string ToString()
		{
			return "Pick Up State";
		}

		// Token: 0x04001B10 RID: 6928
		private bool _isFiring;
	}

	// Token: 0x0200045C RID: 1116
	private class PutDownState : WeaponFeedbackManager.WeaponState
	{
		// Token: 0x06001FDD RID: 8157 RVA: 0x00098E78 File Offset: 0x00097078
		public PutDownState(BaseWeaponLogic weapon, BaseWeaponDecorator decorator, bool destroy = false) : base(weapon, decorator)
		{
			this._destroy = destroy;
			this._currentRotation = decorator.CurrentRotation.eulerAngles.x;
			if (this._currentRotation > 300f)
			{
				this._currentRotation = 360f - this._currentRotation;
			}
			if (!decorator.IsMelee)
			{
				this._pivotOffset = -WeaponFeedbackManager.Instance._pivotPoint.localPosition;
			}
			this._transitionTime = WeaponFeedbackManager.Instance.WeaponAnimation.PutDownDuration;
			if (base.Weapon != null)
			{
				base.Weapon.IsWeaponActive = false;
			}
		}

		// Token: 0x06001FDE RID: 8158 RVA: 0x00098F24 File Offset: 0x00097124
		public override void Update()
		{
			if (base.IsRunning && base.IsValid)
			{
				if (this._time > this._transitionTime)
				{
					return;
				}
				if (base.Decorator.IsMelee)
				{
					this._currentRotation = Mathf.Lerp(this._currentRotation, -90f, this._time / this._transitionTime);
					this._targetPosition = base.Decorator.DefaultPosition;
					this._targetRotation = Quaternion.Euler(0f, 0f, this._currentRotation);
				}
				else
				{
					this._currentRotation = Mathf.Lerp(this._currentRotation, WeaponFeedbackManager.Instance.WeaponAnimation.PutDownAngles, this._time / this._transitionTime);
					this._targetPosition = Quaternion.AngleAxis(this._currentRotation, Vector3.right) * base.PivotVector;
					this._targetRotation = Quaternion.Euler(this._currentRotation, 0f, 0f);
				}
				base.Decorator.CurrentPosition = this._targetPosition;
				base.Decorator.CurrentRotation = this._targetRotation;
				this._time += Time.deltaTime;
				if (this._time > this._transitionTime)
				{
					this.Finish();
				}
			}
		}

		// Token: 0x06001FDF RID: 8159 RVA: 0x00099074 File Offset: 0x00097274
		public override void Finish()
		{
			if (this._isRunning)
			{
				this._isRunning = false;
				if (base.Decorator)
				{
					base.Decorator.IsEnabled = false;
					base.Decorator.CurrentPosition = base.Decorator.DefaultPosition;
					base.Decorator.CurrentRotation = this._targetRotation;
					if (this._destroy)
					{
						UnityEngine.Object.Destroy(base.Decorator.gameObject);
					}
				}
			}
		}

		// Token: 0x06001FE0 RID: 8160 RVA: 0x0001502F File Offset: 0x0001322F
		public override string ToString()
		{
			return "Put down";
		}

		// Token: 0x04001B11 RID: 6929
		private bool _destroy;
	}

	// Token: 0x0200045D RID: 1117
	[Serializable]
	public class FeedbackData
	{
		// Token: 0x04001B12 RID: 6930
		public float timeToPeak;

		// Token: 0x04001B13 RID: 6931
		public float timeToEnd;

		// Token: 0x04001B14 RID: 6932
		public float noise;

		// Token: 0x04001B15 RID: 6933
		public float angle;

		// Token: 0x04001B16 RID: 6934
		public float strength;

		// Token: 0x04001B17 RID: 6935
		public float recoilTime;
	}

	// Token: 0x0200045E RID: 1118
	protected struct Feedback
	{
		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x06001FE2 RID: 8162 RVA: 0x00015036 File Offset: 0x00013236
		public float DebugAngle
		{
			get
			{
				return this._angle;
			}
		}

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x06001FE3 RID: 8163 RVA: 0x0001503E File Offset: 0x0001323E
		public float Duration
		{
			get
			{
				return this.timeToPeak + this.timeToEnd;
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x06001FE4 RID: 8164 RVA: 0x0001504D File Offset: 0x0001324D
		public Vector3 PositionOffset
		{
			get
			{
				return this._positionOffset;
			}
		}

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x06001FE5 RID: 8165 RVA: 0x00015055 File Offset: 0x00013255
		public Quaternion RotationOffset
		{
			get
			{
				return this._rotationOffset;
			}
		}

		// Token: 0x06001FE6 RID: 8166 RVA: 0x000990F4 File Offset: 0x000972F4
		public void HandleFeedback()
		{
			float d = UnityEngine.Random.Range(-this.noise, this.noise);
			this._maxAngle = Mathf.Lerp(this._maxAngle, this.angle, Time.deltaTime * 10f);
			if (this.time < this.Duration)
			{
				this.time += Time.deltaTime;
				if (this.time < this.Duration)
				{
					float d2;
					if (this.time < this.timeToPeak)
					{
						d2 = this.strength * Mathf.Sin(this.time * 3.14159274f * 0.5f / this.timeToPeak);
						this.noise = Mathf.Lerp(this.noise, 0f, this.time / this.timeToPeak);
						this._angle = Mathf.Lerp(0f, this._maxAngle, Mathf.Pow(this.time / this.timeToPeak, 2f));
					}
					else
					{
						float t = (this.time - this.timeToPeak) / this.timeToEnd;
						d2 = this.strength * Mathf.Cos((this.time - this.timeToPeak) * 3.14159274f * 0.5f / this.timeToEnd);
						this._angle = Mathf.Lerp(this._maxAngle, 0f, t);
						if (this.time != 0f)
						{
							d = 0f;
						}
					}
					if (Singleton<WeaponController>.Instance.CurrentWeapon)
					{
						this._positionOffset = d2 * this.direction + Singleton<WeaponController>.Instance.CurrentWeapon.transform.right * d + Singleton<WeaponController>.Instance.CurrentWeapon.transform.up * d;
						this._rotationOffset = Quaternion.AngleAxis(this._angle, this.rotationAxis);
					}
				}
				else
				{
					this._angle = 0f;
					this._positionOffset = Vector3.zero;
					this._rotationOffset = Quaternion.identity;
				}
			}
			else
			{
				this.time = 0f;
				this._angle = 0f;
				this._positionOffset = Vector3.zero;
				this._rotationOffset = Quaternion.identity;
			}
		}

		// Token: 0x06001FE7 RID: 8167 RVA: 0x00099340 File Offset: 0x00097540
		public void Reset()
		{
			this.time = 0f;
			this.timeToEnd = 0f;
			this.timeToPeak = -1f;
			this.angle = 0f;
			this.direction = Vector3.zero;
			this._angle = 0f;
			this._positionOffset = Vector3.zero;
			this._rotationOffset = Quaternion.identity;
		}

		// Token: 0x04001B18 RID: 6936
		public float time;

		// Token: 0x04001B19 RID: 6937
		public float noise;

		// Token: 0x04001B1A RID: 6938
		public float angle;

		// Token: 0x04001B1B RID: 6939
		public float timeToPeak;

		// Token: 0x04001B1C RID: 6940
		public float timeToEnd;

		// Token: 0x04001B1D RID: 6941
		public float strength;

		// Token: 0x04001B1E RID: 6942
		public float recoilTime;

		// Token: 0x04001B1F RID: 6943
		public Vector3 direction;

		// Token: 0x04001B20 RID: 6944
		public Vector3 rotationAxis;

		// Token: 0x04001B21 RID: 6945
		private float _maxAngle;

		// Token: 0x04001B22 RID: 6946
		private float _angle;

		// Token: 0x04001B23 RID: 6947
		private Vector3 _positionOffset;

		// Token: 0x04001B24 RID: 6948
		private Quaternion _rotationOffset;
	}

	// Token: 0x0200045F RID: 1119
	[Serializable]
	public class WeaponAnimData
	{
		// Token: 0x04001B25 RID: 6949
		public float PutDownAngles = 30f;

		// Token: 0x04001B26 RID: 6950
		public float PutDownDuration;

		// Token: 0x04001B27 RID: 6951
		public float PickUpAngles;

		// Token: 0x04001B28 RID: 6952
		public float PickUpDuration;
	}
}
