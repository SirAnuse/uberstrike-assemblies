using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000C1 RID: 193
public class LevelCamera : MonoBehaviour
{
	// Token: 0x17000221 RID: 545
	// (get) Token: 0x0600072C RID: 1836 RVA: 0x000067E9 File Offset: 0x000049E9
	public static float FieldOfView
	{
		get
		{
			return (!LevelCamera._instance || !(LevelCamera._instance.MainCamera != null)) ? 65f : LevelCamera._instance.MainCamera.fieldOfView;
		}
	}

	// Token: 0x17000222 RID: 546
	// (get) Token: 0x0600072D RID: 1837 RVA: 0x00006828 File Offset: 0x00004A28
	// (set) Token: 0x0600072E RID: 1838 RVA: 0x0000682F File Offset: 0x00004A2F
	public static LevelCamera.CameraMode CurrentMode { get; private set; }

	// Token: 0x17000223 RID: 547
	// (get) Token: 0x0600072F RID: 1839 RVA: 0x00006837 File Offset: 0x00004A37
	public static bool IsLowpassFilterEnabled
	{
		get
		{
			return LevelCamera._instance && Application.isWebPlayer && LevelCamera._instance._lowpassFilter.enabled;
		}
	}

	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06000730 RID: 1840 RVA: 0x00006867 File Offset: 0x00004A67
	// (set) Token: 0x06000731 RID: 1841 RVA: 0x0000686F File Offset: 0x00004A6F
	public LevelCamera.CameraFeedback Feedback { get; private set; }

	// Token: 0x17000225 RID: 549
	// (get) Token: 0x06000732 RID: 1842 RVA: 0x00006878 File Offset: 0x00004A78
	// (set) Token: 0x06000733 RID: 1843 RVA: 0x00006880 File Offset: 0x00004A80
	public LevelCamera.CameraZoomData ZoomData { get; private set; }

	// Token: 0x17000226 RID: 550
	// (get) Token: 0x06000734 RID: 1844 RVA: 0x00006889 File Offset: 0x00004A89
	// (set) Token: 0x06000735 RID: 1845 RVA: 0x00006890 File Offset: 0x00004A90
	public static bool IsZoomedIn { get; private set; }

	// Token: 0x17000227 RID: 551
	// (get) Token: 0x06000736 RID: 1846 RVA: 0x00006898 File Offset: 0x00004A98
	// (set) Token: 0x06000737 RID: 1847 RVA: 0x000068A0 File Offset: 0x00004AA0
	public Camera MainCamera { get; private set; }

	// Token: 0x17000228 RID: 552
	// (get) Token: 0x06000738 RID: 1848 RVA: 0x000068A9 File Offset: 0x00004AA9
	// (set) Token: 0x06000739 RID: 1849 RVA: 0x000068B1 File Offset: 0x00004AB1
	public Transform Transform { get; private set; }

	// Token: 0x17000229 RID: 553
	// (get) Token: 0x0600073A RID: 1850 RVA: 0x000068BA File Offset: 0x00004ABA
	// (set) Token: 0x0600073B RID: 1851 RVA: 0x000068C2 File Offset: 0x00004AC2
	public Transform TargetTransform { get; private set; }

	// Token: 0x1700022A RID: 554
	// (get) Token: 0x0600073C RID: 1852 RVA: 0x000068CB File Offset: 0x00004ACB
	// (set) Token: 0x0600073D RID: 1853 RVA: 0x000068D3 File Offset: 0x00004AD3
	public float RotationOffset { get; private set; }

	// Token: 0x0600073E RID: 1854 RVA: 0x000320A0 File Offset: 0x000302A0
	private void Awake()
	{
		this.Transform = base.transform;
		this.Feedback = new LevelCamera.CameraFeedback(base.transform);
		this.ZoomData = new LevelCamera.CameraZoomData(this);
		this._cameraConfiguration = new LevelCamera.CameraConfiguration();
		this._jumpFeedback = new LevelCamera.CameraFeedbackData();
		this._currentState = new LevelCamera.DisabledState(this, Vector3.zero);
		this._ccd = new CameraCollisionDetector();
		this._ccd.Offset = 1f;
		this._ccd.LayerMask = 1;
		if (Application.isWebPlayer)
		{
			this._lowpassFilter = base.gameObject.AddComponent<AudioLowPassFilter>();
			this._lowpassFilter.cutoffFrequency = 755f;
		}
		this._audioListener = base.GetComponent<AudioListener>();
	}

	// Token: 0x0600073F RID: 1855 RVA: 0x000068DC File Offset: 0x00004ADC
	private void LateUpdate()
	{
		this._currentState.Update();
	}

	// Token: 0x06000740 RID: 1856 RVA: 0x000068E9 File Offset: 0x00004AE9
	private void OnDrawGizmos()
	{
		if (this.TargetTransform != null)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawSphere(this.TargetTransform.position, 0.1f);
			Gizmos.color = Color.white;
		}
	}

	// Token: 0x06000741 RID: 1857 RVA: 0x00006925 File Offset: 0x00004B25
	private void OnDestroy()
	{
		this._currentState.Finish();
		LevelCamera._instance = null;
	}

	// Token: 0x06000742 RID: 1858 RVA: 0x0003215C File Offset: 0x0003035C
	private void InitUserInput()
	{
		Vector3 eulerAngles = UserInput.Rotation.eulerAngles;
		this._userInputCache = UserInput.Rotation;
		eulerAngles.x = Mathf.Clamp(eulerAngles.x, 0f, 60f);
		this._userInputRotation = Quaternion.Euler(eulerAngles);
	}

	// Token: 0x06000743 RID: 1859 RVA: 0x000321AC File Offset: 0x000303AC
	private void UpdateUserInput()
	{
		if (Input.GetMouseButton(0))
		{
			UserInput.UpdateMouse();
		}
		Vector3 eulerAngles = UserInput.Rotation.eulerAngles;
		float num = this._userInputCache.eulerAngles.x;
		float num2 = UserInput.Rotation.eulerAngles.x;
		if (num > 180f)
		{
			num -= 360f;
		}
		if (num2 > 180f)
		{
			num2 -= 360f;
		}
		eulerAngles.x = Mathf.Clamp(this._userInputRotation.eulerAngles.x + (num2 - num), 0f, 60f);
		this._userInputCache = UserInput.Rotation;
		this._userInputRotation = Quaternion.Euler(eulerAngles);
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x00032270 File Offset: 0x00030470
	private void TransformFollowCamera(Vector3 targetPosition, Quaternion targetRotation, float distance, ref float collideDistance)
	{
		Vector3 v = this._userInputRotation * Vector3.back * collideDistance;
		Matrix4x4 matrix4x = Matrix4x4.TRS(targetPosition, targetRotation, Vector3.one);
		Vector3 vector = matrix4x.MultiplyPoint3x4(v);
		Quaternion rotation = Quaternion.LookRotation(targetPosition - vector);
		Vector3 to = matrix4x.MultiplyPoint3x4(this._userInputRotation * Vector3.back * distance);
		if (this._ccd.Detect(targetPosition, to, rotation * Vector3.right))
		{
			float distance2 = this._ccd.Distance;
			if (distance2 < collideDistance)
			{
				collideDistance = Mathf.Clamp(distance2, 1f, distance);
			}
			else
			{
				collideDistance = Mathf.Lerp(collideDistance, distance2, Time.deltaTime * 3f);
			}
		}
		else if (!Mathf.Approximately(collideDistance, distance))
		{
			collideDistance = Mathf.Lerp(collideDistance, distance, Time.deltaTime * 5f);
		}
		else
		{
			collideDistance = distance;
		}
		this.Transform.position = vector;
		this.Transform.rotation = rotation;
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x00032388 File Offset: 0x00030588
	private void TransformDeathCamera(Vector3 targetPosition, Quaternion targetRotation, float distance, ref float collideDistance)
	{
		Vector3 v = Vector3.back * collideDistance;
		Matrix4x4 matrix4x = Matrix4x4.TRS(targetPosition, targetRotation, Vector3.one);
		Vector3 vector = matrix4x.MultiplyPoint3x4(v);
		Quaternion rotation = Quaternion.LookRotation(targetPosition - vector);
		Vector3 to = matrix4x.MultiplyPoint3x4(Vector3.back * distance);
		if (this._ccd.Detect(targetPosition, to, rotation * Vector3.right))
		{
			float distance2 = this._ccd.Distance;
			if (distance2 < collideDistance)
			{
				collideDistance = Mathf.Clamp(distance2, 1f, distance);
			}
			else
			{
				collideDistance = Mathf.Lerp(collideDistance, distance2, Time.deltaTime * 3f);
			}
		}
		else if (!Mathf.Approximately(collideDistance, distance))
		{
			collideDistance = Mathf.Lerp(collideDistance, distance, Time.deltaTime * 5f);
		}
		else
		{
			collideDistance = distance;
		}
		this.Transform.position = vector;
		this.Transform.rotation = rotation;
	}

	// Token: 0x06000746 RID: 1862 RVA: 0x00032488 File Offset: 0x00030688
	private void SetCamera(Camera camera, Vector3 position, Quaternion rotation)
	{
		if (camera != this.MainCamera && camera != null)
		{
			this.ReleaseCamera();
			this._cameraConfiguration.Parent = camera.transform.parent;
			this._cameraConfiguration.Fov = camera.fieldOfView;
			this._cameraConfiguration.CullingMask = camera.cullingMask;
			this.MainCamera = camera;
			this.MainCamera.cullingMask = LayerUtil.AddToLayerMask(this.MainCamera.cullingMask, new UberstrikeLayer[]
			{
				UberstrikeLayer.LocalProjectile
			});
			this.MainCamera.transform.parent = base.transform;
			this.MainCamera.transform.localPosition = Vector3.zero;
			this.MainCamera.transform.localRotation = Quaternion.identity;
			this.ZoomData.TargetFOV = this.MainCamera.fieldOfView;
			this.Transform.position = position;
			this.Transform.rotation = rotation;
			this._audioListener.enabled = true;
		}
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x00032598 File Offset: 0x00030798
	private void SetCameraMode(LevelCamera.CameraMode mode, Transform target)
	{
		this.Feedback.timeToEnd = 0f;
		LevelCamera.CurrentMode = mode;
		this._currentState.Finish();
		if (LevelCamera.IsZoomedIn)
		{
			LevelCamera.DoZoomOut(75f, 10f);
		}
		if (this.MainCamera != null)
		{
			this.MainCamera.transform.localRotation = Quaternion.identity;
			this.MainCamera.transform.localPosition = Vector3.zero;
			switch (mode)
			{
			case LevelCamera.CameraMode.Disabled:
				this.TargetTransform = null;
				this._currentState = new LevelCamera.DisabledState(this, Vector3.zero);
				if (GameState.Current.Avatar.Decorator != null)
				{
					GameState.Current.Avatar.Decorator.gameObject.SetActive(true);
				}
				if (GameState.Current.Player.WeaponCamera != null)
				{
					GameState.Current.Player.WeaponCamera.IsEnabled = false;
				}
				break;
			case LevelCamera.CameraMode.FirstPerson:
				this.MainCamera.cullingMask = LayerUtil.RemoveFromLayerMask(this.MainCamera.cullingMask, new UberstrikeLayer[]
				{
					UberstrikeLayer.LocalPlayer,
					UberstrikeLayer.Weapons
				});
				this.MainCamera.cullingMask = LayerUtil.AddToLayerMask(this.MainCamera.cullingMask, new UberstrikeLayer[]
				{
					UberstrikeLayer.RemoteProjectile
				});
				this.TargetTransform = GameState.Current.Player.CameraTarget;
				this._currentState = new LevelCamera.FirstPersonState(this, GameState.Current.Player.EyePosition);
				if (GameState.Current.Avatar.Decorator != null)
				{
					GameState.Current.Avatar.Decorator.gameObject.SetActive(false);
				}
				if (GameState.Current.Player.WeaponCamera)
				{
					GameState.Current.Player.WeaponCamera.IsEnabled = true;
				}
				break;
			case LevelCamera.CameraMode.OrbitAround:
				this.MainCamera.cullingMask = LayerUtil.AddToLayerMask(this.MainCamera.cullingMask, new UberstrikeLayer[]
				{
					UberstrikeLayer.LocalPlayer
				});
				this.TargetTransform = GameState.Current.Player.CameraTarget;
				this.RotationOffset = 180f;
				this._currentState = new LevelCamera.OrbitAroundState(this, new Vector3(0f, -0.5f, 0f));
				if (GameState.Current.Avatar.Decorator != null && GameState.Current.Avatar.Ragdoll == null)
				{
					GameState.Current.Avatar.Decorator.gameObject.SetActive(true);
				}
				if (GameState.Current.Player.WeaponCamera)
				{
					GameState.Current.Player.WeaponCamera.IsEnabled = false;
				}
				break;
			case LevelCamera.CameraMode.Paused:
				this.MainCamera.cullingMask = LayerUtil.AddToLayerMask(this.MainCamera.cullingMask, new UberstrikeLayer[]
				{
					UberstrikeLayer.LocalPlayer
				});
				this.TargetTransform = GameState.Current.Player.CameraTarget;
				this.RotationOffset = 0f;
				this._currentState = new LevelCamera.OrbitAroundState(this, new Vector3(0f, -0.5f, 0f));
				if (GameState.Current.Avatar.Decorator != null && GameState.Current.Avatar.Ragdoll == null)
				{
					GameState.Current.Avatar.Decorator.gameObject.SetActive(true);
				}
				if (GameState.Current.Player.WeaponCamera)
				{
					GameState.Current.Player.WeaponCamera.IsEnabled = false;
				}
				break;
			case LevelCamera.CameraMode.FreeSpectator:
				this.MainCamera.cullingMask = LayerUtil.AddToLayerMask(this.MainCamera.cullingMask, new UberstrikeLayer[]
				{
					UberstrikeLayer.LocalPlayer
				});
				this.TargetTransform = null;
				this._currentState = new LevelCamera.SpectatorState(this, Vector3.zero);
				if (GameState.Current.Avatar.Decorator != null)
				{
					GameState.Current.Avatar.Decorator.gameObject.SetActive(false);
				}
				if (GameState.Current.Player.WeaponCamera)
				{
					GameState.Current.Player.WeaponCamera.IsEnabled = false;
				}
				break;
			case LevelCamera.CameraMode.SmoothFollow:
				this.MainCamera.cullingMask = LayerUtil.AddToLayerMask(this.MainCamera.cullingMask, new UberstrikeLayer[]
				{
					UberstrikeLayer.LocalPlayer
				});
				this.TargetTransform = target;
				this._currentState = new LevelCamera.SmoothFollowState(this, new Vector3(0f, 1.3f, 0f));
				break;
			case LevelCamera.CameraMode.Ragdoll:
				this.MainCamera.cullingMask = LayerUtil.AddToLayerMask(this.MainCamera.cullingMask, new UberstrikeLayer[]
				{
					UberstrikeLayer.LocalPlayer
				});
				this.TargetTransform = GameState.Current.Avatar.Ragdoll.GetBone(BoneIndex.Hips);
				this._currentState = new LevelCamera.RagdollState(this, new Vector3(0f, 1f, 0f));
				if (GameState.Current.Player.WeaponCamera)
				{
					GameState.Current.Player.WeaponCamera.IsEnabled = false;
				}
				break;
			default:
				Debug.LogError("Camera does not support " + mode.ToString());
				break;
			}
		}
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x00006938 File Offset: 0x00004B38
	private void ReleaseCamera()
	{
		if (this.MainCamera != null)
		{
			this._audioListener.enabled = false;
			UnityEngine.Object.Destroy(this.MainCamera.gameObject);
			this.MainCamera = null;
		}
	}

	// Token: 0x06000749 RID: 1865 RVA: 0x00032B24 File Offset: 0x00030D24
	public static void SetLevelCamera(Camera camera, Vector3 position, Quaternion rotation)
	{
		if (LevelCamera._instance == null)
		{
			GameObject gameObject = new GameObject("LevelCamera", new Type[]
			{
				typeof(AudioListener)
			});
			gameObject.layer = 18;
			SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
			sphereCollider.isTrigger = true;
			sphereCollider.radius = 0.01f;
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			rigidbody.isKinematic = true;
			rigidbody.useGravity = false;
			LevelCamera._instance = gameObject.AddComponent<LevelCamera>();
		}
		LevelCamera._instance.SetCamera(camera, position, rotation);
	}

	// Token: 0x0600074A RID: 1866 RVA: 0x0000696E File Offset: 0x00004B6E
	public static void SetMode(LevelCamera.CameraMode mode, Transform target = null)
	{
		if (LevelCamera._instance)
		{
			LevelCamera._instance.SetCameraMode(mode, target);
		}
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x00032BB0 File Offset: 0x00030DB0
	public static void DoFeedback(LevelCamera.FeedbackType type, Vector3 direction, float strength, float noise, float timeToPeak, float timeToEnd, float angle, Vector3 axis)
	{
		if (LevelCamera._instance)
		{
			LevelCamera._instance.Feedback.time = 0f;
			LevelCamera._instance.Feedback.noise = noise / 4f;
			LevelCamera._instance.Feedback.strength = strength;
			LevelCamera._instance.Feedback.timeToPeak = timeToPeak;
			LevelCamera._instance.Feedback.timeToEnd = timeToEnd;
			LevelCamera._instance.Feedback.direction = direction;
			LevelCamera._instance.Feedback.angle = angle;
			LevelCamera._instance.Feedback.rotationAxis = axis;
		}
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x00032C5C File Offset: 0x00030E5C
	public static bool DoLandFeedback(bool shake)
	{
		if (LevelCamera._instance && LevelCamera.CurrentMode == LevelCamera.CameraMode.FirstPerson && (LevelCamera._instance.Feedback.time == 0f || LevelCamera._instance.Feedback.time >= LevelCamera._instance.Feedback.Duration))
		{
			LevelCamera._instance.Feedback.time = 0f;
			LevelCamera._instance.Feedback.angle = LevelCamera._instance._jumpFeedback.angle;
			LevelCamera._instance.Feedback.noise = ((!shake) ? 0f : LevelCamera._instance._jumpFeedback.noise);
			LevelCamera._instance.Feedback.strength = LevelCamera._instance._jumpFeedback.strength;
			LevelCamera._instance.Feedback.timeToPeak = LevelCamera._instance._jumpFeedback.timeToPeak;
			LevelCamera._instance.Feedback.timeToEnd = LevelCamera._instance._jumpFeedback.timeToEnd;
			LevelCamera._instance.Feedback.direction = Vector3.down;
			LevelCamera._instance.Feedback.rotationAxis = Vector3.right;
			WeaponFeedbackManager.Instance.LandingDip();
			return true;
		}
		return false;
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x00032DB0 File Offset: 0x00030FB0
	public static void DoZoomIn(float fov, float speed, bool hideWeapon)
	{
		if (LevelCamera._instance)
		{
			if (fov < 1f || fov > 100f || speed < 0.001f || speed > 100f)
			{
				Debug.LogError(string.Concat(new object[]
				{
					"Invalid parameters specified!\n FOV should be >1 & <100, Speed should be >0.001 & <100.\nFOV = ",
					fov,
					" Speed = ",
					speed
				}));
				return;
			}
			if (LevelCamera.IsZoomedIn && fov == LevelCamera.FieldOfView)
			{
				return;
			}
			if (LevelCamera.CurrentMode == LevelCamera.CameraMode.FirstPerson && hideWeapon)
			{
				GameState.Current.Player.WeaponCamera.IsEnabled = false;
			}
			LevelCamera._instance.ZoomData.Speed = speed;
			LevelCamera._instance.ZoomData.TargetFOV = fov;
			LevelCamera._instance.ZoomData.TargetAlpha = 1f;
			LevelCamera.IsZoomedIn = true;
		}
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x00032EA4 File Offset: 0x000310A4
	public static void DoZoomOut(float fov, float speed)
	{
		if (LevelCamera._instance)
		{
			if (fov < 1f || fov > 100f || speed < 0.001f || speed > 100f)
			{
				Debug.LogError(string.Concat(new object[]
				{
					"Invalid parameters specified!\n FOV should be >1 & <100, Speed should be >0.001 & <100.\nFOV = ",
					fov,
					" Speed = ",
					speed
				}));
				return;
			}
			if (!LevelCamera.IsZoomedIn)
			{
				return;
			}
			LevelCamera._instance.ZoomData.Speed = speed;
			LevelCamera._instance.ZoomData.TargetFOV = fov;
			LevelCamera._instance.ZoomData.TargetAlpha = 0f;
			LevelCamera.IsZoomedIn = false;
			if (LevelCamera.CurrentMode == LevelCamera.CameraMode.FirstPerson)
			{
				GameState.Current.Player.WeaponCamera.IsEnabled = true;
			}
			global::EventHandler.Global.Fire(new GameEvents.PlayerZoomOut());
		}
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x00032F94 File Offset: 0x00031194
	public static void ResetZoom()
	{
		LevelCamera.IsZoomedIn = false;
		if (LevelCamera._instance)
		{
			LevelCamera._instance.ZoomData.ResetZoom();
		}
		if (LevelCamera.CurrentMode == LevelCamera.CameraMode.FirstPerson)
		{
			GameState.Current.Player.WeaponCamera.IsEnabled = true;
		}
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x0000698B File Offset: 0x00004B8B
	public static void EnableLowPassFilter(bool enabled)
	{
		if (LevelCamera._instance && Application.isWebPlayer)
		{
			LevelCamera._instance._lowpassFilter.enabled = enabled;
		}
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x000069B6 File Offset: 0x00004BB6
	public static void ResetFeedback()
	{
		if (LevelCamera._instance)
		{
			LevelCamera._instance.Feedback.Reset();
		}
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x000069D6 File Offset: 0x00004BD6
	public static void SetPosition(Vector3 position)
	{
		if (LevelCamera._instance)
		{
			LevelCamera._instance.transform.position = position;
		}
	}

	// Token: 0x0400062A RID: 1578
	public const int DefaultFOV = 75;

	// Token: 0x0400062B RID: 1579
	public const int ZoomSpeed = 10;

	// Token: 0x0400062C RID: 1580
	private static LevelCamera _instance;

	// Token: 0x0400062D RID: 1581
	private AudioLowPassFilter _lowpassFilter;

	// Token: 0x0400062E RID: 1582
	private LevelCamera.CameraConfiguration _cameraConfiguration;

	// Token: 0x0400062F RID: 1583
	private LevelCamera.CameraFeedbackData _jumpFeedback;

	// Token: 0x04000630 RID: 1584
	private CameraCollisionDetector _ccd;

	// Token: 0x04000631 RID: 1585
	private LevelCamera.CameraState _currentState;

	// Token: 0x04000632 RID: 1586
	private Quaternion _userInputCache;

	// Token: 0x04000633 RID: 1587
	private Quaternion _userInputRotation;

	// Token: 0x04000634 RID: 1588
	private AudioListener _audioListener;

	// Token: 0x020000C2 RID: 194
	public enum CameraMode
	{
		// Token: 0x0400063E RID: 1598
		Disabled,
		// Token: 0x0400063F RID: 1599
		FirstPerson,
		// Token: 0x04000640 RID: 1600
		OrbitAround,
		// Token: 0x04000641 RID: 1601
		Paused,
		// Token: 0x04000642 RID: 1602
		FreeSpectator,
		// Token: 0x04000643 RID: 1603
		SmoothFollow,
		// Token: 0x04000644 RID: 1604
		Ragdoll
	}

	// Token: 0x020000C3 RID: 195
	public enum FeedbackType
	{
		// Token: 0x04000646 RID: 1606
		JumpLand,
		// Token: 0x04000647 RID: 1607
		GetDamage,
		// Token: 0x04000648 RID: 1608
		ShootWeapon
	}

	// Token: 0x020000C4 RID: 196
	public enum BobMode
	{
		// Token: 0x0400064A RID: 1610
		None,
		// Token: 0x0400064B RID: 1611
		Idle,
		// Token: 0x0400064C RID: 1612
		Walk,
		// Token: 0x0400064D RID: 1613
		Run,
		// Token: 0x0400064E RID: 1614
		Fly,
		// Token: 0x0400064F RID: 1615
		Swim,
		// Token: 0x04000650 RID: 1616
		Crouch
	}

	// Token: 0x020000C5 RID: 197
	public class CameraConfiguration
	{
		// Token: 0x04000651 RID: 1617
		public Transform Parent;

		// Token: 0x04000652 RID: 1618
		public int CullingMask;

		// Token: 0x04000653 RID: 1619
		public float Fov;
	}

	// Token: 0x020000C6 RID: 198
	public class CameraBobManager
	{
		// Token: 0x06000754 RID: 1876 RVA: 0x00032FE8 File Offset: 0x000311E8
		public CameraBobManager(LevelCamera camera)
		{
			this.camera = camera;
			this.bobData = new Dictionary<LevelCamera.BobMode, LevelCamera.CameraBobManager.BobData>();
			foreach (object obj in Enum.GetValues(typeof(LevelCamera.BobMode)))
			{
				LevelCamera.BobMode key = (LevelCamera.BobMode)((int)obj);
				switch (key)
				{
				case LevelCamera.BobMode.Idle:
					this.bobData[key] = new LevelCamera.CameraBobManager.BobData(0.2f, 0f, 2f);
					continue;
				case LevelCamera.BobMode.Walk:
					this.bobData[key] = new LevelCamera.CameraBobManager.BobData(0.3f, 0.3f, 6f);
					continue;
				case LevelCamera.BobMode.Run:
					this.bobData[key] = new LevelCamera.CameraBobManager.BobData(0.5f, 0.3f, 8f);
					continue;
				case LevelCamera.BobMode.Crouch:
					this.bobData[key] = new LevelCamera.CameraBobManager.BobData(0.8f, 0.8f, 12f);
					continue;
				}
				this.bobData[key] = new LevelCamera.CameraBobManager.BobData(0f, 0f, 0f);
			}
			this.data = this.bobData[LevelCamera.BobMode.Idle];
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00033164 File Offset: 0x00031364
		public void Update()
		{
			switch (this.bobMode)
			{
			case LevelCamera.BobMode.Idle:
			{
				float num = Mathf.Sin(Time.time * this.data.Frequency);
				this.camera.Transform.rotation = Quaternion.AngleAxis(num * this.data.XAmplitude * this.strength, this.camera.Transform.right) * Quaternion.AngleAxis(num * this.data.ZAmplitude, this.camera.Transform.forward) * this.camera.Transform.rotation;
				break;
			}
			case LevelCamera.BobMode.Walk:
			{
				float num2 = Mathf.Sin(Time.time * this.data.Frequency);
				this.camera.Transform.rotation = Quaternion.AngleAxis(Mathf.Abs(num2 * this.data.XAmplitude), this.camera.Transform.right) * Quaternion.AngleAxis(num2 * this.data.ZAmplitude, this.camera.Transform.forward) * this.camera.Transform.rotation;
				break;
			}
			case LevelCamera.BobMode.Run:
			{
				float num3 = Mathf.Sin(Time.time * this.data.Frequency);
				this.camera.Transform.rotation = Quaternion.AngleAxis(Mathf.Abs(num3 * this.data.XAmplitude * this.strength), this.camera.Transform.right) * Quaternion.AngleAxis(num3 * this.data.ZAmplitude, this.camera.Transform.forward) * this.camera.Transform.rotation;
				break;
			}
			case LevelCamera.BobMode.Fly:
			{
				float angle = Mathf.Sin(Time.time * this.data.Frequency) * this.data.ZAmplitude;
				this.camera.Transform.rotation = Quaternion.AngleAxis(angle, this.camera.Transform.forward) * this.camera.Transform.rotation;
				break;
			}
			case LevelCamera.BobMode.Swim:
			{
				float angle2 = Mathf.Sin(Time.time * this.data.Frequency) * this.data.ZAmplitude;
				this.camera.Transform.rotation = Quaternion.AngleAxis(angle2, this.camera.Transform.forward) * this.camera.Transform.rotation;
				break;
			}
			case LevelCamera.BobMode.Crouch:
			{
				float num4 = Mathf.Sin(Time.time * this.data.Frequency);
				this.camera.Transform.rotation = Quaternion.AngleAxis(Mathf.Abs(num4 * this.data.XAmplitude), this.camera.Transform.right) * Quaternion.AngleAxis(num4 * this.data.ZAmplitude, this.camera.Transform.forward) * this.camera.Transform.rotation;
				break;
			}
			}
			this.strength = Mathf.Clamp01(this.strength + Time.deltaTime);
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x000069F7 File Offset: 0x00004BF7
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x000069FF File Offset: 0x00004BFF
		public LevelCamera.BobMode Mode
		{
			get
			{
				return this.bobMode;
			}
			set
			{
				if (this.bobMode != value)
				{
					this.strength = 0f;
					this.bobMode = value;
					this.data = this.bobData[value];
				}
			}
		}

		// Token: 0x04000654 RID: 1620
		private float strength;

		// Token: 0x04000655 RID: 1621
		private LevelCamera.CameraBobManager.BobData data;

		// Token: 0x04000656 RID: 1622
		private LevelCamera.BobMode bobMode;

		// Token: 0x04000657 RID: 1623
		private LevelCamera camera;

		// Token: 0x04000658 RID: 1624
		private readonly Dictionary<LevelCamera.BobMode, LevelCamera.CameraBobManager.BobData> bobData;

		// Token: 0x020000C7 RID: 199
		private struct BobData
		{
			// Token: 0x06000758 RID: 1880 RVA: 0x00006A31 File Offset: 0x00004C31
			public BobData(float xamp, float zamp, float freq)
			{
				this._xAmplitude = xamp;
				this._zAmplitude = zamp;
				this._frequency = freq;
			}

			// Token: 0x1700022C RID: 556
			// (get) Token: 0x06000759 RID: 1881 RVA: 0x00006A48 File Offset: 0x00004C48
			public float XAmplitude
			{
				get
				{
					return this._xAmplitude;
				}
			}

			// Token: 0x1700022D RID: 557
			// (get) Token: 0x0600075A RID: 1882 RVA: 0x00006A50 File Offset: 0x00004C50
			public float ZAmplitude
			{
				get
				{
					return this._zAmplitude;
				}
			}

			// Token: 0x1700022E RID: 558
			// (get) Token: 0x0600075B RID: 1883 RVA: 0x00006A58 File Offset: 0x00004C58
			public float Frequency
			{
				get
				{
					return this._frequency;
				}
			}

			// Token: 0x04000659 RID: 1625
			private float _xAmplitude;

			// Token: 0x0400065A RID: 1626
			private float _zAmplitude;

			// Token: 0x0400065B RID: 1627
			private float _frequency;
		}
	}

	// Token: 0x020000C8 RID: 200
	public class CameraFeedbackData
	{
		// Token: 0x0400065C RID: 1628
		public float timeToPeak = 0.2f;

		// Token: 0x0400065D RID: 1629
		public float timeToEnd = 0.15f;

		// Token: 0x0400065E RID: 1630
		public float noise = 0.5f;

		// Token: 0x0400065F RID: 1631
		public float angle;

		// Token: 0x04000660 RID: 1632
		public float strength = 0.3f;
	}

	// Token: 0x020000C9 RID: 201
	public class CameraFeedback
	{
		// Token: 0x0600075D RID: 1885 RVA: 0x00006A94 File Offset: 0x00004C94
		public CameraFeedback(Transform transform)
		{
			this.transform = transform;
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x00006AA3 File Offset: 0x00004CA3
		public float DebugAngle
		{
			get
			{
				return this._angle;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00006AAB File Offset: 0x00004CAB
		public float Duration
		{
			get
			{
				return this.timeToPeak + this.timeToEnd;
			}
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x000334C8 File Offset: 0x000316C8
		public void HandleFeedback()
		{
			if (this.Duration == 0f)
			{
				return;
			}
			float num = UnityEngine.Random.Range(-this.noise, this.noise);
			if (this.time < this.Duration)
			{
				float d;
				if (this.time < this.timeToPeak)
				{
					d = this.strength * Mathf.Sin(this.time * 3.14159274f * 0.5f / this.timeToPeak);
					this._angle = Mathf.Lerp(0f, this.angle, this.time / this.timeToPeak);
				}
				else
				{
					float t = (this.time - this.timeToPeak) / this.timeToEnd;
					d = this.strength * Mathf.Cos((this.time - this.timeToPeak) * 3.14159274f * 0.5f / this.timeToEnd);
					this._angle = Mathf.Lerp(this._angle, 0f, t);
					if (this.time != 0f)
					{
						num = 0f;
					}
				}
				this._currentNoise = Mathf.Lerp(this.noise, 0f, this.time / this.Duration);
				this.shakePos = Vector3.Lerp(this.shakePos, UnityEngine.Random.insideUnitSphere * this._currentNoise, Time.deltaTime * 30f);
				this.time += Time.deltaTime;
				this.transform.position += d * this.direction;
				this.transform.rotation = this.transform.rotation * Quaternion.AngleAxis(this._angle, this.rotationAxis) * Quaternion.AngleAxis(num, this.transform.forward);
			}
			else
			{
				this.time = 0f;
				this.timeToEnd = 0f;
				this.timeToPeak = 0f;
				this._angle = 0f;
			}
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x00006ABA File Offset: 0x00004CBA
		public void Reset()
		{
			this._angle = 0f;
			this.time = 0f;
			this.timeToEnd = 0f;
			this.timeToPeak = 0f;
		}

		// Token: 0x04000661 RID: 1633
		private Transform transform;

		// Token: 0x04000662 RID: 1634
		public float time;

		// Token: 0x04000663 RID: 1635
		public float noise;

		// Token: 0x04000664 RID: 1636
		public float angle;

		// Token: 0x04000665 RID: 1637
		public float timeToPeak;

		// Token: 0x04000666 RID: 1638
		public float timeToEnd;

		// Token: 0x04000667 RID: 1639
		public float strength;

		// Token: 0x04000668 RID: 1640
		public Vector3 direction;

		// Token: 0x04000669 RID: 1641
		public Vector3 rotationAxis;

		// Token: 0x0400066A RID: 1642
		private Vector3 shakePos;

		// Token: 0x0400066B RID: 1643
		private float _angle;

		// Token: 0x0400066C RID: 1644
		private float _currentNoise;
	}

	// Token: 0x020000CA RID: 202
	public class CameraZoomData
	{
		// Token: 0x06000762 RID: 1890 RVA: 0x00006AE8 File Offset: 0x00004CE8
		public CameraZoomData(LevelCamera levelCamera)
		{
			this.levelCamera = levelCamera;
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x00006AF7 File Offset: 0x00004CF7
		public bool IsFovChanged
		{
			get
			{
				return this.TargetFOV != LevelCamera.FieldOfView;
			}
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x000336D4 File Offset: 0x000318D4
		public void Update()
		{
			this.alpha = Mathf.Lerp(this.alpha, this.TargetAlpha, Time.deltaTime * this.Speed);
			if (this.levelCamera.MainCamera)
			{
				this.levelCamera.MainCamera.fieldOfView = Mathf.Lerp(this.levelCamera.MainCamera.fieldOfView, this.TargetFOV, Time.deltaTime * this.Speed);
			}
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00006B09 File Offset: 0x00004D09
		public void ResetZoom()
		{
			if (this.levelCamera.MainCamera)
			{
				this.TargetFOV = 75f;
				this.levelCamera.MainCamera.fieldOfView = 75f;
			}
		}

		// Token: 0x0400066D RID: 1645
		public float TargetAlpha;

		// Token: 0x0400066E RID: 1646
		public float TargetFOV;

		// Token: 0x0400066F RID: 1647
		public float Speed;

		// Token: 0x04000670 RID: 1648
		private float alpha;

		// Token: 0x04000671 RID: 1649
		private LevelCamera levelCamera;
	}

	// Token: 0x020000CB RID: 203
	public abstract class CameraState
	{
		// Token: 0x06000766 RID: 1894 RVA: 0x00006B40 File Offset: 0x00004D40
		protected CameraState(LevelCamera camera, Vector3 offset)
		{
			this.camera = camera;
			this.offset = offset;
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00033750 File Offset: 0x00031950
		protected Vector3 LookAtPosition(Transform target, Quaternion lookRot, float distance)
		{
			Vector3 position = lookRot * Vector3.back * distance;
			return target.TransformPoint(position) + this.offset;
		}

		// Token: 0x06000768 RID: 1896
		public abstract void Update();

		// Token: 0x06000769 RID: 1897 RVA: 0x00003C87 File Offset: 0x00001E87
		public virtual void Finish()
		{
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00003C87 File Offset: 0x00001E87
		public virtual void OnDrawGizmos()
		{
		}

		// Token: 0x04000672 RID: 1650
		protected LevelCamera camera;

		// Token: 0x04000673 RID: 1651
		protected Vector3 offset;
	}

	// Token: 0x020000CC RID: 204
	private class DisabledState : LevelCamera.CameraState
	{
		// Token: 0x0600076B RID: 1899 RVA: 0x00006B56 File Offset: 0x00004D56
		public DisabledState(LevelCamera camera, Vector3 offset) : base(camera, offset)
		{
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00003C87 File Offset: 0x00001E87
		public override void Update()
		{
		}
	}

	// Token: 0x020000CD RID: 205
	private class FirstPersonState : LevelCamera.CameraState
	{
		// Token: 0x0600076D RID: 1901 RVA: 0x00006B60 File Offset: 0x00004D60
		public FirstPersonState(LevelCamera camera, Vector3 offset) : base(camera, offset)
		{
			if (camera.TargetTransform != null)
			{
				camera.TargetTransform.localRotation = UserInput.Rotation;
			}
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00033784 File Offset: 0x00031984
		public override void Update()
		{
			if (this.camera.TargetTransform == null)
			{
				return;
			}
			Vector3 position = this.camera.TargetTransform.position + this.offset;
			this.camera.Transform.position = position;
			this.camera.Transform.rotation = this.camera.TargetTransform.rotation;
			if (this._handleFeedback)
			{
				this.camera.Feedback.HandleFeedback();
			}
			if (this.camera.ZoomData.IsFovChanged)
			{
				this.camera.ZoomData.Update();
			}
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x00006B92 File Offset: 0x00004D92
		public override void Finish()
		{
			this.camera.ZoomData.ResetZoom();
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x00006BA4 File Offset: 0x00004DA4
		public override void OnDrawGizmos()
		{
			Gizmos.DrawRay(this.camera.Transform.position, this.camera.Transform.TransformDirection(this.camera.Feedback.rotationAxis));
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00006BDB File Offset: 0x00004DDB
		public override string ToString()
		{
			return "FPS state";
		}

		// Token: 0x04000674 RID: 1652
		private const float _duration = 1f;

		// Token: 0x04000675 RID: 1653
		private bool _handleFeedback = true;
	}

	// Token: 0x020000CE RID: 206
	private class SmoothFollowState : LevelCamera.CameraState
	{
		// Token: 0x06000772 RID: 1906 RVA: 0x00006BE2 File Offset: 0x00004DE2
		public SmoothFollowState(LevelCamera camera, Vector3 offset) : base(camera, offset)
		{
			this._collideDistance = this._distance / 2f;
			camera.InitUserInput();
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00033838 File Offset: 0x00031A38
		public override void Update()
		{
			if (this.camera.TargetTransform != null)
			{
				float num = AutoMonoBehaviour<InputManager>.Instance.RawValue(GameInputKey.NextWeapon);
				if (num != 0f)
				{
					this._distance -= Mathf.Sign(num) * 40f * Time.deltaTime;
					this._distance = Mathf.Clamp(this._distance, 1f, 4f);
				}
				Vector3 eulerAngles = this.camera.TargetTransform.eulerAngles;
				this._targetRotationY = Quaternion.Lerp(this._targetRotationY, Quaternion.Euler(0f, eulerAngles.y, 0f), Time.deltaTime * 2f);
				Vector3 targetPosition = this.camera.TargetTransform.position + this.offset;
				this.camera.UpdateUserInput();
				this.camera.TransformFollowCamera(targetPosition, this._targetRotationY, this._distance, ref this._collideDistance);
			}
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x00006C1A File Offset: 0x00004E1A
		public override string ToString()
		{
			return "Smooth follow state";
		}

		// Token: 0x04000676 RID: 1654
		private const float _zoomSpeed = 40f;

		// Token: 0x04000677 RID: 1655
		private float _collideDistance;

		// Token: 0x04000678 RID: 1656
		private float _distance = 1.5f;

		// Token: 0x04000679 RID: 1657
		private Quaternion _targetRotationY = Quaternion.identity;
	}

	// Token: 0x020000CF RID: 207
	private class OrbitAroundState : LevelCamera.CameraState
	{
		// Token: 0x06000775 RID: 1909 RVA: 0x00033938 File Offset: 0x00031B38
		public OrbitAroundState(LevelCamera camera, Vector3 offset) : base(camera, offset)
		{
			if (camera.TargetTransform == null)
			{
				throw new NullReferenceException("The OrbitAroundState required a valid _targetTransform. Call LevelCamera.camera.SetTarget() before!");
			}
			this._collideDistance = this._distance / 2f;
			this._ccd = new CameraCollisionDetector();
			this._ccd.Offset = 1f;
			this._angle.x = (camera.TargetTransform.rotation.eulerAngles.x + 360f) % 360f;
			this._angle.y = (camera.TargetTransform.rotation.eulerAngles.y + camera.RotationOffset + 360f) % 360f;
			camera.TargetTransform.rotation = Quaternion.identity;
			if (this._angle.x > 70f && this._angle.x < 91f)
			{
				this._angle.x = 70f;
			}
			if (this._angle.x > 269f && this._angle.x < 290f)
			{
				this._angle.x = 290f;
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00033A90 File Offset: 0x00031C90
		public override void Update()
		{
			bool flag = true;
			if (Input.GetMouseButton(0))
			{
				flag = false;
				this._angle.x = (this._angle.x - AutoMonoBehaviour<InputManager>.Instance.RawValue(GameInputKey.VerticalLook) + 360f) % 360f;
				this._angle.y = (this._angle.y + AutoMonoBehaviour<InputManager>.Instance.RawValue(GameInputKey.HorizontalLook)) % 360f;
				if (this._angle.x > 70f && this._angle.x < 91f)
				{
					this._angle.x = 70f;
				}
				if (this._angle.x > 269f && this._angle.x < 290f)
				{
					this._angle.x = 290f;
				}
			}
			Quaternion lookRot = Quaternion.Euler(this._angle.x, this._angle.y, 0f);
			Vector3 vector = this.camera.TargetTransform.position + this.offset;
			Vector3 to = base.LookAtPosition(this.camera.TargetTransform, lookRot, 1f);
			if (this._ccd.Detect(vector, to, this.camera.TargetTransform.right))
			{
				if (this._ccd.Distance < this._collideDistance)
				{
					this._collideDistance = Mathf.Clamp(this._ccd.Distance, 0.5f, this._distance);
				}
				else
				{
					this._collideDistance = Mathf.Lerp(this._collideDistance, this._ccd.Distance, Time.deltaTime);
				}
			}
			else
			{
				this._collideDistance = Mathf.Lerp(this._collideDistance, this._distance, Time.deltaTime);
			}
			if (flag)
			{
				this.camera.Transform.position = Vector3.Lerp(this.camera.Transform.position, base.LookAtPosition(this.camera.TargetTransform, lookRot, this._collideDistance), Time.deltaTime * 5f);
				this.camera.Transform.rotation = Quaternion.Slerp(this.camera.Transform.rotation, Quaternion.LookRotation(vector - this.camera.Transform.position), Time.deltaTime * 5f);
			}
			else
			{
				this.camera.Transform.position = base.LookAtPosition(this.camera.TargetTransform, lookRot, this._collideDistance);
				this.camera.Transform.rotation = Quaternion.LookRotation(vector - this.camera.Transform.position);
			}
		}

		// Token: 0x0400067A RID: 1658
		private float _distance = 2.5f;

		// Token: 0x0400067B RID: 1659
		private float _collideDistance;

		// Token: 0x0400067C RID: 1660
		private Vector2 _angle;

		// Token: 0x0400067D RID: 1661
		private CameraCollisionDetector _ccd;
	}

	// Token: 0x020000D0 RID: 208
	private class RagdollState : LevelCamera.CameraState
	{
		// Token: 0x06000777 RID: 1911 RVA: 0x00033D5C File Offset: 0x00031F5C
		public RagdollState(LevelCamera camera, Vector3 offset) : base(camera, offset)
		{
			this.targetPosition = GameState.Current.Avatar.Ragdoll.GetBone(BoneIndex.Hips).position + new Vector3(0f, 1.5f, 0f);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00033DAC File Offset: 0x00031FAC
		public override void Update()
		{
			this.camera.Transform.position = Vector3.Lerp(this.camera.Transform.position, this.targetPosition, Time.deltaTime);
			this.camera.Transform.LookAt(this.camera.TargetTransform);
		}

		// Token: 0x0400067E RID: 1662
		private const float extraHeight = 1.5f;

		// Token: 0x0400067F RID: 1663
		private Vector3 targetPosition;
	}

	// Token: 0x020000D1 RID: 209
	private class SpectatorState : LevelCamera.CameraState
	{
		// Token: 0x06000779 RID: 1913 RVA: 0x00006C21 File Offset: 0x00004E21
		public SpectatorState(LevelCamera camera, Vector3 offset) : base(camera, offset)
		{
			this._targetPosition = camera.Transform.position;
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00033E04 File Offset: 0x00032004
		public override void Update()
		{
			if (!GameData.Instance.HUDChatIsTyping && Screen.lockCursor)
			{
				int num = (!UserInput.IsWalking) ? 4 : 6;
				this._speed = Mathf.Lerp(this._speed, (float)((!UserInput.IsWalking) ? 11 : 22), Time.deltaTime);
				this._targetPosition += (UserInput.Rotation * UserInput.HorizontalDirection + UserInput.VerticalDirection * 0.8f) * this._speed * Time.deltaTime;
				this.camera.Transform.position = Vector3.Lerp(this.camera.Transform.position, this._targetPosition, Time.deltaTime * (float)num);
				this.camera.Transform.rotation = UserInput.Rotation;
			}
		}

		// Token: 0x04000680 RID: 1664
		private const int MaxSpeed = 22;

		// Token: 0x04000681 RID: 1665
		private const float verticalSpeed = 0.8f;

		// Token: 0x04000682 RID: 1666
		private Vector3 _targetPosition;

		// Token: 0x04000683 RID: 1667
		private float _speed = 11f;
	}
}
