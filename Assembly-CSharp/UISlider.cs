using System;
using UnityEngine;

// Token: 0x02000035 RID: 53
[AddComponentMenu("NGUI/Interaction/Slider")]
public class UISlider : IgnoreTimeScale
{
	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000125 RID: 293 RVA: 0x0001B628 File Offset: 0x00019828
	// (set) Token: 0x06000126 RID: 294 RVA: 0x00003016 File Offset: 0x00001216
	public float sliderValue
	{
		get
		{
			float num = this.rawValue;
			if (this.numberOfSteps > 1)
			{
				num = Mathf.Round(num * (float)(this.numberOfSteps - 1)) / (float)(this.numberOfSteps - 1);
			}
			return num;
		}
		set
		{
			this.Set(value, false);
		}
	}

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x06000127 RID: 295 RVA: 0x00003020 File Offset: 0x00001220
	// (set) Token: 0x06000128 RID: 296 RVA: 0x00003028 File Offset: 0x00001228
	public Vector2 fullSize
	{
		get
		{
			return this.mSize;
		}
		set
		{
			if (this.mSize != value)
			{
				this.mSize = value;
				this.ForceUpdate();
			}
		}
	}

	// Token: 0x06000129 RID: 297 RVA: 0x0001B664 File Offset: 0x00019864
	private void Init()
	{
		this.mInitDone = true;
		if (this.foreground != null)
		{
			this.mFGWidget = this.foreground.GetComponent<UIWidget>();
			this.mFGFilled = ((!(this.mFGWidget != null)) ? null : (this.mFGWidget as UISprite));
			this.mFGTrans = this.foreground.transform;
			if (this.mSize == Vector2.zero)
			{
				this.mSize = this.foreground.localScale;
			}
			if (this.mCenter == Vector2.zero)
			{
				this.mCenter = this.foreground.localPosition + this.foreground.localScale * 0.5f;
			}
		}
		else if (this.mCol != null)
		{
			if (this.mSize == Vector2.zero)
			{
				this.mSize = this.mCol.size;
			}
			if (this.mCenter == Vector2.zero)
			{
				this.mCenter = this.mCol.center;
			}
		}
		else
		{
			Debug.LogWarning("UISlider expected to find a foreground object or a box collider to work with", this);
		}
	}

	// Token: 0x0600012A RID: 298 RVA: 0x00003048 File Offset: 0x00001248
	private void Awake()
	{
		this.mTrans = base.transform;
		this.mCol = (base.collider as BoxCollider);
	}

	// Token: 0x0600012B RID: 299 RVA: 0x0001B7C0 File Offset: 0x000199C0
	private void Start()
	{
		this.Init();
		if (Application.isPlaying && this.thumb != null && this.thumb.collider != null)
		{
			UIEventListener uieventListener = UIEventListener.Get(this.thumb.gameObject);
			UIEventListener uieventListener2 = uieventListener;
			uieventListener2.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(uieventListener2.onPress, new UIEventListener.BoolDelegate(this.OnPressThumb));
			UIEventListener uieventListener3 = uieventListener;
			uieventListener3.onDrag = (UIEventListener.VectorDelegate)Delegate.Combine(uieventListener3.onDrag, new UIEventListener.VectorDelegate(this.OnDragThumb));
		}
		this.Set(this.rawValue, true);
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00003067 File Offset: 0x00001267
	private void OnPress(bool pressed)
	{
		if (pressed && UICamera.currentTouchID != -100)
		{
			this.UpdateDrag();
		}
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00003081 File Offset: 0x00001281
	private void OnDrag(Vector2 delta)
	{
		this.UpdateDrag();
	}

	// Token: 0x0600012E RID: 302 RVA: 0x00003089 File Offset: 0x00001289
	private void OnPressThumb(GameObject go, bool pressed)
	{
		if (pressed)
		{
			this.UpdateDrag();
		}
	}

	// Token: 0x0600012F RID: 303 RVA: 0x00003081 File Offset: 0x00001281
	private void OnDragThumb(GameObject go, Vector2 delta)
	{
		this.UpdateDrag();
	}

	// Token: 0x06000130 RID: 304 RVA: 0x0001B868 File Offset: 0x00019A68
	private void OnKey(KeyCode key)
	{
		float num = ((float)this.numberOfSteps <= 1f) ? 0.125f : (1f / (float)(this.numberOfSteps - 1));
		if (this.direction == UISlider.Direction.Horizontal)
		{
			if (key == KeyCode.LeftArrow)
			{
				this.Set(this.rawValue - num, false);
			}
			else if (key == KeyCode.RightArrow)
			{
				this.Set(this.rawValue + num, false);
			}
		}
		else if (key == KeyCode.DownArrow)
		{
			this.Set(this.rawValue - num, false);
		}
		else if (key == KeyCode.UpArrow)
		{
			this.Set(this.rawValue + num, false);
		}
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0001B924 File Offset: 0x00019B24
	private void UpdateDrag()
	{
		if (this.mCol == null || UICamera.currentCamera == null || UICamera.currentTouch == null)
		{
			return;
		}
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
		Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
		Plane plane = new Plane(this.mTrans.rotation * Vector3.back, this.mTrans.position);
		float distance;
		if (!plane.Raycast(ray, out distance))
		{
			return;
		}
		Vector3 b = this.mTrans.localPosition + (Vector3)(this.mCenter - this.mSize * 0.5f);
		Vector3 b2 = this.mTrans.localPosition - b;
		Vector3 a = this.mTrans.InverseTransformPoint(ray.GetPoint(distance));
		Vector3 vector = a + b2;
		this.Set((this.direction != UISlider.Direction.Horizontal) ? (vector.y / this.mSize.y) : (vector.x / this.mSize.x), false);
	}

	// Token: 0x06000132 RID: 306 RVA: 0x0001BA5C File Offset: 0x00019C5C
	private void Set(float input, bool force)
	{
		if (!this.mInitDone)
		{
			this.Init();
		}
		float num = Mathf.Clamp01(input);
		if (num < 0.001f)
		{
			num = 0f;
		}
		float sliderValue = this.sliderValue;
		this.rawValue = num;
		float sliderValue2 = this.sliderValue;
		if (force || sliderValue != sliderValue2)
		{
			Vector3 localScale = this.mSize;
			if (this.direction == UISlider.Direction.Horizontal)
			{
				localScale.x *= sliderValue2;
			}
			else
			{
				localScale.y *= sliderValue2;
			}
			if (this.mFGFilled != null && this.mFGFilled.type == UISprite.Type.Filled)
			{
				this.mFGFilled.fillAmount = sliderValue2;
			}
			else if (this.foreground != null)
			{
				this.mFGTrans.localScale = localScale;
				if (this.mFGWidget != null)
				{
					if (sliderValue2 > 0.001f)
					{
						this.mFGWidget.enabled = true;
						this.mFGWidget.MarkAsChanged();
					}
					else
					{
						this.mFGWidget.enabled = false;
					}
				}
			}
			if (this.thumb != null)
			{
				Vector3 localPosition = this.thumb.localPosition;
				if (this.mFGFilled != null && this.mFGFilled.type == UISprite.Type.Filled)
				{
					if (this.mFGFilled.fillDirection == UISprite.FillDirection.Horizontal)
					{
						localPosition.x = ((!this.mFGFilled.invert) ? localScale.x : (this.mSize.x - localScale.x));
					}
					else if (this.mFGFilled.fillDirection == UISprite.FillDirection.Vertical)
					{
						localPosition.y = ((!this.mFGFilled.invert) ? localScale.y : (this.mSize.y - localScale.y));
					}
					else
					{
						Debug.LogWarning("Slider thumb is only supported with Horizontal or Vertical fill direction", this);
					}
				}
				else if (this.direction == UISlider.Direction.Horizontal)
				{
					localPosition.x = localScale.x;
				}
				else
				{
					localPosition.y = localScale.y;
				}
				this.thumb.localPosition = localPosition;
			}
			UISlider.current = this;
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName) && Application.isPlaying)
			{
				this.eventReceiver.SendMessage(this.functionName, sliderValue2, SendMessageOptions.DontRequireReceiver);
			}
			if (this.onValueChange != null)
			{
				this.onValueChange(sliderValue2);
			}
			UISlider.current = null;
		}
	}

	// Token: 0x06000133 RID: 307 RVA: 0x00003097 File Offset: 0x00001297
	public void ForceUpdate()
	{
		this.Set(this.rawValue, true);
	}

	// Token: 0x0400014A RID: 330
	public static UISlider current;

	// Token: 0x0400014B RID: 331
	public Transform foreground;

	// Token: 0x0400014C RID: 332
	public Transform thumb;

	// Token: 0x0400014D RID: 333
	public UISlider.Direction direction;

	// Token: 0x0400014E RID: 334
	public GameObject eventReceiver;

	// Token: 0x0400014F RID: 335
	public string functionName = "OnSliderChange";

	// Token: 0x04000150 RID: 336
	public UISlider.OnValueChange onValueChange;

	// Token: 0x04000151 RID: 337
	public int numberOfSteps;

	// Token: 0x04000152 RID: 338
	[SerializeField]
	[HideInInspector]
	private float rawValue = 1f;

	// Token: 0x04000153 RID: 339
	private BoxCollider mCol;

	// Token: 0x04000154 RID: 340
	private Transform mTrans;

	// Token: 0x04000155 RID: 341
	private Transform mFGTrans;

	// Token: 0x04000156 RID: 342
	private UIWidget mFGWidget;

	// Token: 0x04000157 RID: 343
	private UISprite mFGFilled;

	// Token: 0x04000158 RID: 344
	private bool mInitDone;

	// Token: 0x04000159 RID: 345
	private Vector2 mSize = Vector2.zero;

	// Token: 0x0400015A RID: 346
	private Vector2 mCenter = Vector3.zero;

	// Token: 0x02000036 RID: 54
	public enum Direction
	{
		// Token: 0x0400015C RID: 348
		Horizontal,
		// Token: 0x0400015D RID: 349
		Vertical
	}

	// Token: 0x02000037 RID: 55
	// (Invoke) Token: 0x06000135 RID: 309
	public delegate void OnValueChange(float val);
}
