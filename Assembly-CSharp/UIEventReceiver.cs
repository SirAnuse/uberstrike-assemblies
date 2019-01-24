using System;
using UnityEngine;

// Token: 0x02000354 RID: 852
[AddComponentMenu("NGUI/CMune Extensions/Event Receiver")]
[ExecuteInEditMode]
public class UIEventReceiver : MonoBehaviour
{
	// Token: 0x060017B1 RID: 6065 RVA: 0x0000FE81 File Offset: 0x0000E081
	private void OnHover(bool isOver)
	{
		if (this.OnHovered != null && base.enabled)
		{
			this.OnHovered(isOver);
		}
	}

	// Token: 0x060017B2 RID: 6066 RVA: 0x0000FEA5 File Offset: 0x0000E0A5
	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (this.OnPressed != null)
			{
				this.OnPressed(isPressed);
			}
			if (!isPressed && this.OnReleased != null)
			{
				this.OnReleased();
			}
		}
	}

	// Token: 0x060017B3 RID: 6067 RVA: 0x0000FEE5 File Offset: 0x0000E0E5
	private void OnSelect(bool selected)
	{
		if (this.OnSelected != null && base.enabled)
		{
			this.OnSelected(selected);
		}
	}

	// Token: 0x060017B4 RID: 6068 RVA: 0x0000FF09 File Offset: 0x0000E109
	private void OnClick()
	{
		if (this.OnClicked != null && base.enabled)
		{
			this.OnClicked();
		}
	}

	// Token: 0x060017B5 RID: 6069 RVA: 0x0000FF2C File Offset: 0x0000E12C
	private void OnDrag(Vector2 delta)
	{
		if (this.OnDragging != null && base.enabled)
		{
			this.OnDragging(delta);
		}
	}

	// Token: 0x060017B6 RID: 6070 RVA: 0x0000FF50 File Offset: 0x0000E150
	private void OnInput(string text)
	{
		if (this.OnInputEntered != null && base.enabled)
		{
			this.OnInputEntered(text);
		}
	}

	// Token: 0x060017B7 RID: 6071 RVA: 0x0000FF74 File Offset: 0x0000E174
	private void OnKey(KeyCode key)
	{
		if (this.OnKeyEntered != null && base.enabled)
		{
			this.OnKeyEntered(key);
		}
	}

	// Token: 0x060017B8 RID: 6072 RVA: 0x00003C87 File Offset: 0x00001E87
	private void OnTooltip(bool show)
	{
	}

	// Token: 0x04001690 RID: 5776
	public Action<bool> OnHovered;

	// Token: 0x04001691 RID: 5777
	public Action<bool> OnPressed;

	// Token: 0x04001692 RID: 5778
	public Action OnReleased;

	// Token: 0x04001693 RID: 5779
	public Action<bool> OnSelected;

	// Token: 0x04001694 RID: 5780
	public Action OnClicked;

	// Token: 0x04001695 RID: 5781
	public Action<Vector2> OnDragging;

	// Token: 0x04001696 RID: 5782
	public Action<string> OnInputEntered;

	// Token: 0x04001697 RID: 5783
	public Action<KeyCode> OnKeyEntered;

	// Token: 0x04001698 RID: 5784
	public Action<bool> OnTooltipActive;
}
