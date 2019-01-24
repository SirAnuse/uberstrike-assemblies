using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001D7 RID: 471
public class OptionsPanelGUI : PanelGuiBase
{
	// Token: 0x06000D2E RID: 3374 RVA: 0x0005ABD0 File Offset: 0x00058DD0
	private void Awake()
	{
		List<string> list = new List<string>();
		int num = 0;
		string arg = string.Empty;
		foreach (Resolution resolution in ScreenResolutionManager.Resolutions)
		{
			if (++num == ScreenResolutionManager.Resolutions.Count)
			{
				arg = string.Format("({0})", LocalizedStrings.FullscreenOnly);
			}
			list.Add(string.Format("{0} X {1} {2}", resolution.width, resolution.height, arg));
		}
		ArrayList arrayList = new ArrayList(QualitySettings.names);
		if (arrayList.Contains("Mobile"))
		{
			arrayList.Remove("Mobile");
		}
		this.qualitySet = new string[arrayList.Count + 1];
		for (int i = 0; i < this.qualitySet.Length; i++)
		{
			if (i < arrayList.Count)
			{
				this.qualitySet[i] = arrayList[i].ToString();
			}
			else
			{
				this.qualitySet[i] = LocalizedStrings.Custom;
			}
		}
		this._screenResText = list.ToArray();
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x00009CB3 File Offset: 0x00007EB3
	private void OnEnable()
	{
		this.SyncGraphicsSettings();
	}

	// Token: 0x06000D30 RID: 3376 RVA: 0x0005AD20 File Offset: 0x00058F20
	private void Start()
	{
		if (ApplicationDataManager.IsMobile)
		{
			this._optionsTabs = new GUIContent[]
			{
				new GUIContent(LocalizedStrings.ControlsCaps),
				new GUIContent(LocalizedStrings.AudioCaps)
			};
			this._selectedOptionsTab = 0;
		}
		else
		{
			this._optionsTabs = new GUIContent[]
			{
				new GUIContent(LocalizedStrings.ControlsCaps),
				new GUIContent(LocalizedStrings.AudioCaps),
				new GUIContent(LocalizedStrings.VideoCaps)
			};
			this._keyCount = AutoMonoBehaviour<InputManager>.Instance.KeyMapping.Values.Count;
		}
	}

	// Token: 0x06000D31 RID: 3377 RVA: 0x0005ADB8 File Offset: 0x00058FB8
	private void OnGUI()
	{
		GUI.depth = -97;
		this._rect = new Rect((float)((Screen.width - 528) / 2), (float)((Screen.height - 320) / 2), 528f, 320f);
		GUI.BeginGroup(this._rect, GUIContent.none, BlueStonez.window_standard_grey38);
		if (this._screenResChangeDelay > 0f)
		{
			this.DrawScreenResChangePanel();
		}
		else
		{
			this.DrawOptionsPanel();
		}
		GUI.EndGroup();
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000D32 RID: 3378 RVA: 0x0005AE40 File Offset: 0x00059040
	private void DrawOptionsPanel()
	{
		GUI.SetNextControlName("OptionPanelHeading");
		GUI.Label(new Rect(0f, 0f, this._rect.width, 56f), LocalizedStrings.OptionsCaps, BlueStonez.tab_strip);
		if (GUI.GetNameOfFocusedControl() != "OptionPanelHeading")
		{
			GUI.FocusControl("OptionPanelHeading");
		}
		this._selectedOptionsTab = UnityGUI.Toolbar(new Rect(2f, 31f, this._rect.width - 5f, 22f), this._selectedOptionsTab, this._optionsTabs, this._optionsTabs.Length, BlueStonez.tab_medium);
		if (GUI.changed)
		{
			GUI.changed = false;
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
		}
		GUI.BeginGroup(new Rect(16f, 55f, this._rect.width - 32f, this._rect.height - 56f - 44f), string.Empty, BlueStonez.window_standard_grey38);
		switch (this._selectedOptionsTab)
		{
		case 0:
			this.DoControlsGroup();
			break;
		case 1:
			this.DoAudioGroup();
			break;
		case 2:
			this.DoVideoGroup();
			break;
		}
		GUI.EndGroup();
		GUI.enabled = !this._showWaterModeMenu;
		if (GUI.Button(new Rect(this._rect.width - 136f, this._rect.height - 40f, 120f, 32f), new GUIContent(LocalizedStrings.OkCaps), BlueStonez.button))
		{
			ApplicationDataManager.ApplicationOptions.SaveApplicationOptions();
			PanelManager.Instance.ClosePanel(PanelType.Options);
		}
		if (AutoMonoBehaviour<InputManager>.Instance.HasUnassignedKeyMappings)
		{
			GUI.contentColor = Color.red;
			GUI.Label(new Rect(166f, this._rect.height - 40f, this._rect.width - 136f - 166f, 32f), LocalizedStrings.UnassignedKeyMappingsWarningMsg, BlueStonez.label_interparkmed_11pt);
			GUI.contentColor = Color.white;
		}
		if (this._selectedOptionsTab == 0 && !ApplicationDataManager.IsMobile && GUITools.Button(new Rect(16f, this._rect.height - 40f, 150f, 32f), new GUIContent(LocalizedStrings.ResetDefaults), BlueStonez.button))
		{
			AutoMonoBehaviour<InputManager>.Instance.Reset();
		}
		else if (this._selectedOptionsTab == 2)
		{
			GUI.Label(new Rect(16f, this._rect.height - 40f, 150f, 32f), "FPS: " + (1f / Time.smoothDeltaTime).ToString("F1"), BlueStonez.label_interparkbold_16pt_left);
		}
		GUI.enabled = true;
	}

	// Token: 0x06000D33 RID: 3379 RVA: 0x0005B13C File Offset: 0x0005933C
	private void DrawScreenResChangePanel()
	{
		GUI.depth = 1;
		GUI.Label(new Rect(0f, 0f, this._rect.width, 56f), LocalizedStrings.ChangingScreenResolution, BlueStonez.tab_strip);
		GUI.BeginGroup(new Rect(16f, 55f, this._rect.width - 32f, this._rect.height - 56f - 54f), string.Empty, BlueStonez.window_standard_grey38);
		GUI.Label(new Rect(24f, 18f, 460f, 20f), LocalizedStrings.ChooseNewResolution + this._screenResText[this._newScreenResIndex] + " ?", BlueStonez.label_interparkbold_16pt_left);
		GUI.Label(new Rect(0f, 0f, this._rect.width - 32f, this._rect.height - 56f - 54f), ((int)this._screenResChangeDelay).ToString(), BlueStonez.label_interparkbold_48pt);
		GUI.EndGroup();
		if (GUITools.Button(new Rect(this._rect.width - 136f - 140f, this._rect.height - 40f, 120f, 32f), new GUIContent(LocalizedStrings.OkCaps), BlueStonez.button))
		{
			ScreenResolutionManager.SetResolution(this._newScreenResIndex, true);
			this._screenResChangeDelay = 0f;
			GuiLockController.ReleaseLock(GuiDepth.Popup);
		}
		if (GUITools.Button(new Rect(this._rect.width - 136f, this._rect.height - 40f, 120f, 32f), new GUIContent(LocalizedStrings.CancelCaps), BlueStonez.button))
		{
			this._screenResChangeDelay = 0f;
			GuiLockController.ReleaseLock(GuiDepth.Popup);
			if (this._isFullscreenBefore)
			{
				ScreenResolutionManager.IsFullScreen = true;
			}
		}
	}

	// Token: 0x06000D34 RID: 3380 RVA: 0x0005B330 File Offset: 0x00059530
	private void Update()
	{
		if (this._screenResChangeDelay > 0f)
		{
			this._screenResChangeDelay -= Time.deltaTime;
			if (this._screenResChangeDelay <= 0f)
			{
				GuiLockController.ReleaseLock(GuiDepth.Popup);
			}
		}
		if (Input.GetMouseButtonUp(0) && this.graphicsChanged)
		{
			this.UpdateTextureQuality();
			this.UpdateVSyncCount();
			this.UpdateAntiAliasing();
			this.UpdatePostProcessing();
			this.graphicsChanged = false;
		}
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x0005B3AC File Offset: 0x000595AC
	private void SyncGraphicsSettings()
	{
		this._currentQuality = QualitySettings.GetQualityLevel();
		this._textureQuality = (float)(5 - QualitySettings.masterTextureLimit);
		int antiAliasing = QualitySettings.antiAliasing;
		switch (antiAliasing)
		{
		case 2:
			this._antiAliasing = 1;
			break;
		default:
			if (antiAliasing != 8)
			{
				this._antiAliasing = 0;
			}
			else
			{
				this._antiAliasing = 3;
			}
			break;
		case 4:
			this._antiAliasing = 2;
			break;
		}
		this._vsync = QualitySettings.vSyncCount;
	}

	// Token: 0x06000D36 RID: 3382 RVA: 0x0005B434 File Offset: 0x00059634
	public static bool HorizontalScrollbar(Rect rect, string title, ref float value, float min, float max)
	{
		float num = value;
		GUI.BeginGroup(rect);
		GUI.Label(new Rect(0f, 4f, rect.width, rect.height), title, BlueStonez.label_interparkbold_11pt_left);
		value = GUI.HorizontalSlider(new Rect(150f, 10f, rect.width - 200f, 30f), value, min, max, BlueStonez.horizontalSlider, BlueStonez.horizontalSliderThumb);
		GUI.Label(new Rect(rect.width - 40f, 4f, 50f, rect.height), (value >= 0f) ? Mathf.RoundToInt(value).ToString() : LocalizedStrings.Auto, BlueStonez.label_interparkbold_11pt_left);
		GUI.EndGroup();
		return value != num;
	}

	// Token: 0x06000D37 RID: 3383 RVA: 0x0005B508 File Offset: 0x00059708
	public static bool HorizontalGridbar(Rect rect, string title, ref int value, string[] set)
	{
		int num = value;
		GUI.BeginGroup(rect);
		GUI.Label(new Rect(0f, 5f, rect.width, rect.height), title, BlueStonez.label_interparkbold_11pt_left);
		value = UnityGUI.Toolbar(new Rect(150f, 5f, rect.width - 200f, 30f), value, set, set.Length, BlueStonez.tab_medium);
		GUI.EndGroup();
		return value != num;
	}

	// Token: 0x06000D38 RID: 3384 RVA: 0x0005B588 File Offset: 0x00059788
	private void DoVideoGroup()
	{
		GUI.skin = BlueStonez.Skin;
		Rect position = new Rect(1f, 1f, this._rect.width - 33f, this._rect.height - 55f - 47f);
		Rect contentRect = new Rect(0f, 0f, (float)this._desiredWidth, this._rect.height + 200f - 55f - 46f - 20f);
		int num = 10;
		int num2 = 150;
		int num3 = this._screenResText.Length * 16 + 16;
		float width = position.width - 8f - 8f - 20f;
		if (!Application.isWebPlayer || this.showResolutions)
		{
			contentRect.height += (float)(this._screenResText.Length * 16);
		}
		this._scrollVideo = GUITools.BeginScrollView(position, this._scrollVideo, contentRect, false, false, true);
		GUI.enabled = true;
		int num4 = UnityGUI.Toolbar(new Rect(0f, 5f, position.width - 10f, 22f), this._currentQuality, this.qualitySet, this.qualitySet.Length, BlueStonez.tab_medium);
		if (num4 != this._currentQuality)
		{
			this.SetCurrentQuality(num4);
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
		}
		if (OptionsPanelGUI.HorizontalScrollbar(new Rect(8f, 30f, width, 30f), LocalizedStrings.TextureQuality, ref this._textureQuality, 0f, 5f))
		{
			this.graphicsChanged = true;
			this.SetCurrentQuality(this.qualitySet.Length - 1);
		}
		if (OptionsPanelGUI.HorizontalGridbar(new Rect(8f, 60f, width, 30f), LocalizedStrings.VSync, ref this._vsync, this.vsyncSet))
		{
			this.graphicsChanged = true;
			this.SetCurrentQuality(this.qualitySet.Length - 1);
		}
		if (OptionsPanelGUI.HorizontalGridbar(new Rect(8f, 90f, width, 30f), LocalizedStrings.AntiAliasing, ref this._antiAliasing, this.antiAliasingSet))
		{
			this.graphicsChanged = true;
			this.SetCurrentQuality(this.qualitySet.Length - 1);
		}
		int num5 = 130;
		if (!ApplicationDataManager.IsMobile)
		{
			this._postProcessing = GUI.Toggle(new Rect(8f, (float)num5, width, 30f), ApplicationDataManager.ApplicationOptions.VideoPostProcessing, LocalizedStrings.ShowPostProcessingEffects, BlueStonez.toggle);
			if (this._postProcessing != ApplicationDataManager.ApplicationOptions.VideoPostProcessing)
			{
				this.graphicsChanged = true;
				this.SetCurrentQuality(this.qualitySet.Length - 1);
			}
			num5 += 30;
		}
		bool flag = GUI.Toggle(new Rect(8f, (float)num5, width, 30f), ApplicationDataManager.ApplicationOptions.VideoShowFps, LocalizedStrings.ShowFPS, BlueStonez.toggle);
		if (flag != ApplicationDataManager.ApplicationOptions.VideoShowFps)
		{
			ApplicationDataManager.ApplicationOptions.VideoShowFps = flag;
			GameData.Instance.VideoShowFps.Fire();
		}
		num5 += 30;
		if (!Application.isWebPlayer || this.showResolutions)
		{
			this.DrawGroupControl(new Rect(8f, (float)num5, width, (float)num3), LocalizedStrings.ScreenResolution, BlueStonez.label_group_interparkbold_18pt);
			GUI.BeginGroup(new Rect(8f, (float)num5, width, (float)num3));
			GUI.changed = false;
			Rect position2 = new Rect(10f, 10f, (float)(num + num2 * 2), (float)num3);
			int num6 = GUI.SelectionGrid(position2, ScreenResolutionManager.CurrentResolutionIndex, this._screenResText, 1, BlueStonez.radiobutton);
			if (num6 != ScreenResolutionManager.CurrentResolutionIndex)
			{
				if (this.INSTANT_SCREEN_RES_CHANGE)
				{
					ScreenResolutionManager.SetResolution(num6, Screen.fullScreen);
				}
				else
				{
					this.ShowScreenResChangeConfirmation(ScreenResolutionManager.CurrentResolutionIndex, num6);
				}
			}
			GUI.EndGroup();
		}
		GUITools.EndScrollView();
	}

	// Token: 0x06000D39 RID: 3385 RVA: 0x0005B980 File Offset: 0x00059B80
	private void DoAudioGroup()
	{
		float num = 130f;
		float width = (this._rect.height - 55f - 46f >= num) ? (this._rect.width - 50f) : (this._rect.width - 65f);
		this._scrollControls = GUITools.BeginScrollView(new Rect(1f, 1f, this._rect.width - 33f, this._rect.height - 55f - 46f), this._scrollControls, new Rect(0f, 0f, this._rect.width - 50f, num), false, false, true);
		this.DrawGroupControl(new Rect(8f, 20f, width, 130f), LocalizedStrings.Volume, BlueStonez.label_group_interparkbold_18pt);
		GUI.BeginGroup(new Rect(8f, 20f, width, 130f));
		ApplicationDataManager.ApplicationOptions.AudioEnabled = !GUI.Toggle(new Rect(15f, 105f, 100f, 30f), !ApplicationDataManager.ApplicationOptions.AudioEnabled, LocalizedStrings.Mute, BlueStonez.toggle);
		if (GUI.changed)
		{
			GUI.changed = false;
			AutoMonoBehaviour<SfxManager>.Instance.EnableAudio(ApplicationDataManager.ApplicationOptions.AudioEnabled);
		}
		GUITools.PushGUIState();
		GUI.enabled = ApplicationDataManager.ApplicationOptions.AudioEnabled;
		GUI.Label(new Rect(15f, 10f, 110f, 30f), LocalizedStrings.MasterVolume, BlueStonez.label_interparkbold_11pt_left);
		ApplicationDataManager.ApplicationOptions.AudioMasterVolume = GUI.HorizontalSlider(new Rect(145f, 17f, 200f, 30f), Mathf.Clamp01(ApplicationDataManager.ApplicationOptions.AudioMasterVolume), 0f, 1f, BlueStonez.horizontalSlider, BlueStonez.horizontalSliderThumb);
		if (GUI.changed)
		{
			GUI.changed = false;
			AutoMonoBehaviour<SfxManager>.Instance.UpdateMasterVolume();
		}
		GUI.Label(new Rect(350f, 10f, 100f, 30f), (ApplicationDataManager.ApplicationOptions.AudioMasterVolume * 100f).ToString("f0") + " %", BlueStonez.label_interparkbold_11pt_left);
		GUI.Label(new Rect(15f, 40f, 110f, 30f), LocalizedStrings.MusicVolume, BlueStonez.label_interparkbold_11pt_left);
		ApplicationDataManager.ApplicationOptions.AudioMusicVolume = GUI.HorizontalSlider(new Rect(145f, 47f, 200f, 30f), Mathf.Clamp01(ApplicationDataManager.ApplicationOptions.AudioMusicVolume), 0f, 1f, BlueStonez.horizontalSlider, BlueStonez.horizontalSliderThumb);
		if (GUI.changed)
		{
			GUI.changed = false;
			AutoMonoBehaviour<SfxManager>.Instance.UpdateMusicVolume();
		}
		GUI.Label(new Rect(350f, 40f, 100f, 30f), (ApplicationDataManager.ApplicationOptions.AudioMusicVolume * 100f).ToString("f0") + " %", BlueStonez.label_interparkbold_11pt_left);
		GUI.Label(new Rect(15f, 70f, 110f, 30f), LocalizedStrings.EffectsVolume, BlueStonez.label_interparkbold_11pt_left);
		ApplicationDataManager.ApplicationOptions.AudioEffectsVolume = GUI.HorizontalSlider(new Rect(145f, 77f, 200f, 30f), Mathf.Clamp01(ApplicationDataManager.ApplicationOptions.AudioEffectsVolume), 0f, 1f, BlueStonez.horizontalSlider, BlueStonez.horizontalSliderThumb);
		if (GUI.changed)
		{
			GUI.changed = false;
			AutoMonoBehaviour<SfxManager>.Instance.UpdateEffectsVolume();
		}
		GUI.Label(new Rect(350f, 70f, 100f, 30f), (ApplicationDataManager.ApplicationOptions.AudioEffectsVolume * 100f).ToString("f0") + " %", BlueStonez.label_interparkbold_11pt_left);
		GUITools.PopGUIState();
		GUI.EndGroup();
		GUITools.EndScrollView();
	}

	// Token: 0x06000D3A RID: 3386 RVA: 0x0005BD94 File Offset: 0x00059F94
	private void DoControlsGroup()
	{
		GUITools.PushGUIState();
		GUI.enabled = (this._targetMap == null);
		GUI.skin = BlueStonez.Skin;
		this._scrollControls = GUITools.BeginScrollView(new Rect(1f, 3f, this._rect.width - 33f, this._rect.height - 55f - 50f), this._scrollControls, new Rect(0f, 0f, this._rect.width - 50f, (float)(210 + this._keyCount * 21)), false, false, true);
		this.DrawGroupControl(new Rect(8f, 20f, this._rect.width - 65f, 65f), LocalizedStrings.Mouse, BlueStonez.label_group_interparkbold_18pt);
		GUI.BeginGroup(new Rect(8f, 20f, this._rect.width - 65f, 65f));
		GUI.Label(new Rect(15f, 10f, 130f, 30f), LocalizedStrings.MouseSensitivity, BlueStonez.label_interparkbold_11pt_left);
		float num = GUI.HorizontalSlider(new Rect(155f, 17f, 200f, 30f), ApplicationDataManager.ApplicationOptions.InputXMouseSensitivity, 1f, 10f, BlueStonez.horizontalSlider, BlueStonez.horizontalSliderThumb);
		GUI.Label(new Rect(370f, 10f, 100f, 30f), ApplicationDataManager.ApplicationOptions.InputXMouseSensitivity.ToString("N1"), BlueStonez.label_interparkbold_11pt_left);
		if (num != ApplicationDataManager.ApplicationOptions.InputXMouseSensitivity)
		{
			ApplicationDataManager.ApplicationOptions.InputXMouseSensitivity = num;
		}
		bool flag = GUI.Toggle(new Rect(15f, 38f, 200f, 30f), ApplicationDataManager.ApplicationOptions.InputInvertMouse, LocalizedStrings.InvertMouseButtons, BlueStonez.toggle);
		if (flag != ApplicationDataManager.ApplicationOptions.InputInvertMouse)
		{
			ApplicationDataManager.ApplicationOptions.InputInvertMouse = flag;
		}
		GUI.EndGroup();
		int num2 = 105;
		if (Input.GetJoystickNames().Length > 0)
		{
			this.DrawGroupControl(new Rect(8f, 105f, this._rect.width - 65f, 50f), LocalizedStrings.Gamepad, BlueStonez.label_group_interparkbold_18pt);
			GUI.BeginGroup(new Rect(8f, 105f, this._rect.width - 65f, 50f));
			bool flag2 = GUI.Toggle(new Rect(15f, 15f, 400f, 30f), AutoMonoBehaviour<InputManager>.Instance.IsGamepadEnabled, Input.GetJoystickNames()[0], BlueStonez.toggle);
			if (flag2 != AutoMonoBehaviour<InputManager>.Instance.IsGamepadEnabled)
			{
				AutoMonoBehaviour<InputManager>.Instance.IsGamepadEnabled = flag2;
			}
			GUI.EndGroup();
			num2 += 70;
		}
		else if (AutoMonoBehaviour<InputManager>.Instance.IsGamepadEnabled)
		{
			AutoMonoBehaviour<InputManager>.Instance.IsGamepadEnabled = false;
		}
		this.DrawGroupControl(new Rect(8f, (float)num2, this._rect.width - 65f, (float)(this._keyCount * 21 + 20)), LocalizedStrings.Keyboard, BlueStonez.label_group_interparkbold_18pt);
		GUI.BeginGroup(new Rect(8f, (float)num2, this._rect.width - 65f, (float)(this._keyCount * 21 + 20)));
		this.DoInputControlMapping(new Rect(5f, 5f, this._rect.width - 60f, (float)(this._keyCount * 21 + 20)));
		GUI.EndGroup();
		GUITools.EndScrollView();
		GUITools.PopGUIState();
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x00009CBB File Offset: 0x00007EBB
	private void UseMultiTouch()
	{
		ApplicationDataManager.ApplicationOptions.UseMultiTouch = true;
		PanelManager.Instance.OpenPanel(PanelType.Options);
	}

	// Token: 0x06000D3C RID: 3388 RVA: 0x0005C138 File Offset: 0x0005A338
	private void DoInputControlMapping(Rect rect)
	{
		int num = 0;
		GUI.Label(new Rect(20f, 13f, 150f, 20f), LocalizedStrings.Movement, BlueStonez.label_interparkbold_11pt_left);
		GUI.Label(new Rect(220f, 13f, 150f, 20f), LocalizedStrings.KeyButton, BlueStonez.label_interparkbold_11pt_left);
		foreach (UserInputMap userInputMap in AutoMonoBehaviour<InputManager>.Instance.KeyMapping.Values)
		{
			bool flag = userInputMap == this._targetMap;
			GUI.Label(new Rect(20f, (float)(35 + num * 20), 140f, 20f), userInputMap.Description, BlueStonez.label_interparkmed_10pt_left);
			if (userInputMap.IsConfigurable && GUI.Toggle(new Rect(180f, (float)(35 + num * 20), 20f, 20f), flag, string.Empty, BlueStonez.radiobutton))
			{
				this._targetMap = userInputMap;
				Screen.lockCursor = true;
			}
			if (flag)
			{
				GUI.TextField(new Rect(220f, (float)(35 + num * 20), 100f, 20f), string.Empty);
			}
			else
			{
				GUI.contentColor = ((userInputMap.Channel == null) ? Color.red : Color.white);
				GUI.Label(new Rect(220f, (float)(35 + num * 20), 150f, 20f), userInputMap.Assignment, BlueStonez.label_interparkmed_10pt_left);
				GUI.contentColor = Color.white;
			}
			num++;
		}
		if (this._targetMap != null && Event.current.type == EventType.Layout && AutoMonoBehaviour<InputManager>.Instance.ListenForNewKeyAssignment(this._targetMap))
		{
			this._targetMap = null;
			Screen.lockCursor = false;
			Event.current.Use();
		}
	}

	// Token: 0x06000D3D RID: 3389 RVA: 0x00009CD4 File Offset: 0x00007ED4
	private void DrawGroupLabel(Rect position, string label, string text)
	{
		GUI.Label(position, label + ": " + text, BlueStonez.label_interparkbold_16pt_left);
	}

	// Token: 0x06000D3E RID: 3390 RVA: 0x00009CED File Offset: 0x00007EED
	private void DrawContent(Rect position, string label, string text)
	{
		GUI.Label(position, label + ": " + text, BlueStonez.label_interparkbold_11pt_left);
	}

	// Token: 0x06000D3F RID: 3391 RVA: 0x0005C344 File Offset: 0x0005A544
	private void DrawGroupLabelWithWidth(Rect position, string label, string text)
	{
		string text2 = label + ": " + text;
		int num = Mathf.RoundToInt(BlueStonez.label_interparkbold_16pt.CalcSize(new GUIContent(text2)).x);
		GUI.Label(new Rect(position.x, position.y, (float)num, position.height), text2, BlueStonez.label_interparkbold_16pt_left);
		this._desiredWidth = ((num <= this._desiredWidth) ? this._desiredWidth : num);
	}

	// Token: 0x06000D40 RID: 3392 RVA: 0x0005C3C4 File Offset: 0x0005A5C4
	private void DrawGroupControl(Rect rect, string title, GUIStyle style)
	{
		GUI.BeginGroup(rect, string.Empty, BlueStonez.group_grey81);
		GUI.EndGroup();
		GUI.Label(new Rect(rect.x + 18f, rect.y - 8f, this.GetWidth(title, style), 16f), title, style);
	}

	// Token: 0x06000D41 RID: 3393 RVA: 0x00009D06 File Offset: 0x00007F06
	private float GetWidth(string content)
	{
		return this.GetWidth(content, BlueStonez.label_group_interparkbold_18pt);
	}

	// Token: 0x06000D42 RID: 3394 RVA: 0x0005C41C File Offset: 0x0005A61C
	private float GetWidth(string content, GUIStyle style)
	{
		return style.CalcSize(new GUIContent(content)).x + 10f;
	}

	// Token: 0x06000D43 RID: 3395 RVA: 0x00009D14 File Offset: 0x00007F14
	private void ShowScreenResChangeConfirmation(int oldRes, int newRes)
	{
		this._screenResChangeDelay = 15f;
		this._newScreenResIndex = newRes;
		this._isFullscreenBefore = ScreenResolutionManager.IsFullScreen;
		ScreenResolutionManager.IsFullScreen = false;
	}

	// Token: 0x06000D44 RID: 3396 RVA: 0x0005C444 File Offset: 0x0005A644
	private void SetCurrentQuality(int qualityLevel)
	{
		this._currentQuality = qualityLevel;
		if (this._currentQuality < QualitySettings.names.Length)
		{
			ApplicationDataManager.ApplicationOptions.IsUsingCustom = false;
			GraphicSettings.SetQualityLevel(this._currentQuality);
			this.SyncGraphicsSettings();
		}
		else
		{
			ApplicationDataManager.ApplicationOptions.IsUsingCustom = true;
		}
	}

	// Token: 0x06000D45 RID: 3397 RVA: 0x00009D39 File Offset: 0x00007F39
	private void UpdateTextureQuality()
	{
		this._textureQuality = (float)Mathf.RoundToInt(this._textureQuality);
		QualitySettings.masterTextureLimit = 5 - (int)this._textureQuality;
		ApplicationDataManager.ApplicationOptions.VideoTextureQuality = QualitySettings.masterTextureLimit;
	}

	// Token: 0x06000D46 RID: 3398 RVA: 0x00009D6A File Offset: 0x00007F6A
	private void UpdateVSyncCount()
	{
		ApplicationDataManager.ApplicationOptions.VideoVSyncCount = this._vsync;
		QualitySettings.vSyncCount = this._vsync;
	}

	// Token: 0x06000D47 RID: 3399 RVA: 0x0005C498 File Offset: 0x0005A698
	private void UpdateAntiAliasing()
	{
		switch (this._antiAliasing)
		{
		case 1:
			QualitySettings.antiAliasing = 2;
			break;
		case 2:
			QualitySettings.antiAliasing = 4;
			break;
		case 3:
			QualitySettings.antiAliasing = 8;
			break;
		default:
			QualitySettings.antiAliasing = 0;
			break;
		}
		ApplicationDataManager.ApplicationOptions.VideoAntiAliasing = QualitySettings.antiAliasing;
	}

	// Token: 0x06000D48 RID: 3400 RVA: 0x00009D87 File Offset: 0x00007F87
	private void UpdatePostProcessing()
	{
		ApplicationDataManager.ApplicationOptions.VideoPostProcessing = this._postProcessing;
		RenderSettingsController.Instance.EnableImageEffects();
	}

	// Token: 0x06000D49 RID: 3401 RVA: 0x00009DA3 File Offset: 0x00007FA3
	public override void Show()
	{
		base.Show();
		if (ApplicationDataManager.ApplicationOptions.IsUsingCustom)
		{
			this._currentQuality = this.qualitySet.Length - 1;
		}
		else
		{
			this._currentQuality = ApplicationDataManager.ApplicationOptions.VideoQualityLevel;
		}
	}

	// Token: 0x04000C78 RID: 3192
	private const int MasterTextureLimit = 5;

	// Token: 0x04000C79 RID: 3193
	private const int TAB_CONTROL = 0;

	// Token: 0x04000C7A RID: 3194
	private const int TAB_AUDIO = 1;

	// Token: 0x04000C7B RID: 3195
	private const int TAB_VIDEO = 2;

	// Token: 0x04000C7C RID: 3196
	private const int TAB_SYSINFO = 3;

	// Token: 0x04000C7D RID: 3197
	private const int GroupMarginX = 8;

	// Token: 0x04000C7E RID: 3198
	private bool showResolutions;

	// Token: 0x04000C7F RID: 3199
	private bool graphicsChanged;

	// Token: 0x04000C80 RID: 3200
	private string[] qualitySet;

	// Token: 0x04000C81 RID: 3201
	private string[] vsyncSet = new string[]
	{
		"Off",
		"Low",
		"High"
	};

	// Token: 0x04000C82 RID: 3202
	private string[] antiAliasingSet = new string[]
	{
		"Off",
		"2x",
		"4x",
		"8x"
	};

	// Token: 0x04000C83 RID: 3203
	private int _currentQuality;

	// Token: 0x04000C84 RID: 3204
	private float _textureQuality;

	// Token: 0x04000C85 RID: 3205
	private int _vsync;

	// Token: 0x04000C86 RID: 3206
	private int _antiAliasing;

	// Token: 0x04000C87 RID: 3207
	private bool _postProcessing;

	// Token: 0x04000C88 RID: 3208
	private Rect _rect;

	// Token: 0x04000C89 RID: 3209
	private Vector2 _scrollVideo;

	// Token: 0x04000C8A RID: 3210
	private Vector2 _scrollControls;

	// Token: 0x04000C8B RID: 3211
	private int _desiredWidth;

	// Token: 0x04000C8C RID: 3212
	private int _selectedOptionsTab = 2;

	// Token: 0x04000C8D RID: 3213
	private GUIContent[] _optionsTabs;

	// Token: 0x04000C8E RID: 3214
	private UserInputMap _targetMap;

	// Token: 0x04000C8F RID: 3215
	private bool _showWaterModeMenu;

	// Token: 0x04000C90 RID: 3216
	private int _keyCount;

	// Token: 0x04000C91 RID: 3217
	private string[] _screenResText;

	// Token: 0x04000C92 RID: 3218
	private bool INSTANT_SCREEN_RES_CHANGE = true;

	// Token: 0x04000C93 RID: 3219
	private bool _isFullscreenBefore;

	// Token: 0x04000C94 RID: 3220
	private float _screenResChangeDelay;

	// Token: 0x04000C95 RID: 3221
	private int _newScreenResIndex;

	// Token: 0x020001D8 RID: 472
	private class ScreenRes
	{
		// Token: 0x06000D4A RID: 3402 RVA: 0x00009DDF File Offset: 0x00007FDF
		public ScreenRes(int index, string res)
		{
			this.Index = index;
			this.Resolution = res;
		}

		// Token: 0x04000C96 RID: 3222
		public int Index;

		// Token: 0x04000C97 RID: 3223
		public string Resolution;
	}
}
