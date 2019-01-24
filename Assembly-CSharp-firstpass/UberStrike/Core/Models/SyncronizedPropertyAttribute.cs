using System;

namespace UberStrike.Core.Models
{
	// Token: 0x0200022B RID: 555
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class SyncronizedPropertyAttribute : Attribute
	{
		// Token: 0x06000ECD RID: 3789 RVA: 0x0000A294 File Offset: 0x00008494
		public SyncronizedPropertyAttribute(int id)
		{
			this.ID = id;
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000ECF RID: 3791 RVA: 0x0000A2AC File Offset: 0x000084AC
		// (set) Token: 0x06000ECE RID: 3790 RVA: 0x0000A2A3 File Offset: 0x000084A3
		public int ID { get; private set; }
	}
}
