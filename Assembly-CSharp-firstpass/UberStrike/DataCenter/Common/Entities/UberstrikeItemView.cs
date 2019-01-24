using System;
using System.Text;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F7 RID: 503
	public class UberstrikeItemView : ItemView
	{
		// Token: 0x06000D79 RID: 3449 RVA: 0x000096FC File Offset: 0x000078FC
		public UberstrikeItemView()
		{
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x00009704 File Offset: 0x00007904
		public UberstrikeItemView(ItemView item, int levelRequired) : base(item)
		{
			this.LevelRequired = levelRequired;
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x06000D7B RID: 3451 RVA: 0x00009714 File Offset: 0x00007914
		// (set) Token: 0x06000D7C RID: 3452 RVA: 0x0000971C File Offset: 0x0000791C
		public int LevelRequired { get; set; }

		// Token: 0x06000D7D RID: 3453 RVA: 0x000114B8 File Offset: 0x0000F6B8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeItemView: ");
			stringBuilder.Append(base.ToString());
			stringBuilder.Append("[LevelRequired: ");
			stringBuilder.Append(this.LevelRequired);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
