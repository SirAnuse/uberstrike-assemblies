using System;
using System.Text;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020000DD RID: 221
public class DebugLogMessages : IDebugPage
{
	// Token: 0x1700023F RID: 575
	// (get) Token: 0x060007BA RID: 1978 RVA: 0x00006EDD File Offset: 0x000050DD
	public string Title
	{
		get
		{
			return "Logs";
		}
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x00006EE4 File Offset: 0x000050E4
	public void Draw()
	{
		GUILayout.TextArea(DebugLogMessages.Console.DebugOut, new GUILayoutOption[0]);
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x00006EFC File Offset: 0x000050FC
	public static void Log(int type, string msg)
	{
		DebugLogMessages.Console.Log(type, msg);
	}

	// Token: 0x040006AB RID: 1707
	public static readonly DebugLogMessages.ConsoleDebug Console = new DebugLogMessages.ConsoleDebug();

	// Token: 0x020000DE RID: 222
	public class ConsoleDebug
	{
		// Token: 0x060007BE RID: 1982 RVA: 0x00035448 File Offset: 0x00033648
		public void Log(int level, string s)
		{
			this._queue.Enqueue(s);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string value in this._queue)
			{
				stringBuilder.AppendLine(value);
			}
			this._debugOut = stringBuilder.ToString();
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060007BF RID: 1983 RVA: 0x00006F2D File Offset: 0x0000512D
		public string DebugOut
		{
			get
			{
				return this._debugOut;
			}
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x000354C0 File Offset: 0x000336C0
		public string ToHTML()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<h3>DEBUG LOG</h3>");
			foreach (string str in this._queue)
			{
				stringBuilder.AppendLine(str + "<br/>");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0003553C File Offset: 0x0003373C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string value in this._queue)
			{
				stringBuilder.AppendLine(value);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040006AC RID: 1708
		private LimitedQueue<string> _queue = new LimitedQueue<string>(300);

		// Token: 0x040006AD RID: 1709
		private string _debugOut = string.Empty;
	}
}
