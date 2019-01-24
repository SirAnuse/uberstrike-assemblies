using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000AA RID: 170
public static class UIAudio
{
	// Token: 0x0600046F RID: 1135 RVA: 0x0002E00C File Offset: 0x0002C20C
	static UIAudio()
	{
		AudioClipConfigurator component = ((GameObject)Resources.Load("UIAudio", typeof(GameObject))).GetComponent<AudioClipConfigurator>();
		UIAudio._allClips[UIAudio.Clips.AudioVolumn] = component.Assets[0];
		UIAudio._allClips[UIAudio.Clips.ButtonClick] = component.Assets[1];
		UIAudio._allClips[UIAudio.Clips.ButtonRollover] = component.Assets[2];
		UIAudio._allClips[UIAudio.Clips.ClickReady] = component.Assets[3];
		UIAudio._allClips[UIAudio.Clips.ClickUnready] = component.Assets[4];
		UIAudio._allClips[UIAudio.Clips.CloseLoadout] = component.Assets[5];
		UIAudio._allClips[UIAudio.Clips.ClosePanel] = component.Assets[6];
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x00005394 File Offset: 0x00003594
	public static AudioClip Get(UIAudio.Clips clip)
	{
		return UIAudio._allClips[clip];
	}

	// Token: 0x040003ED RID: 1005
	private static Dictionary<UIAudio.Clips, AudioClip> _allClips = new Dictionary<UIAudio.Clips, AudioClip>();

	// Token: 0x020000AB RID: 171
	public enum Clips
	{
		// Token: 0x040003EF RID: 1007
		AudioVolumn,
		// Token: 0x040003F0 RID: 1008
		ButtonClick,
		// Token: 0x040003F1 RID: 1009
		ButtonRollover,
		// Token: 0x040003F2 RID: 1010
		ClickReady,
		// Token: 0x040003F3 RID: 1011
		ClickUnready,
		// Token: 0x040003F4 RID: 1012
		CloseLoadout,
		// Token: 0x040003F5 RID: 1013
		ClosePanel
	}
}
