using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200025D RID: 605
	public static class GroupInvitationViewProxy
	{
		// Token: 0x06001051 RID: 4177 RVA: 0x000137D8 File Offset: 0x000119D8
		public static void Serialize(Stream stream, GroupInvitationView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.GroupId);
				Int32Proxy.Serialize(memoryStream, instance.GroupInvitationId);
				if (instance.GroupName != null)
				{
					StringProxy.Serialize(memoryStream, instance.GroupName);
				}
				else
				{
					num |= 1;
				}
				if (instance.GroupTag != null)
				{
					StringProxy.Serialize(memoryStream, instance.GroupTag);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(memoryStream, instance.InviteeCmid);
				if (instance.InviteeName != null)
				{
					StringProxy.Serialize(memoryStream, instance.InviteeName);
				}
				else
				{
					num |= 4;
				}
				Int32Proxy.Serialize(memoryStream, instance.InviterCmid);
				if (instance.InviterName != null)
				{
					StringProxy.Serialize(memoryStream, instance.InviterName);
				}
				else
				{
					num |= 8;
				}
				if (instance.Message != null)
				{
					StringProxy.Serialize(memoryStream, instance.Message);
				}
				else
				{
					num |= 16;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x000138F0 File Offset: 0x00011AF0
		public static GroupInvitationView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			GroupInvitationView groupInvitationView = new GroupInvitationView();
			groupInvitationView.GroupId = Int32Proxy.Deserialize(bytes);
			groupInvitationView.GroupInvitationId = Int32Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				groupInvitationView.GroupName = StringProxy.Deserialize(bytes);
			}
			if ((num & 2) != 0)
			{
				groupInvitationView.GroupTag = StringProxy.Deserialize(bytes);
			}
			groupInvitationView.InviteeCmid = Int32Proxy.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				groupInvitationView.InviteeName = StringProxy.Deserialize(bytes);
			}
			groupInvitationView.InviterCmid = Int32Proxy.Deserialize(bytes);
			if ((num & 8) != 0)
			{
				groupInvitationView.InviterName = StringProxy.Deserialize(bytes);
			}
			if ((num & 16) != 0)
			{
				groupInvitationView.Message = StringProxy.Deserialize(bytes);
			}
			return groupInvitationView;
		}
	}
}
