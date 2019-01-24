using System;
using Cmune.DataCenter.Common.Entities;

// Token: 0x02000127 RID: 295
public static class GlobalEvents
{
	// Token: 0x02000128 RID: 296
	public class Logout
	{
	}

	// Token: 0x02000129 RID: 297
	public class Login
	{
		// Token: 0x06000842 RID: 2114 RVA: 0x000072B0 File Offset: 0x000054B0
		public Login(MemberAccessLevel level)
		{
			this.AccessLevel = level;
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x000072BF File Offset: 0x000054BF
		// (set) Token: 0x06000844 RID: 2116 RVA: 0x000072C7 File Offset: 0x000054C7
		public MemberAccessLevel AccessLevel { get; private set; }
	}

	// Token: 0x0200012A RID: 298
	public class MobileBackPressed
	{
	}

	// Token: 0x0200012B RID: 299
	public class GlobalUIRibbonChanged
	{
	}

	// Token: 0x0200012C RID: 300
	public class ScreenshotTaken
	{
	}

	// Token: 0x0200012D RID: 301
	public class InputAssignment
	{
	}

	// Token: 0x0200012E RID: 302
	public class InputChanged
	{
		// Token: 0x06000849 RID: 2121 RVA: 0x000072D0 File Offset: 0x000054D0
		public InputChanged(GameInputKey key, float value)
		{
			this.Key = key;
			this.Value = value;
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x000072E6 File Offset: 0x000054E6
		// (set) Token: 0x0600084B RID: 2123 RVA: 0x000072EE File Offset: 0x000054EE
		public GameInputKey Key { get; private set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x0600084C RID: 2124 RVA: 0x000072F7 File Offset: 0x000054F7
		// (set) Token: 0x0600084D RID: 2125 RVA: 0x000072FF File Offset: 0x000054FF
		public float Value { get; private set; }

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x00007308 File Offset: 0x00005508
		public bool IsDown
		{
			get
			{
				return this.Value != 0f;
			}
		}
	}

	// Token: 0x0200012F RID: 303
	public class CameraWidthChanged
	{
	}

	// Token: 0x02000130 RID: 304
	public class ScreenResolutionChanged
	{
	}

	// Token: 0x02000131 RID: 305
	public class ClanCreated
	{
	}

	// Token: 0x02000132 RID: 306
	public class GamePageChanged
	{
	}
}
