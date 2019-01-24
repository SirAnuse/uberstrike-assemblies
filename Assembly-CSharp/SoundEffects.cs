using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public class SoundEffects : MonoBehaviour
{
	// Token: 0x060015C0 RID: 5568 RVA: 0x0000E909 File Offset: 0x0000CB09
	private void Awake()
	{
		SoundEffects.Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(SoundEffects.Instance.gameObject);
	}

	// Token: 0x04001481 RID: 5249
	public SoundEffectTunable HealthNoise_0_25;

	// Token: 0x04001482 RID: 5250
	public SoundEffectTunable HealthHeartbeat_0_25;

	// Token: 0x04001483 RID: 5251
	public SoundEffectTunable Health_100_200_Increase;

	// Token: 0x04001484 RID: 5252
	public static SoundEffects Instance;
}
