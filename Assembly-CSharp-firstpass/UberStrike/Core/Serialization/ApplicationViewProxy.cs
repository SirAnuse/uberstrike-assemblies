using System;
using System.IO;
using Cmune.Core.Models.Views;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200024D RID: 589
	public static class ApplicationViewProxy
	{
		// Token: 0x06001031 RID: 4145 RVA: 0x00011EBC File Offset: 0x000100BC
		public static void Serialize(Stream stream, ApplicationView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.ApplicationVersionId);
				EnumProxy<BuildType>.Serialize(memoryStream, instance.Build);
				EnumProxy<ChannelType>.Serialize(memoryStream, instance.Channel);
				if (instance.ExpirationDate != null)
				{
					Stream bytes = memoryStream;
					DateTime? expirationDate = instance.ExpirationDate;
					DateTimeProxy.Serialize(bytes, (expirationDate == null) ? default(DateTime) : expirationDate.Value);
				}
				else
				{
					num |= 1;
				}
				if (instance.FileName != null)
				{
					StringProxy.Serialize(memoryStream, instance.FileName);
				}
				else
				{
					num |= 2;
				}
				BooleanProxy.Serialize(memoryStream, instance.IsCurrent);
				Int32Proxy.Serialize(memoryStream, instance.PhotonGroupId);
				if (instance.PhotonGroupName != null)
				{
					StringProxy.Serialize(memoryStream, instance.PhotonGroupName);
				}
				else
				{
					num |= 4;
				}
				DateTimeProxy.Serialize(memoryStream, instance.ReleaseDate);
				Int32Proxy.Serialize(memoryStream, instance.RemainingTime);
				if (instance.Servers != null)
				{
					ListProxy<PhotonView>.Serialize(memoryStream, instance.Servers, new ListProxy<PhotonView>.Serializer<PhotonView>(PhotonViewProxy.Serialize));
				}
				else
				{
					num |= 8;
				}
				if (instance.SupportUrl != null)
				{
					StringProxy.Serialize(memoryStream, instance.SupportUrl);
				}
				else
				{
					num |= 16;
				}
				if (instance.Version != null)
				{
					StringProxy.Serialize(memoryStream, instance.Version);
				}
				else
				{
					num |= 32;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0001205C File Offset: 0x0001025C
		public static ApplicationView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ApplicationView applicationView = new ApplicationView();
			applicationView.ApplicationVersionId = Int32Proxy.Deserialize(bytes);
			applicationView.Build = EnumProxy<BuildType>.Deserialize(bytes);
			applicationView.Channel = EnumProxy<ChannelType>.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				applicationView.ExpirationDate = new DateTime?(DateTimeProxy.Deserialize(bytes));
			}
			if ((num & 2) != 0)
			{
				applicationView.FileName = StringProxy.Deserialize(bytes);
			}
			applicationView.IsCurrent = BooleanProxy.Deserialize(bytes);
			applicationView.PhotonGroupId = Int32Proxy.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				applicationView.PhotonGroupName = StringProxy.Deserialize(bytes);
			}
			applicationView.ReleaseDate = DateTimeProxy.Deserialize(bytes);
			applicationView.RemainingTime = Int32Proxy.Deserialize(bytes);
			if ((num & 8) != 0)
			{
				applicationView.Servers = ListProxy<PhotonView>.Deserialize(bytes, new ListProxy<PhotonView>.Deserializer<PhotonView>(PhotonViewProxy.Deserialize));
			}
			if ((num & 16) != 0)
			{
				applicationView.SupportUrl = StringProxy.Deserialize(bytes);
			}
			if ((num & 32) != 0)
			{
				applicationView.Version = StringProxy.Deserialize(bytes);
			}
			return applicationView;
		}
	}
}
