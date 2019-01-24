using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200028C RID: 652
	public static class ServerConnectionViewProxy
	{
		// Token: 0x060010BB RID: 4283 RVA: 0x00016790 File Offset: 0x00014990
		public static void Serialize(Stream stream, ServerConnectionView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<MemberAccessLevel>.Serialize(memoryStream, instance.AccessLevel);
				if (instance.ApiVersion != null)
				{
					StringProxy.Serialize(memoryStream, instance.ApiVersion);
				}
				else
				{
					num |= 1;
				}
				EnumProxy<ChannelType>.Serialize(memoryStream, instance.Channel);
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x0001681C File Offset: 0x00014A1C
		public static ServerConnectionView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ServerConnectionView serverConnectionView = new ServerConnectionView();
			serverConnectionView.AccessLevel = EnumProxy<MemberAccessLevel>.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				serverConnectionView.ApiVersion = StringProxy.Deserialize(bytes);
			}
			serverConnectionView.Channel = EnumProxy<ChannelType>.Deserialize(bytes);
			serverConnectionView.Cmid = Int32Proxy.Deserialize(bytes);
			return serverConnectionView;
		}
	}
}
