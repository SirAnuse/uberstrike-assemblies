using System;

// Token: 0x020001BA RID: 442
public class StatsPageScene : PageScene
{
	// Token: 0x1700031F RID: 799
	// (get) Token: 0x06000C44 RID: 3140 RVA: 0x0000442A File Offset: 0x0000262A
	public override PageType PageType
	{
		get
		{
			return PageType.Stats;
		}
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x0000951B File Offset: 0x0000771B
	protected override void OnLoad()
	{
		if (this._avatarAnchor)
		{
			GameState.Current.Avatar.Decorator.SetPosition(this._avatarAnchor.position, this._avatarAnchor.rotation);
		}
	}
}
