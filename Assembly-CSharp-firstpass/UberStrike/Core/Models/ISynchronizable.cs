using System;
using System.Collections.Generic;

namespace UberStrike.Core.Models
{
	// Token: 0x02000225 RID: 549
	public interface ISynchronizable
	{
		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000E4D RID: 3661
		SortedList<int, object> Changes { get; }
	}
}
