using System;
using UnityEngine;

// Token: 0x0200005B RID: 91
public abstract class UIWidget : MonoBehaviour
{
	// Token: 0x17000045 RID: 69
	// (get) Token: 0x06000244 RID: 580 RVA: 0x00003A42 File Offset: 0x00001C42
	public bool isVisible
	{
		get
		{
			return this.mVisibleByPanel && this.finalAlpha > 0.001f;
		}
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x06000245 RID: 581 RVA: 0x00003A5F File Offset: 0x00001C5F
	// (set) Token: 0x06000246 RID: 582 RVA: 0x00003A67 File Offset: 0x00001C67
	public Color color
	{
		get
		{
			return this.mColor;
		}
		set
		{
			if (!this.mColor.Equals(value))
			{
				this.mColor = value;
				this.mChanged = true;
			}
		}
	}

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x06000247 RID: 583 RVA: 0x00003A8D File Offset: 0x00001C8D
	// (set) Token: 0x06000248 RID: 584 RVA: 0x00020368 File Offset: 0x0001E568
	public float alpha
	{
		get
		{
			return this.mColor.a;
		}
		set
		{
			Color color = this.mColor;
			color.a = value;
			this.color = color;
		}
	}

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x06000249 RID: 585 RVA: 0x0002038C File Offset: 0x0001E58C
	public float finalAlpha
	{
		get
		{
			if (this.mPanel == null)
			{
				this.CreatePanel();
			}
			return (!(this.mPanel != null)) ? this.mColor.a : (this.mColor.a * this.mPanel.alpha);
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x0600024A RID: 586 RVA: 0x00003A9A File Offset: 0x00001C9A
	// (set) Token: 0x0600024B RID: 587 RVA: 0x000203E8 File Offset: 0x0001E5E8
	public UIWidget.Pivot pivot
	{
		get
		{
			return this.mPivot;
		}
		set
		{
			if (this.mPivot != value)
			{
				Vector3 vector = NGUIMath.CalculateWidgetCorners(this)[0];
				this.mPivot = value;
				this.mChanged = true;
				Vector3 vector2 = NGUIMath.CalculateWidgetCorners(this)[0];
				Transform cachedTransform = this.cachedTransform;
				Vector3 vector3 = cachedTransform.position;
				float z = cachedTransform.localPosition.z;
				vector3.x += vector.x - vector2.x;
				vector3.y += vector.y - vector2.y;
				this.cachedTransform.position = vector3;
				vector3 = this.cachedTransform.localPosition;
				vector3.x = Mathf.Round(vector3.x);
				vector3.y = Mathf.Round(vector3.y);
				vector3.z = z;
				this.cachedTransform.localPosition = vector3;
			}
		}
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x0600024C RID: 588 RVA: 0x00003AA2 File Offset: 0x00001CA2
	// (set) Token: 0x0600024D RID: 589 RVA: 0x00003AAA File Offset: 0x00001CAA
	public int depth
	{
		get
		{
			return this.mDepth;
		}
		set
		{
			if (this.mDepth != value)
			{
				this.mDepth = value;
				if (this.mPanel != null)
				{
					this.mPanel.MarkMaterialAsChanged(this.material, true);
				}
			}
		}
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x0600024E RID: 590 RVA: 0x000204E0 File Offset: 0x0001E6E0
	public Vector2 pivotOffset
	{
		get
		{
			Vector2 zero = Vector2.zero;
			Vector4 relativePadding = this.relativePadding;
			UIWidget.Pivot pivot = this.pivot;
			if (pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.Bottom)
			{
				zero.x = (relativePadding.x - relativePadding.z - 1f) * 0.5f;
			}
			else if (pivot == UIWidget.Pivot.TopRight || pivot == UIWidget.Pivot.Right || pivot == UIWidget.Pivot.BottomRight)
			{
				zero.x = -1f - relativePadding.z;
			}
			else
			{
				zero.x = relativePadding.x;
			}
			if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.Right)
			{
				zero.y = (relativePadding.w - relativePadding.y + 1f) * 0.5f;
			}
			else if (pivot == UIWidget.Pivot.BottomLeft || pivot == UIWidget.Pivot.Bottom || pivot == UIWidget.Pivot.BottomRight)
			{
				zero.y = 1f + relativePadding.w;
			}
			else
			{
				zero.y = -relativePadding.y;
			}
			return zero;
		}
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x0600024F RID: 591 RVA: 0x00003AE2 File Offset: 0x00001CE2
	public GameObject cachedGameObject
	{
		get
		{
			if (this.mGo == null)
			{
				this.mGo = base.gameObject;
			}
			return this.mGo;
		}
	}

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000250 RID: 592 RVA: 0x00003B07 File Offset: 0x00001D07
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

	// Token: 0x1700004E RID: 78
	// (get) Token: 0x06000251 RID: 593 RVA: 0x00003B2C File Offset: 0x00001D2C
	// (set) Token: 0x06000252 RID: 594 RVA: 0x000205F4 File Offset: 0x0001E7F4
	public virtual Material material
	{
		get
		{
			return this.mMat;
		}
		set
		{
			if (this.mMat != value)
			{
				if (this.mMat != null && this.mPanel != null)
				{
					this.mPanel.RemoveWidget(this);
				}
				this.mPanel = null;
				this.mMat = value;
				this.mTex = null;
				if (this.mMat != null)
				{
					this.CreatePanel();
				}
			}
		}
	}

	// Token: 0x1700004F RID: 79
	// (get) Token: 0x06000253 RID: 595 RVA: 0x0002066C File Offset: 0x0001E86C
	// (set) Token: 0x06000254 RID: 596 RVA: 0x0002070C File Offset: 0x0001E90C
	public virtual Texture mainTexture
	{
		get
		{
			Material material = this.material;
			if (material != null)
			{
				if (material.mainTexture != null)
				{
					this.mTex = material.mainTexture;
				}
				else if (this.mTex != null)
				{
					if (this.mPanel != null)
					{
						this.mPanel.RemoveWidget(this);
					}
					this.mPanel = null;
					this.mMat.mainTexture = this.mTex;
					if (base.enabled)
					{
						this.CreatePanel();
					}
				}
			}
			return this.mTex;
		}
		set
		{
			Material material = this.material;
			if (material == null || material.mainTexture != value)
			{
				if (this.mPanel != null)
				{
					this.mPanel.RemoveWidget(this);
				}
				this.mPanel = null;
				this.mTex = value;
				material = this.material;
				if (material != null)
				{
					material.mainTexture = value;
					if (base.enabled)
					{
						this.CreatePanel();
					}
				}
			}
		}
	}

	// Token: 0x17000050 RID: 80
	// (get) Token: 0x06000255 RID: 597 RVA: 0x00003B34 File Offset: 0x00001D34
	// (set) Token: 0x06000256 RID: 598 RVA: 0x00003B53 File Offset: 0x00001D53
	public UIPanel panel
	{
		get
		{
			if (this.mPanel == null)
			{
				this.CreatePanel();
			}
			return this.mPanel;
		}
		set
		{
			this.mPanel = value;
		}
	}

	// Token: 0x06000257 RID: 599 RVA: 0x00020794 File Offset: 0x0001E994
	public static BetterList<UIWidget> Raycast(GameObject root, Vector2 mousePos)
	{
		BetterList<UIWidget> betterList = new BetterList<UIWidget>();
		UICamera uicamera = UICamera.FindCameraForLayer(root.layer);
		if (uicamera != null)
		{
			Camera cachedCamera = uicamera.cachedCamera;
			foreach (UIWidget uiwidget in root.GetComponentsInChildren<UIWidget>())
			{
				Vector3[] worldPoints = NGUIMath.CalculateWidgetCorners(uiwidget);
				if (NGUIMath.DistanceToRectangle(worldPoints, mousePos, cachedCamera) == 0f)
				{
					betterList.Add(uiwidget);
				}
			}
			betterList.Sort((UIWidget w1, UIWidget w2) => w2.depth.CompareTo(w1.depth));
		}
		return betterList;
	}

	// Token: 0x06000258 RID: 600 RVA: 0x00003B5C File Offset: 0x00001D5C
	public static int CompareFunc(UIWidget left, UIWidget right)
	{
		if (left.mDepth > right.mDepth)
		{
			return 1;
		}
		if (left.mDepth < right.mDepth)
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x06000259 RID: 601 RVA: 0x00003B85 File Offset: 0x00001D85
	public void MarkAsChangedLite()
	{
		this.mChanged = true;
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00020834 File Offset: 0x0001EA34
	public virtual void MarkAsChanged()
	{
		this.mChanged = true;
		if (this.mPanel != null && base.enabled && NGUITools.GetActive(base.gameObject) && !Application.isPlaying && this.material != null)
		{
			this.mPanel.AddWidget(this);
			this.CheckLayer();
		}
	}

	// Token: 0x0600025B RID: 603 RVA: 0x000208A4 File Offset: 0x0001EAA4
	public void CreatePanel()
	{
		if (this.mPanel == null && base.enabled && NGUITools.GetActive(base.gameObject) && this.material != null)
		{
			this.mPanel = UIPanel.Find(this.cachedTransform);
			if (this.mPanel != null)
			{
				this.CheckLayer();
				this.mPanel.AddWidget(this);
				this.mChanged = true;
			}
		}
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0002092C File Offset: 0x0001EB2C
	public void CheckLayer()
	{
		if (this.mPanel != null && this.mPanel.gameObject.layer != base.gameObject.layer)
		{
			Debug.LogWarning("You can't place widgets on a layer different than the UIPanel that manages them.\nIf you want to move widgets to a different layer, parent them to a new panel instead.", this);
			base.gameObject.layer = this.mPanel.gameObject.layer;
		}
	}

	// Token: 0x0600025D RID: 605 RVA: 0x00003B8E File Offset: 0x00001D8E
	[Obsolete("Use ParentHasChanged() instead")]
	public void CheckParent()
	{
		this.ParentHasChanged();
	}

	// Token: 0x0600025E RID: 606 RVA: 0x00020990 File Offset: 0x0001EB90
	public void ParentHasChanged()
	{
		if (this.mPanel != null)
		{
			UIPanel y = UIPanel.Find(this.cachedTransform);
			if (this.mPanel != y)
			{
				this.mPanel.RemoveWidget(this);
				if (!this.keepMaterial || Application.isPlaying)
				{
					this.material = null;
				}
				this.mPanel = null;
				this.CreatePanel();
			}
		}
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00003B96 File Offset: 0x00001D96
	protected virtual void Awake()
	{
		this.mGo = base.gameObject;
		this.mPlayMode = Application.isPlaying;
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00003BAF File Offset: 0x00001DAF
	protected virtual void OnEnable()
	{
		this.mChanged = true;
		if (!this.keepMaterial)
		{
			this.mMat = null;
			this.mTex = null;
		}
		this.mPanel = null;
	}

	// Token: 0x06000261 RID: 609 RVA: 0x00003BD8 File Offset: 0x00001DD8
	private void Start()
	{
		this.OnStart();
		this.CreatePanel();
	}

	// Token: 0x06000262 RID: 610 RVA: 0x00003BE6 File Offset: 0x00001DE6
	public virtual void Update()
	{
		if (this.mPanel == null)
		{
			this.CreatePanel();
		}
	}

	// Token: 0x06000263 RID: 611 RVA: 0x00003BFF File Offset: 0x00001DFF
	protected virtual void OnDisable()
	{
		if (!this.keepMaterial)
		{
			this.material = null;
		}
		else if (this.mPanel != null)
		{
			this.mPanel.RemoveWidget(this);
		}
		this.mPanel = null;
	}

	// Token: 0x06000264 RID: 612 RVA: 0x00003C3C File Offset: 0x00001E3C
	private void OnDestroy()
	{
		if (this.mPanel != null)
		{
			this.mPanel.RemoveWidget(this);
			this.mPanel = null;
		}
	}

	// Token: 0x06000265 RID: 613 RVA: 0x00020A00 File Offset: 0x0001EC00
	public bool UpdateGeometry(UIPanel p, bool forceVisible)
	{
		if (this.material != null && p != null)
		{
			this.mPanel = p;
			bool flag = false;
			float finalAlpha = this.finalAlpha;
			bool flag2 = finalAlpha > 0.001f;
			bool flag3 = forceVisible || this.mVisibleByPanel;
			if (this.cachedTransform.hasChanged)
			{
				this.mTrans.hasChanged = false;
				if (!this.mPanel.widgetsAreStatic)
				{
					Vector2 relativeSize = this.relativeSize;
					Vector2 pivotOffset = this.pivotOffset;
					Vector4 relativePadding = this.relativePadding;
					float num = pivotOffset.x * relativeSize.x - relativePadding.x;
					float num2 = pivotOffset.y * relativeSize.y + relativePadding.y;
					float x = num + relativeSize.x + relativePadding.x + relativePadding.z;
					float y = num2 - relativeSize.y - relativePadding.y - relativePadding.w;
					this.mLocalToPanel = p.worldToLocal * this.cachedTransform.localToWorldMatrix;
					flag = true;
					Vector3 vector = new Vector3(num, num2, 0f);
					Vector3 vector2 = new Vector3(x, y, 0f);
					vector = this.mLocalToPanel.MultiplyPoint3x4(vector);
					vector2 = this.mLocalToPanel.MultiplyPoint3x4(vector2);
					if (Vector3.SqrMagnitude(this.mOldV0 - vector) > 1E-06f || Vector3.SqrMagnitude(this.mOldV1 - vector2) > 1E-06f)
					{
						this.mChanged = true;
						this.mOldV0 = vector;
						this.mOldV1 = vector2;
					}
				}
				if (flag2 || this.mForceVisible != forceVisible)
				{
					this.mForceVisible = forceVisible;
					flag3 = (forceVisible || this.mPanel.IsVisible(this));
				}
			}
			else if (flag2 && this.mForceVisible != forceVisible)
			{
				this.mForceVisible = forceVisible;
				flag3 = this.mPanel.IsVisible(this);
			}
			if (this.mVisibleByPanel != flag3)
			{
				this.mVisibleByPanel = flag3;
				this.mChanged = true;
			}
			if (this.mVisibleByPanel && this.mLastAlpha != finalAlpha)
			{
				this.mChanged = true;
			}
			this.mLastAlpha = finalAlpha;
			if (this.mChanged)
			{
				this.mChanged = false;
				if (this.isVisible)
				{
					this.mGeom.Clear();
					this.OnFill(this.mGeom.verts, this.mGeom.uvs, this.mGeom.cols);
					if (this.mGeom.hasVertices)
					{
						Vector3 pivotOffset2 = this.pivotOffset;
						Vector2 relativeSize2 = this.relativeSize;
						pivotOffset2.x *= relativeSize2.x;
						pivotOffset2.y *= relativeSize2.y;
						if (!flag)
						{
							this.mLocalToPanel = p.worldToLocal * this.cachedTransform.localToWorldMatrix;
						}
						this.mGeom.ApplyOffset(pivotOffset2);
						this.mGeom.ApplyTransform(this.mLocalToPanel, p.generateNormals);
					}
					return true;
				}
				if (this.mGeom.hasVertices)
				{
					this.mGeom.Clear();
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000266 RID: 614 RVA: 0x00003C62 File Offset: 0x00001E62
	public void WriteToBuffers(BetterList<Vector3> v, BetterList<Vector2> u, BetterList<Color32> c, BetterList<Vector3> n, BetterList<Vector4> t)
	{
		this.mGeom.WriteToBuffers(v, u, c, n, t);
	}

	// Token: 0x06000267 RID: 615 RVA: 0x00020D4C File Offset: 0x0001EF4C
	public virtual void MakePixelPerfect()
	{
		Vector3 localScale = this.cachedTransform.localScale;
		int num = Mathf.RoundToInt(localScale.x);
		int num2 = Mathf.RoundToInt(localScale.y);
		localScale.x = (float)num;
		localScale.y = (float)num2;
		localScale.z = 1f;
		Vector3 localPosition = this.cachedTransform.localPosition;
		localPosition.z = (float)Mathf.RoundToInt(localPosition.z);
		if (num % 2 == 1 && (this.pivot == UIWidget.Pivot.Top || this.pivot == UIWidget.Pivot.Center || this.pivot == UIWidget.Pivot.Bottom))
		{
			localPosition.x = Mathf.Floor(localPosition.x) + 0.5f;
		}
		else
		{
			localPosition.x = Mathf.Round(localPosition.x);
		}
		if (num2 % 2 == 1 && (this.pivot == UIWidget.Pivot.Left || this.pivot == UIWidget.Pivot.Center || this.pivot == UIWidget.Pivot.Right))
		{
			localPosition.y = Mathf.Ceil(localPosition.y) - 0.5f;
		}
		else
		{
			localPosition.y = Mathf.Round(localPosition.y);
		}
		this.cachedTransform.localPosition = localPosition;
		this.cachedTransform.localScale = localScale;
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x06000268 RID: 616 RVA: 0x00003C76 File Offset: 0x00001E76
	public virtual Vector2 relativeSize
	{
		get
		{
			return Vector2.one;
		}
	}

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x06000269 RID: 617 RVA: 0x00003C7D File Offset: 0x00001E7D
	public virtual Vector4 relativePadding
	{
		get
		{
			return Vector4.zero;
		}
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x0600026A RID: 618 RVA: 0x00003C7D File Offset: 0x00001E7D
	public virtual Vector4 border
	{
		get
		{
			return Vector4.zero;
		}
	}

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x0600026B RID: 619 RVA: 0x00003C84 File Offset: 0x00001E84
	public virtual bool keepMaterial
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x0600026C RID: 620 RVA: 0x00003C84 File Offset: 0x00001E84
	public virtual bool pixelPerfectAfterResize
	{
		get
		{
			return false;
		}
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00003C87 File Offset: 0x00001E87
	protected virtual void OnStart()
	{
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
	}

	// Token: 0x040001F4 RID: 500
	[HideInInspector]
	[SerializeField]
	protected Material mMat;

	// Token: 0x040001F5 RID: 501
	[HideInInspector]
	[SerializeField]
	protected Texture mTex;

	// Token: 0x040001F6 RID: 502
	[SerializeField]
	[HideInInspector]
	private Color mColor = Color.white;

	// Token: 0x040001F7 RID: 503
	[HideInInspector]
	[SerializeField]
	private UIWidget.Pivot mPivot = UIWidget.Pivot.Center;

	// Token: 0x040001F8 RID: 504
	[HideInInspector]
	[SerializeField]
	private int mDepth;

	// Token: 0x040001F9 RID: 505
	protected GameObject mGo;

	// Token: 0x040001FA RID: 506
	protected Transform mTrans;

	// Token: 0x040001FB RID: 507
	protected UIPanel mPanel;

	// Token: 0x040001FC RID: 508
	protected bool mChanged = true;

	// Token: 0x040001FD RID: 509
	protected bool mPlayMode = true;

	// Token: 0x040001FE RID: 510
	private Vector3 mDiffPos;

	// Token: 0x040001FF RID: 511
	private Quaternion mDiffRot;

	// Token: 0x04000200 RID: 512
	private Vector3 mDiffScale;

	// Token: 0x04000201 RID: 513
	private Matrix4x4 mLocalToPanel;

	// Token: 0x04000202 RID: 514
	private bool mVisibleByPanel = true;

	// Token: 0x04000203 RID: 515
	private float mLastAlpha;

	// Token: 0x04000204 RID: 516
	private UIGeometry mGeom = new UIGeometry();

	// Token: 0x04000205 RID: 517
	private bool mForceVisible;

	// Token: 0x04000206 RID: 518
	private Vector3 mOldV0;

	// Token: 0x04000207 RID: 519
	private Vector3 mOldV1;

	// Token: 0x0200005C RID: 92
	public enum Pivot
	{
		// Token: 0x0400020A RID: 522
		TopLeft,
		// Token: 0x0400020B RID: 523
		Top,
		// Token: 0x0400020C RID: 524
		TopRight,
		// Token: 0x0400020D RID: 525
		Left,
		// Token: 0x0400020E RID: 526
		Center,
		// Token: 0x0400020F RID: 527
		Right,
		// Token: 0x04000210 RID: 528
		BottomLeft,
		// Token: 0x04000211 RID: 529
		Bottom,
		// Token: 0x04000212 RID: 530
		BottomRight
	}
}
