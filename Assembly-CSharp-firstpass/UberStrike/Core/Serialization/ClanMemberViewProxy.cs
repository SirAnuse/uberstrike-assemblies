using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000255 RID: 597
	public static class ClanMemberViewProxy
	{
		// Token: 0x06001041 RID: 4161 RVA: 0x00012BB0 File Offset: 0x00010DB0
		public static void Serialize(Stream stream, ClanMemberView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				DateTimeProxy.Serialize(memoryStream, instance.JoiningDate);
				DateTimeProxy.Serialize(memoryStream, instance.Lastlogin);
				if (instance.Name != null)
				{
					StringProxy.Serialize(memoryStream, instance.Name);
				}
				else
				{
					num |= 1;
				}
				EnumProxy<GroupPosition>.Serialize(memoryStream, instance.Position);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x00012C48 File Offset: 0x00010E48
		public static ClanMemberView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ClanMemberView clanMemberView = new ClanMemberView();
			clanMemberView.Cmid = Int32Proxy.Deserialize(bytes);
			clanMemberView.JoiningDate = DateTimeProxy.Deserialize(bytes);
			clanMemberView.Lastlogin = DateTimeProxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				clanMemberView.Name = StringProxy.Deserialize(bytes);
			}
			clanMemberView.Position = EnumProxy<GroupPosition>.Deserialize(bytes);
			return clanMemberView;
		}
	}
}
