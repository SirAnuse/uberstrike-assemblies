using System;
using UnityEngine;

// Token: 0x02000157 RID: 343
internal class SearchBarGUI
{
	// Token: 0x0600091E RID: 2334 RVA: 0x00007AE3 File Offset: 0x00005CE3
	public SearchBarGUI(string name)
	{
		this._guiName = name;
		this.FilterText = string.Empty;
	}

	// Token: 0x1700028E RID: 654
	// (get) Token: 0x0600091F RID: 2335 RVA: 0x00007AFD File Offset: 0x00005CFD
	// (set) Token: 0x06000920 RID: 2336 RVA: 0x00007B05 File Offset: 0x00005D05
	public string FilterText { get; private set; }

	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06000921 RID: 2337 RVA: 0x00007B0E File Offset: 0x00005D0E
	public bool IsSearching
	{
		get
		{
			return !string.IsNullOrEmpty(this.FilterText);
		}
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x0003A28C File Offset: 0x0003848C
	public void Draw(Rect rect)
	{
		int num = 20;
		if (ApplicationDataManager.IsMobile)
		{
			num = 30;
		}
		if (!TabScreenPanelGUI.Enabled)
		{
			GUI.SetNextControlName(this._guiName);
			this.FilterText = GUI.TextField(new Rect(rect.x, rect.y, (!this.IsSearching) ? rect.width : (rect.width - (float)num - 2f), rect.height), this.FilterText, BlueStonez.textField);
		}
		if (string.IsNullOrEmpty(this.FilterText) && GUI.GetNameOfFocusedControl() != this._guiName)
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(rect, " " + LocalizedStrings.Search, BlueStonez.label_interparkbold_11pt_left);
			GUI.color = Color.white;
		}
		if (this.IsSearching && GUITools.Button(new Rect(rect.x + rect.width - (float)num, 8f, (float)num, (float)num), new GUIContent("x"), BlueStonez.buttondark_medium))
		{
			this.ClearFilter();
			GUIUtility.hotControl = 1;
		}
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x00007B1E File Offset: 0x00005D1E
	public void ClearFilter()
	{
		this.FilterText = string.Empty;
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x00007B2B File Offset: 0x00005D2B
	public bool CheckIfPassFilter(string text)
	{
		return !this.IsSearching || text.ToLower().Contains(this.FilterText.ToLower());
	}

	// Token: 0x0400095D RID: 2397
	private string _guiName;
}
