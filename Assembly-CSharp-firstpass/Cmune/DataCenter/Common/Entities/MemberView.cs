using System;
using System.Collections.Generic;
using System.Text;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200005D RID: 93
	[Serializable]
	public class MemberView
	{
		// Token: 0x0600026D RID: 621 RVA: 0x000034BD File Offset: 0x000016BD
		public MemberView()
		{
			this.PublicProfile = new PublicProfileView();
			this.MemberWallet = new MemberWalletView();
			this.MemberItems = new List<int>(0);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x000034E7 File Offset: 0x000016E7
		public MemberView(PublicProfileView publicProfile, MemberWalletView memberWallet, List<int> memberItems)
		{
			this.PublicProfile = publicProfile;
			this.MemberWallet = memberWallet;
			this.MemberItems = memberItems;
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00003504 File Offset: 0x00001704
		// (set) Token: 0x06000270 RID: 624 RVA: 0x0000350C File Offset: 0x0000170C
		public PublicProfileView PublicProfile { get; set; }

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000271 RID: 625 RVA: 0x00003515 File Offset: 0x00001715
		// (set) Token: 0x06000272 RID: 626 RVA: 0x0000351D File Offset: 0x0000171D
		public MemberWalletView MemberWallet { get; set; }

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00003526 File Offset: 0x00001726
		// (set) Token: 0x06000274 RID: 628 RVA: 0x0000352E File Offset: 0x0000172E
		public List<int> MemberItems { get; set; }

		// Token: 0x06000275 RID: 629 RVA: 0x0000E244 File Offset: 0x0000C444
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("[Member view: ");
			if (this.PublicProfile != null && this.MemberWallet != null)
			{
				stringBuilder.Append(this.PublicProfile);
				stringBuilder.Append(this.MemberWallet);
				stringBuilder.Append("[items: ");
				if (this.MemberItems != null && this.MemberItems.Count > 0)
				{
					int num = this.MemberItems.Count;
					foreach (int value in this.MemberItems)
					{
						stringBuilder.Append(value);
						if (--num > 0)
						{
							stringBuilder.Append(", ");
						}
					}
				}
				else
				{
					stringBuilder.Append("No items");
				}
				stringBuilder.Append("]");
			}
			else
			{
				stringBuilder.Append("No member");
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
