using System;
using UnityEngine;

// Token: 0x02000098 RID: 152
[AddComponentMenu("NGUI/UI/Tooltip")]
public class UITooltip : MonoBehaviour
{
	// Token: 0x0600041B RID: 1051 RVA: 0x00005079 File Offset: 0x00003279
	private void Awake()
	{
		UITooltip.mInstance = this;
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x00005081 File Offset: 0x00003281
	private void OnDestroy()
	{
		UITooltip.mInstance = null;
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x0002CE34 File Offset: 0x0002B034
	private void Start()
	{
		this.mTrans = base.transform;
		this.mWidgets = base.GetComponentsInChildren<UIWidget>();
		this.mPos = this.mTrans.localPosition;
		this.mSize = this.mTrans.localScale;
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.SetAlpha(0f);
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x0002CEB0 File Offset: 0x0002B0B0
	private void Update()
	{
		if (this.mCurrent != this.mTarget)
		{
			this.mCurrent = Mathf.Lerp(this.mCurrent, this.mTarget, Time.deltaTime * this.appearSpeed);
			if (Mathf.Abs(this.mCurrent - this.mTarget) < 0.001f)
			{
				this.mCurrent = this.mTarget;
			}
			this.SetAlpha(this.mCurrent * this.mCurrent);
			if (this.scalingTransitions)
			{
				Vector3 b = this.mSize * 0.25f;
				b.y = -b.y;
				Vector3 localScale = Vector3.one * (1.5f - this.mCurrent * 0.5f);
				Vector3 localPosition = Vector3.Lerp(this.mPos - b, this.mPos, this.mCurrent);
				this.mTrans.localPosition = localPosition;
				this.mTrans.localScale = localScale;
			}
		}
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x0002CFAC File Offset: 0x0002B1AC
	private void SetAlpha(float val)
	{
		int i = 0;
		int num = this.mWidgets.Length;
		while (i < num)
		{
			UIWidget uiwidget = this.mWidgets[i];
			Color color = uiwidget.color;
			color.a = val;
			uiwidget.color = color;
			i++;
		}
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0002CFF4 File Offset: 0x0002B1F4
	private void SetText(string tooltipText)
	{
		if (this.text != null && !string.IsNullOrEmpty(tooltipText))
		{
			this.mTarget = 1f;
			if (this.text != null)
			{
				this.text.text = tooltipText;
			}
			this.mPos = Input.mousePosition;
			if (this.background != null)
			{
				Transform transform = this.background.transform;
				Transform transform2 = this.text.transform;
				Vector3 localPosition = transform2.localPosition;
				Vector3 localScale = transform2.localScale;
				this.mSize = this.text.relativeSize;
				this.mSize.x = this.mSize.x * localScale.x;
				this.mSize.y = this.mSize.y * localScale.y;
				this.mSize.x = this.mSize.x + (this.background.border.x + this.background.border.z + (localPosition.x - this.background.border.x) * 2f);
				this.mSize.y = this.mSize.y + (this.background.border.y + this.background.border.w + (-localPosition.y - this.background.border.y) * 2f);
				this.mSize.z = 1f;
				transform.localScale = this.mSize;
			}
			if (this.uiCamera != null)
			{
				this.mPos.x = Mathf.Clamp01(this.mPos.x / (float)Screen.width);
				this.mPos.y = Mathf.Clamp01(this.mPos.y / (float)Screen.height);
				float num = this.uiCamera.orthographicSize / this.mTrans.parent.lossyScale.y;
				float num2 = (float)Screen.height * 0.5f / num;
				Vector2 vector = new Vector2(num2 * this.mSize.x / (float)Screen.width, num2 * this.mSize.y / (float)Screen.height);
				this.mPos.x = Mathf.Min(this.mPos.x, 1f - vector.x);
				this.mPos.y = Mathf.Max(this.mPos.y, vector.y);
				this.mTrans.position = this.uiCamera.ViewportToWorldPoint(this.mPos);
				this.mPos = this.mTrans.localPosition;
				this.mPos.x = Mathf.Round(this.mPos.x);
				this.mPos.y = Mathf.Round(this.mPos.y);
				this.mTrans.localPosition = this.mPos;
			}
			else
			{
				if (this.mPos.x + this.mSize.x > (float)Screen.width)
				{
					this.mPos.x = (float)Screen.width - this.mSize.x;
				}
				if (this.mPos.y - this.mSize.y < 0f)
				{
					this.mPos.y = this.mSize.y;
				}
				this.mPos.x = this.mPos.x - (float)Screen.width * 0.5f;
				this.mPos.y = this.mPos.y - (float)Screen.height * 0.5f;
			}
		}
		else
		{
			this.mTarget = 0f;
		}
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x00005089 File Offset: 0x00003289
	public static void ShowText(string tooltipText)
	{
		if (UITooltip.mInstance != null)
		{
			UITooltip.mInstance.SetText(tooltipText);
		}
	}

	// Token: 0x040003AC RID: 940
	private static UITooltip mInstance;

	// Token: 0x040003AD RID: 941
	public Camera uiCamera;

	// Token: 0x040003AE RID: 942
	public UILabel text;

	// Token: 0x040003AF RID: 943
	public UISprite background;

	// Token: 0x040003B0 RID: 944
	public float appearSpeed = 10f;

	// Token: 0x040003B1 RID: 945
	public bool scalingTransitions = true;

	// Token: 0x040003B2 RID: 946
	private Transform mTrans;

	// Token: 0x040003B3 RID: 947
	private float mTarget;

	// Token: 0x040003B4 RID: 948
	private float mCurrent;

	// Token: 0x040003B5 RID: 949
	private Vector3 mPos;

	// Token: 0x040003B6 RID: 950
	private Vector3 mSize;

	// Token: 0x040003B7 RID: 951
	private UIWidget[] mWidgets;
}
