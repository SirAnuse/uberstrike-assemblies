﻿using System;
using System.IO;
using Cmune.Core.Models.Views;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000264 RID: 612
	public static class MemberSessionDataViewProxy
	{
		// Token: 0x0600105F RID: 4191 RVA: 0x00014138 File Offset: 0x00012338
		public static void Serialize(Stream stream, MemberSessionDataView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<MemberAccessLevel>.Serialize(memoryStream, instance.AccessLevel);
				if (instance.AuthToken != null)
				{
					StringProxy.Serialize(memoryStream, instance.AuthToken);
				}
				else
				{
					num |= 1;
				}
				EnumProxy<ChannelType>.Serialize(memoryStream, instance.Channel);
				if (instance.ClanTag != null)
				{
					StringProxy.Serialize(memoryStream, instance.ClanTag);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				BooleanProxy.Serialize(memoryStream, instance.IsBanned);
				Int32Proxy.Serialize(memoryStream, instance.Level);
				DateTimeProxy.Serialize(memoryStream, instance.LoginDate);
				if (instance.Name != null)
				{
					StringProxy.Serialize(memoryStream, instance.Name);
				}
				else
				{
					num |= 4;
				}
				Int32Proxy.Serialize(memoryStream, instance.XP);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x00014234 File Offset: 0x00012434
		public static MemberSessionDataView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			MemberSessionDataView memberSessionDataView = new MemberSessionDataView();
			memberSessionDataView.AccessLevel = EnumProxy<MemberAccessLevel>.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				memberSessionDataView.AuthToken = StringProxy.Deserialize(bytes);
			}
			memberSessionDataView.Channel = EnumProxy<ChannelType>.Deserialize(bytes);
			if ((num & 2) != 0)
			{
				memberSessionDataView.ClanTag = StringProxy.Deserialize(bytes);
			}
			memberSessionDataView.Cmid = Int32Proxy.Deserialize(bytes);
			memberSessionDataView.IsBanned = BooleanProxy.Deserialize(bytes);
			memberSessionDataView.Level = Int32Proxy.Deserialize(bytes);
			memberSessionDataView.LoginDate = DateTimeProxy.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				memberSessionDataView.Name = StringProxy.Deserialize(bytes);
			}
			memberSessionDataView.XP = Int32Proxy.Deserialize(bytes);
			return memberSessionDataView;
		}
	}
}
