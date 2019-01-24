using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02000419 RID: 1049
public class UberDaemon : MonoBehaviour
{
	// Token: 0x06001DAE RID: 7598 RVA: 0x00013A8A File Offset: 0x00011C8A
	private void Awake()
	{
		UberDaemon.Instance = this;
	}

	// Token: 0x06001DAF RID: 7599 RVA: 0x00093428 File Offset: 0x00091628
	public string GetMagicHash(string authToken)
	{
		ProcessStartInfo processStartInfo = new ProcessStartInfo();
		string fileName = "bash";
		processStartInfo.Arguments = "uberdaemon.sh " + authToken;
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			fileName = "uberdaemon.exe";
			processStartInfo.Arguments = authToken;
		}
		processStartInfo.RedirectStandardError = true;
		processStartInfo.RedirectStandardOutput = true;
		processStartInfo.UseShellExecute = false;
		processStartInfo.FileName = fileName;
		processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;
		processStartInfo.CreateNoWindow = true;
		Process process = Process.Start(processStartInfo);
		return process.StandardOutput.ReadToEnd().Trim();
	}

	// Token: 0x040019E9 RID: 6633
	public static UberDaemon Instance;
}
