using System;
using System.IO;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002A6 RID: 678
	public static class UberstrikeMemberViewProxy
	{
		// Token: 0x060010EF RID: 4335 RVA: 0x0001915C File Offset: 0x0001735C
		public static void Serialize(Stream stream, UberstrikeMemberView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.PlayerCardView != null)
				{
					PlayerCardViewProxy.Serialize(memoryStream, instance.PlayerCardView);
				}
				else
				{
					num |= 1;
				}
				if (instance.PlayerStatisticsView != null)
				{
					PlayerStatisticsViewProxy.Serialize(memoryStream, instance.PlayerStatisticsView);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x000191E4 File Offset: 0x000173E4
		public static UberstrikeMemberView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			UberstrikeMemberView uberstrikeMemberView = new UberstrikeMemberView();
			if ((num & 1) != 0)
			{
				uberstrikeMemberView.PlayerCardView = PlayerCardViewProxy.Deserialize(bytes);
			}
			if ((num & 2) != 0)
			{
				uberstrikeMemberView.PlayerStatisticsView = PlayerStatisticsViewProxy.Deserialize(bytes);
			}
			return uberstrikeMemberView;
		}
	}
}
