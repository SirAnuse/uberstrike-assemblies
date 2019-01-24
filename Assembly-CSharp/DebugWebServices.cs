using System;
using System.Collections.Generic;
using System.Text;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020000E7 RID: 231
public class DebugWebServices : IDebugPage
{
	// Token: 0x060007DB RID: 2011 RVA: 0x00006F79 File Offset: 0x00005179
	public DebugWebServices()
	{
		this._requestLog = new StringBuilder();
		Configuration.RequestLogger = (Action<string>)Delegate.Combine(Configuration.RequestLogger, new Action<string>(this.AddRequestLog));
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x00006FB7 File Offset: 0x000051B7
	private void AddRequestLog(string log)
	{
		this._requestLog.AppendLine(log);
		this._currentLog = this._requestLog.ToString();
	}

	// Token: 0x17000249 RID: 585
	// (get) Token: 0x060007DD RID: 2013 RVA: 0x00006FD7 File Offset: 0x000051D7
	public string Title
	{
		get
		{
			return "WS";
		}
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x000363A0 File Offset: 0x000345A0
	public void Draw()
	{
		this.scroller = GUILayout.BeginScrollView(this.scroller, new GUILayoutOption[0]);
		GUILayout.Label(string.Concat(new object[]
		{
			"IN (",
			WebServiceStatistics.TotalBytesIn,
			") -  OUT (",
			WebServiceStatistics.TotalBytesOut,
			")"
		}), new GUILayoutOption[0]);
		foreach (KeyValuePair<string, WebServiceStatistics.Statistics> keyValuePair in WebServiceStatistics.Data)
		{
			GUILayout.Label(keyValuePair.Key + ": " + keyValuePair.Value, new GUILayoutOption[0]);
		}
		GUILayout.TextArea(this._currentLog, new GUILayoutOption[0]);
		GUILayout.EndScrollView();
	}

	// Token: 0x040006BC RID: 1724
	private StringBuilder _requestLog;

	// Token: 0x040006BD RID: 1725
	private string _currentLog = string.Empty;

	// Token: 0x040006BE RID: 1726
	private Vector2 scroller;
}
