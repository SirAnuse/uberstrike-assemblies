﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200002D RID: 45
[AddComponentMenu("NGUI/Interaction/Popup List")]
[ExecuteInEditMode]
public class UIPopupList : MonoBehaviour
{
	// Token: 0x17000010 RID: 16
	// (get) Token: 0x060000E4 RID: 228 RVA: 0x00002D8F File Offset: 0x00000F8F
	public bool isOpen
	{
		get
		{
			return this.mChild != null;
		}
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x060000E5 RID: 229 RVA: 0x00002D9D File Offset: 0x00000F9D
	// (set) Token: 0x060000E6 RID: 230 RVA: 0x00019E40 File Offset: 0x00018040
	public string selection
	{
		get
		{
			return this.mSelectedItem;
		}
		set
		{
			if (this.mSelectedItem != value)
			{
				this.mSelectedItem = value;
				if (this.textLabel != null)
				{
					this.textLabel.text = ((!this.isLocalized) ? value : Localization.Localize(value));
				}
				UIPopupList.current = this;
				if (this.onSelectionChange != null)
				{
					this.onSelectionChange(this.mSelectedItem);
				}
				if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName) && Application.isPlaying)
				{
					this.eventReceiver.SendMessage(this.functionName, this.mSelectedItem, SendMessageOptions.DontRequireReceiver);
				}
				UIPopupList.current = null;
				if (this.textLabel == null)
				{
					this.mSelectedItem = null;
				}
			}
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x060000E7 RID: 231 RVA: 0x00019F1C File Offset: 0x0001811C
	// (set) Token: 0x060000E8 RID: 232 RVA: 0x00019F48 File Offset: 0x00018148
	private bool handleEvents
	{
		get
		{
			UIButtonKeys component = base.GetComponent<UIButtonKeys>();
			return component == null || !component.enabled;
		}
		set
		{
			UIButtonKeys component = base.GetComponent<UIButtonKeys>();
			if (component != null)
			{
				component.enabled = !value;
			}
		}
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00019F74 File Offset: 0x00018174
	private void Start()
	{
		if (this.textLabel != null)
		{
			if (string.IsNullOrEmpty(this.mSelectedItem))
			{
				if (this.items.Count > 0)
				{
					this.selection = this.items[0];
				}
			}
			else
			{
				string selection = this.mSelectedItem;
				this.mSelectedItem = null;
				this.selection = selection;
			}
		}
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00002DA5 File Offset: 0x00000FA5
	private void OnLocalize(Localization loc)
	{
		if (this.isLocalized && this.textLabel != null)
		{
			this.textLabel.text = loc.Get(this.mSelectedItem);
		}
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00019FE0 File Offset: 0x000181E0
	private void Highlight(UILabel lbl, bool instant)
	{
		if (this.mHighlight != null)
		{
			TweenPosition component = lbl.GetComponent<TweenPosition>();
			if (component != null && component.enabled)
			{
				return;
			}
			this.mHighlightedLabel = lbl;
			UIAtlas.Sprite atlasSprite = this.mHighlight.GetAtlasSprite();
			if (atlasSprite == null)
			{
				return;
			}
			float num = atlasSprite.inner.xMin - atlasSprite.outer.xMin;
			float y = atlasSprite.inner.yMin - atlasSprite.outer.yMin;
			Vector3 vector = lbl.cachedTransform.localPosition + new Vector3(-num, y, 1f);
			if (instant || !this.isAnimated)
			{
				this.mHighlight.cachedTransform.localPosition = vector;
			}
			else
			{
				TweenPosition.Begin(this.mHighlight.gameObject, 0.1f, vector).method = UITweener.Method.EaseOut;
			}
		}
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0001A0CC File Offset: 0x000182CC
	private void OnItemHover(GameObject go, bool isOver)
	{
		if (isOver)
		{
			UILabel component = go.GetComponent<UILabel>();
			this.Highlight(component, false);
		}
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0001A0F0 File Offset: 0x000182F0
	private void Select(UILabel lbl, bool instant)
	{
		this.Highlight(lbl, instant);
		UIEventListener component = lbl.gameObject.GetComponent<UIEventListener>();
		this.selection = (component.parameter as string);
		UIButtonSound[] components = base.GetComponents<UIButtonSound>();
		int i = 0;
		int num = components.Length;
		while (i < num)
		{
			UIButtonSound uibuttonSound = components[i];
			if (uibuttonSound.trigger == UIButtonSound.Trigger.OnClick)
			{
				NGUITools.PlaySound(uibuttonSound.audioClip, uibuttonSound.volume, 1f);
			}
			i++;
		}
	}

	// Token: 0x060000EE RID: 238 RVA: 0x00002DDA File Offset: 0x00000FDA
	private void OnItemPress(GameObject go, bool isPressed)
	{
		if (isPressed)
		{
			this.Select(go.GetComponent<UILabel>(), true);
		}
	}

	// Token: 0x060000EF RID: 239 RVA: 0x0001A16C File Offset: 0x0001836C
	private void OnKey(KeyCode key)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.handleEvents)
		{
			int num = this.mLabelList.IndexOf(this.mHighlightedLabel);
			if (key == KeyCode.UpArrow)
			{
				if (num > 0)
				{
					this.Select(this.mLabelList[num - 1], false);
				}
			}
			else if (key == KeyCode.DownArrow)
			{
				if (num + 1 < this.mLabelList.Count)
				{
					this.Select(this.mLabelList[num + 1], false);
				}
			}
			else if (key == KeyCode.Escape)
			{
				this.OnSelect(false);
			}
		}
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x0001A228 File Offset: 0x00018428
	private void OnSelect(bool isSelected)
	{
		if (!isSelected && this.mChild != null)
		{
			this.mLabelList.Clear();
			this.handleEvents = false;
			if (this.isAnimated)
			{
				UIWidget[] componentsInChildren = this.mChild.GetComponentsInChildren<UIWidget>();
				int i = 0;
				int num = componentsInChildren.Length;
				while (i < num)
				{
					UIWidget uiwidget = componentsInChildren[i];
					Color color = uiwidget.color;
					color.a = 0f;
					TweenColor.Begin(uiwidget.gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
					i++;
				}
				Collider[] componentsInChildren2 = this.mChild.GetComponentsInChildren<Collider>();
				int j = 0;
				int num2 = componentsInChildren2.Length;
				while (j < num2)
				{
					componentsInChildren2[j].enabled = false;
					j++;
				}
				UnityEngine.Object.Destroy(this.mChild, 0.15f);
			}
			else
			{
				UnityEngine.Object.Destroy(this.mChild);
			}
			this.mBackground = null;
			this.mHighlight = null;
			this.mChild = null;
		}
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x0001A328 File Offset: 0x00018528
	private void AnimateColor(UIWidget widget)
	{
		Color color = widget.color;
		widget.color = new Color(color.r, color.g, color.b, 0f);
		TweenColor.Begin(widget.gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x0001A378 File Offset: 0x00018578
	private void AnimatePosition(UIWidget widget, bool placeAbove, float bottom)
	{
		Vector3 localPosition = widget.cachedTransform.localPosition;
		Vector3 localPosition2 = (!placeAbove) ? new Vector3(localPosition.x, 0f, localPosition.z) : new Vector3(localPosition.x, bottom, localPosition.z);
		widget.cachedTransform.localPosition = localPosition2;
		GameObject gameObject = widget.gameObject;
		TweenPosition.Begin(gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x0001A3F0 File Offset: 0x000185F0
	private void AnimateScale(UIWidget widget, bool placeAbove, float bottom)
	{
		GameObject gameObject = widget.gameObject;
		Transform cachedTransform = widget.cachedTransform;
		float num = (float)this.font.size * this.textScale + this.mBgBorder * 2f;
		Vector3 localScale = cachedTransform.localScale;
		cachedTransform.localScale = new Vector3(localScale.x, num, localScale.z);
		TweenScale.Begin(gameObject, 0.15f, localScale).method = UITweener.Method.EaseOut;
		if (placeAbove)
		{
			Vector3 localPosition = cachedTransform.localPosition;
			cachedTransform.localPosition = new Vector3(localPosition.x, localPosition.y - localScale.y + num, localPosition.z);
			TweenPosition.Begin(gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
		}
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00002DEF File Offset: 0x00000FEF
	private void Animate(UIWidget widget, bool placeAbove, float bottom)
	{
		this.AnimateColor(widget);
		this.AnimatePosition(widget, placeAbove, bottom);
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0001A4AC File Offset: 0x000186AC
	private void OnClick()
	{
		if (this.mChild == null && this.atlas != null && this.font != null && this.items.Count > 0)
		{
			this.mLabelList.Clear();
			this.handleEvents = true;
			if (this.mPanel == null)
			{
				this.mPanel = UIPanel.Find(base.transform, true);
			}
			Transform transform = base.transform;
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(transform.parent, transform);
			this.mChild = new GameObject("Drop-down List");
			this.mChild.layer = base.gameObject.layer;
			Transform transform2 = this.mChild.transform;
			transform2.parent = transform.parent;
			transform2.localPosition = bounds.min;
			transform2.localRotation = Quaternion.identity;
			transform2.localScale = Vector3.one;
			this.mBackground = NGUITools.AddSprite(this.mChild, this.atlas, this.backgroundSprite);
			this.mBackground.pivot = UIWidget.Pivot.TopLeft;
			this.mBackground.depth = NGUITools.CalculateNextDepth(this.mPanel.gameObject);
			this.mBackground.color = this.backgroundColor;
			Vector4 border = this.mBackground.border;
			this.mBgBorder = border.y;
			this.mBackground.cachedTransform.localPosition = new Vector3(0f, border.y, 0f);
			this.mHighlight = NGUITools.AddSprite(this.mChild, this.atlas, this.highlightSprite);
			this.mHighlight.pivot = UIWidget.Pivot.TopLeft;
			this.mHighlight.color = this.highlightColor;
			UIAtlas.Sprite atlasSprite = this.mHighlight.GetAtlasSprite();
			if (atlasSprite == null)
			{
				return;
			}
			float num = atlasSprite.inner.yMin - atlasSprite.outer.yMin;
			float num2 = (float)this.font.size * this.font.pixelSize * this.textScale;
			float num3 = 0f;
			float num4 = -this.padding.y;
			List<UILabel> list = new List<UILabel>();
			int i = 0;
			int count = this.items.Count;
			while (i < count)
			{
				string text = this.items[i];
				UILabel uilabel = NGUITools.AddWidget<UILabel>(this.mChild);
				uilabel.pivot = UIWidget.Pivot.TopLeft;
				uilabel.font = this.font;
				uilabel.text = ((!this.isLocalized || !(Localization.instance != null)) ? text : Localization.instance.Get(text));
				uilabel.color = this.textColor;
				uilabel.cachedTransform.localPosition = new Vector3(border.x + this.padding.x, num4, -1f);
				uilabel.MakePixelPerfect();
				if (this.textScale != 1f)
				{
					Vector3 localScale = uilabel.cachedTransform.localScale;
					uilabel.cachedTransform.localScale = localScale * this.textScale;
				}
				list.Add(uilabel);
				num4 -= num2;
				num4 -= this.padding.y;
				num3 = Mathf.Max(num3, uilabel.relativeSize.x * num2);
				UIEventListener uieventListener = UIEventListener.Get(uilabel.gameObject);
				uieventListener.onHover = new UIEventListener.BoolDelegate(this.OnItemHover);
				uieventListener.onPress = new UIEventListener.BoolDelegate(this.OnItemPress);
				uieventListener.parameter = text;
				if (this.mSelectedItem == text)
				{
					this.Highlight(uilabel, true);
				}
				this.mLabelList.Add(uilabel);
				i++;
			}
			num3 = Mathf.Max(num3, bounds.size.x - (border.x + this.padding.x) * 2f);
			Vector3 center = new Vector3(num3 * 0.5f / num2, -0.5f, 0f);
			Vector3 size = new Vector3(num3 / num2, (num2 + this.padding.y) / num2, 1f);
			int j = 0;
			int count2 = list.Count;
			while (j < count2)
			{
				UILabel uilabel2 = list[j];
				BoxCollider boxCollider = NGUITools.AddWidgetCollider(uilabel2.gameObject);
				center.z = boxCollider.center.z;
				boxCollider.center = center;
				boxCollider.size = size;
				j++;
			}
			num3 += (border.x + this.padding.x) * 2f;
			num4 -= border.y;
			this.mBackground.cachedTransform.localScale = new Vector3(num3, -num4 + border.y, 1f);
			this.mHighlight.cachedTransform.localScale = new Vector3(num3 - (border.x + this.padding.x) * 2f + (atlasSprite.inner.xMin - atlasSprite.outer.xMin) * 2f, num2 + num * 2f, 1f);
			bool flag = this.position == UIPopupList.Position.Above;
			if (this.position == UIPopupList.Position.Auto)
			{
				UICamera uicamera = UICamera.FindCameraForLayer(base.gameObject.layer);
				if (uicamera != null)
				{
					flag = (uicamera.cachedCamera.WorldToViewportPoint(transform.position).y < 0.5f);
				}
			}
			if (this.isAnimated)
			{
				float bottom = num4 + num2;
				this.Animate(this.mHighlight, flag, bottom);
				int k = 0;
				int count3 = list.Count;
				while (k < count3)
				{
					this.Animate(list[k], flag, bottom);
					k++;
				}
				this.AnimateColor(this.mBackground);
				this.AnimateScale(this.mBackground, flag, bottom);
			}
			if (flag)
			{
				transform2.localPosition = new Vector3(bounds.min.x, bounds.max.y - num4 - border.y, bounds.min.z);
			}
		}
		else
		{
			this.OnSelect(false);
		}
	}

	// Token: 0x04000119 RID: 281
	private const float animSpeed = 0.15f;

	// Token: 0x0400011A RID: 282
	public static UIPopupList current;

	// Token: 0x0400011B RID: 283
	public UIAtlas atlas;

	// Token: 0x0400011C RID: 284
	public UIFont font;

	// Token: 0x0400011D RID: 285
	public UILabel textLabel;

	// Token: 0x0400011E RID: 286
	public string backgroundSprite;

	// Token: 0x0400011F RID: 287
	public string highlightSprite;

	// Token: 0x04000120 RID: 288
	public UIPopupList.Position position;

	// Token: 0x04000121 RID: 289
	public List<string> items = new List<string>();

	// Token: 0x04000122 RID: 290
	public Vector2 padding = new Vector3(4f, 4f);

	// Token: 0x04000123 RID: 291
	public float textScale = 1f;

	// Token: 0x04000124 RID: 292
	public Color textColor = Color.white;

	// Token: 0x04000125 RID: 293
	public Color backgroundColor = Color.white;

	// Token: 0x04000126 RID: 294
	public Color highlightColor = new Color(0.596078455f, 1f, 0.2f, 1f);

	// Token: 0x04000127 RID: 295
	public bool isAnimated = true;

	// Token: 0x04000128 RID: 296
	public bool isLocalized;

	// Token: 0x04000129 RID: 297
	public GameObject eventReceiver;

	// Token: 0x0400012A RID: 298
	public string functionName = "OnSelectionChange";

	// Token: 0x0400012B RID: 299
	public UIPopupList.OnSelectionChange onSelectionChange;

	// Token: 0x0400012C RID: 300
	[HideInInspector]
	[SerializeField]
	private string mSelectedItem;

	// Token: 0x0400012D RID: 301
	private UIPanel mPanel;

	// Token: 0x0400012E RID: 302
	private GameObject mChild;

	// Token: 0x0400012F RID: 303
	private UISprite mBackground;

	// Token: 0x04000130 RID: 304
	private UISprite mHighlight;

	// Token: 0x04000131 RID: 305
	private UILabel mHighlightedLabel;

	// Token: 0x04000132 RID: 306
	private List<UILabel> mLabelList = new List<UILabel>();

	// Token: 0x04000133 RID: 307
	private float mBgBorder;

	// Token: 0x0200002E RID: 46
	public enum Position
	{
		// Token: 0x04000135 RID: 309
		Auto,
		// Token: 0x04000136 RID: 310
		Above,
		// Token: 0x04000137 RID: 311
		Below
	}

	// Token: 0x0200002F RID: 47
	// (Invoke) Token: 0x060000F7 RID: 247
	public delegate void OnSelectionChange(string item);
}
