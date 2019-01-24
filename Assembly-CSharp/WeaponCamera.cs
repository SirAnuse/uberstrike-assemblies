using System;
using UnityEngine;

// Token: 0x020000D4 RID: 212
[RequireComponent(typeof(Camera))]
public class WeaponCamera : MonoBehaviour
{
	// Token: 0x06000791 RID: 1937 RVA: 0x00006D48 File Offset: 0x00004F48
	private void Awake()
	{
		this._transform = base.transform;
	}

	// Token: 0x17000236 RID: 566
	// (get) Token: 0x06000792 RID: 1938 RVA: 0x00006D56 File Offset: 0x00004F56
	// (set) Token: 0x06000793 RID: 1939 RVA: 0x00006D63 File Offset: 0x00004F63
	public bool IsEnabled
	{
		get
		{
			return base.camera.enabled;
		}
		set
		{
			base.camera.enabled = value;
		}
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x00006D63 File Offset: 0x00004F63
	public void SetCameraEnabled(bool enabled)
	{
		base.camera.enabled = enabled;
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x00034598 File Offset: 0x00032798
	private void LateUpdate()
	{
		if (WeaponFeedbackManager.Instance)
		{
			if (WeaponFeedbackManager.Instance.IsIronSighted)
			{
				this._currentAngle = Vector2.Lerp(this._currentAngle, Vector2.zero, Time.deltaTime * 5f);
				this.MoveWeapon();
			}
			else
			{
				float value = AutoMonoBehaviour<InputManager>.Instance.GetValue(GameInputKey.HorizontalLook);
				float value2 = AutoMonoBehaviour<InputManager>.Instance.GetValue(GameInputKey.VerticalLook);
				this.AddDeltaAngle(value, value2);
				this.MoveWeapon();
				this._currentAngle = Vector2.Lerp(this._currentAngle, Vector2.zero, Time.deltaTime * 5f);
			}
		}
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x00034638 File Offset: 0x00032838
	private void AddDeltaAngle(float x, float y)
	{
		Vector2 b = Vector2.ClampMagnitude(new Vector2(x, y), this._maxDisplacementDelta);
		this._currentAngle = Vector2.ClampMagnitude(this._currentAngle + b, this._maxDisplacement);
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x00006D71 File Offset: 0x00004F71
	private void MoveWeapon()
	{
		this._transform.localRotation = Quaternion.AngleAxis(this._currentAngle.x, Vector3.up) * Quaternion.AngleAxis(-this._currentAngle.y, Vector3.right);
	}

	// Token: 0x0400069A RID: 1690
	private const float RESET_VELOCITY = 5f;

	// Token: 0x0400069B RID: 1691
	private const float LERP_DURATION = 0.1f;

	// Token: 0x0400069C RID: 1692
	[SerializeField]
	private float _maxDisplacementDelta = 0.4f;

	// Token: 0x0400069D RID: 1693
	[SerializeField]
	private float _maxDisplacement = 0.8f;

	// Token: 0x0400069E RID: 1694
	private Transform _transform;

	// Token: 0x0400069F RID: 1695
	public Vector2 _currentAngle = Vector2.zero;
}
