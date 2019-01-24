using System;
using UnityEngine;

// Token: 0x0200009B RID: 155
[RequireComponent(typeof(Collider))]
public class AudioEffectArea : MonoBehaviour
{
	// Token: 0x06000428 RID: 1064 RVA: 0x0002D5B4 File Offset: 0x0002B7B4
	private void Awake()
	{
		base.collider.isTrigger = true;
		if (this.indoorEnvironment != null)
		{
			this.indoorEnvironment.SetActive(true);
		}
		if (this.outdoorEnvironment != null)
		{
			this.outdoorEnvironment.SetActive(false);
		}
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x0002D608 File Offset: 0x0002B808
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			if (this.outdoorEnvironment != null)
			{
				this.outdoorEnvironment.SetActive(false);
			}
			if (this.indoorEnvironment != null)
			{
				this.indoorEnvironment.SetActive(true);
			}
		}
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x0002D664 File Offset: 0x0002B864
	private void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Player")
		{
			if (this.outdoorEnvironment != null)
			{
				this.outdoorEnvironment.SetActive(true);
			}
			if (this.indoorEnvironment != null)
			{
				this.indoorEnvironment.SetActive(false);
			}
		}
	}

	// Token: 0x040003C0 RID: 960
	[SerializeField]
	private GameObject outdoorEnvironment;

	// Token: 0x040003C1 RID: 961
	[SerializeField]
	private GameObject indoorEnvironment;
}
