using System;
using System.IO;
using UberStrike.Core.Models.Views;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002A9 RID: 681
	public static class MapSettingsProxy
	{
		// Token: 0x060010F5 RID: 4341 RVA: 0x000193A0 File Offset: 0x000175A0
		public static void Serialize(Stream stream, MapSettings instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.KillsCurrent);
				Int32Proxy.Serialize(memoryStream, instance.KillsMax);
				Int32Proxy.Serialize(memoryStream, instance.KillsMin);
				Int32Proxy.Serialize(memoryStream, instance.PlayersCurrent);
				Int32Proxy.Serialize(memoryStream, instance.PlayersMax);
				Int32Proxy.Serialize(memoryStream, instance.PlayersMin);
				Int32Proxy.Serialize(memoryStream, instance.TimeCurrent);
				Int32Proxy.Serialize(memoryStream, instance.TimeMax);
				Int32Proxy.Serialize(memoryStream, instance.TimeMin);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010F6 RID: 4342 RVA: 0x00019448 File Offset: 0x00017648
		public static MapSettings Deserialize(Stream bytes)
		{
			return new MapSettings
			{
				KillsCurrent = Int32Proxy.Deserialize(bytes),
				KillsMax = Int32Proxy.Deserialize(bytes),
				KillsMin = Int32Proxy.Deserialize(bytes),
				PlayersCurrent = Int32Proxy.Deserialize(bytes),
				PlayersMax = Int32Proxy.Deserialize(bytes),
				PlayersMin = Int32Proxy.Deserialize(bytes),
				TimeCurrent = Int32Proxy.Deserialize(bytes),
				TimeMax = Int32Proxy.Deserialize(bytes),
				TimeMin = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
