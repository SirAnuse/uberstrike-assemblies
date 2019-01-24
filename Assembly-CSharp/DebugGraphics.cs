using System;
using UnityEngine;

// Token: 0x020000DB RID: 219
public class DebugGraphics : IDebugPage
{
	// Token: 0x1700023E RID: 574
	// (get) Token: 0x060007B4 RID: 1972 RVA: 0x00006ECA File Offset: 0x000050CA
	public string Title
	{
		get
		{
			return "Graphics";
		}
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x000350F8 File Offset: 0x000332F8
	public void Draw()
	{
		GUILayout.Label("graphicsDeviceID: " + SystemInfo.graphicsDeviceID, new GUILayoutOption[0]);
		GUILayout.Label("graphicsDeviceNameD: " + SystemInfo.graphicsDeviceName, new GUILayoutOption[0]);
		GUILayout.Label("graphicsDeviceVendorD: " + SystemInfo.graphicsDeviceVendor, new GUILayoutOption[0]);
		GUILayout.Label("graphicsDeviceVendorIDD: " + SystemInfo.graphicsDeviceVendorID, new GUILayoutOption[0]);
		GUILayout.Label("graphicsDeviceVersionD: " + SystemInfo.graphicsDeviceVersion, new GUILayoutOption[0]);
		GUILayout.Label("graphicsMemorySizeD: " + SystemInfo.graphicsMemorySize, new GUILayoutOption[0]);
		GUILayout.Label("graphicsPixelFillrateD: " + SystemInfo.graphicsPixelFillrate, new GUILayoutOption[0]);
		GUILayout.Label("graphicsShaderLevelD: " + SystemInfo.graphicsShaderLevel, new GUILayoutOption[0]);
		GUILayout.Label("supportedRenderTargetCountD: " + SystemInfo.supportedRenderTargetCount, new GUILayoutOption[0]);
		GUILayout.Label("supportsImageEffectsD: " + SystemInfo.supportsImageEffects, new GUILayoutOption[0]);
		GUILayout.Label("supportsRenderTexturesD: " + SystemInfo.supportsRenderTextures, new GUILayoutOption[0]);
		GUILayout.Label("supportsShadowsD: " + SystemInfo.supportsShadows, new GUILayoutOption[0]);
		GUILayout.Label("supportsVertexPrograms: " + SystemInfo.supportsVertexPrograms, new GUILayoutOption[0]);
		QualitySettings.pixelLightCount = CmuneGUI.HorizontalScrollbar("pixelLightCount: ", QualitySettings.pixelLightCount, 0, 10);
		QualitySettings.masterTextureLimit = CmuneGUI.HorizontalScrollbar("masterTextureLimit: ", QualitySettings.masterTextureLimit, 0, 20);
		QualitySettings.maxQueuedFrames = CmuneGUI.HorizontalScrollbar("maxQueuedFrames: ", QualitySettings.maxQueuedFrames, 0, 10);
		QualitySettings.maximumLODLevel = CmuneGUI.HorizontalScrollbar("maximumLODLevel: ", QualitySettings.maximumLODLevel, 0, 7);
		QualitySettings.vSyncCount = CmuneGUI.HorizontalScrollbar("vSyncCount: ", QualitySettings.vSyncCount, 0, 2);
		QualitySettings.antiAliasing = CmuneGUI.HorizontalScrollbar("antiAliasing: ", QualitySettings.antiAliasing, 0, 4);
		QualitySettings.lodBias = CmuneGUI.HorizontalScrollbar("lodBias: ", QualitySettings.lodBias, 0, 4);
		Shader.globalMaximumLOD = CmuneGUI.HorizontalScrollbar("globalMaximumLOD: ", Shader.globalMaximumLOD, 100, 600);
	}
}
