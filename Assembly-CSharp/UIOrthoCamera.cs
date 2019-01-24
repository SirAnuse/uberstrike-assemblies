using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Orthographic Camera")]
[RequireComponent(typeof(Camera))]
public class UIOrthoCamera : MonoBehaviour
{
	// Token: 0x06000390 RID: 912 RVA: 0x00004B6F File Offset: 0x00002D6F
	private void Start()
	{
		this.mCam = base.camera;
		this.mTrans = base.transform;
		this.mCam.orthographic = true;
	}

	// Token: 0x06000391 RID: 913 RVA: 0x00028404 File Offset: 0x00026604
	private void Update()
	{
		float num = this.mCam.rect.yMin * (float)Screen.height;
		float num2 = this.mCam.rect.yMax * (float)Screen.height;
		float num3 = (num2 - num) * 0.5f * this.mTrans.lossyScale.y;
		if (!Mathf.Approximately(this.mCam.orthographicSize, num3))
		{
			this.mCam.orthographicSize = num3;
		}
	}

	// Token: 0x04000332 RID: 818
	private Camera mCam;

	// Token: 0x04000333 RID: 819
	private Transform mTrans;
}
