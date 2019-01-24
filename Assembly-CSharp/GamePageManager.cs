using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002AF RID: 687
public class GamePageManager : MonoBehaviour
{
	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06001303 RID: 4867 RVA: 0x0000CFE3 File Offset: 0x0000B1E3
	// (set) Token: 0x06001304 RID: 4868 RVA: 0x0000CFEA File Offset: 0x0000B1EA
	public static GamePageManager Instance { get; private set; }

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x06001305 RID: 4869 RVA: 0x0000CFF2 File Offset: 0x0000B1F2
	public static bool Exists
	{
		get
		{
			return GamePageManager.Instance != null;
		}
	}

	// Token: 0x06001306 RID: 4870 RVA: 0x0000CFFF File Offset: 0x0000B1FF
	private void Awake()
	{
		GamePageManager.Instance = this;
		GamePageManager._pageByPageType = new Dictionary<IngamePageType, SceneGuiController>();
	}

	// Token: 0x06001307 RID: 4871 RVA: 0x0006FF54 File Offset: 0x0006E154
	private void Start()
	{
		foreach (SceneGuiController sceneGuiController in base.GetComponentsInChildren<SceneGuiController>(true))
		{
			GamePageManager._pageByPageType[sceneGuiController.PageType] = sceneGuiController;
		}
	}

	// Token: 0x06001308 RID: 4872 RVA: 0x0000D011 File Offset: 0x0000B211
	public static bool IsCurrentPage(IngamePageType type)
	{
		return GamePageManager._currentPageType == type;
	}

	// Token: 0x06001309 RID: 4873 RVA: 0x0006FF94 File Offset: 0x0006E194
	public SceneGuiController GetCurrentPage()
	{
		SceneGuiController result;
		GamePageManager._pageByPageType.TryGetValue(GamePageManager._currentPageType, out result);
		return result;
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x0600130A RID: 4874 RVA: 0x0000D01B File Offset: 0x0000B21B
	public static bool HasPage
	{
		get
		{
			return GamePageManager._currentPageType != IngamePageType.None;
		}
	}

	// Token: 0x0600130B RID: 4875 RVA: 0x0006FFB4 File Offset: 0x0006E1B4
	public void UnloadCurrentPage()
	{
		SceneGuiController currentPage = this.GetCurrentPage();
		if (currentPage)
		{
			currentPage.gameObject.SetActive(false);
			GamePageManager._currentPageType = IngamePageType.None;
		}
		global::EventHandler.Global.Fire(new GlobalEvents.GamePageChanged());
	}

	// Token: 0x0600130C RID: 4876 RVA: 0x0006FFF4 File Offset: 0x0006E1F4
	public void LoadPage(IngamePageType pageType)
	{
		if (pageType == GamePageManager._currentPageType)
		{
			return;
		}
		SceneGuiController sceneGuiController = null;
		if (GamePageManager._pageByPageType.TryGetValue(pageType, out sceneGuiController))
		{
			SceneGuiController sceneGuiController2 = null;
			GamePageManager._pageByPageType.TryGetValue(GamePageManager._currentPageType, out sceneGuiController2);
			if (sceneGuiController2)
			{
				sceneGuiController2.gameObject.SetActive(false);
			}
			GamePageManager._currentPageType = pageType;
			sceneGuiController.gameObject.SetActive(true);
			global::EventHandler.Global.Fire(new GlobalEvents.GamePageChanged());
		}
	}

	// Token: 0x04001307 RID: 4871
	private static IDictionary<IngamePageType, SceneGuiController> _pageByPageType;

	// Token: 0x04001308 RID: 4872
	private static IngamePageType _currentPageType;
}
