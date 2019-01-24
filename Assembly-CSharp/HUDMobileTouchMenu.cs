using System;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HUDMobileTouchMenu : MonoBehaviour
{
	// Token: 0x06001620 RID: 5664 RVA: 0x0007B828 File Offset: 0x00079A28
	private void Start()
	{
		this.pauseButton.OnRelease = delegate()
		{
			global::EventHandler.Global.Fire(new GameEvents.PlayerPause());
		};
		this.chatButton.OnRelease = delegate()
		{
			GameData.Instance.OnHUDChatStartTyping.Fire();
		};
		GameData.Instance.PlayerState.AddEventAndFire(delegate(PlayerStateId el)
		{
			bool flag = el == PlayerStateId.Paused;
			this.pauseButton.gameObject.SetActive(!flag);
		}, this);
	}

	// Token: 0x040014E3 RID: 5347
	[SerializeField]
	private UIButton pauseButton;

	// Token: 0x040014E4 RID: 5348
	[SerializeField]
	private UIButton chatButton;

	// Token: 0x040014E5 RID: 5349
	[SerializeField]
	private UIButton takeScreenshotButton;
}
