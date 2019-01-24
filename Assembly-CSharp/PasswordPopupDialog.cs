using System;
using UnityEngine;

// Token: 0x020001E7 RID: 487
public class PasswordPopupDialog : BasePopupDialog
{
	// Token: 0x06000DC0 RID: 3520 RVA: 0x0005F978 File Offset: 0x0005DB78
	public PasswordPopupDialog(string title, string text, Action<string> ok, Action cancel)
	{
		PasswordPopupDialog f__this = this;
		this.Text = text;
		this.Title = title;
		this._alertType = PopupSystem.AlertType.OKCancel;
		this._actionType = PopupSystem.ActionType.None;
		this._callbackOk = delegate()
		{
			ok(f__this.password);
		};
		this._callbackCancel = cancel;
		this._okCaption = "OK";
		this._cancelCaption = "Cancel";
		this._allowAudio = true;
		this._size = new Vector2(320f, 200f);
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x0000A11B File Offset: 0x0000831B
	protected override bool IsOkButtonEnabled
	{
		get
		{
			return !string.IsNullOrEmpty(this.password);
		}
	}

	// Token: 0x06000DC2 RID: 3522 RVA: 0x0005FA14 File Offset: 0x0005DC14
	protected override void DrawPopupWindow()
	{
		if (this.IsOkButtonEnabled && Event.current.type == EventType.KeyDown && (Event.current.keyCode == KeyCode.KeypadEnter || Event.current.keyCode == KeyCode.Return))
		{
			PopupSystem.HideMessage(this);
			if (this._callbackOk != null)
			{
				this._callbackOk();
			}
		}
		GUI.Label(new Rect(17f, 55f, this._size.x - 34f, 40f), this.Text, PopupSkin.label);
		GUI.SetNextControlName("JoinPassword");
		this.password = GUI.PasswordField(new Rect(25f, 100f, this._size.x - 50f, 24f), this.password, '*', 64, BlueStonez.textField);
		if (string.IsNullOrEmpty(this.password))
		{
			GUI.color = Color.white.SetAlpha(0.3f);
			GUI.Label(new Rect(25f, 100f, this._size.x - 50f, 24f), "  " + LocalizedStrings.Password, BlueStonez.label_interparkbold_13pt_left);
			GUI.color = Color.white;
		}
		if (GUI.GetNameOfFocusedControl() == string.Empty)
		{
			GUI.FocusControl("JoinPassword");
		}
	}

	// Token: 0x04000CF3 RID: 3315
	private string password = string.Empty;
}
