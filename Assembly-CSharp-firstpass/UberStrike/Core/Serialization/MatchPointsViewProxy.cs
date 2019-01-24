using System;
using System.IO;
using UberStrike.Core.Models.Views;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002AA RID: 682
	public static class MatchPointsViewProxy
	{
		// Token: 0x060010F7 RID: 4343 RVA: 0x000194C8 File Offset: 0x000176C8
		public static void Serialize(Stream stream, MatchPointsView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.LoserPointsBase);
				Int32Proxy.Serialize(memoryStream, instance.LoserPointsPerMinute);
				Int32Proxy.Serialize(memoryStream, instance.MaxTimeInGame);
				Int32Proxy.Serialize(memoryStream, instance.WinnerPointsBase);
				Int32Proxy.Serialize(memoryStream, instance.WinnerPointsPerMinute);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010F8 RID: 4344 RVA: 0x00019540 File Offset: 0x00017740
		public static MatchPointsView Deserialize(Stream bytes)
		{
			return new MatchPointsView
			{
				LoserPointsBase = Int32Proxy.Deserialize(bytes),
				LoserPointsPerMinute = Int32Proxy.Deserialize(bytes),
				MaxTimeInGame = Int32Proxy.Deserialize(bytes),
				WinnerPointsBase = Int32Proxy.Deserialize(bytes),
				WinnerPointsPerMinute = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
