using System;
using UnityEngine;

// Token: 0x02000070 RID: 112
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Anchor")]
public class UIAnchor : MonoBehaviour
{
	// Token: 0x060002CC RID: 716 RVA: 0x00004191 File Offset: 0x00002391
	private void Awake()
	{
		this.mTrans = base.transform;
		this.mAnim = base.animation;
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00022180 File Offset: 0x00020380
	private void Start()
	{
		this.mRoot = NGUITools.FindInParents<UIRoot>(base.gameObject);
		this.mNeedsHalfPixelOffset = (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.XBOX360 || Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.WindowsEditor);
		if (this.mNeedsHalfPixelOffset)
		{
			this.mNeedsHalfPixelOffset = (SystemInfo.graphicsShaderLevel < 40);
		}
		if (this.uiCamera == null)
		{
			this.uiCamera = this.FindCamera();
		}
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.Update();
	}

	// Token: 0x060002CE RID: 718 RVA: 0x00022238 File Offset: 0x00020438
	private Camera FindCamera()
	{
		Transform transform = base.transform;
		while (transform != null)
		{
			Camera component = transform.GetComponent<Camera>();
			if (component != null)
			{
				return component;
			}
			transform = transform.parent;
		}
		return null;
	}

	// Token: 0x060002CF RID: 719 RVA: 0x0002227C File Offset: 0x0002047C
	private void Update()
	{
		if (this.mAnim != null && this.mAnim.enabled && this.mAnim.isPlaying)
		{
			return;
		}
		bool flag = false;
		if (this.panelContainer != null)
		{
			if (this.panelContainer.clipping == UIDrawCall.Clipping.None)
			{
				float num = (!(this.mRoot != null)) ? 0.5f : ((float)this.mRoot.activeHeight / (float)Screen.height * 0.5f);
				this.mRect.xMin = (float)(-(float)Screen.width) * num;
				this.mRect.yMin = (float)(-(float)Screen.height) * num;
				this.mRect.xMax = -this.mRect.xMin;
				this.mRect.yMax = -this.mRect.yMin;
			}
			else
			{
				Vector4 clipRange = this.panelContainer.clipRange;
				this.mRect.x = clipRange.x - clipRange.z * 0.5f;
				this.mRect.y = clipRange.y - clipRange.w * 0.5f;
				this.mRect.width = clipRange.z;
				this.mRect.height = clipRange.w;
			}
		}
		else if (this.widgetContainer != null)
		{
			Transform cachedTransform = this.widgetContainer.cachedTransform;
			Vector3 localScale = cachedTransform.localScale;
			Vector3 localPosition = cachedTransform.localPosition;
			Vector3 vector = this.widgetContainer.relativeSize;
			Vector3 vector2 = this.widgetContainer.pivotOffset;
			vector2.y -= 1f;
			vector2.x *= this.widgetContainer.relativeSize.x * localScale.x;
			vector2.y *= this.widgetContainer.relativeSize.y * localScale.y;
			this.mRect.x = localPosition.x + vector2.x;
			this.mRect.y = localPosition.y + vector2.y;
			this.mRect.width = vector.x * localScale.x;
			this.mRect.height = vector.y * localScale.y;
		}
		else
		{
			if (!(this.uiCamera != null))
			{
				return;
			}
			flag = true;
			this.mRect = this.uiCamera.pixelRect;
		}
		float x = (this.mRect.xMin + this.mRect.xMax) * 0.5f;
		float y = (this.mRect.yMin + this.mRect.yMax) * 0.5f;
		Vector3 vector3 = new Vector3(x, y, 0f);
		if (this.side != UIAnchor.Side.Center)
		{
			if (this.side == UIAnchor.Side.Right || this.side == UIAnchor.Side.TopRight || this.side == UIAnchor.Side.BottomRight)
			{
				vector3.x = this.mRect.xMax;
			}
			else if (this.side == UIAnchor.Side.Top || this.side == UIAnchor.Side.Center || this.side == UIAnchor.Side.Bottom)
			{
				vector3.x = x;
			}
			else
			{
				vector3.x = this.mRect.xMin;
			}
			if (this.side == UIAnchor.Side.Top || this.side == UIAnchor.Side.TopRight || this.side == UIAnchor.Side.TopLeft)
			{
				vector3.y = this.mRect.yMax;
			}
			else if (this.side == UIAnchor.Side.Left || this.side == UIAnchor.Side.Center || this.side == UIAnchor.Side.Right)
			{
				vector3.y = y;
			}
			else
			{
				vector3.y = this.mRect.yMin;
			}
		}
		float width = this.mRect.width;
		float height = this.mRect.height;
		vector3.x += this.relativeOffset.x * width;
		vector3.y += this.relativeOffset.y * height;
		if (flag)
		{
			if (this.uiCamera.orthographic)
			{
				vector3.x = Mathf.Round(vector3.x);
				vector3.y = Mathf.Round(vector3.y);
				if (this.halfPixelOffset && this.mNeedsHalfPixelOffset)
				{
					vector3.x -= 0.5f;
					vector3.y += 0.5f;
				}
			}
			vector3.z = this.uiCamera.WorldToScreenPoint(this.mTrans.position).z;
			vector3 = this.uiCamera.ScreenToWorldPoint(vector3);
		}
		else
		{
			vector3.x = Mathf.Round(vector3.x);
			vector3.y = Mathf.Round(vector3.y);
			if (this.panelContainer != null)
			{
				vector3 = this.panelContainer.cachedTransform.TransformPoint(vector3);
			}
			else if (this.widgetContainer != null)
			{
				Transform parent = this.widgetContainer.cachedTransform.parent;
				if (parent != null)
				{
					vector3 = parent.TransformPoint(vector3);
				}
			}
			vector3.z = this.mTrans.position.z;
		}
		if (this.mTrans.position != vector3)
		{
			this.mTrans.position = vector3;
		}
		if (this.runOnlyOnce && Application.isPlaying)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x0400026C RID: 620
	private bool mNeedsHalfPixelOffset;

	// Token: 0x0400026D RID: 621
	public Camera uiCamera;

	// Token: 0x0400026E RID: 622
	public UIWidget widgetContainer;

	// Token: 0x0400026F RID: 623
	public UIPanel panelContainer;

	// Token: 0x04000270 RID: 624
	public UIAnchor.Side side = UIAnchor.Side.Center;

	// Token: 0x04000271 RID: 625
	public bool halfPixelOffset = true;

	// Token: 0x04000272 RID: 626
	public bool runOnlyOnce;

	// Token: 0x04000273 RID: 627
	public Vector2 relativeOffset = Vector2.zero;

	// Token: 0x04000274 RID: 628
	private Transform mTrans;

	// Token: 0x04000275 RID: 629
	private Animation mAnim;

	// Token: 0x04000276 RID: 630
	private Rect mRect = default(Rect);

	// Token: 0x04000277 RID: 631
	private UIRoot mRoot;

	// Token: 0x02000071 RID: 113
	public enum Side
	{
		// Token: 0x04000279 RID: 633
		BottomLeft,
		// Token: 0x0400027A RID: 634
		Left,
		// Token: 0x0400027B RID: 635
		TopLeft,
		// Token: 0x0400027C RID: 636
		Top,
		// Token: 0x0400027D RID: 637
		TopRight,
		// Token: 0x0400027E RID: 638
		Right,
		// Token: 0x0400027F RID: 639
		BottomRight,
		// Token: 0x04000280 RID: 640
		Bottom,
		// Token: 0x04000281 RID: 641
		Center
	}
}
