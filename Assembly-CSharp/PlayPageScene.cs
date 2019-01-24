using System;

// Token: 0x020001AB RID: 427
public class PlayPageScene : PageScene
{
	// Token: 0x17000311 RID: 785
	// (get) Token: 0x06000BBE RID: 3006 RVA: 0x0000505C File Offset: 0x0000325C
	public override PageType PageType
	{
		get
		{
			return PageType.Play;
		}
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0000929A File Offset: 0x0000749A
	protected override void OnLoad()
	{
		PlayPageGUI.Instance.Show();
	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x000092A6 File Offset: 0x000074A6
	protected override void OnUnload()
	{
		PlayPageGUI.Instance.Hide();
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x000092A6 File Offset: 0x000074A6
	private void OnDisable()
	{
		PlayPageGUI.Instance.Hide();
	}
}
