using System;
using UnityEngine;

// Token: 0x0200031B RID: 795
public class HUDSniperControls : MonoBehaviour
{
	// Token: 0x0600163F RID: 5695 RVA: 0x0000EFF8 File Offset: 0x0000D1F8
	private void OnEnable()
	{
		this.sniperButton.gameObject.SetActive(false);
		this.zoomSlider.gameObject.SetActive(false);
	}

	// Token: 0x06001640 RID: 5696 RVA: 0x0007BF74 File Offset: 0x0007A174
	private void Start()
	{
		this.ignoreRect = new Rect((float)Screen.width - 100f, 400f, 100f, 300f);
		this.sniperButton.OnClicked = delegate()
		{
		};
		this.zoomSlider.onValueChange = delegate(float el)
		{
			global::EventHandler.Global.Fire(new GlobalEvents.InputChanged((el != 0f) ? GameInputKey.NextWeapon : GameInputKey.PrevWeapon, 1f));
		};
		GameState.Current.PlayerData.ActiveWeapon.AddEventAndFire(delegate(WeaponSlot el)
		{
			if (el != null)
			{
				this.sniperButton.gameObject.SetActive(el.View.WeaponSecondaryAction != 0);
				this.zoomInfo = new ZoomInfo((float)el.View.DefaultZoomMultiplier, (float)el.View.MinZoomMultiplier, (float)el.View.MaxZoomMultiplier);
			}
		}, this);
		TouchInput.OnSecondaryFire.AddEventAndFire(delegate(bool el)
		{
			bool flag = el && this.zoomInfo != null && this.zoomInfo.DefaultMultiplier != 1f && this.zoomInfo.MaxMultiplier != this.zoomInfo.MinMultiplier;
			this.zoomSlider.gameObject.SetActive(flag);
			if (flag)
			{
				this.zoomSlider.sliderValue = 0f;
				AutoMonoBehaviour<TouchInput>.Instance.Shooter.IgnoreRect(this.ignoreRect);
			}
			else
			{
				AutoMonoBehaviour<TouchInput>.Instance.Shooter.UnignoreRect(this.ignoreRect);
			}
		}, this);
	}

	// Token: 0x0400150C RID: 5388
	[SerializeField]
	private UIEventReceiver sniperButton;

	// Token: 0x0400150D RID: 5389
	[SerializeField]
	private UISlider zoomSlider;

	// Token: 0x0400150E RID: 5390
	private ZoomInfo zoomInfo;

	// Token: 0x0400150F RID: 5391
	private Rect ignoreRect = default(Rect);
}
