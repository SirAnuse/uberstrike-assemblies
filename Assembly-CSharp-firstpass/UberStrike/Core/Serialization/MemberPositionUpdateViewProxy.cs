using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000262 RID: 610
	public static class MemberPositionUpdateViewProxy
	{
		// Token: 0x0600105B RID: 4187 RVA: 0x00013EF8 File Offset: 0x000120F8
		public static void Serialize(Stream stream, MemberPositionUpdateView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.AuthToken != null)
				{
					StringProxy.Serialize(memoryStream, instance.AuthToken);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.GroupId);
				Int32Proxy.Serialize(memoryStream, instance.MemberCmid);
				EnumProxy<GroupPosition>.Serialize(memoryStream, instance.Position);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x00013F84 File Offset: 0x00012184
		public static MemberPositionUpdateView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			MemberPositionUpdateView memberPositionUpdateView = new MemberPositionUpdateView();
			if ((num & 1) != 0)
			{
				memberPositionUpdateView.AuthToken = StringProxy.Deserialize(bytes);
			}
			memberPositionUpdateView.GroupId = Int32Proxy.Deserialize(bytes);
			memberPositionUpdateView.MemberCmid = Int32Proxy.Deserialize(bytes);
			memberPositionUpdateView.Position = EnumProxy<GroupPosition>.Deserialize(bytes);
			return memberPositionUpdateView;
		}
	}
}
