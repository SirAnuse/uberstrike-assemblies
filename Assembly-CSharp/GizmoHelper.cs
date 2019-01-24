using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000229 RID: 553
public class GizmoHelper : AutoMonoBehaviour<GizmoHelper>
{
	// Token: 0x06000F3E RID: 3902 RVA: 0x0006441C File Offset: 0x0006261C
	public void AddGizmo(Vector3 position, Color color, GizmoHelper.GizmoType type = GizmoHelper.GizmoType.Sphere, float size = 0.1f)
	{
		Debug.Log("AddGizmo " + position);
		this.gizmos.Add(new GizmoHelper.Gizmo
		{
			Position = position,
			Type = type,
			Size = size,
			Color = color
		});
	}

	// Token: 0x06000F3F RID: 3903 RVA: 0x00064470 File Offset: 0x00062670
	private void OnDrawGizmos()
	{
		if (this.CollisionTest.Size > 0f)
		{
			Gizmos.color = this.CollisionTest.Color;
			Gizmos.DrawSphere(this.CollisionTest.Position, this.CollisionTest.Size);
		}
		foreach (GizmoHelper.Gizmo gizmo in this.gizmos)
		{
			Gizmos.color = gizmo.Color;
			GizmoHelper.GizmoType type = gizmo.Type;
			if (type != GizmoHelper.GizmoType.Cube)
			{
				if (type != GizmoHelper.GizmoType.Sphere)
				{
					Gizmos.DrawSphere(gizmo.Position, gizmo.Size);
				}
				else
				{
					Gizmos.DrawSphere(gizmo.Position, gizmo.Size);
				}
			}
			else
			{
				Gizmos.DrawCube(gizmo.Position, Vector3.one * gizmo.Size);
			}
		}
		Gizmos.color = Color.white;
	}

	// Token: 0x04000D79 RID: 3449
	[SerializeField]
	private List<GizmoHelper.Gizmo> gizmos = new List<GizmoHelper.Gizmo>();

	// Token: 0x04000D7A RID: 3450
	public GizmoHelper.Gizmo CollisionTest = new GizmoHelper.Gizmo
	{
		Color = Color.red,
		Type = GizmoHelper.GizmoType.Sphere
	};

	// Token: 0x0200022A RID: 554
	public enum GizmoType
	{
		// Token: 0x04000D7C RID: 3452
		Cube,
		// Token: 0x04000D7D RID: 3453
		Sphere,
		// Token: 0x04000D7E RID: 3454
		WiredSphere
	}

	// Token: 0x0200022B RID: 555
	[Serializable]
	public class Gizmo
	{
		// Token: 0x04000D7F RID: 3455
		public GizmoHelper.GizmoType Type;

		// Token: 0x04000D80 RID: 3456
		public Vector3 Position;

		// Token: 0x04000D81 RID: 3457
		public float Size;

		// Token: 0x04000D82 RID: 3458
		public Color Color;
	}
}
