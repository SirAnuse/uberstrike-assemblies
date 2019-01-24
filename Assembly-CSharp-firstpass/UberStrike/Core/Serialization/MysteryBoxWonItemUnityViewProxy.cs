using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000269 RID: 617
	public static class MysteryBoxWonItemUnityViewProxy
	{
		// Token: 0x06001069 RID: 4201 RVA: 0x00014880 File Offset: 0x00012A80
		public static void Serialize(Stream stream, MysteryBoxWonItemUnityView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.CreditWon);
				Int32Proxy.Serialize(memoryStream, instance.ItemIdWon);
				Int32Proxy.Serialize(memoryStream, instance.PointWon);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x000148E0 File Offset: 0x00012AE0
		public static MysteryBoxWonItemUnityView Deserialize(Stream bytes)
		{
			return new MysteryBoxWonItemUnityView
			{
				CreditWon = Int32Proxy.Deserialize(bytes),
				ItemIdWon = Int32Proxy.Deserialize(bytes),
				PointWon = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
