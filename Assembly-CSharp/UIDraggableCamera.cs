using System;
using UnityEngine;

// Token: 0x02000021 RID: 33
[AddComponentMenu("NGUI/Interaction/Draggable Camera")]
[RequireComponent(typeof(Camera))]
public class UIDraggableCamera : IgnoreTimeScale
{
	// Token: 0x17000008 RID: 8
	// (get) Token: 0x0600009E RID: 158 RVA: 0x00002A22 File Offset: 0x00000C22
	// (set) Token: 0x0600009F RID: 159 RVA: 0x00002A2A File Offset: 0x00000C2A
	public Vector2 currentMomentum
	{
		get
		{
			return this.mMomentum;
		}
		set
		{
			this.mMomentum = value;
		}
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00018068 File Offset: 0x00016268
	private void Awake()
	{
		this.mCam = base.camera;
		this.mTrans = base.transform;
		if (this.rootForBounds == null)
		{
			Debug.LogError(NGUITools.GetHierarchy(base.gameObject) + " needs the 'Root For Bounds' parameter to be set", this);
			base.enabled = false;
		}
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00002A33 File Offset: 0x00000C33
	private void Start()
	{
		this.mRoot = NGUITools.FindInParents<UIRoot>(base.gameObject);
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x000180C0 File Offset: 0x000162C0
	private Vector3 CalculateConstrainOffset()
	{
		if (this.rootForBounds == null || this.rootForBounds.childCount == 0)
		{
			return Vector3.zero;
		}
		Vector3 vector = new Vector3(this.mCam.rect.xMin * (float)Screen.width, this.mCam.rect.yMin * (float)Screen.height, 0f);
		Vector3 vector2 = new Vector3(this.mCam.rect.xMax * (float)Screen.width, this.mCam.rect.yMax * (float)Screen.height, 0f);
		vector = this.mCam.ScreenToWorldPoint(vector);
		vector2 = this.mCam.ScreenToWorldPoint(vector2);
		Vector2 minRect = new Vector2(this.mBounds.min.x, this.mBounds.min.y);
		Vector2 maxRect = new Vector2(this.mBounds.max.x, this.mBounds.max.y);
		return NGUIMath.ConstrainRect(minRect, maxRect, vector, vector2);
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x00018208 File Offset: 0x00016408
	public bool ConstrainToBounds(bool immediate)
	{
		if (this.mTrans != null && this.rootForBounds != null)
		{
			Vector3 b = this.CalculateConstrainOffset();
			if (b.magnitude > 0f)
			{
				if (immediate)
				{
					this.mTrans.position -= b;
				}
				else
				{
					SpringPosition springPosition = SpringPosition.Begin(base.gameObject, this.mTrans.position - b, 13f);
					springPosition.ignoreTimeScale = true;
					springPosition.worldSpace = true;
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x000182A4 File Offset: 0x000164A4
	public void Press(bool isPressed)
	{
		if (isPressed)
		{
			this.mDragStarted = false;
		}
		if (this.rootForBounds != null)
		{
			this.mPressed = isPressed;
			if (isPressed)
			{
				this.mBounds = NGUIMath.CalculateAbsoluteWidgetBounds(this.rootForBounds);
				this.mMomentum = Vector2.zero;
				this.mScroll = 0f;
				SpringPosition component = base.GetComponent<SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			else if (this.dragEffect == UIDragObject.DragEffect.MomentumAndSpring)
			{
				this.ConstrainToBounds(false);
			}
		}
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00018338 File Offset: 0x00016538
	public void Drag(Vector2 delta)
	{
		if (this.smoothDragStart && !this.mDragStarted)
		{
			this.mDragStarted = true;
			return;
		}
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
		if (this.mRoot != null)
		{
			delta *= this.mRoot.pixelSizeAdjustment;
		}
		Vector2 vector = Vector2.Scale(delta, -this.scale);
		mTrans.localPosition += (Vector3)vector;
		this.mMomentum = Vector2.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
		if (this.dragEffect != UIDragObject.DragEffect.MomentumAndSpring && this.ConstrainToBounds(true))
		{
			this.mMomentum = Vector2.zero;
			this.mScroll = 0f;
		}
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00018424 File Offset: 0x00016624
	public void Scroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject))
		{
			if (Mathf.Sign(this.mScroll) != Mathf.Sign(delta))
			{
				this.mScroll = 0f;
			}
			this.mScroll += delta * this.scrollWheelFactor;
		}
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00018484 File Offset: 0x00016684
	private void Update()
	{
		float deltaTime = base.UpdateRealTimeDelta();
		if (this.mPressed)
		{
			SpringPosition component = base.GetComponent<SpringPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			this.mScroll = 0f;
		}
		else
		{
			this.mMomentum += this.scale * (this.mScroll * 20f);
			this.mScroll = NGUIMath.SpringLerp(this.mScroll, 0f, 20f, deltaTime);
			if (this.mMomentum.magnitude > 0.01f)
			{
				this.mTrans.localPosition += (Vector3)NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
				this.mBounds = NGUIMath.CalculateAbsoluteWidgetBounds(this.rootForBounds);
				if (!this.ConstrainToBounds(this.dragEffect == UIDragObject.DragEffect.None))
				{
					SpringPosition component2 = base.GetComponent<SpringPosition>();
					if (component2 != null)
					{
						component2.enabled = false;
					}
				}
				return;
			}
			this.mScroll = 0f;
		}
		NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
	}

	// Token: 0x040000C2 RID: 194
	public Transform rootForBounds;

	// Token: 0x040000C3 RID: 195
	public Vector2 scale = Vector2.one;

	// Token: 0x040000C4 RID: 196
	public float scrollWheelFactor;

	// Token: 0x040000C5 RID: 197
	public UIDragObject.DragEffect dragEffect = UIDragObject.DragEffect.MomentumAndSpring;

	// Token: 0x040000C6 RID: 198
	public bool smoothDragStart = true;

	// Token: 0x040000C7 RID: 199
	public float momentumAmount = 35f;

	// Token: 0x040000C8 RID: 200
	private Camera mCam;

	// Token: 0x040000C9 RID: 201
	private Transform mTrans;

	// Token: 0x040000CA RID: 202
	private bool mPressed;

	// Token: 0x040000CB RID: 203
	private Vector2 mMomentum = Vector2.zero;

	// Token: 0x040000CC RID: 204
	private Bounds mBounds;

	// Token: 0x040000CD RID: 205
	private float mScroll;

	// Token: 0x040000CE RID: 206
	private UIRoot mRoot;

	// Token: 0x040000CF RID: 207
	private bool mDragStarted;
}
