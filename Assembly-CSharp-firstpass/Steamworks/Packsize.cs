using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200009D RID: 157
	public static class Packsize
	{
		// Token: 0x0600042D RID: 1069 RVA: 0x0000F654 File Offset: 0x0000D854
		public static bool Test()
		{
			int num = Marshal.SizeOf(typeof(Packsize.ValvePackingSentinel_t));
			int num2 = Marshal.SizeOf(typeof(RemoteStorageEnumerateUserSubscribedFilesResult_t));
			return num == 32 && num2 == 616;
		}

		// Token: 0x04000337 RID: 823
		public const int value = 8;

		// Token: 0x0200009E RID: 158
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		private struct ValvePackingSentinel_t
		{
			// Token: 0x04000338 RID: 824
			private uint m_u32;

			// Token: 0x04000339 RID: 825
			private ulong m_u64;

			// Token: 0x0400033A RID: 826
			private ushort m_u16;

			// Token: 0x0400033B RID: 827
			private double m_d;
		}
	}
}
