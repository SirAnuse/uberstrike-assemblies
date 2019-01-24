using System;
using System.IO;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002A1 RID: 673
	public static class PlayerLevelCapViewProxy
	{
		// Token: 0x060010E5 RID: 4325 RVA: 0x00018974 File Offset: 0x00016B74
		public static void Serialize(Stream stream, PlayerLevelCapView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Level);
				Int32Proxy.Serialize(memoryStream, instance.PlayerLevelCapId);
				Int32Proxy.Serialize(memoryStream, instance.XPRequired);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x000189D4 File Offset: 0x00016BD4
		public static PlayerLevelCapView Deserialize(Stream bytes)
		{
			return new PlayerLevelCapView
			{
				Level = Int32Proxy.Deserialize(bytes),
				PlayerLevelCapId = Int32Proxy.Deserialize(bytes),
				XPRequired = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
