using System;
using UnityEngine;

// Token: 0x020000D9 RID: 217
public class DebugGameState : IDebugPage
{
	// Token: 0x1700023C RID: 572
	// (get) Token: 0x060007AE RID: 1966 RVA: 0x00006EBC File Offset: 0x000050BC
	public string Title
	{
		get
		{
			return "States";
		}
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x00034B94 File Offset: 0x00032D94
	public void Draw()
	{
		if (GameState.Current != null)
		{
			this.v1 = GUILayout.BeginScrollView(this.v1, new GUILayoutOption[0]);
			GUILayout.Label(string.Concat(new object[]
			{
				"Mode:",
				GameState.Current.RoomData.GameMode,
				"/",
				Singleton<GameStateController>.Instance.CurrentGameMode
			}), new GUILayoutOption[0]);
			GUILayout.Label("MatchState:" + GameState.Current.MatchState.CurrentStateId, new GUILayoutOption[0]);
			GUILayout.Label("PlayerState:" + GameState.Current.PlayerState.CurrentStateId, new GUILayoutOption[0]);
			if (GameState.Current.RoomData.Server != null)
			{
				GUILayout.Label(string.Concat(new object[]
				{
					"Server:",
					GameState.Current.RoomData.Server,
					"/",
					GameState.Current.RoomData.Number
				}), new GUILayoutOption[0]);
			}
			GUILayout.Label("IsSpectator:" + GameState.Current.PlayerData.IsSpectator, new GUILayoutOption[0]);
			GUILayout.Label("HasJoinedGame:" + GameState.Current.HasJoinedGame, new GUILayoutOption[0]);
			GUILayout.Label("IsMatchRunning:" + GameState.Current.IsMatchRunning, new GUILayoutOption[0]);
			GUILayout.Label("CameraMode:" + LevelCamera.CurrentMode, new GUILayoutOption[0]);
			GUILayout.Space(10f);
			GUILayout.Label("IsInputEnabled:" + AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled, new GUILayoutOption[0]);
			GUILayout.Label("lockCursor:" + Screen.lockCursor, new GUILayoutOption[0]);
			GUILayout.Label(string.Concat(new object[]
			{
				"Mouse:",
				UserInput.Mouse,
				" ",
				UserInput.Rotation
			}), new GUILayoutOption[0]);
			GUILayout.Label("KeyState:" + GameState.Current.PlayerData.KeyState, new GUILayoutOption[0]);
			GUILayout.Label("MovementState:" + GameState.Current.PlayerData.MovementState, new GUILayoutOption[0]);
			GUILayout.Label("IsWalkingEnabled:" + GameState.Current.Player.IsWalkingEnabled, new GUILayoutOption[0]);
			GUILayout.Label("WeaponCamera:" + GameState.Current.Player.WeaponCamera.IsEnabled, new GUILayoutOption[0]);
			GUILayout.Label("Weapons:" + GameState.Current.Player.EnableWeaponControl, new GUILayoutOption[0]);
			GUILayout.Space(10f);
			GUILayout.Label("GameTime:" + GameState.Current.GameTime.ToString("N2"), new GUILayoutOption[0]);
			GUILayout.Label("Latency:" + Singleton<GameStateController>.Instance.Client.Peer.RoundTripTime.ToString("N0"), new GUILayoutOption[0]);
			GUILayout.EndScrollView();
		}
	}

	// Token: 0x040006A9 RID: 1705
	private Vector2 v1;
}
