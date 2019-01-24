using System;
using UnityEngine;

// Token: 0x0200006B RID: 107
[AddComponentMenu("NGUI/Examples/Typewriter Effect")]
[RequireComponent(typeof(UILabel))]
public class TypewriterEffect : MonoBehaviour
{
	// Token: 0x060002B8 RID: 696 RVA: 0x0002192C File Offset: 0x0001FB2C
	private void Update()
	{
		if (this.mLabel == null)
		{
			this.mLabel = base.GetComponent<UILabel>();
			this.mLabel.supportEncoding = false;
			this.mLabel.symbolStyle = UIFont.SymbolStyle.None;
			this.mText = this.mLabel.font.WrapText(this.mLabel.text, (float)this.mLabel.lineWidth / this.mLabel.cachedTransform.localScale.x, this.mLabel.maxLineCount, false, UIFont.SymbolStyle.None);
		}
		if (this.mOffset < this.mText.Length)
		{
			if (this.mNextChar <= Time.time)
			{
				this.charsPerSecond = Mathf.Max(1, this.charsPerSecond);
				float num = 1f / (float)this.charsPerSecond;
				char c = this.mText[this.mOffset];
				if (c == '.' || c == '\n' || c == '!' || c == '?')
				{
					num *= 4f;
				}
				this.mNextChar = Time.time + num;
				this.mLabel.text = this.mText.Substring(0, ++this.mOffset);
			}
		}
		else if (this.loop)
		{
			this.mOffset = 0;
			this.mText = this.mLabel.font.WrapText(this.mLabel.text, (float)this.mLabel.lineWidth / this.mLabel.cachedTransform.localScale.x, this.mLabel.maxLineCount, false, UIFont.SymbolStyle.None);
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x0400024A RID: 586
	public int charsPerSecond = 40;

	// Token: 0x0400024B RID: 587
	public bool loop;

	// Token: 0x0400024C RID: 588
	private UILabel mLabel;

	// Token: 0x0400024D RID: 589
	private string mText;

	// Token: 0x0400024E RID: 590
	private int mOffset;

	// Token: 0x0400024F RID: 591
	private float mNextChar;
}
