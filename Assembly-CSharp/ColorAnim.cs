using System;
using UnityEngine;

// Token: 0x0200022F RID: 559
public class ColorAnim
{
	// Token: 0x06000F6F RID: 3951 RVA: 0x0000AFBC File Offset: 0x000091BC
	public ColorAnim(ColorAnim.OnValueChange onColorChange = null)
	{
		this._isAnimating = false;
		if (onColorChange != null)
		{
			this._onColorChange = onColorChange;
		}
	}

	// Token: 0x1700039B RID: 923
	// (get) Token: 0x06000F70 RID: 3952 RVA: 0x0000AFD8 File Offset: 0x000091D8
	// (set) Token: 0x06000F71 RID: 3953 RVA: 0x00064DE8 File Offset: 0x00062FE8
	public Color Color
	{
		get
		{
			return this._color;
		}
		set
		{
			Color color = this._color;
			this._color = value;
			if (this._onColorChange != null)
			{
				this._onColorChange(color, this._color);
			}
		}
	}

	// Token: 0x1700039C RID: 924
	// (get) Token: 0x06000F72 RID: 3954 RVA: 0x0000AFE0 File Offset: 0x000091E0
	public bool IsAnimating
	{
		get
		{
			return this._isAnimating;
		}
	}

	// Token: 0x1700039D RID: 925
	// (get) Token: 0x06000F73 RID: 3955 RVA: 0x0000AFE8 File Offset: 0x000091E8
	// (set) Token: 0x06000F74 RID: 3956 RVA: 0x00064E20 File Offset: 0x00063020
	public float Alpha
	{
		get
		{
			return this._color.a;
		}
		set
		{
			Color color = this._color;
			this._color.a = value;
			if (this._onColorChange != null)
			{
				this._onColorChange(color, this._color);
			}
		}
	}

	// Token: 0x06000F75 RID: 3957 RVA: 0x00064E60 File Offset: 0x00063060
	public void Update()
	{
		if (this._isAnimating)
		{
			float num = Time.time - this._animStartTime;
			if (num <= this._animTime)
			{
				float t = Mathf.Clamp01(num * (1f / this._animTime));
				this.Color = Color.Lerp(this._animSrc, this._animDest, Mathfx.Ease(t, this._animEaseType));
				this.Alpha = this.Color.a;
			}
			else
			{
				this.Color = this._animDest;
				this.Alpha = this.Color.a;
				this._isAnimating = false;
			}
		}
	}

	// Token: 0x06000F76 RID: 3958 RVA: 0x00064F08 File Offset: 0x00063108
	public void FadeAlphaTo(float destAlpha, float time = 0f, EaseType easeType = EaseType.None)
	{
		if (time <= 0f)
		{
			this.Alpha = destAlpha;
			return;
		}
		this._isAnimating = true;
		this._animSrc = this.Color;
		this._animDest = this.Color;
		this._animDest.a = destAlpha;
		this._animTime = time;
		this._animEaseType = easeType;
		this._animStartTime = Time.time;
	}

	// Token: 0x06000F77 RID: 3959 RVA: 0x00064F6C File Offset: 0x0006316C
	public void FadeAlpha(float deltaAlpha, float time = 0f, EaseType easeType = EaseType.None)
	{
		float destAlpha = this.Color.a + deltaAlpha;
		this.FadeAlphaTo(destAlpha, time, easeType);
	}

	// Token: 0x06000F78 RID: 3960 RVA: 0x00064F94 File Offset: 0x00063194
	public void FadeColorTo(Color destColor, float time = 0f, EaseType easeType = EaseType.None)
	{
		if (time <= 0f)
		{
			this.Color = destColor;
			return;
		}
		this._isAnimating = true;
		this._animSrc = this.Color;
		this._animDest = destColor;
		this._animTime = time;
		this._animEaseType = easeType;
		this._animStartTime = Time.time;
	}

	// Token: 0x06000F79 RID: 3961 RVA: 0x00064FE8 File Offset: 0x000631E8
	public void FadeColor(Color deltaColor, float time = 0f, EaseType easeType = EaseType.None)
	{
		Color destColor = this.Color + deltaColor;
		this.FadeColorTo(destColor, time, easeType);
	}

	// Token: 0x06000F7A RID: 3962 RVA: 0x0000AFF5 File Offset: 0x000091F5
	public void StopFading()
	{
		this._isAnimating = false;
	}

	// Token: 0x04000D9A RID: 3482
	private Color _color;

	// Token: 0x04000D9B RID: 3483
	private ColorAnim.OnValueChange _onColorChange;

	// Token: 0x04000D9C RID: 3484
	private bool _isAnimating;

	// Token: 0x04000D9D RID: 3485
	private Color _animSrc;

	// Token: 0x04000D9E RID: 3486
	private Color _animDest;

	// Token: 0x04000D9F RID: 3487
	private float _animTime;

	// Token: 0x04000DA0 RID: 3488
	private float _animStartTime;

	// Token: 0x04000DA1 RID: 3489
	private EaseType _animEaseType;

	// Token: 0x02000230 RID: 560
	// (Invoke) Token: 0x06000F7C RID: 3964
	public delegate void OnValueChange(Color oldValue, Color newValue);
}
