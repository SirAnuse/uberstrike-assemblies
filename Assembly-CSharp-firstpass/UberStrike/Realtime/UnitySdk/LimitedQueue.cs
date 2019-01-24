using System;
using System.Collections;
using System.Collections.Generic;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x02000344 RID: 836
	public class LimitedQueue<T> : IEnumerable, IEnumerable<T>
	{
		// Token: 0x060013AF RID: 5039 RVA: 0x0000C199 File Offset: 0x0000A399
		public LimitedQueue(int capacity)
		{
			this._capacity = capacity;
			this._list = new List<T>(capacity);
		}

		// Token: 0x060013B0 RID: 5040 RVA: 0x0000C1B4 File Offset: 0x0000A3B4
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this._list.GetEnumerator();
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x060013B1 RID: 5041 RVA: 0x0000C1C6 File Offset: 0x0000A3C6
		// (set) Token: 0x060013B2 RID: 5042 RVA: 0x0000C1CE File Offset: 0x0000A3CE
		public T LastItem { get; private set; }

		// Token: 0x170003C2 RID: 962
		public T this[int index]
		{
			get
			{
				return this._list[index];
			}
			set
			{
				this._list[index] = value;
			}
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x0000C1F4 File Offset: 0x0000A3F4
		public bool Contains(T item)
		{
			return this._list.Contains(item);
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x0000C202 File Offset: 0x0000A402
		public bool Remove(T item)
		{
			return this._list.Remove(item);
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x00023014 File Offset: 0x00021214
		public bool EnqueueUnique(T item)
		{
			int num = this._list.RemoveAll((T p) => p.Equals(item));
			this.Enqueue(item);
			return num == 0;
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x00023058 File Offset: 0x00021258
		public void Enqueue(T item)
		{
			if (this._list.Count + 1 > this._capacity)
			{
				this.LastItem = this.Dequeue();
			}
			else
			{
				this.LastItem = default(T);
			}
			this._list.Add(item);
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x000230AC File Offset: 0x000212AC
		public T Dequeue()
		{
			T result = default(T);
			if (this._list.Count > 0)
			{
				result = this._list[0];
				this._list.RemoveAt(0);
			}
			return result;
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x000230F0 File Offset: 0x000212F0
		public T Peek()
		{
			if (this._list.Count > 0)
			{
				return this._list[0];
			}
			return default(T);
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x00023124 File Offset: 0x00021324
		public T Tail()
		{
			if (this._list.Count > 0)
			{
				return this._list[this._list.Count - 1];
			}
			return default(T);
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x060013BC RID: 5052 RVA: 0x0000C210 File Offset: 0x0000A410
		public int Count
		{
			get
			{
				return this._list.Count;
			}
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x0000C21D File Offset: 0x0000A41D
		public void Clear()
		{
			this._list.Clear();
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x0000C1B4 File Offset: 0x0000A3B4
		public IEnumerator<T> GetEnumerator()
		{
			return this._list.GetEnumerator();
		}

		// Token: 0x04000E16 RID: 3606
		private List<T> _list;

		// Token: 0x04000E17 RID: 3607
		private int _capacity;
	}
}
