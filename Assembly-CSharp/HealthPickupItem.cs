using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000220 RID: 544
public class HealthPickupItem : PickupItem
{
	// Token: 0x06000F08 RID: 3848 RVA: 0x00063A80 File Offset: 0x00061C80
	protected override bool OnPlayerPickup()
	{
		int num;
		int num2;
		switch (this._healthPoints)
		{
		case HealthPickupItem.Category.HP_100:
			num = 100;
			num2 = 200;
			break;
		case HealthPickupItem.Category.HP_50:
			num = 50;
			num2 = 100;
			break;
		case HealthPickupItem.Category.HP_25:
			num = 25;
			num2 = 100;
			break;
		case HealthPickupItem.Category.HP_5:
			num = 5;
			num2 = 200;
			break;
		default:
			num = 0;
			num2 = 100;
			break;
		}
		PlayerData playerData = GameState.Current.PlayerData;
		if (playerData.Health < num2)
		{
			playerData.Health.Value = Mathf.Clamp(playerData.Health + num, 0, num2);
			GameState.Current.Actions.PickupPowerup(base.PickupID, PickupItemType.Health, num);
			switch (this._healthPoints)
			{
			case HealthPickupItem.Category.HP_100:
				GameData.Instance.OnItemPickup.Fire("Uber Health", PickUpMessageType.Health100);
				break;
			case HealthPickupItem.Category.HP_50:
				GameData.Instance.OnItemPickup.Fire("Big Health", PickUpMessageType.Health50);
				break;
			case HealthPickupItem.Category.HP_25:
				GameData.Instance.OnItemPickup.Fire("Medium Health", PickUpMessageType.Health25);
				break;
			case HealthPickupItem.Category.HP_5:
				GameData.Instance.OnItemPickup.Fire("Mini Health", PickUpMessageType.Health5);
				break;
			}
			switch (this._healthPoints)
			{
			case HealthPickupItem.Category.HP_100:
				base.PlayLocalPickupSound(GameAudio.MegaHealth2D);
				break;
			case HealthPickupItem.Category.HP_50:
				base.PlayLocalPickupSound(GameAudio.BigHealth2D);
				break;
			case HealthPickupItem.Category.HP_25:
				base.PlayLocalPickupSound(GameAudio.MediumHealth2D);
				break;
			case HealthPickupItem.Category.HP_5:
				base.PlayLocalPickupSound(GameAudio.SmallHealth2D);
				break;
			default:
				base.PlayLocalPickupSound(GameAudio.SmallHealth2D);
				break;
			}
			if (GameState.Current.IsSinglePlayer)
			{
				base.StartCoroutine(base.StartHidingPickupForSeconds(this._respawnTime));
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000F09 RID: 3849 RVA: 0x00063C68 File Offset: 0x00061E68
	protected override void OnRemotePickup()
	{
		switch (this._healthPoints)
		{
		case HealthPickupItem.Category.HP_100:
			base.PlayRemotePickupSound(GameAudio.MegaHealth, base.transform.position);
			break;
		case HealthPickupItem.Category.HP_50:
			base.PlayRemotePickupSound(GameAudio.BigHealth, base.transform.position);
			break;
		case HealthPickupItem.Category.HP_25:
			base.PlayRemotePickupSound(GameAudio.MediumHealth, base.transform.position);
			break;
		case HealthPickupItem.Category.HP_5:
			base.PlayRemotePickupSound(GameAudio.SmallHealth, base.transform.position);
			break;
		default:
			base.PlayRemotePickupSound(GameAudio.SmallHealth, base.transform.position);
			break;
		}
	}

	// Token: 0x17000386 RID: 902
	// (get) Token: 0x06000F0A RID: 3850 RVA: 0x0000ACD6 File Offset: 0x00008ED6
	protected override bool CanPlayerPickup
	{
		get
		{
			return GameState.Current.PlayerData.Health < 100;
		}
	}

	// Token: 0x04000D54 RID: 3412
	[SerializeField]
	private HealthPickupItem.Category _healthPoints;

	// Token: 0x02000221 RID: 545
	public enum Category
	{
		// Token: 0x04000D56 RID: 3414
		HP_100,
		// Token: 0x04000D57 RID: 3415
		HP_50,
		// Token: 0x04000D58 RID: 3416
		HP_25,
		// Token: 0x04000D59 RID: 3417
		HP_5
	}
}
