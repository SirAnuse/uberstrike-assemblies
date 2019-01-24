using System;
using System.Diagnostics;
using System.IO;

namespace Steamworks
{
	// Token: 0x0200009C RID: 156
	public class DllCheck
	{
		// Token: 0x0600042B RID: 1067 RVA: 0x0000F5B4 File Offset: 0x0000D7B4
		public static bool Test()
		{
			return DllCheck.CheckSteamAPIDLL();
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0000F5CC File Offset: 0x0000D7CC
		private static bool CheckSteamAPIDLL()
		{
			string currentDirectory = Directory.GetCurrentDirectory();
			string text;
			int num;
			if (IntPtr.Size == 4)
			{
				text = Path.Combine(currentDirectory, "steam_api.dll");
				num = 187584;
			}
			else
			{
				text = Path.Combine(currentDirectory, "steam_api64.dll");
				num = 208296;
			}
			if (File.Exists(text))
			{
				FileInfo fileInfo = new FileInfo(text);
				if (fileInfo.Length != (long)num)
				{
					return false;
				}
				if (FileVersionInfo.GetVersionInfo(text).FileVersion != "02.59.51.43")
				{
					return false;
				}
			}
			return true;
		}
	}
}
