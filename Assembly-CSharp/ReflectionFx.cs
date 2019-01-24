using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200014B RID: 331
public class ReflectionFx : MonoBehaviour
{
	// Token: 0x060008A7 RID: 2215 RVA: 0x00037DE4 File Offset: 0x00035FE4
	private void Start()
	{
		this.initialReflectionTextures = new Texture2D[this.reflectiveMaterials.Length];
		for (int i = 0; i < this.reflectiveMaterials.Length; i++)
		{
			this.initialReflectionTextures[i] = this.reflectiveMaterials[i].GetTexture(this.reflectionSampler);
		}
		if (!SystemInfo.supportsRenderTextures)
		{
			base.enabled = false;
		}
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x00037E4C File Offset: 0x0003604C
	private void OnDisable()
	{
		if (this.initialReflectionTextures == null)
		{
			return;
		}
		for (int i = 0; i < this.reflectiveMaterials.Length; i++)
		{
			this.reflectiveMaterials[i].SetTexture(this.reflectionSampler, this.initialReflectionTextures[i]);
		}
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x00037E9C File Offset: 0x0003609C
	private void LateUpdate()
	{
		Transform x = null;
		float num = float.PositiveInfinity;
		Vector3 position = Camera.main.transform.position;
		foreach (Transform transform in this.reflectiveObjects)
		{
			if (transform.renderer.isVisible)
			{
				float sqrMagnitude = (position - transform.position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					x = transform;
				}
			}
		}
		if (x == null)
		{
			return;
		}
		this.reflectiveSurfaceHeight = x;
		this.RenderHelpCameras(Camera.main);
		if (this.helperCameras != null)
		{
			this.helperCameras.Clear();
		}
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x00037F54 File Offset: 0x00036154
	public void RenderHelpCameras(Camera currentCam)
	{
		if (this.helperCameras == null)
		{
			this.helperCameras = new Dictionary<Camera, bool>();
		}
		if (!this.helperCameras.ContainsKey(currentCam))
		{
			this.helperCameras.Add(currentCam, false);
		}
		if (this.helperCameras[currentCam])
		{
			return;
		}
		if (this.reflectionCamera == null)
		{
			this.reflectionCamera = this.CreateReflectionCameraFor(currentCam);
			foreach (Material material in this.reflectiveMaterials)
			{
				material.SetTexture(this.reflectionSampler, this.reflectionCamera.targetTexture);
			}
		}
		this.RenderReflectionFor(currentCam, this.reflectionCamera);
		this.helperCameras[currentCam] = true;
	}

	// Token: 0x060008AB RID: 2219 RVA: 0x00038018 File Offset: 0x00036218
	private void RenderReflectionFor(Camera cam, Camera reflectCamera)
	{
		if (reflectCamera == null)
		{
			return;
		}
		this.SaneCameraSettings(reflectCamera);
		reflectCamera.backgroundColor = this.clearColor;
		reflectCamera.enabled = true;
		GL.SetRevertBackfacing(true);
		Transform transform = this.reflectiveSurfaceHeight;
		Vector3 eulerAngles = cam.transform.eulerAngles;
		reflectCamera.transform.eulerAngles = new Vector3(-eulerAngles.x, eulerAngles.y, eulerAngles.z);
		reflectCamera.transform.position = cam.transform.position;
		Vector3 position = transform.transform.position;
		position.y = transform.position.y;
		Vector3 up = transform.transform.up;
		float w = -Vector3.Dot(up, position) - this.clipPlaneOffset;
		Vector4 plane = new Vector4(up.x, up.y, up.z, w);
		Matrix4x4 matrix4x = Matrix4x4.zero;
		matrix4x = ReflectionFx.CalculateReflectionMatrix(matrix4x, plane);
		this.oldpos = cam.transform.position;
		Vector3 position2 = matrix4x.MultiplyPoint(this.oldpos);
		reflectCamera.worldToCameraMatrix = cam.worldToCameraMatrix * matrix4x;
		Vector4 clipPlane = this.CameraSpacePlane(reflectCamera, position, up, 1f);
		Matrix4x4 matrix4x2 = cam.projectionMatrix;
		matrix4x2 = ReflectionFx.CalculateObliqueMatrix(matrix4x2, clipPlane);
		reflectCamera.projectionMatrix = matrix4x2;
		reflectCamera.transform.position = position2;
		Vector3 eulerAngles2 = cam.transform.eulerAngles;
		reflectCamera.transform.eulerAngles = new Vector3(-eulerAngles2.x, eulerAngles2.y, eulerAngles2.z);
		reflectCamera.RenderWithShader(this.replacementShader, "Reflection");
		GL.SetRevertBackfacing(false);
	}

	// Token: 0x060008AC RID: 2220 RVA: 0x000381C8 File Offset: 0x000363C8
	private Camera CreateReflectionCameraFor(Camera cam)
	{
		string text = base.gameObject.name + "Reflection" + cam.name;
		Debug.Log("Created internal reflection camera " + text);
		GameObject gameObject = GameObject.Find(text);
		if (!gameObject)
		{
			gameObject = new GameObject(text, new Type[]
			{
				typeof(Camera)
			});
		}
		if (!gameObject.GetComponent(typeof(Camera)))
		{
			gameObject.AddComponent(typeof(Camera));
		}
		Camera camera = gameObject.camera;
		camera.backgroundColor = this.clearColor;
		camera.clearFlags = CameraClearFlags.Color;
		this.SetStandardCameraParameter(camera, this.reflectionMask);
		if (!camera.targetTexture)
		{
			camera.targetTexture = this.CreateTextureFor(cam);
		}
		return camera;
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x000382A0 File Offset: 0x000364A0
	private RenderTexture CreateTextureFor(Camera cam)
	{
		RenderTextureFormat format = RenderTextureFormat.RGB565;
		if (!SystemInfo.SupportsRenderTextureFormat(format))
		{
			format = RenderTextureFormat.Default;
		}
		float num = 0.5f;
		return new RenderTexture(Mathf.FloorToInt(cam.pixelWidth * num), Mathf.FloorToInt(cam.pixelHeight * num), 24, format)
		{
			hideFlags = HideFlags.DontSave
		};
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x00007607 File Offset: 0x00005807
	private void SaneCameraSettings(Camera helperCam)
	{
		helperCam.depthTextureMode = DepthTextureMode.None;
		helperCam.backgroundColor = Color.black;
		helperCam.clearFlags = CameraClearFlags.Color;
		helperCam.renderingPath = RenderingPath.Forward;
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x00007629 File Offset: 0x00005829
	private void SetStandardCameraParameter(Camera cam, LayerMask mask)
	{
		cam.backgroundColor = Color.black;
		cam.enabled = false;
		cam.cullingMask = this.reflectionMask;
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x000382F0 File Offset: 0x000364F0
	private static Matrix4x4 CalculateObliqueMatrix(Matrix4x4 projection, Vector4 clipPlane)
	{
		Vector4 b = projection.inverse * new Vector4(ReflectionFx.sgn(clipPlane.x), ReflectionFx.sgn(clipPlane.y), 1f, 1f);
		Vector4 vector = clipPlane * (2f / Vector4.Dot(clipPlane, b));
		projection[2] = vector.x - projection[3];
		projection[6] = vector.y - projection[7];
		projection[10] = vector.z - projection[11];
		projection[14] = vector.w - projection[15];
		return projection;
	}

	// Token: 0x060008B1 RID: 2225 RVA: 0x000383AC File Offset: 0x000365AC
	private static Matrix4x4 CalculateReflectionMatrix(Matrix4x4 reflectionMat, Vector4 plane)
	{
		reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
		reflectionMat.m01 = -2f * plane[0] * plane[1];
		reflectionMat.m02 = -2f * plane[0] * plane[2];
		reflectionMat.m03 = -2f * plane[3] * plane[0];
		reflectionMat.m10 = -2f * plane[1] * plane[0];
		reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
		reflectionMat.m12 = -2f * plane[1] * plane[2];
		reflectionMat.m13 = -2f * plane[3] * plane[1];
		reflectionMat.m20 = -2f * plane[2] * plane[0];
		reflectionMat.m21 = -2f * plane[2] * plane[1];
		reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
		reflectionMat.m23 = -2f * plane[3] * plane[2];
		reflectionMat.m30 = 0f;
		reflectionMat.m31 = 0f;
		reflectionMat.m32 = 0f;
		reflectionMat.m33 = 1f;
		return reflectionMat;
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x0000764E File Offset: 0x0000584E
	private static float sgn(float a)
	{
		if (a > 0f)
		{
			return 1f;
		}
		if (a < 0f)
		{
			return -1f;
		}
		return 0f;
	}

	// Token: 0x060008B3 RID: 2227 RVA: 0x00038564 File Offset: 0x00036764
	private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		Vector3 v = pos + normal * this.clipPlaneOffset;
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(v);
		Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(rhs.x, rhs.y, rhs.z, -Vector3.Dot(lhs, rhs));
	}

	// Token: 0x040008F9 RID: 2297
	public Transform[] reflectiveObjects;

	// Token: 0x040008FA RID: 2298
	public LayerMask reflectionMask;

	// Token: 0x040008FB RID: 2299
	public Material[] reflectiveMaterials;

	// Token: 0x040008FC RID: 2300
	private Transform reflectiveSurfaceHeight;

	// Token: 0x040008FD RID: 2301
	public Shader replacementShader;

	// Token: 0x040008FE RID: 2302
	public Color clearColor = Color.black;

	// Token: 0x040008FF RID: 2303
	public string reflectionSampler = "_ReflectionTex";

	// Token: 0x04000900 RID: 2304
	public float clipPlaneOffset = 0.07f;

	// Token: 0x04000901 RID: 2305
	private Vector3 oldpos = Vector3.zero;

	// Token: 0x04000902 RID: 2306
	private Camera reflectionCamera;

	// Token: 0x04000903 RID: 2307
	private Dictionary<Camera, bool> helperCameras;

	// Token: 0x04000904 RID: 2308
	private Texture[] initialReflectionTextures;
}
