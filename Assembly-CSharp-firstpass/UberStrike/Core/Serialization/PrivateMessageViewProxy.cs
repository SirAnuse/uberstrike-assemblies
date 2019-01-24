﻿using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200026E RID: 622
	public static class PrivateMessageViewProxy
	{
		// Token: 0x06001073 RID: 4211 RVA: 0x00014D00 File Offset: 0x00012F00
		public static void Serialize(Stream stream, PrivateMessageView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.ContentText != null)
				{
					StringProxy.Serialize(memoryStream, instance.ContentText);
				}
				else
				{
					num |= 1;
				}
				DateTimeProxy.Serialize(memoryStream, instance.DateSent);
				Int32Proxy.Serialize(memoryStream, instance.FromCmid);
				if (instance.FromName != null)
				{
					StringProxy.Serialize(memoryStream, instance.FromName);
				}
				else
				{
					num |= 2;
				}
				BooleanProxy.Serialize(memoryStream, instance.HasAttachment);
				BooleanProxy.Serialize(memoryStream, instance.IsDeletedByReceiver);
				BooleanProxy.Serialize(memoryStream, instance.IsDeletedBySender);
				BooleanProxy.Serialize(memoryStream, instance.IsRead);
				Int32Proxy.Serialize(memoryStream, instance.PrivateMessageId);
				Int32Proxy.Serialize(memoryStream, instance.ToCmid);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x00014DE8 File Offset: 0x00012FE8
		public static PrivateMessageView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			PrivateMessageView privateMessageView = new PrivateMessageView();
			if ((num & 1) != 0)
			{
				privateMessageView.ContentText = StringProxy.Deserialize(bytes);
			}
			privateMessageView.DateSent = DateTimeProxy.Deserialize(bytes);
			privateMessageView.FromCmid = Int32Proxy.Deserialize(bytes);
			if ((num & 2) != 0)
			{
				privateMessageView.FromName = StringProxy.Deserialize(bytes);
			}
			privateMessageView.HasAttachment = BooleanProxy.Deserialize(bytes);
			privateMessageView.IsDeletedByReceiver = BooleanProxy.Deserialize(bytes);
			privateMessageView.IsDeletedBySender = BooleanProxy.Deserialize(bytes);
			privateMessageView.IsRead = BooleanProxy.Deserialize(bytes);
			privateMessageView.PrivateMessageId = Int32Proxy.Deserialize(bytes);
			privateMessageView.ToCmid = Int32Proxy.Deserialize(bytes);
			return privateMessageView;
		}
	}
}
