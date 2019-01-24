﻿using System;
using System.IO;
using Cmune.Core.Models.Views;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200026C RID: 620
	public static class PhotonViewProxy
	{
		// Token: 0x0600106F RID: 4207 RVA: 0x00014ADC File Offset: 0x00012CDC
		public static void Serialize(Stream stream, PhotonView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.IP != null)
				{
					StringProxy.Serialize(memoryStream, instance.IP);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.MinLatency);
				if (instance.Name != null)
				{
					StringProxy.Serialize(memoryStream, instance.Name);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(memoryStream, instance.PhotonId);
				Int32Proxy.Serialize(memoryStream, instance.Port);
				EnumProxy<RegionType>.Serialize(memoryStream, instance.Region);
				EnumProxy<PhotonUsageType>.Serialize(memoryStream, instance.UsageType);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x00014BA0 File Offset: 0x00012DA0
		public static PhotonView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			PhotonView photonView = new PhotonView();
			if ((num & 1) != 0)
			{
				photonView.IP = StringProxy.Deserialize(bytes);
			}
			photonView.MinLatency = Int32Proxy.Deserialize(bytes);
			if ((num & 2) != 0)
			{
				photonView.Name = StringProxy.Deserialize(bytes);
			}
			photonView.PhotonId = Int32Proxy.Deserialize(bytes);
			photonView.Port = Int32Proxy.Deserialize(bytes);
			photonView.Region = EnumProxy<RegionType>.Deserialize(bytes);
			photonView.UsageType = EnumProxy<PhotonUsageType>.Deserialize(bytes);
			return photonView;
		}
	}
}
