using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000093 RID: 147
[AddComponentMenu("NGUI/UI/Text List")]
public class UITextList : MonoBehaviour
{
	// Token: 0x06000401 RID: 1025 RVA: 0x00004F99 File Offset: 0x00003199
	public void Clear()
	{
		this.mParagraphs.Clear();
		this.UpdateVisibleText();
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x00004FAC File Offset: 0x000031AC
	public void Add(string text)
	{
		this.Add(text, true);
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x0002C58C File Offset: 0x0002A78C
	protected void Add(string text, bool updateVisible)
	{
		UITextList.Paragraph paragraph;
		if (this.mParagraphs.Count < this.maxEntries)
		{
			paragraph = new UITextList.Paragraph();
		}
		else
		{
			paragraph = this.mParagraphs[0];
			this.mParagraphs.RemoveAt(0);
		}
		paragraph.text = text;
		this.mParagraphs.Add(paragraph);
		if (this.textLabel != null && this.textLabel.font != null)
		{
			paragraph.lines = this.textLabel.font.WrapText(paragraph.text, this.maxWidth / this.textLabel.transform.localScale.y, this.textLabel.maxLineCount, this.textLabel.supportEncoding, this.textLabel.symbolStyle).Split(this.mSeparator);
			this.mTotalLines = 0;
			int i = 0;
			int count = this.mParagraphs.Count;
			while (i < count)
			{
				this.mTotalLines += this.mParagraphs[i].lines.Length;
				i++;
			}
		}
		if (updateVisible)
		{
			this.UpdateVisibleText();
		}
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x0002C6C8 File Offset: 0x0002A8C8
	private void Awake()
	{
		if (this.textLabel == null)
		{
			this.textLabel = base.GetComponentInChildren<UILabel>();
		}
		if (this.textLabel != null)
		{
			this.textLabel.lineWidth = 0;
		}
		Collider collider = base.collider;
		if (collider != null)
		{
			if (this.maxHeight <= 0f)
			{
				this.maxHeight = collider.bounds.size.y / base.transform.lossyScale.y;
			}
			if (this.maxWidth <= 0f)
			{
				this.maxWidth = collider.bounds.size.x / base.transform.lossyScale.x;
			}
		}
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x00004FB6 File Offset: 0x000031B6
	private void OnSelect(bool selected)
	{
		this.mSelected = selected;
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x0002C7A8 File Offset: 0x0002A9A8
	protected void UpdateVisibleText()
	{
		if (this.textLabel != null)
		{
			UIFont font = this.textLabel.font;
			if (font != null)
			{
				int num = 0;
				int num2 = (this.maxHeight <= 0f) ? 100000 : Mathf.FloorToInt(this.maxHeight / this.textLabel.cachedTransform.localScale.y);
				int num3 = Mathf.RoundToInt(this.mScroll);
				if (num2 + num3 > this.mTotalLines)
				{
					num3 = Mathf.Max(0, this.mTotalLines - num2);
					this.mScroll = (float)num3;
				}
				if (this.style == UITextList.Style.Chat)
				{
					num3 = Mathf.Max(0, this.mTotalLines - num2 - num3);
				}
				StringBuilder stringBuilder = new StringBuilder();
				int i = 0;
				int count = this.mParagraphs.Count;
				while (i < count)
				{
					UITextList.Paragraph paragraph = this.mParagraphs[i];
					int j = 0;
					int num4 = paragraph.lines.Length;
					while (j < num4)
					{
						string value = paragraph.lines[j];
						if (num3 > 0)
						{
							num3--;
						}
						else
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append("\n");
							}
							stringBuilder.Append(value);
							num++;
							if (num >= num2)
							{
								break;
							}
						}
						j++;
					}
					if (num >= num2)
					{
						break;
					}
					i++;
				}
				this.textLabel.text = stringBuilder.ToString();
			}
		}
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x0002C938 File Offset: 0x0002AB38
	private void OnScroll(float val)
	{
		if (this.mSelected && this.supportScrollWheel)
		{
			val *= ((this.style != UITextList.Style.Chat) ? -10f : 10f);
			this.mScroll = Mathf.Max(0f, this.mScroll + val);
			this.UpdateVisibleText();
		}
	}

	// Token: 0x04000396 RID: 918
	public UITextList.Style style;

	// Token: 0x04000397 RID: 919
	public UILabel textLabel;

	// Token: 0x04000398 RID: 920
	public float maxWidth;

	// Token: 0x04000399 RID: 921
	public float maxHeight;

	// Token: 0x0400039A RID: 922
	public int maxEntries = 50;

	// Token: 0x0400039B RID: 923
	public bool supportScrollWheel = true;

	// Token: 0x0400039C RID: 924
	protected char[] mSeparator = new char[]
	{
		'\n'
	};

	// Token: 0x0400039D RID: 925
	protected List<UITextList.Paragraph> mParagraphs = new List<UITextList.Paragraph>();

	// Token: 0x0400039E RID: 926
	protected float mScroll;

	// Token: 0x0400039F RID: 927
	protected bool mSelected;

	// Token: 0x040003A0 RID: 928
	protected int mTotalLines;

	// Token: 0x02000094 RID: 148
	public enum Style
	{
		// Token: 0x040003A2 RID: 930
		Text,
		// Token: 0x040003A3 RID: 931
		Chat
	}

	// Token: 0x02000095 RID: 149
	protected class Paragraph
	{
		// Token: 0x040003A4 RID: 932
		public string text;

		// Token: 0x040003A5 RID: 933
		public string[] lines;
	}
}
