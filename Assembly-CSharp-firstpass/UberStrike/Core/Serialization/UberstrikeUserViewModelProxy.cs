using System;
using System.IO;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002BA RID: 698
	public static class UberstrikeUserViewModelProxy
	{
		// Token: 0x06001117 RID: 4375 RVA: 0x0001AF98 File Offset: 0x00019198
		public static void Serialize(Stream stream, UberstrikeUserViewModel instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.CmuneMemberView != null)
				{
					MemberViewProxy.Serialize(memoryStream, instance.CmuneMemberView);
				}
				else
				{
					num |= 1;
				}
				if (instance.UberstrikeMemberView != null)
				{
					UberstrikeMemberViewProxy.Serialize(memoryStream, instance.UberstrikeMemberView);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x0001B020 File Offset: 0x00019220
		public static UberstrikeUserViewModel Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			UberstrikeUserViewModel uberstrikeUserViewModel = new UberstrikeUserViewModel();
			if ((num & 1) != 0)
			{
				uberstrikeUserViewModel.CmuneMemberView = MemberViewProxy.Deserialize(bytes);
			}
			if ((num & 2) != 0)
			{
				uberstrikeUserViewModel.UberstrikeMemberView = UberstrikeMemberViewProxy.Deserialize(bytes);
			}
			return uberstrikeUserViewModel;
		}
	}
}
