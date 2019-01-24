using System;
using System.Collections.Generic;

// Token: 0x020003CA RID: 970
public static class EnumerationExtensions
{
	// Token: 0x06001C6F RID: 7279 RVA: 0x00090014 File Offset: 0x0008E214
	public static T[] ValueArray<S, T>(this Dictionary<S, T> dict)
	{
		T[] array = new T[dict.Count];
		dict.Values.CopyTo(array, 0);
		return array;
	}

	// Token: 0x06001C70 RID: 7280 RVA: 0x0009003C File Offset: 0x0008E23C
	public static S[] KeyArray<S, T>(this Dictionary<S, T> dict)
	{
		S[] array = new S[dict.Count];
		dict.Keys.CopyTo(array, 0);
		return array;
	}

	// Token: 0x06001C71 RID: 7281 RVA: 0x00090064 File Offset: 0x0008E264
	public static KeyValuePair<S, T> First<S, T>(this Dictionary<S, T> dict)
	{
		Dictionary<S, T>.Enumerator enumerator = dict.GetEnumerator();
		enumerator.MoveNext();
		return enumerator.Current;
	}

	// Token: 0x06001C72 RID: 7282 RVA: 0x00090088 File Offset: 0x0008E288
	public static T Reduce<T, TList>(this IEnumerable<TList> list, Func<TList, T, T> func, T initialValue)
	{
		T t = initialValue;
		foreach (TList arg in list)
		{
			t = func(arg, t);
		}
		return t;
	}

	// Token: 0x06001C73 RID: 7283 RVA: 0x000900E0 File Offset: 0x0008E2E0
	public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key, TValue defaultValue)
	{
		TValue result = defaultValue;
		dic.TryGetValue(key, out result);
		return result;
	}
}
