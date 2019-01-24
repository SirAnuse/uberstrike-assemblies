using System;
using UnityEngine;

// Token: 0x020000A2 RID: 162
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class AudioTriggerArea : MonoBehaviour
{
	// Token: 0x06000448 RID: 1096 RVA: 0x000051D0 File Offset: 0x000033D0
	private void Awake()
	{
		this.audioSource = base.GetComponent<AudioSource>();
		this.audioSource.volume = 0f;
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0002DA2C File Offset: 0x0002BC2C
	private void Update()
	{
		if (this.audioSource.isPlaying)
		{
			if (this.audioSource.volume < this.wishVolume)
			{
				this.audioSource.volume += Time.deltaTime;
			}
			else
			{
				this.audioSource.volume -= Time.deltaTime;
			}
			if (this.audioSource.volume <= 0f)
			{
				this.audioSource.Stop();
			}
		}
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x000051EE File Offset: 0x000033EE
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			this.audioSource.loop = this.loopClip;
			this.wishVolume = this.maxVolume;
			this.audioSource.Play();
		}
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0000522D File Offset: 0x0000342D
	private void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Player" && this.audioSource.isPlaying)
		{
			this.wishVolume = 0f;
		}
	}

	// Token: 0x040003D5 RID: 981
	[SerializeField]
	private bool loopClip;

	// Token: 0x040003D6 RID: 982
	[SerializeField]
	private float maxVolume;

	// Token: 0x040003D7 RID: 983
	private AudioSource audioSource;

	// Token: 0x040003D8 RID: 984
	private float wishVolume;
}
