using System;
using System.Collections.Generic;

// Token: 0x020001E9 RID: 489
public class PopupStack<T>
{
	// Token: 0x17000355 RID: 853
	// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x0000A156 File Offset: 0x00008356
	public int Count
	{
		get
		{
			return this.items.Count;
		}
	}

	// Token: 0x06000DC7 RID: 3527 RVA: 0x0005FB88 File Offset: 0x0005DD88
	public T Peek()
	{
		if (this.items.Count > 0)
		{
			return this.items[this.items.Count - 1];
		}
		return default(T);
	}

	// Token: 0x06000DC8 RID: 3528 RVA: 0x0000A163 File Offset: 0x00008363
	public void Push(T item)
	{
		this.items.Add(item);
	}

	// Token: 0x06000DC9 RID: 3529 RVA: 0x0005FBCC File Offset: 0x0005DDCC
	public T Pop()
	{
		if (this.items.Count > 0)
		{
			T t = this.items[this.items.Count - 1];
			this.items.Remove(t);
			return t;
		}
		return default(T);
	}

	// Token: 0x06000DCA RID: 3530 RVA: 0x0000A171 File Offset: 0x00008371
	public void Remove(int itemAtPosition)
	{
		this.items.RemoveAt(itemAtPosition);
	}

	// Token: 0x06000DCB RID: 3531 RVA: 0x0000A17F File Offset: 0x0000837F
	public void Remove(T item)
	{
		this.items.Remove(item);
	}

	// Token: 0x06000DCC RID: 3532 RVA: 0x0000A18E File Offset: 0x0000838E
	public void Clear()
	{
		this.items.Clear();
	}

	// Token: 0x04000CF6 RID: 3318
	private List<T> items = new List<T>();
}
