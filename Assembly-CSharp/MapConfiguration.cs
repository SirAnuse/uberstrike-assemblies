using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002EB RID: 747
public class MapConfiguration : MonoBehaviour
{
	// Token: 0x17000528 RID: 1320
	// (get) Token: 0x0600157A RID: 5498 RVA: 0x0000E69B File Offset: 0x0000C89B
	public bool IsEnabled
	{
		get
		{
			return this._isEnabled;
		}
	}

	// Token: 0x17000529 RID: 1321
	// (get) Token: 0x0600157B RID: 5499 RVA: 0x00078674 File Offset: 0x00076874
	public Transform DefaultSpawnPoint
	{
		get
		{
			Transform result;
			try
			{
				if (this._defaultSpawnPoint)
				{
					result = this._defaultSpawnPoint;
				}
				else
				{
					Debug.LogError("No DefaultSpawnPoint assigned for " + base.gameObject.name);
					result = this._spawnPoints.transform.GetChild(0).GetChild(0);
				}
			}
			catch
			{
				Debug.LogError("No DefaultSpawnPoint assigned for " + base.gameObject.name);
				result = base.transform;
			}
			return result;
		}
	}

	// Token: 0x1700052A RID: 1322
	// (get) Token: 0x0600157C RID: 5500 RVA: 0x0000E6A3 File Offset: 0x0000C8A3
	// (set) Token: 0x0600157D RID: 5501 RVA: 0x0000E6AB File Offset: 0x0000C8AB
	public string SceneName { get; private set; }

	// Token: 0x1700052B RID: 1323
	// (get) Token: 0x0600157E RID: 5502 RVA: 0x0000E6B4 File Offset: 0x0000C8B4
	public Camera Camera
	{
		get
		{
			return this._camera;
		}
	}

	// Token: 0x1700052C RID: 1324
	// (get) Token: 0x0600157F RID: 5503 RVA: 0x0000E6BC File Offset: 0x0000C8BC
	public FootStepSoundType DefaultFootStep
	{
		get
		{
			return this._defaultFootStep;
		}
	}

	// Token: 0x1700052D RID: 1325
	// (get) Token: 0x06001580 RID: 5504 RVA: 0x0000E6C4 File Offset: 0x0000C8C4
	public Transform DefaultViewPoint
	{
		get
		{
			return this._defaultViewPoint;
		}
	}

	// Token: 0x1700052E RID: 1326
	// (get) Token: 0x06001581 RID: 5505 RVA: 0x0000E6CC File Offset: 0x0000C8CC
	public GameObject SpawnPoints
	{
		get
		{
			return this._spawnPoints;
		}
	}

	// Token: 0x1700052F RID: 1327
	// (get) Token: 0x06001582 RID: 5506 RVA: 0x0000E6D4 File Offset: 0x0000C8D4
	public bool HasWaterPlane
	{
		get
		{
			return this._waterPlane != null;
		}
	}

	// Token: 0x17000530 RID: 1328
	// (get) Token: 0x06001583 RID: 5507 RVA: 0x00078718 File Offset: 0x00076918
	public float WaterPlaneHeight
	{
		get
		{
			return (!this._waterPlane) ? float.MinValue : this._waterPlane.position.y;
		}
	}

	// Token: 0x06001584 RID: 5508 RVA: 0x00078754 File Offset: 0x00076954
	private void Awake()
	{
		if (this._defaultViewPoint == null)
		{
			this._defaultViewPoint = base.transform;
		}
		Singleton<SpawnPointManager>.Instance.ConfigureSpawnPoints(this.SpawnPoints.GetComponentsInChildren<SpawnPoint>(true));
		GameState.Current.Map = this;
		this.SceneName = Singleton<SceneLoader>.Instance.CurrentScene;
	}

	// Token: 0x06001585 RID: 5509 RVA: 0x000787B0 File Offset: 0x000769B0
	public void UpdateVolumes(float volume = 1f)
	{
		foreach (KeyValuePair<AudioSource, float> keyValuePair in this.audioSources)
		{
			keyValuePair.Key.volume = keyValuePair.Value * volume;
		}
	}

	// Token: 0x06001586 RID: 5510 RVA: 0x00078818 File Offset: 0x00076A18
	private void Start()
	{
		this.audioSources = new Dictionary<AudioSource, float>();
		foreach (AudioSource audioSource in base.GetComponentsInChildren<AudioSource>())
		{
			this.audioSources.Add(audioSource, audioSource.volume);
		}
		this.UpdateVolumes(ApplicationDataManager.ApplicationOptions.AudioMusicVolume);
	}

	// Token: 0x04001413 RID: 5139
	[SerializeField]
	private bool _isEnabled = true;

	// Token: 0x04001414 RID: 5140
	[SerializeField]
	private Transform _defaultSpawnPoint;

	// Token: 0x04001415 RID: 5141
	[SerializeField]
	private FootStepSoundType _defaultFootStep = FootStepSoundType.Sand;

	// Token: 0x04001416 RID: 5142
	[SerializeField]
	private Camera _camera;

	// Token: 0x04001417 RID: 5143
	[SerializeField]
	private Transform _defaultViewPoint;

	// Token: 0x04001418 RID: 5144
	[SerializeField]
	protected GameObject _staticContentParent;

	// Token: 0x04001419 RID: 5145
	[SerializeField]
	private GameObject _spawnPoints;

	// Token: 0x0400141A RID: 5146
	[SerializeField]
	private Transform _waterPlane;

	// Token: 0x0400141B RID: 5147
	private Dictionary<AudioSource, float> audioSources;
}
