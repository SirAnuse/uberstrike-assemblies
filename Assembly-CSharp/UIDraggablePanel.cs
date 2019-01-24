using System;
using UnityEngine;

// Token: 0x02000022 RID: 34
[ExecuteInEditMode]
[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Interaction/Draggable Panel")]
public class UIDraggablePanel : IgnoreTimeScale
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x060000A9 RID: 169 RVA: 0x00002A46 File Offset: 0x00000C46
	public UIPanel panel
	{
		get
		{
			return this.mPanel;
		}
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x060000AA RID: 170 RVA: 0x00002A4E File Offset: 0x00000C4E
	public Bounds bounds
	{
		get
		{
			if (!this.mCalculatedBounds)
			{
				this.mCalculatedBounds = true;
				this.mBounds = NGUIMath.CalculateRelativeWidgetBounds(this.mTrans, this.mTrans);
			}
			return this.mBounds;
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x060000AB RID: 171 RVA: 0x00018628 File Offset: 0x00016828
	public bool shouldMoveHorizontally
	{
		get
		{
			float num = this.bounds.size.x;
			if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				num += this.mPanel.clipSoftness.x * 2f;
			}
			return num > this.mPanel.clipRange.z;
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x060000AC RID: 172 RVA: 0x00018690 File Offset: 0x00016890
	public bool shouldMoveVertically
	{
		get
		{
			float num = this.bounds.size.y;
			if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				num += this.mPanel.clipSoftness.y * 2f;
			}
			return num > this.mPanel.clipRange.w;
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x060000AD RID: 173 RVA: 0x000186F8 File Offset: 0x000168F8
	private bool shouldMove
	{
		get
		{
			if (!this.disableDragIfFits)
			{
				return true;
			}
			if (this.mPanel == null)
			{
				this.mPanel = base.GetComponent<UIPanel>();
			}
			Vector4 clipRange = this.mPanel.clipRange;
			Bounds bounds = this.bounds;
			float num = (clipRange.z != 0f) ? (clipRange.z * 0.5f) : ((float)Screen.width);
			float num2 = (clipRange.w != 0f) ? (clipRange.w * 0.5f) : ((float)Screen.height);
			if (!Mathf.Approximately(this.scale.x, 0f))
			{
				if (bounds.min.x < clipRange.x - num)
				{
					return true;
				}
				if (bounds.max.x > clipRange.x + num)
				{
					return true;
				}
			}
			if (!Mathf.Approximately(this.scale.y, 0f))
			{
				if (bounds.min.y < clipRange.y - num2)
				{
					return true;
				}
				if (bounds.max.y > clipRange.y + num2)
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x060000AE RID: 174 RVA: 0x00002A7F File Offset: 0x00000C7F
	// (set) Token: 0x060000AF RID: 175 RVA: 0x00002A87 File Offset: 0x00000C87
	public Vector3 currentMomentum
	{
		get
		{
			return this.mMomentum;
		}
		set
		{
			this.mMomentum = value;
			this.mShouldMove = true;
		}
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x0001884C File Offset: 0x00016A4C
	private void Awake()
	{
		this.mTrans = base.transform;
		this.mPanel = base.GetComponent<UIPanel>();
		UIPanel uipanel = this.mPanel;
		uipanel.onChange = (UIPanel.OnChangeDelegate)Delegate.Combine(uipanel.onChange, new UIPanel.OnChangeDelegate(this.OnPanelChange));
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00002A97 File Offset: 0x00000C97
	private void OnDestroy()
	{
		if (this.mPanel != null)
		{
			UIPanel uipanel = this.mPanel;
			uipanel.onChange = (UIPanel.OnChangeDelegate)Delegate.Remove(uipanel.onChange, new UIPanel.OnChangeDelegate(this.OnPanelChange));
		}
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00002AD1 File Offset: 0x00000CD1
	private void OnPanelChange()
	{
		this.UpdateScrollbars(true);
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00018898 File Offset: 0x00016A98
	private void Start()
	{
		this.UpdateScrollbars(true);
		if (this.horizontalScrollBar != null)
		{
			UIScrollBar uiscrollBar = this.horizontalScrollBar;
			uiscrollBar.onChange = (UIScrollBar.OnScrollBarChange)Delegate.Combine(uiscrollBar.onChange, new UIScrollBar.OnScrollBarChange(this.OnHorizontalBar));
			this.horizontalScrollBar.alpha = ((this.showScrollBars != UIDraggablePanel.ShowCondition.Always && !this.shouldMoveHorizontally) ? 0f : 1f);
		}
		if (this.verticalScrollBar != null)
		{
			UIScrollBar uiscrollBar2 = this.verticalScrollBar;
			uiscrollBar2.onChange = (UIScrollBar.OnScrollBarChange)Delegate.Combine(uiscrollBar2.onChange, new UIScrollBar.OnScrollBarChange(this.OnVerticalBar));
			this.verticalScrollBar.alpha = ((this.showScrollBars != UIDraggablePanel.ShowCondition.Always && !this.shouldMoveVertically) ? 0f : 1f);
		}
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x0001897C File Offset: 0x00016B7C
	public bool RestrictWithinBounds(bool instant)
	{
		Vector3 vector = this.mPanel.CalculateConstrainOffset(this.bounds.min, this.bounds.max);
		if (vector.magnitude > 0.001f)
		{
			if (!instant && this.dragEffect == UIDraggablePanel.DragEffect.MomentumAndSpring)
			{
				SpringPanel.Begin(this.mPanel.gameObject, this.mTrans.localPosition + vector, 13f);
			}
			else
			{
				this.MoveRelative(vector);
				this.mMomentum = Vector3.zero;
				this.mScroll = 0f;
			}
			return true;
		}
		return false;
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00018A2C File Offset: 0x00016C2C
	public void DisableSpring()
	{
		SpringPanel component = base.GetComponent<SpringPanel>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00018A54 File Offset: 0x00016C54
	public void UpdateScrollbars(bool recalculateBounds)
	{
		if (this.mPanel == null)
		{
			return;
		}
		if (this.horizontalScrollBar != null || this.verticalScrollBar != null)
		{
			if (recalculateBounds)
			{
				this.mCalculatedBounds = false;
				this.mShouldMove = this.shouldMove;
			}
			Bounds bounds = this.bounds;
			Vector2 a = bounds.min;
			Vector2 a2 = bounds.max;
			if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				Vector2 clipSoftness = this.mPanel.clipSoftness;
				a -= clipSoftness;
				a2 += clipSoftness;
			}
			if (this.horizontalScrollBar != null && a2.x > a.x)
			{
				Vector4 clipRange = this.mPanel.clipRange;
				float num = clipRange.z * 0.5f;
				float num2 = clipRange.x - num - bounds.min.x;
				float num3 = bounds.max.x - num - clipRange.x;
				float num4 = a2.x - a.x;
				num2 = Mathf.Clamp01(num2 / num4);
				num3 = Mathf.Clamp01(num3 / num4);
				float num5 = num2 + num3;
				this.mIgnoreCallbacks = true;
				this.horizontalScrollBar.barSize = 1f - num5;
				this.horizontalScrollBar.scrollValue = ((num5 <= 0.001f) ? 0f : (num2 / num5));
				this.mIgnoreCallbacks = false;
			}
			if (this.verticalScrollBar != null && a2.y > a.y)
			{
				Vector4 clipRange2 = this.mPanel.clipRange;
				float num6 = clipRange2.w * 0.5f;
				float num7 = clipRange2.y - num6 - a.y;
				float num8 = a2.y - num6 - clipRange2.y;
				float num9 = a2.y - a.y;
				num7 = Mathf.Clamp01(num7 / num9);
				num8 = Mathf.Clamp01(num8 / num9);
				float num10 = num7 + num8;
				this.mIgnoreCallbacks = true;
				this.verticalScrollBar.barSize = 1f - num10;
				this.verticalScrollBar.scrollValue = ((num10 <= 0.001f) ? 0f : (1f - num7 / num10));
				this.mIgnoreCallbacks = false;
			}
		}
		else if (recalculateBounds)
		{
			this.mCalculatedBounds = false;
		}
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00018CE4 File Offset: 0x00016EE4
	public void SetDragAmount(float x, float y, bool updateScrollbars)
	{
		this.DisableSpring();
		Bounds bounds = this.bounds;
		if (bounds.min.x == bounds.max.x || bounds.min.y == bounds.max.y)
		{
			return;
		}
		Vector4 clipRange = this.mPanel.clipRange;
		float num = clipRange.z * 0.5f;
		float num2 = clipRange.w * 0.5f;
		float num3 = bounds.min.x + num;
		float num4 = bounds.max.x - num;
		float num5 = bounds.min.y + num2;
		float num6 = bounds.max.y - num2;
		if (this.mPanel.clipping == UIDrawCall.Clipping.SoftClip)
		{
			num3 -= this.mPanel.clipSoftness.x;
			num4 += this.mPanel.clipSoftness.x;
			num5 -= this.mPanel.clipSoftness.y;
			num6 += this.mPanel.clipSoftness.y;
		}
		float num7 = Mathf.Lerp(num3, num4, x);
		float num8 = Mathf.Lerp(num6, num5, y);
		if (!updateScrollbars)
		{
			Vector3 localPosition = this.mTrans.localPosition;
			if (this.scale.x != 0f)
			{
				localPosition.x += clipRange.x - num7;
			}
			if (this.scale.y != 0f)
			{
				localPosition.y += clipRange.y - num8;
			}
			this.mTrans.localPosition = localPosition;
		}
		clipRange.x = num7;
		clipRange.y = num8;
		this.mPanel.clipRange = clipRange;
		if (updateScrollbars)
		{
			this.UpdateScrollbars(false);
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00018EF4 File Offset: 0x000170F4
	public void ResetPosition()
	{
		this.mCalculatedBounds = false;
		this.SetDragAmount(this.relativePositionOnReset.x, this.relativePositionOnReset.y, false);
		this.SetDragAmount(this.relativePositionOnReset.x, this.relativePositionOnReset.y, true);
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00018F44 File Offset: 0x00017144
	private void OnHorizontalBar(UIScrollBar sb)
	{
		if (!this.mIgnoreCallbacks)
		{
			float x = (!(this.horizontalScrollBar != null)) ? 0f : this.horizontalScrollBar.scrollValue;
			float y = (!(this.verticalScrollBar != null)) ? 0f : this.verticalScrollBar.scrollValue;
			this.SetDragAmount(x, y, false);
		}
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00018F44 File Offset: 0x00017144
	private void OnVerticalBar(UIScrollBar sb)
	{
		if (!this.mIgnoreCallbacks)
		{
			float x = (!(this.horizontalScrollBar != null)) ? 0f : this.horizontalScrollBar.scrollValue;
			float y = (!(this.verticalScrollBar != null)) ? 0f : this.verticalScrollBar.scrollValue;
			this.SetDragAmount(x, y, false);
		}
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00018FB4 File Offset: 0x000171B4
	public void MoveRelative(Vector3 relative)
	{
		this.mTrans.localPosition += relative;
		Vector4 clipRange = this.mPanel.clipRange;
		clipRange.x -= relative.x;
		clipRange.y -= relative.y;
		this.mPanel.clipRange = clipRange;
		this.UpdateScrollbars(false);
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00019024 File Offset: 0x00017224
	public void MoveAbsolute(Vector3 absolute)
	{
		Vector3 a = this.mTrans.InverseTransformPoint(absolute);
		Vector3 b = this.mTrans.InverseTransformPoint(Vector3.zero);
		this.MoveRelative(a - b);
	}

	// Token: 0x060000BD RID: 189 RVA: 0x0001905C File Offset: 0x0001725C
	public void Press(bool pressed)
	{
		if (this.smoothDragStart && pressed)
		{
			this.mDragStarted = false;
			this.mDragStartOffset = Vector2.zero;
		}
		if (base.enabled && NGUITools.GetActive(base.gameObject))
		{
			if (!pressed && this.mDragID == UICamera.currentTouchID)
			{
				this.mDragID = -10;
			}
			this.mCalculatedBounds = false;
			this.mShouldMove = this.shouldMove;
			if (!this.mShouldMove)
			{
				return;
			}
			this.mPressed = pressed;
			if (pressed)
			{
				this.mMomentum = Vector3.zero;
				this.mScroll = 0f;
				this.DisableSpring();
				this.mLastPos = UICamera.lastHit.point;
				this.mPlane = new Plane(this.mTrans.rotation * Vector3.back, this.mLastPos);
			}
			else
			{
				if (this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None && this.dragEffect == UIDraggablePanel.DragEffect.MomentumAndSpring)
				{
					this.RestrictWithinBounds(false);
				}
				if (this.onDragFinished != null)
				{
					this.onDragFinished();
				}
			}
		}
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00019190 File Offset: 0x00017390
	public void Drag()
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.mShouldMove)
		{
			if (this.mDragID == -10)
			{
				this.mDragID = UICamera.currentTouchID;
			}
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			if (this.smoothDragStart && !this.mDragStarted)
			{
				this.mDragStarted = true;
				this.mDragStartOffset = UICamera.currentTouch.totalDelta;
			}
			Ray ray = (!this.smoothDragStart) ? UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos) : UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos - this.mDragStartOffset);
			float distance = 0f;
			if (this.mPlane.Raycast(ray, out distance))
			{
				Vector3 point = ray.GetPoint(distance);
				Vector3 vector = point - this.mLastPos;
				this.mLastPos = point;
				if (vector.x != 0f || vector.y != 0f)
				{
					vector = this.mTrans.InverseTransformDirection(vector);
					vector.Scale(this.scale);
					vector = this.mTrans.TransformDirection(vector);
				}
				this.mMomentum = Vector3.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
				if (!this.iOSDragEmulation)
				{
					this.MoveAbsolute(vector);
				}
				else if (this.mPanel.CalculateConstrainOffset(this.bounds.min, this.bounds.max).magnitude > 0.001f)
				{
					this.MoveAbsolute(vector * 0.5f);
					this.mMomentum *= 0.5f;
				}
				else
				{
					this.MoveAbsolute(vector);
				}
				if (this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None && this.dragEffect != UIDraggablePanel.DragEffect.MomentumAndSpring)
				{
					this.RestrictWithinBounds(true);
				}
			}
		}
	}

	// Token: 0x060000BF RID: 191 RVA: 0x000193D4 File Offset: 0x000175D4
	public void Scroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.scrollWheelFactor != 0f)
		{
			this.DisableSpring();
			this.mShouldMove = this.shouldMove;
			if (Mathf.Sign(this.mScroll) != Mathf.Sign(delta))
			{
				this.mScroll = 0f;
			}
			this.mScroll += delta * this.scrollWheelFactor;
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00019454 File Offset: 0x00017654
	private void LateUpdate()
	{
		if (this.repositionClipping)
		{
			this.repositionClipping = false;
			this.mCalculatedBounds = false;
			this.SetDragAmount(this.relativePositionOnReset.x, this.relativePositionOnReset.y, true);
		}
		if (!Application.isPlaying)
		{
			return;
		}
		float num = base.UpdateRealTimeDelta();
		if (this.showScrollBars != UIDraggablePanel.ShowCondition.Always)
		{
			bool flag = false;
			bool flag2 = false;
			if (this.showScrollBars != UIDraggablePanel.ShowCondition.WhenDragging || this.mDragID != -10 || this.mMomentum.magnitude > 0.01f)
			{
				flag = this.shouldMoveVertically;
				flag2 = this.shouldMoveHorizontally;
			}
			if (this.verticalScrollBar)
			{
				float num2 = this.verticalScrollBar.alpha;
				num2 += ((!flag) ? (-num * 3f) : (num * 6f));
				num2 = Mathf.Clamp01(num2);
				if (this.verticalScrollBar.alpha != num2)
				{
					this.verticalScrollBar.alpha = num2;
				}
			}
			if (this.horizontalScrollBar)
			{
				float num3 = this.horizontalScrollBar.alpha;
				num3 += ((!flag2) ? (-num * 3f) : (num * 6f));
				num3 = Mathf.Clamp01(num3);
				if (this.horizontalScrollBar.alpha != num3)
				{
					this.horizontalScrollBar.alpha = num3;
				}
			}
		}
		if (this.mShouldMove && !this.mPressed)
		{
			this.mMomentum -= this.scale * (this.mScroll * 0.05f);
			if (this.mMomentum.magnitude > 0.0001f)
			{
				this.mScroll = NGUIMath.SpringLerp(this.mScroll, 0f, 20f, num);
				Vector3 absolute = NGUIMath.SpringDampen(ref this.mMomentum, 9f, num);
				this.MoveAbsolute(absolute);
				if (this.restrictWithinPanel && this.mPanel.clipping != UIDrawCall.Clipping.None)
				{
					this.RestrictWithinBounds(false);
				}
				if (this.mMomentum.magnitude < 0.0001f && this.onDragFinished != null)
				{
					this.onDragFinished();
				}
				return;
			}
			this.mScroll = 0f;
			this.mMomentum = Vector3.zero;
		}
		else
		{
			this.mScroll = 0f;
		}
		NGUIMath.SpringDampen(ref this.mMomentum, 9f, num);
	}

	// Token: 0x040000D0 RID: 208
	public bool restrictWithinPanel = true;

	// Token: 0x040000D1 RID: 209
	public bool disableDragIfFits;

	// Token: 0x040000D2 RID: 210
	public UIDraggablePanel.DragEffect dragEffect = UIDraggablePanel.DragEffect.MomentumAndSpring;

	// Token: 0x040000D3 RID: 211
	public bool smoothDragStart = true;

	// Token: 0x040000D4 RID: 212
	public Vector3 scale = Vector3.one;

	// Token: 0x040000D5 RID: 213
	public float scrollWheelFactor;

	// Token: 0x040000D6 RID: 214
	public float momentumAmount = 35f;

	// Token: 0x040000D7 RID: 215
	public Vector2 relativePositionOnReset = Vector2.zero;

	// Token: 0x040000D8 RID: 216
	public bool repositionClipping;

	// Token: 0x040000D9 RID: 217
	public bool iOSDragEmulation = true;

	// Token: 0x040000DA RID: 218
	public UIScrollBar horizontalScrollBar;

	// Token: 0x040000DB RID: 219
	public UIScrollBar verticalScrollBar;

	// Token: 0x040000DC RID: 220
	public UIDraggablePanel.ShowCondition showScrollBars = UIDraggablePanel.ShowCondition.OnlyIfNeeded;

	// Token: 0x040000DD RID: 221
	public UIDraggablePanel.OnDragFinished onDragFinished;

	// Token: 0x040000DE RID: 222
	private Transform mTrans;

	// Token: 0x040000DF RID: 223
	private UIPanel mPanel;

	// Token: 0x040000E0 RID: 224
	private Plane mPlane;

	// Token: 0x040000E1 RID: 225
	private Vector3 mLastPos;

	// Token: 0x040000E2 RID: 226
	private bool mPressed;

	// Token: 0x040000E3 RID: 227
	private Vector3 mMomentum = Vector3.zero;

	// Token: 0x040000E4 RID: 228
	private float mScroll;

	// Token: 0x040000E5 RID: 229
	private Bounds mBounds;

	// Token: 0x040000E6 RID: 230
	private bool mCalculatedBounds;

	// Token: 0x040000E7 RID: 231
	private bool mShouldMove;

	// Token: 0x040000E8 RID: 232
	private bool mIgnoreCallbacks;

	// Token: 0x040000E9 RID: 233
	private int mDragID = -10;

	// Token: 0x040000EA RID: 234
	private Vector2 mDragStartOffset = Vector2.zero;

	// Token: 0x040000EB RID: 235
	private bool mDragStarted;

	// Token: 0x02000023 RID: 35
	public enum DragEffect
	{
		// Token: 0x040000ED RID: 237
		None,
		// Token: 0x040000EE RID: 238
		Momentum,
		// Token: 0x040000EF RID: 239
		MomentumAndSpring
	}

	// Token: 0x02000024 RID: 36
	public enum ShowCondition
	{
		// Token: 0x040000F1 RID: 241
		Always,
		// Token: 0x040000F2 RID: 242
		OnlyIfNeeded,
		// Token: 0x040000F3 RID: 243
		WhenDragging
	}

	// Token: 0x02000025 RID: 37
	// (Invoke) Token: 0x060000C2 RID: 194
	public delegate void OnDragFinished();
}
