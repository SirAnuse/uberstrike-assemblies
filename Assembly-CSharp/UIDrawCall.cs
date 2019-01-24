using System;
using UnityEngine;

// Token: 0x02000050 RID: 80
[AddComponentMenu("NGUI/Internal/Draw Call")]
[ExecuteInEditMode]
public class UIDrawCall : MonoBehaviour
{
	// Token: 0x1700003B RID: 59
	// (get) Token: 0x06000201 RID: 513 RVA: 0x0000372F File Offset: 0x0000192F
	// (set) Token: 0x06000202 RID: 514 RVA: 0x00003737 File Offset: 0x00001937
	public bool depthPass
	{
		get
		{
			return this.mDepthPass;
		}
		set
		{
			if (this.mDepthPass != value)
			{
				this.mDepthPass = value;
				this.mReset = true;
			}
		}
	}

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x06000203 RID: 515 RVA: 0x00003753 File Offset: 0x00001953
	public Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x06000204 RID: 516 RVA: 0x00003778 File Offset: 0x00001978
	// (set) Token: 0x06000205 RID: 517 RVA: 0x00003780 File Offset: 0x00001980
	public Material material
	{
		get
		{
			return this.mSharedMat;
		}
		set
		{
			this.mSharedMat = value;
		}
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x06000206 RID: 518 RVA: 0x0001F8C8 File Offset: 0x0001DAC8
	public int triangles
	{
		get
		{
			Mesh mesh = (!this.mEven) ? this.mMesh1 : this.mMesh0;
			return (!(mesh != null)) ? 0 : (mesh.vertexCount >> 1);
		}
	}

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x06000207 RID: 519 RVA: 0x00003789 File Offset: 0x00001989
	public bool isClipped
	{
		get
		{
			return this.mClippedMat != null;
		}
	}

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x06000208 RID: 520 RVA: 0x00003797 File Offset: 0x00001997
	// (set) Token: 0x06000209 RID: 521 RVA: 0x0000379F File Offset: 0x0000199F
	public UIDrawCall.Clipping clipping
	{
		get
		{
			return this.mClipping;
		}
		set
		{
			if (this.mClipping != value)
			{
				this.mClipping = value;
				this.mReset = true;
			}
		}
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x0600020A RID: 522 RVA: 0x000037BB File Offset: 0x000019BB
	// (set) Token: 0x0600020B RID: 523 RVA: 0x000037C3 File Offset: 0x000019C3
	public Vector4 clipRange
	{
		get
		{
			return this.mClipRange;
		}
		set
		{
			this.mClipRange = value;
		}
	}

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x0600020C RID: 524 RVA: 0x000037CC File Offset: 0x000019CC
	// (set) Token: 0x0600020D RID: 525 RVA: 0x000037D4 File Offset: 0x000019D4
	public Vector2 clipSoftness
	{
		get
		{
			return this.mClipSoft;
		}
		set
		{
			this.mClipSoft = value;
		}
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0001F90C File Offset: 0x0001DB0C
	private Mesh GetMesh(ref bool rebuildIndices, int vertexCount)
	{
		this.mEven = !this.mEven;
		if (this.mEven)
		{
			if (this.mMesh0 == null)
			{
				this.mMesh0 = new Mesh();
				this.mMesh0.hideFlags = HideFlags.DontSave;
				this.mMesh0.name = "Mesh0 for " + this.mSharedMat.name;
				this.mMesh0.MarkDynamic();
				rebuildIndices = true;
			}
			else if (rebuildIndices || this.mMesh0.vertexCount != vertexCount)
			{
				rebuildIndices = true;
				this.mMesh0.Clear();
			}
			return this.mMesh0;
		}
		if (this.mMesh1 == null)
		{
			this.mMesh1 = new Mesh();
			this.mMesh1.hideFlags = HideFlags.DontSave;
			this.mMesh1.name = "Mesh1 for " + this.mSharedMat.name;
			this.mMesh1.MarkDynamic();
			rebuildIndices = true;
		}
		else if (rebuildIndices || this.mMesh1.vertexCount != vertexCount)
		{
			rebuildIndices = true;
			this.mMesh1.Clear();
		}
		return this.mMesh1;
	}

	// Token: 0x0600020F RID: 527 RVA: 0x0001FA44 File Offset: 0x0001DC44
	private void UpdateMaterials()
	{
		bool flag = this.mClipping != UIDrawCall.Clipping.None;
		if (flag)
		{
			Shader shader = null;
			if (this.mClipping != UIDrawCall.Clipping.None)
			{
				string text = this.mSharedMat.shader.name;
				text = text.Replace(" (AlphaClip)", string.Empty);
				text = text.Replace(" (SoftClip)", string.Empty);
				if (this.mClipping == UIDrawCall.Clipping.HardClip || this.mClipping == UIDrawCall.Clipping.AlphaClip)
				{
					shader = Shader.Find(text + " (AlphaClip)");
				}
				else if (this.mClipping == UIDrawCall.Clipping.SoftClip)
				{
					shader = Shader.Find(text + " (SoftClip)");
				}
				if (shader == null)
				{
					this.mClipping = UIDrawCall.Clipping.None;
				}
			}
			if (shader != null)
			{
				if (this.mClippedMat == null)
				{
					this.mClippedMat = new Material(this.mSharedMat);
					this.mClippedMat.hideFlags = HideFlags.DontSave;
				}
				this.mClippedMat.shader = shader;
				this.mClippedMat.CopyPropertiesFromMaterial(this.mSharedMat);
			}
			else if (this.mClippedMat != null)
			{
				NGUITools.Destroy(this.mClippedMat);
				this.mClippedMat = null;
			}
		}
		else if (this.mClippedMat != null)
		{
			NGUITools.Destroy(this.mClippedMat);
			this.mClippedMat = null;
		}
		if (this.mDepthPass)
		{
			if (this.mDepthMat == null)
			{
				Shader shader2 = Shader.Find("Unlit/Depth Cutout");
				this.mDepthMat = new Material(shader2);
				this.mDepthMat.hideFlags = HideFlags.DontSave;
			}
			this.mDepthMat.mainTexture = this.mSharedMat.mainTexture;
		}
		else if (this.mDepthMat != null)
		{
			NGUITools.Destroy(this.mDepthMat);
			this.mDepthMat = null;
		}
		Material material = (!(this.mClippedMat != null)) ? this.mSharedMat : this.mClippedMat;
		if (this.mDepthMat != null)
		{
			if (this.mRen.sharedMaterials != null && this.mRen.sharedMaterials.Length == 2 && this.mRen.sharedMaterials[1] == material)
			{
				return;
			}
			this.mRen.sharedMaterials = new Material[]
			{
				this.mDepthMat,
				material
			};
		}
		else if (this.mRen.sharedMaterial != material)
		{
			this.mRen.sharedMaterials = new Material[]
			{
				material
			};
		}
	}

	// Token: 0x06000210 RID: 528 RVA: 0x0001FCF4 File Offset: 0x0001DEF4
	public void Set(BetterList<Vector3> verts, BetterList<Vector3> norms, BetterList<Vector4> tans, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		int size = verts.size;
		if (size > 0 && size == uvs.size && size == cols.size && size % 4 == 0)
		{
			if (this.mFilter == null)
			{
				this.mFilter = base.gameObject.GetComponent<MeshFilter>();
			}
			if (this.mFilter == null)
			{
				this.mFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			if (this.mRen == null)
			{
				this.mRen = base.gameObject.GetComponent<MeshRenderer>();
			}
			if (this.mRen == null)
			{
				this.mRen = base.gameObject.AddComponent<MeshRenderer>();
				this.UpdateMaterials();
			}
			else if (this.mClippedMat != null && this.mClippedMat.mainTexture != this.mSharedMat.mainTexture)
			{
				this.UpdateMaterials();
			}
			if (verts.size < 65000)
			{
				int num = (size >> 1) * 3;
				bool flag = this.mIndices == null || this.mIndices.Length != num;
				if (flag)
				{
					this.mIndices = new int[num];
					int num2 = 0;
					for (int i = 0; i < size; i += 4)
					{
						this.mIndices[num2++] = i;
						this.mIndices[num2++] = i + 1;
						this.mIndices[num2++] = i + 2;
						this.mIndices[num2++] = i + 2;
						this.mIndices[num2++] = i + 3;
						this.mIndices[num2++] = i;
					}
				}
				Mesh mesh = this.GetMesh(ref flag, verts.size);
				mesh.vertices = verts.ToArray();
				if (norms != null)
				{
					mesh.normals = norms.ToArray();
				}
				if (tans != null)
				{
					mesh.tangents = tans.ToArray();
				}
				mesh.uv = uvs.ToArray();
				mesh.colors32 = cols.ToArray();
				if (flag)
				{
					mesh.triangles = this.mIndices;
				}
				mesh.RecalculateBounds();
				this.mFilter.mesh = mesh;
			}
			else
			{
				if (this.mFilter.mesh != null)
				{
					this.mFilter.mesh.Clear();
				}
				Debug.LogError("Too many vertices on one panel: " + verts.size);
			}
		}
		else
		{
			if (this.mFilter.mesh != null)
			{
				this.mFilter.mesh.Clear();
			}
			Debug.LogError("UIWidgets must fill the buffer with 4 vertices per quad. Found " + size);
		}
	}

	// Token: 0x06000211 RID: 529 RVA: 0x0001FFC0 File Offset: 0x0001E1C0
	private void OnWillRenderObject()
	{
		if (this.mReset)
		{
			this.mReset = false;
			this.UpdateMaterials();
		}
		if (this.mClippedMat != null)
		{
			this.mClippedMat.mainTextureOffset = new Vector2(-this.mClipRange.x / this.mClipRange.z, -this.mClipRange.y / this.mClipRange.w);
			this.mClippedMat.mainTextureScale = new Vector2(1f / this.mClipRange.z, 1f / this.mClipRange.w);
			Vector2 v = new Vector2(1000f, 1000f);
			if (this.mClipSoft.x > 0f)
			{
				v.x = this.mClipRange.z / this.mClipSoft.x;
			}
			if (this.mClipSoft.y > 0f)
			{
				v.y = this.mClipRange.w / this.mClipSoft.y;
			}
			this.mClippedMat.SetVector("_ClipSharpness", v);
		}
	}

	// Token: 0x06000212 RID: 530 RVA: 0x000037DD File Offset: 0x000019DD
	private void OnDestroy()
	{
		NGUITools.DestroyImmediate(this.mMesh0);
		NGUITools.DestroyImmediate(this.mMesh1);
		NGUITools.DestroyImmediate(this.mClippedMat);
		NGUITools.DestroyImmediate(this.mDepthMat);
	}

	// Token: 0x040001CE RID: 462
	private Transform mTrans;

	// Token: 0x040001CF RID: 463
	private Material mSharedMat;

	// Token: 0x040001D0 RID: 464
	private Mesh mMesh0;

	// Token: 0x040001D1 RID: 465
	private Mesh mMesh1;

	// Token: 0x040001D2 RID: 466
	private MeshFilter mFilter;

	// Token: 0x040001D3 RID: 467
	private MeshRenderer mRen;

	// Token: 0x040001D4 RID: 468
	private UIDrawCall.Clipping mClipping;

	// Token: 0x040001D5 RID: 469
	private Vector4 mClipRange;

	// Token: 0x040001D6 RID: 470
	private Vector2 mClipSoft;

	// Token: 0x040001D7 RID: 471
	private Material mClippedMat;

	// Token: 0x040001D8 RID: 472
	private Material mDepthMat;

	// Token: 0x040001D9 RID: 473
	private int[] mIndices;

	// Token: 0x040001DA RID: 474
	private bool mDepthPass;

	// Token: 0x040001DB RID: 475
	private bool mReset = true;

	// Token: 0x040001DC RID: 476
	private bool mEven = true;

	// Token: 0x02000051 RID: 81
	public enum Clipping
	{
		// Token: 0x040001DE RID: 478
		None,
		// Token: 0x040001DF RID: 479
		HardClip,
		// Token: 0x040001E0 RID: 480
		AlphaClip,
		// Token: 0x040001E1 RID: 481
		SoftClip
	}
}
