using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200026F RID: 623
	public static class PublicProfileViewProxy
	{
		// Token: 0x06001075 RID: 4213 RVA: 0x00014E8C File Offset: 0x0001308C
		public static void Serialize(Stream stream, PublicProfileView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<MemberAccessLevel>.Serialize(memoryStream, instance.AccessLevel);
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				EnumProxy<EmailAddressStatus>.Serialize(memoryStream, instance.EmailAddressStatus);
				if (instance.FacebookId != null)
				{
					StringProxy.Serialize(memoryStream, instance.FacebookId);
				}
				else
				{
					num |= 1;
				}
				if (instance.GroupTag != null)
				{
					StringProxy.Serialize(memoryStream, instance.GroupTag);
				}
				else
				{
					num |= 2;
				}
				BooleanProxy.Serialize(memoryStream, instance.IsChatDisabled);
				DateTimeProxy.Serialize(memoryStream, instance.LastLoginDate);
				if (instance.Name != null)
				{
					StringProxy.Serialize(memoryStream, instance.Name);
				}
				else
				{
					num |= 4;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x00014F70 File Offset: 0x00013170
		public static PublicProfileView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			PublicProfileView publicProfileView = new PublicProfileView();
			publicProfileView.AccessLevel = EnumProxy<MemberAccessLevel>.Deserialize(bytes);
			publicProfileView.Cmid = Int32Proxy.Deserialize(bytes);
			publicProfileView.EmailAddressStatus = EnumProxy<EmailAddressStatus>.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				publicProfileView.FacebookId = StringProxy.Deserialize(bytes);
			}
			if ((num & 2) != 0)
			{
				publicProfileView.GroupTag = StringProxy.Deserialize(bytes);
			}
			publicProfileView.IsChatDisabled = BooleanProxy.Deserialize(bytes);
			publicProfileView.LastLoginDate = DateTimeProxy.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				publicProfileView.Name = StringProxy.Deserialize(bytes);
			}
			return publicProfileView;
		}
	}
}
