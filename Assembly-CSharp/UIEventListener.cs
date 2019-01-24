using System;
using UnityEngine;

// Token: 0x02000052 RID: 82
[AddComponentMenu("NGUI/Internal/Event Listener")]
public class UIEventListener : MonoBehaviour
{
	// Token: 0x06000214 RID: 532 RVA: 0x0000380B File Offset: 0x00001A0B
	private void OnSubmit()
	{
		if (this.onSubmit != null)
		{
			this.onSubmit(base.gameObject);
		}
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00003829 File Offset: 0x00001A29
	private void OnClick()
	{
		if (this.onClick != null)
		{
			this.onClick(base.gameObject);
		}
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00003847 File Offset: 0x00001A47
	private void OnDoubleClick()
	{
		if (this.onDoubleClick != null)
		{
			this.onDoubleClick(base.gameObject);
		}
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00003865 File Offset: 0x00001A65
	private void OnHover(bool isOver)
	{
		if (this.onHover != null)
		{
			this.onHover(base.gameObject, isOver);
		}
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00003884 File Offset: 0x00001A84
	private void OnPress(bool isPressed)
	{
		if (this.onPress != null)
		{
			this.onPress(base.gameObject, isPressed);
		}
	}

	// Token: 0x06000219 RID: 537 RVA: 0x000038A3 File Offset: 0x00001AA3
	private void OnSelect(bool selected)
	{
		if (this.onSelect != null)
		{
			this.onSelect(base.gameObject, selected);
		}
	}

	// Token: 0x0600021A RID: 538 RVA: 0x000038C2 File Offset: 0x00001AC2
	private void OnScroll(float delta)
	{
		if (this.onScroll != null)
		{
			this.onScroll(base.gameObject, delta);
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x000038E1 File Offset: 0x00001AE1
	private void OnDrag(Vector2 delta)
	{
		if (this.onDrag != null)
		{
			this.onDrag(base.gameObject, delta);
		}
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00003900 File Offset: 0x00001B00
	private void OnDrop(GameObject go)
	{
		if (this.onDrop != null)
		{
			this.onDrop(base.gameObject, go);
		}
	}

	// Token: 0x0600021D RID: 541 RVA: 0x0000391F File Offset: 0x00001B1F
	private void OnInput(string text)
	{
		if (this.onInput != null)
		{
			this.onInput(base.gameObject, text);
		}
	}

	// Token: 0x0600021E RID: 542 RVA: 0x0000393E File Offset: 0x00001B3E
	private void OnKey(KeyCode key)
	{
		if (this.onKey != null)
		{
			this.onKey(base.gameObject, key);
		}
	}

	// Token: 0x0600021F RID: 543 RVA: 0x000200F8 File Offset: 0x0001E2F8
	public static UIEventListener Get(GameObject go)
	{
		UIEventListener uieventListener = go.GetComponent<UIEventListener>();
		if (uieventListener == null)
		{
			uieventListener = go.AddComponent<UIEventListener>();
		}
		return uieventListener;
	}

	// Token: 0x040001E2 RID: 482
	public object parameter;

	// Token: 0x040001E3 RID: 483
	public UIEventListener.VoidDelegate onSubmit;

	// Token: 0x040001E4 RID: 484
	public UIEventListener.VoidDelegate onClick;

	// Token: 0x040001E5 RID: 485
	public UIEventListener.VoidDelegate onDoubleClick;

	// Token: 0x040001E6 RID: 486
	public UIEventListener.BoolDelegate onHover;

	// Token: 0x040001E7 RID: 487
	public UIEventListener.BoolDelegate onPress;

	// Token: 0x040001E8 RID: 488
	public UIEventListener.BoolDelegate onSelect;

	// Token: 0x040001E9 RID: 489
	public UIEventListener.FloatDelegate onScroll;

	// Token: 0x040001EA RID: 490
	public UIEventListener.VectorDelegate onDrag;

	// Token: 0x040001EB RID: 491
	public UIEventListener.ObjectDelegate onDrop;

	// Token: 0x040001EC RID: 492
	public UIEventListener.StringDelegate onInput;

	// Token: 0x040001ED RID: 493
	public UIEventListener.KeyCodeDelegate onKey;

	// Token: 0x02000053 RID: 83
	// (Invoke) Token: 0x06000221 RID: 545
	public delegate void VoidDelegate(GameObject go);

	// Token: 0x02000054 RID: 84
	// (Invoke) Token: 0x06000225 RID: 549
	public delegate void BoolDelegate(GameObject go, bool state);

	// Token: 0x02000055 RID: 85
	// (Invoke) Token: 0x06000229 RID: 553
	public delegate void FloatDelegate(GameObject go, float delta);

	// Token: 0x02000056 RID: 86
	// (Invoke) Token: 0x0600022D RID: 557
	public delegate void VectorDelegate(GameObject go, Vector2 delta);

	// Token: 0x02000057 RID: 87
	// (Invoke) Token: 0x06000231 RID: 561
	public delegate void StringDelegate(GameObject go, string text);

	// Token: 0x02000058 RID: 88
	// (Invoke) Token: 0x06000235 RID: 565
	public delegate void ObjectDelegate(GameObject go, GameObject draggedObject);

	// Token: 0x02000059 RID: 89
	// (Invoke) Token: 0x06000239 RID: 569
	public delegate void KeyCodeDelegate(GameObject go, KeyCode key);
}
