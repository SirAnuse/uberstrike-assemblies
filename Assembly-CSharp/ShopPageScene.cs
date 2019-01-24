using System;

// Token: 0x020001B3 RID: 435
public class ShopPageScene : PageScene
{
	// Token: 0x1700031C RID: 796
	// (get) Token: 0x06000C1A RID: 3098 RVA: 0x0000944A File Offset: 0x0000764A
	public override PageType PageType
	{
		get
		{
			return PageType.Shop;
		}
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x00050B88 File Offset: 0x0004ED88
	protected override void OnLoad()
	{
		if (!GameState.Current.HasJoinedGame)
		{
			if (this._avatarAnchor)
			{
				GameState.Current.Avatar.Decorator.SetPosition(this._avatarAnchor.position, this._avatarAnchor.rotation);
			}
			if (GameState.Current.Avatar != null)
			{
				GameState.Current.Avatar.HideWeapons();
			}
			global::EventHandler.Global.Fire(new GameEvents.PlayerPause());
		}
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x0000944D File Offset: 0x0000764D
	protected override void OnUnload()
	{
		if (!GameState.Current.HasJoinedGame)
		{
			Singleton<TemporaryLoadoutManager>.Instance.ResetLoadout();
		}
	}
}
