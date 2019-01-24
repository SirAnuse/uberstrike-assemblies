using System;
using UnityEngine;

// Token: 0x020002BA RID: 698
internal static class GraphicSettings
{
	// Token: 0x06001359 RID: 4953 RVA: 0x00070C98 File Offset: 0x0006EE98
	public static void SetQualityLevel(int level)
	{
		if (level > 2 || level < 0)
		{
			level = 1;
		}
		QualitySettings.SetQualityLevel(level, true);
		ApplicationDataManager.ApplicationOptions.VideoQualityLevel = level;
		switch (level)
		{
		case 0:
			ApplicationDataManager.ApplicationOptions.VideoBloomAndFlares = false;
			ApplicationDataManager.ApplicationOptions.VideoVignetting = false;
			ApplicationDataManager.ApplicationOptions.VideoMotionBlur = false;
			ApplicationDataManager.ApplicationOptions.VideoWaterMode = 0;
			ApplicationDataManager.ApplicationOptions.VideoPostProcessing = false;
			break;
		case 1:
			ApplicationDataManager.ApplicationOptions.VideoBloomAndFlares = true;
			ApplicationDataManager.ApplicationOptions.VideoVignetting = false;
			ApplicationDataManager.ApplicationOptions.VideoMotionBlur = true;
			ApplicationDataManager.ApplicationOptions.VideoWaterMode = 1;
			ApplicationDataManager.ApplicationOptions.VideoPostProcessing = true;
			break;
		case 2:
			ApplicationDataManager.ApplicationOptions.VideoBloomAndFlares = true;
			ApplicationDataManager.ApplicationOptions.VideoMotionBlur = true;
			ApplicationDataManager.ApplicationOptions.VideoVignetting = true;
			ApplicationDataManager.ApplicationOptions.VideoWaterMode = ((Application.platform != RuntimePlatform.OSXPlayer && Application.platform != RuntimePlatform.OSXWebPlayer) ? 2 : 1);
			ApplicationDataManager.ApplicationOptions.VideoPostProcessing = true;
			break;
		}
	}
}
