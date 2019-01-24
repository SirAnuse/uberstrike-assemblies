using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
[AddComponentMenu("NGUI/Interaction/Button Message")]
public class UIButtonMessage : MonoBehaviour
{
	// Token: 0x06000043 RID: 67 RVA: 0x00002409 File Offset: 0x00000609
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002412 File Offset: 0x00000612
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000045 RID: 69 RVA: 0x0000243B File Offset: 0x0000063B
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if ((isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOver) || (!isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOut))
			{
				this.Send();
			}
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002479 File Offset: 0x00000679
	private void OnPress(bool isPressed)
	{
		if (base.enabled && ((isPressed && this.trigger == UIButtonMessage.Trigger.OnPress) || (!isPressed && this.trigger == UIButtonMessage.Trigger.OnRelease)))
		{
			this.Send();
		}
	}

	// Token: 0x06000047 RID: 71 RVA: 0x000024B0 File Offset: 0x000006B0
	private void OnClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnClick)
		{
			this.Send();
		}
	}

	// Token: 0x06000048 RID: 72 RVA: 0x000024CE File Offset: 0x000006CE
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnDoubleClick)
		{
			this.Send();
		}
	}

	// Token: 0x06000049 RID: 73 RVA: 0x000166CC File Offset: 0x000148CC
	private void Send()
	{
		if (string.IsNullOrEmpty(this.functionName))
		{
			return;
		}
		if (this.target == null)
		{
			this.target = base.gameObject;
		}
		if (this.includeChildren)
		{
			Transform[] componentsInChildren = this.target.GetComponentsInChildren<Transform>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				Transform transform = componentsInChildren[i];
				transform.gameObject.SendMessage(this.functionName, base.gameObject, SendMessageOptions.DontRequireReceiver);
				i++;
			}
		}
		else
		{
			this.target.SendMessage(this.functionName, base.gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x0400004F RID: 79
	public GameObject target;

	// Token: 0x04000050 RID: 80
	public string functionName;

	// Token: 0x04000051 RID: 81
	public UIButtonMessage.Trigger trigger;

	// Token: 0x04000052 RID: 82
	public bool includeChildren;

	// Token: 0x04000053 RID: 83
	private bool mStarted;

	// Token: 0x04000054 RID: 84
	private bool mHighlighted;

	// Token: 0x02000010 RID: 16
	public enum Trigger
	{
		// Token: 0x04000056 RID: 86
		OnClick,
		// Token: 0x04000057 RID: 87
		OnMouseOver,
		// Token: 0x04000058 RID: 88
		OnMouseOut,
		// Token: 0x04000059 RID: 89
		OnPress,
		// Token: 0x0400005A RID: 90
		OnRelease,
		// Token: 0x0400005B RID: 91
		OnDoubleClick
	}
}
