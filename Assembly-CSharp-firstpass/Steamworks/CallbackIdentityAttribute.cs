using System;

namespace Steamworks
{
	// Token: 0x02000079 RID: 121
	[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false)]
	internal class CallbackIdentityAttribute : Attribute
	{
		// Token: 0x060003A1 RID: 929 RVA: 0x00003F85 File Offset: 0x00002185
		public CallbackIdentityAttribute(int callbackNum)
		{
			this.Identity = callbackNum;
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00003F94 File Offset: 0x00002194
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x00003F9C File Offset: 0x0000219C
		public int Identity { get; set; }
	}
}
