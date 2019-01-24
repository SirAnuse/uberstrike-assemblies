using System;
using UnityEngine;

// Token: 0x020001ED RID: 493
public class ProgressPopupDialog : GeneralPopupDialog
{
	// Token: 0x06000DE3 RID: 3555 RVA: 0x0000A2AD File Offset: 0x000084AD
	public ProgressPopupDialog(string title, string text, Func<float> progress = null) : base(title, text)
	{
		this._progress = progress;
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x06000DE4 RID: 3556 RVA: 0x0000A2BE File Offset: 0x000084BE
	// (set) Token: 0x06000DE5 RID: 3557 RVA: 0x0000A2C6 File Offset: 0x000084C6
	public float Progress { get; set; }

	// Token: 0x06000DE6 RID: 3558 RVA: 0x0005FE08 File Offset: 0x0005E008
	protected override void DrawPopupWindow()
	{
		GUI.Label(new Rect(17f, 95f, this._size.x - 34f, 32f), this.Text, BlueStonez.label_interparkbold_11pt);
		if (this._progress != null)
		{
			this.DrawLevelBar(new Rect(17f, 125f, this._size.x - 34f, 16f), this._progress(), ColorScheme.ProgressBar);
		}
		else
		{
			this.DrawLevelBar(new Rect(17f, 125f, this._size.x - 34f, 16f), this.Progress, ColorScheme.ProgressBar);
		}
	}

	// Token: 0x06000DE7 RID: 3559 RVA: 0x0005FECC File Offset: 0x0005E0CC
	private void DrawLevelBar(Rect position, float amount, Color barColor)
	{
		GUI.BeginGroup(position);
		GUI.Label(new Rect(0f, 0f, position.width, 12f), GUIContent.none, BlueStonez.progressbar_background);
		GUI.color = barColor;
		GUI.Label(new Rect(2f, 2f, (position.width - 4f) * Mathf.Clamp01(amount), 8f), string.Empty, BlueStonez.progressbar_thumb);
		GUI.color = Color.white;
		GUI.EndGroup();
	}

	// Token: 0x06000DE8 RID: 3560 RVA: 0x0000A2CF File Offset: 0x000084CF
	public void SetCancelable(Action action)
	{
		this._callbackCancel = action;
		this._cancelCaption = LocalizedStrings.Cancel;
		this._alertType = ((action == null) ? PopupSystem.AlertType.None : PopupSystem.AlertType.Cancel);
		this._actionType = PopupSystem.ActionType.None;
	}

	// Token: 0x04000D02 RID: 3330
	private Func<float> _progress;
}
