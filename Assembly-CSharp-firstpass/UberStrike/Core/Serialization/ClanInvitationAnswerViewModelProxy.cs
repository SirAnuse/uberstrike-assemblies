using System;
using System.IO;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000298 RID: 664
	public static class ClanInvitationAnswerViewModelProxy
	{
		// Token: 0x060010D3 RID: 4307 RVA: 0x00017D18 File Offset: 0x00015F18
		public static void Serialize(Stream stream, ClanInvitationAnswerViewModel instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.GroupInvitationId);
				BooleanProxy.Serialize(memoryStream, instance.IsInvitationAccepted);
				Int32Proxy.Serialize(memoryStream, instance.ReturnValue);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x00017D78 File Offset: 0x00015F78
		public static ClanInvitationAnswerViewModel Deserialize(Stream bytes)
		{
			return new ClanInvitationAnswerViewModel
			{
				GroupInvitationId = Int32Proxy.Deserialize(bytes),
				IsInvitationAccepted = BooleanProxy.Deserialize(bytes),
				ReturnValue = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
