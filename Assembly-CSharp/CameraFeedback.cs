using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
[RequireComponent(typeof(Camera))]
public class CameraFeedback : MonoBehaviour
{
	// Token: 0x1700021E RID: 542
	// (get) Token: 0x06000714 RID: 1812 RVA: 0x000066E1 File Offset: 0x000048E1
	public static CameraFeedback Instance
	{
		get
		{
			return CameraFeedback._instance;
		}
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x000066E8 File Offset: 0x000048E8
	private void Awake()
	{
		CameraFeedback._instance = this;
		this._transformCache = base.transform;
		this._currentFeedback = null;
		this._tmpRotation = Quaternion.identity;
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x000318D4 File Offset: 0x0002FAD4
	private void Update()
	{
		if (this._currentFeedback == null)
		{
			if (this._transformCache.localPosition.sqrMagnitude > 0.001f)
			{
				this._transformCache.localPosition = Vector3.Lerp(this._transformCache.localPosition, Vector3.zero, Time.deltaTime);
				this._transformCache.localRotation = Quaternion.Lerp(this._transformCache.localRotation, Quaternion.identity, Time.deltaTime);
			}
		}
		else
		{
			Vector3 direction = this._currentFeedback.GetDirection();
			float num = this._currentFeedback.Peak;
			float num2 = UnityEngine.Random.Range(-this._currentFeedback.MaxNoise, this._currentFeedback.MaxNoise);
			if (this._timer < this._currentFeedback.TimeToEnd + this._currentFeedback.TimeToPeak)
			{
				if (this._timer < this._currentFeedback.TimeToPeak)
				{
					num *= Mathf.Sin(this._timer * 3.14159274f * 0.5f / this._currentFeedback.TimeToPeak);
					num2 = Mathf.Lerp(num2, 0f, this._timer / this._currentFeedback.TimeToPeak);
					this._angle = Mathf.Lerp(0f, this._currentFeedback.MaxAngle, this._timer / this._currentFeedback.TimeToPeak);
				}
				else
				{
					float t = (this._timer - this._currentFeedback.TimeToPeak) / this._currentFeedback.TimeToEnd;
					num = Mathf.Lerp(num, 0f, t);
					this._angle = Mathf.Lerp(this._angle, 0f, t);
					num2 = 0f;
				}
				this._timer += Time.deltaTime;
				this._transformCache.localPosition = num * direction + this._transformCache.right * num2 + this._transformCache.up * num2;
				this._tmpRotation = Quaternion.AngleAxis(this._angle, this._rotationAxis);
				this._testAngle = this._angle;
			}
			else
			{
				this._timer = 0f;
				this._tmpRotation = Quaternion.identity;
				this._currentFeedback = null;
			}
		}
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x00031B1C File Offset: 0x0002FD1C
	private void DoApplyFeedback()
	{
		GUI.Label(new Rect(10f, 50f, 300f, 20f), "Camera local position = " + this._transformCache.localPosition);
		GUI.Label(new Rect(10f, 60f, 300f, 20f), "Camera world position = " + this._transformCache.position);
		GUI.Label(new Rect(10f, 70f, 300f, 20f), "Rotation Axis = " + this._rotationAxis);
		GUI.Label(new Rect(10f, 80f, 300f, 20f), "Rotation Angle = " + this._testAngle);
		if (GUI.Button(new Rect(10f, 100f, 60f, 25f), "Land"))
		{
			this.onPlayerLand(new PlayerLandEvent());
		}
		if (GUI.Button(new Rect(80f, 100f, 60f, 25f), "Damage"))
		{
			this.onDamage(new GetDamageEvent(Vector3.back));
		}
		if (GUI.Button(new Rect(150f, 100f, 60f, 25f), "Weapon"))
		{
			this.onWeaponShoot(new WeaponShootEvent(Vector3.back, this.Feedbacks[2].MaxNoise, this.Feedbacks[2].MaxAngle));
		}
		Vector3[] array = new Vector3[]
		{
			new Vector3(-0.8f, -0.3f, 0.6f),
			new Vector3(-0.8f, -0.1f, 0.6f),
			new Vector3(0.5f, -0.7f, 0.5f)
		};
		for (int i = 0; i < array.Length; i++)
		{
			if (GUI.Button(new Rect(10f, (float)(125 + 25 * i), 100f, 25f), "Damage " + i))
			{
				this.onDamage(new GetDamageEvent(array[i]));
			}
		}
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x00031D84 File Offset: 0x0002FF84
	private void OnDrawGizmos()
	{
		if (!this._transformCache)
		{
			this._transformCache = base.transform;
		}
		Gizmos.color = Color.green;
		Gizmos.DrawRay(this._transformCache.position, this.Feedbacks[1].GetDirection());
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x0000670E File Offset: 0x0000490E
	private void onPlayerLand(PlayerLandEvent ev)
	{
		this.ApplyFeedback(CameraFeedback.FeedbackType.Land, Vector3.down, Vector3.right);
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x00006721 File Offset: 0x00004921
	private void onDamage(GetDamageEvent ev)
	{
		this.ApplyFeedback(CameraFeedback.FeedbackType.Damage, ev.Force, Vector3.zero);
	}

	// Token: 0x0600071B RID: 1819 RVA: 0x00031DD4 File Offset: 0x0002FFD4
	private void onWeaponShoot(WeaponShootEvent ev)
	{
		this.Feedbacks[2].Peak = 1f;
		this.Feedbacks[2].MaxNoise = ev.Noise;
		this.Feedbacks[2].MaxAngle = ev.Angle;
		this.ApplyFeedback(CameraFeedback.FeedbackType.Weapon, ev.Force, Vector3.left);
	}

	// Token: 0x0600071C RID: 1820 RVA: 0x00031E2C File Offset: 0x0003002C
	public void ApplyFeedback(CameraFeedback.FeedbackType t, Vector3 dir, Vector3 rotAxis)
	{
		this._timer = 0f;
		this._currentFeedback = this.Feedbacks[(int)t];
		this._currentFeedback.SetDirection(dir);
		this._rotationAxis = ((!(rotAxis == Vector3.zero)) ? rotAxis : this._transformCache.InverseTransformDirection(Vector3.Cross(Vector3.up, dir)));
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x00006735 File Offset: 0x00004935
	public void ApplyFeedback(Vector3 dir, float noise, float angle)
	{
		this.Feedbacks[2].Peak = 1f;
		this.Feedbacks[2].MaxNoise = noise;
		this.Feedbacks[2].MaxAngle = angle;
		this.ApplyFeedback(CameraFeedback.FeedbackType.Weapon, dir, Vector3.left);
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x00006772 File Offset: 0x00004972
	public Quaternion GetFeedbackRoation()
	{
		return this._tmpRotation;
	}

	// Token: 0x0400060F RID: 1551
	public bool DEBUG = true;

	// Token: 0x04000610 RID: 1552
	private static CameraFeedback _instance;

	// Token: 0x04000611 RID: 1553
	public CameraFeedback.Feedback[] Feedbacks;

	// Token: 0x04000612 RID: 1554
	private CameraFeedback.Feedback _currentFeedback;

	// Token: 0x04000613 RID: 1555
	private Transform _transformCache;

	// Token: 0x04000614 RID: 1556
	private Quaternion _tmpRotation;

	// Token: 0x04000615 RID: 1557
	private Vector3 _rotationAxis;

	// Token: 0x04000616 RID: 1558
	private float _timer;

	// Token: 0x04000617 RID: 1559
	private float _angle;

	// Token: 0x04000618 RID: 1560
	private float _testAngle;

	// Token: 0x020000BB RID: 187
	public enum FeedbackType
	{
		// Token: 0x0400061A RID: 1562
		Land,
		// Token: 0x0400061B RID: 1563
		Damage,
		// Token: 0x0400061C RID: 1564
		Weapon
	}

	// Token: 0x020000BC RID: 188
	[Serializable]
	public class Feedback
	{
		// Token: 0x0600071F RID: 1823 RVA: 0x00031E90 File Offset: 0x00030090
		public Feedback(CameraFeedback.Feedback f)
		{
			this._dir = Vector3.zero;
			this.Type = f.Type;
			this.Peak = f.Peak;
			this.TimeToPeak = f.TimeToPeak;
			this.TimeToEnd = f.TimeToEnd;
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0000677A File Offset: 0x0000497A
		public void SetDirection(Vector3 dir)
		{
			this._dir = dir;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00006783 File Offset: 0x00004983
		public Vector3 GetDirection()
		{
			return this._dir;
		}

		// Token: 0x0400061D RID: 1565
		public CameraFeedback.FeedbackType Type;

		// Token: 0x0400061E RID: 1566
		public float Peak;

		// Token: 0x0400061F RID: 1567
		public float TimeToPeak;

		// Token: 0x04000620 RID: 1568
		public float TimeToEnd;

		// Token: 0x04000621 RID: 1569
		public float MaxNoise;

		// Token: 0x04000622 RID: 1570
		public float MaxAngle;

		// Token: 0x04000623 RID: 1571
		private Vector3 _dir;
	}
}
