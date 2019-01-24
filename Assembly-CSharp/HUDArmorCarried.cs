using System;
using UnityEngine;

// Token: 0x02000325 RID: 805
public class HUDArmorCarried : MonoBehaviour
{
	// Token: 0x06001676 RID: 5750 RVA: 0x0000F218 File Offset: 0x0000D418
	private void OnEnable()
	{
		GameState.Current.PlayerData.ArmorCarried.Fire();
	}

	// Token: 0x06001677 RID: 5751 RVA: 0x0000F22E File Offset: 0x0000D42E
	private void Start()
	{
		GameState.Current.PlayerData.ArmorCarried.AddEventAndFire(delegate(int el)
		{
			this.armorCarriedValue.text = el.ToString();
		}, this);
		GameData.Instance.IsShopLoaded.AddEventAndFire(delegate(bool el)
		{
			NGUITools.SetActiveChildren(base.gameObject, el);
		}, this);
	}

	// Token: 0x04001557 RID: 5463
	[SerializeField]
	private UILabel armorCarriedValue;
}
