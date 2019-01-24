using System;
using System.IO;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000272 RID: 626
	public static class DecimalProxy
	{
		// Token: 0x0600107B RID: 4219 RVA: 0x00015094 File Offset: 0x00013294
		public static void Serialize(Stream bytes, decimal instance)
		{
			int[] bits = decimal.GetBits(instance);
			Int32Proxy.Serialize(bytes, bits[0]);
			Int32Proxy.Serialize(bytes, bits[1]);
			Int32Proxy.Serialize(bytes, bits[2]);
			Int32Proxy.Serialize(bytes, bits[3]);
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x000150CC File Offset: 0x000132CC
		public static decimal Deserialize(Stream bytes)
		{
			int[] bits = new int[]
			{
				Int32Proxy.Deserialize(bytes),
				Int32Proxy.Deserialize(bytes),
				Int32Proxy.Deserialize(bytes),
				Int32Proxy.Deserialize(bytes)
			};
			return new decimal(bits);
		}
	}
}
