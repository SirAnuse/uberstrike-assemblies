using System;
using System.Collections.Generic;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001D5 RID: 469
	[Serializable]
	public class AccountCompletionResultView
	{
		// Token: 0x06000B62 RID: 2914 RVA: 0x00008372 File Offset: 0x00006572
		public AccountCompletionResultView()
		{
			this.ItemsAttributed = new Dictionary<int, int>();
			this.NonDuplicateNames = new List<string>();
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x00008390 File Offset: 0x00006590
		public AccountCompletionResultView(int result) : this()
		{
			this.Result = result;
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x0000839F File Offset: 0x0000659F
		public AccountCompletionResultView(int result, Dictionary<int, int> itemsAttributed, List<string> nonDuplicateNames)
		{
			this.Result = result;
			this.ItemsAttributed = itemsAttributed;
			this.NonDuplicateNames = nonDuplicateNames;
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000B65 RID: 2917 RVA: 0x000083BC File Offset: 0x000065BC
		// (set) Token: 0x06000B66 RID: 2918 RVA: 0x000083C4 File Offset: 0x000065C4
		public int Result { get; set; }

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x000083CD File Offset: 0x000065CD
		// (set) Token: 0x06000B68 RID: 2920 RVA: 0x000083D5 File Offset: 0x000065D5
		public Dictionary<int, int> ItemsAttributed { get; set; }

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x000083DE File Offset: 0x000065DE
		// (set) Token: 0x06000B6A RID: 2922 RVA: 0x000083E6 File Offset: 0x000065E6
		public List<string> NonDuplicateNames { get; set; }
	}
}
