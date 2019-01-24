using System;
using UnityEngine;

// Token: 0x02000303 RID: 771
[Serializable]
public class SoundEffectTunable
{
	// Token: 0x060015C2 RID: 5570 RVA: 0x0000E954 File Offset: 0x0000CB54
	public SoundEffect Interpolate(float value, float valueFrom, float valueTo)
	{
		return new SoundEffect(this.Clip, this.LinearScale(value, valueFrom, valueTo, this.VolumeLeft, this.VolumeRight), this.LinearScale(value, valueFrom, valueTo, this.PitchLeft, this.PitchRight));
	}

	// Token: 0x060015C3 RID: 5571 RVA: 0x00079E4C File Offset: 0x0007804C
	private float LinearScale(float value, float sourceFrom, float sourceTo, float targetFrom, float targetTo)
	{
		if (sourceFrom == sourceTo)
		{
			return sourceFrom;
		}
		float num = (targetTo - targetFrom) / (sourceTo - sourceFrom);
		float num2 = targetFrom - num * sourceFrom;
		return num * value + num2;
	}

	// Token: 0x04001485 RID: 5253
	public AudioClip Clip;

	// Token: 0x04001486 RID: 5254
	public float VolumeLeft = 1f;

	// Token: 0x04001487 RID: 5255
	public float VolumeRight = 1f;

	// Token: 0x04001488 RID: 5256
	public float PitchLeft = 1f;

	// Token: 0x04001489 RID: 5257
	public float PitchRight = 1f;
}
