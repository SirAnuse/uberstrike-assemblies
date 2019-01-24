using System;
using UnityEngine;

// Token: 0x020001EE RID: 494
public class SceneGuiController : MonoBehaviour
{
	// Token: 0x17000359 RID: 857
	// (get) Token: 0x06000DEA RID: 3562 RVA: 0x0000A2FD File Offset: 0x000084FD
	public IngamePageType PageType
	{
		get
		{
			return this._pageType;
		}
	}

	// Token: 0x06000DEB RID: 3563 RVA: 0x0005FF58 File Offset: 0x0005E158
	private void Awake()
	{
		this._currentWidth = new FloatAnim(delegate(float oldValue, float newValue)
		{
			AutoMonoBehaviour<CameraRectController>.Instance.SetAbsoluteWidth((float)Screen.width - this._currentWidth.Value);
		}, 0f);
		this._guiPageTabs = new GUIContent[this._guiPages.Length];
		for (int i = 0; i < this._guiPages.Length; i++)
		{
			this._guiPageTabs[i] = new GUIContent(this._guiPages[i].Title);
		}
	}

	// Token: 0x06000DEC RID: 3564 RVA: 0x0000A305 File Offset: 0x00008505
	private void OnEnable()
	{
		if (this._guiPages.Length > 0)
		{
			this.SetCurrentPage(0);
			this._currentWidth.Value = this._width;
		}
		global::EventHandler.Global.AddListener<GlobalEvents.ScreenResolutionChanged>(new Action<GlobalEvents.ScreenResolutionChanged>(this.OnScreenResolutionChange));
	}

	// Token: 0x06000DED RID: 3565 RVA: 0x0005FFC8 File Offset: 0x0005E1C8
	private void OnDisable()
	{
		if (this._guiPages[this._currentGuiPageIndex] != null)
		{
			this._guiPages[this._currentGuiPageIndex].enabled = false;
		}
		this._currentWidth.Value = 0f;
		this._currentGuiPageIndex = -1;
		global::EventHandler.Global.RemoveListener<GlobalEvents.ScreenResolutionChanged>(new Action<GlobalEvents.ScreenResolutionChanged>(this.OnScreenResolutionChange));
	}

	// Token: 0x06000DEE RID: 3566 RVA: 0x00060030 File Offset: 0x0005E230
	private void OnGUI()
	{
		GUI.depth = 11;
		this._rect.x = (float)Screen.width - this._width;
		this._rect.y = (float)GlobalUIRibbon.Instance.Height();
		this._rect.width = this._width;
		this._rect.height = (float)Screen.height - this._rect.y;
		GUI.skin = BlueStonez.Skin;
		GUI.BeginGroup(this._rect, GUIContent.none, BlueStonez.window_standard_grey38);
		GUI.Label(new Rect(0f, 0f, this._rect.width, 56f), this._title, BlueStonez.tab_strip);
		GUI.changed = false;
		this._currentGuiPageIndex = UnityGUI.Toolbar(new Rect(0f, 34f, (float)(140 * this._guiPageTabs.Length), 22f), this._currentGuiPageIndex, this._guiPageTabs, this._guiPageTabs.Length, BlueStonez.tab_medium);
		if (GUI.changed)
		{
			this.SetCurrentPage(this._currentGuiPageIndex);
			return;
		}
		GUI.EndGroup();
		this._guiPages[this._currentGuiPageIndex].DrawGUI(new Rect(this._rect.x, this._rect.y + 57f, this._rect.width, this._rect.height - 56f));
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000DEF RID: 3567 RVA: 0x000601AC File Offset: 0x0005E3AC
	private void SetCurrentPage(int index)
	{
		for (int i = 0; i < this._guiPages.Length; i++)
		{
			this._guiPages[i].IsOnGUIEnabled = false;
			this._guiPages[i].enabled = false;
		}
		if (index >= 0 && index < this._guiPages.Length)
		{
			this._currentGuiPageIndex = index;
			this._guiPages[this._currentGuiPageIndex].enabled = true;
		}
	}

	// Token: 0x06000DF0 RID: 3568 RVA: 0x0000A343 File Offset: 0x00008543
	private void OnScreenResolutionChange(GlobalEvents.ScreenResolutionChanged ev)
	{
		AutoMonoBehaviour<CameraRectController>.Instance.SetAbsoluteWidth((float)Screen.width - this._currentWidth.Value);
	}

	// Token: 0x04000D04 RID: 3332
	[SerializeField]
	private string _title;

	// Token: 0x04000D05 RID: 3333
	[SerializeField]
	private PageGUI[] _guiPages;

	// Token: 0x04000D06 RID: 3334
	[SerializeField]
	private float _width;

	// Token: 0x04000D07 RID: 3335
	[SerializeField]
	private IngamePageType _pageType;

	// Token: 0x04000D08 RID: 3336
	private Rect _rect;

	// Token: 0x04000D09 RID: 3337
	private GUIContent[] _guiPageTabs;

	// Token: 0x04000D0A RID: 3338
	private int _currentGuiPageIndex;

	// Token: 0x04000D0B RID: 3339
	private FloatAnim _currentWidth;
}
