using System;
using System.Collections.Generic;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class MapManager : Singleton<MapManager>
{
	// Token: 0x06001448 RID: 5192 RVA: 0x0000DA4B File Offset: 0x0000BC4B
	private MapManager()
	{
		this.Clear();
	}

	// Token: 0x170004D0 RID: 1232
	// (get) Token: 0x06001449 RID: 5193 RVA: 0x0000DA64 File Offset: 0x0000BC64
	public IEnumerable<UberstrikeMap> AllMaps
	{
		get
		{
			return this._mapsByName.Values;
		}
	}

	// Token: 0x170004D1 RID: 1233
	// (get) Token: 0x0600144A RID: 5194 RVA: 0x0000DA71 File Offset: 0x0000BC71
	public int Count
	{
		get
		{
			return this._mapsByName.Count;
		}
	}

	// Token: 0x0600144B RID: 5195 RVA: 0x00074E50 File Offset: 0x00073050
	public string GetMapDescription(int mapId)
	{
		UberstrikeMap mapWithId = this.GetMapWithId(mapId);
		if (mapWithId != null)
		{
			return mapWithId.Description;
		}
		return LocalizedStrings.None;
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x00074E78 File Offset: 0x00073078
	public string GetMapName(string name)
	{
		UberstrikeMap uberstrikeMap;
		if (this._mapsByName.TryGetValue(name, out uberstrikeMap))
		{
			return uberstrikeMap.Name;
		}
		return LocalizedStrings.None;
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x00074EA4 File Offset: 0x000730A4
	public string GetMapName(int mapId)
	{
		UberstrikeMap mapWithId = this.GetMapWithId(mapId);
		if (mapWithId != null)
		{
			return mapWithId.Name;
		}
		return LocalizedStrings.None;
	}

	// Token: 0x0600144E RID: 5198 RVA: 0x00074ECC File Offset: 0x000730CC
	public string GetMapSceneName(int mapId)
	{
		UberstrikeMap mapWithId = this.GetMapWithId(mapId);
		if (mapWithId != null)
		{
			return mapWithId.SceneName;
		}
		return LocalizedStrings.None;
	}

	// Token: 0x0600144F RID: 5199 RVA: 0x00074EF4 File Offset: 0x000730F4
	public UberstrikeMap GetMapWithId(int mapId)
	{
		foreach (UberstrikeMap uberstrikeMap in this._mapsByName.Values)
		{
			if (uberstrikeMap.Id == mapId)
			{
				return uberstrikeMap;
			}
		}
		return null;
	}

	// Token: 0x06001450 RID: 5200 RVA: 0x0000DA7E File Offset: 0x0000BC7E
	public bool MapExistsWithId(int mapId)
	{
		return this.GetMapWithId(mapId) != null;
	}

	// Token: 0x06001451 RID: 5201 RVA: 0x0000DA7E File Offset: 0x0000BC7E
	public bool HasMapWithId(int mapId)
	{
		return this.GetMapWithId(mapId) != null;
	}

	// Token: 0x06001452 RID: 5202 RVA: 0x00074F64 File Offset: 0x00073164
	private UberstrikeMap AddMapView(MapView mapView, bool isVisible = true, bool isBuiltIn = false)
	{
		UberstrikeMap uberstrikeMap = new UberstrikeMap(mapView)
		{
			IsVisible = isVisible,
			IsBuiltIn = isBuiltIn
		};
		UberstrikeMap uberstrikeMap2;
		if (this._mapsByName.TryGetValue(mapView.SceneName, out uberstrikeMap2))
		{
			uberstrikeMap.View.MapId = uberstrikeMap2.View.MapId;
			uberstrikeMap.View.Settings = uberstrikeMap2.View.Settings;
			uberstrikeMap.View.SupportedGameModes = uberstrikeMap2.View.SupportedGameModes;
		}
		this._mapsByName[mapView.SceneName] = uberstrikeMap;
		return uberstrikeMap;
	}

	// Token: 0x06001453 RID: 5203 RVA: 0x00074FF8 File Offset: 0x000731F8
	private void Clear()
	{
		this._mapsByName.Clear();
		this.AddMapView(new MapView
		{
			Description = "Menu",
			DisplayName = "Menu",
			SceneName = "Menu"
		}, false, true);
	}

	// Token: 0x06001454 RID: 5204 RVA: 0x00075044 File Offset: 0x00073244
	public bool InitializeMapsToLoad(List<MapView> mapViews)
	{
		this.Clear();
		foreach (MapView mapView in mapViews)
		{
			this.AddMapView(mapView, true, false);
		}
		return this._mapsByName.Count > 0;
	}

	// Token: 0x06001455 RID: 5205 RVA: 0x000750B0 File Offset: 0x000732B0
	public void LoadMap(UberstrikeMap map, Action onSuccess)
	{
		PickupItem.Reset();
		Debug.LogWarning("Loading map: " + map.SceneName);
		Singleton<SceneLoader>.Instance.LoadLevel(map.SceneName, delegate
		{
			if (onSuccess != null)
			{
				onSuccess();
			}
			Debug.LogWarning("Finished Loading map");
		});
	}

	// Token: 0x06001456 RID: 5206 RVA: 0x00075100 File Offset: 0x00073300
	public bool TryGetMapId(string mapName, out int mapId)
	{
		foreach (UberstrikeMap uberstrikeMap in this._mapsByName.Values)
		{
			if (uberstrikeMap.SceneName == mapName)
			{
				mapId = uberstrikeMap.Id;
				return true;
			}
		}
		mapId = 0;
		return false;
	}

	// Token: 0x0400138A RID: 5002
	private Dictionary<string, UberstrikeMap> _mapsByName = new Dictionary<string, UberstrikeMap>();
}
