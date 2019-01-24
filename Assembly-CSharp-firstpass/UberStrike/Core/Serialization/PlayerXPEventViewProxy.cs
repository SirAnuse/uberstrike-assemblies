using System;
using System.IO;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002A5 RID: 677
	public static class PlayerXPEventViewProxy
	{
		// Token: 0x060010ED RID: 4333 RVA: 0x00019094 File Offset: 0x00017294
		public static void Serialize(Stream stream, PlayerXPEventView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.Name != null)
				{
					StringProxy.Serialize(memoryStream, instance.Name);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.PlayerXPEventId);
				DecimalProxy.Serialize(memoryStream, instance.XPMultiplier);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010EE RID: 4334 RVA: 0x00019114 File Offset: 0x00017314
		public static PlayerXPEventView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			PlayerXPEventView playerXPEventView = new PlayerXPEventView();
			if ((num & 1) != 0)
			{
				playerXPEventView.Name = StringProxy.Deserialize(bytes);
			}
			playerXPEventView.PlayerXPEventId = Int32Proxy.Deserialize(bytes);
			playerXPEventView.XPMultiplier = DecimalProxy.Deserialize(bytes);
			return playerXPEventView;
		}
	}
}
