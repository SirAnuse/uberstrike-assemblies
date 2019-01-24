using System;
using UnityEngine;

// Token: 0x0200009C RID: 156
public class AudioFadeArea : MonoBehaviour
{
	// Token: 0x0600042C RID: 1068 RVA: 0x00005101 File Offset: 0x00003301
	private void Awake()
	{
		base.collider.isTrigger = true;
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0000510F File Offset: 0x0000330F
	private void Update()
	{
		if (AudioFadeArea.Current == this)
		{
			this.outdoorAudio.Update();
			this.indoorAudio.Update();
		}
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x0002D6C0 File Offset: 0x0002B8C0
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			AudioFadeArea.Current = this;
			if (this.outdoorAudio != null)
			{
				this.outdoorAudio.Enabled = false;
			}
			if (this.indoorAudio != null)
			{
				this.indoorAudio.Enabled = true;
			}
		}
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x0002D718 File Offset: 0x0002B918
	private void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Player")
		{
			if (this.outdoorAudio != null)
			{
				this.outdoorAudio.Enabled = (AudioFadeArea.Current == this);
			}
			if (this.indoorAudio != null)
			{
				this.indoorAudio.Enabled = false;
			}
		}
	}

	// Token: 0x040003C2 RID: 962
	private static AudioFadeArea Current;

	// Token: 0x040003C3 RID: 963
	[SerializeField]
	private AudioFadeArea.AudioArea outdoorAudio;

	// Token: 0x040003C4 RID: 964
	[SerializeField]
	private AudioFadeArea.AudioArea indoorAudio;

	// Token: 0x0200009D RID: 157
	[Serializable]
	private class AudioArea
	{
		// Token: 0x06000430 RID: 1072 RVA: 0x0002D774 File Offset: 0x0002B974
		public AudioArea()
		{
			this.currentVolume = ((!this.enabled) ? 0f : this.maxVolume);
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00005139 File Offset: 0x00003339
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x00005141 File Offset: 0x00003341
		public bool Enabled
		{
			get
			{
				return this.enabled;
			}
			set
			{
				this.enabled = value;
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0002D7CC File Offset: 0x0002B9CC
		public bool Update()
		{
			if (this.enabled && this.currentVolume < this.maxVolume)
			{
				this.currentVolume = Mathf.Lerp(this.currentVolume, this.maxVolume, Time.deltaTime * this.fadeSpeed);
				if (Mathf.Abs(this.currentVolume - this.maxVolume) < 0.01f)
				{
					this.currentVolume = this.maxVolume;
				}
				Array.ForEach<AudioSource>(this.sources, delegate(AudioSource s)
				{
					s.volume = this.currentVolume;
				});
				return true;
			}
			if (!this.enabled && this.currentVolume > 0f)
			{
				this.currentVolume = Mathf.Lerp(this.currentVolume, 0f, Time.deltaTime * this.fadeSpeed);
				if (this.currentVolume < 0.01f)
				{
					this.currentVolume = 0f;
				}
				Array.ForEach<AudioSource>(this.sources, delegate(AudioSource s)
				{
					s.volume = this.currentVolume;
				});
				return true;
			}
			return false;
		}

		// Token: 0x040003C5 RID: 965
		[SerializeField]
		private AudioSource[] sources;

		// Token: 0x040003C6 RID: 966
		[SerializeField]
		private float maxVolume = 1f;

		// Token: 0x040003C7 RID: 967
		[SerializeField]
		private float currentVolume = 1f;

		// Token: 0x040003C8 RID: 968
		[SerializeField]
		private float fadeSpeed = 3f;

		// Token: 0x040003C9 RID: 969
		[SerializeField]
		private bool enabled;
	}
}
