using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002DF RID: 735
public class SfxManager : AutoMonoBehaviour<SfxManager>
{
	// Token: 0x1700050F RID: 1295
	// (get) Token: 0x06001512 RID: 5394 RVA: 0x0000E234 File Offset: 0x0000C434
	public static float EffectsAudioVolume
	{
		get
		{
			return ApplicationDataManager.ApplicationOptions.AudioEffectsVolume;
		}
	}

	// Token: 0x17000510 RID: 1296
	// (get) Token: 0x06001513 RID: 5395 RVA: 0x0000E240 File Offset: 0x0000C440
	public static float MusicAudioVolume
	{
		get
		{
			return ApplicationDataManager.ApplicationOptions.AudioMusicVolume;
		}
	}

	// Token: 0x17000511 RID: 1297
	// (get) Token: 0x06001514 RID: 5396 RVA: 0x0000E24C File Offset: 0x0000C44C
	public static float MasterAudioVolume
	{
		get
		{
			return ApplicationDataManager.ApplicationOptions.AudioMasterVolume;
		}
	}

	// Token: 0x06001515 RID: 5397 RVA: 0x00077134 File Offset: 0x00075334
	private void Awake()
	{
		this.audioPool = new SfxManager.AudioPool(10);
		this.gameAudioSource = base.gameObject.AddComponent<AudioSource>();
		this.gameAudioSource.loop = false;
		this.gameAudioSource.playOnAwake = false;
		this.gameAudioSource.rolloffMode = AudioRolloffMode.Linear;
		this.gameAudioSource.priority = 100;
		this.uiAudioSource = base.gameObject.AddComponent<AudioSource>();
		this.uiAudioSource.loop = false;
		this.uiAudioSource.playOnAwake = false;
		this.uiAudioSource.rolloffMode = AudioRolloffMode.Linear;
		this.uiAudioSource.priority = 100;
		this.uiAudioSourceLooped = base.gameObject.AddComponent<AudioSource>();
		this.uiAudioSourceLooped.loop = true;
		this.uiAudioSourceLooped.playOnAwake = false;
		this.uiAudioSourceLooped.rolloffMode = AudioRolloffMode.Linear;
		this._footStepDirt = new AudioClip[]
		{
			GameAudio.FootStepDirt1,
			GameAudio.FootStepDirt2,
			GameAudio.FootStepDirt3,
			GameAudio.FootStepDirt4
		};
		this._footStepGrass = new AudioClip[]
		{
			GameAudio.FootStepGrass1,
			GameAudio.FootStepGrass2,
			GameAudio.FootStepGrass3,
			GameAudio.FootStepGrass4
		};
		this._footStepMetal = new AudioClip[]
		{
			GameAudio.FootStepMetal1,
			GameAudio.FootStepMetal2,
			GameAudio.FootStepMetal3,
			GameAudio.FootStepMetal4
		};
		this._footStepHeavyMetal = new AudioClip[]
		{
			GameAudio.FootStepHeavyMetal1,
			GameAudio.FootStepHeavyMetal2,
			GameAudio.FootStepHeavyMetal3,
			GameAudio.FootStepHeavyMetal4
		};
		this._footStepRock = new AudioClip[]
		{
			GameAudio.FootStepRock1,
			GameAudio.FootStepRock2,
			GameAudio.FootStepRock3,
			GameAudio.FootStepRock4
		};
		this._footStepSand = new AudioClip[]
		{
			GameAudio.FootStepSand1,
			GameAudio.FootStepSand2,
			GameAudio.FootStepSand3,
			GameAudio.FootStepSand4
		};
		this._footStepWater = new AudioClip[]
		{
			GameAudio.FootStepWater1,
			GameAudio.FootStepWater2,
			GameAudio.FootStepWater3
		};
		this._footStepWood = new AudioClip[]
		{
			GameAudio.FootStepWood1,
			GameAudio.FootStepWood2,
			GameAudio.FootStepWood3,
			GameAudio.FootStepWood4
		};
		this._swimAboveWater = new AudioClip[]
		{
			GameAudio.SwimAboveWater1,
			GameAudio.SwimAboveWater2,
			GameAudio.SwimAboveWater3,
			GameAudio.SwimAboveWater4
		};
		this._swimUnderWater = new AudioClip[]
		{
			GameAudio.SwimUnderWater
		};
		this._footStepSnow = new AudioClip[]
		{
			GameAudio.FootStepSnow1,
			GameAudio.FootStepSnow2,
			GameAudio.FootStepSnow3,
			GameAudio.FootStepSnow4
		};
		this._footStepGlass = new AudioClip[]
		{
			GameAudio.FootStepGlass1,
			GameAudio.FootStepGlass2,
			GameAudio.FootStepGlass3,
			GameAudio.FootStepGlass4
		};
		AudioClip[] value = new AudioClip[]
		{
			GameAudio.ImpactCement1,
			GameAudio.ImpactCement2,
			GameAudio.ImpactCement3,
			GameAudio.ImpactCement4
		};
		AudioClip[] value2 = new AudioClip[]
		{
			GameAudio.ImpactGlass1,
			GameAudio.ImpactGlass2,
			GameAudio.ImpactGlass3,
			GameAudio.ImpactGlass4,
			GameAudio.ImpactGlass5
		};
		AudioClip[] value3 = new AudioClip[]
		{
			GameAudio.ImpactGrass1,
			GameAudio.ImpactGrass2,
			GameAudio.ImpactGrass3,
			GameAudio.ImpactGrass4
		};
		AudioClip[] value4 = new AudioClip[]
		{
			GameAudio.ImpactMetal1,
			GameAudio.ImpactMetal2,
			GameAudio.ImpactMetal3,
			GameAudio.ImpactMetal4,
			GameAudio.ImpactMetal5
		};
		AudioClip[] value5 = new AudioClip[]
		{
			GameAudio.ImpactSand1,
			GameAudio.ImpactSand2,
			GameAudio.ImpactSand3,
			GameAudio.ImpactSand4,
			GameAudio.ImpactSand5
		};
		AudioClip[] value6 = new AudioClip[]
		{
			GameAudio.ImpactStone1,
			GameAudio.ImpactStone2,
			GameAudio.ImpactStone3,
			GameAudio.ImpactStone4,
			GameAudio.ImpactStone5
		};
		AudioClip[] value7 = new AudioClip[]
		{
			GameAudio.ImpactWater1,
			GameAudio.ImpactWater2,
			GameAudio.ImpactWater3,
			GameAudio.ImpactWater4,
			GameAudio.ImpactWater5
		};
		AudioClip[] value8 = new AudioClip[]
		{
			GameAudio.ImpactWood1,
			GameAudio.ImpactWood2,
			GameAudio.ImpactWood3,
			GameAudio.ImpactWood4,
			GameAudio.ImpactWood5
		};
		this._surfaceImpactSoundMap = new Dictionary<string, AudioClip[]>
		{
			{
				"Wood",
				value8
			},
			{
				"SolidWood",
				value8
			},
			{
				"Stone",
				value6
			},
			{
				"Metal",
				value4
			},
			{
				"Sand",
				value5
			},
			{
				"Grass",
				value3
			},
			{
				"Glass",
				value2
			},
			{
				"Cement",
				value
			},
			{
				"Water",
				value7
			}
		};
	}

	// Token: 0x06001516 RID: 5398 RVA: 0x0000E258 File Offset: 0x0000C458
	public void PlayInGameAudioClip(AudioClip audioClip, ulong delay = 0UL)
	{
		if (audioClip != null)
		{
			AutoMonoBehaviour<SfxManager>.Instance.gameAudioSource.PlayOneShot(audioClip);
		}
	}

	// Token: 0x06001517 RID: 5399 RVA: 0x0000E273 File Offset: 0x0000C473
	public void Play2dAudioClip(SoundEffect sound)
	{
		this.Play2dAudioClip(sound.Clip, 0UL, sound.Volume, sound.Pitch);
	}

	// Token: 0x06001518 RID: 5400 RVA: 0x000775E0 File Offset: 0x000757E0
	public void Play2dAudioClip(AudioClip audioClip, ulong delay = 0UL, float volume = 1f, float pitch = 1f)
	{
		if (audioClip == null)
		{
			return;
		}
		if (delay > 0UL)
		{
			base.StartCoroutine(this.CoPlayDelayedClip(audioClip, delay / 1000f));
		}
		else
		{
			AutoMonoBehaviour<SfxManager>.Instance.uiAudioSource.PlayOneShot(audioClip);
		}
		ApplicationOptions applicationOptions = ApplicationDataManager.ApplicationOptions;
		float num = (!applicationOptions.AudioEnabled) ? 0f : (applicationOptions.AudioEffectsVolume * applicationOptions.AudioMasterVolume);
		AutoMonoBehaviour<SfxManager>.Instance.uiAudioSource.volume = num * volume;
		AutoMonoBehaviour<SfxManager>.Instance.uiAudioSource.pitch = pitch;
	}

	// Token: 0x06001519 RID: 5401 RVA: 0x0000E28F File Offset: 0x0000C48F
	public void PlayLoopedAudioClip(SoundEffect sound)
	{
		this.PlayLoopedAudioClip(sound.Clip, sound.Volume, sound.Pitch);
	}

	// Token: 0x0600151A RID: 5402 RVA: 0x0007766C File Offset: 0x0007586C
	public void PlayLoopedAudioClip(AudioClip audioClip, float volume = 1f, float pitch = 1f)
	{
		if (audioClip == null)
		{
			return;
		}
		ApplicationOptions applicationOptions = ApplicationDataManager.ApplicationOptions;
		float num = (!applicationOptions.AudioEnabled) ? 0f : applicationOptions.AudioEffectsVolume;
		this.uiAudioSourceLooped.volume = num * Mathf.Clamp01(volume);
		this.uiAudioSourceLooped.pitch = Mathf.Clamp(pitch, -3f, 3f);
		if (this.uiAudioSourceLooped.clip == audioClip && this.uiAudioSourceLooped.isPlaying)
		{
			return;
		}
		this.uiAudioSourceLooped.clip = audioClip;
		this.uiAudioSourceLooped.Play();
	}

	// Token: 0x0600151B RID: 5403 RVA: 0x0000E2A9 File Offset: 0x0000C4A9
	public void StopLoopedAudioClip()
	{
		this.uiAudioSourceLooped.Stop();
	}

	// Token: 0x0600151C RID: 5404 RVA: 0x00077708 File Offset: 0x00075908
	public void Play3dAudioClip(AudioClip clip, Vector3 position, float volume = 1f)
	{
		ApplicationOptions applicationOptions = ApplicationDataManager.ApplicationOptions;
		float num = (!applicationOptions.AudioEnabled) ? 0f : (applicationOptions.AudioEffectsVolume * applicationOptions.AudioMasterVolume);
		volume *= num;
		this.audioPool.PlayClipAtPoint(clip, position, volume);
	}

	// Token: 0x0600151D RID: 5405 RVA: 0x0007774C File Offset: 0x0007594C
	public AudioClip GetFootStepAudioClip(FootStepSoundType footStep)
	{
		AudioClip[] array;
		switch (footStep)
		{
		case FootStepSoundType.Grass:
			array = this._footStepGrass;
			break;
		case FootStepSoundType.Metal:
			array = this._footStepMetal;
			break;
		case FootStepSoundType.Rock:
			array = this._footStepRock;
			break;
		case FootStepSoundType.Sand:
			array = this._footStepSand;
			break;
		case FootStepSoundType.Water:
			array = this._footStepWater;
			break;
		case FootStepSoundType.Wood:
			array = this._footStepWood;
			break;
		case FootStepSoundType.Swim:
			array = this._swimAboveWater;
			break;
		case FootStepSoundType.Dive:
			array = this._swimUnderWater;
			break;
		case FootStepSoundType.Snow:
			array = this._footStepSnow;
			break;
		case FootStepSoundType.HeavyMetal:
			array = this._footStepHeavyMetal;
			break;
		case FootStepSoundType.Glass:
			array = this._footStepGlass;
			break;
		default:
			array = this._footStepDirt;
			break;
		}
		if (array.Length > 1)
		{
			return array[UnityEngine.Random.Range(0, array.Length)];
		}
		return array[0];
	}

	// Token: 0x0600151E RID: 5406 RVA: 0x00077810 File Offset: 0x00075A10
	public void PlayImpactSound(string surfaceType, Vector3 position)
	{
		AudioClip[] array = null;
		if (this._surfaceImpactSoundMap.TryGetValue(surfaceType, out array))
		{
			this.Play3dAudioClip(array[UnityEngine.Random.Range(0, array.Length)], position, 1f);
		}
	}

	// Token: 0x0600151F RID: 5407 RVA: 0x0000E2B6 File Offset: 0x0000C4B6
	public void EnableAudio(bool enabled)
	{
		AudioListener.volume = ((!enabled) ? 0f : ApplicationDataManager.ApplicationOptions.AudioMasterVolume);
	}

	// Token: 0x06001520 RID: 5408 RVA: 0x0000E2D1 File Offset: 0x0000C4D1
	public void UpdateMasterVolume()
	{
		if (ApplicationDataManager.ApplicationOptions.AudioEnabled)
		{
			AudioListener.volume = ApplicationDataManager.ApplicationOptions.AudioMasterVolume;
		}
	}

	// Token: 0x06001521 RID: 5409 RVA: 0x00077848 File Offset: 0x00075A48
	public void UpdateMusicVolume()
	{
		if (ApplicationDataManager.ApplicationOptions.AudioEnabled)
		{
			AutoMonoBehaviour<BackgroundMusicPlayer>.Instance.Volume = ApplicationDataManager.ApplicationOptions.AudioMusicVolume;
			if (GameState.Current.Map != null)
			{
				GameState.Current.Map.UpdateVolumes(ApplicationDataManager.ApplicationOptions.AudioMusicVolume);
			}
		}
	}

	// Token: 0x06001522 RID: 5410 RVA: 0x000778A0 File Offset: 0x00075AA0
	public void UpdateEffectsVolume()
	{
		ApplicationOptions applicationOptions = ApplicationDataManager.ApplicationOptions;
		float volume = (!applicationOptions.AudioEnabled) ? 0f : applicationOptions.AudioEffectsVolume;
		AutoMonoBehaviour<SfxManager>.Instance.uiAudioSource.volume = volume;
		AutoMonoBehaviour<SfxManager>.Instance.gameAudioSource.volume = volume;
		AutoMonoBehaviour<SfxManager>.Instance.uiAudioSourceLooped.volume = volume;
	}

	// Token: 0x06001523 RID: 5411 RVA: 0x0000E2EE File Offset: 0x0000C4EE
	private IEnumerator CoPlayDelayedClip(AudioClip _clip, float _secondsDelay)
	{
		yield return new WaitForSeconds(_secondsDelay);
		AutoMonoBehaviour<SfxManager>.Instance.uiAudioSource.PlayOneShot(_clip);
		yield break;
	}

	// Token: 0x040013DB RID: 5083
	private SfxManager.AudioPool audioPool;

	// Token: 0x040013DC RID: 5084
	private AudioSource gameAudioSource;

	// Token: 0x040013DD RID: 5085
	private AudioSource uiAudioSource;

	// Token: 0x040013DE RID: 5086
	private AudioSource uiAudioSourceLooped;

	// Token: 0x040013DF RID: 5087
	private AudioClip[] _footStepDirt;

	// Token: 0x040013E0 RID: 5088
	private AudioClip[] _footStepGrass;

	// Token: 0x040013E1 RID: 5089
	private AudioClip[] _footStepMetal;

	// Token: 0x040013E2 RID: 5090
	private AudioClip[] _footStepHeavyMetal;

	// Token: 0x040013E3 RID: 5091
	private AudioClip[] _footStepRock;

	// Token: 0x040013E4 RID: 5092
	private AudioClip[] _footStepSand;

	// Token: 0x040013E5 RID: 5093
	private AudioClip[] _footStepWater;

	// Token: 0x040013E6 RID: 5094
	private AudioClip[] _footStepWood;

	// Token: 0x040013E7 RID: 5095
	private AudioClip[] _swimAboveWater;

	// Token: 0x040013E8 RID: 5096
	private AudioClip[] _swimUnderWater;

	// Token: 0x040013E9 RID: 5097
	private AudioClip[] _footStepSnow;

	// Token: 0x040013EA RID: 5098
	private AudioClip[] _footStepGlass;

	// Token: 0x040013EB RID: 5099
	private Dictionary<string, AudioClip[]> _surfaceImpactSoundMap;

	// Token: 0x020002E0 RID: 736
	private class AudioPool
	{
		// Token: 0x06001524 RID: 5412 RVA: 0x000778FC File Offset: 0x00075AFC
		public AudioPool(int size = 10)
		{
			Transform transform = new GameObject("AudioPool").transform;
			UnityEngine.Object.DontDestroyOnLoad(transform);
			this.audioPool = new Queue<AudioSource>();
			for (int i = 0; i < size; i++)
			{
				AudioSource component = new GameObject("AudioSource", new Type[]
				{
					typeof(AudioSource)
				}).GetComponent<AudioSource>();
				component.gameObject.transform.parent = transform;
				component.playOnAwake = false;
				component.minDistance = 0f;
				component.maxDistance = 80f;
				component.rolloffMode = AudioRolloffMode.Custom;
				component.loop = false;
				this.audioPool.Enqueue(component);
			}
		}

		// Token: 0x06001525 RID: 5413 RVA: 0x000779A8 File Offset: 0x00075BA8
		public void PlayClipAtPoint(AudioClip clip, Vector3 position, float volume)
		{
			if (clip != null)
			{
				AudioSource audioSource = this.audioPool.Dequeue();
				audioSource.transform.position = position;
				audioSource.clip = clip;
				audioSource.volume = volume;
				audioSource.Play();
				this.audioPool.Enqueue(audioSource);
			}
		}

		// Token: 0x040013EC RID: 5100
		private Queue<AudioSource> audioPool;
	}
}
