using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200024F RID: 591
	public static class BugViewProxy
	{
		// Token: 0x06001035 RID: 4149 RVA: 0x0001242C File Offset: 0x0001062C
		public static void Serialize(Stream stream, BugView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.Content != null)
				{
					StringProxy.Serialize(memoryStream, instance.Content);
				}
				else
				{
					num |= 1;
				}
				if (instance.Subject != null)
				{
					StringProxy.Serialize(memoryStream, instance.Subject);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x000124B4 File Offset: 0x000106B4
		public static BugView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			BugView bugView = new BugView();
			if ((num & 1) != 0)
			{
				bugView.Content = StringProxy.Deserialize(bytes);
			}
			if ((num & 2) != 0)
			{
				bugView.Subject = StringProxy.Deserialize(bytes);
			}
			return bugView;
		}
	}
}
