using System;
using UnityEngine;

// Token: 0x0200005A RID: 90
public class UIGeometry
{
	// Token: 0x17000043 RID: 67
	// (get) Token: 0x0600023D RID: 573 RVA: 0x00003991 File Offset: 0x00001B91
	public bool hasVertices
	{
		get
		{
			return this.verts.size > 0;
		}
	}

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x0600023E RID: 574 RVA: 0x000039A1 File Offset: 0x00001BA1
	public bool hasTransformed
	{
		get
		{
			return this.mRtpVerts != null && this.mRtpVerts.size > 0 && this.mRtpVerts.size == this.verts.size;
		}
	}

	// Token: 0x0600023F RID: 575 RVA: 0x000039DA File Offset: 0x00001BDA
	public void Clear()
	{
		this.verts.Clear();
		this.uvs.Clear();
		this.cols.Clear();
		this.mRtpVerts.Clear();
	}

	// Token: 0x06000240 RID: 576 RVA: 0x00020120 File Offset: 0x0001E320
	public void ApplyOffset(Vector3 pivotOffset)
	{
		for (int i = 0; i < this.verts.size; i++)
		{
			this.verts.buffer[i] += pivotOffset;
		}
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0002016C File Offset: 0x0001E36C
	public void ApplyTransform(Matrix4x4 widgetToPanel, bool normals)
	{
		if (this.verts.size > 0)
		{
			this.mRtpVerts.Clear();
			int i = 0;
			int size = this.verts.size;
			while (i < size)
			{
				this.mRtpVerts.Add(widgetToPanel.MultiplyPoint3x4(this.verts[i]));
				i++;
			}
			this.mRtpNormal = widgetToPanel.MultiplyVector(Vector3.back).normalized;
			Vector3 normalized = widgetToPanel.MultiplyVector(Vector3.right).normalized;
			this.mRtpTan = new Vector4(normalized.x, normalized.y, normalized.z, -1f);
		}
		else
		{
			this.mRtpVerts.Clear();
		}
	}

	// Token: 0x06000242 RID: 578 RVA: 0x00020238 File Offset: 0x0001E438
	public void WriteToBuffers(BetterList<Vector3> v, BetterList<Vector2> u, BetterList<Color32> c, BetterList<Vector3> n, BetterList<Vector4> t)
	{
		if (this.mRtpVerts != null && this.mRtpVerts.size > 0)
		{
			if (n == null)
			{
				for (int i = 0; i < this.mRtpVerts.size; i++)
				{
					v.Add(this.mRtpVerts.buffer[i]);
					u.Add(this.uvs.buffer[i]);
					c.Add(this.cols.buffer[i]);
				}
			}
			else
			{
				for (int j = 0; j < this.mRtpVerts.size; j++)
				{
					v.Add(this.mRtpVerts.buffer[j]);
					u.Add(this.uvs.buffer[j]);
					c.Add(this.cols.buffer[j]);
					n.Add(this.mRtpNormal);
					t.Add(this.mRtpTan);
				}
			}
		}
	}

	// Token: 0x040001EE RID: 494
	public BetterList<Vector3> verts = new BetterList<Vector3>();

	// Token: 0x040001EF RID: 495
	public BetterList<Vector2> uvs = new BetterList<Vector2>();

	// Token: 0x040001F0 RID: 496
	public BetterList<Color32> cols = new BetterList<Color32>();

	// Token: 0x040001F1 RID: 497
	private BetterList<Vector3> mRtpVerts = new BetterList<Vector3>();

	// Token: 0x040001F2 RID: 498
	private Vector3 mRtpNormal;

	// Token: 0x040001F3 RID: 499
	private Vector4 mRtpTan;
}
