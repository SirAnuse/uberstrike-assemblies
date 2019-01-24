using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200025A RID: 602
	public static class ContactRequestViewProxy
	{
		// Token: 0x0600104B RID: 4171 RVA: 0x00013214 File Offset: 0x00011414
		public static void Serialize(Stream stream, ContactRequestView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.InitiatorCmid);
				if (instance.InitiatorMessage != null)
				{
					StringProxy.Serialize(memoryStream, instance.InitiatorMessage);
				}
				else
				{
					num |= 1;
				}
				if (instance.InitiatorName != null)
				{
					StringProxy.Serialize(memoryStream, instance.InitiatorName);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(memoryStream, instance.ReceiverCmid);
				Int32Proxy.Serialize(memoryStream, instance.RequestId);
				DateTimeProxy.Serialize(memoryStream, instance.SentDate);
				EnumProxy<ContactRequestStatus>.Serialize(memoryStream, instance.Status);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x000132D8 File Offset: 0x000114D8
		public static ContactRequestView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ContactRequestView contactRequestView = new ContactRequestView();
			contactRequestView.InitiatorCmid = Int32Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				contactRequestView.InitiatorMessage = StringProxy.Deserialize(bytes);
			}
			if ((num & 2) != 0)
			{
				contactRequestView.InitiatorName = StringProxy.Deserialize(bytes);
			}
			contactRequestView.ReceiverCmid = Int32Proxy.Deserialize(bytes);
			contactRequestView.RequestId = Int32Proxy.Deserialize(bytes);
			contactRequestView.SentDate = DateTimeProxy.Deserialize(bytes);
			contactRequestView.Status = EnumProxy<ContactRequestStatus>.Deserialize(bytes);
			return contactRequestView;
		}
	}
}
