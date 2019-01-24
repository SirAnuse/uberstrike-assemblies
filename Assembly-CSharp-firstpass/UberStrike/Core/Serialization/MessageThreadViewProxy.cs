using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000267 RID: 615
	public static class MessageThreadViewProxy
	{
		// Token: 0x06001065 RID: 4197 RVA: 0x000144C0 File Offset: 0x000126C0
		public static void Serialize(Stream stream, MessageThreadView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BooleanProxy.Serialize(memoryStream, instance.HasNewMessages);
				if (instance.LastMessagePreview != null)
				{
					StringProxy.Serialize(memoryStream, instance.LastMessagePreview);
				}
				else
				{
					num |= 1;
				}
				DateTimeProxy.Serialize(memoryStream, instance.LastUpdate);
				Int32Proxy.Serialize(memoryStream, instance.MessageCount);
				Int32Proxy.Serialize(memoryStream, instance.ThreadId);
				if (instance.ThreadName != null)
				{
					StringProxy.Serialize(memoryStream, instance.ThreadName);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x00014578 File Offset: 0x00012778
		public static MessageThreadView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			MessageThreadView messageThreadView = new MessageThreadView();
			messageThreadView.HasNewMessages = BooleanProxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				messageThreadView.LastMessagePreview = StringProxy.Deserialize(bytes);
			}
			messageThreadView.LastUpdate = DateTimeProxy.Deserialize(bytes);
			messageThreadView.MessageCount = Int32Proxy.Deserialize(bytes);
			messageThreadView.ThreadId = Int32Proxy.Deserialize(bytes);
			if ((num & 2) != 0)
			{
				messageThreadView.ThreadName = StringProxy.Deserialize(bytes);
			}
			return messageThreadView;
		}
	}
}
