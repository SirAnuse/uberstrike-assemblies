using System;
using UnityEngine;

// Token: 0x020001E0 RID: 480
public class GeneralPopupDialog : BasePopupDialog
{
	// Token: 0x06000D88 RID: 3464 RVA: 0x0005E974 File Offset: 0x0005CB74
	public GeneralPopupDialog(string title, string text, PopupSystem.AlertType flag, Action ok, string okCaption, Action cancel, string cancelCaption, PopupSystem.ActionType actionType, bool allowAudio = true)
	{
		this.Text = text;
		this.Title = title;
		this._alertType = flag;
		this._actionType = actionType;
		this._callbackOk = ok;
		this._callbackCancel = cancel;
		this._okCaption = okCaption;
		this._cancelCaption = cancelCaption;
		this._allowAudio = allowAudio;
	}

	// Token: 0x06000D89 RID: 3465 RVA: 0x0005E9CC File Offset: 0x0005CBCC
	public GeneralPopupDialog(string title, string text) : this(title, text, PopupSystem.AlertType.None, null, string.Empty, null, string.Empty, PopupSystem.ActionType.None, true)
	{
	}

	// Token: 0x06000D8A RID: 3466 RVA: 0x0005E9F0 File Offset: 0x0005CBF0
	public GeneralPopupDialog(string title, string text, PopupSystem.AlertType flag, bool allowAudio = true) : this(title, text, flag, null, string.Empty, null, string.Empty, PopupSystem.ActionType.None, allowAudio)
	{
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x0005EA18 File Offset: 0x0005CC18
	public GeneralPopupDialog(string title, string text, PopupSystem.AlertType flag, Action ok, string okCaption, bool allowAudio = true) : this(title, text, flag, ok, okCaption, null, string.Empty, PopupSystem.ActionType.None, allowAudio)
	{
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x0005EA3C File Offset: 0x0005CC3C
	public GeneralPopupDialog(string title, string text, PopupSystem.AlertType flag, Action action, bool allowAudio = true) : this(title, text, flag, action, string.Empty, null, string.Empty, PopupSystem.ActionType.None, allowAudio)
	{
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x0005EA64 File Offset: 0x0005CC64
	public GeneralPopupDialog(string title, string text, PopupSystem.AlertType flag, Action ok, Action cancel, bool allowAudio = true) : this(title, text, flag, ok, string.Empty, cancel, string.Empty, PopupSystem.ActionType.None, allowAudio)
	{
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x0005EA8C File Offset: 0x0005CC8C
	protected override void DrawPopupWindow()
	{
		GUI.Label(new Rect(17f, 55f, this._size.x - 34f, this._size.y - 100f), this.Text, PopupSkin.label);
	}
}
