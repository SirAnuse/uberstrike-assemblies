﻿using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000292 RID: 658
	public static class CommActorInfoProxy
	{
		// Token: 0x060010C7 RID: 4295 RVA: 0x000170F4 File Offset: 0x000152F4
		public static void Serialize(Stream stream, CommActorInfo instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<MemberAccessLevel>.Serialize(memoryStream, instance.AccessLevel);
				EnumProxy<ChannelType>.Serialize(memoryStream, instance.Channel);
				if (instance.ClanTag != null)
				{
					StringProxy.Serialize(memoryStream, instance.ClanTag);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				if (instance.CurrentRoom != null)
				{
					GameRoomProxy.Serialize(memoryStream, instance.CurrentRoom);
				}
				else
				{
					num |= 2;
				}
				ByteProxy.Serialize(memoryStream, instance.ModerationFlag);
				if (instance.ModInformation != null)
				{
					StringProxy.Serialize(memoryStream, instance.ModInformation);
				}
				else
				{
					num |= 4;
				}
				if (instance.PlayerName != null)
				{
					StringProxy.Serialize(memoryStream, instance.PlayerName);
				}
				else
				{
					num |= 8;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x000171EC File Offset: 0x000153EC
		public static CommActorInfo Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			CommActorInfo commActorInfo = new CommActorInfo();
			commActorInfo.AccessLevel = EnumProxy<MemberAccessLevel>.Deserialize(bytes);
			commActorInfo.Channel = EnumProxy<ChannelType>.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				commActorInfo.ClanTag = StringProxy.Deserialize(bytes);
			}
			commActorInfo.Cmid = Int32Proxy.Deserialize(bytes);
			if ((num & 2) != 0)
			{
				commActorInfo.CurrentRoom = GameRoomProxy.Deserialize(bytes);
			}
			commActorInfo.ModerationFlag = ByteProxy.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				commActorInfo.ModInformation = StringProxy.Deserialize(bytes);
			}
			if ((num & 8) != 0)
			{
				commActorInfo.PlayerName = StringProxy.Deserialize(bytes);
			}
			return commActorInfo;
		}
	}
}
