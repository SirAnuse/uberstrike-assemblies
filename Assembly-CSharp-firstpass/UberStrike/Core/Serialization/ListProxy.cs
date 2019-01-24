using System;
using System.Collections.Generic;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200027A RID: 634
	public static class ListProxy<T>
	{
		// Token: 0x0600108F RID: 4239 RVA: 0x00015308 File Offset: 0x00013508
		public static void Serialize(Stream bytes, ICollection<T> instance, ListProxy<T>.Serializer<T> serialization)
		{
			UShortProxy.Serialize(bytes, (ushort)instance.Count);
			foreach (T instance2 in instance)
			{
				serialization(bytes, instance2);
			}
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x00015368 File Offset: 0x00013568
		public static List<T> Deserialize(Stream bytes, ListProxy<T>.Deserializer<T> serialization)
		{
			ushort num = UShortProxy.Deserialize(bytes);
			List<T> list = new List<T>((int)num);
			for (int i = 0; i < (int)num; i++)
			{
				list.Add(serialization(bytes));
			}
			return list;
		}

		// Token: 0x0200027B RID: 635
		// (Invoke) Token: 0x06001092 RID: 4242
		public delegate void Serializer<U>(Stream stream, U instance);

		// Token: 0x0200027C RID: 636
		// (Invoke) Token: 0x06001096 RID: 4246
		public delegate U Deserializer<U>(Stream stream);
	}
}
