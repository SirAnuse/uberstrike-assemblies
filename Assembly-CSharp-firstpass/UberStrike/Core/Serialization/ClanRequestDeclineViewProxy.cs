using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000257 RID: 599
	public static class ClanRequestDeclineViewProxy
	{
		// Token: 0x06001045 RID: 4165 RVA: 0x00012D70 File Offset: 0x00010F70
		public static void Serialize(Stream stream, ClanRequestDeclineView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.ActionResult);
				Int32Proxy.Serialize(memoryStream, instance.ClanRequestId);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x00012DC4 File Offset: 0x00010FC4
		public static ClanRequestDeclineView Deserialize(Stream bytes)
		{
			return new ClanRequestDeclineView
			{
				ActionResult = Int32Proxy.Deserialize(bytes),
				ClanRequestId = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
