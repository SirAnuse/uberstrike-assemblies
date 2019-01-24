using System;
using System.Collections;
using UnityEngine;

// Token: 0x020003B7 RID: 951
public class TouchShooter : TouchBaseControl
{
	// Token: 0x06001BDA RID: 7130 RVA: 0x0008E750 File Offset: 0x0008C950
	public TouchShooter()
	{
		this._primaryFinger = new TouchFinger();
		this._secondaryFinger = new TouchFinger();
		this._ignoreTouches = new ArrayList();
	}

	// Token: 0x14000021 RID: 33
	// (add) Token: 0x06001BDB RID: 7131 RVA: 0x000127B5 File Offset: 0x000109B5
	// (remove) Token: 0x06001BDC RID: 7132 RVA: 0x000127CE File Offset: 0x000109CE
	public event Action<Vector2> OnDoubleTap;

	// Token: 0x14000022 RID: 34
	// (add) Token: 0x06001BDD RID: 7133 RVA: 0x000127E7 File Offset: 0x000109E7
	// (remove) Token: 0x06001BDE RID: 7134 RVA: 0x00012800 File Offset: 0x00010A00
	public event Action OnFireStart;

	// Token: 0x14000023 RID: 35
	// (add) Token: 0x06001BDF RID: 7135 RVA: 0x00012819 File Offset: 0x00010A19
	// (remove) Token: 0x06001BE0 RID: 7136 RVA: 0x00012832 File Offset: 0x00010A32
	public event Action OnFireEnd;

	// Token: 0x1700062A RID: 1578
	// (get) Token: 0x06001BE1 RID: 7137 RVA: 0x0001284B File Offset: 0x00010A4B
	// (set) Token: 0x06001BE2 RID: 7138 RVA: 0x00012853 File Offset: 0x00010A53
	public Vector2 Aim { get; private set; }

	// Token: 0x1700062B RID: 1579
	// (get) Token: 0x06001BE3 RID: 7139 RVA: 0x0001285C File Offset: 0x00010A5C
	// (set) Token: 0x06001BE4 RID: 7140 RVA: 0x0008E7A8 File Offset: 0x0008C9A8
	public override bool Enabled
	{
		get
		{
			return this.enabled;
		}
		set
		{
			if (value != this.enabled)
			{
				this.enabled = value;
				if (!this.enabled)
				{
					this._primaryFinger = new TouchFinger();
					this._secondaryFinger = new TouchFinger();
					this.Aim = Vector2.zero;
				}
			}
		}
	}

	// Token: 0x06001BE5 RID: 7141 RVA: 0x0008E7F4 File Offset: 0x0008C9F4
	public override void UpdateTouches(Touch touch)
	{
		if (touch.phase == TouchPhase.Began && this.Boundary.ContainsTouch(touch.position) && this.ValidArea(touch.position))
		{
			if (this._primaryFinger.FingerId == -1)
			{
				this._primaryFinger = new TouchFinger
				{
					StartPos = touch.position,
					StartTouchTime = Time.time,
					LastPos = touch.position,
					FingerId = touch.fingerId
				};
				if (this._lastFireTouch + this.SecondaryFireTapDelay > Time.time && (this._lastFirePosition - touch.position).sqrMagnitude < this.SecondaryFireTapMaxDistanceSqr)
				{
					if (this.OnDoubleTap != null)
					{
						this.OnDoubleTap(touch.position);
					}
				}
				else
				{
					this._lastFireTouch = Time.time;
					this._lastFirePosition = touch.position;
				}
			}
			else if (this._primaryFinger.FingerId != touch.fingerId && this._secondaryFinger.FingerId == -1)
			{
				this._secondaryFinger = new TouchFinger
				{
					StartPos = touch.position,
					StartTouchTime = Time.time,
					LastPos = touch.position,
					FingerId = touch.fingerId
				};
				if (this.OnFireStart != null)
				{
					this.OnFireStart();
				}
			}
		}
		else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
		{
			if (this._primaryFinger.FingerId == touch.fingerId)
			{
				this.Aim = touch.deltaPosition * 500f / (float)Screen.width;
			}
		}
		else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
		{
			if (this._primaryFinger.FingerId == touch.fingerId)
			{
				this._primaryFinger.Reset();
				this.Aim = Vector2.zero;
			}
			else if (this._secondaryFinger.FingerId == touch.fingerId)
			{
				if (this.OnFireEnd != null)
				{
					this.OnFireEnd();
				}
				this._secondaryFinger.Reset();
			}
		}
	}

	// Token: 0x06001BE6 RID: 7142 RVA: 0x00012864 File Offset: 0x00010A64
	public void IgnoreRect(Rect r)
	{
		if (!this._ignoreTouches.Contains(r))
		{
			this._ignoreTouches.Add(r);
		}
	}

	// Token: 0x06001BE7 RID: 7143 RVA: 0x0001288E File Offset: 0x00010A8E
	public void UnignoreRect(Rect r)
	{
		if (this._ignoreTouches.Contains(r))
		{
			this._ignoreTouches.Remove(r);
		}
	}

	// Token: 0x06001BE8 RID: 7144 RVA: 0x0008EA60 File Offset: 0x0008CC60
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

	// Token: 0x040018D9 RID: 6361
	public float SecondaryFireTapDelay = 0.4f;

	// Token: 0x040018DA RID: 6362
	public float SecondaryFireTapMaxDistanceSqr = 10000f;

	// Token: 0x040018DB RID: 6363
	private bool enabled;

	// Token: 0x040018DC RID: 6364
	private TouchFinger _primaryFinger;

	// Token: 0x040018DD RID: 6365
	private TouchFinger _secondaryFinger;

	// Token: 0x040018DE RID: 6366
	private float _lastFireTouch;

	// Token: 0x040018DF RID: 6367
	private Vector2 _lastFirePosition = Vector2.zero;

	// Token: 0x040018E0 RID: 6368
	private ArrayList _ignoreTouches;
}
