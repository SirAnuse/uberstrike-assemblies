using System;
using UnityEngine;

// Token: 0x02000087 RID: 135
[AddComponentMenu("NGUI/UI/Panel")]
[ExecuteInEditMode]
public class UIPanel : MonoBehaviour
{
	// Token: 0x170000A2 RID: 162
	// (get) Token: 0x06000394 RID: 916 RVA: 0x00004BA2 File Offset: 0x00002DA2
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

	// Token: 0x170000A3 RID: 163
	// (get) Token: 0x06000395 RID: 917 RVA: 0x00004BC7 File Offset: 0x00002DC7
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

	// Token: 0x170000A4 RID: 164
	// (get) Token: 0x06000396 RID: 918 RVA: 0x00004BEC File Offset: 0x00002DEC
	// (set) Token: 0x06000397 RID: 919 RVA: 0x00028558 File Offset: 0x00026758
	public float alpha
	{
		get
		{
			return this.mAlpha;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (this.mAlpha != num)
			{
				this.mAlpha = num;
				for (int i = 0; i < this.mDrawCalls.size; i++)
				{
					UIDrawCall uidrawCall = this.mDrawCalls[i];
					this.MarkMaterialAsChanged(uidrawCall.material, false);
				}
				for (int j = 0; j < this.mWidgets.size; j++)
				{
					this.mWidgets[j].MarkAsChangedLite();
				}
			}
		}
	}

	// Token: 0x06000398 RID: 920 RVA: 0x000285E4 File Offset: 0x000267E4
	public void SetAlphaRecursive(float val, bool rebuildList)
	{
		if (rebuildList || this.mChildPanels == null)
		{
			this.mChildPanels = base.GetComponentsInChildren<UIPanel>(true);
		}
		int i = 0;
		int num = this.mChildPanels.Length;
		while (i < num)
		{
			this.mChildPanels[i].alpha = val;
			i++;
		}
	}

	// Token: 0x170000A5 RID: 165
	// (get) Token: 0x06000399 RID: 921 RVA: 0x00004BF4 File Offset: 0x00002DF4
	// (set) Token: 0x0600039A RID: 922 RVA: 0x00028638 File Offset: 0x00026838
	public UIPanel.DebugInfo debugInfo
	{
		get
		{
			return this.mDebugInfo;
		}
		set
		{
			if (this.mDebugInfo != value)
			{
				this.mDebugInfo = value;
				BetterList<UIDrawCall> drawCalls = this.drawCalls;
				HideFlags hideFlags = (this.mDebugInfo != UIPanel.DebugInfo.Geometry) ? HideFlags.HideAndDontSave : (HideFlags.DontSave | HideFlags.NotEditable);
				int i = 0;
				int size = drawCalls.size;
				while (i < size)
				{
					UIDrawCall uidrawCall = drawCalls[i];
					GameObject gameObject = uidrawCall.gameObject;
					NGUITools.SetActiveSelf(gameObject, false);
					gameObject.hideFlags = hideFlags;
					NGUITools.SetActiveSelf(gameObject, true);
					i++;
				}
			}
		}
	}

	// Token: 0x170000A6 RID: 166
	// (get) Token: 0x0600039B RID: 923 RVA: 0x00004BFC File Offset: 0x00002DFC
	// (set) Token: 0x0600039C RID: 924 RVA: 0x00004C04 File Offset: 0x00002E04
	public UIDrawCall.Clipping clipping
	{
		get
		{
			return this.mClipping;
		}
		set
		{
			if (this.mClipping != value)
			{
				this.mClipping = value;
				this.mMatrixTime = 0f;
				this.UpdateDrawcalls();
			}
		}
	}

	// Token: 0x170000A7 RID: 167
	// (get) Token: 0x0600039D RID: 925 RVA: 0x00004C2A File Offset: 0x00002E2A
	// (set) Token: 0x0600039E RID: 926 RVA: 0x000286B8 File Offset: 0x000268B8
	public Vector4 clipRange
	{
		get
		{
			return this.mClipRange;
		}
		set
		{
			if (this.mClipRange != value)
			{
				this.mCullTime = ((this.mCullTime != 0f) ? (Time.realtimeSinceStartup + 0.15f) : 0.001f);
				this.mClipRange = value;
				this.mMatrixTime = 0f;
				this.UpdateDrawcalls();
			}
		}
	}

	// Token: 0x170000A8 RID: 168
	// (get) Token: 0x0600039F RID: 927 RVA: 0x00004C32 File Offset: 0x00002E32
	// (set) Token: 0x060003A0 RID: 928 RVA: 0x00004C3A File Offset: 0x00002E3A
	public Vector2 clipSoftness
	{
		get
		{
			return this.mClipSoftness;
		}
		set
		{
			if (this.mClipSoftness != value)
			{
				this.mClipSoftness = value;
				this.UpdateDrawcalls();
			}
		}
	}

	// Token: 0x170000A9 RID: 169
	// (get) Token: 0x060003A1 RID: 929 RVA: 0x00004C5A File Offset: 0x00002E5A
	public BetterList<UIWidget> widgets
	{
		get
		{
			return this.mWidgets;
		}
	}

	// Token: 0x170000AA RID: 170
	// (get) Token: 0x060003A2 RID: 930 RVA: 0x0002871C File Offset: 0x0002691C
	public BetterList<UIDrawCall> drawCalls
	{
		get
		{
			int i = this.mDrawCalls.size;
			while (i > 0)
			{
				UIDrawCall x = this.mDrawCalls[--i];
				if (x == null)
				{
					this.mDrawCalls.RemoveAt(i);
				}
			}
			return this.mDrawCalls;
		}
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x00028770 File Offset: 0x00026970
	private bool IsVisible(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
	{
		this.UpdateTransformMatrix();
		a = this.worldToLocal.MultiplyPoint3x4(a);
		b = this.worldToLocal.MultiplyPoint3x4(b);
		c = this.worldToLocal.MultiplyPoint3x4(c);
		d = this.worldToLocal.MultiplyPoint3x4(d);
		UIPanel.mTemp[0] = a.x;
		UIPanel.mTemp[1] = b.x;
		UIPanel.mTemp[2] = c.x;
		UIPanel.mTemp[3] = d.x;
		float num = Mathf.Min(UIPanel.mTemp);
		float num2 = Mathf.Max(UIPanel.mTemp);
		UIPanel.mTemp[0] = a.y;
		UIPanel.mTemp[1] = b.y;
		UIPanel.mTemp[2] = c.y;
		UIPanel.mTemp[3] = d.y;
		float num3 = Mathf.Min(UIPanel.mTemp);
		float num4 = Mathf.Max(UIPanel.mTemp);
		return num2 >= this.mMin.x && num4 >= this.mMin.y && num <= this.mMax.x && num3 <= this.mMax.y;
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x000288A8 File Offset: 0x00026AA8
	public bool IsVisible(Vector3 worldPos)
	{
		if (this.mAlpha < 0.001f)
		{
			return false;
		}
		if (this.mClipping == UIDrawCall.Clipping.None)
		{
			return true;
		}
		this.UpdateTransformMatrix();
		Vector3 vector = this.worldToLocal.MultiplyPoint3x4(worldPos);
		return vector.x >= this.mMin.x && vector.y >= this.mMin.y && vector.x <= this.mMax.x && vector.y <= this.mMax.y;
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x0002894C File Offset: 0x00026B4C
	public bool IsVisible(UIWidget w)
	{
		if (this.mAlpha < 0.001f)
		{
			return false;
		}
		if (!w.enabled || !NGUITools.GetActive(w.cachedGameObject) || w.alpha < 0.001f)
		{
			return false;
		}
		if (this.mClipping == UIDrawCall.Clipping.None)
		{
			return true;
		}
		Vector2 relativeSize = w.relativeSize;
		Vector2 vector = Vector2.Scale(w.pivotOffset, relativeSize);
		Vector2 v = vector;
		vector.x += relativeSize.x;
		vector.y -= relativeSize.y;
		Transform cachedTransform = w.cachedTransform;
		Vector3 a = cachedTransform.TransformPoint(vector);
		Vector3 b = cachedTransform.TransformPoint(new Vector2(vector.x, v.y));
		Vector3 c = cachedTransform.TransformPoint(new Vector2(v.x, vector.y));
		Vector3 d = cachedTransform.TransformPoint(v);
		return this.IsVisible(a, b, c, d);
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00004C62 File Offset: 0x00002E62
	public void MarkMaterialAsChanged(Material mat, bool sort)
	{
		if (mat != null)
		{
			if (sort)
			{
				this.mDepthChanged = true;
			}
			if (!this.mChanged.Contains(mat))
			{
				this.mChanged.Add(mat);
			}
		}
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00028A58 File Offset: 0x00026C58
	public void AddWidget(UIWidget w)
	{
		if (w != null && !this.mWidgets.Contains(w))
		{
			this.mWidgets.Add(w);
			if (!this.mChanged.Contains(w.material))
			{
				this.mChanged.Add(w.material);
			}
			this.mDepthChanged = true;
		}
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x00028ABC File Offset: 0x00026CBC
	public void RemoveWidget(UIWidget w)
	{
		if (w != null && w != null && this.mWidgets.Remove(w) && w.material != null)
		{
			this.mChanged.Add(w.material);
		}
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00028B14 File Offset: 0x00026D14
	private UIDrawCall GetDrawCall(Material mat, bool createIfMissing)
	{
		int i = 0;
		int size = this.drawCalls.size;
		while (i < size)
		{
			UIDrawCall uidrawCall = this.drawCalls.buffer[i];
			if (uidrawCall.material == mat)
			{
				return uidrawCall;
			}
			i++;
		}
		UIDrawCall uidrawCall2 = null;
		if (createIfMissing)
		{
			GameObject gameObject = new GameObject("_UIDrawCall [" + mat.name + "]");
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			gameObject.layer = this.cachedGameObject.layer;
			uidrawCall2 = gameObject.AddComponent<UIDrawCall>();
			uidrawCall2.material = mat;
			this.mDrawCalls.Add(uidrawCall2);
		}
		return uidrawCall2;
	}

	// Token: 0x060003AA RID: 938 RVA: 0x00004C9A File Offset: 0x00002E9A
	private void Awake()
	{
		this.mGo = base.gameObject;
		this.mTrans = base.transform;
	}

	// Token: 0x060003AB RID: 939 RVA: 0x00028BBC File Offset: 0x00026DBC
	private void Start()
	{
		this.mLayer = this.mGo.layer;
		UICamera uicamera = UICamera.FindCameraForLayer(this.mLayer);
		this.mCam = ((!(uicamera != null)) ? NGUITools.FindCameraForLayer(this.mLayer) : uicamera.cachedCamera);
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00028C10 File Offset: 0x00026E10
	private void OnEnable()
	{
		int i = 0;
		while (i < this.mWidgets.size)
		{
			UIWidget uiwidget = this.mWidgets.buffer[i];
			if (uiwidget != null)
			{
				this.MarkMaterialAsChanged(uiwidget.material, true);
				i++;
			}
			else
			{
				this.mWidgets.RemoveAt(i);
			}
		}
	}

	// Token: 0x060003AD RID: 941 RVA: 0x00028C74 File Offset: 0x00026E74
	private void OnDisable()
	{
		int i = this.mDrawCalls.size;
		while (i > 0)
		{
			UIDrawCall uidrawCall = this.mDrawCalls.buffer[--i];
			if (uidrawCall != null)
			{
				NGUITools.DestroyImmediate(uidrawCall.gameObject);
			}
		}
		this.mDrawCalls.Clear();
		this.mChanged.Clear();
	}

	// Token: 0x060003AE RID: 942 RVA: 0x00028CD8 File Offset: 0x00026ED8
	private void UpdateTransformMatrix()
	{
		if (this.mUpdateTime == 0f || this.mMatrixTime != this.mUpdateTime)
		{
			this.mMatrixTime = this.mUpdateTime;
			this.worldToLocal = this.cachedTransform.worldToLocalMatrix;
			if (this.mClipping != UIDrawCall.Clipping.None)
			{
				Vector2 a = new Vector2(this.mClipRange.z, this.mClipRange.w);
				if (a.x == 0f)
				{
					a.x = ((!(this.mCam == null)) ? this.mCam.pixelWidth : ((float)Screen.width));
				}
				if (a.y == 0f)
				{
					a.y = ((!(this.mCam == null)) ? this.mCam.pixelHeight : ((float)Screen.height));
				}
				a *= 0.5f;
				this.mMin.x = this.mClipRange.x - a.x;
				this.mMin.y = this.mClipRange.y - a.y;
				this.mMax.x = this.mClipRange.x + a.x;
				this.mMax.y = this.mClipRange.y + a.y;
			}
		}
	}

	// Token: 0x060003AF RID: 943 RVA: 0x00028E50 File Offset: 0x00027050
	public void UpdateDrawcalls()
	{
		Vector4 zero = Vector4.zero;
		if (this.mClipping != UIDrawCall.Clipping.None)
		{
			zero = new Vector4(this.mClipRange.x, this.mClipRange.y, this.mClipRange.z * 0.5f, this.mClipRange.w * 0.5f);
		}
		if (zero.z == 0f)
		{
			zero.z = (float)Screen.width * 0.5f;
		}
		if (zero.w == 0f)
		{
			zero.w = (float)Screen.height * 0.5f;
		}
		RuntimePlatform platform = Application.platform;
		if (platform == RuntimePlatform.WindowsPlayer || platform == RuntimePlatform.WindowsWebPlayer || platform == RuntimePlatform.WindowsEditor)
		{
			zero.x -= 0.5f;
			zero.y += 0.5f;
		}
		Transform cachedTransform = this.cachedTransform;
		int i = 0;
		int size = this.mDrawCalls.size;
		while (i < size)
		{
			UIDrawCall uidrawCall = this.mDrawCalls.buffer[i];
			uidrawCall.clipping = this.mClipping;
			uidrawCall.clipRange = zero;
			uidrawCall.clipSoftness = this.mClipSoftness;
			uidrawCall.depthPass = (this.depthPass && this.mClipping == UIDrawCall.Clipping.None);
			Transform transform = uidrawCall.transform;
			transform.position = cachedTransform.position;
			transform.rotation = cachedTransform.rotation;
			transform.localScale = cachedTransform.lossyScale;
			i++;
		}
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x00028FDC File Offset: 0x000271DC
	private void Fill(Material mat)
	{
		int i = 0;
		while (i < this.mWidgets.size)
		{
			UIWidget uiwidget = this.mWidgets.buffer[i];
			if (uiwidget == null)
			{
				this.mWidgets.RemoveAt(i);
			}
			else
			{
				if (uiwidget.material == mat && uiwidget.isVisible)
				{
					if (!(uiwidget.panel == this))
					{
						this.mWidgets.RemoveAt(i);
						continue;
					}
					if (this.generateNormals)
					{
						uiwidget.WriteToBuffers(this.mVerts, this.mUvs, this.mCols, this.mNorms, this.mTans);
					}
					else
					{
						uiwidget.WriteToBuffers(this.mVerts, this.mUvs, this.mCols, null, null);
					}
				}
				i++;
			}
		}
		if (this.mVerts.size > 0)
		{
			UIDrawCall drawCall = this.GetDrawCall(mat, true);
			drawCall.depthPass = (this.depthPass && this.mClipping == UIDrawCall.Clipping.None);
			drawCall.Set(this.mVerts, (!this.generateNormals) ? null : this.mNorms, (!this.generateNormals) ? null : this.mTans, this.mUvs, this.mCols);
		}
		else
		{
			UIDrawCall drawCall2 = this.GetDrawCall(mat, false);
			if (drawCall2 != null)
			{
				this.mDrawCalls.Remove(drawCall2);
				NGUITools.DestroyImmediate(drawCall2.gameObject);
			}
		}
		this.mVerts.Clear();
		this.mNorms.Clear();
		this.mTans.Clear();
		this.mUvs.Clear();
		this.mCols.Clear();
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x000291A8 File Offset: 0x000273A8
	private void LateUpdate()
	{
		this.mUpdateTime = Time.realtimeSinceStartup;
		this.UpdateTransformMatrix();
		if (this.mLayer != this.cachedGameObject.layer)
		{
			this.mLayer = this.mGo.layer;
			UICamera uicamera = UICamera.FindCameraForLayer(this.mLayer);
			this.mCam = ((!(uicamera != null)) ? NGUITools.FindCameraForLayer(this.mLayer) : uicamera.cachedCamera);
			UIPanel.SetChildLayer(this.cachedTransform, this.mLayer);
			int i = 0;
			int size = this.drawCalls.size;
			while (i < size)
			{
				this.mDrawCalls.buffer[i].gameObject.layer = this.mLayer;
				i++;
			}
		}
		bool forceVisible = !this.cullWhileDragging && (this.clipping == UIDrawCall.Clipping.None || this.mCullTime > this.mUpdateTime);
		int j = 0;
		int size2 = this.mWidgets.size;
		while (j < size2)
		{
			UIWidget uiwidget = this.mWidgets[j];
			if (uiwidget.UpdateGeometry(this, forceVisible) && !this.mChanged.Contains(uiwidget.material))
			{
				this.mChanged.Add(uiwidget.material);
			}
			j++;
		}
		if (this.mChanged.size != 0 && this.onChange != null)
		{
			this.onChange();
		}
		if (this.mDepthChanged)
		{
			this.mDepthChanged = false;
			this.mWidgets.Sort(new Comparison<UIWidget>(UIWidget.CompareFunc));
		}
		int k = 0;
		int size3 = this.mChanged.size;
		while (k < size3)
		{
			this.Fill(this.mChanged.buffer[k]);
			k++;
		}
		this.UpdateDrawcalls();
		this.mChanged.Clear();
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x000293A0 File Offset: 0x000275A0
	public void Refresh()
	{
		UIWidget[] componentsInChildren = base.GetComponentsInChildren<UIWidget>();
		int i = 0;
		int num = componentsInChildren.Length;
		while (i < num)
		{
			componentsInChildren[i].Update();
			i++;
		}
		this.LateUpdate();
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x000293D8 File Offset: 0x000275D8
	public Vector3 CalculateConstrainOffset(Vector2 min, Vector2 max)
	{
		float num = this.clipRange.z * 0.5f;
		float num2 = this.clipRange.w * 0.5f;
		Vector2 minRect = new Vector2(min.x, min.y);
		Vector2 maxRect = new Vector2(max.x, max.y);
		Vector2 minArea = new Vector2(this.clipRange.x - num, this.clipRange.y - num2);
		Vector2 maxArea = new Vector2(this.clipRange.x + num, this.clipRange.y + num2);
		if (this.clipping == UIDrawCall.Clipping.SoftClip)
		{
			minArea.x += this.clipSoftness.x;
			minArea.y += this.clipSoftness.y;
			maxArea.x -= this.clipSoftness.x;
			maxArea.y -= this.clipSoftness.y;
		}
		return NGUIMath.ConstrainRect(minRect, maxRect, minArea, maxArea);
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x00029520 File Offset: 0x00027720
	public bool ConstrainTargetToBounds(Transform target, ref Bounds targetBounds, bool immediate)
	{
		Vector3 b = this.CalculateConstrainOffset(targetBounds.min, targetBounds.max);
		if (b.magnitude > 0f)
		{
			if (immediate)
			{
				target.localPosition += b;
				targetBounds.center += b;
				SpringPosition component = target.GetComponent<SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			else
			{
				SpringPosition springPosition = SpringPosition.Begin(target.gameObject, target.localPosition + b, 13f);
				springPosition.ignoreTimeScale = true;
				springPosition.worldSpace = false;
			}
			return true;
		}
		return false;
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x000295D4 File Offset: 0x000277D4
	public bool ConstrainTargetToBounds(Transform target, bool immediate)
	{
		Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(this.cachedTransform, target);
		return this.ConstrainTargetToBounds(target, ref bounds, immediate);
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x000295F8 File Offset: 0x000277F8
	private static void SetChildLayer(Transform t, int layer)
	{
		for (int i = 0; i < t.childCount; i++)
		{
			Transform child = t.GetChild(i);
			if (child.GetComponent<UIPanel>() == null)
			{
				child.gameObject.layer = layer;
				UIPanel.SetChildLayer(child, layer);
			}
		}
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x00029648 File Offset: 0x00027848
	public static UIPanel Find(Transform trans, bool createIfMissing)
	{
		Transform y = trans;
		UIPanel uipanel = null;
		while (uipanel == null && trans != null)
		{
			uipanel = trans.GetComponent<UIPanel>();
			if (uipanel != null)
			{
				break;
			}
			if (trans.parent == null)
			{
				break;
			}
			trans = trans.parent;
		}
		if (createIfMissing && uipanel == null && trans != y)
		{
			uipanel = trans.gameObject.AddComponent<UIPanel>();
			UIPanel.SetChildLayer(uipanel.cachedTransform, uipanel.cachedGameObject.layer);
		}
		return uipanel;
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x00004CB4 File Offset: 0x00002EB4
	public static UIPanel Find(Transform trans)
	{
		return UIPanel.Find(trans, true);
	}

	// Token: 0x04000334 RID: 820
	public UIPanel.OnChangeDelegate onChange;

	// Token: 0x04000335 RID: 821
	public bool showInPanelTool = true;

	// Token: 0x04000336 RID: 822
	public bool generateNormals;

	// Token: 0x04000337 RID: 823
	public bool depthPass;

	// Token: 0x04000338 RID: 824
	public bool widgetsAreStatic;

	// Token: 0x04000339 RID: 825
	public bool cullWhileDragging;

	// Token: 0x0400033A RID: 826
	[HideInInspector]
	public Matrix4x4 worldToLocal = Matrix4x4.identity;

	// Token: 0x0400033B RID: 827
	[HideInInspector]
	[SerializeField]
	private float mAlpha = 1f;

	// Token: 0x0400033C RID: 828
	[HideInInspector]
	[SerializeField]
	private UIPanel.DebugInfo mDebugInfo = UIPanel.DebugInfo.Gizmos;

	// Token: 0x0400033D RID: 829
	[HideInInspector]
	[SerializeField]
	private UIDrawCall.Clipping mClipping;

	// Token: 0x0400033E RID: 830
	[HideInInspector]
	[SerializeField]
	private Vector4 mClipRange = Vector4.zero;

	// Token: 0x0400033F RID: 831
	[SerializeField]
	[HideInInspector]
	private Vector2 mClipSoftness = new Vector2(40f, 40f);

	// Token: 0x04000340 RID: 832
	private BetterList<UIWidget> mWidgets = new BetterList<UIWidget>();

	// Token: 0x04000341 RID: 833
	private BetterList<Material> mChanged = new BetterList<Material>();

	// Token: 0x04000342 RID: 834
	private BetterList<UIDrawCall> mDrawCalls = new BetterList<UIDrawCall>();

	// Token: 0x04000343 RID: 835
	private BetterList<Vector3> mVerts = new BetterList<Vector3>();

	// Token: 0x04000344 RID: 836
	private BetterList<Vector3> mNorms = new BetterList<Vector3>();

	// Token: 0x04000345 RID: 837
	private BetterList<Vector4> mTans = new BetterList<Vector4>();

	// Token: 0x04000346 RID: 838
	private BetterList<Vector2> mUvs = new BetterList<Vector2>();

	// Token: 0x04000347 RID: 839
	private BetterList<Color32> mCols = new BetterList<Color32>();

	// Token: 0x04000348 RID: 840
	private GameObject mGo;

	// Token: 0x04000349 RID: 841
	private Transform mTrans;

	// Token: 0x0400034A RID: 842
	private Camera mCam;

	// Token: 0x0400034B RID: 843
	private int mLayer = -1;

	// Token: 0x0400034C RID: 844
	private bool mDepthChanged;

	// Token: 0x0400034D RID: 845
	private float mCullTime;

	// Token: 0x0400034E RID: 846
	private float mUpdateTime;

	// Token: 0x0400034F RID: 847
	private float mMatrixTime;

	// Token: 0x04000350 RID: 848
	private static float[] mTemp = new float[4];

	// Token: 0x04000351 RID: 849
	private Vector2 mMin = Vector2.zero;

	// Token: 0x04000352 RID: 850
	private Vector2 mMax = Vector2.zero;

	// Token: 0x04000353 RID: 851
	private UIPanel[] mChildPanels;

	// Token: 0x02000088 RID: 136
	public enum DebugInfo
	{
		// Token: 0x04000355 RID: 853
		None,
		// Token: 0x04000356 RID: 854
		Gizmos,
		// Token: 0x04000357 RID: 855
		Geometry
	}

	// Token: 0x02000089 RID: 137
	// (Invoke) Token: 0x060003BA RID: 954
	public delegate void OnChangeDelegate();
}
