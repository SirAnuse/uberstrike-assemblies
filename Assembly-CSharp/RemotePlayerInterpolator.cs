using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000392 RID: 914
public class RemotePlayerInterpolator
{
	// Token: 0x06001B07 RID: 6919 RVA: 0x00011F67 File Offset: 0x00010167
	public RemotePlayerInterpolator()
	{
		this.remoteStates = new Dictionary<byte, RemoteCharacterState>(20);
	}

	// Token: 0x06001B08 RID: 6920 RVA: 0x0008BE70 File Offset: 0x0008A070
	public void Update()
	{
		foreach (RemoteCharacterState remoteCharacterState in this.remoteStates.Values)
		{
			remoteCharacterState.InterpolateMovement();
		}
	}

	// Token: 0x06001B09 RID: 6921 RVA: 0x0008BED0 File Offset: 0x0008A0D0
	public void PositionUpdate(PlayerMovement update, ushort gameFrame)
	{
		RemoteCharacterState remoteCharacterState;
		if (this.remoteStates.TryGetValue(update.Number, out remoteCharacterState))
		{
			remoteCharacterState.PositionUpdate(update, gameFrame);
		}
	}

	// Token: 0x06001B0A RID: 6922 RVA: 0x0008BF00 File Offset: 0x0008A100
	public void DeltaUpdate(GameActorInfoDelta delta)
	{
		RemoteCharacterState remoteCharacterState;
		if (this.remoteStates.TryGetValue(delta.Id, out remoteCharacterState))
		{
			remoteCharacterState.DeltaUpdate(delta);
		}
	}

	// Token: 0x06001B0B RID: 6923 RVA: 0x0008BF2C File Offset: 0x0008A12C
	public void UpdatePositionHard(byte playerNumber, Vector3 pos)
	{
		RemoteCharacterState remoteCharacterState;
		if (this.remoteStates.TryGetValue(playerNumber, out remoteCharacterState))
		{
			remoteCharacterState.SetPosition(pos);
		}
	}

	// Token: 0x06001B0C RID: 6924 RVA: 0x00011F7C File Offset: 0x0001017C
	public void AddCharacterInfo(GameActorInfo player, PlayerMovement position)
	{
		this.remoteStates[player.PlayerId] = new RemoteCharacterState(player, position);
	}

	// Token: 0x06001B0D RID: 6925 RVA: 0x00011F96 File Offset: 0x00010196
	public void Reset()
	{
		this.remoteStates.Clear();
	}

	// Token: 0x06001B0E RID: 6926 RVA: 0x0008BF54 File Offset: 0x0008A154
	public void RemoveCharacterInfo(byte playerID)
	{
		RemoteCharacterState remoteCharacterState;
		if (this.remoteStates.TryGetValue(playerID, out remoteCharacterState))
		{
			this.remoteStates.Remove(remoteCharacterState.Player.PlayerId);
		}
	}

	// Token: 0x06001B0F RID: 6927 RVA: 0x0008BF8C File Offset: 0x0008A18C
	public RemoteCharacterState GetState(byte playerID)
	{
		RemoteCharacterState result = null;
		this.remoteStates.TryGetValue(playerID, out result);
		return result;
	}

	// Token: 0x0400182D RID: 6189
	private Dictionary<byte, RemoteCharacterState> remoteStates;
}
