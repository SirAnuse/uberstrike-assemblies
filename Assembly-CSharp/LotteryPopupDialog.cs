using System;
using UnityEngine;

// Token: 0x020001E5 RID: 485
public abstract class LotteryPopupDialog : IPopupDialog
{
	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06000DAF RID: 3503 RVA: 0x0000A0BE File Offset: 0x000082BE
	// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x0000A0C6 File Offset: 0x000082C6
	public string Text { get; set; }

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06000DB1 RID: 3505 RVA: 0x0000A0CF File Offset: 0x000082CF
	// (set) Token: 0x06000DB2 RID: 3506 RVA: 0x0000A0D7 File Offset: 0x000082D7
	public string Title { get; set; }

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06000DB3 RID: 3507 RVA: 0x0000A0E0 File Offset: 0x000082E0
	// (set) Token: 0x06000DB4 RID: 3508 RVA: 0x0000A0E8 File Offset: 0x000082E8
	public bool IsVisible { get; set; }

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x0000A0F1 File Offset: 0x000082F1
	// (set) Token: 0x06000DB6 RID: 3510 RVA: 0x0000A0F9 File Offset: 0x000082F9
	public bool IsUIDisabled { get; set; }

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x0000A102 File Offset: 0x00008302
	// (set) Token: 0x06000DB8 RID: 3512 RVA: 0x0000A10A File Offset: 0x0000830A
	public bool IsWaiting { get; set; }

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06000DB9 RID: 3513 RVA: 0x00008F9A File Offset: 0x0000719A
	public GuiDepth Depth
	{
		get
		{
			return GuiDepth.Event;
		}
	}

	// Token: 0x06000DBA RID: 3514 RVA: 0x0005F820 File Offset: 0x0005DA20
	public void OnGUI()
	{
		Rect position = this.GetPosition();
		GUI.Box(position, GUIContent.none, BlueStonez.window);
		GUITools.PushGUIState();
		GUI.enabled = !this.IsUIDisabled;
		GUI.BeginGroup(position);
		if (this._showExitButton && GUI.Button(new Rect(position.width - 20f, 0f, 20f, 20f), "X", BlueStonez.friends_hidden_button))
		{
			PopupSystem.HideMessage(this);
		}
		this.DrawPlayGUI(position);
		GUI.EndGroup();
		GUITools.PopGUIState();
		if (this.IsWaiting)
		{
			WaitingTexture.Draw(position.center, 0);
		}
		if (this.ClickAnywhereToExit && Event.current.type == EventType.MouseDown && !position.Contains(Event.current.mousePosition))
		{
			this.ClosePopup();
			Event.current.Use();
		}
		this.OnAfterGUI();
	}

	// Token: 0x06000DBB RID: 3515 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void OnAfterGUI()
	{
	}

	// Token: 0x06000DBC RID: 3516 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnHide()
	{
	}

	// Token: 0x06000DBD RID: 3517
	protected abstract void DrawPlayGUI(Rect rect);

	// Token: 0x06000DBE RID: 3518 RVA: 0x0000A113 File Offset: 0x00008313
	protected void ClosePopup()
	{
		PopupSystem.HideMessage(this);
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x0005F914 File Offset: 0x0005DB14
	private Rect GetPosition()
	{
		float left = (float)(Screen.width - this.Width) * 0.5f;
		float top = (float)GlobalUIRibbon.Instance.Height() + (float)(Screen.height - GlobalUIRibbon.Instance.Height() - this.Height) * 0.5f;
		return new Rect(left, top, (float)this.Width, (float)this.Height);
	}

	// Token: 0x04000CE3 RID: 3299
	public const int IMG_WIDTH = 282;

	// Token: 0x04000CE4 RID: 3300
	public const int IMG_HEIGHT = 317;

	// Token: 0x04000CE5 RID: 3301
	private const float BerpSpeed = 2.5f;

	// Token: 0x04000CE6 RID: 3302
	protected int Width = 650;

	// Token: 0x04000CE7 RID: 3303
	protected int Height = 330;

	// Token: 0x04000CE8 RID: 3304
	public bool ClickAnywhereToExit = true;

	// Token: 0x04000CE9 RID: 3305
	protected LotteryPopupDialog.State _state;

	// Token: 0x04000CEA RID: 3306
	protected bool _showExitButton = true;

	// Token: 0x020001E6 RID: 486
	protected enum State
	{
		// Token: 0x04000CF1 RID: 3313
		Normal,
		// Token: 0x04000CF2 RID: 3314
		Rolled
	}
}
