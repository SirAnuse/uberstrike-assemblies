using System;
using UnityEngine;

// Token: 0x020000D3 RID: 211
public class MouseOrbit : MonoBehaviour
{
	// Token: 0x17000233 RID: 563
	// (get) Token: 0x06000781 RID: 1921 RVA: 0x00006C78 File Offset: 0x00004E78
	// (set) Token: 0x06000782 RID: 1922 RVA: 0x00006C7F File Offset: 0x00004E7F
	public static MouseOrbit Instance { get; private set; }

	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06000783 RID: 1923 RVA: 0x00006C87 File Offset: 0x00004E87
	// (set) Token: 0x06000784 RID: 1924 RVA: 0x00006C8F File Offset: 0x00004E8F
	public Vector3 OrbitOffset { get; set; }

	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06000785 RID: 1925 RVA: 0x00006C98 File Offset: 0x00004E98
	// (set) Token: 0x06000786 RID: 1926 RVA: 0x00006C9F File Offset: 0x00004E9F
	public static bool Disable { get; set; }

	// Token: 0x06000787 RID: 1927 RVA: 0x00006CA7 File Offset: 0x00004EA7
	private void Awake()
	{
		MouseOrbit.Instance = this;
		MouseOrbit.Disable = false;
		if (this.target == null)
		{
			throw new NullReferenceException("MouseOrbit.target not set");
		}
	}

	// Token: 0x06000788 RID: 1928 RVA: 0x00033FF4 File Offset: 0x000321F4
	private void Start()
	{
		this.mouseAxisSpin = Vector2.zero;
		Vector3 eulerAngles = base.transform.eulerAngles;
		this.OrbitConfig.x = eulerAngles.y;
		this.OrbitConfig.y = eulerAngles.x;
		this.MaxX = Screen.width;
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x00034048 File Offset: 0x00032248
	private void OnEnable()
	{
		this.zoomDistance = (this.OrbitConfig.z = Mathf.Clamp(Vector3.Distance(base.transform.position, this.target.position), this.zoomMax[0], this.zoomMax[1]));
		this.OrbitConfig.x = base.transform.rotation.eulerAngles.y;
		this.OrbitConfig.y = base.transform.rotation.eulerAngles.x;
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x000340F0 File Offset: 0x000322F0
	private void LateUpdate()
	{
		if (!PopupSystem.IsAnyPopupOpen && !PanelManager.IsAnyPanelOpen && GUIUtility.hotControl == 0)
		{
			if (base.camera.pixelRect.Contains(Input.mousePosition) && Input.GetAxis("Mouse ScrollWheel") != 0f)
			{
				this.OrbitConfig.z = Mathf.Clamp(this.zoomDistance - Input.GetAxis("Mouse ScrollWheel") * 15f, this.zoomMax[0], this.zoomMax[1]);
			}
			if (Input.GetMouseButtonDown(0) && base.camera.pixelRect.Contains(Input.mousePosition))
			{
				this.mouseAxisSpin = Vector2.zero;
				this.listenToMouseUp = true;
				this.isMouseDragging = true;
			}
			if (Input.GetMouseButtonUp(0))
			{
				if (this.listenToMouseUp)
				{
					float d = Mathf.Clamp((Input.mousePosition - this.mousePos).magnitude, 0f, 3f);
					this.mouseAxisSpin = (Input.mousePosition - this.mousePos).normalized * d;
				}
				else
				{
					this.mouseAxisSpin = Vector2.zero;
				}
				this.listenToMouseUp = false;
			}
			this.mousePos = Input.mousePosition;
			if (this.isMouseDragging && Input.GetMouseButton(0))
			{
				this.OrbitConfig.x = this.OrbitConfig.x + Input.GetAxis("Mouse X") * 3f;
				this.yPanningOffset -= Input.GetAxis("Mouse Y") * 0.01f * ((!MouseOrbit.IsValueWithin(this.yPanningOffset, this.panMax[0], this.panMax[1])) ? 0.3f : 1f);
			}
			else if (this.mouseAxisSpin.magnitude > 0.0100000007f)
			{
				this.mouseAxisSpin = Vector2.Lerp(this.mouseAxisSpin, Vector2.zero, Time.deltaTime * 2f);
				this.OrbitConfig.x = this.OrbitConfig.x + this.mouseAxisSpin.x * 0.1f;
				this.yPanningOffset -= this.mouseAxisSpin.y * 0.01f * 0.1f * ((!MouseOrbit.IsValueWithin(this.yPanningOffset, this.panMax[0], this.panMax[1])) ? 0.3f : 1f);
			}
			else
			{
				this.mouseAxisSpin = Vector2.zero;
			}
			if (!this.isMouseDragging || !Input.GetMouseButton(0))
			{
				this.yPanningOffset = Mathf.Lerp(this.yPanningOffset, Mathf.Clamp(this.yPanningOffset, this.panMax[0], this.panMax[1]), Time.deltaTime * 10f);
			}
			this.yPanningOffset = Mathf.Clamp(this.yPanningOffset, this.panTotalMax[0], this.panTotalMax[1]);
			this.zoomDistance = Mathf.Lerp(this.zoomDistance, Mathf.Clamp(this.OrbitConfig.z, this.zoomMax[0], this.zoomMax[1]), Time.deltaTime * 5f);
			this.Transform(base.transform);
		}
		else
		{
			this.listenToMouseUp = false;
			this.mouseAxisSpin = Vector2.zero;
		}
		if (this.isMouseDragging && !Input.GetMouseButton(0))
		{
			this.isMouseDragging = false;
		}
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x000344B0 File Offset: 0x000326B0
	public void Transform(Transform transform)
	{
		Vector3 position;
		Quaternion rotation;
		this.Transform(out position, out rotation);
		transform.position = position;
		transform.rotation = rotation;
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x000344D8 File Offset: 0x000326D8
	public void Transform(out Vector3 position, out Quaternion rotation2)
	{
		float num = 1f - Mathf.Clamp01(this.zoomDistance / this.zoomMax[1]);
		Quaternion quaternion = Quaternion.Euler(this.OrbitConfig.y, this.OrbitConfig.x, 0f);
		rotation2 = quaternion;
		position = this.target.position + quaternion * new Vector3(0f, 0f, -this.zoomDistance) + quaternion * (this.OrbitOffset + new Vector3(0f, this.yPanningOffset * num, 0f)) * this.zoomDistance;
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x00006CD1 File Offset: 0x00004ED1
	public void SetTarget(Transform t)
	{
		this.target = t;
	}

	// Token: 0x0600078E RID: 1934 RVA: 0x00006CDA File Offset: 0x00004EDA
	private static bool IsValueWithin(float value, float min, float max)
	{
		return value >= min && value <= max;
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x00006CED File Offset: 0x00004EED
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	// Token: 0x04000686 RID: 1670
	private const float zoomSpeedFactor = 15f;

	// Token: 0x04000687 RID: 1671
	private const float zoomTouchSpeedFactor = 0.001f;

	// Token: 0x04000688 RID: 1672
	private const float flingSpeedFactor = 0.1f;

	// Token: 0x04000689 RID: 1673
	private const float orbitSpeedFactor = 3f;

	// Token: 0x0400068A RID: 1674
	private const float panSpeedFactor = 0.01f;

	// Token: 0x0400068B RID: 1675
	[SerializeField]
	private Transform target;

	// Token: 0x0400068C RID: 1676
	private Vector2 zoomMax = new Vector2(1.3f, 5f);

	// Token: 0x0400068D RID: 1677
	private Vector2 panMax = new Vector2(-0.5f, 0.5f);

	// Token: 0x0400068E RID: 1678
	private Vector2 panTotalMax = new Vector2(-1f, 1f);

	// Token: 0x0400068F RID: 1679
	public Vector3 OrbitConfig;

	// Token: 0x04000690 RID: 1680
	public float yPanningOffset;

	// Token: 0x04000691 RID: 1681
	private float zoomDistance = 5f;

	// Token: 0x04000692 RID: 1682
	public int MaxX;

	// Token: 0x04000693 RID: 1683
	private Vector2 mouseAxisSpin;

	// Token: 0x04000694 RID: 1684
	private Vector3 mousePos;

	// Token: 0x04000695 RID: 1685
	private bool listenToMouseUp;

	// Token: 0x04000696 RID: 1686
	private bool isMouseDragging;
}
