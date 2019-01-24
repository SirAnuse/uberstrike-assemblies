using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000248 RID: 584
	public static class ArrayProxy<T>
	{
		// Token: 0x06001023 RID: 4131 RVA: 0x00011DF8 File Offset: 0x0000FFF8
		public static void Serialize(Stream bytes, T[] instance, Action<Stream, T> serialization)
		{
			UShortProxy.Serialize(bytes, (ushort)instance.Length);
			foreach (T arg in instance)
			{
				serialization(bytes, arg);
			}
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x00011E38 File Offset: 0x00010038
		public static T[] Deserialize(Stream bytes, ArrayProxy<T>.Deserializer<T> serialization)
		{
			ushort num = UShortProxy.Deserialize(bytes);
			T[] array = new T[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				array[i] = serialization(bytes);
			}
			return array;
		}

		// Token: 0x02000249 RID: 585
		// (Invoke) Token: 0x06001026 RID: 4134
		public delegate void Serializer<U>(Stream stream, U instance);

		// Token: 0x0200024A RID: 586
		// (Invoke) Token: 0x0600102A RID: 4138
		public delegate U Deserializer<U>(Stream stream);
	}
}
