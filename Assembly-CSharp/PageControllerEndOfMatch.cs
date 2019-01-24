using System;
using UnityEngine;

// Token: 0x0200031C RID: 796
public class PageControllerEndOfMatch : PageControllerBase
{
	// Token: 0x06001646 RID: 5702 RVA: 0x0000F04E File Offset: 0x0000D24E
	private void Start()
	{
		GameData.Instance.PlayerState.AddEventAndFire(delegate(PlayerStateId el)
		{
		}, this);
	}

	// Token: 0x04001512 RID: 5394
	[SerializeField]
	private GameObject joinButtons;
}
