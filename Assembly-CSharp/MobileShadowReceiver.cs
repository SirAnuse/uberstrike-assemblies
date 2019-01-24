using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public class MobileShadowReceiver : MonoBehaviour
{
	// Token: 0x060015A4 RID: 5540 RVA: 0x000793CC File Offset: 0x000775CC
	public void OnWillRenderObject()
	{
		Camera camera = null;
		for (int i = 0; i < Camera.allCameras.Length; i++)
		{
			if (Camera.allCameras[i].name == "Shadow Camera")
			{
				camera = Camera.allCameras[i];
				break;
			}
		}
		if (camera != null)
		{
			Matrix4x4 matrix = camera.projectionMatrix * camera.worldToCameraMatrix * base.renderer.localToWorldMatrix;
			base.renderer.material.SetMatrix("_LocalToShadowMatrix", matrix);
		}
	}
}
