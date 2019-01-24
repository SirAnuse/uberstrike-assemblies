using System;
using UnityEngine;

// Token: 0x0200028E RID: 654
public class Teleport : MonoBehaviour
{
	// Token: 0x0600120A RID: 4618 RVA: 0x0000C78F File Offset: 0x0000A98F
	private void Awake()
	{
		this._audio = base.GetComponent<AudioSource>();
	}

	// Token: 0x0600120B RID: 4619 RVA: 0x0006A948 File Offset: 0x00068B48
	private void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			if (this._audio)
			{
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(this._sound, 0UL, 1f, 1f);
			}
			GameState.Current.Player.SpawnPlayerAt(this._spawnPoint.position, this._spawnPoint.rotation);
		}
		else if (c.tag == "Prop")
		{
			c.transform.position = this._spawnPoint.position;
		}
	}

	// Token: 0x04000EF1 RID: 3825
	[SerializeField]
	private Transform _spawnPoint;

	// Token: 0x04000EF2 RID: 3826
	[SerializeField]
	private AudioClip _sound;

	// Token: 0x04000EF3 RID: 3827
	private AudioSource _audio;
}
