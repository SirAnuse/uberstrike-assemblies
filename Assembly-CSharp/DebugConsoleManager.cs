using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x020000D5 RID: 213
public class DebugConsoleManager : MonoBehaviour
{
	// Token: 0x17000237 RID: 567
	// (get) Token: 0x0600079A RID: 1946 RVA: 0x00006DE1 File Offset: 0x00004FE1
	// (set) Token: 0x0600079B RID: 1947 RVA: 0x00006DE8 File Offset: 0x00004FE8
	public static DebugConsoleManager Instance { get; private set; }

	// Token: 0x17000238 RID: 568
	// (get) Token: 0x0600079C RID: 1948 RVA: 0x00006DF0 File Offset: 0x00004FF0
	// (set) Token: 0x0600079D RID: 1949 RVA: 0x00006DF8 File Offset: 0x00004FF8
	public bool IsDebugConsoleEnabled { get; set; }

	// Token: 0x0600079E RID: 1950 RVA: 0x00006E01 File Offset: 0x00005001
	private void Awake()
	{
		DebugConsoleManager.Instance = this;
		if (Application.isEditor)
		{
			this.UpdatePages(MemberAccessLevel.Admin);
		}
		else
		{
			global::EventHandler.Global.AddListener<GlobalEvents.Login>(delegate(GlobalEvents.Login ev)
			{
				this.UpdatePages(ev.AccessLevel);
			});
		}
	}

	// Token: 0x0600079F RID: 1951 RVA: 0x00006E36 File Offset: 0x00005036
	private void Update()
	{
		if (KeyInput.AltPressed && KeyInput.CtrlPressed && KeyInput.GetKeyDown(KeyCode.D))
		{
			this.IsDebugConsoleEnabled = !this.IsDebugConsoleEnabled;
		}
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x00034678 File Offset: 0x00032878
	private void DrawDebugMenuGrid()
	{
		int num = GUILayout.SelectionGrid(DebugConsoleManager._currentPageSelectedIdx, DebugConsoleManager._debugPageDescriptors, DebugConsoleManager._debugPageDescriptors.Length, BlueStonez.tab_medium, new GUILayoutOption[0]);
		if (num != DebugConsoleManager._currentPageSelectedIdx)
		{
			num = Mathf.Clamp(num, 0, DebugConsoleManager._debugPages.Length - 1);
			DebugConsoleManager._currentPageSelectedIdx = num;
			DebugConsoleManager._currentPageSelected = DebugConsoleManager._debugPages[num];
		}
	}

	// Token: 0x060007A1 RID: 1953 RVA: 0x00006E67 File Offset: 0x00005067
	private void DrawDebugPage()
	{
		this._scrollDebug = GUILayout.BeginScrollView(this._scrollDebug, new GUILayoutOption[0]);
		if (DebugConsoleManager._currentPageSelected != null)
		{
			DebugConsoleManager._currentPageSelected.Draw();
		}
		GUILayout.EndScrollView();
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x000346D8 File Offset: 0x000328D8
	private void UpdatePages(MemberAccessLevel level)
	{
		if (level > MemberAccessLevel.Default)
		{
			DebugConsoleManager._debugPages = new IDebugPage[]
			{
				new DebugLogMessages(),
				new DebugApplication(),
				new DebugGameState(),
				new DebugServerState()
			};
		}
		else if (level >= MemberAccessLevel.SeniorModerator)
		{
			DebugConsoleManager._debugPages = new IDebugPage[]
			{
				new DebugLogMessages(),
				new DebugApplication(),
				new DebugGameState(),
				new DebugServerState(),
				new DebugGames()
			};
		}
		else
		{
			DebugConsoleManager._debugPages = new IDebugPage[]
			{
				new DebugLogMessages()
			};
		}
		DebugConsoleManager._debugPageDescriptors = new string[DebugConsoleManager._debugPages.Length];
		for (int i = 0; i < DebugConsoleManager._debugPages.Length; i++)
		{
			DebugConsoleManager._debugPageDescriptors[i] = DebugConsoleManager._debugPages[i].Title;
		}
		DebugConsoleManager._currentPageSelectedIdx = 0;
		DebugConsoleManager._currentPageSelected = DebugConsoleManager._debugPages[0];
	}

	// Token: 0x040006A0 RID: 1696
	private Vector2 _scrollDebug;

	// Token: 0x040006A1 RID: 1697
	private List<string> _exceptions = new List<string>(10);

	// Token: 0x040006A2 RID: 1698
	private static IDebugPage[] _debugPages = new IDebugPage[0];

	// Token: 0x040006A3 RID: 1699
	private static string[] _debugPageDescriptors = new string[0];

	// Token: 0x040006A4 RID: 1700
	private static int _currentPageSelectedIdx = 0;

	// Token: 0x040006A5 RID: 1701
	private static IDebugPage _currentPageSelected;
}
