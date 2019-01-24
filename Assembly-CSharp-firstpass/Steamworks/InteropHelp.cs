using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x02000098 RID: 152
	public class InteropHelp
	{
		// Token: 0x06000418 RID: 1048 RVA: 0x00004074 File Offset: 0x00002274
		public static void TestIfPlatformSupported()
		{
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00004076 File Offset: 0x00002276
		public static void TestIfAvailableClient()
		{
			InteropHelp.TestIfPlatformSupported();
			if (NativeMethods.SteamClient() == IntPtr.Zero)
			{
				throw new InvalidOperationException("Steamworks is not initialized.");
			}
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x0000409C File Offset: 0x0000229C
		public static void TestIfAvailableGameServer()
		{
			InteropHelp.TestIfPlatformSupported();
			if (NativeMethods.SteamClientGameServer() == IntPtr.Zero)
			{
				throw new InvalidOperationException("Steamworks is not initialized.");
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x0000F144 File Offset: 0x0000D344
		public static string PtrToStringUTF8(IntPtr nativeUtf8)
		{
			if (nativeUtf8 == IntPtr.Zero)
			{
				return string.Empty;
			}
			int num = 0;
			while (Marshal.ReadByte(nativeUtf8, num) != 0)
			{
				num++;
			}
			if (num == 0)
			{
				return string.Empty;
			}
			byte[] array = new byte[num];
			Marshal.Copy(nativeUtf8, array, 0, array.Length);
			return Encoding.UTF8.GetString(array);
		}

		// Token: 0x02000099 RID: 153
		public class SteamParamStringArray
		{
			// Token: 0x0600041C RID: 1052 RVA: 0x0000F1A8 File Offset: 0x0000D3A8
			public SteamParamStringArray(IList<string> strings)
			{
				if (strings == null)
				{
					this.m_pSteamParamStringArray = IntPtr.Zero;
					return;
				}
				this.m_Strings = new IntPtr[strings.Count];
				for (int i = 0; i < strings.Count; i++)
				{
					byte[] array = new byte[Encoding.UTF8.GetByteCount(strings[i]) + 1];
					Encoding.UTF8.GetBytes(strings[i], 0, strings[i].Length, array, 0);
					this.m_Strings[i] = Marshal.AllocHGlobal(array.Length);
					Marshal.Copy(array, 0, this.m_Strings[i], array.Length);
				}
				this.m_ptrStrings = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * this.m_Strings.Length);
				SteamParamStringArray_t steamParamStringArray_t = new SteamParamStringArray_t
				{
					m_ppStrings = this.m_ptrStrings,
					m_nNumStrings = this.m_Strings.Length
				};
				Marshal.Copy(this.m_Strings, 0, steamParamStringArray_t.m_ppStrings, this.m_Strings.Length);
				this.m_pSteamParamStringArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SteamParamStringArray_t)));
				Marshal.StructureToPtr(steamParamStringArray_t, this.m_pSteamParamStringArray, false);
			}

			// Token: 0x0600041D RID: 1053 RVA: 0x0000F2EC File Offset: 0x0000D4EC
			~SteamParamStringArray()
			{
				try
				{
					foreach (IntPtr hglobal in this.m_Strings)
					{
						Marshal.FreeHGlobal(hglobal);
					}
					if (this.m_ptrStrings != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(this.m_ptrStrings);
					}
					if (this.m_pSteamParamStringArray != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(this.m_pSteamParamStringArray);
					}
				}
                finally
                {

                }
			}

			// Token: 0x0600041E RID: 1054 RVA: 0x000040C2 File Offset: 0x000022C2
			public static implicit operator IntPtr(InteropHelp.SteamParamStringArray that)
			{
				return that.m_pSteamParamStringArray;
			}

			// Token: 0x0400032D RID: 813
			private IntPtr[] m_Strings;

			// Token: 0x0400032E RID: 814
			private IntPtr m_ptrStrings;

			// Token: 0x0400032F RID: 815
			private IntPtr m_pSteamParamStringArray;
		}
	}
}
