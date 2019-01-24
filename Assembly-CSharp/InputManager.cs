using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class InputManager : AutoMonoBehaviour<InputManager>
{
	// Token: 0x170004BF RID: 1215
	// (get) Token: 0x060013C0 RID: 5056 RVA: 0x0000D748 File Offset: 0x0000B948
	// (set) Token: 0x060013C1 RID: 5057 RVA: 0x0000D74F File Offset: 0x0000B94F
	public static int SkipFrame { get; set; }

	// Token: 0x060013C2 RID: 5058 RVA: 0x0000D757 File Offset: 0x0000B957
	private void Awake()
	{
		this.SetDefaultKeyMapping();
	}

	// Token: 0x060013C3 RID: 5059 RVA: 0x00071810 File Offset: 0x0006FA10
	private void Update()
	{
		if (InputManager.SkipFrame == Time.frameCount)
		{
			return;
		}
		if (GameData.Instance.HUDChatIsTyping)
		{
			return;
		}
		foreach (UserInputMap userInputMap in this._keyMapping.Values)
		{
			if (userInputMap != null && userInputMap.Channel != null)
			{
				userInputMap.Channel.Listen();
				if (userInputMap.IsEventSender && userInputMap.Channel.IsChanged)
				{
					global::EventHandler.Global.Fire(new GlobalEvents.InputChanged(userInputMap.Slot, userInputMap.Channel.Value));
				}
			}
		}
		if (this.RawValue(GameInputKey.Fullscreen) != 0f && GUITools.SaveClickIn(0.2f))
		{
			GUITools.Clicked();
			ScreenResolutionManager.IsFullScreen = !Screen.fullScreen;
		}
	}

	// Token: 0x060013C4 RID: 5060 RVA: 0x00071914 File Offset: 0x0006FB14
	private void OnGUI()
	{
		if (Event.current.shift && Event.current.type == EventType.ScrollWheel)
		{
			if (Event.current.delta.x > 0f)
			{
				global::EventHandler.Global.Fire(new GlobalEvents.InputChanged(GameInputKey.PrevWeapon, Event.current.delta.x));
			}
			if (Event.current.delta.x < 0f)
			{
				global::EventHandler.Global.Fire(new GlobalEvents.InputChanged(GameInputKey.NextWeapon, Event.current.delta.x));
			}
		}
	}

	// Token: 0x060013C5 RID: 5061 RVA: 0x0000D75F File Offset: 0x0000B95F
	public static bool GetMouseButtonDown(int button)
	{
		return (Event.current == null || Event.current.type == EventType.Layout) && Input.GetMouseButtonDown(button);
	}

	// Token: 0x060013C6 RID: 5062 RVA: 0x000719C0 File Offset: 0x0006FBC0
	public bool ListenForNewKeyAssignment(UserInputMap map)
	{
		if (Event.current.keyCode == KeyCode.Escape)
		{
			this.IsSettingKeymap = false;
			return true;
		}
		if (Event.current.keyCode != KeyCode.None)
		{
			map.Channel = new KeyInputChannel(Event.current.keyCode);
		}
		else if (Event.current.shift)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				map.Channel = new KeyInputChannel(KeyCode.LeftShift);
			}
			if (Input.GetKey(KeyCode.RightShift))
			{
				map.Channel = new KeyInputChannel(KeyCode.RightShift);
			}
		}
		else if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || Input.GetMouseButtonDown(3) || Input.GetMouseButtonDown(4))
		{
			map.Channel = new MouseInputChannel(Event.current.button);
		}
		else if (Mathf.Abs(Input.GetAxisRaw("Mouse ScrollWheel")) > 0.1f)
		{
			map.Channel = new AxisInputChannel("Mouse ScrollWheel", 0.1f, (Input.GetAxisRaw("Mouse ScrollWheel") <= 0f) ? AxisInputChannel.AxisReadingMethod.NegativeOnly : AxisInputChannel.AxisReadingMethod.PositiveOnly);
		}
		else if (Mathf.Abs(Input.GetAxisRaw("LS X")) > 0.1f)
		{
			map.Channel = new AxisInputChannel("LS X", 0.1f, (Input.GetAxisRaw("LS X") <= 0f) ? AxisInputChannel.AxisReadingMethod.NegativeOnly : AxisInputChannel.AxisReadingMethod.PositiveOnly);
		}
		else if (Mathf.Abs(Input.GetAxisRaw("LS Y")) > 0.1f)
		{
			map.Channel = new AxisInputChannel("LS Y", 0.1f, (Input.GetAxisRaw("LS Y") <= 0f) ? AxisInputChannel.AxisReadingMethod.NegativeOnly : AxisInputChannel.AxisReadingMethod.PositiveOnly);
		}
		else if (Mathf.Abs(Input.GetAxisRaw("RS X")) > 0.1f)
		{
			map.Channel = new AxisInputChannel("RS X", 0.1f, (Input.GetAxisRaw("RS X") <= 0f) ? AxisInputChannel.AxisReadingMethod.NegativeOnly : AxisInputChannel.AxisReadingMethod.PositiveOnly);
		}
		else if (Mathf.Abs(Input.GetAxisRaw("RS Y")) > 0.1f)
		{
			map.Channel = new AxisInputChannel("RS Y", 0.1f, (Input.GetAxisRaw("RS Y") <= 0f) ? AxisInputChannel.AxisReadingMethod.NegativeOnly : AxisInputChannel.AxisReadingMethod.PositiveOnly);
		}
		else if (Mathf.Abs(Input.GetAxisRaw("DPad X")) > 0.1f)
		{
			map.Channel = new AxisInputChannel("DPad X", 0.1f, (Input.GetAxisRaw("DPad X") <= 0f) ? AxisInputChannel.AxisReadingMethod.NegativeOnly : AxisInputChannel.AxisReadingMethod.PositiveOnly);
		}
		else if (Mathf.Abs(Input.GetAxisRaw("DPad Y")) > 0.1f)
		{
			map.Channel = new AxisInputChannel("DPad Y", 0.1f, (Input.GetAxisRaw("DPad Y") <= 0f) ? AxisInputChannel.AxisReadingMethod.NegativeOnly : AxisInputChannel.AxisReadingMethod.PositiveOnly);
		}
		else if (Input.GetAxisRaw("LT") > 0.1f)
		{
			map.Channel = new AxisInputChannel("LT", 0.1f);
		}
		else if (Input.GetAxisRaw("RT") > 0.1f)
		{
			map.Channel = new AxisInputChannel("RT", 0.1f);
		}
		else if (Input.GetButton("A"))
		{
			map.Channel = new ButtonInputChannel("A");
		}
		else if (Input.GetButton("B"))
		{
			map.Channel = new ButtonInputChannel("B");
		}
		else if (Input.GetButton("X"))
		{
			map.Channel = new ButtonInputChannel("X");
		}
		else if (Input.GetButton("Y"))
		{
			map.Channel = new ButtonInputChannel("Y");
		}
		else if (Input.GetButton("LB"))
		{
			map.Channel = new ButtonInputChannel("LB");
		}
		else if (Input.GetButton("RB"))
		{
			map.Channel = new ButtonInputChannel("RB");
		}
		else if (Input.GetButton("Start"))
		{
			map.Channel = new ButtonInputChannel("Start");
		}
		else
		{
			if (!Input.GetButton("Back"))
			{
				this.IsSettingKeymap = true;
				return false;
			}
			map.Channel = new ButtonInputChannel("Back");
		}
		global::EventHandler.Global.Fire(new GlobalEvents.InputAssignment());
		Event.current.Use();
		this.ResolveMultipleAssignment(map);
		this.WriteAllKeyMappings();
		this.IsSettingKeymap = false;
		return true;
	}

	// Token: 0x060013C7 RID: 5063 RVA: 0x0000D784 File Offset: 0x0000B984
	public void Reset()
	{
		this._keyMapping.Clear();
		this.SetDefaultKeyMapping();
		this.IsGamepadEnabled = false;
		this.WriteAllKeyMappings();
	}

	// Token: 0x060013C8 RID: 5064 RVA: 0x00071E88 File Offset: 0x00070088
	public float RawValue(GameInputKey slot)
	{
		UserInputMap userInputMap;
		if (!this.IsSettingKeymap && this._keyMapping.TryGetValue((int)slot, out userInputMap))
		{
			return userInputMap.RawValue();
		}
		return 0f;
	}

	// Token: 0x060013C9 RID: 5065 RVA: 0x00071EC0 File Offset: 0x000700C0
	public float GetValue(GameInputKey slot)
	{
		UserInputMap userInputMap;
		if (!this.IsSettingKeymap && this.IsInputEnabled && this._keyMapping.TryGetValue((int)slot, out userInputMap))
		{
			return userInputMap.Value;
		}
		return 0f;
	}

	// Token: 0x060013CA RID: 5066 RVA: 0x00071F04 File Offset: 0x00070104
	public bool IsDown(GameInputKey slot)
	{
		UserInputMap userInputMap;
		return !this.IsSettingKeymap && this._keyMapping.TryGetValue((int)slot, out userInputMap) && userInputMap.Value != 0f;
	}

	// Token: 0x060013CB RID: 5067 RVA: 0x00071F44 File Offset: 0x00070144
	public string GetKeyAssignmentString(GameInputKey slot)
	{
		UserInputMap userInputMap;
		if (this._keyMapping.TryGetValue((int)slot, out userInputMap) && userInputMap != null)
		{
			return userInputMap.Assignment;
		}
		return "Not set";
	}

	// Token: 0x060013CC RID: 5068 RVA: 0x00071F78 File Offset: 0x00070178
	public string GetSlotName(GameInputKey slot)
	{
		switch (slot)
		{
		case GameInputKey.None:
			return "None";
		case GameInputKey.HorizontalLook:
			return "HorizontalLook";
		case GameInputKey.VerticalLook:
			return "VerticalLook";
		case GameInputKey.Forward:
			return "Forward";
		case GameInputKey.Backward:
			return "Backward";
		case GameInputKey.Left:
			return "Left";
		case GameInputKey.Right:
			return "Right";
		case GameInputKey.Jump:
			return "Jump";
		case GameInputKey.Crouch:
			return "Crouch";
		case GameInputKey.PrimaryFire:
			return "Primary Fire";
		case GameInputKey.SecondaryFire:
			return "Secondary Fire";
		case GameInputKey.Weapon1:
			return "Primary Weapon";
		case GameInputKey.Weapon2:
			return "Secondary Weapon";
		case GameInputKey.Weapon3:
			return "Tertiary Weapon";
		case GameInputKey.WeaponMelee:
			return "Melee Weapon";
		case GameInputKey.QuickItem1:
			return "Quick Item 1";
		case GameInputKey.QuickItem2:
			return "Quick Item 2";
		case GameInputKey.QuickItem3:
			return "Quick Item 3";
		case GameInputKey.NextWeapon:
			return "Next Weapon / Zoom In";
		case GameInputKey.PrevWeapon:
			return "Prev Weapon / Zoom Out";
		case GameInputKey.Pause:
			return "Pause";
		case GameInputKey.Fullscreen:
			return "Fullscreen";
		case GameInputKey.Tabscreen:
			return "Tabscreen";
		case GameInputKey.Chat:
			return "Chat";
		case GameInputKey.Loadout:
			return "Loadout";
		case GameInputKey.UseQuickItem:
			return "Use QuickItem";
		case GameInputKey.ChangeTeam:
			return "Change Team";
		case GameInputKey.NextQuickItem:
			return "Cycle QuickItems";
		case GameInputKey.SendScreenshotToFacebook:
			return "Send Screenshot to Facebook";
		}
		return "No Name";
	}

	// Token: 0x060013CD RID: 5069 RVA: 0x000720C4 File Offset: 0x000702C4
	private void ResolveMultipleAssignment(UserInputMap map)
	{
		foreach (UserInputMap userInputMap in this._keyMapping.Values)
		{
			if (userInputMap != map && userInputMap.Channel != null && userInputMap.Channel.ChannelType == map.Channel.ChannelType && map.Assignment == userInputMap.Assignment)
			{
				userInputMap.Channel = null;
				break;
			}
		}
	}

	// Token: 0x060013CE RID: 5070 RVA: 0x0007216C File Offset: 0x0007036C
	private bool IsChannelTaken(IInputChannel channel)
	{
		bool result = false;
		foreach (UserInputMap userInputMap in this._keyMapping.Values)
		{
			if (userInputMap.Channel.Equals(channel))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x060013CF RID: 5071 RVA: 0x000721E0 File Offset: 0x000703E0
	private void SetDefaultKeyMapping()
	{
		this._keyMapping[1] = new UserInputMap(this.GetSlotName(GameInputKey.HorizontalLook), GameInputKey.HorizontalLook, new AxisInputChannel("Mouse X", 0f), false, false, KeyCode.None);
		this._keyMapping[2] = new UserInputMap(this.GetSlotName(GameInputKey.VerticalLook), GameInputKey.VerticalLook, new AxisInputChannel("Mouse Y", 1f), false, false, KeyCode.None);
		this._keyMapping[21] = new UserInputMap(this.GetSlotName(GameInputKey.Pause), GameInputKey.Pause, new KeyInputChannel(KeyCode.Backspace), true, true, KeyCode.None);
		this._keyMapping[23] = new UserInputMap(this.GetSlotName(GameInputKey.Tabscreen), GameInputKey.Tabscreen, new KeyInputChannel(KeyCode.Tab), true, true, KeyCode.None);
		this._keyMapping[22] = new UserInputMap(this.GetSlotName(GameInputKey.Fullscreen), GameInputKey.Fullscreen, new KeyInputChannel(KeyCode.F), true, true, KeyCode.LeftAlt);
		this._keyMapping[30] = new UserInputMap(this.GetSlotName(GameInputKey.SendScreenshotToFacebook), GameInputKey.SendScreenshotToFacebook, new KeyInputChannel(KeyCode.B), true, true, KeyCode.None);
		this._keyMapping[3] = new UserInputMap(this.GetSlotName(GameInputKey.Forward), GameInputKey.Forward, new KeyInputChannel(KeyCode.W), true, true, KeyCode.None);
		this._keyMapping[5] = new UserInputMap(this.GetSlotName(GameInputKey.Left), GameInputKey.Left, new KeyInputChannel(KeyCode.A), true, true, KeyCode.None);
		this._keyMapping[4] = new UserInputMap(this.GetSlotName(GameInputKey.Backward), GameInputKey.Backward, new KeyInputChannel(KeyCode.S), true, true, KeyCode.None);
		this._keyMapping[6] = new UserInputMap(this.GetSlotName(GameInputKey.Right), GameInputKey.Right, new KeyInputChannel(KeyCode.D), true, true, KeyCode.None);
		this._keyMapping[7] = new UserInputMap(this.GetSlotName(GameInputKey.Jump), GameInputKey.Jump, new KeyInputChannel(KeyCode.Space), true, true, KeyCode.None);
		this._keyMapping[8] = new UserInputMap(this.GetSlotName(GameInputKey.Crouch), GameInputKey.Crouch, new KeyInputChannel(KeyCode.LeftShift), true, true, KeyCode.None);
		this._keyMapping[9] = new UserInputMap(this.GetSlotName(GameInputKey.PrimaryFire), GameInputKey.PrimaryFire, new MouseInputChannel(0), true, true, KeyCode.None);
		this._keyMapping[10] = new UserInputMap(this.GetSlotName(GameInputKey.SecondaryFire), GameInputKey.SecondaryFire, new MouseInputChannel(1), true, true, KeyCode.None);
		this._keyMapping[19] = new UserInputMap(this.GetSlotName(GameInputKey.NextWeapon), GameInputKey.NextWeapon, new AxisInputChannel("Mouse ScrollWheel", 0.01f, AxisInputChannel.AxisReadingMethod.PositiveOnly), true, true, KeyCode.None);
		this._keyMapping[20] = new UserInputMap(this.GetSlotName(GameInputKey.PrevWeapon), GameInputKey.PrevWeapon, new AxisInputChannel("Mouse ScrollWheel", 0.01f, AxisInputChannel.AxisReadingMethod.NegativeOnly), true, true, KeyCode.None);
		this._keyMapping[15] = new UserInputMap(this.GetSlotName(GameInputKey.WeaponMelee), GameInputKey.WeaponMelee, new KeyInputChannel(KeyCode.Alpha1), true, true, KeyCode.None);
		this._keyMapping[11] = new UserInputMap(this.GetSlotName(GameInputKey.Weapon1), GameInputKey.Weapon1, new KeyInputChannel(KeyCode.Alpha2), true, true, KeyCode.None);
		this._keyMapping[12] = new UserInputMap(this.GetSlotName(GameInputKey.Weapon2), GameInputKey.Weapon2, new KeyInputChannel(KeyCode.Alpha3), true, true, KeyCode.None);
		this._keyMapping[13] = new UserInputMap(this.GetSlotName(GameInputKey.Weapon3), GameInputKey.Weapon3, new KeyInputChannel(KeyCode.Alpha4), true, true, KeyCode.None);
		this._keyMapping[16] = new UserInputMap(this.GetSlotName(GameInputKey.QuickItem1), GameInputKey.QuickItem1, new KeyInputChannel(KeyCode.Alpha6), true, true, KeyCode.None);
		this._keyMapping[17] = new UserInputMap(this.GetSlotName(GameInputKey.QuickItem2), GameInputKey.QuickItem2, new KeyInputChannel(KeyCode.Alpha7), true, true, KeyCode.None);
		this._keyMapping[18] = new UserInputMap(this.GetSlotName(GameInputKey.QuickItem3), GameInputKey.QuickItem3, new KeyInputChannel(KeyCode.Alpha8), true, true, KeyCode.None);
		this._keyMapping[27] = new UserInputMap(this.GetSlotName(GameInputKey.ChangeTeam), GameInputKey.ChangeTeam, new KeyInputChannel(KeyCode.M), true, true, KeyCode.LeftAlt);
		this._keyMapping[26] = new UserInputMap(this.GetSlotName(GameInputKey.UseQuickItem), GameInputKey.UseQuickItem, new KeyInputChannel(KeyCode.E), true, true, KeyCode.None);
		this._keyMapping[28] = new UserInputMap(this.GetSlotName(GameInputKey.NextQuickItem), GameInputKey.NextQuickItem, new KeyInputChannel(KeyCode.R), true, true, KeyCode.None);
	}

	// Token: 0x060013D0 RID: 5072 RVA: 0x000725DC File Offset: 0x000707DC
	private static CmunePrefs.Key GetPrefsKeyForSlot(int slot)
	{
		switch (slot)
		{
		case 0:
			return CmunePrefs.Key.Keymap_None;
		case 1:
			return CmunePrefs.Key.Keymap_HorizontalLook;
		case 2:
			return CmunePrefs.Key.Keymap_VerticalLook;
		case 3:
			return CmunePrefs.Key.Keymap_Forward;
		case 4:
			return CmunePrefs.Key.Keymap_Backward;
		case 5:
			return CmunePrefs.Key.Keymap_Left;
		case 6:
			return CmunePrefs.Key.Keymap_Right;
		case 7:
			return CmunePrefs.Key.Keymap_Jump;
		case 8:
			return CmunePrefs.Key.Keymap_Crouch;
		case 9:
			return CmunePrefs.Key.Keymap_PrimaryFire;
		case 10:
			return CmunePrefs.Key.Keymap_SecondaryFire;
		case 11:
			return CmunePrefs.Key.Keymap_Weapon1;
		case 12:
			return CmunePrefs.Key.Keymap_Weapon2;
		case 13:
			return CmunePrefs.Key.Keymap_Weapon3;
		case 15:
			return CmunePrefs.Key.Keymap_WeaponMelee;
		case 16:
			return CmunePrefs.Key.Keymap_QuickItem1;
		case 17:
			return CmunePrefs.Key.Keymap_QuickItem2;
		case 18:
			return CmunePrefs.Key.Keymap_QuickItem3;
		case 19:
			return CmunePrefs.Key.Keymap_NextWeapon;
		case 20:
			return CmunePrefs.Key.Keymap_PrevWeapon;
		case 21:
			return CmunePrefs.Key.Keymap_Pause;
		case 22:
			return CmunePrefs.Key.Keymap_Fullscreen;
		case 23:
			return CmunePrefs.Key.Keymap_Tabscreen;
		case 24:
			return CmunePrefs.Key.Keymap_Chat;
		case 25:
			return CmunePrefs.Key.Keymap_Inventory;
		case 26:
			return CmunePrefs.Key.Keymap_UseQuickItem;
		case 27:
			return CmunePrefs.Key.Keymap_ChangeTeam;
		case 28:
			return CmunePrefs.Key.Keymap_NextQuickItem;
		case 30:
			return CmunePrefs.Key.Keymap_SendScreenshotToFacebook;
		}
		return CmunePrefs.Key.Keymap_None;
	}

	// Token: 0x060013D1 RID: 5073 RVA: 0x00072728 File Offset: 0x00070928
	private void WriteAllKeyMappings()
	{
		this._unassignedKeyMappings = false;
		foreach (KeyValuePair<int, UserInputMap> keyValuePair in this._keyMapping)
		{
			if (keyValuePair.Value.IsConfigurable)
			{
				CmunePrefs.WriteKey<string>(InputManager.GetPrefsKeyForSlot(keyValuePair.Key), keyValuePair.Value.GetPlayerPrefs());
				if (keyValuePair.Value.Channel == null)
				{
					this._unassignedKeyMappings = true;
				}
			}
		}
	}

	// Token: 0x060013D2 RID: 5074 RVA: 0x000727D0 File Offset: 0x000709D0
	public void ReadAllKeyMappings()
	{
		this._unassignedKeyMappings = false;
		foreach (KeyValuePair<int, UserInputMap> keyValuePair in this._keyMapping)
		{
			if (keyValuePair.Value.IsConfigurable)
			{
				string pref;
				if (CmunePrefs.TryGetKey<string>(InputManager.GetPrefsKeyForSlot(keyValuePair.Key), out pref))
				{
					keyValuePair.Value.ReadPlayerPrefs(pref);
					if (keyValuePair.Value.Channel == null)
					{
						this._unassignedKeyMappings = true;
					}
				}
			}
		}
	}

	// Token: 0x060013D3 RID: 5075 RVA: 0x00072880 File Offset: 0x00070A80
	public void SetKeyboardKeyMappingAndroid()
	{
		this._keyMapping[1] = new UserInputMap(this.GetSlotName(GameInputKey.HorizontalLook), GameInputKey.HorizontalLook, new AxisInputChannel("GameStopLook X", 0f), false, false, KeyCode.None);
		this._keyMapping[2] = new UserInputMap(this.GetSlotName(GameInputKey.VerticalLook), GameInputKey.VerticalLook, new AxisInputChannel("GameStopLook Y", 1f), false, false, KeyCode.None);
		this._keyMapping[21] = new UserInputMap(this.GetSlotName(GameInputKey.Pause), GameInputKey.Pause, new KeyInputChannel(KeyCode.Escape), true, true, KeyCode.None);
		this._keyMapping[3] = new UserInputMap(this.GetSlotName(GameInputKey.Forward), GameInputKey.Forward, new KeyInputChannel(KeyCode.UpArrow), true, true, KeyCode.None);
		this._keyMapping[5] = new UserInputMap(this.GetSlotName(GameInputKey.Left), GameInputKey.Left, new KeyInputChannel(KeyCode.LeftArrow), true, true, KeyCode.None);
		this._keyMapping[4] = new UserInputMap(this.GetSlotName(GameInputKey.Backward), GameInputKey.Backward, new KeyInputChannel(KeyCode.DownArrow), true, true, KeyCode.None);
		this._keyMapping[6] = new UserInputMap(this.GetSlotName(GameInputKey.Right), GameInputKey.Right, new KeyInputChannel(KeyCode.RightArrow), true, true, KeyCode.None);
		this._keyMapping[7] = new UserInputMap(this.GetSlotName(GameInputKey.Jump), GameInputKey.Jump, new KeyInputChannel(KeyCode.Alpha6), true, true, KeyCode.None);
		this._keyMapping[8] = new UserInputMap(this.GetSlotName(GameInputKey.Crouch), GameInputKey.Crouch, new KeyInputChannel(KeyCode.Alpha8), true, true, KeyCode.None);
		this._keyMapping[9] = new UserInputMap(this.GetSlotName(GameInputKey.PrimaryFire), GameInputKey.PrimaryFire, new KeyInputChannel(KeyCode.Alpha1), true, true, KeyCode.None);
		this._keyMapping[10] = new UserInputMap(this.GetSlotName(GameInputKey.SecondaryFire), GameInputKey.SecondaryFire, new KeyInputChannel(KeyCode.Alpha2), true, true, KeyCode.None);
		this._keyMapping[19] = new UserInputMap(this.GetSlotName(GameInputKey.NextWeapon), GameInputKey.NextWeapon, new KeyInputChannel(KeyCode.Alpha7), true, true, KeyCode.None);
		this._keyMapping[20] = new UserInputMap(this.GetSlotName(GameInputKey.PrevWeapon), GameInputKey.PrevWeapon, new KeyInputChannel(KeyCode.Alpha5), true, true, KeyCode.None);
		this._keyMapping[26] = new UserInputMap(this.GetSlotName(GameInputKey.UseQuickItem), GameInputKey.UseQuickItem, new KeyInputChannel(KeyCode.Alpha3), true, true, KeyCode.None);
		this._keyMapping[28] = new UserInputMap(this.GetSlotName(GameInputKey.NextQuickItem), GameInputKey.NextQuickItem, new KeyInputChannel(KeyCode.Alpha4), true, true, KeyCode.None);
	}

	// Token: 0x170004C0 RID: 1216
	// (get) Token: 0x060013D4 RID: 5076 RVA: 0x0000D7A4 File Offset: 0x0000B9A4
	// (set) Token: 0x060013D5 RID: 5077 RVA: 0x00072ACC File Offset: 0x00070CCC
	public bool IsGamepadEnabled
	{
		get
		{
			return this._isGamepadEnabled;
		}
		set
		{
			this._isGamepadEnabled = value;
			if (this._isGamepadEnabled)
			{
				this.KeyMapping[1].Channel = new AxisInputChannel("RS X", 0f);
				this.KeyMapping[2].Channel = new AxisInputChannel("RS Y", 0f);
			}
			else
			{
				this.KeyMapping[1].Channel = new AxisInputChannel("Mouse X", 0f);
				this.KeyMapping[2].Channel = new AxisInputChannel("Mouse Y", 0f);
			}
		}
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x060013D6 RID: 5078 RVA: 0x0000D7AC File Offset: 0x0000B9AC
	public Dictionary<int, UserInputMap> KeyMapping
	{
		get
		{
			return this._keyMapping;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x060013D7 RID: 5079 RVA: 0x00072B70 File Offset: 0x00070D70
	public bool IsAnyDown
	{
		get
		{
			if (this.IsInputEnabled)
			{
				foreach (UserInputMap userInputMap in this._keyMapping.Values)
				{
					if (userInputMap.Value != 0f)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x060013D8 RID: 5080 RVA: 0x0000D7B4 File Offset: 0x0000B9B4
	// (set) Token: 0x060013D9 RID: 5081 RVA: 0x00072BF0 File Offset: 0x00070DF0
	public bool IsInputEnabled
	{
		get
		{
			return this._inputEnabled;
		}
		set
		{
			this._inputEnabled = value;
			if (!this._inputEnabled)
			{
				foreach (UserInputMap userInputMap in this._keyMapping.Values)
				{
					if (userInputMap != null && userInputMap.Channel != null)
					{
						userInputMap.Channel.Reset();
						if (userInputMap.IsEventSender && userInputMap.Channel.IsChanged)
						{
							global::EventHandler.Global.Fire(new GlobalEvents.InputChanged(userInputMap.Slot, userInputMap.Channel.Value));
						}
					}
				}
			}
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x060013DA RID: 5082 RVA: 0x0000D7BC File Offset: 0x0000B9BC
	// (set) Token: 0x060013DB RID: 5083 RVA: 0x0000D7C4 File Offset: 0x0000B9C4
	public bool IsSettingKeymap { get; private set; }

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x060013DC RID: 5084 RVA: 0x0000D7CD File Offset: 0x0000B9CD
	public bool HasUnassignedKeyMappings
	{
		get
		{
			return this._unassignedKeyMappings;
		}
	}

	// Token: 0x060013DD RID: 5085 RVA: 0x00072CB4 File Offset: 0x00070EB4
	public string InputChannelForSlot(GameInputKey keySlot)
	{
		UserInputMap userInputMap;
		if (this.KeyMapping.TryGetValue((int)keySlot, out userInputMap))
		{
			return userInputMap.Assignment;
		}
		return "None";
	}

	// Token: 0x04001357 RID: 4951
	private const float _mouseScrollThreshold = 0.01f;

	// Token: 0x04001358 RID: 4952
	private bool _inputEnabled;

	// Token: 0x04001359 RID: 4953
	private bool _unassignedKeyMappings;

	// Token: 0x0400135A RID: 4954
	private bool _isGamepadEnabled;

	// Token: 0x0400135B RID: 4955
	private Dictionary<int, UserInputMap> _keyMapping = new Dictionary<int, UserInputMap>();
}
