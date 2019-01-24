using System;
using System.Collections.Generic;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000273 RID: 627
	public static class DictionaryProxy<S, T>
	{
		// Token: 0x0600107D RID: 4221 RVA: 0x0001510C File Offset: 0x0001330C
		public static void Serialize(Stream bytes, Dictionary<S, T> instance, DictionaryProxy<S, T>.Serializer<S> keySerialization, DictionaryProxy<S, T>.Serializer<T> valueSerialization)
		{
			Int32Proxy.Serialize(bytes, instance.Count);
			foreach (KeyValuePair<S, T> keyValuePair in instance)
			{
				keySerialization(bytes, keyValuePair.Key);
				valueSerialization(bytes, keyValuePair.Value);
			}
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x00015184 File Offset: 0x00013384
		public static Dictionary<S, T> Deserialize(Stream bytes, DictionaryProxy<S, T>.Deserializer<S> keySerialization, DictionaryProxy<S, T>.Deserializer<T> valueSerialization)
		{
			int num = Int32Proxy.Deserialize(bytes);
			Dictionary<S, T> dictionary = new Dictionary<S, T>(num);
			for (int i = 0; i < num; i++)
			{
				dictionary.Add(keySerialization(bytes), valueSerialization(bytes));
			}
			return dictionary;
		}

		// Token: 0x02000274 RID: 628
		// (Invoke) Token: 0x06001080 RID: 4224
		public delegate void Serializer<U>(Stream stream, U instance);

		// Token: 0x02000275 RID: 629
		// (Invoke) Token: 0x06001084 RID: 4228
		public delegate U Deserializer<U>(Stream stream);
	}
}
