using System;
using UnityEngine;

// Token: 0x020003B2 RID: 946
public class TouchControl : TouchBaseControl
{
	// Token: 0x06001BB3 RID: 7091 RVA: 0x000124CF File Offset: 0x000106CF
	public TouchControl()
	{
		this.finger = new TouchFinger();
	}

	// Token: 0x1400001B RID: 27
	// (add) Token: 0x06001BB4 RID: 7092 RVA: 0x000124ED File Offset: 0x000106ED
	// (remove) Token: 0x06001BB5 RID: 7093 RVA: 0x00012506 File Offset: 0x00010706
	public event Action<Vector2> OnTouchBegan;

	// Token: 0x1400001C RID: 28
	// (add) Token: 0x06001BB6 RID: 7094 RVA: 0x0001251F File Offset: 0x0001071F
	// (remove) Token: 0x06001BB7 RID: 7095 RVA: 0x00012538 File Offset: 0x00010738
	public event Action<Vector2, Vector2> OnTouchLeftBoundary;

	// Token: 0x1400001D RID: 29
	// (add) Token: 0x06001BB8 RID: 7096 RVA: 0x00012551 File Offset: 0x00010751
	// (remove) Token: 0x06001BB9 RID: 7097 RVA: 0x0001256A File Offset: 0x0001076A
	public event Action<Vector2, Vector2> OnTouchMoved;

	// Token: 0x1400001E RID: 30
	// (add) Token: 0x06001BBA RID: 7098 RVA: 0x00012583 File Offset: 0x00010783
	// (remove) Token: 0x06001BBB RID: 7099 RVA: 0x0001259C File Offset: 0x0001079C
	public event Action<Vector2, Vector2> OnTouchEnteredBoundary;

	// Token: 0x1400001F RID: 31
	// (add) Token: 0x06001BBC RID: 7100 RVA: 0x000125B5 File Offset: 0x000107B5
	// (remove) Token: 0x06001BBD RID: 7101 RVA: 0x000125CE File Offset: 0x000107CE
	public event Action<Vector2> OnTouchEnded;

	// Token: 0x17000626 RID: 1574
	// (get) Token: 0x06001BBE RID: 7102 RVA: 0x000125E7 File Offset: 0x000107E7
	// (set) Token: 0x06001BBF RID: 7103 RVA: 0x000125EF File Offset: 0x000107EF
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
					this.finger.Reset();
					this._inside = false;
				}
			}
		}
	}

	// Token: 0x17000627 RID: 1575
	// (get) Token: 0x06001BC0 RID: 7104 RVA: 0x00012621 File Offset: 0x00010821
	public bool IsActive
	{
		get
		{
			return this.finger.FingerId != -1;
		}
	}

	// Token: 0x06001BC1 RID: 7105 RVA: 0x00012634 File Offset: 0x00010834
	public void SetRotation(float angle, Vector2 point)
	{
		this._rotationAngle = angle;
		this._rotationPoint = point;
	}

	// Token: 0x06001BC2 RID: 7106 RVA: 0x0008E1EC File Offset: 0x0008C3EC
	public override void UpdateTouches(Touch touch)
	{
		if (this.finger.FingerId != -1 && touch.fingerId != this.finger.FingerId)
		{
			return;
		}
		if (this.finger.FingerId == -1 && touch.phase != TouchPhase.Began)
		{
			return;
		}
		Vector2 vector = touch.position;
		if (this._rotationAngle != 0f)
		{
			vector = Mathfx.RotateVector2AboutPoint(touch.position, new Vector2(this._rotationPoint.x, (float)Screen.height - this._rotationPoint.y), -this._rotationAngle);
		}
		switch (touch.phase)
		{
		case TouchPhase.Began:
			if (this.TouchInside(vector))
			{
				this.finger.StartPos = vector;
				this.finger.LastPos = vector;
				this.finger.StartTouchTime = Time.time;
				this.finger.FingerId = touch.fingerId;
				this._inside = true;
				if (this.OnTouchBegan != null)
				{
					this.OnTouchBegan(vector);
				}
			}
			break;
		case TouchPhase.Moved:
		case TouchPhase.Stationary:
		{
			bool flag = this.TouchInside(vector);
			if (this._inside && !flag)
			{
				this._inside = false;
				if (this.OnTouchLeftBoundary != null)
				{
					this.OnTouchLeftBoundary(vector, touch.deltaPosition);
				}
			}
			else if (!this._inside && flag)
			{
				this._inside = true;
				if (this.OnTouchEnteredBoundary != null)
				{
					this.OnTouchEnteredBoundary(vector, touch.deltaPosition);
				}
			}
			if (this.OnTouchMoved != null)
			{
				this.OnTouchMoved(vector, touch.deltaPosition);
			}
			this.finger.LastPos = vector;
			break;
		}
		case TouchPhase.Ended:
		case TouchPhase.Canceled:
			if (this.OnTouchEnded != null)
			{
				this.OnTouchEnded(vector);
			}
			this.ResetTouch();
			break;
		}
	}

	// Token: 0x06001BC3 RID: 7107 RVA: 0x00012644 File Offset: 0x00010844
	protected virtual void ResetTouch()
	{
		this.finger.Reset();
		this._inside = false;
	}

	// Token: 0x06001BC4 RID: 7108 RVA: 0x00012658 File Offset: 0x00010858
	protected virtual bool TouchInside(Vector2 position)
	{
		return this.Boundary.ContainsTouch(position);
	}

	// Token: 0x040018B9 RID: 6329
	public TouchFinger finger;

	// Token: 0x040018BA RID: 6330
	private bool enabled;

	// Token: 0x040018BB RID: 6331
	protected float _rotationAngle;

	// Token: 0x040018BC RID: 6332
	protected Vector2 _rotationPoint = Vector2.zero;

	// Token: 0x040018BD RID: 6333
	private bool _inside;
}
