using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000252 RID: 594
	public static class CheckApplicationVersionViewProxy
	{
		// Token: 0x0600103B RID: 4155 RVA: 0x00012960 File Offset: 0x00010B60
		public static void Serialize(Stream stream, CheckApplicationVersionView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.ClientVersion != null)
				{
					ApplicationViewProxy.Serialize(memoryStream, instance.ClientVersion);
				}
				else
				{
					num |= 1;
				}
				if (instance.CurrentVersion != null)
				{
					ApplicationViewProxy.Serialize(memoryStream, instance.CurrentVersion);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x000129E8 File Offset: 0x00010BE8
		public static CheckApplicationVersionView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			CheckApplicationVersionView checkApplicationVersionView = new CheckApplicationVersionView();
			if ((num & 1) != 0)
			{
				checkApplicationVersionView.ClientVersion = ApplicationViewProxy.Deserialize(bytes);
			}
			if ((num & 2) != 0)
			{
				checkApplicationVersionView.CurrentVersion = ApplicationViewProxy.Deserialize(bytes);
			}
			return checkApplicationVersionView;
		}
	}
}
