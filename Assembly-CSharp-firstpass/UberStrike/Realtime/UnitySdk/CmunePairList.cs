using System;
using System.Collections.Generic;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x02000336 RID: 822
	public class CmunePairList<T1, T2> : List<KeyValuePair<T1, T2>>
	{
		// Token: 0x0600134F RID: 4943 RVA: 0x0000BE2F File Offset: 0x0000A02F
		public CmunePairList()
		{
		}

		// Token: 0x06001350 RID: 4944 RVA: 0x0000BE37 File Offset: 0x0000A037
		public CmunePairList(int capacity) : base(capacity)
		{
		}

		// Token: 0x06001351 RID: 4945 RVA: 0x0000BE40 File Offset: 0x0000A040
		public CmunePairList(IEnumerable<KeyValuePair<T1, T2>> collection) : base(collection)
		{
		}

		// Token: 0x06001352 RID: 4946 RVA: 0x00022288 File Offset: 0x00020488
		public CmunePairList(IEnumerable<T1> collection1, IEnumerable<T2> collection2)
		{
			IEnumerator<T1> enumerator = collection1.GetEnumerator();
			IEnumerator<T2> enumerator2 = collection2.GetEnumerator();
			while (enumerator.MoveNext() && enumerator2.MoveNext())
			{
				this.Add(new KeyValuePair<T1, T2>(enumerator.Current, enumerator2.Current));
			}
		}

		// Token: 0x06001353 RID: 4947 RVA: 0x000222DC File Offset: 0x000204DC
		public ICollection<KeyValuePair<T1, T2>> GetPairsWithKey(T1 key)
		{
			return base.FindAll(delegate(KeyValuePair<T1, T2> p)
			{
				T1 key2 = p.Key;
				return key2.Equals(key);
			});
		}

		// Token: 0x06001354 RID: 4948 RVA: 0x00022308 File Offset: 0x00020508
		public ICollection<KeyValuePair<T1, T2>> GetPairsWithValue(T2 value)
		{
			return base.FindAll(delegate(KeyValuePair<T1, T2> p)
			{
				T2 value2 = p.Value;
				return value2.Equals(value);
			});
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x06001355 RID: 4949 RVA: 0x00022334 File Offset: 0x00020534
		public ICollection<T1> Keys
		{
			get
			{
				List<T1> l = new List<T1>(this.Count);
				base.ForEach(delegate(KeyValuePair<T1, T2> p)
				{
					l.Add(p.Key);
				});
				return l;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06001356 RID: 4950 RVA: 0x00022370 File Offset: 0x00020570
		public ICollection<T2> Values
		{
			get
			{
				List<T2> l = new List<T2>(this.Count);
				base.ForEach(delegate(KeyValuePair<T1, T2> p)
				{
					l.Add(p.Value);
				});
				return l;
			}
		}

		// Token: 0x06001357 RID: 4951 RVA: 0x0000BE49 File Offset: 0x0000A049
		public void Add(T1 first, T2 second)
		{
			this.Add(new KeyValuePair<T1, T2>(first, second));
		}

		// Token: 0x06001358 RID: 4952 RVA: 0x0000BE58 File Offset: 0x0000A058
		public void Clamp(int max)
		{
			if (this.Count > max)
			{
				base.RemoveRange(max, this.Count - max);
			}
		}
	}
}
