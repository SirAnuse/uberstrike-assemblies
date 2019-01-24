using System;
using UnityEngine;

// Token: 0x02000237 RID: 567
public class Vector2Anim
{
	// Token: 0x06000F9E RID: 3998 RVA: 0x0000B089 File Offset: 0x00009289
	public Vector2Anim(Action<Vector2, Vector2> onVec2Change = null)
	{
		this._isAnimating = false;
		if (onVec2Change != null)
		{
			this._onVec2Change = onVec2Change;
		}
	}

	// Token: 0x170003A6 RID: 934
	// (get) Token: 0x06000F9F RID: 3999 RVA: 0x0000B0A5 File Offset: 0x000092A5
	// (set) Token: 0x06000FA0 RID: 4000 RVA: 0x000651F8 File Offset: 0x000633F8
	public Vector2 Vec2
	{
		get
		{
			return this._vec2;
		}
		set
		{
			Vector2 vec = this._vec2;
			this._vec2 = value;
			if (this._onVec2Change != null)
			{
				this._onVec2Change(vec, this._vec2);
			}
		}
	}

	// Token: 0x170003A7 RID: 935
	// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x0000B0AD File Offset: 0x000092AD
	public bool IsAnimating
	{
		get
		{
			return this._isAnimating;
		}
	}

	// Token: 0x06000FA2 RID: 4002 RVA: 0x00065230 File Offset: 0x00063430
	public void Update()
	{
		if (this._isAnimating)
		{
			float num = Time.time - this._animStartTime;
			if (num <= this._animTime)
			{
				float t = Mathf.Clamp01(num * (1f / this._animTime));
				this.Vec2 = Vector2.Lerp(this._animSrc, this._animDest, Mathfx.Ease(t, this._animEaseType));
			}
			else
			{
				this.Vec2 = this._animDest;
				this._isAnimating = false;
			}
		}
	}

	// Token: 0x06000FA3 RID: 4003 RVA: 0x000652B0 File Offset: 0x000634B0
	public void AnimTo(Vector2 destPosition, float time = 0f, EaseType easeType = EaseType.None, float startDelay = 0f)
	{
		if (time <= 0f)
		{
			this.Vec2 = destPosition;
			return;
		}
		this._isAnimating = true;
		this._animSrc = this.Vec2;
		this._animDest = destPosition;
		this._animTime = time;
		this._animEaseType = easeType;
		this._animStartTime = Time.time + startDelay;
	}

	// Token: 0x06000FA4 RID: 4004 RVA: 0x00065308 File Offset: 0x00063508
	public void AnimBy(Vector2 deltaPosition, float time = 0f, EaseType easeType = EaseType.None)
	{
		Vector2 destPosition = this.Vec2 + deltaPosition;
		this.AnimTo(destPosition, time, easeType, 0f);
	}

	// Token: 0x06000FA5 RID: 4005 RVA: 0x0000B0B5 File Offset: 0x000092B5
	public void StopAnim()
	{
		this._isAnimating = false;
	}

	// Token: 0x04000DB1 RID: 3505
	private Vector2 _vec2;

	// Token: 0x04000DB2 RID: 3506
	private Action<Vector2, Vector2> _onVec2Change;

	// Token: 0x04000DB3 RID: 3507
	private bool _isAnimating;

	// Token: 0x04000DB4 RID: 3508
	private Vector2 _animSrc;

	// Token: 0x04000DB5 RID: 3509
	private Vector2 _animDest;

	// Token: 0x04000DB6 RID: 3510
	private float _animTime;

	// Token: 0x04000DB7 RID: 3511
	private float _animStartTime;

	// Token: 0x04000DB8 RID: 3512
	private EaseType _animEaseType;
}
