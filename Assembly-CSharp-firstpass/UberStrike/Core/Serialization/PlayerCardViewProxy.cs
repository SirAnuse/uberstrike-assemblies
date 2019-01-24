﻿using System;
using System.IO;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002A0 RID: 672
	public static class PlayerCardViewProxy
	{
		// Token: 0x060010E3 RID: 4323 RVA: 0x000187E4 File Offset: 0x000169E4
		public static void Serialize(Stream stream, PlayerCardView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				Int64Proxy.Serialize(memoryStream, instance.Hits);
				if (instance.Name != null)
				{
					StringProxy.Serialize(memoryStream, instance.Name);
				}
				else
				{
					num |= 1;
				}
				if (instance.Precision != null)
				{
					StringProxy.Serialize(memoryStream, instance.Precision);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(memoryStream, instance.Ranking);
				Int64Proxy.Serialize(memoryStream, instance.Shots);
				Int32Proxy.Serialize(memoryStream, instance.Splats);
				Int32Proxy.Serialize(memoryStream, instance.Splatted);
				if (instance.TagName != null)
				{
					StringProxy.Serialize(memoryStream, instance.TagName);
				}
				else
				{
					num |= 4;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x000188D4 File Offset: 0x00016AD4
		public static PlayerCardView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			PlayerCardView playerCardView = new PlayerCardView();
			playerCardView.Cmid = Int32Proxy.Deserialize(bytes);
			playerCardView.Hits = Int64Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				playerCardView.Name = StringProxy.Deserialize(bytes);
			}
			if ((num & 2) != 0)
			{
				playerCardView.Precision = StringProxy.Deserialize(bytes);
			}
			playerCardView.Ranking = Int32Proxy.Deserialize(bytes);
			playerCardView.Shots = Int64Proxy.Deserialize(bytes);
			playerCardView.Splats = Int32Proxy.Deserialize(bytes);
			playerCardView.Splatted = Int32Proxy.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				playerCardView.TagName = StringProxy.Deserialize(bytes);
			}
			return playerCardView;
		}
	}
}