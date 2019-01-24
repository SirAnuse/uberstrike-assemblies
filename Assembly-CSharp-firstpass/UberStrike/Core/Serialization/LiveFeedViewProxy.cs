using System;
using System.IO;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200029D RID: 669
	public static class LiveFeedViewProxy
	{
		// Token: 0x060010DD RID: 4317 RVA: 0x00018200 File Offset: 0x00016400
		public static void Serialize(Stream stream, LiveFeedView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				DateTimeProxy.Serialize(memoryStream, instance.Date);
				if (instance.Description != null)
				{
					StringProxy.Serialize(memoryStream, instance.Description);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.LivedFeedId);
				Int32Proxy.Serialize(memoryStream, instance.Priority);
				if (instance.Url != null)
				{
					StringProxy.Serialize(memoryStream, instance.Url);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x000182AC File Offset: 0x000164AC
		public static LiveFeedView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			LiveFeedView liveFeedView = new LiveFeedView();
			liveFeedView.Date = DateTimeProxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				liveFeedView.Description = StringProxy.Deserialize(bytes);
			}
			liveFeedView.LivedFeedId = Int32Proxy.Deserialize(bytes);
			liveFeedView.Priority = Int32Proxy.Deserialize(bytes);
			if ((num & 2) != 0)
			{
				liveFeedView.Url = StringProxy.Deserialize(bytes);
			}
			return liveFeedView;
		}
	}
}
