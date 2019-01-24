using System;
using UnityEngine;

// Token: 0x020003AF RID: 943
public class MobileDisableRenderer : MonoBehaviour
{
	// Token: 0x06001BA6 RID: 7078 RVA: 0x00012482 File Offset: 0x00010682
	private void OnEnable()
	{
		if (ApplicationDataManager.IsMobile)
		{
			base.renderer.enabled = false;
		}
	}
}
