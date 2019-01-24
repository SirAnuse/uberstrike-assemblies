using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000256 RID: 598
	public static class ClanRequestAcceptViewProxy
	{
		// Token: 0x06001043 RID: 4163 RVA: 0x00012CA8 File Offset: 0x00010EA8
		public static void Serialize(Stream stream, ClanRequestAcceptView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.ActionResult);
				Int32Proxy.Serialize(memoryStream, instance.ClanRequestId);
				if (instance.ClanView != null)
				{
					ClanViewProxy.Serialize(memoryStream, instance.ClanView);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x00012D28 File Offset: 0x00010F28
		public static ClanRequestAcceptView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ClanRequestAcceptView clanRequestAcceptView = new ClanRequestAcceptView();
			clanRequestAcceptView.ActionResult = Int32Proxy.Deserialize(bytes);
			clanRequestAcceptView.ClanRequestId = Int32Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				clanRequestAcceptView.ClanView = ClanViewProxy.Deserialize(bytes);
			}
			return clanRequestAcceptView;
		}
	}
}
