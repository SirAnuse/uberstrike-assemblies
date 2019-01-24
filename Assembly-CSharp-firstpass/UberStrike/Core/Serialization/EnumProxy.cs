using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000276 RID: 630
	public static class EnumProxy<T>
	{
		// Token: 0x06001087 RID: 4231 RVA: 0x000151C8 File Offset: 0x000133C8
		public static void Serialize(Stream bytes, T instance)
		{
			byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt32(instance));
			bytes.Write(bytes2, 0, bytes2.Length);
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x000151F4 File Offset: 0x000133F4
		public static T Deserialize(Stream bytes)
		{
			byte[] array = new byte[4];
			bytes.Read(array, 0, 4);
			return (T)((object)Enum.ToObject(typeof(T), BitConverter.ToInt32(array, 0)));
		}
	}
}
