using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000374 RID: 884
public class SpawnPointManager : Singleton<SpawnPointManager>
{
	// Token: 0x060018FE RID: 6398 RVA: 0x00086140 File Offset: 0x00084340
	private SpawnPointManager()
	{
		this._spawnPointsDictionary = new Dictionary<GameModeType, IDictionary<TeamID, IList<SpawnPoint>>>();
		foreach (object obj in Enum.GetValues(typeof(GameModeType)))
		{
			GameModeType key = (GameModeType)((int)obj);
			this._spawnPointsDictionary[key] = new Dictionary<TeamID, IList<SpawnPoint>>
			{
				{
					TeamID.BLUE,
					new List<SpawnPoint>()
				},
				{
					TeamID.RED,
					new List<SpawnPoint>()
				},
				{
					TeamID.NONE,
					new List<SpawnPoint>()
				}
			};
		}
	}

	// Token: 0x060018FF RID: 6399 RVA: 0x000861F0 File Offset: 0x000843F0
	private void Clear()
	{
		foreach (object obj in Enum.GetValues(typeof(GameModeType)))
		{
			GameModeType key = (GameModeType)((int)obj);
			this._spawnPointsDictionary[key][TeamID.NONE].Clear();
			this._spawnPointsDictionary[key][TeamID.BLUE].Clear();
			this._spawnPointsDictionary[key][TeamID.RED].Clear();
		}
	}

	// Token: 0x06001900 RID: 6400 RVA: 0x00010AAA File Offset: 0x0000ECAA
	private bool TryGetSpawnPointAt(int index, GameModeType gameMode, TeamID teamID, out SpawnPoint point)
	{
		point = ((index >= this.GetSpawnPointList(gameMode, teamID).Count) ? null : this.GetSpawnPointList(gameMode, teamID)[index]);
		return point != null;
	}

	// Token: 0x06001901 RID: 6401 RVA: 0x0008629C File Offset: 0x0008449C
	private bool TryGetRandomSpawnPoint(GameModeType gameMode, TeamID teamID, out SpawnPoint point)
	{
		IList<SpawnPoint> spawnPointList = this.GetSpawnPointList(gameMode, teamID);
		point = ((spawnPointList.Count <= 0) ? null : spawnPointList[UnityEngine.Random.Range(0, spawnPointList.Count)]);
		return point != null;
	}

	// Token: 0x06001902 RID: 6402 RVA: 0x00010ADF File Offset: 0x0000ECDF
	private IList<SpawnPoint> GetSpawnPointList(GameModeType gameMode, TeamID team)
	{
		if (gameMode == GameModeType.None)
		{
			return this._spawnPointsDictionary[GameModeType.DeathMatch][TeamID.NONE];
		}
		return this._spawnPointsDictionary[gameMode][team];
	}

	// Token: 0x06001903 RID: 6403 RVA: 0x000862E0 File Offset: 0x000844E0
	public void ConfigureSpawnPoints(SpawnPoint[] points)
	{
		this.Clear();
		foreach (SpawnPoint spawnPoint in points)
		{
			if (this._spawnPointsDictionary.ContainsKey(spawnPoint.GameModeType))
			{
				this._spawnPointsDictionary[spawnPoint.GameModeType][spawnPoint.TeamId].Add(spawnPoint);
			}
		}
	}

	// Token: 0x06001904 RID: 6404 RVA: 0x00086348 File Offset: 0x00084548
	public int GetSpawnPointCount(GameModeType gameMode, TeamID team)
	{
		return this.GetSpawnPointList(gameMode, team).Count;
	}

	// Token: 0x06001905 RID: 6405 RVA: 0x00086364 File Offset: 0x00084564
	public void GetAllSpawnPoints(GameModeType gameMode, TeamID team, out List<Vector3> positions, out List<byte> angles)
	{
		IList<SpawnPoint> spawnPointList = this.GetSpawnPointList(gameMode, team);
		positions = new List<Vector3>(spawnPointList.Count);
		angles = new List<byte>(spawnPointList.Count);
		foreach (SpawnPoint spawnPoint in spawnPointList)
		{
			positions.Add(spawnPoint.Position);
			angles.Add(Conversion.Angle2Byte(spawnPoint.transform.rotation.eulerAngles.y));
		}
	}

	// Token: 0x06001906 RID: 6406 RVA: 0x0008640C File Offset: 0x0008460C
	public void GetSpawnPointAt(int index, GameModeType gameMode, TeamID team, out Vector3 position, out Quaternion rotation)
	{
		if (gameMode == GameModeType.None)
		{
			gameMode = GameModeType.DeathMatch;
		}
		SpawnPoint spawnPoint;
		if (this.TryGetSpawnPointAt(index, gameMode, team, out spawnPoint))
		{
			position = spawnPoint.transform.position;
			rotation = spawnPoint.transform.rotation;
		}
		else
		{
			Debug.LogException(new Exception(string.Concat(new object[]
			{
				"No spawnpoints found at ",
				index,
				" int list of length ",
				this.GetSpawnPointCount(gameMode, team)
			})));
			if (GameState.Current.Map != null && GameState.Current.Map.DefaultSpawnPoint != null)
			{
				position = GameState.Current.Map.DefaultSpawnPoint.position;
			}
			else
			{
				position = new Vector3(0f, 10f, 0f);
			}
			rotation = Quaternion.identity;
		}
	}

	// Token: 0x06001907 RID: 6407 RVA: 0x0008650C File Offset: 0x0008470C
	public void GetRandomSpawnPoint(GameModeType gameMode, TeamID team, out Vector3 position, out Quaternion rotation)
	{
		if (gameMode == GameModeType.None)
		{
			gameMode = GameModeType.DeathMatch;
		}
		IList<SpawnPoint> list = this._spawnPointsDictionary[gameMode][team];
		if (list.Count > 0)
		{
			SpawnPoint spawnPoint = list[UnityEngine.Random.Range(0, list.Count)];
			position = spawnPoint.transform.position;
			rotation = spawnPoint.transform.rotation;
		}
		else
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				"GetRandomSpawnPoint failed for ",
				team,
				"/",
				gameMode
			}));
			position = Vector3.zero;
			rotation = Quaternion.identity;
		}
	}

	// Token: 0x04001769 RID: 5993
	private IDictionary<GameModeType, IDictionary<TeamID, IList<SpawnPoint>>> _spawnPointsDictionary;
}
