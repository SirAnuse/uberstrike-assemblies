using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x0200021E RID: 542
public class ArmorPickupItem : PickupItem
{
	// Token: 0x06000F04 RID: 3844 RVA: 0x0006389C File Offset: 0x00061A9C
	protected override bool OnPlayerPickup()
	{
		if (this.CanPlayerPickup)
		{
			int num = 0;
			switch (this._armorPoints)
			{
			case ArmorPickupItem.Category.Gold:
				num = 100;
				GameData.Instance.OnItemPickup.Fire("Uber Armor", PickUpMessageType.Armor100);
				break;
			case ArmorPickupItem.Category.Silver:
				num = 50;
				GameData.Instance.OnItemPickup.Fire("Big Armor", PickUpMessageType.Armor50);
				break;
			case ArmorPickupItem.Category.Bronze:
				num = 5;
				GameData.Instance.OnItemPickup.Fire("Mini Armor", PickUpMessageType.Armor5);
				break;
			}
			GameState.Current.PlayerData.ArmorPoints.Value += num;
			switch (this._armorPoints)
			{
			case ArmorPickupItem.Category.Gold:
				base.PlayLocalPickupSound(GameAudio.GoldArmor2D);
				break;
			case ArmorPickupItem.Category.Silver:
				base.PlayLocalPickupSound(GameAudio.SilverArmor2D);
				break;
			case ArmorPickupItem.Category.Bronze:
				base.PlayLocalPickupSound(GameAudio.ArmorShard2D);
				break;
			default:
				base.PlayLocalPickupSound(GameAudio.ArmorShard2D);
				break;
			}
			GameState.Current.Actions.PickupPowerup(base.PickupID, PickupItemType.Armor, num);
			if (GameState.Current.IsSinglePlayer)
			{
				base.StartCoroutine(base.StartHidingPickupForSeconds(this._respawnTime));
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x000639E8 File Offset: 0x00061BE8
	protected override void OnRemotePickup()
	{
		switch (this._armorPoints)
		{
		case ArmorPickupItem.Category.Gold:
			base.PlayRemotePickupSound(GameAudio.GoldArmor, base.transform.position);
			break;
		case ArmorPickupItem.Category.Silver:
			base.PlayRemotePickupSound(GameAudio.SilverArmor, base.transform.position);
			break;
		case ArmorPickupItem.Category.Bronze:
			base.PlayRemotePickupSound(GameAudio.ArmorShard, base.transform.position);
			break;
		default:
			base.PlayRemotePickupSound(GameAudio.ArmorShard, base.transform.position);
			break;
		}
	}

	// Token: 0x17000385 RID: 901
	// (get) Token: 0x06000F06 RID: 3846 RVA: 0x0000ACB9 File Offset: 0x00008EB9
	protected override bool CanPlayerPickup
	{
		get
		{
			return GameState.Current.PlayerData.ArmorPoints < 200;
		}
	}

	// Token: 0x04000D4F RID: 3407
	[SerializeField]
	private ArmorPickupItem.Category _armorPoints;

	// Token: 0x0200021F RID: 543
	public enum Category
	{
		// Token: 0x04000D51 RID: 3409
		Gold,
		// Token: 0x04000D52 RID: 3410
		Silver,
		// Token: 0x04000D53 RID: 3411
		Bronze
	}
}
