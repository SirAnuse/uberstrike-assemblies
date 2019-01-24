using System;
using UnityEngine;

// Token: 0x02000368 RID: 872
public class MeshContainer
{
	// Token: 0x06001483 RID: 5251 RVA: 0x0000CBB8 File Offset: 0x0000ADB8
	public MeshContainer(Mesh m)
	{
		this.mesh = m;
		this.vertices = m.vertices;
		this.normals = m.normals;
	}

	// Token: 0x06001484 RID: 5252 RVA: 0x0000CBDF File Offset: 0x0000ADDF
	public void Update()
	{
		this.mesh.vertices = this.vertices;
		this.mesh.normals = this.normals;
	}

	// Token: 0x04000E95 RID: 3733
	public Mesh mesh;

	// Token: 0x04000E96 RID: 3734
	public Vector3[] vertices;

	// Token: 0x04000E97 RID: 3735
	public Vector3[] normals;
}
