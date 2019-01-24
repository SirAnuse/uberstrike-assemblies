using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000046 RID: 70
public class BetterList<T>
{
	// Token: 0x06000175 RID: 373 RVA: 0x0001CD20 File Offset: 0x0001AF20
	public IEnumerator<T> GetEnumerator()
	{
		if (this.buffer != null)
		{
			for (int i = 0; i < this.size; i++)
			{
				yield return this.buffer[i];
			}
		}
		yield break;
	}

	// Token: 0x1700002F RID: 47
	public T this[int i]
	{
		get
		{
			return this.buffer[i];
		}
		set
		{
			this.buffer[i] = value;
		}
	}

	// Token: 0x06000178 RID: 376 RVA: 0x0001CD3C File Offset: 0x0001AF3C
	private void AllocateMore()
	{
		T[] array = (this.buffer == null) ? new T[32] : new T[Mathf.Max(this.buffer.Length << 1, 32)];
		if (this.buffer != null && this.size > 0)
		{
			this.buffer.CopyTo(array, 0);
		}
		this.buffer = array;
	}

	// Token: 0x06000179 RID: 377 RVA: 0x0001CDA4 File Offset: 0x0001AFA4
	private void Trim()
	{
		if (this.size > 0)
		{
			if (this.size < this.buffer.Length)
			{
				T[] array = new T[this.size];
				for (int i = 0; i < this.size; i++)
				{
					array[i] = this.buffer[i];
				}
				this.buffer = array;
			}
		}
		else
		{
			this.buffer = null;
		}
	}

	// Token: 0x0600017A RID: 378 RVA: 0x000032C1 File Offset: 0x000014C1
	public void Clear()
	{
		this.size = 0;
	}

	// Token: 0x0600017B RID: 379 RVA: 0x000032CA File Offset: 0x000014CA
	public void Release()
	{
		this.size = 0;
		this.buffer = null;
	}

	// Token: 0x0600017C RID: 380 RVA: 0x0001CE1C File Offset: 0x0001B01C
	public void Add(T item)
	{
		if (this.buffer == null || this.size == this.buffer.Length)
		{
			this.AllocateMore();
		}
		this.buffer[this.size++] = item;
	}

	// Token: 0x0600017D RID: 381 RVA: 0x0001CE6C File Offset: 0x0001B06C
	public void Insert(int index, T item)
	{
		if (this.buffer == null || this.size == this.buffer.Length)
		{
			this.AllocateMore();
		}
		if (index < this.size)
		{
			for (int i = this.size; i > index; i--)
			{
				this.buffer[i] = this.buffer[i - 1];
			}
			this.buffer[index] = item;
			this.size++;
		}
		else
		{
			this.Add(item);
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x0001CF04 File Offset: 0x0001B104
	public bool Contains(T item)
	{
		if (this.buffer == null)
		{
			return false;
		}
		for (int i = 0; i < this.size; i++)
		{
			if (this.buffer[i].Equals(item))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600017F RID: 383 RVA: 0x0001CF5C File Offset: 0x0001B15C
	public bool Remove(T item)
	{
		if (this.buffer != null)
		{
			EqualityComparer<T> @default = EqualityComparer<T>.Default;
			for (int i = 0; i < this.size; i++)
			{
				if (@default.Equals(this.buffer[i], item))
				{
					this.size--;
					this.buffer[i] = default(T);
					for (int j = i; j < this.size; j++)
					{
						this.buffer[j] = this.buffer[j + 1];
					}
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000180 RID: 384 RVA: 0x0001D000 File Offset: 0x0001B200
	public void RemoveAt(int index)
	{
		if (this.buffer != null && index < this.size)
		{
			this.size--;
			this.buffer[index] = default(T);
			for (int i = index; i < this.size; i++)
			{
				this.buffer[i] = this.buffer[i + 1];
			}
		}
	}

	// Token: 0x06000181 RID: 385 RVA: 0x0001D078 File Offset: 0x0001B278
	public T Pop()
	{
		if (this.buffer != null && this.size != 0)
		{
			T result = this.buffer[--this.size];
			this.buffer[this.size] = default(T);
			return result;
		}
		return default(T);
	}

	// Token: 0x06000182 RID: 386 RVA: 0x000032DA File Offset: 0x000014DA
	public T[] ToArray()
	{
		this.Trim();
		return this.buffer;
	}

	// Token: 0x06000183 RID: 387 RVA: 0x0001D0E0 File Offset: 0x0001B2E0
	public void Sort(Comparison<T> comparer)
	{
		bool flag = true;
		while (flag)
		{
			flag = false;
			for (int i = 1; i < this.size; i++)
			{
				if (comparer(this.buffer[i - 1], this.buffer[i]) > 0)
				{
					T t = this.buffer[i];
					this.buffer[i] = this.buffer[i - 1];
					this.buffer[i - 1] = t;
					flag = true;
				}
			}
		}
	}

	// Token: 0x040001AE RID: 430
	public T[] buffer;

	// Token: 0x040001AF RID: 431
	public int size;
}
