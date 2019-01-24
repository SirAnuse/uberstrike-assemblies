using System;
using UnityEngine;

// Token: 0x02000027 RID: 39
[AddComponentMenu("NGUI/Interaction/Forward Events")]
public class UIForwardEvents : MonoBehaviour
{
	// Token: 0x060000C9 RID: 201 RVA: 0x00002AF8 File Offset: 0x00000CF8
	private void OnHover(bool isOver)
	{
		if (this.onHover && this.target != null)
		{
			this.target.SendMessage("OnHover", isOver, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00002B2D File Offset: 0x00000D2D
	private void OnPress(bool pressed)
	{
		if (this.onPress && this.target != null)
		{
			this.target.SendMessage("OnPress", pressed, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00002B62 File Offset: 0x00000D62
	private void OnClick()
	{
		if (this.onClick && this.target != null)
		{
			this.target.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00002B91 File Offset: 0x00000D91
	private void OnDoubleClick()
	{
		if (this.onDoubleClick && this.target != null)
		{
			this.target.SendMessage("OnDoubleClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00002BC0 File Offset: 0x00000DC0
	private void OnSelect(bool selected)
	{
		if (this.onSelect && this.target != null)
		{
			this.target.SendMessage("OnSelect", selected, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00002BF5 File Offset: 0x00000DF5
	private void OnDrag(Vector2 delta)
	{
		if (this.onDrag && this.target != null)
		{
			this.target.SendMessage("OnDrag", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00002C2A File Offset: 0x00000E2A
	private void OnDrop(GameObject go)
	{
		if (this.onDrop && this.target != null)
		{
			this.target.SendMessage("OnDrop", go, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00002C5A File Offset: 0x00000E5A
	private void OnInput(string text)
	{
		if (this.onInput && this.target != null)
		{
			this.target.SendMessage("OnInput", text, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00002C8A File Offset: 0x00000E8A
	private void OnSubmit()
	{
		if (this.onSubmit && this.target != null)
		{
			this.target.SendMessage("OnSubmit", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00002CB9 File Offset: 0x00000EB9
	private void OnScroll(float delta)
	{
		if (this.onScroll && this.target != null)
		{
			this.target.SendMessage("OnScroll", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x040000F4 RID: 244
	public GameObject target;

	// Token: 0x040000F5 RID: 245
	public bool onHover;

	// Token: 0x040000F6 RID: 246
	public bool onPress;

	// Token: 0x040000F7 RID: 247
	public bool onClick;

	// Token: 0x040000F8 RID: 248
	public bool onDoubleClick;

	// Token: 0x040000F9 RID: 249
	public bool onSelect;

	// Token: 0x040000FA RID: 250
	public bool onDrag;

	// Token: 0x040000FB RID: 251
	public bool onDrop;

	// Token: 0x040000FC RID: 252
	public bool onInput;

	// Token: 0x040000FD RID: 253
	public bool onSubmit;

	// Token: 0x040000FE RID: 254
	public bool onScroll;
}
