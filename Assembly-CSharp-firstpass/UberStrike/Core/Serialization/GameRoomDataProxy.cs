using System;
using System.IO;
using UberStrike.Core.Models;
using UberStrike.Core.Types;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000294 RID: 660
	public static class GameRoomDataProxy
	{
		// Token: 0x060010CB RID: 4299 RVA: 0x00017308 File Offset: 0x00015508
		public static void Serialize(Stream stream, GameRoomData instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.ConnectedPlayers);
				Int32Proxy.Serialize(memoryStream, instance.GameFlags);
				EnumProxy<GameModeType>.Serialize(memoryStream, instance.GameMode);
				if (instance.Guid != null)
				{
					StringProxy.Serialize(memoryStream, instance.Guid);
				}
				else
				{
					num |= 1;
				}
				BooleanProxy.Serialize(memoryStream, instance.IsPasswordProtected);
				BooleanProxy.Serialize(memoryStream, instance.IsPermanentGame);
				Int32Proxy.Serialize(memoryStream, instance.KillLimit);
				ByteProxy.Serialize(memoryStream, instance.LevelMax);
				ByteProxy.Serialize(memoryStream, instance.LevelMin);
				Int32Proxy.Serialize(memoryStream, instance.MapID);
				if (instance.Name != null)
				{
					StringProxy.Serialize(memoryStream, instance.Name);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(memoryStream, instance.Number);
				Int32Proxy.Serialize(memoryStream, instance.PlayerLimit);
				if (instance.Server != null)
				{
					ConnectionAddressProxy.Serialize(memoryStream, instance.Server);
				}
				else
				{
					num |= 4;
				}
				Int32Proxy.Serialize(memoryStream, instance.TimeLimit);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0001744C File Offset: 0x0001564C
		public static GameRoomData Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			GameRoomData gameRoomData = new GameRoomData();
			gameRoomData.ConnectedPlayers = Int32Proxy.Deserialize(bytes);
			gameRoomData.GameFlags = Int32Proxy.Deserialize(bytes);
			gameRoomData.GameMode = EnumProxy<GameModeType>.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				gameRoomData.Guid = StringProxy.Deserialize(bytes);
			}
			gameRoomData.IsPasswordProtected = BooleanProxy.Deserialize(bytes);
			gameRoomData.IsPermanentGame = BooleanProxy.Deserialize(bytes);
			gameRoomData.KillLimit = Int32Proxy.Deserialize(bytes);
			gameRoomData.LevelMax = ByteProxy.Deserialize(bytes);
			gameRoomData.LevelMin = ByteProxy.Deserialize(bytes);
			gameRoomData.MapID = Int32Proxy.Deserialize(bytes);
			if ((num & 2) != 0)
			{
				gameRoomData.Name = StringProxy.Deserialize(bytes);
			}
			gameRoomData.Number = Int32Proxy.Deserialize(bytes);
			gameRoomData.PlayerLimit = Int32Proxy.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				gameRoomData.Server = ConnectionAddressProxy.Deserialize(bytes);
			}
			gameRoomData.TimeLimit = Int32Proxy.Deserialize(bytes);
			return gameRoomData;
		}
	}
}
