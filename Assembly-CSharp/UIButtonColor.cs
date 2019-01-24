using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
[AddComponentMenu("NGUI/Interaction/Button Color")]
public class UIButtonColor : MonoBehaviour
{
	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000034 RID: 52 RVA: 0x0000233F File Offset: 0x0000053F
	// (set) Token: 0x06000035 RID: 53 RVA: 0x00002358 File Offset: 0x00000558
	public Color defaultColor
	{
		get
		{
			if (!this.mStarted)
			{
				this.Init();
			}
			return this.mColor;
		}
		set
		{
			this.mColor = value;
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00002361 File Offset: 0x00000561
	private void Start()
	{
		if (!this.mStarted)
		{
			this.Init();
			this.mStarted = true;
		}
	}

	// Token: 0x06000037 RID: 55 RVA: 0x0000237B File Offset: 0x0000057B
	protected virtual void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00016228 File Offset: 0x00014428
	private void OnDisable()
	{
		if (this.mStarted && this.tweenTarget != null)
		{
			TweenColor component = this.tweenTarget.GetComponent<TweenColor>();
			if (component != null)
			{
				component.color = this.mColor;
				component.enabled = false;
			}
		}
	}

	// Token: 0x06000039 RID: 57 RVA: 0x0001627C File Offset: 0x0001447C
	protected void Init()
	{
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.gameObject;
		}
		UIWidget component = this.tweenTarget.GetComponent<UIWidget>();
		if (component != null)
		{
			this.mColor = component.color;
		}
		else
		{
			Renderer renderer = this.tweenTarget.renderer;
			if (renderer != null)
			{
				this.mColor = renderer.material.color;
			}
			else
			{
				Light light = this.tweenTarget.light;
				if (light != null)
				{
					this.mColor = light.color;
				}
				else
				{
					Debug.LogWarning(NGUITools.GetHierarchy(base.gameObject) + " has nothing for UIButtonColor to color", this);
					base.enabled = false;
				}
			}
		}
		this.OnEnable();
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00016350 File Offset: 0x00014550
	public virtual void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenColor.Begin(this.tweenTarget, this.duration, (!isPressed) ? ((!UICamera.IsHighlighted(base.gameObject)) ? this.mColor : this.hover) : this.pressed);
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x000163C0 File Offset: 0x000145C0
	public virtual void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenColor.Begin(this.tweenTarget, this.duration, (!isOver) ? this.mColor : this.hover);
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x04000041 RID: 65
	public GameObject tweenTarget;

	// Token: 0x04000042 RID: 66
	public Color hover = new Color(0.6f, 1f, 0.2f, 1f);

	// Token: 0x04000043 RID: 67
	public Color pressed = Color.grey;

	// Token: 0x04000044 RID: 68
	public float duration = 0.2f;

	// Token: 0x04000045 RID: 69
	protected Color mColor;

	// Token: 0x04000046 RID: 70
	protected bool mStarted;

	// Token: 0x04000047 RID: 71
	protected bool mHighlighted;
}
