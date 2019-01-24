using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
[AddComponentMenu("NGUI/Interaction/Drag Camera")]
[ExecuteInEditMode]
public class UIDragCamera : IgnoreTimeScale
{
	// Token: 0x0600008D RID: 141 RVA: 0x000179B4 File Offset: 0x00015BB4
	private void Awake()
	{
		if (this.target != null)
		{
			if (this.draggableCamera == null)
			{
				this.draggableCamera = this.target.GetComponent<UIDraggableCamera>();
				if (this.draggableCamera == null)
				{
					this.draggableCamera = this.target.gameObject.AddComponent<UIDraggableCamera>();
				}
			}
			this.target = null;
		}
		else if (this.draggableCamera == null)
		{
			this.draggableCamera = NGUITools.FindInParents<UIDraggableCamera>(base.gameObject);
		}
	}

	// Token: 0x0600008E RID: 142 RVA: 0x0000283C File Offset: 0x00000A3C
	private void OnPress(bool isPressed)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null)
		{
			this.draggableCamera.Press(isPressed);
		}
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00002876 File Offset: 0x00000A76
	private void OnDrag(Vector2 delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null)
		{
			this.draggableCamera.Drag(delta);
		}
	}

	// Token: 0x06000090 RID: 144 RVA: 0x000028B0 File Offset: 0x00000AB0
	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null)
		{
			this.draggableCamera.Scroll(delta);
		}
	}

	// Token: 0x040000AD RID: 173
	public UIDraggableCamera draggableCamera;

	// Token: 0x040000AE RID: 174
	[SerializeField]
	[HideInInspector]
	private Component target;
}
