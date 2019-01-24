using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000265 RID: 613
	public static class MemberViewProxy
	{
		// Token: 0x06001061 RID: 4193 RVA: 0x000142E0 File Offset: 0x000124E0
		public static void Serialize(Stream stream, MemberView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.MemberItems != null)
				{
					ListProxy<int>.Serialize(memoryStream, instance.MemberItems, new ListProxy<int>.Serializer<int>(Int32Proxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				if (instance.MemberWallet != null)
				{
					MemberWalletViewProxy.Serialize(memoryStream, instance.MemberWallet);
				}
				else
				{
					num |= 2;
				}
				if (instance.PublicProfile != null)
				{
					PublicProfileViewProxy.Serialize(memoryStream, instance.PublicProfile);
				}
				else
				{
					num |= 4;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x00014394 File Offset: 0x00012594
		public static MemberView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			MemberView memberView = new MemberView();
			if ((num & 1) != 0)
			{
				memberView.MemberItems = ListProxy<int>.Deserialize(bytes, new ListProxy<int>.Deserializer<int>(Int32Proxy.Deserialize));
			}
			if ((num & 2) != 0)
			{
				memberView.MemberWallet = MemberWalletViewProxy.Deserialize(bytes);
			}
			if ((num & 4) != 0)
			{
				memberView.PublicProfile = PublicProfileViewProxy.Deserialize(bytes);
			}
			return memberView;
		}
	}
}
