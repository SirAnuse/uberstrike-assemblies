using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200021D RID: 541
public class AmmoPickupItem : PickupItem
{
	// Token: 0x06000F00 RID: 3840 RVA: 0x00063728 File Offset: 0x00061928
	protected override bool OnPlayerPickup()
	{
		bool flag = AmmoDepot.CanAddAmmo(this._ammoType);
		if (flag)
		{
			AmmoDepot.AddDefaultAmmoOfType(this._ammoType);
			switch (this._ammoType)
			{
			case AmmoType.Cannon:
				GameData.Instance.OnItemPickup.Fire("Cannon Rockets", PickUpMessageType.AmmoCannon);
				break;
			case AmmoType.Handgun:
				GameData.Instance.OnItemPickup.Fire("Handgun Rounds", PickUpMessageType.AmmoHandgun);
				break;
			case AmmoType.Launcher:
				GameData.Instance.OnItemPickup.Fire("Launcher Grenades", PickUpMessageType.AmmoLauncher);
				break;
			case AmmoType.Machinegun:
				GameData.Instance.OnItemPickup.Fire("Machinegun Ammo", PickUpMessageType.AmmoMachinegun);
				break;
			case AmmoType.Shotgun:
				GameData.Instance.OnItemPickup.Fire("Shotgun Shells", PickUpMessageType.AmmoShotgun);
				break;
			case AmmoType.Snipergun:
				GameData.Instance.OnItemPickup.Fire("Sniper Bullets", PickUpMessageType.AmmoSnipergun);
				break;
			case AmmoType.Splattergun:
				GameData.Instance.OnItemPickup.Fire("Splattergun Cells", PickUpMessageType.AmmoSplattergun);
				break;
			}
			base.PlayLocalPickupSound(GameAudio.AmmoPickup2D);
			UberstrikeItemClass uberstrikeItemClass;
			if (AmmoDepot.TryGetAmmoTypeFromItemClass(this._ammoType, out uberstrikeItemClass))
			{
				GameState.Current.Actions.PickupPowerup(base.PickupID, PickupItemType.Ammo, (int)((byte)uberstrikeItemClass));
			}
			if (GameState.Current.IsSinglePlayer)
			{
				base.StartCoroutine(base.StartHidingPickupForSeconds(this._respawnTime));
			}
		}
		return flag;
	}

	// Token: 0x06000F01 RID: 3841 RVA: 0x0000AC94 File Offset: 0x00008E94
	protected override void OnRemotePickup()
	{
		base.PlayRemotePickupSound(GameAudio.AmmoPickup, base.transform.position);
	}

	// Token: 0x17000384 RID: 900
	// (get) Token: 0x06000F02 RID: 3842 RVA: 0x0000ACAC File Offset: 0x00008EAC
	protected override bool CanPlayerPickup
	{
		get
		{
			return AmmoDepot.CanAddAmmo(this._ammoType);
		}
	}

	// Token: 0x04000D4E RID: 3406
	[SerializeField]
	private AmmoType _ammoType;
}
