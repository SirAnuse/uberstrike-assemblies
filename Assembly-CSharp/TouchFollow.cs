using System;
using System.Collections;
using UnityEngine;

// Token: 0x020003B5 RID: 949
public class TouchFollow : TouchBaseControl
{
	// Token: 0x06001BCC RID: 7116 RVA: 0x000126BB File Offset: 0x000108BB
	public TouchFollow()
	{
		this._finger = new TouchFinger();
		this._ignoreTouches = new ArrayList();
	}

	// Token: 0x14000020 RID: 32
	// (add) Token: 0x06001BCD RID: 7117 RVA: 0x000126D9 File Offset: 0x000108D9
	// (remove) Token: 0x06001BCE RID: 7118 RVA: 0x000126F2 File Offset: 0x000108F2
	public event Action OnFired;

	// Token: 0x17000628 RID: 1576
	// (get) Token: 0x06001BCF RID: 7119 RVA: 0x0001270B File Offset: 0x0001090B
	// (set) Token: 0x06001BD0 RID: 7120 RVA: 0x00012713 File Offset: 0x00010913
	public Vector2 Aim { get; private set; }

	// Token: 0x17000629 RID: 1577
	// (get) Token: 0x06001BD1 RID: 7121 RVA: 0x0001271C File Offset: 0x0001091C
	// (set) Token: 0x06001BD2 RID: 7122 RVA: 0x00012724 File Offset: 0x00010924
	public override bool Enabled
	{
		get
		{
			return this.enabled;
		}
		set
		{
			if (this.enabled != value)
			{
				this.enabled = value;
				if (this.enabled)
				{
					this.Aim = Vector2.zero;
					this._finger = new TouchFinger();
				}
			}
		}
	}

	// Token: 0x06001BD3 RID: 7123 RVA: 0x0008E558 File Offset: 0x0008C758
	public override void UpdateTouches(Touch touch)
	{
		if (touch.phase == TouchPhase.Began)
		{
			if (this._finger.FingerId == -1)
			{
				this._finger = new TouchFinger
				{
					StartPos = touch.position,
					StartTouchTime = Time.time,
					LastPos = touch.position,
					FingerId = touch.fingerId
				};
				this._totalMoved = 0f;
			}
		}
		else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
		{
			if (this._finger.FingerId == touch.fingerId)
			{
				this.Aim = touch.deltaPosition * 500f / (float)Screen.width;
				this._totalMoved += Mathf.Abs(touch.deltaPosition.x) + Mathf.Abs(touch.deltaPosition.y);
			}
		}
		else if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && this._finger.FingerId == touch.fingerId)
		{
			if (this._totalMoved < 10f && this.OnFired != null)
			{
				this.OnFired();
			}
			this._finger.Reset();
			this.Aim = Vector2.zero;
		}
	}

	// Token: 0x06001BD4 RID: 7124 RVA: 0x0001275A File Offset: 0x0001095A
	public void IgnoreRect(Rect r)
	{
		if (!this._ignoreTouches.Contains(r))
		{
			this._ignoreTouches.Add(r);
		}
	}

	// Token: 0x06001BD5 RID: 7125 RVA: 0x0008E6CC File Offset: 0x0008C8CC
	private bool ValidArea(Vector2 pos)
	{
		if (this._ignoreTouches.Count == 0)
		{
			return true;
		}
		foreach (object obj in this._ignoreTouches)
		{
			Rect rect = (Rect)obj;
			if (rect.ContainsTouch(pos))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x040018C9 RID: 6345
	private bool enabled;

	// Token: 0x040018CA RID: 6346
	private TouchFinger _finger;

	// Token: 0x040018CB RID: 6347
	private ArrayList _ignoreTouches;

	// Token: 0x040018CC RID: 6348
	private float _totalMoved;
}
