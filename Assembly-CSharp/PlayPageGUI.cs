using System;
using System.Collections.Generic;
using Cmune.Core.Models;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020001A4 RID: 420
public class PlayPageGUI : MonoBehaviour
{
	// Token: 0x1700030F RID: 783
	// (get) Token: 0x06000B91 RID: 2961 RVA: 0x00009177 File Offset: 0x00007377
	// (set) Token: 0x06000B92 RID: 2962 RVA: 0x0000917E File Offset: 0x0000737E
	public static PlayPageGUI Instance { get; private set; }

	// Token: 0x06000B93 RID: 2963 RVA: 0x00049DBC File Offset: 0x00047FBC
	private void Awake()
	{
		PlayPageGUI.Instance = this;
		this._filterSavedData = new PlayPageGUI.FilterSavedData();
		this._cachedGameList = new List<GameRoomData>();
		this._sortGamesAscending = false;
		this._gameSortingMethod = new GameDataPlayerComparer();
		this._lastSortedColumn = PlayPageGUI.GameListColumns.PlayerCount;
		this._searchBar = new SearchBarGUI("SearchGame");
		if (this._privateGameIcon == null)
		{
			throw new Exception("_privateGameIcon not assigned");
		}
	}

	// Token: 0x06000B94 RID: 2964 RVA: 0x00049E2C File Offset: 0x0004802C
	private void Start()
	{
		this._weaponClassTexts = new string[]
		{
			LocalizedStrings.Machineguns,
			LocalizedStrings.SniperRifles,
			LocalizedStrings.Shotguns,
			LocalizedStrings.Launchers
		};
		this._modesFilter = new string[]
		{
			LocalizedStrings.All + " Modes",
			LocalizedStrings.DeathMatch,
			LocalizedStrings.TeamDeathMatch,
			LocalizedStrings.TeamElimination
		};
		List<string> list = new List<string>();
		list.Add(LocalizedStrings.All + " Maps");
		foreach (UberstrikeMap uberstrikeMap in Singleton<MapManager>.Instance.AllMaps)
		{
			if (uberstrikeMap.Id != 0)
			{
				list.Add(uberstrikeMap.Name);
			}
		}
		list.RemoveAll((string s) => string.IsNullOrEmpty(s));
		this._mapsFilter = list.ToArray();
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x00009186 File Offset: 0x00007386
	private void OnEnable()
	{
		this._showFilters = false;
		this.ResetFilters();
		this._unFocus = true;
		this._currentSelectedServer = Singleton<GameServerController>.Instance.SelectedServer;
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x00049F44 File Offset: 0x00048144
	private void OnGUI()
	{
		GUI.depth = 11;
		GUI.skin = BlueStonez.Skin;
		if (this._unFocus)
		{
			if (GUIUtility.keyboardControl != 0)
			{
				GUIUtility.keyboardControl = 0;
			}
			this._unFocus = false;
		}
		Rect rect = new Rect(0f, (float)GlobalUIRibbon.Instance.Height(), (float)Screen.width, (float)(Screen.height - GlobalUIRibbon.Instance.Height()));
		GUI.Box(rect, string.Empty, BlueStonez.box_grey31);
		if (Singleton<GameServerController>.Instance.SelectedServer != null)
		{
			this.DoGamePage(rect);
		}
		else
		{
			this.DoServerPage(rect);
		}
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x00049FEC File Offset: 0x000481EC
	private void ResetFilters()
	{
		this._currentMap = 0;
		this._currentMode = 0;
		this._currentWeapon = 0;
		this._noFriendFire = false;
		this._gameNotFull = false;
		this._noPrivateGames = false;
		this._instasplat = false;
		this._lowGravity = false;
		this._justForFun = false;
		this._singleWeapon = false;
		this._searchBar.ClearFilter();
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x0004A04C File Offset: 0x0004824C
	private void DoServerPage(Rect rect)
	{
		float num = 200f;
		GUI.BeginGroup(rect);
		GUI.Label(new Rect(0f, 0f, rect.width, 56f), LocalizedStrings.ChooseYourRegionCaps, BlueStonez.tab_strip);
		GUI.Box(new Rect(0f, 55f, rect.width, rect.height - 57f), string.Empty, BlueStonez.window_standard_grey38);
		GUI.color = new Color(1f, 1f, 1f, 0.5f);
		GUI.Label(new Rect(0f, 28f, rect.width - 5f, 28f), string.Format("{0} {1}, {2} {3} ", new object[]
		{
			Singleton<GameServerManager>.Instance.AllPlayersCount,
			LocalizedStrings.PlayersOnline,
			Singleton<GameServerManager>.Instance.AllGamesCount,
			LocalizedStrings.Games
		}), BlueStonez.label_interparkbold_18pt_right);
		GUI.color = Color.white;
		bool enabled = GUI.enabled;
		GUI.enabled = (enabled && Time.time > this._nextServerCheckTime);
		if (GUITools.Button(new Rect(rect.width - 150f, 6f, 140f, 23f), new GUIContent(LocalizedStrings.Refresh), BlueStonez.buttondark_medium))
		{
			this.RefreshServerLoad();
		}
		GUI.enabled = enabled;
		this.DoServerList(new Rect(10f, 55f, rect.width - num - 10f, rect.height - 49f));
		this.DoServerHelpText(new Rect(rect.width - num, 55f, num - 10f, rect.height - 49f));
		if (GUITools.Button(new Rect(rect.width - 180f, rect.height - 42f, 160f, 32f), new GUIContent(LocalizedStrings.ExploreMaps), BlueStonez.button_white))
		{
			MenuPageManager.Instance.LoadPage(PageType.Training, false);
		}
		GUI.EndGroup();
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x0004A270 File Offset: 0x00048470
	private void DoServerHelpText(Rect position)
	{
		GUI.BeginGroup(position);
		GUI.Box(new Rect(0f, 0f, position.width, 32f), LocalizedStrings.HelpCaps, BlueStonez.box_grey50);
		GUI.Box(new Rect(0f, 31f, position.width, position.height - 31f - 55f), string.Empty, BlueStonez.box_grey50);
		this._serverSelectionHelpScrollBar = GUITools.BeginScrollView(new Rect(0f, 33f, position.width, position.height - 31f - 60f), this._serverSelectionHelpScrollBar, new Rect(0f, 0f, position.width - 20f, 400f), false, false, true);
		this.DrawGroupLabel(new Rect(5f, 5f, position.width - 25f, 100f), "1. " + LocalizedStrings.ServerName, LocalizedStrings.ServerNameDesc);
		this.DrawGroupLabel(new Rect(5f, 105f, position.width - 25f, 70f), "2. " + LocalizedStrings.Capacity, LocalizedStrings.CapacityDesc);
		this.DrawGroupLabel(new Rect(5f, 180f, position.width - 25f, 180f), "3. " + LocalizedStrings.Speed, LocalizedStrings.SpeedDesc);
		GUITools.EndScrollView();
		GUI.EndGroup();
	}

	// Token: 0x06000B9A RID: 2970 RVA: 0x0004A400 File Offset: 0x00048600
	private void DoServerList(Rect position)
	{
		this._serverNameColumnWidth = position.width - 130f - 110f - 130f + 1f - 20f;
		GUI.BeginGroup(position);
		GUI.Box(new Rect(0f, 0f, this._serverNameColumnWidth + 1f, 32f), string.Empty, BlueStonez.box_grey50);
		GUI.Box(new Rect(this._serverNameColumnWidth, 0f, 131f, 32f), string.Empty, BlueStonez.box_grey50);
		GUI.Box(new Rect(this._serverNameColumnWidth + 130f, 0f, 111f, 32f), string.Empty, BlueStonez.box_grey50);
		GUI.Box(new Rect(this._serverNameColumnWidth + 130f + 130f - 20f, 0f, 150f, 32f), string.Empty, BlueStonez.box_grey50);
		GUI.Box(new Rect(0f, 31f, position.width + 1f, position.height - 31f - 55f), string.Empty, BlueStonez.box_grey50);
		if (this._lastSortedServerColumn == PlayPageGUI.ServerListColumns.ServerName)
		{
			if (this._sortServerAscending)
			{
				GUI.Label(new Rect(5f, 0f, this._serverNameColumnWidth + 1f - 5f, 32f), new GUIContent(LocalizedStrings.ServerName, this._sortUpArrow), BlueStonez.label_interparkbold_18pt_left);
			}
			else
			{
				GUI.Label(new Rect(5f, 0f, this._serverNameColumnWidth + 1f - 5f, 32f), new GUIContent(LocalizedStrings.ServerName, this._sortDownArrow), BlueStonez.label_interparkbold_18pt_left);
			}
		}
		else
		{
			GUI.Label(new Rect(12f, 0f, this._serverNameColumnWidth + 1f - 5f, 32f), LocalizedStrings.ServerName, BlueStonez.label_interparkbold_18pt_left);
		}
		if (GUI.Button(new Rect(0f, 0f, this._serverNameColumnWidth + 1f - 5f, 32f), GUIContent.none, BlueStonez.label_interparkbold_11pt_left))
		{
			this.SortServerList(PlayPageGUI.ServerListColumns.ServerName, true);
		}
		if (this._lastSortedServerColumn == PlayPageGUI.ServerListColumns.ServerCapacity)
		{
			if (this._sortServerAscending)
			{
				GUI.Label(new Rect(5f + this._serverNameColumnWidth, 0f, 126f, 32f), new GUIContent(LocalizedStrings.Capacity, this._sortUpArrow), BlueStonez.label_interparkbold_18pt_left);
			}
			else
			{
				GUI.Label(new Rect(5f + this._serverNameColumnWidth, 0f, 126f, 32f), new GUIContent(LocalizedStrings.Capacity, this._sortDownArrow), BlueStonez.label_interparkbold_18pt_left);
			}
		}
		else
		{
			GUI.Label(new Rect(this._serverNameColumnWidth + 12f, 0f, 126f, 32f), LocalizedStrings.Capacity, BlueStonez.label_interparkbold_18pt_left);
		}
		if (GUI.Button(new Rect(this._serverNameColumnWidth, 0f, 126f, 32f), GUIContent.none, BlueStonez.label_interparkbold_11pt_left))
		{
			this.SortServerList(PlayPageGUI.ServerListColumns.ServerCapacity, true);
		}
		if (this._lastSortedServerColumn == PlayPageGUI.ServerListColumns.ServerSpeed)
		{
			if (this._sortServerAscending)
			{
				GUI.Label(new Rect(5f + this._serverNameColumnWidth + 130f, 0f, 105f, 32f), new GUIContent(LocalizedStrings.Speed, this._sortUpArrow), BlueStonez.label_interparkbold_18pt_left);
			}
			else
			{
				GUI.Label(new Rect(5f + this._serverNameColumnWidth + 130f, 0f, 105f, 32f), new GUIContent(LocalizedStrings.Speed, this._sortDownArrow), BlueStonez.label_interparkbold_18pt_left);
			}
		}
		else
		{
			GUI.Label(new Rect(this._serverNameColumnWidth + 130f + 12f, 0f, 105f, 32f), LocalizedStrings.Speed, BlueStonez.label_interparkbold_18pt_left);
		}
		if (GUI.Button(new Rect(this._serverNameColumnWidth + 130f, 0f, 105f, 32f), GUIContent.none, BlueStonez.label_interparkbold_11pt_left))
		{
			this.SortServerList(PlayPageGUI.ServerListColumns.ServerSpeed, true);
		}
		this.DrawAllServers(position);
		GUI.EndGroup();
	}

	// Token: 0x06000B9B RID: 2971 RVA: 0x0004A870 File Offset: 0x00048A70
	private void DrawProgressBarLarge(Rect position, float amount)
	{
		amount = Mathf.Clamp01(amount);
		GUI.Box(new Rect(position.x, position.y, position.width, 23f), GUIContent.none, BlueStonez.progressbar_large_background);
		GUI.color = ColorScheme.ProgressBar;
		GUI.Box(new Rect(position.x + 2f, position.y + 2f, (float)Mathf.RoundToInt((position.width - 4f) * amount), 19f), GUIContent.none, BlueStonez.progressbar_large_thumb);
		GUI.color = Color.white;
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x0004A910 File Offset: 0x00048B10
	private void DrawAllServers(Rect pos)
	{
		int num = Singleton<GameServerManager>.Instance.PhotonServerCount * 48;
		GUI.color = Color.white;
		this._serverSelectionScrollBar = GUITools.BeginScrollView(new Rect(0f, 31f, pos.width + 1f, pos.height - 31f - 55f), this._serverSelectionScrollBar, new Rect(0f, 0f, pos.width - 20f, (float)num), false, false, true);
		List<string> list = new List<string>();
		int num2 = 0;
		string text = string.Empty;
		foreach (PhotonServer photonServer in Singleton<GameServerManager>.Instance.PhotonServerList)
		{
			GUI.BeginGroup(new Rect(0f, (float)(num2 * 48), pos.width + 2f, 49f), BlueStonez.box_grey50);
			if (photonServer == this._currentSelectedServer)
			{
				GUI.color = new Color(1f, 1f, 1f, 0.03f);
				GUI.DrawTexture(new Rect(1f, 0f, pos.width + 1f, 49f), UberstrikeIconsHelper.White);
				GUI.color = Color.white;
			}
			photonServer.Flag.Draw(new Rect(5f, 8f, 32f, 32f), false);
			list.Add(photonServer.Flag.Url);
			GUI.Label(new Rect(42f, 1f, this._serverNameColumnWidth + 1f - 42f, 48f), photonServer.Name, BlueStonez.label_interparkbold_16pt_left);
			if (photonServer.Data.State == PhotonServerLoad.Status.Alive)
			{
				GUI.BeginGroup(new Rect(5f + this._serverNameColumnWidth, 0f, 126f, 48f));
				int num3;
				if (PlayerDataManager.AccessLevel == MemberAccessLevel.Admin)
				{
					num3 = photonServer.Data.PlayersConnected;
				}
				else
				{
					num3 = Mathf.Clamp(photonServer.Data.PlayersConnected, 0, (int)photonServer.Data.MaxPlayerCount);
				}
				float amount;
				if ((float)num3 >= photonServer.Data.MaxPlayerCount)
				{
					amount = 1f;
				}
				else
				{
					amount = (float)num3 / photonServer.Data.MaxPlayerCount;
				}
				this.DrawProgressBarLarge(new Rect(2f, 12f, 58f, 20f), amount);
				text = string.Format("{0}/{1}", num3, photonServer.Data.MaxPlayerCount);
				GUI.Label(new Rect(64f, 14f, 60f, 20f), text, BlueStonez.label_interparkmed_10pt_left);
				GUI.EndGroup();
				GUI.BeginGroup(new Rect(5f + this._serverNameColumnWidth + 130f, 0f, 105f - (float)(((float)num <= pos.height - 31f) ? 0 : 21), 48f));
				int latency = photonServer.Latency;
				text = string.Empty;
				if (latency < 100)
				{
					GUI.color = ColorConverter.RgbToColor(80f, 99f, 42f);
					text = LocalizedStrings.FastCaps;
				}
				else if (latency < 300)
				{
					GUI.color = ColorConverter.RgbToColor(234f, 112f, 13f);
					text = LocalizedStrings.MedCaps;
				}
				else
				{
					GUI.color = ColorConverter.RgbToColor(192f, 80f, 70f);
					text = LocalizedStrings.SlowCaps;
				}
				GUI.DrawTexture(new Rect(0f, 14f, 45f, 20f), UberstrikeIconsHelper.White);
				GUI.color = Color.white;
				GUI.Label(new Rect(2f, 14f, 40f, 20f), text, BlueStonez.label_interparkbold_16pt);
				GUI.Label(new Rect(48f, 4f, 40f, 40f), string.Format("{0}ms", latency), BlueStonez.label_interparkmed_10pt_left);
				GUI.EndGroup();
				GUI.BeginGroup(new Rect(5f + this._serverNameColumnWidth + 130f + 130f - 5f, 0f, 125f - (float)(((float)num <= pos.height - 31f) ? 0 : 21), 48f));
				int height = BlueStonez.button.normal.background.height;
				if (GUI.Button(new Rect(2f, (float)(24 - height / 2), 100f, (float)height), LocalizedStrings.JoinCaps, BlueStonez.button_white))
				{
					Singleton<GameServerController>.Instance.SelectedServer = photonServer;
					this.SelectedServerUpdated(photonServer);
					AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.JoinServer, 0UL, 1f, 1f);
				}
				GUI.EndGroup();
			}
			else if (photonServer.Data.State == PhotonServerLoad.Status.None)
			{
				Rect position = new Rect(5f + this._serverNameColumnWidth, 0f, 236f - (float)(((float)num <= pos.height - 31f) ? 0 : 21), 48f);
				GUI.BeginGroup(position);
				GUI.Label(new Rect(0f, 0f, position.width, 48f), LocalizedStrings.RefreshingServer, BlueStonez.label_interparkbold_16pt);
				GUI.EndGroup();
			}
			else if (photonServer.Data.State == PhotonServerLoad.Status.NotReachable)
			{
				Rect position2 = new Rect(5f + this._serverNameColumnWidth, 0f, 236f - (float)(((float)num <= pos.height - 31f) ? 0 : 21), 48f);
				GUI.BeginGroup(position2);
				GUI.Label(new Rect(0f, 0f, position2.width, 48f), LocalizedStrings.ServerIsNotReachable, BlueStonez.label_interparkbold_16pt);
				GUI.EndGroup();
			}
			if (GUI.Button(new Rect(0f, 0f, pos.width + 1f, 49f), GUIContent.none, GUIStyle.none) && photonServer.Data.State != PhotonServerLoad.Status.NotReachable)
			{
				if (this._currentSelectedServer == photonServer && this._serverJoinDoubleClick > Time.time)
				{
					this._serverJoinDoubleClick = 0f;
					this.SelectedServerUpdated(photonServer);
					AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.JoinServer, 0UL, 1f, 1f);
				}
				else
				{
					this._serverJoinDoubleClick = Time.time + 0.5f;
				}
				this._currentSelectedServer = photonServer;
			}
			GUI.EndGroup();
			num2++;
		}
		GUITools.EndScrollView();
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x0004B01C File Offset: 0x0004921C
	public void SelectedServerUpdated(PhotonServer view)
	{
		if (view != null && view.Data.State == PhotonServerLoad.Status.Alive)
		{
			if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
			{
				this.ShowGameSelection(view);
			}
			else if ((float)view.Data.PlayersConnected >= view.Data.MaxPlayerCount)
			{
				PopupSystem.ShowMessage(LocalizedStrings.ServerFull, LocalizedStrings.ServerFullMsg);
			}
			else if (!view.CheckLatency())
			{
				PopupSystem.ShowMessage(LocalizedStrings.Warning, "Your connection to this server is too slow.", PopupSystem.AlertType.OK, null);
			}
			else if (view.Latency >= 300)
			{
				PopupSystem.ShowMessage(LocalizedStrings.Warning, LocalizedStrings.ConnectionSlowMsg, PopupSystem.AlertType.OKCancel, delegate()
				{
					this.ShowGameSelection(view);
				}, LocalizedStrings.OkCaps, null, LocalizedStrings.CancelCaps);
			}
			else
			{
				this.ShowGameSelection(view);
			}
		}
		else
		{
			Debug.LogError("Couldn't connect to server!");
		}
	}

	// Token: 0x06000B9E RID: 2974 RVA: 0x0004B138 File Offset: 0x00049338
	private void DrawGroupLabel(Rect position, string header, string text)
	{
		GUI.color = Color.white;
		GUI.Label(new Rect(position.x, position.y, position.width, 16f), header, BlueStonez.label_interparkbold_13pt);
		GUI.color = new Color(1f, 1f, 1f, 0.8f);
		GUI.Label(new Rect(position.x, position.y + 16f, position.width, position.height - 16f), text, BlueStonez.label_interparkbold_11pt_left_wrap);
		GUI.color = Color.white;
	}

	// Token: 0x06000B9F RID: 2975 RVA: 0x0004B1DC File Offset: 0x000493DC
	private void DoGamePage(Rect rect)
	{
		GUI.BeginGroup(rect);
		GUI.Label(new Rect(0f, 0f, rect.width, 56f), LocalizedStrings.ChooseAGameCaps, BlueStonez.tab_strip);
		GUI.color = new Color(1f, 1f, 1f, 0.5f);
		GUI.Label(new Rect(10f, 28f, rect.width - 37f, 28f), string.Format("{0} ({1}ms)", Singleton<GameServerController>.Instance.SelectedServer.Name, Singleton<GameServerController>.Instance.SelectedServer.Latency.ToString()), BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, 28f, rect.width - 5f, 28f), string.Format("{0} {1}, {2} {3} ", new object[]
		{
			Singleton<GameListManager>.Instance.PlayersCount,
			LocalizedStrings.PlayersOnline,
			this._filteredActiveRoomCount,
			LocalizedStrings.Games
		}), BlueStonez.label_interparkbold_18pt_right);
		GUI.color = Color.white;
		GUI.Box(new Rect(0f, 55f, rect.width, rect.height - 57f), string.Empty, BlueStonez.window_standard_grey38);
		this.DrawQuickSearch(new Rect(rect.width - 150f, 8f, 142f, 20f));
		bool enabled = GUI.enabled;
		GUI.enabled &= (this._dropDownList == 0);
		this.DoGameList(rect);
		this.DoBottomArea(rect);
		GUI.enabled = enabled;
		if (this._showFilters)
		{
			this.DoFilterArea(rect);
		}
		GUI.EndGroup();
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x0004B3A8 File Offset: 0x000495A8
	private void DoGameList(Rect rect)
	{
		this.UpdateColumnWidth();
		int num = Mathf.RoundToInt(rect.height) - 73 - 104;
		if (!this._showFilters)
		{
			num += 73;
		}
		Rect rect2 = new Rect(10f, 55f, rect.width - 20f, (float)num);
		GUI.Box(rect2, string.Empty, BlueStonez.box_grey50);
		GUI.BeginGroup(rect2);
		if (Singleton<GameStateController>.Instance.Client.IsConnected)
		{
			if (!Singleton<GameStateController>.Instance.Client.IsConnectedToLobby)
			{
				GUI.Label(new Rect(0f, rect2.height * 0.5f, rect2.width, 23f), LocalizedStrings.PressRefreshToSeeCurrentGames, BlueStonez.label_interparkmed_11pt);
				if (GUITools.Button(new Rect(rect2.width * 0.5f - 70f, rect2.height * 0.5f - 30f, 140f, 23f), new GUIContent(LocalizedStrings.Refresh), BlueStonez.buttondark_medium))
				{
					Singleton<GameStateController>.Instance.Client.RefreshGameLobby();
					this.RefreshGameList();
				}
			}
			else if (this._cachedGameList.Count == 0)
			{
				GUI.Label(new Rect(0f, 0f, rect2.width, rect2.height - 1f), "No games found.", BlueStonez.label_interparkmed_11pt);
			}
		}
		else
		{
			GUI.Label(new Rect(0f, 0f, rect2.width, rect2.height - 1f), "Lost connection to server.", BlueStonez.label_interparkmed_11pt);
		}
		if (Singleton<GameServerController>.Instance.SelectedServer != null)
		{
			num = 70 * ((this._filteredActiveRoomCount < 0 || this._filteredActiveRoomCount > this._cachedGameList.Count) ? this._cachedGameList.Count : this._filteredActiveRoomCount) + 5;
		}
		else
		{
			num = 0;
		}
		int num2 = 0;
		Texture2D image = (this._lastSortedColumn != PlayPageGUI.GameListColumns.GameMap) ? null : ((!this._sortGamesAscending) ? this._sortDownArrow : this._sortUpArrow);
		int num3 = (this._lastSortedColumn != PlayPageGUI.GameListColumns.GameMap) ? 12 : 5;
		GUI.Box(new Rect((float)num2, 0f, (float)this._mapNameWidth, 25f), string.Empty, BlueStonez.box_grey50);
		GUI.Label(new Rect((float)(num2 + num3), 0f, (float)this._mapNameWidth, 25f), new GUIContent(LocalizedStrings.Map, image), BlueStonez.label_interparkbold_16pt_left);
		if (GUI.Button(new Rect((float)num2, 0f, (float)this._mapNameWidth, 25f), string.Empty, BlueStonez.label_interparkbold_11pt_left))
		{
			this.SortGameList(PlayPageGUI.GameListColumns.GameMap);
		}
		num2 = 108;
		image = ((this._lastSortedColumn != PlayPageGUI.GameListColumns.GameName) ? null : ((!this._sortGamesAscending) ? this._sortDownArrow : this._sortUpArrow));
		num3 = ((this._lastSortedColumn != PlayPageGUI.GameListColumns.GameName) ? 12 : 5);
		GUI.Box(new Rect((float)num2, 0f, (float)this._gameNameWidth, 25f), string.Empty, BlueStonez.box_grey50);
		GUI.Label(new Rect((float)(num2 + num3), 0f, (float)this._gameNameWidth, 25f), new GUIContent(LocalizedStrings.Name, image), BlueStonez.label_interparkbold_16pt_left);
		if (GUI.Button(new Rect((float)num2, 0f, (float)this._gameNameWidth, 25f), GUIContent.none, BlueStonez.label_interparkbold_11pt_left))
		{
			this.SortGameList(PlayPageGUI.GameListColumns.GameName);
		}
		num2 = 110 + this._gameNameWidth - 3;
		image = ((this._lastSortedColumn != PlayPageGUI.GameListColumns.GameMode) ? null : ((!this._sortGamesAscending) ? this._sortDownArrow : this._sortUpArrow));
		num3 = ((this._lastSortedColumn != PlayPageGUI.GameListColumns.GameMode) ? 12 : 5);
		GUI.Box(new Rect((float)num2, 0f, (float)this._gameModeWidth, 25f), string.Empty, BlueStonez.box_grey50);
		GUI.Label(new Rect((float)(num2 + num3), 0f, (float)this._gameModeWidth, 25f), new GUIContent(LocalizedStrings.Mode, image), BlueStonez.label_interparkbold_16pt_left);
		if (GUI.Button(new Rect((float)num2, 0f, (float)this._gameModeWidth, 25f), string.Empty, BlueStonez.label_interparkbold_11pt_left))
		{
			this.SortGameList(PlayPageGUI.GameListColumns.GameMode);
		}
		GUI.Box(new Rect((float)(num2 + this._gameModeWidth - 1), 0f, rect2.width - (float)(num2 + this._gameModeWidth - 1), 25f), string.Empty, BlueStonez.box_grey50);
		if (Singleton<GameStateController>.Instance.Client.IsConnected)
		{
			this._serverScroll = GUITools.BeginScrollView(new Rect(0f, 25f, rect2.width, rect2.height - 1f - 25f), this._serverScroll, new Rect(0f, 0f, rect2.width - 60f, (float)num), BlueStonez.horizontalScrollbar, BlueStonez.verticalScrollbar);
			this._filteredActiveRoomCount = this.DrawAllGames(rect2, rect2.height <= (float)num);
			GUITools.EndScrollView();
		}
		GUI.EndGroup();
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x0004B900 File Offset: 0x00049B00
	private void SortServerList(PlayPageGUI.ServerListColumns sortedColumn, bool changeDirection = true)
	{
		if (changeDirection && sortedColumn == this._lastSortedServerColumn)
		{
			this._sortServerAscending = !this._sortServerAscending;
		}
		this._lastSortedServerColumn = sortedColumn;
		switch (sortedColumn)
		{
		case PlayPageGUI.ServerListColumns.ServerName:
			Singleton<GameServerManager>.Instance.SortServers(new GameServerNameComparer(), this._sortServerAscending);
			break;
		case PlayPageGUI.ServerListColumns.ServerCapacity:
			Singleton<GameServerManager>.Instance.SortServers(new GameServerPlayerCountComparer(), this._sortServerAscending);
			break;
		case PlayPageGUI.ServerListColumns.ServerSpeed:
			Singleton<GameServerManager>.Instance.SortServers(new GameServerLatencyComparer(), this._sortServerAscending);
			break;
		default:
			Singleton<GameServerManager>.Instance.SortServers(new GameServerLatencyComparer(), this._sortServerAscending);
			break;
		}
	}

	// Token: 0x06000BA2 RID: 2978 RVA: 0x0004B9B8 File Offset: 0x00049BB8
	private void SortGameList(PlayPageGUI.GameListColumns sortedColumn)
	{
		if (sortedColumn == this._lastSortedColumn)
		{
			this._sortGamesAscending = !this._sortGamesAscending;
		}
		this._lastSortedColumn = sortedColumn;
		switch (sortedColumn)
		{
		case PlayPageGUI.GameListColumns.Lock:
			this.SortGameList(new GameDataAccessComparer());
			return;
		case PlayPageGUI.GameListColumns.GameMap:
			this.SortGameList(new GameDataMapComparer());
			return;
		case PlayPageGUI.GameListColumns.GameMode:
			this.SortGameList(new GameDataRuleComparer());
			return;
		case PlayPageGUI.GameListColumns.PlayerCount:
			this.SortGameList(new GameDataPlayerComparer());
			return;
		case PlayPageGUI.GameListColumns.GameTime:
			this.SortGameList(new GameDataTimeComparer());
			return;
		}
		this.SortGameList(new GameDataNameComparer());
	}

	// Token: 0x06000BA3 RID: 2979 RVA: 0x000091AC File Offset: 0x000073AC
	private void SortGameList(IComparer<GameRoomData> method)
	{
		this._gameSortingMethod = method;
		this.RefreshGameList();
	}

	// Token: 0x06000BA4 RID: 2980 RVA: 0x0004BA78 File Offset: 0x00049C78
	public void RefreshGameList()
	{
		bool flag = false;
		this._cachedGameList.Clear();
		if (Singleton<GameListManager>.Instance.GamesCount > 0)
		{
			foreach (GameRoomData gameRoomData in Singleton<GameListManager>.Instance.GameList)
			{
				this._cachedGameList.Add(gameRoomData);
				if (this._selectedGame != null && gameRoomData.Number == this._selectedGame.Number)
				{
					flag = true;
				}
			}
			GameDataComparer.SortAscending = this._sortGamesAscending;
			this._cachedGameList.Sort(this._gameSortingMethod);
		}
		if (!flag)
		{
			this._selectedGame = null;
		}
	}

	// Token: 0x06000BA5 RID: 2981 RVA: 0x0004BB44 File Offset: 0x00049D44
	private void DoFilterArea(Rect rect)
	{
		bool enabled = GUI.enabled;
		Rect position = new Rect(10f, rect.height - 73f - 50f, rect.width - 20f, 74f);
		GUI.Box(position, string.Empty, BlueStonez.box_grey50);
		GUI.BeginGroup(new Rect(position.x, position.y, position.width, position.width + 60f));
		GUI.enabled = (enabled && (this._dropDownList == 0 || this._dropDownList == 1));
		GUI.Label(new Rect(10f, 10f, 115f, 21f), this._mapsFilter[this._currentMap], BlueStonez.label_dropdown);
		if (GUI.Button(new Rect(123f, 9f, 21f, 21f), GUIContent.none, BlueStonez.dropdown_button))
		{
			this._dropDownList = ((this._dropDownList != 0) ? 0 : 1);
			this._dropDownRect = new Rect(10f, 31f, 133f, 80f);
		}
		GUI.enabled = (enabled && (this._dropDownList == 0 || this._dropDownList == 2));
		GUI.Label(new Rect(10f, 42f, 115f, 21f), this._modesFilter[this._currentMode], BlueStonez.label_dropdown);
		if (GUI.Button(new Rect(123f, 41f, 21f, 21f), GUIContent.none, BlueStonez.dropdown_button))
		{
			this._dropDownList = ((this._dropDownList != 0) ? 0 : 2);
			this._dropDownRect = new Rect(10f, 63f, 133f, 60f);
		}
		GUI.enabled = (enabled && this._dropDownList == 0);
		this._gameNotFull = GUI.Toggle(new Rect(165f, 7f, 170f, 16f), this._gameNotFull, LocalizedStrings.GameNotFull, BlueStonez.toggle);
		this._noPrivateGames = GUI.Toggle(new Rect(165f, 28f, 170f, 16f), this._noPrivateGames, LocalizedStrings.NotPasswordProtected, BlueStonez.toggle);
		GUI.enabled = false;
		if (this.CheckChangesInFilter())
		{
			this._serverScroll = new Vector2(0f, 0f);
			if (!this.CanPassFilter(this._selectedGame))
			{
				this._selectedGame = null;
			}
			this.RefreshGameList();
		}
		GUI.enabled = enabled;
		if (this._dropDownList != 0)
		{
			this.DoDropDownList();
		}
		GUI.EndGroup();
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x0004BE18 File Offset: 0x0004A018
	private bool CheckChangesInFilter()
	{
		bool result = false;
		if (this._filterSavedData.UseFilter != this._showFilters)
		{
			this._filterSavedData.UseFilter = this._showFilters;
			result = true;
		}
		if (this._filterSavedData.MapName != this._mapsFilter[this._currentMap])
		{
			this._filterSavedData.MapName = this._mapsFilter[this._currentMap];
			result = true;
		}
		if (this._filterSavedData.GameMode != this._modesFilter[this._currentMode])
		{
			this._filterSavedData.GameMode = this._modesFilter[this._currentMode];
			result = true;
		}
		if (this._filterSavedData.NoFriendlyFire != this._noFriendFire)
		{
			this._filterSavedData.NoFriendlyFire = this._noFriendFire;
			result = true;
		}
		if (this._filterSavedData.ISGameNotFull != this._gameNotFull)
		{
			this._filterSavedData.ISGameNotFull = this._gameNotFull;
			result = true;
		}
		if (this._filterSavedData.NoPasswordProtection != this._noPrivateGames)
		{
			this._filterSavedData.NoPasswordProtection = this._noPrivateGames;
			result = true;
		}
		return result;
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x0004BF44 File Offset: 0x0004A144
	private void DoBottomArea(Rect rect)
	{
		GUITools.PushGUIState();
		GUI.enabled = (this._dropDownList == 0);
		bool showFilters = this._showFilters;
		this._showFilters = GUI.Toggle(new Rect(22f, rect.height - 42f, 120f, 32f), this._showFilters, LocalizedStrings.FiltersCaps, BlueStonez.button);
		if (showFilters != this._showFilters)
		{
			Singleton<GameStateController>.Instance.Client.RefreshGameLobby();
		}
		if (this._showFilters && this.IsAnyFilterOn && GUITools.Button(new Rect(153f, rect.height - 42f, 145f, 32f), new GUIContent(LocalizedStrings.ResetFiltersCaps), BlueStonez.button))
		{
			Singleton<GameStateController>.Instance.Client.RefreshGameLobby();
			this.ResetFilters();
		}
		if (!this._showFilters && this._filterSavedData.UseFilter)
		{
			this._filterSavedData.UseFilter = false;
		}
		if (!this._refreshGameListOnFilterChange && this.IsAnyFilterOn)
		{
			this.RefreshGameList();
			this._refreshGameListOnFilterChange = true;
		}
		if (this._refreshGameListOnFilterChange && !this.IsAnyFilterOn)
		{
			this.RefreshGameList();
			this._refreshGameListOnFilterChange = false;
		}
		GUI.enabled = true;
		if (GUITools.Button(new Rect(rect.width - 160f, rect.height - 42f, 140f, 32f), new GUIContent(LocalizedStrings.CreateGameCaps), BlueStonez.button))
		{
			PanelManager.Instance.OpenPanel(PanelType.CreateGame);
		}
		GUI.enabled = (Singleton<GameStateController>.Instance.Client.IsConnected && this._selectedGame != null && Singleton<GameServerController>.Instance.SelectedServer != null && Singleton<GameServerController>.Instance.SelectedServer.Data.RoomsCreated != 0 && !PanelManager.Instance.IsPanelOpen(PanelType.CreateGame));
		GUITools.PopGUIState();
	}

	// Token: 0x06000BA8 RID: 2984 RVA: 0x0004C14C File Offset: 0x0004A34C
	private void DrawQuickSearch(Rect rect)
	{
		this._searchBar.Draw(rect);
		if (!this._refreshGameListOnSortChange && this._searchBar.FilterText.Length > 0)
		{
			Singleton<GameStateController>.Instance.Client.RefreshGameLobby();
			this.RefreshGameList();
			this._refreshGameListOnSortChange = true;
		}
		if (this._refreshGameListOnSortChange && this._searchBar.FilterText.Length == 0)
		{
			this.RefreshGameList();
			this._refreshGameListOnSortChange = false;
		}
	}

	// Token: 0x06000BA9 RID: 2985 RVA: 0x0004C1D0 File Offset: 0x0004A3D0
	private void DoDropDownList()
	{
		string[] array;
		switch (this._dropDownList)
		{
		case 1:
			array = this._mapsFilter;
			goto IL_65;
		case 2:
			array = this._modesFilter;
			goto IL_65;
		case 4:
			array = this._weaponClassTexts;
			goto IL_65;
		}
		Debug.LogError("Nondefined drop down list: " + this._dropDownList);
		return;
		IL_65:
		GUI.Box(this._dropDownRect, string.Empty, BlueStonez.window);
		this._filterScroll = GUITools.BeginScrollView(this._dropDownRect, this._filterScroll, new Rect(0f, 0f, this._dropDownRect.width - 20f, (float)(20 * array.Length)), false, false, true);
		for (int i = 0; i < array.Length; i++)
		{
			GUI.Label(new Rect(2f, (float)(20 * i), this._dropDownRect.width, 20f), array[i], BlueStonez.dropdown_list);
			if (GUI.Button(new Rect(2f, (float)(20 * i), this._dropDownRect.width, 20f), string.Empty, BlueStonez.dropdown_list))
			{
				switch (this._dropDownList)
				{
				case 1:
					this._currentMap = i;
					break;
				case 2:
					this._currentMode = i;
					break;
				case 4:
					this._currentWeapon = i;
					break;
				}
				this._dropDownList = 0;
				this._filterScroll.y = 0f;
			}
		}
		GUITools.EndScrollView();
	}

	// Token: 0x06000BAA RID: 2986 RVA: 0x0004C370 File Offset: 0x0004A570
	private void JoinGame(GameRoomData game)
	{
		if (game != null)
		{
			if (ApplicationDataManager.IsMobile && game.PlayerLimit > 6)
			{
				PopupSystem.ShowMessage(LocalizedStrings.Warning, LocalizedStrings.MobileGameMoreThan8Players, PopupSystem.AlertType.OKCancel, delegate()
				{
					Singleton<GameStateController>.Instance.JoinNetworkGame(game);
				}, LocalizedStrings.OkCaps, null, LocalizedStrings.CancelCaps);
			}
			else
			{
				Singleton<GameStateController>.Instance.JoinNetworkGame(game);
			}
		}
	}

	// Token: 0x06000BAB RID: 2987 RVA: 0x0004C3F0 File Offset: 0x0004A5F0
	private bool CanPassFilter(GameRoomData game)
	{
		if (game == null)
		{
			return false;
		}
		GameFlags gameFlags = new GameFlags();
		gameFlags.SetFlags(game.GameFlags);
		bool flag = this._searchBar.CheckIfPassFilter(game.Name);
		bool flag2 = true;
		bool flag3 = true;
		if (ApplicationDataManager.IsMobile && GameRoomHelper.HasLevelRestriction(game))
		{
			return false;
		}
		if (!Singleton<MapManager>.Instance.MapExistsWithId(game.MapID))
		{
			return false;
		}
		bool flag4 = this._mapsFilter[this._currentMap] == LocalizedStrings.All + " Maps" || Singleton<MapManager>.Instance.GetMapName(game.MapID) == this._mapsFilter[this._currentMap];
		bool flag5 = this._modesFilter[this._currentMode] == LocalizedStrings.All + " Modes" || GameStateHelper.GetModeName(game.GameMode) == this._modesFilter[this._currentMode];
		if (this._gameNotFull)
		{
			flag2 = !game.IsFull;
		}
		if (this._noPrivateGames)
		{
			flag3 = !game.IsPasswordProtected;
		}
		if (this._showFilters)
		{
			return flag && flag4 && flag5 && flag2 && flag3 && this._showFilters;
		}
		return flag;
	}

	// Token: 0x06000BAC RID: 2988 RVA: 0x0004C560 File Offset: 0x0004A760
	private string DisplayMapIcon(int mapId, Rect rect)
	{
		string mapSceneName = Singleton<MapManager>.Instance.GetMapSceneName(mapId);
		string text = ApplicationDataManager.ImagePath + "maps/" + mapSceneName + ".jpg";
		if (this._mapImages.ContainsKey(mapId))
		{
			this._mapImages[mapId].Draw(rect, false);
		}
		else
		{
			DynamicTexture dynamicTexture = new DynamicTexture(text, false);
			this._mapImages[mapId] = dynamicTexture;
			dynamicTexture.Draw(rect, false);
		}
		return text;
	}

	// Token: 0x06000BAD RID: 2989 RVA: 0x0004C5D8 File Offset: 0x0004A7D8
	private int DrawAllGames(Rect rect, bool hasVScroll)
	{
		int playerLevel = PlayerDataManager.PlayerLevel;
		List<string> list = new List<string>();
		int num = 0;
		foreach (GameRoomData gameRoomData in this._cachedGameList)
		{
			if (this.CanPassFilter(gameRoomData))
			{
				bool flag = GameRoomHelper.CanJoinGame(gameRoomData);
				bool enabled = GUI.enabled;
				GUI.enabled = (enabled && flag && this._dropDownList == 0);
				int num2 = 70 * num - 1;
				GUI.Box(new Rect(0f, (float)num2, rect.width, 71f), new GUIContent(string.Empty), BlueStonez.box_grey50);
				if (!ApplicationDataManager.IsMobile)
				{
					string tooltip = LocalizedStrings.PlayCaps;
					if (!GameRoomHelper.IsLevelAllowed(gameRoomData, playerLevel) && (int)gameRoomData.LevelMin > playerLevel)
					{
						tooltip = string.Format(LocalizedStrings.YouHaveToReachLevelNToJoinThisGame, gameRoomData.LevelMin);
					}
					else if (!GameRoomHelper.IsLevelAllowed(gameRoomData, playerLevel) && (int)gameRoomData.LevelMax < playerLevel)
					{
						tooltip = string.Format(LocalizedStrings.YouAlreadyMasteredThisLevel, new object[0]);
					}
					else if (gameRoomData.IsFull)
					{
						tooltip = string.Format(LocalizedStrings.ThisGameIsFull, new object[0]);
					}
					GUI.Box(new Rect(0f, (float)num2, rect.width, 70f), new GUIContent(string.Empty, tooltip), BlueStonez.box_grey50);
				}
				if (this._selectedGame != null && this._selectedGame.Number == gameRoomData.Number)
				{
					GUI.color = new Color(1f, 1f, 1f, 0.03f);
					GUI.DrawTexture(new Rect(1f, (float)num2, rect.width + 1f, 70f), UberstrikeIconsHelper.White);
					GUI.color = Color.white;
				}
				GUIStyle style = (!flag) ? BlueStonez.label_interparkmed_10pt_left : BlueStonez.label_interparkbold_11pt_left;
				GUI.color = ((!GameRoomHelper.HasLevelRestriction(gameRoomData)) ? Color.white : new Color(1f, 0.7f, 0f));
				int num3 = 0;
				string item = this.DisplayMapIcon(gameRoomData.MapID, new Rect((float)num3, (float)num2, 110f, 70f));
				list.Add(item);
				if (gameRoomData.IsPermanentGame && GameRoomHelper.HasLevelRestriction(gameRoomData))
				{
					if (gameRoomData.LevelMax <= 5)
					{
						GUI.DrawTexture(new Rect(80f, (float)(num2 + 70 - 30), 25f, 25f), this._level1GameIcon);
					}
					else if (gameRoomData.LevelMax <= 10)
					{
						GUI.DrawTexture(new Rect(80f, (float)(num2 + 70 - 30), 25f, 25f), this._level2GameIcon);
					}
					else if (gameRoomData.LevelMax <= 20)
					{
						GUI.DrawTexture(new Rect(80f, (float)(num2 + 70 - 30), 25f, 25f), this._level3GameIcon);
					}
					else if (gameRoomData.LevelMin >= 40)
					{
						GUI.DrawTexture(new Rect(80f, (float)(num2 + 70 - 30), 25f, 25f), this._level20GameIcon);
					}
					else if (gameRoomData.LevelMin >= 30)
					{
						GUI.DrawTexture(new Rect(80f, (float)(num2 + 70 - 30), 25f, 25f), this._level10GameIcon);
					}
					else if (gameRoomData.LevelMin >= 20)
					{
						GUI.DrawTexture(new Rect(80f, (float)(num2 + 70 - 30), 25f, 25f), this._level5GameIcon);
					}
					if (playerLevel > (int)gameRoomData.LevelMax)
					{
						GUI.DrawTexture(new Rect(0f, (float)(num2 + 70 - 50), 50f, 50f), UberstrikeIcons.LevelMastered);
					}
				}
				if (gameRoomData.IsPasswordProtected)
				{
					GUI.DrawTexture(new Rect(80f, (float)(num2 + 70 - 30), 25f, 25f), this._privateGameIcon);
				}
				GUI.color = ((!GameRoomHelper.HasLevelRestriction(gameRoomData)) ? Color.white : new Color(1f, 0.7f, 0f));
				num3 = 120;
				GUI.Label(new Rect((float)num3, (float)num2, (float)this._gameNameWidth, 35f), gameRoomData.Name, BlueStonez.label_interparkbold_13pt_left);
				GUI.Label(new Rect((float)num3, (float)(num2 + 35), (float)this._gameNameWidth, 35f), Singleton<MapManager>.Instance.GetMapName(gameRoomData.MapID) + " " + this.LevelRestrictionText(gameRoomData), BlueStonez.label_interparkmed_10pt_left);
				num3 = 122 + this._gameNameWidth - 4;
				int num4 = gameRoomData.TimeLimit / 60;
				GUI.Label(new Rect((float)num3, (float)num2, (float)this._gameModeWidth, 35f), string.Concat(new object[]
				{
					GameStateHelper.GetModeName(gameRoomData.GameMode),
					" - ",
					num4,
					" mins Mods: ",
					PlayPageGUI.GetGameFlagText(gameRoomData)
				}), BlueStonez.label_interparkmed_10pt_left);
				GUI.Label(new Rect((float)(num3 + 64), (float)(num2 + 35), (float)this._gameModeWidth, 35f), string.Format("{0}/{1} players", gameRoomData.ConnectedPlayers, gameRoomData.PlayerLimit), style);
				GUI.color = Color.white;
				this.DrawProgressBarLarge(new Rect((float)num3, (float)(num2 + 35 + 5), 58f, 35f), (float)gameRoomData.ConnectedPlayers / (float)gameRoomData.PlayerLimit);
				num3 = 110 + this._gameNameWidth + this._gameModeWidth - 6;
				int height = BlueStonez.button.normal.background.height;
				if (GUI.Button(new Rect((float)num3, (float)(num2 + 35 - height / 2), 90f, (float)height), LocalizedStrings.JoinCaps, BlueStonez.button_white))
				{
					this.JoinGame(gameRoomData);
					AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.JoinServer, 0UL, 1f, 1f);
				}
				if (GUI.Button(new Rect(0f, (float)num2, rect.width, 70f), string.Empty, BlueStonez.label_interparkbold_11pt_left))
				{
					Singleton<GameStateController>.Instance.Client.RefreshGameLobby();
					if (this._selectedGame != null && this._selectedGame.Number == gameRoomData.Number && this._gameJoinDoubleClick > Time.time)
					{
						this._gameJoinDoubleClick = 0f;
						this.JoinGame(this._selectedGame);
						AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.JoinServer, 0UL, 1f, 1f);
					}
					else
					{
						this._gameJoinDoubleClick = Time.time + 0.5f;
					}
					this._selectedGame = gameRoomData;
				}
				num++;
				GUI.color = Color.white;
				GUI.enabled = enabled;
			}
		}
		if (num == 0 && Singleton<GameServerController>.Instance.SelectedServer != null && Singleton<GameServerController>.Instance.SelectedServer.Data.RoomsCreated > 0 && this._cachedGameList.Count > 0)
		{
			GUI.Label(new Rect(0f, rect.height * 0.5f, rect.width, 23f), "No games running on this server", BlueStonez.label_interparkmed_11pt);
			if (GUITools.Button(new Rect(rect.width * 0.5f - 70f, rect.height * 0.5f - 30f, 140f, 23f), new GUIContent(LocalizedStrings.CreateGameCaps), BlueStonez.button))
			{
				PanelManager.Instance.OpenPanel(PanelType.CreateGame);
			}
		}
		return num;
	}

	// Token: 0x06000BAE RID: 2990 RVA: 0x0004CDD8 File Offset: 0x0004AFD8
	public static string GetGameFlagText(GameRoomData data)
	{
		string result = "None";
		if (GameFlags.IsFlagSet(GameFlags.GAME_FLAGS.NoArmor, data.GameFlags))
		{
			result = "No Armor";
		}
		else if (GameFlags.IsFlagSet(GameFlags.GAME_FLAGS.LowGravity, data.GameFlags))
		{
			result = "Low Gravity";
		}
		else if (GameFlags.IsFlagSet(GameFlags.GAME_FLAGS.QuickSwitch, data.GameFlags))
		{
			result = "Quick Switching";
		}
		else if (GameFlags.IsFlagSet(GameFlags.GAME_FLAGS.MeleeOnly, data.GameFlags))
		{
			result = "Melee Only";
		}
		return result;
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x0004CE58 File Offset: 0x0004B058
	private string LevelRestrictionText(GameRoomData m)
	{
		if (!GameRoomHelper.HasLevelRestriction(m))
		{
			return string.Empty;
		}
		if (m.LevelMax == m.LevelMin)
		{
			return string.Format(LocalizedStrings.PlayerLevelNRestriction, m.LevelMin);
		}
		if (m.LevelMax == 0)
		{
			return string.Format(LocalizedStrings.PlayerLevelNPlusRestriction, m.LevelMin);
		}
		if (m.LevelMin == 0)
		{
			return string.Format(LocalizedStrings.PlayerLevelNMinusRestriction, (int)(m.LevelMax + 1));
		}
		return string.Format(LocalizedStrings.PlayerLevelNToNRestriction, m.LevelMin, m.LevelMax);
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x0004CF04 File Offset: 0x0004B104
	private void UpdateColumnWidth()
	{
		int num = Screen.width - 40;
		this._gameNameWidth = num - 110 - this._gameModeWidth - 110;
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x000091BB File Offset: 0x000073BB
	public void Show()
	{
		if (this._currentSelectedServer != null)
		{
			this.ShowGameSelection(this._currentSelectedServer);
		}
		else
		{
			this.ShowServerSelection();
		}
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x000091DF File Offset: 0x000073DF
	private void ShowGameSelection(PhotonServer server)
	{
		if (server != null)
		{
			Singleton<GameServerController>.Instance.SelectedServer = server;
			this._cachedGameList.Clear();
			Singleton<GameStateController>.Instance.Client.EnterGameLobby(Singleton<GameServerController>.Instance.SelectedServer.ConnectionString);
		}
	}

	// Token: 0x06000BB3 RID: 2995 RVA: 0x0004CF30 File Offset: 0x0004B130
	public void ShowServerSelection()
	{
		Singleton<GameServerController>.Instance.SelectedServer = null;
		Singleton<GameStateController>.Instance.Client.Disconnect();
		if (this._lastSortedServerColumn == PlayPageGUI.ServerListColumns.None)
		{
			this._lastSortedServerColumn = PlayPageGUI.ServerListColumns.ServerSpeed;
			this.SortServerList(this._lastSortedServerColumn, false);
		}
		this.RefreshServerLoad();
	}

	// Token: 0x06000BB4 RID: 2996 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Hide()
	{
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x0000921B File Offset: 0x0000741B
	private void RefreshServerLoad()
	{
		if (this._nextServerCheckTime < Time.time)
		{
			this._nextServerCheckTime = Time.time + 5f;
			base.StartCoroutine(Singleton<GameServerManager>.Instance.StartUpdatingServerLoads());
		}
	}

	// Token: 0x17000310 RID: 784
	// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x0004CF7C File Offset: 0x0004B17C
	private bool IsAnyFilterOn
	{
		get
		{
			return this._currentMap != 0 || this._currentMode != 0 || this._currentWeapon != 0 || this._noFriendFire || this._gameNotFull || this._noPrivateGames || this._instasplat || this._lowGravity || this._justForFun || this._singleWeapon;
		}
	}

	// Token: 0x04000ADA RID: 2778
	private const float JoinServerButtonWidth = 130f;

	// Token: 0x04000ADB RID: 2779
	private const int GameRowHeight = 70;

	// Token: 0x04000ADC RID: 2780
	private const float _doubleClickFrame = 0.5f;

	// Token: 0x04000ADD RID: 2781
	private const int _dropDownListMap = 1;

	// Token: 0x04000ADE RID: 2782
	private const int _dropDownListGameMode = 2;

	// Token: 0x04000ADF RID: 2783
	private const int _dropDownListSingleWeapon = 4;

	// Token: 0x04000AE0 RID: 2784
	public const int MAX_PLAYERS_ON_MOBILE = 6;

	// Token: 0x04000AE1 RID: 2785
	private const int _mapImageWidth = 110;

	// Token: 0x04000AE2 RID: 2786
	private const int _gameTimeWidth = 80;

	// Token: 0x04000AE3 RID: 2787
	private const int _playerCountWidth = 80;

	// Token: 0x04000AE4 RID: 2788
	private const int _joinGameWidth = 110;

	// Token: 0x04000AE5 RID: 2789
	private const float _serverSpeedColumnWidth = 110f;

	// Token: 0x04000AE6 RID: 2790
	private const float _serverPlayerCountColumnWidth = 130f;

	// Token: 0x04000AE7 RID: 2791
	private const int ServerCheckDelay = 5;

	// Token: 0x04000AE8 RID: 2792
	private Dictionary<int, DynamicTexture> _mapImages = new Dictionary<int, DynamicTexture>();

	// Token: 0x04000AE9 RID: 2793
	[SerializeField]
	private Texture2D _level1GameIcon;

	// Token: 0x04000AEA RID: 2794
	[SerializeField]
	private Texture2D _level2GameIcon;

	// Token: 0x04000AEB RID: 2795
	[SerializeField]
	private Texture2D _level3GameIcon;

	// Token: 0x04000AEC RID: 2796
	[SerializeField]
	private Texture2D _level5GameIcon;

	// Token: 0x04000AED RID: 2797
	[SerializeField]
	private Texture2D _level10GameIcon;

	// Token: 0x04000AEE RID: 2798
	[SerializeField]
	private Texture2D _level20GameIcon;

	// Token: 0x04000AEF RID: 2799
	[SerializeField]
	private Texture2D _privateGameIcon;

	// Token: 0x04000AF0 RID: 2800
	[SerializeField]
	private Texture2D _sortUpArrow;

	// Token: 0x04000AF1 RID: 2801
	[SerializeField]
	private Texture2D _sortDownArrow;

	// Token: 0x04000AF2 RID: 2802
	private PhotonServer _currentSelectedServer;

	// Token: 0x04000AF3 RID: 2803
	private string[] _mapsFilter;

	// Token: 0x04000AF4 RID: 2804
	private string[] _modesFilter;

	// Token: 0x04000AF5 RID: 2805
	private float _gameJoinDoubleClick;

	// Token: 0x04000AF6 RID: 2806
	private float _serverJoinDoubleClick;

	// Token: 0x04000AF7 RID: 2807
	private bool _refreshGameListOnFilterChange;

	// Token: 0x04000AF8 RID: 2808
	private bool _refreshGameListOnSortChange;

	// Token: 0x04000AF9 RID: 2809
	private Vector2 _serverScroll;

	// Token: 0x04000AFA RID: 2810
	private Vector2 _filterScroll;

	// Token: 0x04000AFB RID: 2811
	private bool _gameNotFull;

	// Token: 0x04000AFC RID: 2812
	private bool _noPrivateGames;

	// Token: 0x04000AFD RID: 2813
	private bool _instasplat;

	// Token: 0x04000AFE RID: 2814
	private bool _lowGravity;

	// Token: 0x04000AFF RID: 2815
	private bool _justForFun;

	// Token: 0x04000B00 RID: 2816
	private bool _singleWeapon;

	// Token: 0x04000B01 RID: 2817
	private bool _noFriendFire;

	// Token: 0x04000B02 RID: 2818
	private bool _showFilters;

	// Token: 0x04000B03 RID: 2819
	private string[] _weaponClassTexts;

	// Token: 0x04000B04 RID: 2820
	private int _dropDownList;

	// Token: 0x04000B05 RID: 2821
	private Rect _dropDownRect;

	// Token: 0x04000B06 RID: 2822
	private int _currentMap;

	// Token: 0x04000B07 RID: 2823
	private int _currentMode;

	// Token: 0x04000B08 RID: 2824
	private int _currentWeapon;

	// Token: 0x04000B09 RID: 2825
	private GameRoomData _selectedGame;

	// Token: 0x04000B0A RID: 2826
	private int _mapNameWidth = 135;

	// Token: 0x04000B0B RID: 2827
	private int _gameModeWidth = 170;

	// Token: 0x04000B0C RID: 2828
	private int _gameNameWidth = 200;

	// Token: 0x04000B0D RID: 2829
	private float _serverNameColumnWidth;

	// Token: 0x04000B0E RID: 2830
	private bool _unFocus;

	// Token: 0x04000B0F RID: 2831
	private bool _sortServerAscending;

	// Token: 0x04000B10 RID: 2832
	private bool _sortGamesAscending;

	// Token: 0x04000B11 RID: 2833
	private int _filteredActiveRoomCount;

	// Token: 0x04000B12 RID: 2834
	private PlayPageGUI.GameListColumns _lastSortedColumn;

	// Token: 0x04000B13 RID: 2835
	private PlayPageGUI.FilterSavedData _filterSavedData;

	// Token: 0x04000B14 RID: 2836
	private List<GameRoomData> _cachedGameList;

	// Token: 0x04000B15 RID: 2837
	private IComparer<GameRoomData> _gameSortingMethod;

	// Token: 0x04000B16 RID: 2838
	private Vector2 _serverSelectionHelpScrollBar;

	// Token: 0x04000B17 RID: 2839
	private Vector2 _serverSelectionScrollBar;

	// Token: 0x04000B18 RID: 2840
	private PlayPageGUI.ServerListColumns _lastSortedServerColumn;

	// Token: 0x04000B19 RID: 2841
	private float _nextServerCheckTime;

	// Token: 0x04000B1A RID: 2842
	private SearchBarGUI _searchBar;

	// Token: 0x020001A5 RID: 421
	private enum ServerLatency
	{
		// Token: 0x04000B1E RID: 2846
		Fast = 100,
		// Token: 0x04000B1F RID: 2847
		Med = 300
	}

	// Token: 0x020001A6 RID: 422
	private enum GameListColumns
	{
		// Token: 0x04000B21 RID: 2849
		None,
		// Token: 0x04000B22 RID: 2850
		Lock,
		// Token: 0x04000B23 RID: 2851
		Star,
		// Token: 0x04000B24 RID: 2852
		GameName,
		// Token: 0x04000B25 RID: 2853
		GameMap,
		// Token: 0x04000B26 RID: 2854
		GameMode,
		// Token: 0x04000B27 RID: 2855
		PlayerCount,
		// Token: 0x04000B28 RID: 2856
		GameServerPing,
		// Token: 0x04000B29 RID: 2857
		GameTime
	}

	// Token: 0x020001A7 RID: 423
	private enum ServerListColumns
	{
		// Token: 0x04000B2B RID: 2859
		None,
		// Token: 0x04000B2C RID: 2860
		ServerName,
		// Token: 0x04000B2D RID: 2861
		ServerCapacity,
		// Token: 0x04000B2E RID: 2862
		ServerSpeed
	}

	// Token: 0x020001A8 RID: 424
	private class FilterSavedData
	{
		// Token: 0x04000B2F RID: 2863
		public bool UseFilter;

		// Token: 0x04000B30 RID: 2864
		public string MapName = string.Empty;

		// Token: 0x04000B31 RID: 2865
		public string GameMode = string.Empty;

		// Token: 0x04000B32 RID: 2866
		public bool NoFriendlyFire;

		// Token: 0x04000B33 RID: 2867
		public bool ISGameNotFull;

		// Token: 0x04000B34 RID: 2868
		public bool NoPasswordProtection;
	}
}
