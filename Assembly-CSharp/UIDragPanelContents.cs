using System;
using UnityEngine;

// Token: 0x02000020 RID: 32
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Drag Panel Contents")]
public class UIDragPanelContents : MonoBehaviour
{
	// Token: 0x06000098 RID: 152 RVA: 0x00017FF8 File Offset: 0x000161F8
	private void Awake()
	{
		if (this.panel != null)
		{
			if (this.draggablePanel == null)
			{
				this.draggablePanel = this.panel.GetComponent<UIDraggablePanel>();
				if (this.draggablePanel == null)
				{
					this.draggablePanel = this.panel.gameObject.AddComponent<UIDraggablePanel>();
				}
			}
			this.panel = null;
		}
	}

	// Token: 0x06000099 RID: 153 RVA: 0x0000291A File Offset: 0x00000B1A
	private void Start()
	{
		if (this.draggablePanel == null)
		{
			this.draggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		}
	}

	// Token: 0x0600009A RID: 154 RVA: 0x0000293E File Offset: 0x00000B3E
	private void OnPress(bool pressed)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggablePanel != null)
		{
			this.draggablePanel.Press(pressed);
		}
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00002978 File Offset: 0x00000B78
	private void OnDrag(Vector2 delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggablePanel != null)
		{
			this.draggablePanel.Drag();
		}
	}

	// Token: 0x0600009C RID: 156 RVA: 0x000029B1 File Offset: 0x00000BB1
	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggablePanel != null)
		{
			this.draggablePanel.Scroll(delta);
		}
	}

	// Token: 0x040000C0 RID: 192
	public UIDraggablePanel draggablePanel;

	// Token: 0x040000C1 RID: 193
	[HideInInspector]
	[SerializeField]
	private UIPanel panel;
}
