using System;

// Token: 0x02000191 RID: 401
public class HomePageScene : PageScene
{
	// Token: 0x170002EE RID: 750
	// (get) Token: 0x06000AFA RID: 2810 RVA: 0x00004D4D File Offset: 0x00002F4D
	public override PageType PageType
	{
		get
		{
			return PageType.Home;
		}
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x000470D4 File Offset: 0x000452D4
	protected override void OnLoad()
	{
		if (this._avatarAnchor && GameState.Current.Avatar.Decorator)
		{
			GameState.Current.Avatar.Decorator.SetPosition(this._avatarAnchor.position, this._avatarAnchor.rotation);
			GameState.Current.Avatar.HideWeapons();
			GameState.Current.Avatar.Decorator.HudInformation.SetAvatarLabel(PlayerDataManager.NameAndTag);
		}
		Singleton<EventPopupManager>.Instance.ShowNextPopup(1);
	}
}
