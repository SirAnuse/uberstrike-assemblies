using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200037A RID: 890
public class GameActions
{
	// Token: 0x0600194C RID: 6476 RVA: 0x00087444 File Offset: 0x00085644
	public void Clear()
	{
		this.JoinTeam = delegate(TeamID A_0)
		{
		};
		this.ChangeTeam = delegate()
		{
		};
		this.RequestRespawn = delegate()
		{
		};
		this.PickupPowerup = delegate(int A_0, PickupItemType A_1, int A_2)
		{
		};
		this.OpenDoor = delegate(int A_0)
		{
		};
		this.SingleBulletFire = delegate()
		{
		};
		this.EmitProjectile = delegate(Vector3 A_0, Vector3 A_1, global::LoadoutSlotType A_2, int A_3, bool A_4)
		{
		};
		this.RemoveProjectile = delegate(int A_0, bool A_1)
		{
		};
		this.DirectHitDamage = delegate(int A_0, ushort A_1, BodyPart A_2, Vector3 A_3, byte A_4, byte A_5)
		{
		};
		this.ExplosionHitDamage = delegate(int A_0, ushort A_1, Vector3 A_2, byte A_3, byte A_4)
		{
		};
		this.PlayerHitFeeback = delegate(int A_0, Vector3 A_1)
		{
		};
		this.EmitQuickItem = delegate(Vector3 A_0, Vector3 A_1, int A_2, byte A_3, int A_4)
		{
		};
		this.ActivateQuickItem = delegate(QuickItemLogic A_0, int A_1, int A_2, bool A_3)
		{
		};
		this.IncreaseHealthAndArmor = delegate(int A_0, int A_1)
		{
		};
		this.JoinAsSpectator = delegate()
		{
		};
		this.KickPlayer = delegate(int A_0)
		{
		};
		this.ChatMessage = delegate(string A_0, byte A_1)
		{
		};
		this.KillPlayer = delegate()
		{
		};
	}

	// Token: 0x04001779 RID: 6009
	public Action<TeamID> JoinTeam;

	// Token: 0x0400177A RID: 6010
	public Action ChangeTeam;

	// Token: 0x0400177B RID: 6011
	public Action RequestRespawn;

	// Token: 0x0400177C RID: 6012
	public Action<int, PickupItemType, int> PickupPowerup;

	// Token: 0x0400177D RID: 6013
	public Action<int> OpenDoor;

	// Token: 0x0400177E RID: 6014
	public Action SingleBulletFire;

	// Token: 0x0400177F RID: 6015
	public Action<Vector3, Vector3, global::LoadoutSlotType, int, bool> EmitProjectile;

	// Token: 0x04001780 RID: 6016
	public Action<int, bool> RemoveProjectile;

	// Token: 0x04001781 RID: 6017
	public Action<int, ushort, BodyPart, Vector3, byte, byte> DirectHitDamage;

	// Token: 0x04001782 RID: 6018
	public Action<int, ushort, Vector3, byte, byte> ExplosionHitDamage;

	// Token: 0x04001783 RID: 6019
	public Action<int, Vector3> PlayerHitFeeback;

	// Token: 0x04001784 RID: 6020
	public Action<Vector3, Vector3, int, byte, int> EmitQuickItem;

	// Token: 0x04001785 RID: 6021
	public Action<QuickItemLogic, int, int, bool> ActivateQuickItem;

	// Token: 0x04001786 RID: 6022
	public Action<int, int> IncreaseHealthAndArmor;

	// Token: 0x04001787 RID: 6023
	public Action JoinAsSpectator;

	// Token: 0x04001788 RID: 6024
	public Action<int> KickPlayer;

	// Token: 0x04001789 RID: 6025
	public Action<string, byte> ChatMessage;

	// Token: 0x0400178A RID: 6026
	public Action KillPlayer;
}
