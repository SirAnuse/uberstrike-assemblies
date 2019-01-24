using System;

// Token: 0x020001A2 RID: 418
public class LoginPageScene : PageScene
{
	// Token: 0x17000307 RID: 775
	// (get) Token: 0x06000B80 RID: 2944 RVA: 0x000090B9 File Offset: 0x000072B9
	public override PageType PageType
	{
		get
		{
			return PageType.Login;
		}
	}

	// Token: 0x06000B81 RID: 2945 RVA: 0x000090BC File Offset: 0x000072BC
	protected override void OnLoad()
	{
		PanelManager.Instance.OpenPanel(PanelType.Login);
	}

	// Token: 0x06000B82 RID: 2946 RVA: 0x000090CA File Offset: 0x000072CA
	protected override void OnUnload()
	{
		PanelManager.Instance.ClosePanel(PanelType.Login);
	}
}
