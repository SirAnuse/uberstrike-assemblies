using System;
using UnityEngine;

// Token: 0x02000009 RID: 9
[AddComponentMenu("NGUI/Interaction/Button")]
public class UIButton : UIButtonColor
{
	// Token: 0x06000029 RID: 41 RVA: 0x0000227F File Offset: 0x0000047F
	protected override void OnEnable()
	{
		if (this.isEnabled)
		{
			base.OnEnable();
		}
		else
		{
			this.UpdateColor(false, true);
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x0000229F File Offset: 0x0000049F
	public override void OnHover(bool isOver)
	{
		if (this.isEnabled)
		{
			if (isOver && this.OnHovered != null)
			{
				this.OnHovered();
			}
			base.OnHover(isOver);
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x0001608C File Offset: 0x0001428C
	public override void OnPress(bool isPressed)
	{
		if (this.isEnabled)
		{
			if (isPressed)
			{
				if (this.OnPressed != null)
				{
					this.OnPressed();
				}
			}
			else if (this.OnRelease != null)
			{
				this.OnRelease();
			}
			base.OnPress(isPressed);
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x0600002C RID: 44 RVA: 0x000160E4 File Offset: 0x000142E4
	// (set) Token: 0x0600002D RID: 45 RVA: 0x0001610C File Offset: 0x0001430C
	public bool isEnabled
	{
		get
		{
			Collider collider = base.collider;
			return collider && collider.enabled;
		}
		set
		{
			Collider collider = base.collider;
			if (!collider)
			{
				return;
			}
			if (collider.enabled != value)
			{
				collider.enabled = value;
				this.UpdateColor(value, false);
			}
		}
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00016148 File Offset: 0x00014348
	public void UpdateColor(bool shouldBeEnabled, bool immediate)
	{
		if (this.tweenTarget)
		{
			if (!this.mStarted)
			{
				this.mStarted = true;
				base.Init();
			}
			Color color = (!shouldBeEnabled) ? this.disabledColor : base.defaultColor;
			TweenColor tweenColor = TweenColor.Begin(this.tweenTarget, 0.15f, color);
			if (immediate)
			{
				tweenColor.color = color;
				tweenColor.enabled = false;
			}
		}
	}

	// Token: 0x04000038 RID: 56
	public Color disabledColor = Color.grey;

	// Token: 0x04000039 RID: 57
	public Action OnPressed;

	// Token: 0x0400003A RID: 58
	public Action OnRelease;

	// Token: 0x0400003B RID: 59
	public Action OnHovered;
}
