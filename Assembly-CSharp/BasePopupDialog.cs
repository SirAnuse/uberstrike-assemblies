using System;
using UnityEngine;

// Token: 0x020001DE RID: 478
public abstract class BasePopupDialog : IPopupDialog
{
	// Token: 0x17000343 RID: 835
	// (get) Token: 0x06000D78 RID: 3448 RVA: 0x00009FF5 File Offset: 0x000081F5
	// (set) Token: 0x06000D79 RID: 3449 RVA: 0x00009FFD File Offset: 0x000081FD
	public string Text { get; set; }

	// Token: 0x17000344 RID: 836
	// (get) Token: 0x06000D7A RID: 3450 RVA: 0x0000A006 File Offset: 0x00008206
	// (set) Token: 0x06000D7B RID: 3451 RVA: 0x0000A00E File Offset: 0x0000820E
	public string Title { get; set; }

	// Token: 0x06000D7C RID: 3452 RVA: 0x00003C87 File Offset: 0x00001E87
	public virtual void OnHide()
	{
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x0000A017 File Offset: 0x00008217
	public void SetAlertType(PopupSystem.AlertType type)
	{
		this._alertType = type;
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x0005E2EC File Offset: 0x0005C4EC
	public void OnGUI()
	{
		Rect position = new Rect(((float)Screen.width - this._size.x) * 0.5f, ((float)Screen.height - this._size.y - 56f) * 0.5f, this._size.x, this._size.y);
		GUI.BeginGroup(position, GUIContent.none, PopupSkin.window);
		GUI.Label(new Rect(0f, 0f, this._size.x, 56f), this.Title, PopupSkin.title);
		this.DrawPopupWindow();
		switch (this._alertType)
		{
		case PopupSystem.AlertType.OK:
			this.DoOKButton();
			break;
		case PopupSystem.AlertType.OKCancel:
			this.DoOKCancelButtons();
			break;
		case PopupSystem.AlertType.Cancel:
			this.DoCancelButton();
			break;
		}
		GUI.EndGroup();
	}

	// Token: 0x06000D7F RID: 3455
	protected abstract void DrawPopupWindow();

	// Token: 0x17000345 RID: 837
	// (get) Token: 0x06000D80 RID: 3456 RVA: 0x00004D4D File Offset: 0x00002F4D
	public GuiDepth Depth
	{
		get
		{
			return GuiDepth.Popup;
		}
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x0005E3D8 File Offset: 0x0005C5D8
	private void DoOKButton()
	{
		GUIStyle style = PopupSkin.button;
		PopupSystem.ActionType actionType = this._actionType;
		if (actionType != PopupSystem.ActionType.Negative)
		{
			if (actionType == PopupSystem.ActionType.Positive)
			{
				style = PopupSkin.button_green;
			}
		}
		else
		{
			style = PopupSkin.button_red;
		}
		Rect rect = new Rect((this._size.x - 120f) * 0.5f, this._size.y - 40f, 120f, 32f);
		GUIContent content = new GUIContent((!string.IsNullOrEmpty(this._okCaption)) ? this._okCaption : LocalizedStrings.OkCaps);
		bool flag;
		if (this._allowAudio)
		{
			flag = GUITools.Button(rect, content, style);
		}
		else
		{
			flag = GUI.Button(rect, content, style);
		}
		if (flag)
		{
			PopupSystem.HideMessage(this);
			if (this._callbackOk != null)
			{
				this._callbackOk();
			}
		}
	}

	// Token: 0x06000D82 RID: 3458 RVA: 0x0005E4C4 File Offset: 0x0005C6C4
	private void DoOKCancelButtons()
	{
		Rect rect = new Rect(this._size.x * 0.5f + 5f, this._size.y - 40f, 120f, 32f);
		GUIContent content = new GUIContent((!string.IsNullOrEmpty(this._cancelCaption)) ? this._cancelCaption : LocalizedStrings.CancelCaps);
		GUI.color = Color.white;
		bool flag;
		if (this._allowAudio)
		{
			flag = GUITools.Button(rect, content, PopupSkin.button);
		}
		else
		{
			flag = GUI.Button(rect, content, PopupSkin.button);
		}
		if (flag)
		{
			PopupSystem.HideMessage(this);
			if (this._callbackCancel != null)
			{
				this._callbackCancel();
			}
		}
		GUIStyle style = PopupSkin.button;
		PopupSystem.ActionType actionType = this._actionType;
		if (actionType != PopupSystem.ActionType.Negative)
		{
			if (actionType == PopupSystem.ActionType.Positive)
			{
				style = PopupSkin.button_green;
			}
		}
		else
		{
			style = PopupSkin.button_red;
		}
		rect = new Rect(this._size.x * 0.5f - 125f, this._size.y - 40f, 120f, 32f);
		content = new GUIContent((!string.IsNullOrEmpty(this._okCaption)) ? this._okCaption : LocalizedStrings.OkCaps);
		GUI.enabled = this.IsOkButtonEnabled;
		if (this._allowAudio)
		{
			flag = GUITools.Button(rect, content, style);
		}
		else
		{
			flag = GUI.Button(rect, content, style);
		}
		if (flag)
		{
			PopupSystem.HideMessage(this);
			if (this._callbackOk != null)
			{
				this._callbackOk();
			}
		}
	}

	// Token: 0x17000346 RID: 838
	// (get) Token: 0x06000D83 RID: 3459 RVA: 0x00004D4D File Offset: 0x00002F4D
	protected virtual bool IsOkButtonEnabled
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000D84 RID: 3460 RVA: 0x0005E670 File Offset: 0x0005C870
	private void DoCancelButton()
	{
		GUIStyle style = PopupSkin.button;
		PopupSystem.ActionType actionType = this._actionType;
		if (actionType != PopupSystem.ActionType.Negative)
		{
			if (actionType == PopupSystem.ActionType.Positive)
			{
				style = PopupSkin.button_green;
			}
		}
		else
		{
			style = PopupSkin.button_red;
		}
		Rect rect = new Rect((this._size.x - 120f) * 0.5f, this._size.y - 40f, 120f, 32f);
		GUIContent content = new GUIContent((!string.IsNullOrEmpty(this._cancelCaption)) ? this._cancelCaption : LocalizedStrings.CancelCaps);
		bool flag;
		if (this._allowAudio)
		{
			flag = GUITools.Button(rect, content, style);
		}
		else
		{
			flag = GUI.Button(rect, content, style);
		}
		if (flag)
		{
			PopupSystem.HideMessage(this);
			if (this._callbackCancel != null)
			{
				this._callbackCancel();
			}
		}
	}

	// Token: 0x04000CCA RID: 3274
	protected Vector2 _size = new Vector2(320f, 240f);

	// Token: 0x04000CCB RID: 3275
	protected PopupSystem.ActionType _actionType;

	// Token: 0x04000CCC RID: 3276
	protected PopupSystem.AlertType _alertType;

	// Token: 0x04000CCD RID: 3277
	protected string _okCaption = string.Empty;

	// Token: 0x04000CCE RID: 3278
	protected string _cancelCaption = string.Empty;

	// Token: 0x04000CCF RID: 3279
	protected bool _allowAudio = true;

	// Token: 0x04000CD0 RID: 3280
	protected Action _callbackOk;

	// Token: 0x04000CD1 RID: 3281
	protected Action _callbackCancel;

	// Token: 0x04000CD2 RID: 3282
	protected Action _onGUIAction;
}
