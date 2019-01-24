using System;
using System.IO;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200029B RID: 667
	public static class DailyPointsViewProxy
	{
		// Token: 0x060010D9 RID: 4313 RVA: 0x00018058 File Offset: 0x00016258
		public static void Serialize(Stream stream, DailyPointsView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Current);
				Int32Proxy.Serialize(memoryStream, instance.PointsMax);
				Int32Proxy.Serialize(memoryStream, instance.PointsTomorrow);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x000180B8 File Offset: 0x000162B8
		public static DailyPointsView Deserialize(Stream bytes)
		{
			return new DailyPointsView
			{
				Current = Int32Proxy.Deserialize(bytes),
				PointsMax = Int32Proxy.Deserialize(bytes),
				PointsTomorrow = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
