using System;
using UnityEngine;

// Token: 0x02000099 RID: 153
[AddComponentMenu("NGUI/UI/Viewport Camera")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class UIViewport : MonoBehaviour
{
	// Token: 0x06000423 RID: 1059 RVA: 0x000050B9 File Offset: 0x000032B9
	private void Start()
	{
		this.mCam = base.camera;
		if (this.sourceCamera == null)
		{
			this.sourceCamera = Camera.main;
		}
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x0002D3EC File Offset: 0x0002B5EC
	private void LateUpdate()
	{
		if (this.topLeft != null && this.bottomRight != null)
		{
			Vector3 vector = this.sourceCamera.WorldToScreenPoint(this.topLeft.position);
			Vector3 vector2 = this.sourceCamera.WorldToScreenPoint(this.bottomRight.position);
			Rect rect = new Rect(vector.x / (float)Screen.width, vector2.y / (float)Screen.height, (vector2.x - vector.x) / (float)Screen.width, (vector.y - vector2.y) / (float)Screen.height);
			float num = this.fullSize * rect.height;
			if (rect != this.mCam.rect)
			{
				this.mCam.rect = rect;
			}
			if (this.mCam.orthographicSize != num)
			{
				this.mCam.orthographicSize = num;
			}
		}
	}

	// Token: 0x040003B8 RID: 952
	public Camera sourceCamera;

	// Token: 0x040003B9 RID: 953
	public Transform topLeft;

	// Token: 0x040003BA RID: 954
	public Transform bottomRight;

	// Token: 0x040003BB RID: 955
	public float fullSize = 1f;

	// Token: 0x040003BC RID: 956
	private Camera mCam;
}
