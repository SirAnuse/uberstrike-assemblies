using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200031D RID: 797
public class PageControllerMatch : PageControllerBase
{
	// Token: 0x06001649 RID: 5705 RVA: 0x0007C13C File Offset: 0x0007A33C
	private void Start()
	{
		GameData.Instance.PlayerState.AddEventAndFire(delegate(PlayerStateId el)
		{
			PageControllerMatch.HandleSharedViews(el, this.healthBar, this.ammoBar, this.armorBar, this.hudReticleController, this.hudStatusPanel, this.itemPickup);
			bool flag = el == PlayerStateId.Playing;
			bool flag2 = el == PlayerStateId.Spectating;
			bool flag3 = el == PlayerStateId.Killed;
			bool flag4 = el == PlayerStateId.Paused;
			bool flag5 = el == PlayerStateId.PrepareForMatch;
			this.desktopChat.SetActive(flag || flag4 || flag5 || flag3 || flag2);
			this.eventStream.gameObject.SetActive(flag || flag4 || flag5 || flag3 || flag2);
			this.weaponScroller.SetActive(flag || flag5);
			this.quickItems.SetActive(flag || flag5);
			if (this.eventStream.gameObject.activeInHierarchy)
			{
				this.eventStream.DoAnimateDown(flag4 || flag3);
			}
			this.fps.SetActive(true);
		}, this);
		GameData.Instance.OnHUDStreamClear.AddEvent(delegate()
		{
			Singleton<DamageFeedbackHud>.Instance.ClearAll();
		}, this);
	}

	// Token: 0x0600164A RID: 5706 RVA: 0x0007C194 File Offset: 0x0007A394
	public static void HandleSharedViews(PlayerStateId state, GameObject healthBar, GameObject ammoBar, GameObject armorBar, GameObject hudReticleController, GameObject hudStatusPanel, GameObject itemPickup)
	{
		bool flag = state == PlayerStateId.Playing;
		bool flag2 = state == PlayerStateId.Spectating;
		bool flag3 = state == PlayerStateId.Killed;
		bool flag4 = state == PlayerStateId.Paused;
		bool flag5 = state == PlayerStateId.PrepareForMatch;
		bool flag6 = GameState.Current.GameMode == GameModeType.None;
		bool flag7 = GameData.Instance.GameState.Value == GameStateId.WaitingForPlayers;
		flag2 |= (flag4 && (!GameState.Current.Players.ContainsKey(PlayerDataManager.Cmid) || GameState.Current.PlayerData.IsSpectator));
		healthBar.SetActive((flag || flag4 || flag5) && !flag2);
		armorBar.SetActive((flag || flag4 || flag5) && !flag2);
		ammoBar.SetActive((flag || flag5) && !flag2);
		hudReticleController.SetActive(flag || flag5);
		hudStatusPanel.SetActive((flag || flag4 || flag5 || flag2 || flag3) && !flag6 && !flag7);
		if (hudStatusPanel.activeInHierarchy)
		{
			hudStatusPanel.GetComponent<HUDStatusPanel>().IsOnPaused(flag4 || flag3 || flag2);
		}
		itemPickup.SetActive(flag);
	}

	// Token: 0x0600164B RID: 5707 RVA: 0x0000F07D File Offset: 0x0000D27D
	private void Update()
	{
		Singleton<DamageFeedbackHud>.Instance.Update();
	}

	// Token: 0x0600164C RID: 5708 RVA: 0x0000F089 File Offset: 0x0000D289
	private void OnGUI()
	{
		Singleton<DamageFeedbackHud>.Instance.Draw();
	}

	// Token: 0x04001514 RID: 5396
	[SerializeField]
	private GameObject healthBar;

	// Token: 0x04001515 RID: 5397
	[SerializeField]
	private GameObject ammoBar;

	// Token: 0x04001516 RID: 5398
	[SerializeField]
	private GameObject armorBar;

	// Token: 0x04001517 RID: 5399
	[SerializeField]
	private GameObject quickItems;

	// Token: 0x04001518 RID: 5400
	[SerializeField]
	private GameObject hudReticleController;

	// Token: 0x04001519 RID: 5401
	[SerializeField]
	private GameObject hudStatusPanel;

	// Token: 0x0400151A RID: 5402
	[SerializeField]
	private GameObject desktopChat;

	// Token: 0x0400151B RID: 5403
	[SerializeField]
	private HUDDesktopEventStream eventStream;

	// Token: 0x0400151C RID: 5404
	[SerializeField]
	private GameObject itemPickup;

	// Token: 0x0400151D RID: 5405
	[SerializeField]
	private GameObject fps;

	// Token: 0x0400151E RID: 5406
	[SerializeField]
	private GameObject weaponScroller;
}
