using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000E2 RID: 226
public class DebugProjectiles : IDebugPage
{
	// Token: 0x17000244 RID: 580
	// (get) Token: 0x060007CC RID: 1996 RVA: 0x00006F56 File Offset: 0x00005156
	public string Title
	{
		get
		{
			return "Projectiles";
		}
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x00035A14 File Offset: 0x00033C14
	public void Draw()
	{
		this.scroll1 = GUILayout.BeginScrollView(this.scroll1, new GUILayoutOption[0]);
		foreach (KeyValuePair<int, IProjectile> keyValuePair in Singleton<ProjectileManager>.Instance.AllProjectiles)
		{
			GUILayout.Label((keyValuePair.Key + " - " + keyValuePair.Value == null) ? (ProjectileManager.PrintID(keyValuePair.Key) + " (exploded zombie)") : ProjectileManager.PrintID(keyValuePair.Key), new GUILayoutOption[0]);
		}
		GUILayout.EndScrollView();
		GUILayout.Space(30f);
		this.scroll2 = GUILayout.BeginScrollView(this.scroll2, new GUILayoutOption[0]);
		foreach (int id in Singleton<ProjectileManager>.Instance.LimitedProjectiles)
		{
			GUILayout.Label("Limited " + ProjectileManager.PrintID(id), new GUILayoutOption[0]);
		}
		GUILayout.EndScrollView();
	}

	// Token: 0x040006B3 RID: 1715
	private Vector2 scroll1;

	// Token: 0x040006B4 RID: 1716
	private Vector2 scroll2;
}
