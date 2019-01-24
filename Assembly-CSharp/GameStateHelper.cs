using System;
using System.Collections.Generic;
using System.Linq;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000204 RID: 516
internal static class GameStateHelper
{
	// Token: 0x06000E4B RID: 3659 RVA: 0x00061C24 File Offset: 0x0005FE24
	public static bool IsLocalConnection(ConnectionAddress address)
	{
		return address.IpAddress.StartsWith("10.") || address.IpAddress.StartsWith("172.16.") || address.IpAddress.StartsWith("192.168.") || address.IpAddress.StartsWith("127.");
	}

	// Token: 0x06000E4C RID: 3660 RVA: 0x0000A6B9 File Offset: 0x000088B9
	public static void UpdateMatchTime()
	{
		GameState.Current.PlayerData.RemainingTime.Value = GameState.Current.RoomData.TimeLimit - Mathf.CeilToInt(GameState.Current.GameTime);
	}

	// Token: 0x06000E4D RID: 3661 RVA: 0x00061C84 File Offset: 0x0005FE84
	public static void EnterGameMode()
	{
		TabScreenPanelGUI.SetGameName(GameState.Current.RoomData.Name);
		TabScreenPanelGUI.SetServerName(Singleton<GameServerManager>.Instance.GetServerName(GameState.Current.RoomData));
		LevelCamera.SetLevelCamera(GameState.Current.Map.Camera, GameState.Current.Map.DefaultViewPoint.position, GameState.Current.Map.DefaultViewPoint.rotation);
		GameState.Current.Player.SetEnabled(true);
		GameState.Current.UpdateTeamCounter();
	}

	// Token: 0x06000E4E RID: 3662 RVA: 0x00061D14 File Offset: 0x0005FF14
	public static void ExitGameMode()
	{
		GameData.Instance.GameState.Value = GameStateId.None;
		GameData.Instance.PlayerState.Value = PlayerStateId.None;
		GameState.Current.Reset();
		Singleton<WeaponController>.Instance.StopInputHandler();
		Singleton<QuickItemController>.Instance.Clear();
		Singleton<ProjectileManager>.Instance.Clear();
		GameData.Instance.OnHUDChatClear.Fire();
		GameData.Instance.OnHUDChatClear.Fire();
		GameData.Instance.OnHUDStreamClear.Fire();
		Singleton<ChatManager>.Instance.UpdateLastgamePlayers();
		if (GameState.Current.Avatar != null)
		{
			GameState.Current.Avatar.CleanupRagdoll();
		}
		if (GameState.Current.Player.Character)
		{
			GameState.Current.Player.Character.Destroy();
			GameState.Current.Player.SetCurrentCharacterConfig(null);
		}
		GameState.Current.Player.SetEnabled(false);
	}

	// Token: 0x06000E4F RID: 3663 RVA: 0x00061E0C File Offset: 0x0006000C
	public static void OnPlayerChangeTeam(int cmid, TeamID team)
	{
		GameActorInfo gameActorInfo;
		if (GameState.Current.TryGetActorInfo(cmid, out gameActorInfo))
		{
			gameActorInfo.TeamID = team;
			GameState.Current.UpdateTeamCounter();
			if (cmid == PlayerDataManager.Cmid)
			{
				GameState.Current.PlayerData.Player.TeamID = team;
				GameState.Current.PlayerData.FocusedPlayerTeam.Value = TeamID.NONE;
				GameState.Current.PlayerData.Team.Value = team;
			}
			string arg = (team != TeamID.BLUE) ? LocalizedStrings.Red : LocalizedStrings.Blue;
			GameData.Instance.OnHUDStreamMessage.Fire(gameActorInfo, string.Format(LocalizedStrings.ChangingToTeamN, arg), null);
		}
	}

	// Token: 0x06000E50 RID: 3664 RVA: 0x00061EBC File Offset: 0x000600BC
	public static bool CanChangeTeam()
	{
		if (GameState.Current.GameMode == GameModeType.DeathMatch)
		{
			return false;
		}
		int num = 0;
		int num2 = 0;
		foreach (GameActorInfo gameActorInfo in GameState.Current.Players.Values)
		{
			if (gameActorInfo.TeamID == TeamID.BLUE)
			{
				num++;
			}
			if (gameActorInfo.TeamID == TeamID.RED)
			{
				num2++;
			}
		}
		return (GameState.Current.PlayerData.Player.TeamID != TeamID.BLUE) ? (num < num2) : (num > num2);
	}

	// Token: 0x06000E51 RID: 3665 RVA: 0x00061F78 File Offset: 0x00060178
	public static void SortDeathMatchPlayers(IEnumerable<GameActorInfo> toBeSortedPlayers)
	{
		List<GameActorInfo> list = (from a in toBeSortedPlayers
		where a.TeamID == TeamID.NONE
		select a).ToList<GameActorInfo>();
		list.Sort(new GameStateHelper.KillSorter());
		TabScreenPanelGUI.SetPlayerListAll(list);
	}

	// Token: 0x06000E52 RID: 3666 RVA: 0x00061FC0 File Offset: 0x000601C0
	public static void SortTeamMatchPlayers(IEnumerable<GameActorInfo> toBeSortedPlayers)
	{
		List<GameActorInfo> list = (from a in toBeSortedPlayers
		where a.TeamID == TeamID.BLUE
		select a).ToList<GameActorInfo>();
		List<GameActorInfo> list2 = (from a in toBeSortedPlayers
		where a.TeamID == TeamID.RED
		select a).ToList<GameActorInfo>();
		list.Sort(new GameStateHelper.KillSorter());
		list2.Sort(new GameStateHelper.KillSorter());
		TabScreenPanelGUI.SetPlayerListBlue(list);
		TabScreenPanelGUI.SetPlayerListRed(list2);
	}

	// Token: 0x06000E53 RID: 3667 RVA: 0x00062044 File Offset: 0x00060244
	public static byte GetDamageDirectionAngle(Vector3 direction)
	{
		byte result = 0;
		Vector3 normalized = direction.normalized;
		normalized.y = 0f;
		if (normalized.magnitude != 0f)
		{
			result = Conversion.Angle2Byte(Quaternion.LookRotation(normalized).eulerAngles.y);
		}
		return result;
	}

	// Token: 0x06000E54 RID: 3668 RVA: 0x00062098 File Offset: 0x00060298
	public static void PlayerHit(int targetCmid, ushort damage, BodyPart part, Vector3 force)
	{
		PlayerData playerData = GameState.Current.PlayerData;
		short num;
		byte b;
		playerData.GetArmorDamage((short)damage, part, out num, out b);
		playerData.Health.Value -= (int)num;
		playerData.ArmorPoints.Value -= (int)b;
		GameState.Current.Player.MoveController.ApplyForce(force, CharacterMoveController.ForceType.Additive);
	}

	// Token: 0x06000E55 RID: 3669 RVA: 0x000620FC File Offset: 0x000602FC
	public static void RespawnLocalPlayerAtRandom()
	{
		Vector3 position;
		Quaternion rotation;
		Singleton<SpawnPointManager>.Instance.GetRandomSpawnPoint(GameState.Current.GameMode, GameState.Current.PlayerData.Player.TeamID, out position, out rotation);
		GameState.Current.RespawnLocalPlayerAt(position, rotation);
	}

	// Token: 0x06000E56 RID: 3670 RVA: 0x00062144 File Offset: 0x00060344
	public static string GetModeName(GameModeType gameMode)
	{
		switch (gameMode)
		{
		case GameModeType.DeathMatch:
			return LocalizedStrings.DeathMatch;
		case GameModeType.TeamDeathMatch:
			return LocalizedStrings.TeamDeathMatch;
		case GameModeType.EliminationMode:
			return LocalizedStrings.TeamElimination;
		default:
			return LocalizedStrings.TrainingCaps;
		}
	}

	// Token: 0x06000E57 RID: 3671 RVA: 0x00062184 File Offset: 0x00060384
	internal static void OnChatMessage(int cmid, string name, string message, MemberAccessLevel accessLevel, byte context)
	{
		if (ChatManager.CanShowMessage((ChatContext)context))
		{
			GameData.Instance.OnHUDChatMessage.Fire(name, message, accessLevel);
		}
		Singleton<ChatManager>.Instance.InGameDialog.AddMessage(new InstantMessage(cmid, name, message, accessLevel, (ChatContext)context));
	}

	// Token: 0x02000205 RID: 517
	private class KillSorter : Comparer<GameActorInfo>
	{
		// Token: 0x06000E5C RID: 3676 RVA: 0x000621CC File Offset: 0x000603CC
		public override int Compare(GameActorInfo x, GameActorInfo y)
		{
			int num = (int)(y.Kills - x.Kills);
			if (num == 0)
			{
				num = (int)(x.Deaths - y.Deaths);
			}
			return num;
		}
	}
}
