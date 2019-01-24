using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000369 RID: 873
[RequireComponent(typeof(WaterBase))]
[ExecuteInEditMode]
public class PlanarReflection : MonoBehaviour
{
	// Token: 0x06001486 RID: 5254 RVA: 0x0000CC37 File Offset: 0x0000AE37
	public void Start()
	{
		this.sharedMaterial = ((WaterBase)base.gameObject.GetComponent(typeof(WaterBase))).sharedMaterial;
	}

	// Token: 0x06001487 RID: 5255 RVA: 0x00026774 File Offset: 0x00024974
	private Camera CreateReflectionCameraFor(Camera cam)
	{
		string name = base.gameObject.name + "Reflection" + cam.name;
		GameObject gameObject = GameObject.Find(name);
		if (!gameObject)
		{
			gameObject = new GameObject(name, new Type[]
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
		camera.clearFlags = ((!this.reflectSkybox) ? CameraClearFlags.Color : CameraClearFlags.Skybox);
		this.SetStandardCameraParameter(camera, this.reflectionMask);
		if (!camera.targetTexture)
		{
			camera.targetTexture = this.CreateTextureFor(cam);
		}
		return camera;
	}

	// Token: 0x06001488 RID: 5256 RVA: 0x0000CC5E File Offset: 0x0000AE5E
	private void SetStandardCameraParameter(Camera cam, LayerMask mask)
	{
		cam.cullingMask = (mask & ~(1 << LayerMask.NameToLayer("Water")));
		cam.backgroundColor = Color.black;
		cam.enabled = false;
	}

	// Token: 0x06001489 RID: 5257 RVA: 0x0002684C File Offset: 0x00024A4C
	private RenderTexture CreateTextureFor(Camera cam)
	{
		return new RenderTexture(Mathf.FloorToInt(cam.pixelWidth * 0.5f), Mathf.FloorToInt(cam.pixelHeight * 0.5f), 24)
		{
			hideFlags = HideFlags.DontSave
		};
	}

	// Token: 0x0600148A RID: 5258 RVA: 0x0002688C File Offset: 0x00024A8C
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
		if (!this.reflectionCamera)
		{
			this.reflectionCamera = this.CreateReflectionCameraFor(currentCam);
		}
		this.RenderReflectionFor(currentCam, this.reflectionCamera);
		this.helperCameras[currentCam] = true;
	}

	// Token: 0x0600148B RID: 5259 RVA: 0x0000CC8F File Offset: 0x0000AE8F
	public void LateUpdate()
	{
		if (this.helperCameras != null)
		{
			this.helperCameras.Clear();
		}
	}

	// Token: 0x0600148C RID: 5260 RVA: 0x00026918 File Offset: 0x00024B18
	public void WaterTileBeingRendered(Transform tr, Camera currentCam)
	{
		this.RenderHelpCameras(currentCam);
		if (this.reflectionCamera && this.sharedMaterial)
		{
			this.sharedMaterial.SetTexture(this.reflectionSampler, this.reflectionCamera.targetTexture);
		}
	}

	// Token: 0x0600148D RID: 5261 RVA: 0x0000CCA7 File Offset: 0x0000AEA7
	public void OnEnable()
	{
		Shader.EnableKeyword("WATER_REFLECTIVE");
		Shader.DisableKeyword("WATER_SIMPLE");
	}

	// Token: 0x0600148E RID: 5262 RVA: 0x0000CCBD File Offset: 0x0000AEBD
	public void OnDisable()
	{
		Shader.EnableKeyword("WATER_SIMPLE");
		Shader.DisableKeyword("WATER_REFLECTIVE");
	}

	// Token: 0x0600148F RID: 5263 RVA: 0x00026968 File Offset: 0x00024B68
	private void RenderReflectionFor(Camera cam, Camera reflectCamera)
	{
		if (!reflectCamera)
		{
			return;
		}
		if (this.sharedMaterial && !this.sharedMaterial.HasProperty(this.reflectionSampler))
		{
			return;
		}
		reflectCamera.cullingMask = (this.reflectionMask & ~(1 << LayerMask.NameToLayer("Water")));
		this.SaneCameraSettings(reflectCamera);
		reflectCamera.backgroundColor = this.clearColor;
		reflectCamera.clearFlags = ((!this.reflectSkybox) ? CameraClearFlags.Color : CameraClearFlags.Skybox);
		if (this.reflectSkybox && cam.gameObject.GetComponent(typeof(Skybox)))
		{
			Skybox skybox = (Skybox)reflectCamera.gameObject.GetComponent(typeof(Skybox));
			if (!skybox)
			{
				skybox = (Skybox)reflectCamera.gameObject.AddComponent(typeof(Skybox));
			}
			skybox.material = ((Skybox)cam.GetComponent(typeof(Skybox))).material;
		}
		GL.SetRevertBackfacing(true);
		Transform transform = base.transform;
		Vector3 eulerAngles = cam.transform.eulerAngles;
		reflectCamera.transform.eulerAngles = new Vector3(-eulerAngles.x, eulerAngles.y, eulerAngles.z);
		reflectCamera.transform.position = cam.transform.position;
		Vector3 position = transform.transform.position;
		position.y = transform.position.y;
		Vector3 up = transform.transform.up;
		float w = -Vector3.Dot(up, position) - this.clipPlaneOffset;
		Vector4 plane = new Vector4(up.x, up.y, up.z, w);
		Matrix4x4 matrix4x = Matrix4x4.zero;
		matrix4x = PlanarReflection.CalculateReflectionMatrix(matrix4x, plane);
		this.oldpos = cam.transform.position;
		Vector3 position2 = matrix4x.MultiplyPoint(this.oldpos);
		reflectCamera.worldToCameraMatrix = cam.worldToCameraMatrix * matrix4x;
		Vector4 clipPlane = this.CameraSpacePlane(reflectCamera, position, up, 1f);
		Matrix4x4 matrix4x2 = cam.projectionMatrix;
		matrix4x2 = PlanarReflection.CalculateObliqueMatrix(matrix4x2, clipPlane);
		reflectCamera.projectionMatrix = matrix4x2;
		reflectCamera.transform.position = position2;
		Vector3 eulerAngles2 = cam.transform.eulerAngles;
		reflectCamera.transform.eulerAngles = new Vector3(-eulerAngles2.x, eulerAngles2.y, eulerAngles2.z);
		reflectCamera.Render();
		GL.SetRevertBackfacing(false);
	}

	// Token: 0x06001490 RID: 5264 RVA: 0x0000CCD3 File Offset: 0x0000AED3
	private void SaneCameraSettings(Camera helperCam)
	{
		helperCam.depthTextureMode = DepthTextureMode.None;
		helperCam.backgroundColor = Color.black;
		helperCam.clearFlags = CameraClearFlags.Color;
		helperCam.renderingPath = RenderingPath.Forward;
	}

	// Token: 0x06001491 RID: 5265 RVA: 0x00026BF4 File Offset: 0x00024DF4
	private static Matrix4x4 CalculateObliqueMatrix(Matrix4x4 projection, Vector4 clipPlane)
	{
		Vector4 b = projection.inverse * new Vector4(PlanarReflection.sgn(clipPlane.x), PlanarReflection.sgn(clipPlane.y), 1f, 1f);
		Vector4 vector = clipPlane * (2f / Vector4.Dot(clipPlane, b));
		projection[2] = vector.x - projection[3];
		projection[6] = vector.y - projection[7];
		projection[10] = vector.z - projection[11];
		projection[14] = vector.w - projection[15];
		return projection;
	}

	// Token: 0x06001492 RID: 5266 RVA: 0x00026CB0 File Offset: 0x00024EB0
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

	// Token: 0x06001493 RID: 5267 RVA: 0x0000CB3D File Offset: 0x0000AD3D
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

	// Token: 0x06001494 RID: 5268 RVA: 0x00026E68 File Offset: 0x00025068
	private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
	{
		Vector3 v = pos + normal * this.clipPlaneOffset;
		Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
		Vector3 lhs = worldToCameraMatrix.MultiplyPoint(v);
		Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
		return new Vector4(rhs.x, rhs.y, rhs.z, -Vector3.Dot(lhs, rhs));
	}

	// Token: 0x04000E98 RID: 3736
	public LayerMask reflectionMask;

	// Token: 0x04000E99 RID: 3737
	public bool reflectSkybox;

	// Token: 0x04000E9A RID: 3738
	public Color clearColor = Color.grey;

	// Token: 0x04000E9B RID: 3739
	public string reflectionSampler = "_ReflectionTex";

	// Token: 0x04000E9C RID: 3740
	public float clipPlaneOffset = 0.07f;

	// Token: 0x04000E9D RID: 3741
	private Vector3 oldpos = Vector3.zero;

	// Token: 0x04000E9E RID: 3742
	private Camera reflectionCamera;

	// Token: 0x04000E9F RID: 3743
	private Material sharedMaterial;

	// Token: 0x04000EA0 RID: 3744
	private Dictionary<Camera, bool> helperCameras;
}
