using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000266 RID: 614
	public static class MemberWalletViewProxy
	{
		// Token: 0x06001063 RID: 4195 RVA: 0x000143F8 File Offset: 0x000125F8
		public static void Serialize(Stream stream, MemberWalletView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				Int32Proxy.Serialize(memoryStream, instance.Credits);
				DateTimeProxy.Serialize(memoryStream, instance.CreditsExpiration);
				Int32Proxy.Serialize(memoryStream, instance.Points);
				DateTimeProxy.Serialize(memoryStream, instance.PointsExpiration);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x00014470 File Offset: 0x00012670
		public static MemberWalletView Deserialize(Stream bytes)
		{
			return new MemberWalletView
			{
				Cmid = Int32Proxy.Deserialize(bytes),
				Credits = Int32Proxy.Deserialize(bytes),
				CreditsExpiration = DateTimeProxy.Deserialize(bytes),
				Points = Int32Proxy.Deserialize(bytes),
				PointsExpiration = DateTimeProxy.Deserialize(bytes)
			};
		}
	}
}
