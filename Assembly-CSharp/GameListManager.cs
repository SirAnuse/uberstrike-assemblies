using System;
using System.Collections.Generic;
using UberStrike.Core.Models;

// Token: 0x020002AE RID: 686
public class GameListManager : Singleton<GameListManager>
{
	// Token: 0x060012F6 RID: 4854 RVA: 0x0000CF29 File Offset: 0x0000B129
	private GameListManager()
	{
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x060012F7 RID: 4855 RVA: 0x0000CF3C File Offset: 0x0000B13C
	public IEnumerable<GameRoomData> GameList
	{
		get
		{
			return this._gameList.Values;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x060012F8 RID: 4856 RVA: 0x0000CF49 File Offset: 0x0000B149
	public int GamesCount
	{
		get
		{
			return this._gameList.Count;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x060012F9 RID: 4857 RVA: 0x0000CF56 File Offset: 0x0000B156
	// (set) Token: 0x060012FA RID: 4858 RVA: 0x0000CF5E File Offset: 0x0000B15E
	public int PlayersCount { get; private set; }

	// Token: 0x060012FB RID: 4859 RVA: 0x0000CF67 File Offset: 0x0000B167
	public void SetGameList(List<GameRoomData> data)
	{
		this._gameList.Clear();
		data.ForEach(delegate(GameRoomData g)
		{
			this._gameList[g.Number] = g;
		});
		this.UpdatePlayerCount();
	}

	// Token: 0x060012FC RID: 4860 RVA: 0x0000CF8C File Offset: 0x0000B18C
	public void AddGame(GameRoomData game)
	{
		this._gameList[game.Number] = game;
		this.UpdatePlayerCount();
	}

	// Token: 0x060012FD RID: 4861 RVA: 0x0000CFA6 File Offset: 0x0000B1A6
	public void RemoveGame(int id)
	{
		this._gameList.Remove(id);
		this.UpdatePlayerCount();
	}

	// Token: 0x060012FE RID: 4862 RVA: 0x0000CFBB File Offset: 0x0000B1BB
	public void Clear()
	{
		this._gameList.Clear();
		this.PlayersCount = 0;
	}

	// Token: 0x060012FF RID: 4863 RVA: 0x0006FEE0 File Offset: 0x0006E0E0
	private void UpdatePlayerCount()
	{
		this.PlayersCount = 0;
		foreach (KeyValuePair<int, GameRoomData> keyValuePair in this._gameList)
		{
			this.PlayersCount += keyValuePair.Value.ConnectedPlayers;
		}
	}

	// Token: 0x04001305 RID: 4869
	private Dictionary<int, GameRoomData> _gameList = new Dictionary<int, GameRoomData>();
}
