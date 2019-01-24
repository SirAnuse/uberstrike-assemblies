using System;
using UnityEngine;

// Token: 0x02000200 RID: 512
public class TryItemGUI : MonoBehaviour
{
	// Token: 0x06000E3D RID: 3645 RVA: 0x0006178C File Offset: 0x0005F98C
	private void OnGUI()
	{
		if (PopupSystem.IsAnyPopupOpen || PanelManager.IsAnyPanelOpen)
		{
			return;
		}
		LoadoutArea currentLoadoutArea = this._currentLoadoutArea;
		if (currentLoadoutArea == LoadoutArea.Gear)
		{
			this.DrawResetGear();
		}
	}

	// Token: 0x06000E3E RID: 3646 RVA: 0x0000A65B File Offset: 0x0000885B
	private void OnEnable()
	{
		global::EventHandler.Global.AddListener<ShopEvents.LoadoutAreaChanged>(new Action<ShopEvents.LoadoutAreaChanged>(this.OnLoadoutAreaChanged));
	}

	// Token: 0x06000E3F RID: 3647 RVA: 0x0000A673 File Offset: 0x00008873
	private void OnDisable()
	{
		global::EventHandler.Global.RemoveListener<ShopEvents.LoadoutAreaChanged>(new Action<ShopEvents.LoadoutAreaChanged>(this.OnLoadoutAreaChanged));
	}

	// Token: 0x06000E40 RID: 3648 RVA: 0x000617CC File Offset: 0x0005F9CC
	private void DrawResetGear()
	{
		float num = Mathf.Max((float)(Screen.width - 584) * 0.5f, 170f);
		float num2 = ((float)(Screen.width - 584) - num) * 0.5f;
		if (Singleton<TemporaryLoadoutManager>.Instance.IsGearLoadoutModified && GUITools.Button(new Rect(2f + num2, (float)(Screen.height - 60), num, 32f), new GUIContent("Reset Avatar"), BlueStonez.button_white))
		{
			Singleton<TemporaryLoadoutManager>.Instance.ResetLoadout();
		}
	}

	// Token: 0x06000E41 RID: 3649 RVA: 0x0000A68B File Offset: 0x0000888B
	public void OnLoadoutAreaChanged(ShopEvents.LoadoutAreaChanged ev)
	{
		this._currentLoadoutArea = ev.Area;
	}

	// Token: 0x04000D21 RID: 3361
	private LoadoutArea _currentLoadoutArea;
}
