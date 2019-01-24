using System;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class HUDDesktopFPS : MonoBehaviour
{
	// Token: 0x060015E9 RID: 5609 RVA: 0x0000EB96 File Offset: 0x0000CD96
	private void Start()
	{
		GameData.Instance.VideoShowFps.AddEventAndFire(delegate(Tuple el)
		{
			this.label.enabled = ApplicationDataManager.ApplicationOptions.VideoShowFps;
		}, this);
	}

	// Token: 0x060015EA RID: 5610 RVA: 0x0000EBB4 File Offset: 0x0000CDB4
	private void OnEnable()
	{
		GameData.Instance.VideoShowFps.Fire();
	}

	// Token: 0x060015EB RID: 5611 RVA: 0x0000EBC5 File Offset: 0x0000CDC5
	private void Update()
	{
		if (this.label.enabled)
		{
			this.label.text = ApplicationDataManager.FrameRate;
		}
	}

	// Token: 0x040014B4 RID: 5300
	[SerializeField]
	private UILabel label;
}
