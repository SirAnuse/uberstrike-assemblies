using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000253 RID: 595
	public static class ClaimFacebookGiftViewProxy
	{
		// Token: 0x0600103D RID: 4157 RVA: 0x00012A2C File Offset: 0x00010C2C
		public static void Serialize(Stream stream, ClaimFacebookGiftView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<ClaimFacebookGiftResult>.Serialize(memoryStream, instance.ClaimResult);
				if (instance.ItemId != null)
				{
					Stream bytes = memoryStream;
					int? itemId = instance.ItemId;
					Int32Proxy.Serialize(bytes, (itemId == null) ? 0 : itemId.Value);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x00012AC0 File Offset: 0x00010CC0
		public static ClaimFacebookGiftView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ClaimFacebookGiftView claimFacebookGiftView = new ClaimFacebookGiftView();
			claimFacebookGiftView.ClaimResult = EnumProxy<ClaimFacebookGiftResult>.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				claimFacebookGiftView.ItemId = new int?(Int32Proxy.Deserialize(bytes));
			}
			return claimFacebookGiftView;
		}
	}
}
