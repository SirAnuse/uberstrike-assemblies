using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000254 RID: 596
	public static class ClanCreationReturnViewProxy
	{
		// Token: 0x0600103F RID: 4159 RVA: 0x00012B00 File Offset: 0x00010D00
		public static void Serialize(Stream stream, ClanCreationReturnView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.ClanView != null)
				{
					ClanViewProxy.Serialize(memoryStream, instance.ClanView);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.ResultCode);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x00012B74 File Offset: 0x00010D74
		public static ClanCreationReturnView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ClanCreationReturnView clanCreationReturnView = new ClanCreationReturnView();
			if ((num & 1) != 0)
			{
				clanCreationReturnView.ClanView = ClanViewProxy.Deserialize(bytes);
			}
			clanCreationReturnView.ResultCode = Int32Proxy.Deserialize(bytes);
			return clanCreationReturnView;
		}
	}
}
