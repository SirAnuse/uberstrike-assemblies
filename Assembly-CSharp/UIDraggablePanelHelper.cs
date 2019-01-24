using System;
using UnityEngine;

// Token: 0x02000026 RID: 38
public static class UIDraggablePanelHelper
{
	// Token: 0x060000C5 RID: 197 RVA: 0x00002ADA File Offset: 0x00000CDA
	public static void SpringToSelection(this UIDraggablePanel dragPanel, GameObject selectedObject, float springStrength)
	{
		dragPanel.SpringToPosition(selectedObject.transform.position, springStrength);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00002AEE File Offset: 0x00000CEE
	public static void SpringToSelection(this UIDraggablePanel dragPanel, Vector3 selectedPosition, float springStrength)
	{
		dragPanel.SpringToPosition(selectedPosition, springStrength);
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x000196C8 File Offset: 0x000178C8
	private static void SpringToPosition(this UIDraggablePanel dragPanel, Vector3 positionToSpring, float springStrength)
	{
		Vector4 clipRange = dragPanel.panel.clipRange;
		Transform cachedTransform = dragPanel.panel.cachedTransform;
		Vector3 position = cachedTransform.localPosition;
		position.x += clipRange.x;
		position.y += clipRange.y;
		position = cachedTransform.parent.TransformPoint(position);
		dragPanel.currentMomentum = Vector3.zero;
		Vector3 a = cachedTransform.InverseTransformPoint(positionToSpring);
		Vector3 b = cachedTransform.InverseTransformPoint(position);
		Vector3 b2 = a - b;
		if (dragPanel.scale.x == 0f)
		{
			b2.x = 0f;
		}
		if (dragPanel.scale.y == 0f)
		{
			b2.y = 0f;
		}
		if (dragPanel.scale.z == 0f)
		{
			b2.z = 0f;
		}
		SpringPanel.Begin(dragPanel.gameObject, cachedTransform.localPosition - b2, springStrength);
	}
}
