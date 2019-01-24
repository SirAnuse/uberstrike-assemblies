using System;

namespace UberStrike.Core.Models
{
	// Token: 0x02000226 RID: 550
	[Serializable]
	public class PlayerMovement
	{
		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x00009DFC File Offset: 0x00007FFC
		// (set) Token: 0x06000E50 RID: 3664 RVA: 0x00009E04 File Offset: 0x00008004
		public byte Number { get; set; }

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000E51 RID: 3665 RVA: 0x00009E0D File Offset: 0x0000800D
		// (set) Token: 0x06000E52 RID: 3666 RVA: 0x00009E15 File Offset: 0x00008015
		public ShortVector3 Position { get; set; }

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000E53 RID: 3667 RVA: 0x00009E1E File Offset: 0x0000801E
		// (set) Token: 0x06000E54 RID: 3668 RVA: 0x00009E26 File Offset: 0x00008026
		public ShortVector3 Velocity { get; set; }

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000E55 RID: 3669 RVA: 0x00009E2F File Offset: 0x0000802F
		// (set) Token: 0x06000E56 RID: 3670 RVA: 0x00009E37 File Offset: 0x00008037
		public byte HorizontalRotation { get; set; }

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000E57 RID: 3671 RVA: 0x00009E40 File Offset: 0x00008040
		// (set) Token: 0x06000E58 RID: 3672 RVA: 0x00009E48 File Offset: 0x00008048
		public byte VerticalRotation { get; set; }

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000E59 RID: 3673 RVA: 0x00009E51 File Offset: 0x00008051
		// (set) Token: 0x06000E5A RID: 3674 RVA: 0x00009E59 File Offset: 0x00008059
		public byte KeyState { get; set; }

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000E5B RID: 3675 RVA: 0x00009E62 File Offset: 0x00008062
		// (set) Token: 0x06000E5C RID: 3676 RVA: 0x00009E6A File Offset: 0x0000806A
		public byte MovementState { get; set; }
	}
}
