using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class Heartbeat : MonoBehaviour
{
	// Token: 0x06000016 RID: 22
	[DllImport("uberheartbeat", CallingConvention = CallingConvention.Cdecl)]
	public static extern void I();

	// Token: 0x06000017 RID: 23
	[DllImport("uberheartbeat", CallingConvention = CallingConvention.Cdecl)]
	public static extern int S();

	// Token: 0x06000018 RID: 24
	[DllImport("uberheartbeat", CallingConvention = CallingConvention.Cdecl)]
	public static extern int D();

	// Token: 0x06000019 RID: 25
	[DllImport("uberheartbeat", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	public static extern IntPtr C(StringBuilder input);

	// Token: 0x0600001A RID: 26 RVA: 0x00015F08 File Offset: 0x00014108
	private IEnumerator Start()
	{
		this.m_MonoInitialized = false;
		Heartbeat.I();
		yield return new WaitForSeconds(1f);
		int monoRet = Heartbeat.S();
		this.m_MonoInitialized = (monoRet == 0);
		yield break;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000021E7 File Offset: 0x000003E7
	private void Awake()
	{
		Heartbeat.Instance = this;
	}

	// Token: 0x0600001C RID: 28 RVA: 0x000021EF File Offset: 0x000003EF
	private void OnApplicationQuit()
	{
		if (this.m_MonoInitialized)
		{
			Heartbeat.D();
		}
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00015F24 File Offset: 0x00014124
	public string CheckHeartbeat(string input)
	{
		if (this.m_MonoInitialized)
		{
			StringBuilder input2 = new StringBuilder(input);
			IntPtr ptr = Heartbeat.C(input2);
			return Marshal.PtrToStringAnsi(ptr);
		}
		Debug.Log("Plugin failed to init somewhere!");
		return "Failed to init";
	}

	// Token: 0x0400002E RID: 46
	public static Heartbeat Instance;

	// Token: 0x0400002F RID: 47
	private static string m_AuthToken;

	// Token: 0x04000030 RID: 48
	private static string m_HeartbeatHash;

	// Token: 0x04000031 RID: 49
	private bool m_MonoInitialized;

	// Token: 0x04000032 RID: 50
	private static List<string> m_Keys;
}
