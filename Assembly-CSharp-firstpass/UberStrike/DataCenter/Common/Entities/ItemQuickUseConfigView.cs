using System;
using UberStrike.Core.Types;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001DB RID: 475
	[Serializable]
	public class ItemQuickUseConfigView
	{
		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x0000862E File Offset: 0x0000682E
		// (set) Token: 0x06000BA3 RID: 2979 RVA: 0x00008636 File Offset: 0x00006836
		public int ItemId { get; set; }

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000BA4 RID: 2980 RVA: 0x0000863F File Offset: 0x0000683F
		// (set) Token: 0x06000BA5 RID: 2981 RVA: 0x00008647 File Offset: 0x00006847
		public int LevelRequired { get; set; }

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000BA6 RID: 2982 RVA: 0x00008650 File Offset: 0x00006850
		// (set) Token: 0x06000BA7 RID: 2983 RVA: 0x00008658 File Offset: 0x00006858
		public int UsesPerLife { get; set; }

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x00008661 File Offset: 0x00006861
		// (set) Token: 0x06000BA9 RID: 2985 RVA: 0x00008669 File Offset: 0x00006869
		public int UsesPerRound { get; set; }

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x00008672 File Offset: 0x00006872
		// (set) Token: 0x06000BAB RID: 2987 RVA: 0x0000867A File Offset: 0x0000687A
		public int UsesPerGame { get; set; }

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x00008683 File Offset: 0x00006883
		// (set) Token: 0x06000BAD RID: 2989 RVA: 0x0000868B File Offset: 0x0000688B
		public int CoolDownTime { get; set; }

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x00008694 File Offset: 0x00006894
		// (set) Token: 0x06000BAF RID: 2991 RVA: 0x0000869C File Offset: 0x0000689C
		public int WarmUpTime { get; set; }

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x000086A5 File Offset: 0x000068A5
		// (set) Token: 0x06000BB1 RID: 2993 RVA: 0x000086AD File Offset: 0x000068AD
		public QuickItemLogic BehaviourType { get; set; }
	}
}
