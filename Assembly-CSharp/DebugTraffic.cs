using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class DebugTraffic : IDebugPage
{
	// Token: 0x17000248 RID: 584
	// (get) Token: 0x060007D8 RID: 2008 RVA: 0x00006F72 File Offset: 0x00005172
	public string Title
	{
		get
		{
			return "Traffic";
		}
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x0003628C File Offset: 0x0003448C
	public void Draw()
	{
		if (GUILayout.Button("Clear", new GUILayoutOption[0]))
		{
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Monitor.AllEvents.Clear();
			Singleton<GameStateController>.Instance.Client.Monitor.AllEvents.Clear();
		}
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.TextArea(this.Debug(AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Monitor.AllEvents), new GUILayoutOption[0]);
		GUILayout.TextArea(this.Debug(Singleton<GameStateController>.Instance.Client.Monitor.AllEvents), new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x0003633C File Offset: 0x0003453C
	private string Debug(LinkedList<string> list)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string value in list)
		{
			stringBuilder.AppendLine(value);
		}
		return stringBuilder.ToString();
	}
}
