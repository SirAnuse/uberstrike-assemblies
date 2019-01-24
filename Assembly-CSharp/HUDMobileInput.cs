using System;
using UnityEngine;

// Token: 0x02000313 RID: 787
public class HUDMobileInput : MonoBehaviour
{
	// Token: 0x0600160C RID: 5644 RVA: 0x0000EDC8 File Offset: 0x0000CFC8
	private void Start()
	{
		TouchInput.ShowTouchControls.AddEventAndFire(delegate(bool el)
		{
			this.multitouchController.gameObject.SetActive(el && TouchInput.UseMultiTouch);
			this.simpleTouchController.gameObject.SetActive(el && !TouchInput.UseMultiTouch);
			this.sniperControls.gameObject.SetActive(el);
		}, this);
	}

	// Token: 0x040014D6 RID: 5334
	[SerializeField]
	private HUDMultitouchController multitouchController;

	// Token: 0x040014D7 RID: 5335
	[SerializeField]
	private HUDSimpleTouchController simpleTouchController;

	// Token: 0x040014D8 RID: 5336
	[SerializeField]
	private HUDSniperControls sniperControls;
}
