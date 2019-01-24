using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002B2 RID: 690
	public static class MemberAuthenticationViewModelProxy
	{
		// Token: 0x06001107 RID: 4359 RVA: 0x0001A738 File Offset: 0x00018938
		public static void Serialize(Stream stream, MemberAuthenticationViewModel instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<MemberAuthenticationResult>.Serialize(memoryStream, instance.MemberAuthenticationResult);
				if (instance.MemberView != null)
				{
					MemberViewProxy.Serialize(memoryStream, instance.MemberView);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x0001A7AC File Offset: 0x000189AC
		public static MemberAuthenticationViewModel Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			MemberAuthenticationViewModel memberAuthenticationViewModel = new MemberAuthenticationViewModel();
			memberAuthenticationViewModel.MemberAuthenticationResult = EnumProxy<MemberAuthenticationResult>.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				memberAuthenticationViewModel.MemberView = MemberViewProxy.Deserialize(bytes);
			}
			return memberAuthenticationViewModel;
		}
	}
}
