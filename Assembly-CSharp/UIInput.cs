using System;
using UnityEngine;

// Token: 0x0200007E RID: 126
[AddComponentMenu("NGUI/UI/Input (Basic)")]
public class UIInput : MonoBehaviour
{
	// Token: 0x1700008D RID: 141
	// (get) Token: 0x06000346 RID: 838 RVA: 0x000047A1 File Offset: 0x000029A1
	// (set) Token: 0x06000347 RID: 839 RVA: 0x00026B68 File Offset: 0x00024D68
	public virtual string text
	{
		get
		{
			if (this.mDoInit)
			{
				this.Init();
			}
			return this.mText;
		}
		set
		{
			if (this.mDoInit)
			{
				this.Init();
			}
			this.mText = value;
			if (this.label != null)
			{
				if (string.IsNullOrEmpty(value))
				{
					value = this.mDefaultText;
				}
				this.label.supportEncoding = false;
				this.label.text = ((!this.selected) ? value : (value + this.caratChar));
				this.label.showLastPasswordChar = this.selected;
				this.label.color = ((!this.selected && !(value != this.mDefaultText)) ? this.mDefaultColor : this.activeColor);
			}
		}
	}

	// Token: 0x1700008E RID: 142
	// (get) Token: 0x06000348 RID: 840 RVA: 0x000047BA File Offset: 0x000029BA
	// (set) Token: 0x06000349 RID: 841 RVA: 0x000047CC File Offset: 0x000029CC
	public bool selected
	{
		get
		{
			return UICamera.selectedObject == base.gameObject;
		}
		set
		{
			if (!value && UICamera.selectedObject == base.gameObject)
			{
				UICamera.selectedObject = null;
			}
			else if (value)
			{
				UICamera.selectedObject = base.gameObject;
			}
		}
	}

	// Token: 0x1700008F RID: 143
	// (get) Token: 0x0600034A RID: 842 RVA: 0x00004805 File Offset: 0x00002A05
	// (set) Token: 0x0600034B RID: 843 RVA: 0x0000480D File Offset: 0x00002A0D
	public string defaultText
	{
		get
		{
			return this.mDefaultText;
		}
		set
		{
			if (this.label.text == this.mDefaultText)
			{
				this.label.text = value;
			}
			this.mDefaultText = value;
		}
	}

	// Token: 0x0600034C RID: 844 RVA: 0x00026C30 File Offset: 0x00024E30
	protected void Init()
	{
		if (this.mDoInit)
		{
			this.mDoInit = false;
			if (this.label == null)
			{
				this.label = base.GetComponentInChildren<UILabel>();
			}
			if (this.label != null)
			{
				if (this.useLabelTextAtStart)
				{
					this.mText = this.label.text;
				}
				this.mDefaultText = this.label.text;
				this.mDefaultColor = this.label.color;
				this.label.supportEncoding = false;
				this.label.password = this.isPassword;
				this.mPivot = this.label.pivot;
				this.mPosition = this.label.cachedTransform.localPosition.x;
			}
			else
			{
				base.enabled = false;
			}
		}
	}

	// Token: 0x0600034D RID: 845 RVA: 0x0000483D File Offset: 0x00002A3D
	private void OnEnable()
	{
		if (UICamera.IsHighlighted(base.gameObject))
		{
			this.OnSelect(true);
		}
	}

	// Token: 0x0600034E RID: 846 RVA: 0x00004856 File Offset: 0x00002A56
	private void OnDisable()
	{
		if (UICamera.IsHighlighted(base.gameObject))
		{
			this.OnSelect(false);
		}
	}

	// Token: 0x0600034F RID: 847 RVA: 0x00026D14 File Offset: 0x00024F14
	private void OnSelect(bool isSelected)
	{
		if (this.mDoInit)
		{
			this.Init();
		}
		if (this.label != null && base.enabled && NGUITools.GetActive(base.gameObject))
		{
			if (isSelected)
			{
				this.mText = ((this.useLabelTextAtStart || !(this.label.text == this.mDefaultText)) ? this.label.text : string.Empty);
				this.label.color = this.activeColor;
				if (this.isPassword)
				{
					this.label.password = true;
				}
				Input.imeCompositionMode = IMECompositionMode.On;
				Transform cachedTransform = this.label.cachedTransform;
				Vector3 position = this.label.pivotOffset;
				position.y += this.label.relativeSize.y;
				position = cachedTransform.TransformPoint(position);
				Input.compositionCursorPos = UICamera.currentCamera.WorldToScreenPoint(position);
				this.UpdateLabel();
			}
			else
			{
				if (string.IsNullOrEmpty(this.mText))
				{
					this.label.text = this.mDefaultText;
					this.label.color = this.mDefaultColor;
					if (this.isPassword)
					{
						this.label.password = false;
					}
				}
				else
				{
					this.label.text = this.mText;
				}
				this.label.showLastPasswordChar = false;
				Input.imeCompositionMode = IMECompositionMode.Off;
				this.RestoreLabel();
			}
		}
	}

	// Token: 0x06000350 RID: 848 RVA: 0x00026EB0 File Offset: 0x000250B0
	private void Update()
	{
		if (this.selected)
		{
			if (this.selectOnTab != null && Input.GetKeyDown(KeyCode.Tab))
			{
				UICamera.selectedObject = this.selectOnTab;
			}
			if (Input.GetKeyDown(KeyCode.V) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
			{
				this.Append(NGUITools.clipboard);
			}
			if (this.mLastIME != Input.compositionString)
			{
				this.mLastIME = Input.compositionString;
				this.UpdateLabel();
			}
		}
	}

	// Token: 0x06000351 RID: 849 RVA: 0x00026F4C File Offset: 0x0002514C
	private void OnInput(string input)
	{
		if (this.mDoInit)
		{
			this.Init();
		}
		if (this.selected && base.enabled && NGUITools.GetActive(base.gameObject))
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				return;
			}
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				return;
			}
			this.Append(input);
		}
	}

	// Token: 0x06000352 RID: 850 RVA: 0x00026FB0 File Offset: 0x000251B0
	private void Append(string input)
	{
		int i = 0;
		int length = input.Length;
		while (i < length)
		{
			char c = input[i];
			if (c == '\b')
			{
				if (this.mText.Length > 0)
				{
					this.mText = this.mText.Substring(0, this.mText.Length - 1);
					base.SendMessage("OnInputChanged", this, SendMessageOptions.DontRequireReceiver);
				}
			}
			else if (c == '\r' || c == '\n')
			{
				if ((UICamera.current.submitKey0 == KeyCode.Return || UICamera.current.submitKey1 == KeyCode.Return) && (!this.label.multiLine || (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))))
				{
					UIInput.current = this;
					if (this.onSubmit != null)
					{
						this.onSubmit(this.mText);
					}
					if (this.eventReceiver == null)
					{
						this.eventReceiver = base.gameObject;
					}
					this.eventReceiver.SendMessage(this.functionName, this.mText, SendMessageOptions.DontRequireReceiver);
					UIInput.current = null;
					this.selected = false;
					return;
				}
				if (this.validator != null)
				{
					c = this.validator(this.mText, c);
				}
				if (c != '\0')
				{
					if (c == '\n' || c == '\r')
					{
						if (this.label.multiLine)
						{
							this.mText += "\n";
						}
					}
					else
					{
						this.mText += c;
					}
					base.SendMessage("OnInputChanged", this, SendMessageOptions.DontRequireReceiver);
				}
			}
			else if (c >= ' ')
			{
				if (this.validator != null)
				{
					c = this.validator(this.mText, c);
				}
				if (c != '\0')
				{
					this.mText += c;
					base.SendMessage("OnInputChanged", this, SendMessageOptions.DontRequireReceiver);
				}
			}
			i++;
		}
		this.UpdateLabel();
	}

	// Token: 0x06000353 RID: 851 RVA: 0x000271D4 File Offset: 0x000253D4
	private void UpdateLabel()
	{
		if (this.mDoInit)
		{
			this.Init();
		}
		if (this.maxChars > 0 && this.mText.Length > this.maxChars)
		{
			this.mText = this.mText.Substring(0, this.maxChars);
		}
		if (this.label.font != null)
		{
			string text;
			if (this.isPassword && this.selected)
			{
				text = string.Empty;
				int i = 0;
				int length = this.mText.Length;
				while (i < length)
				{
					text += "*";
					i++;
				}
				text = text + Input.compositionString + this.caratChar;
			}
			else
			{
				text = ((!this.selected) ? this.mText : (this.mText + Input.compositionString + this.caratChar));
			}
			this.label.supportEncoding = false;
			if (!this.label.shrinkToFit)
			{
				if (this.label.multiLine)
				{
					text = this.label.font.WrapText(text, (float)this.label.lineWidth / this.label.cachedTransform.localScale.x, 0, false, UIFont.SymbolStyle.None);
				}
				else
				{
					string endOfLineThatFits = this.label.font.GetEndOfLineThatFits(text, (float)this.label.lineWidth / this.label.cachedTransform.localScale.x, false, UIFont.SymbolStyle.None);
					if (endOfLineThatFits != text)
					{
						text = endOfLineThatFits;
						Vector3 localPosition = this.label.cachedTransform.localPosition;
						localPosition.x = this.mPosition + (float)this.label.lineWidth;
						if (this.mPivot == UIWidget.Pivot.Left)
						{
							this.label.pivot = UIWidget.Pivot.Right;
						}
						else if (this.mPivot == UIWidget.Pivot.TopLeft)
						{
							this.label.pivot = UIWidget.Pivot.TopRight;
						}
						else if (this.mPivot == UIWidget.Pivot.BottomLeft)
						{
							this.label.pivot = UIWidget.Pivot.BottomRight;
						}
						this.label.cachedTransform.localPosition = localPosition;
					}
					else
					{
						this.RestoreLabel();
					}
				}
			}
			this.label.text = text;
			this.label.showLastPasswordChar = this.selected;
		}
	}

	// Token: 0x06000354 RID: 852 RVA: 0x00027438 File Offset: 0x00025638
	private void RestoreLabel()
	{
		if (this.label != null)
		{
			this.label.pivot = this.mPivot;
			Vector3 localPosition = this.label.cachedTransform.localPosition;
			localPosition.x = this.mPosition;
			this.label.cachedTransform.localPosition = localPosition;
		}
	}

	// Token: 0x040002F2 RID: 754
	public static UIInput current;

	// Token: 0x040002F3 RID: 755
	public UILabel label;

	// Token: 0x040002F4 RID: 756
	public int maxChars;

	// Token: 0x040002F5 RID: 757
	public string caratChar = "|";

	// Token: 0x040002F6 RID: 758
	public UIInput.Validator validator;

	// Token: 0x040002F7 RID: 759
	public UIInput.KeyboardType type;

	// Token: 0x040002F8 RID: 760
	public bool isPassword;

	// Token: 0x040002F9 RID: 761
	public bool autoCorrect;

	// Token: 0x040002FA RID: 762
	public bool useLabelTextAtStart;

	// Token: 0x040002FB RID: 763
	public Color activeColor = Color.white;

	// Token: 0x040002FC RID: 764
	public GameObject selectOnTab;

	// Token: 0x040002FD RID: 765
	public GameObject eventReceiver;

	// Token: 0x040002FE RID: 766
	public string functionName = "OnSubmit";

	// Token: 0x040002FF RID: 767
	public UIInput.OnSubmit onSubmit;

	// Token: 0x04000300 RID: 768
	private string mText = string.Empty;

	// Token: 0x04000301 RID: 769
	private string mDefaultText = string.Empty;

	// Token: 0x04000302 RID: 770
	private Color mDefaultColor = Color.white;

	// Token: 0x04000303 RID: 771
	private UIWidget.Pivot mPivot = UIWidget.Pivot.Left;

	// Token: 0x04000304 RID: 772
	private float mPosition;

	// Token: 0x04000305 RID: 773
	private string mLastIME = string.Empty;

	// Token: 0x04000306 RID: 774
	private bool mDoInit = true;

	// Token: 0x0200007F RID: 127
	public enum KeyboardType
	{
		// Token: 0x04000308 RID: 776
		Default,
		// Token: 0x04000309 RID: 777
		ASCIICapable,
		// Token: 0x0400030A RID: 778
		NumbersAndPunctuation,
		// Token: 0x0400030B RID: 779
		URL,
		// Token: 0x0400030C RID: 780
		NumberPad,
		// Token: 0x0400030D RID: 781
		PhonePad,
		// Token: 0x0400030E RID: 782
		NamePhonePad,
		// Token: 0x0400030F RID: 783
		EmailAddress
	}

	// Token: 0x02000080 RID: 128
	// (Invoke) Token: 0x06000356 RID: 854
	public delegate char Validator(string currentText, char nextChar);

	// Token: 0x02000081 RID: 129
	// (Invoke) Token: 0x0600035A RID: 858
	public delegate void OnSubmit(string inputString);
}
