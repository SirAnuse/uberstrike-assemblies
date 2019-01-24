using System;
using UberStrike.Core.Models;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020000E0 RID: 224
public class DebugPlayerManager : IDebugPage
{
	// Token: 0x17000242 RID: 578
	// (get) Token: 0x060007C6 RID: 1990 RVA: 0x00006F3C File Offset: 0x0000513C
	public string Title
	{
		get
		{
			return "Players";
		}
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x0003567C File Offset: 0x0003387C
	public void Draw()
	{
		this.v1 = GUILayout.BeginScrollView(this.v1, new GUILayoutOption[0]);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		foreach (GameActorInfo gameActorInfo in GameState.Current.Players.Values)
		{
			ICharacterState characterState = GameState.Current.RemotePlayerStates.GetState(gameActorInfo.PlayerId);
			if (gameActorInfo.Cmid == PlayerDataManager.Cmid)
			{
				characterState = GameState.Current.PlayerData;
			}
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.Label(gameActorInfo.ToCustomString(), new GUILayoutOption[0]);
			if (characterState != null)
			{
				GUILayout.Label("Keys: " + CmunePrint.Flag<KeyState>(characterState.KeyState), new GUILayoutOption[0]);
				GUILayout.Label("Move: " + CmunePrint.Flag<MoveStates>(characterState.MovementState), new GUILayoutOption[0]);
				float num = Mathf.Clamp(characterState.VerticalRotation + 90f, 0f, 180f) / 180f;
				GUILayout.Label(string.Concat(new object[]
				{
					"Rotation: ",
					characterState.HorizontalRotation,
					"/",
					characterState.VerticalRotation.ToString("f2"),
					"/",
					num.ToString("f2")
				}), new GUILayoutOption[0]);
				GUILayout.Label("Position: " + characterState.Position, new GUILayoutOption[0]);
				GUILayout.Label("Velocity: " + characterState.Velocity, new GUILayoutOption[0]);
			}
			GUI.contentColor = ((gameActorInfo.TeamID != TeamID.RED) ? ((gameActorInfo.TeamID != TeamID.BLUE) ? Color.white : Color.blue) : Color.red);
			GUILayout.Label("AVATAR: " + GameState.Current.Avatars.ContainsKey(gameActorInfo.Cmid), new GUILayoutOption[0]);
			if (gameActorInfo.Cmid != PlayerDataManager.Cmid && GUILayout.Button("Kick", new GUILayoutOption[0]))
			{
				GameState.Current.Actions.KickPlayer(gameActorInfo.Cmid);
			}
			GUI.contentColor = Color.white;
			GUILayout.EndVertical();
		}
		GUILayout.EndHorizontal();
		GUILayout.EndScrollView();
	}

	// Token: 0x040006AF RID: 1711
	private Vector2 v1;
}
