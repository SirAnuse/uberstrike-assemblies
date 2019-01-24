using System;
using System.IO;
using Cmune.Core.Models;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200026B RID: 619
	public static class PhotonServerLoadProxy
	{
		// Token: 0x0600106D RID: 4205 RVA: 0x00014A2C File Offset: 0x00012C2C
		public static void Serialize(Stream stream, PhotonServerLoad instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				SingleProxy.Serialize(memoryStream, instance.MaxPlayerCount);
				Int32Proxy.Serialize(memoryStream, instance.PeersConnected);
				Int32Proxy.Serialize(memoryStream, instance.PlayersConnected);
				Int32Proxy.Serialize(memoryStream, instance.RoomsCreated);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x00014A98 File Offset: 0x00012C98
		public static PhotonServerLoad Deserialize(Stream bytes)
		{
			return new PhotonServerLoad
			{
				MaxPlayerCount = SingleProxy.Deserialize(bytes),
				PeersConnected = Int32Proxy.Deserialize(bytes),
				PlayersConnected = Int32Proxy.Deserialize(bytes),
				RoomsCreated = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
