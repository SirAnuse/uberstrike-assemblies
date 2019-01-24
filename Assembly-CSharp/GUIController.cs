using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000342 RID: 834
internal class GUIController : MonoBehaviour
{
	// Token: 0x0600172E RID: 5934 RVA: 0x0007F78C File Offset: 0x0007D98C
	private IEnumerator Start()
	{
		while (!Singleton<AuthenticationManager>.Instance.IsAuthComplete)
		{
			yield return new WaitForEndOfFrame();
		}
		this.home.gameObject.SetActive(true);
		GameData.Instance.MainMenu.AddEventAndFire(new Action<MainMenuState>(this.OnMenuChanged), this);
		global::EventHandler.Global.AddListener<GlobalEvents.CameraWidthChanged>(new Action<GlobalEvents.CameraWidthChanged>(this.OnCameraWidthChanged));
		this.OnCameraWidthChanged(null);
		yield break;
	}

	// Token: 0x0600172F RID: 5935 RVA: 0x0000FA03 File Offset: 0x0000DC03
	private void OnDestroy()
	{
		global::EventHandler.Global.RemoveListener<GlobalEvents.CameraWidthChanged>(new Action<GlobalEvents.CameraWidthChanged>(this.OnCameraWidthChanged));
	}

	// Token: 0x06001730 RID: 5936 RVA: 0x0000EC9C File Offset: 0x0000CE9C
	private void OnCameraWidthChanged(GlobalEvents.CameraWidthChanged obj)
	{
		UICamera.eventHandler.cachedCamera.rect = new Rect(0f, 0f, AutoMonoBehaviour<CameraRectController>.Instance.NormalizedWidth, 1f);
	}

	// Token: 0x06001731 RID: 5937 RVA: 0x0000FA1B File Offset: 0x0000DC1B
	private void OnMenuChanged(MainMenuState state)
	{
		this.SetPage(this.home, state == MainMenuState.Home);
		if (this.xpbar != null)
		{
			this.xpbar.SetActive(state != MainMenuState.Logout);
		}
	}

	// Token: 0x06001732 RID: 5938 RVA: 0x0000FA50 File Offset: 0x0000DC50
	private void SetPage(GUIPageBase page, bool enabled)
	{
		if (page == null)
		{
			return;
		}
		page.gameObject.SetActive(enabled);
		if (enabled)
		{
			page.BringIn();
		}
	}

	// Token: 0x0400161E RID: 5662
	[SerializeField]
	private GUIPageBase home;

	// Token: 0x0400161F RID: 5663
	[SerializeField]
	private GameObject xpbar;
}
