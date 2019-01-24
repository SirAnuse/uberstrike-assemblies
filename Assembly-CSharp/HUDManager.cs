using System;
using UnityEngine;

// Token: 0x0200030E RID: 782
public class HUDManager : MonoBehaviour
{
	// Token: 0x060015F3 RID: 5619 RVA: 0x0000EC49 File Offset: 0x0000CE49
	private void Start()
	{
		GameData.Instance.GameState.AddEventAndFire(delegate(GameStateId el)
		{
			bool flag = el == GameStateId.MatchRunning;
			bool active = el == GameStateId.PregameLoadout;
			bool flag2 = el == GameStateId.WaitingForPlayers;
			bool active2 = el == GameStateId.EndOfMatch;
			bool flag3 = el == GameStateId.PrepareNextRound;
			this.TrySetActive(this.pregameLoadoutPage, active);
			this.TrySetActive(this.matchRunningPage, flag || flag2 || flag3);
			this.TrySetActive(this.endOfMatchPage, active2);
			GameData.Instance.PlayerState.Fire();
		}, this);
		global::EventHandler.Global.AddListener<GlobalEvents.CameraWidthChanged>(new Action<GlobalEvents.CameraWidthChanged>(this.OnCameraWidthChanged));
		this.OnCameraWidthChanged(null);
	}

	// Token: 0x060015F4 RID: 5620 RVA: 0x0000EC84 File Offset: 0x0000CE84
	private void OnDestroy()
	{
		global::EventHandler.Global.RemoveListener<GlobalEvents.CameraWidthChanged>(new Action<GlobalEvents.CameraWidthChanged>(this.OnCameraWidthChanged));
	}

	// Token: 0x060015F5 RID: 5621 RVA: 0x0000EC9C File Offset: 0x0000CE9C
	private void OnCameraWidthChanged(GlobalEvents.CameraWidthChanged obj)
	{
		UICamera.eventHandler.cachedCamera.rect = new Rect(0f, 0f, AutoMonoBehaviour<CameraRectController>.Instance.NormalizedWidth, 1f);
	}

	// Token: 0x060015F6 RID: 5622 RVA: 0x0000ECCB File Offset: 0x0000CECB
	private void TrySetActive(MonoBehaviour page, bool active)
	{
		if (page != null)
		{
			page.gameObject.SetActive(active);
		}
	}

	// Token: 0x040014B8 RID: 5304
	[SerializeField]
	private PageControllerBase pregameLoadoutPage;

	// Token: 0x040014B9 RID: 5305
	[SerializeField]
	private PageControllerBase matchRunningPage;

	// Token: 0x040014BA RID: 5306
	[SerializeField]
	private PageControllerBase endOfMatchPage;
}
