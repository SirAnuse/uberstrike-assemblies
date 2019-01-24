using System;
using UnityEngine;

// Token: 0x02000316 RID: 790
public class HUDMobileScoreboardTrigger : MonoBehaviour
{
	// Token: 0x0600161C RID: 5660 RVA: 0x0007B7D4 File Offset: 0x000799D4
	private void Start()
	{
		this.scoreboardButton.OnPressed = delegate(bool el)
		{
			TabScreenPanelGUI.ForceShow = el;
		};
		GameData.Instance.GameState.AddEventAndFire(delegate(GameStateId el)
		{
			this.visualAid.SetActive(el == GameStateId.PrepareNextRound);
		}, this);
	}

	// Token: 0x040014E0 RID: 5344
	[SerializeField]
	private UIEventReceiver scoreboardButton;

	// Token: 0x040014E1 RID: 5345
	[SerializeField]
	private GameObject visualAid;
}
