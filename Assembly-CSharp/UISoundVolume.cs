using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
[RequireComponent(typeof(UISlider))]
[AddComponentMenu("NGUI/Interaction/Sound Volume")]
public class UISoundVolume : MonoBehaviour
{
	// Token: 0x0600013C RID: 316 RVA: 0x000030BA File Offset: 0x000012BA
	private void Awake()
	{
		this.mSlider = base.GetComponent<UISlider>();
		this.mSlider.sliderValue = NGUITools.soundVolume;
		this.mSlider.eventReceiver = base.gameObject;
	}

	// Token: 0x0600013D RID: 317 RVA: 0x000030E9 File Offset: 0x000012E9
	private void OnSliderChange(float val)
	{
		NGUITools.soundVolume = val;
	}

	// Token: 0x04000161 RID: 353
	private UISlider mSlider;
}
