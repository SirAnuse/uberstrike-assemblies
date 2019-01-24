using System;
using UnityEngine;

// Token: 0x02000031 RID: 49
[AddComponentMenu("NGUI/Interaction/Scroll Bar")]
[ExecuteInEditMode]
public class UIScrollBar : MonoBehaviour
{
	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000103 RID: 259 RVA: 0x00002E74 File Offset: 0x00001074
	public Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x06000104 RID: 260 RVA: 0x00002E99 File Offset: 0x00001099
	public Camera cachedCamera
	{
		get
		{
			if (this.mCam == null)
			{
				this.mCam = NGUITools.FindCameraForLayer(base.gameObject.layer);
			}
			return this.mCam;
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x06000105 RID: 261 RVA: 0x00002EC8 File Offset: 0x000010C8
	// (set) Token: 0x06000106 RID: 262 RVA: 0x00002ED0 File Offset: 0x000010D0
	public UISprite background
	{
		get
		{
			return this.mBG;
		}
		set
		{
			if (this.mBG != value)
			{
				this.mBG = value;
				this.mIsDirty = true;
			}
		}
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x06000107 RID: 263 RVA: 0x00002EF1 File Offset: 0x000010F1
	// (set) Token: 0x06000108 RID: 264 RVA: 0x00002EF9 File Offset: 0x000010F9
	public UISprite foreground
	{
		get
		{
			return this.mFG;
		}
		set
		{
			if (this.mFG != value)
			{
				this.mFG = value;
				this.mIsDirty = true;
			}
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000109 RID: 265 RVA: 0x00002F1A File Offset: 0x0000111A
	// (set) Token: 0x0600010A RID: 266 RVA: 0x0001AD70 File Offset: 0x00018F70
	public UIScrollBar.Direction direction
	{
		get
		{
			return this.mDir;
		}
		set
		{
			if (this.mDir != value)
			{
				this.mDir = value;
				this.mIsDirty = true;
				if (this.mBG != null)
				{
					Transform cachedTransform = this.mBG.cachedTransform;
					Vector3 localScale = cachedTransform.localScale;
					if ((this.mDir == UIScrollBar.Direction.Vertical && localScale.x > localScale.y) || (this.mDir == UIScrollBar.Direction.Horizontal && localScale.x < localScale.y))
					{
						float x = localScale.x;
						localScale.x = localScale.y;
						localScale.y = x;
						cachedTransform.localScale = localScale;
						this.ForceUpdate();
						if (this.mBG.collider != null)
						{
							NGUITools.AddWidgetCollider(this.mBG.gameObject);
						}
						if (this.mFG.collider != null)
						{
							NGUITools.AddWidgetCollider(this.mFG.gameObject);
						}
					}
				}
			}
		}
	}

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x0600010B RID: 267 RVA: 0x00002F22 File Offset: 0x00001122
	// (set) Token: 0x0600010C RID: 268 RVA: 0x00002F2A File Offset: 0x0000112A
	public bool inverted
	{
		get
		{
			return this.mInverted;
		}
		set
		{
			if (this.mInverted != value)
			{
				this.mInverted = value;
				this.mIsDirty = true;
			}
		}
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x0600010D RID: 269 RVA: 0x00002F46 File Offset: 0x00001146
	// (set) Token: 0x0600010E RID: 270 RVA: 0x0001AE74 File Offset: 0x00019074
	public float scrollValue
	{
		get
		{
			return this.mScroll;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (this.mScroll != num)
			{
				this.mScroll = num;
				this.mIsDirty = true;
				if (this.onChange != null)
				{
					this.onChange(this);
				}
			}
		}
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x0600010F RID: 271 RVA: 0x00002F4E File Offset: 0x0000114E
	// (set) Token: 0x06000110 RID: 272 RVA: 0x0001AEBC File Offset: 0x000190BC
	public float barSize
	{
		get
		{
			return this.mSize;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (this.mSize != num)
			{
				this.mSize = num;
				this.mIsDirty = true;
				if (this.onChange != null)
				{
					this.onChange(this);
				}
			}
		}
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x06000111 RID: 273 RVA: 0x0001AF04 File Offset: 0x00019104
	// (set) Token: 0x06000112 RID: 274 RVA: 0x0001AF50 File Offset: 0x00019150
	public float alpha
	{
		get
		{
			if (this.mFG != null)
			{
				return this.mFG.alpha;
			}
			if (this.mBG != null)
			{
				return this.mBG.alpha;
			}
			return 0f;
		}
		set
		{
			if (this.mFG != null)
			{
				this.mFG.alpha = value;
				NGUITools.SetActiveSelf(this.mFG.gameObject, this.mFG.alpha > 0.001f);
			}
			if (this.mBG != null)
			{
				this.mBG.alpha = value;
				NGUITools.SetActiveSelf(this.mBG.gameObject, this.mBG.alpha > 0.001f);
			}
		}
	}

	// Token: 0x06000113 RID: 275 RVA: 0x0001AFDC File Offset: 0x000191DC
	private void CenterOnPos(Vector2 localPos)
	{
		if (this.mBG == null || this.mFG == null)
		{
			return;
		}
		Bounds bounds = NGUIMath.CalculateRelativeInnerBounds(this.cachedTransform, this.mBG);
		Bounds bounds2 = NGUIMath.CalculateRelativeInnerBounds(this.cachedTransform, this.mFG);
		if (this.mDir == UIScrollBar.Direction.Horizontal)
		{
			float num = bounds.size.x - bounds2.size.x;
			float num2 = num * 0.5f;
			float num3 = bounds.center.x - num2;
			float num4 = (num <= 0f) ? 0f : ((localPos.x - num3) / num);
			this.scrollValue = ((!this.mInverted) ? num4 : (1f - num4));
		}
		else
		{
			float num5 = bounds.size.y - bounds2.size.y;
			float num6 = num5 * 0.5f;
			float num7 = bounds.center.y - num6;
			float num8 = (num5 <= 0f) ? 0f : (1f - (localPos.y - num7) / num5);
			this.scrollValue = ((!this.mInverted) ? num8 : (1f - num8));
		}
	}

	// Token: 0x06000114 RID: 276 RVA: 0x0001B150 File Offset: 0x00019350
	private void Reposition(Vector2 screenPos)
	{
		Transform cachedTransform = this.cachedTransform;
		Plane plane = new Plane(cachedTransform.rotation * Vector3.back, cachedTransform.position);
		Ray ray = this.cachedCamera.ScreenPointToRay(screenPos);
		float distance;
		if (!plane.Raycast(ray, out distance))
		{
			return;
		}
		this.CenterOnPos(cachedTransform.InverseTransformPoint(ray.GetPoint(distance)));
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00002F56 File Offset: 0x00001156
	private void OnPressBackground(GameObject go, bool isPressed)
	{
		this.mCam = UICamera.currentCamera;
		this.Reposition(UICamera.lastTouchPosition);
		if (!isPressed && this.onDragFinished != null)
		{
			this.onDragFinished();
		}
	}

	// Token: 0x06000116 RID: 278 RVA: 0x00002F8A File Offset: 0x0000118A
	private void OnDragBackground(GameObject go, Vector2 delta)
	{
		this.mCam = UICamera.currentCamera;
		this.Reposition(UICamera.lastTouchPosition);
	}

	// Token: 0x06000117 RID: 279 RVA: 0x0001B1BC File Offset: 0x000193BC
	private void OnPressForeground(GameObject go, bool isPressed)
	{
		if (isPressed)
		{
			this.mCam = UICamera.currentCamera;
			Bounds bounds = NGUIMath.CalculateAbsoluteWidgetBounds(this.mFG.cachedTransform);
			this.mScreenPos = this.mCam.WorldToScreenPoint(bounds.center);
		}
		else if (this.onDragFinished != null)
		{
			this.onDragFinished();
		}
	}

	// Token: 0x06000118 RID: 280 RVA: 0x00002FA2 File Offset: 0x000011A2
	private void OnDragForeground(GameObject go, Vector2 delta)
	{
		this.mCam = UICamera.currentCamera;
		this.Reposition(this.mScreenPos + UICamera.currentTouch.totalDelta);
	}

	// Token: 0x06000119 RID: 281 RVA: 0x0001B224 File Offset: 0x00019424
	private void Start()
	{
		if (this.background != null && this.background.collider != null)
		{
			UIEventListener uieventListener = UIEventListener.Get(this.background.gameObject);
			UIEventListener uieventListener2 = uieventListener;
			uieventListener2.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener2.onPress, new UIEventListener.BoolDelegate(this.OnPressBackground));
			UIEventListener uieventListener3 = uieventListener;
			uieventListener3.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(uieventListener3.onDrag, new UIEventListener.VectorDelegate(this.OnDragBackground));
		}
		if (this.foreground != null && this.foreground.collider != null)
		{
			UIEventListener uieventListener4 = UIEventListener.Get(this.foreground.gameObject);
			UIEventListener uieventListener5 = uieventListener4;
			uieventListener5.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener5.onPress, new UIEventListener.BoolDelegate(this.OnPressForeground));
			UIEventListener uieventListener6 = uieventListener4;
			uieventListener6.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(uieventListener6.onDrag, new UIEventListener.VectorDelegate(this.OnDragForeground));
		}
		this.ForceUpdate();
	}

	// Token: 0x0600011A RID: 282 RVA: 0x00002FCA File Offset: 0x000011CA
	private void Update()
	{
		if (this.mIsDirty)
		{
			this.ForceUpdate();
		}
	}

	// Token: 0x0600011B RID: 283 RVA: 0x0001B330 File Offset: 0x00019530
	public void ForceUpdate()
	{
		this.mIsDirty = false;
		if (this.mBG != null && this.mFG != null)
		{
			this.mSize = Mathf.Clamp01(this.mSize);
			this.mScroll = Mathf.Clamp01(this.mScroll);
			Vector4 border = this.mBG.border;
			Vector4 border2 = this.mFG.border;
			Vector2 vector = new Vector2(Mathf.Max(0f, this.mBG.cachedTransform.localScale.x - border.x - border.z), Mathf.Max(0f, this.mBG.cachedTransform.localScale.y - border.y - border.w));
			float num = (!this.mInverted) ? this.mScroll : (1f - this.mScroll);
			if (this.mDir == UIScrollBar.Direction.Horizontal)
			{
				Vector2 vector2 = new Vector2(vector.x * this.mSize, vector.y);
				this.mFG.pivot = UIWidget.Pivot.Left;
				this.mBG.pivot = UIWidget.Pivot.Left;
				this.mBG.cachedTransform.localPosition = Vector3.zero;
				this.mFG.cachedTransform.localPosition = new Vector3(border.x - border2.x + (vector.x - vector2.x) * num, 0f, 0f);
				this.mFG.cachedTransform.localScale = new Vector3(vector2.x + border2.x + border2.z, vector2.y + border2.y + border2.w, 1f);
				if (num < 0.999f && num > 0.001f)
				{
					this.mFG.MakePixelPerfect();
				}
			}
			else
			{
				Vector2 vector3 = new Vector2(vector.x, vector.y * this.mSize);
				this.mFG.pivot = UIWidget.Pivot.Top;
				this.mBG.pivot = UIWidget.Pivot.Top;
				this.mBG.cachedTransform.localPosition = Vector3.zero;
				this.mFG.cachedTransform.localPosition = new Vector3(0f, -border.y + border2.y - (vector.y - vector3.y) * num, 0f);
				this.mFG.cachedTransform.localScale = new Vector3(vector3.x + border2.x + border2.z, vector3.y + border2.y + border2.w, 1f);
				if (num < 0.999f && num > 0.001f)
				{
					this.mFG.MakePixelPerfect();
				}
			}
		}
	}

	// Token: 0x0400013B RID: 315
	[HideInInspector]
	[SerializeField]
	private UISprite mBG;

	// Token: 0x0400013C RID: 316
	[SerializeField]
	[HideInInspector]
	private UISprite mFG;

	// Token: 0x0400013D RID: 317
	[SerializeField]
	[HideInInspector]
	private UIScrollBar.Direction mDir;

	// Token: 0x0400013E RID: 318
	[SerializeField]
	[HideInInspector]
	private bool mInverted;

	// Token: 0x0400013F RID: 319
	[HideInInspector]
	[SerializeField]
	private float mScroll;

	// Token: 0x04000140 RID: 320
	[SerializeField]
	[HideInInspector]
	private float mSize = 1f;

	// Token: 0x04000141 RID: 321
	private Transform mTrans;

	// Token: 0x04000142 RID: 322
	private bool mIsDirty;

	// Token: 0x04000143 RID: 323
	private Camera mCam;

	// Token: 0x04000144 RID: 324
	private Vector2 mScreenPos = Vector2.zero;

	// Token: 0x04000145 RID: 325
	public UIScrollBar.OnScrollBarChange onChange;

	// Token: 0x04000146 RID: 326
	public UIScrollBar.OnDragFinished onDragFinished;

	// Token: 0x02000032 RID: 50
	public enum Direction
	{
		// Token: 0x04000148 RID: 328
		Horizontal,
		// Token: 0x04000149 RID: 329
		Vertical
	}

	// Token: 0x02000033 RID: 51
	// (Invoke) Token: 0x0600011D RID: 285
	public delegate void OnScrollBarChange(UIScrollBar sb);

	// Token: 0x02000034 RID: 52
	// (Invoke) Token: 0x06000121 RID: 289
	public delegate void OnDragFinished();
}
