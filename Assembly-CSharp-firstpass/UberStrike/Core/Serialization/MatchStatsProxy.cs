using System;
using System.IO;
using UberStrike.Core.Types;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200028A RID: 650
	public static class MatchStatsProxy
	{
		// Token: 0x060010B7 RID: 4279 RVA: 0x000164AC File Offset: 0x000146AC
		public static void Serialize(Stream stream, MatchStats instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<GameModeType>.Serialize(memoryStream, instance.GameModeId);
				Int32Proxy.Serialize(memoryStream, instance.MapId);
				if (instance.Players != null)
				{
					ListProxy<PlayerMatchStats>.Serialize(memoryStream, instance.Players, new ListProxy<PlayerMatchStats>.Serializer<PlayerMatchStats>(PlayerMatchStatsProxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.PlayersLimit);
				Int32Proxy.Serialize(memoryStream, instance.TimeLimit);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x00016550 File Offset: 0x00014750
		public static MatchStats Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			MatchStats matchStats = new MatchStats();
			matchStats.GameModeId = EnumProxy<GameModeType>.Deserialize(bytes);
			matchStats.MapId = Int32Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				matchStats.Players = ListProxy<PlayerMatchStats>.Deserialize(bytes, new ListProxy<PlayerMatchStats>.Deserializer<PlayerMatchStats>(PlayerMatchStatsProxy.Deserialize));
			}
			matchStats.PlayersLimit = Int32Proxy.Deserialize(bytes);
			matchStats.TimeLimit = Int32Proxy.Deserialize(bytes);
			return matchStats;
		}
	}
}
