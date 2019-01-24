using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000EA RID: 234
public class ExplosionDebug : AutoMonoBehaviour<ExplosionDebug>
{
	// Token: 0x060007E4 RID: 2020 RVA: 0x0000700F File Offset: 0x0000520F
	public void Reset()
	{
		this.Hits.Clear();
		this.Protections.Clear();
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x0003648C File Offset: 0x0003468C
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(this.ImpactPoint, this.Radius);
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(this.TestPoint, 0.1f);
		for (int i = 0; i < this.Hits.Count; i++)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(this.Hits[i], 0.1f);
		}
		for (int j = 0; j < this.Protections.Count; j++)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(this.Protections[j].Start, this.Protections[j].End);
		}
	}

	// Token: 0x040006BF RID: 1727
	public Vector3 ImpactPoint;

	// Token: 0x040006C0 RID: 1728
	public Vector3 TestPoint;

	// Token: 0x040006C1 RID: 1729
	public float Radius;

	// Token: 0x040006C2 RID: 1730
	public List<Vector3> Hits = new List<Vector3>();

	// Token: 0x040006C3 RID: 1731
	public List<ExplosionDebug.Line> Protections = new List<ExplosionDebug.Line>();

	// Token: 0x020000EB RID: 235
	public struct Line
	{
		// Token: 0x060007E6 RID: 2022 RVA: 0x00007027 File Offset: 0x00005227
		public Line(Vector3 start, Vector3 end)
		{
			this.Start = start;
			this.End = end;
		}

		// Token: 0x040006C4 RID: 1732
		public Vector3 Start;

		// Token: 0x040006C5 RID: 1733
		public Vector3 End;
	}
}
