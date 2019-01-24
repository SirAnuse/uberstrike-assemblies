using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001EA RID: 490
public class PopupSystem : AutoMonoBehaviour<PopupSystem>
{
	// Token: 0x06000DCE RID: 3534 RVA: 0x0005FC1C File Offset: 0x0005DE1C
	private void OnGUI()
	{
		this.ReleaseOldLock();
		if (this._popups.Count > 0)
		{
			IPopupDialog popupDialog = this._popups.Peek();
			this._lastLockDepth = popupDialog.Depth;
			GUI.depth = (int)this._lastLockDepth;
			popupDialog.OnGUI();
			if (Event.current.type == EventType.Layout)
			{
				GuiLockController.EnableLock(this._lastLockDepth);
			}
		}
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000DCF RID: 3535 RVA: 0x0005FC8C File Offset: 0x0005DE8C
	private void ReleaseOldLock()
	{
		if (Event.current.type == EventType.Layout)
		{
			if (this._popups.Count > 0)
			{
				if (this._lastLockDepth != this._popups.Peek().Depth)
				{
					GuiLockController.ReleaseLock(this._lastLockDepth);
				}
			}
			else
			{
				GuiLockController.ReleaseLock(this._lastLockDepth);
				base.enabled = false;
			}
		}
	}

	// Token: 0x06000DD0 RID: 3536 RVA: 0x0000A1AE File Offset: 0x000083AE
	public static void Show(IPopupDialog popup)
	{
		AutoMonoBehaviour<PopupSystem>.Instance._popups.Push(popup);
		AutoMonoBehaviour<PopupSystem>.Instance.enabled = true;
	}

	// Token: 0x06000DD1 RID: 3537 RVA: 0x0000A1CB File Offset: 0x000083CB
	public static void ShowMessage(string title, string text, PopupSystem.AlertType flag, Action ok)
	{
		PopupSystem.ShowMessage(title, text, flag, ok, null);
	}

	// Token: 0x06000DD2 RID: 3538 RVA: 0x0000A1D7 File Offset: 0x000083D7
	public static void ShowError(string title, string text, PopupSystem.AlertType flag, Action ok)
	{
		PopupSystem.ShowError(title, text, flag, ok, null);
	}

	// Token: 0x06000DD3 RID: 3539 RVA: 0x0000A1E3 File Offset: 0x000083E3
	public static void ShowMessage(string title, string text, PopupSystem.AlertType flag, Action ok, Action cancel)
	{
		PopupSystem.Show(new GeneralPopupDialog(title, text, flag, ok, cancel, true));
	}

	// Token: 0x06000DD4 RID: 3540 RVA: 0x0000A1F6 File Offset: 0x000083F6
	public static void ShowError(string title, string text, PopupSystem.AlertType flag, Action ok, Action cancel)
	{
		PopupSystem.Show(new GeneralPopupDialog(title, text, flag, ok, cancel, false));
	}

	// Token: 0x06000DD5 RID: 3541 RVA: 0x0005FCF8 File Offset: 0x0005DEF8
	public static IPopupDialog ShowMessage(string title, string text, PopupSystem.AlertType flag, Action ok, string okCaption, Action cancel, string cancelCaption, PopupSystem.ActionType type)
	{
		IPopupDialog popupDialog = new GeneralPopupDialog(title, text, flag, ok, okCaption, cancel, cancelCaption, type, true);
		PopupSystem.Show(popupDialog);
		return popupDialog;
	}

	// Token: 0x06000DD6 RID: 3542 RVA: 0x0005FD20 File Offset: 0x0005DF20
	public static IPopupDialog ShowMessage(string title, string text, PopupSystem.AlertType flag, Action ok, string okCaption, Action cancel, string cancelCaption)
	{
		IPopupDialog popupDialog = new GeneralPopupDialog(title, text, flag, ok, okCaption, cancel, cancelCaption, PopupSystem.ActionType.None, true);
		PopupSystem.Show(popupDialog);
		return popupDialog;
	}

	// Token: 0x06000DD7 RID: 3543 RVA: 0x0005FD48 File Offset: 0x0005DF48
	public static IPopupDialog ShowMessage(string title, string text, PopupSystem.AlertType flag, string okCaption, Action ok)
	{
		IPopupDialog popupDialog = new GeneralPopupDialog(title, text, flag, ok, okCaption, true);
		PopupSystem.Show(popupDialog);
		return popupDialog;
	}

	// Token: 0x06000DD8 RID: 3544 RVA: 0x0005FD6C File Offset: 0x0005DF6C
	public static ProgressPopupDialog ShowProgress(string title, string text, Func<float> progress = null)
	{
		ProgressPopupDialog progressPopupDialog = new ProgressPopupDialog(title, text, progress);
		PopupSystem.Show(progressPopupDialog);
		return progressPopupDialog;
	}

	// Token: 0x06000DD9 RID: 3545 RVA: 0x0005FD8C File Offset: 0x0005DF8C
	public static IPopupDialog ShowItems(string title, string text, List<IUnityItem> items)
	{
		IPopupDialog popupDialog = new ItemListPopupDialog(title, text, items, null);
		PopupSystem.Show(popupDialog);
		return popupDialog;
	}

	// Token: 0x06000DDA RID: 3546 RVA: 0x0005FDAC File Offset: 0x0005DFAC
	public static IPopupDialog ShowItem(IUnityItem item, string customMessage = "")
	{
		IPopupDialog popupDialog = new ItemListPopupDialog(item, customMessage);
		PopupSystem.Show(popupDialog);
		return popupDialog;
	}

	// Token: 0x06000DDB RID: 3547 RVA: 0x0005FDC8 File Offset: 0x0005DFC8
	public static IPopupDialog ShowMessage(string title, string text)
	{
		IPopupDialog popupDialog = new GeneralPopupDialog(title, text, PopupSystem.AlertType.OK, true);
		PopupSystem.Show(popupDialog);
		return popupDialog;
	}

	// Token: 0x06000DDC RID: 3548 RVA: 0x0005FDE8 File Offset: 0x0005DFE8
	public static IPopupDialog ShowMessage(string title, string text, PopupSystem.AlertType flag)
	{
		IPopupDialog popupDialog = new GeneralPopupDialog(title, text, flag, true);
		PopupSystem.Show(popupDialog);
		return popupDialog;
	}

	// Token: 0x06000DDD RID: 3549 RVA: 0x0005FDE8 File Offset: 0x0005DFE8
	public static IPopupDialog ShowError(string title, string text, PopupSystem.AlertType flag)
	{
		IPopupDialog popupDialog = new GeneralPopupDialog(title, text, flag, true);
		PopupSystem.Show(popupDialog);
		return popupDialog;
	}

	// Token: 0x06000DDE RID: 3550 RVA: 0x0000A209 File Offset: 0x00008409
	public static void HideMessage(IPopupDialog dialog)
	{
		if (dialog != null)
		{
			AutoMonoBehaviour<PopupSystem>.Instance._popups.Remove(dialog);
			dialog.OnHide();
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x06000DDF RID: 3551 RVA: 0x0000A227 File Offset: 0x00008427
	public static bool IsAnyPopupOpen
	{
		get
		{
			return AutoMonoBehaviour<PopupSystem>.Instance._popups.Count > 0;
		}
	}

	// Token: 0x06000DE0 RID: 3552 RVA: 0x0000A23B File Offset: 0x0000843B
	public static void ClearAll()
	{
		AutoMonoBehaviour<PopupSystem>.Instance._popups.Clear();
	}

	// Token: 0x06000DE1 RID: 3553 RVA: 0x0000A24C File Offset: 0x0000844C
	private static bool IsCurrentPopup(IPopupDialog dialog)
	{
		return AutoMonoBehaviour<PopupSystem>.Instance._popups.Count > 0 && AutoMonoBehaviour<PopupSystem>.Instance._popups.Peek() == dialog;
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x0000A278 File Offset: 0x00008478
	public static string CurrentPopupName
	{
		get
		{
			return (AutoMonoBehaviour<PopupSystem>.Instance._popups.Count <= 0) ? string.Empty : AutoMonoBehaviour<PopupSystem>.Instance._popups.Peek().ToString();
		}
	}

	// Token: 0x04000CF7 RID: 3319
	private GuiDepth _lastLockDepth;

	// Token: 0x04000CF8 RID: 3320
	private readonly PopupStack<IPopupDialog> _popups = new PopupStack<IPopupDialog>();

	// Token: 0x020001EB RID: 491
	public enum AlertType
	{
		// Token: 0x04000CFA RID: 3322
		OK,
		// Token: 0x04000CFB RID: 3323
		OKCancel,
		// Token: 0x04000CFC RID: 3324
		Cancel,
		// Token: 0x04000CFD RID: 3325
		None
	}

	// Token: 0x020001EC RID: 492
	public enum ActionType
	{
		// Token: 0x04000CFF RID: 3327
		None,
		// Token: 0x04000D00 RID: 3328
		Negative,
		// Token: 0x04000D01 RID: 3329
		Positive
	}
}
