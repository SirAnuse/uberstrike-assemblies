using System;

namespace UberStrike.Realtime.UnitySdk
{
	// Token: 0x02000342 RID: 834
	public class GameFlags
	{
		// Token: 0x170003BD RID: 957
		// (get) Token: 0x060013A1 RID: 5025 RVA: 0x0000C0F7 File Offset: 0x0000A2F7
		// (set) Token: 0x060013A2 RID: 5026 RVA: 0x0000C100 File Offset: 0x0000A300
		public bool LowGravity
		{
			get
			{
				return this.IsFlagSet(GameFlags.GAME_FLAGS.LowGravity);
			}
			set
			{
				this.SetFlag(GameFlags.GAME_FLAGS.LowGravity, value);
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x060013A3 RID: 5027 RVA: 0x0000C10A File Offset: 0x0000A30A
		// (set) Token: 0x060013A4 RID: 5028 RVA: 0x0000C113 File Offset: 0x0000A313
		public bool NoArmor
		{
			get
			{
				return this.IsFlagSet(GameFlags.GAME_FLAGS.NoArmor);
			}
			set
			{
				this.SetFlag(GameFlags.GAME_FLAGS.NoArmor, value);
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x060013A5 RID: 5029 RVA: 0x0000C11D File Offset: 0x0000A31D
		// (set) Token: 0x060013A6 RID: 5030 RVA: 0x0000C126 File Offset: 0x0000A326
		public bool QuickSwitch
		{
			get
			{
				return this.IsFlagSet(GameFlags.GAME_FLAGS.QuickSwitch);
			}
			set
			{
				this.SetFlag(GameFlags.GAME_FLAGS.QuickSwitch, value);
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x060013A7 RID: 5031 RVA: 0x0000C130 File Offset: 0x0000A330
		// (set) Token: 0x060013A8 RID: 5032 RVA: 0x0000C139 File Offset: 0x0000A339
		public bool MeleeOnly
		{
			get
			{
				return this.IsFlagSet(GameFlags.GAME_FLAGS.MeleeOnly);
			}
			set
			{
				this.SetFlag(GameFlags.GAME_FLAGS.MeleeOnly, value);
			}
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x0000C143 File Offset: 0x0000A343
		public int ToInt()
		{
			return (int)this.gameFlags;
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x0000C14B File Offset: 0x0000A34B
		public static bool IsFlagSet(GameFlags.GAME_FLAGS flag, int state)
		{
			return (state & (int)flag) != 0;
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x0000C156 File Offset: 0x0000A356
		private bool IsFlagSet(GameFlags.GAME_FLAGS f)
		{
			return (this.gameFlags & f) == f;
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x0000C163 File Offset: 0x0000A363
		private void SetFlag(GameFlags.GAME_FLAGS f, bool b)
		{
			this.gameFlags = ((!b) ? (this.gameFlags & ~f) : (this.gameFlags | f));
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x0000C187 File Offset: 0x0000A387
		public void SetFlags(int flags)
		{
			this.gameFlags = (GameFlags.GAME_FLAGS)flags;
		}

		// Token: 0x060013AE RID: 5038 RVA: 0x0000C190 File Offset: 0x0000A390
		public void ResetFlags()
		{
			this.gameFlags = GameFlags.GAME_FLAGS.None;
		}

		// Token: 0x04000E0F RID: 3599
		private GameFlags.GAME_FLAGS gameFlags;

		// Token: 0x02000343 RID: 835
		[Flags]
		public enum GAME_FLAGS
		{
			// Token: 0x04000E11 RID: 3601
			None = 0,
			// Token: 0x04000E12 RID: 3602
			LowGravity = 1,
			// Token: 0x04000E13 RID: 3603
			NoArmor = 2,
			// Token: 0x04000E14 RID: 3604
			QuickSwitch = 4,
			// Token: 0x04000E15 RID: 3605
			MeleeOnly = 8
		}
	}
}
