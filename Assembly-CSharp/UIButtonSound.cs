using System;
using UnityEngine;

// Token: 0x02000015 RID: 21
[AddComponentMenu("NGUI/Interaction/Button Sound")]
public class UIButtonSound : MonoBehaviour
{
	// Token: 0x06000067 RID: 103 RVA: 0x00016F14 File Offset: 0x00015114
	private void OnHover(bool isOver)
	{
		if (base.enabled && ((isOver && this.trigger == UIButtonSound.Trigger.OnMouseOver) || (!isOver && this.trigger == UIButtonSound.Trigger.OnMouseOut)))
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00016F68 File Offset: 0x00015168
	private void OnPress(bool isPressed)
	{
		if (base.enabled && ((isPressed && this.trigger == UIButtonSound.Trigger.OnPress) || (!isPressed && this.trigger == UIButtonSound.Trigger.OnRelease)))
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00002663 File Offset: 0x00000863
	private void OnClick()
	{
		if (base.enabled && this.trigger == UIButtonSound.Trigger.OnClick)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x0400007E RID: 126
	public AudioClip audioClip;

	// Token: 0x0400007F RID: 127
	public UIButtonSound.Trigger trigger;

	// Token: 0x04000080 RID: 128
	public float volume = 1f;

	// Token: 0x04000081 RID: 129
	public float pitch = 1f;

	// Token: 0x02000016 RID: 22
	public enum Trigger
	{
		// Token: 0x04000083 RID: 131
		OnClick,
		// Token: 0x04000084 RID: 132
		OnMouseOver,
		// Token: 0x04000085 RID: 133
		OnMouseOut,
		// Token: 0x04000086 RID: 134
		OnPress,
		// Token: 0x04000087 RID: 135
		OnRelease
	}
}
