using System;
using System.IO;
using UberStrike.Core.Models;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000291 RID: 657
	public static class GameRoomProxy
	{
		// Token: 0x060010C5 RID: 4293 RVA: 0x0001702C File Offset: 0x0001522C
		public static void Serialize(Stream stream, GameRoom instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.MapId);
				Int32Proxy.Serialize(memoryStream, instance.Number);
				if (instance.Server != null)
				{
					ConnectionAddressProxy.Serialize(memoryStream, instance.Server);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x000170AC File Offset: 0x000152AC
		public static GameRoom Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			GameRoom gameRoom = new GameRoom();
			gameRoom.MapId = Int32Proxy.Deserialize(bytes);
			gameRoom.Number = Int32Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				gameRoom.Server = ConnectionAddressProxy.Deserialize(bytes);
			}
			return gameRoom;
		}
	}
}
