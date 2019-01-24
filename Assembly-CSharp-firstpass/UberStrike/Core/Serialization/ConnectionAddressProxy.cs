using System;
using System.IO;
using UberStrike.Core.Models;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000293 RID: 659
	public static class ConnectionAddressProxy
	{
		// Token: 0x060010C9 RID: 4297 RVA: 0x00017288 File Offset: 0x00015488
		public static void Serialize(Stream stream, ConnectionAddress instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Ipv4);
				UInt16Proxy.Serialize(memoryStream, instance.Port);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x000172DC File Offset: 0x000154DC
		public static ConnectionAddress Deserialize(Stream bytes)
		{
			return new ConnectionAddress
			{
				Ipv4 = Int32Proxy.Deserialize(bytes),
				Port = UInt16Proxy.Deserialize(bytes)
			};
		}
	}
}
