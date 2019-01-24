using System;
using System.IO;
using Cmune.Core.Models.Views;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200029A RID: 666
	public static class AuthenticateApplicationViewProxy
	{
		// Token: 0x060010D7 RID: 4311 RVA: 0x00017EDC File Offset: 0x000160DC
		public static void Serialize(Stream stream, AuthenticateApplicationView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.CommServer != null)
				{
					PhotonViewProxy.Serialize(memoryStream, instance.CommServer);
				}
				else
				{
					num |= 1;
				}
				if (instance.EncryptionInitVector != null)
				{
					StringProxy.Serialize(memoryStream, instance.EncryptionInitVector);
				}
				else
				{
					num |= 2;
				}
				if (instance.EncryptionPassPhrase != null)
				{
					StringProxy.Serialize(memoryStream, instance.EncryptionPassPhrase);
				}
				else
				{
					num |= 4;
				}
				if (instance.GameServers != null)
				{
					ListProxy<PhotonView>.Serialize(memoryStream, instance.GameServers, new ListProxy<PhotonView>.Serializer<PhotonView>(PhotonViewProxy.Serialize));
				}
				else
				{
					num |= 8;
				}
				BooleanProxy.Serialize(memoryStream, instance.IsEnabled);
				BooleanProxy.Serialize(memoryStream, instance.WarnPlayer);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x00017FC8 File Offset: 0x000161C8
		public static AuthenticateApplicationView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			AuthenticateApplicationView authenticateApplicationView = new AuthenticateApplicationView();
			if ((num & 1) != 0)
			{
				authenticateApplicationView.CommServer = PhotonViewProxy.Deserialize(bytes);
			}
			if ((num & 2) != 0)
			{
				authenticateApplicationView.EncryptionInitVector = StringProxy.Deserialize(bytes);
			}
			if ((num & 4) != 0)
			{
				authenticateApplicationView.EncryptionPassPhrase = StringProxy.Deserialize(bytes);
			}
			if ((num & 8) != 0)
			{
				authenticateApplicationView.GameServers = ListProxy<PhotonView>.Deserialize(bytes, new ListProxy<PhotonView>.Deserializer<PhotonView>(PhotonViewProxy.Deserialize));
			}
			authenticateApplicationView.IsEnabled = BooleanProxy.Deserialize(bytes);
			authenticateApplicationView.WarnPlayer = BooleanProxy.Deserialize(bytes);
			return authenticateApplicationView;
		}
	}
}
