using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class MenuPageManager : MonoBehaviour
{
	// Token: 0x170004D2 RID: 1234
	// (get) Token: 0x0600145B RID: 5211 RVA: 0x0000DABE File Offset: 0x0000BCBE
	// (set) Token: 0x0600145C RID: 5212 RVA: 0x0000DAC5 File Offset: 0x0000BCC5
	public static MenuPageManager Instance { get; private set; }

	// Token: 0x170004D3 RID: 1235
	// (get) Token: 0x0600145D RID: 5213 RVA: 0x0000DACD File Offset: 0x0000BCCD
	// (set) Token: 0x0600145E RID: 5214 RVA: 0x0000DAD5 File Offset: 0x0000BCD5
	public float LeftAreaGUIOffset { get; set; }

	// Token: 0x0600145F RID: 5215 RVA: 0x0000DADE File Offset: 0x0000BCDE
	private void Awake()
	{
		this._pageByPageType = new Dictionary<PageType, PageScene>();
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x0000DAEB File Offset: 0x0000BCEB
	private void OnEnable()
	{
		MenuPageManager.Instance = this;
		global::EventHandler.Global.AddListener<GlobalEvents.ScreenResolutionChanged>(new Action<GlobalEvents.ScreenResolutionChanged>(this.OnScreenResolutionEvent));
	}

	// Token: 0x06001461 RID: 5217 RVA: 0x0000DB09 File Offset: 0x0000BD09
	private void OnDisable()
	{
		MenuPageManager.Instance = null;
		global::EventHandler.Global.RemoveListener<GlobalEvents.ScreenResolutionChanged>(new Action<GlobalEvents.ScreenResolutionChanged>(this.OnScreenResolutionEvent));
	}

	// Token: 0x06001462 RID: 5218 RVA: 0x00075180 File Offset: 0x00073380
	private void Start()
	{
		foreach (PageScene pageScene in base.GetComponentsInChildren<PageScene>(true))
		{
			this._pageByPageType.Add(pageScene.PageType, pageScene);
		}
		if (GlobalUIRibbon.Instance)
		{
			GlobalUIRibbon.Instance.Show();
		}
	}

	// Token: 0x06001463 RID: 5219 RVA: 0x000751D8 File Offset: 0x000733D8
	private void OnScreenResolutionEvent(GlobalEvents.ScreenResolutionChanged ev)
	{
		int pagePanelWidth = this.GetPagePanelWidth(MenuPageManager._currentPageType);
		AutoMonoBehaviour<CameraRectController>.Instance.SetAbsoluteWidth((float)(Screen.width - pagePanelWidth));
	}

	// Token: 0x06001464 RID: 5220 RVA: 0x00075204 File Offset: 0x00073404
	private IEnumerator StartPageTransition(PageScene newPage, float time)
	{
		newPage.Load();
		if (newPage.HaveMouseOrbitCamera)
		{
			MouseOrbit.Instance.enabled = true;
			Vector3 offset = MouseOrbit.Instance.OrbitOffset;
			Vector3 config = MouseOrbit.Instance.OrbitConfig;
			float t = 0f;
			while (t < time && newPage.PageType == MenuPageManager._currentPageType)
			{
				t += Time.deltaTime;
				MouseOrbit.Instance.OrbitConfig = Vector3.Lerp(config, newPage.MouseOrbitConfig, Mathfx.Ease(t / time, this._transitionType));
				MouseOrbit.Instance.OrbitOffset = Vector3.Lerp(offset, newPage.MouseOrbitPivot, Mathfx.Ease(t / time, this._transitionType));
				MouseOrbit.Instance.yPanningOffset = Mathf.Lerp(MouseOrbit.Instance.yPanningOffset, 0f, Mathfx.Ease(t / time, this._transitionType));
				yield return new WaitForEndOfFrame();
			}
			if (newPage.PageType == MenuPageManager._currentPageType)
			{
				MouseOrbit.Instance.OrbitOffset = newPage.MouseOrbitPivot;
				MouseOrbit.Instance.OrbitConfig = newPage.MouseOrbitConfig;
			}
		}
		else
		{
			MouseOrbit.Instance.enabled = false;
		}
		yield break;
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x0007523C File Offset: 0x0007343C
	private int GetPagePanelWidth(PageType type)
	{
		PageScene pageScene;
		if (this._pageByPageType.TryGetValue(type, out pageScene))
		{
			return pageScene.GuiWidth;
		}
		return 0;
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x00075264 File Offset: 0x00073464
	private IEnumerator AnimateCameraPixelRect(PageType type, float time, bool immediate)
	{
		if (immediate)
		{
			AutoMonoBehaviour<CameraRectController>.Instance.SetAbsoluteWidth((float)(Screen.width - this.GetPagePanelWidth(MenuPageManager._currentPageType)));
			yield return new WaitForEndOfFrame();
		}
		else
		{
			float t = time * 0.1f;
			float oldCameraWidth = AutoMonoBehaviour<CameraRectController>.Instance.PixelWidth;
			int panelWidth = this.GetPagePanelWidth(type);
			RenderSettingsController.Instance.DisableImageEffects();
			while (t < time && type == MenuPageManager._currentPageType)
			{
				AutoMonoBehaviour<CameraRectController>.Instance.SetAbsoluteWidth(Mathf.Lerp(oldCameraWidth, (float)(Screen.width - panelWidth), t / time * (t / time)));
				yield return new WaitForEndOfFrame();
				t += Time.deltaTime;
			}
			AutoMonoBehaviour<CameraRectController>.Instance.SetAbsoluteWidth((float)(Screen.width - this.GetPagePanelWidth(MenuPageManager._currentPageType)));
			RenderSettingsController.Instance.EnableImageEffects();
		}
		yield break;
	}

	// Token: 0x06001467 RID: 5223 RVA: 0x0000DB27 File Offset: 0x0000BD27
	public bool IsCurrentPage(PageType type)
	{
		return MenuPageManager._currentPageType == type;
	}

	// Token: 0x06001468 RID: 5224 RVA: 0x0000DB31 File Offset: 0x0000BD31
	public PageType GetCurrentPage()
	{
		return MenuPageManager._currentPageType;
	}

	// Token: 0x06001469 RID: 5225 RVA: 0x000752AC File Offset: 0x000734AC
	public void UnloadCurrentPage()
	{
		PageScene pageScene;
		if (this._pageByPageType.TryGetValue(MenuPageManager._currentPageType, out pageScene) && pageScene)
		{
			pageScene.Unload();
			MenuPageManager._currentPageType = PageType.None;
			MouseOrbit.Instance.enabled = false;
			AutoMonoBehaviour<CameraRectController>.Instance.SetAbsoluteWidth((float)Screen.width);
		}
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x00075304 File Offset: 0x00073504
	public void LoadPage(PageType pageType, bool forceReload = false)
	{
		this.LeftAreaGUIOffset = 0f;
		if (PanelManager.Instance)
		{
			PanelManager.Instance.CloseAllPanels(PanelType.None);
		}
		if (pageType == PageType.Home)
		{
			GameData.Instance.MainMenu.Value = MainMenuState.Home;
		}
		if (pageType == MenuPageManager._currentPageType && !forceReload)
		{
			return;
		}
		PageScene pageScene = null;
		if (this._pageByPageType.TryGetValue(pageType, out pageScene))
		{
			PageScene pageScene2 = null;
			this._pageByPageType.TryGetValue(MenuPageManager._currentPageType, out pageScene2);
			if (pageScene2 && !forceReload)
			{
				pageScene2.Unload();
			}
			bool flag = (MenuPageManager._currentPageType == PageType.Home && pageType == PageType.Shop) || (MenuPageManager._currentPageType == PageType.Home && pageType == PageType.Stats);
			MenuPageManager._currentPageType = pageType;
			base.StartCoroutine(this.AnimateCameraPixelRect(pageScene.PageType, 0.25f, !flag));
			MouseOrbit.Instance.enabled = false;
			MenuPageManager.Instance.StartCoroutine(this.StartPageTransition(pageScene, 1f));
		}
	}

	// Token: 0x0600146B RID: 5227 RVA: 0x0000DB38 File Offset: 0x0000BD38
	private bool IsScreenResolutionChanged()
	{
		if (Screen.width != this._lastScreenWidth || Screen.height != this._lastScreenHeight)
		{
			this._lastScreenWidth = Screen.width;
			this._lastScreenHeight = Screen.height;
			return true;
		}
		return false;
	}

	// Token: 0x0400138C RID: 5004
	private IDictionary<PageType, PageScene> _pageByPageType;

	// Token: 0x0400138D RID: 5005
	private static PageType _currentPageType;

	// Token: 0x0400138E RID: 5006
	private EaseType _transitionType = EaseType.InOut;

	// Token: 0x0400138F RID: 5007
	private int _lastScreenWidth;

	// Token: 0x04001390 RID: 5008
	private int _lastScreenHeight;
}
