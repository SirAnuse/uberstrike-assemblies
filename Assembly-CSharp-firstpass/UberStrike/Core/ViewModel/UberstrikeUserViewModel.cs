using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x02000247 RID: 583
	[Serializable]
	public class UberstrikeUserViewModel
	{
		public MemberView CmuneMemberView { get; set; }
		public UberstrikeMemberView UberstrikeMemberView { get; set; }
	}
}
