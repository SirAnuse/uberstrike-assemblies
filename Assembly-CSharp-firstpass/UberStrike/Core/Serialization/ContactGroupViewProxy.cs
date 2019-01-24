using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000259 RID: 601
	public static class ContactGroupViewProxy
	{
		// Token: 0x06001049 RID: 4169 RVA: 0x00013118 File Offset: 0x00011318
		public static void Serialize(Stream stream, ContactGroupView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.Contacts != null)
				{
					ListProxy<PublicProfileView>.Serialize(memoryStream, instance.Contacts, new ListProxy<PublicProfileView>.Serializer<PublicProfileView>(PublicProfileViewProxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.GroupId);
				if (instance.GroupName != null)
				{
					StringProxy.Serialize(memoryStream, instance.GroupName);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x000131B8 File Offset: 0x000113B8
		public static ContactGroupView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ContactGroupView contactGroupView = new ContactGroupView();
			if ((num & 1) != 0)
			{
				contactGroupView.Contacts = ListProxy<PublicProfileView>.Deserialize(bytes, new ListProxy<PublicProfileView>.Deserializer<PublicProfileView>(PublicProfileViewProxy.Deserialize));
			}
			contactGroupView.GroupId = Int32Proxy.Deserialize(bytes);
			if ((num & 2) != 0)
			{
				contactGroupView.GroupName = StringProxy.Deserialize(bytes);
			}
			return contactGroupView;
		}
	}
}
