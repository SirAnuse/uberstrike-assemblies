using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class PageControllerPregameLoadout : PageControllerBase
{
	// Token: 0x06001654 RID: 5716 RVA: 0x0000F0F6 File Offset: 0x0000D2F6
	private void Start()
	{
		GameData.Instance.PlayerState.AddEventAndFire(delegate(PlayerStateId el)
		{
		}, this);
	}

	// Token: 0x0400152A RID: 5418
	[SerializeField]
	private GameObject joinButtons;
}
