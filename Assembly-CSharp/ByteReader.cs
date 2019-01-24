using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000048 RID: 72
public class ByteReader
{
	// Token: 0x0600018A RID: 394 RVA: 0x00003306 File Offset: 0x00001506
	public ByteReader(byte[] bytes)
	{
		this.mBuffer = bytes;
	}

	// Token: 0x0600018B RID: 395 RVA: 0x00003315 File Offset: 0x00001515
	public ByteReader(TextAsset asset)
	{
		this.mBuffer = asset.bytes;
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x0600018C RID: 396 RVA: 0x00003329 File Offset: 0x00001529
	public bool canRead
	{
		get
		{
			return this.mBuffer != null && this.mOffset < this.mBuffer.Length;
		}
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00003349 File Offset: 0x00001549
	private static string ReadLine(byte[] buffer, int start, int count)
	{
		return Encoding.UTF8.GetString(buffer, start, count);
	}

	// Token: 0x0600018E RID: 398 RVA: 0x0001D218 File Offset: 0x0001B418
	public string ReadLine()
	{
		int num = this.mBuffer.Length;
		while (this.mOffset < num && this.mBuffer[this.mOffset] < 32)
		{
			this.mOffset++;
		}
		int i = this.mOffset;
		if (i < num)
		{
			while (i < num)
			{
				int num2 = (int)this.mBuffer[i++];
				if (num2 == 10 || num2 == 13)
				{
					IL_81:
					string result = ByteReader.ReadLine(this.mBuffer, this.mOffset, i - this.mOffset - 1);
					this.mOffset = i;
					return result;
				}
			}
			i++;
		}
		this.mOffset = num;
		return null;
	}

	// Token: 0x0600018F RID: 399 RVA: 0x0001D2D8 File Offset: 0x0001B4D8
	public Dictionary<string, string> ReadDictionary()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		char[] separator = new char[]
		{
			'='
		};
		while (this.canRead)
		{
			string text = this.ReadLine();
			if (text == null)
			{
				break;
			}
			if (!text.StartsWith("//"))
			{
				string[] array = text.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 2)
				{
					string key = array[0].Trim();
					string value = array[1].Trim().Replace("\\n", "\n");
					dictionary[key] = value;
				}
			}
		}
		return dictionary;
	}

	// Token: 0x040001B4 RID: 436
	private byte[] mBuffer;

	// Token: 0x040001B5 RID: 437
	private int mOffset;
}
