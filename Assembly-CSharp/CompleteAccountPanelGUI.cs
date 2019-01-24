using System;
using System.Collections;
using System.Collections.Generic;
using UberStrike.DataCenter.Common.Entities;
using UberStrike.Realtime.UnitySdk;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020001C9 RID: 457
public class CompleteAccountPanelGUI : PanelGuiBase
{
	// Token: 0x06000C9F RID: 3231 RVA: 0x000552D4 File Offset: 0x000534D4
	private void Awake()
	{
		this._availableNames = new List<string>();
		this._errorMessages = new Dictionary<int, string>();
		this._errorMessages.Add(3, string.Empty);
		this._errorMessages.Add(2, string.Empty);
		this._errorMessages.Add(0, string.Empty);
		this._errorMessages.Add(4, string.Empty);
		this._errorMessages.Add(5, LocalizedStrings.YourAccountHasBeenBanned);
		this._targetKeyboardOffset = 0f;
	}

	// Token: 0x06000CA0 RID: 3232 RVA: 0x00003C87 File Offset: 0x00001E87
	private void Update()
	{
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x00003C87 File Offset: 0x00001E87
	private void HideKeyboard()
	{
	}

	// Token: 0x06000CA2 RID: 3234 RVA: 0x00055358 File Offset: 0x00053558
	private void OnGUI()
	{
		float num = 400f;
		if (Mathf.Abs(this._keyboardOffset - this._targetKeyboardOffset) > 2f)
		{
			this._keyboardOffset = Mathf.Lerp(this._keyboardOffset, this._targetKeyboardOffset, Time.deltaTime * 4f);
		}
		else
		{
			this._keyboardOffset = this._targetKeyboardOffset;
		}
		if (this._height != this._targetHeight)
		{
			this._height = Mathf.Lerp(this._height, this._targetHeight, Time.deltaTime * 5f);
			if (Mathf.Approximately(this._height, this._targetHeight))
			{
				this._height = this._targetHeight;
			}
		}
		GUI.depth = 1;
		Rect position = new Rect(((float)Screen.width - num) * 0.5f, ((float)Screen.height - this._height) * 0.5f - this._keyboardOffset, num, this._height);
		GUI.BeginGroup(position, GUIContent.none, BlueStonez.window);
		GUI.Label(new Rect(0f, 0f, position.width, 56f), LocalizedStrings.ChooseCharacterName, BlueStonez.tab_strip);
		Rect position2 = new Rect(20f, 55f, position.width - 40f, position.height - 76f);
		GUI.Label(position2, GUIContent.none, BlueStonez.window_standard_grey38);
		GUI.BeginGroup(position2);
		GUI.Label(new Rect(10f, 8f, position2.width - 20f, 40f), "Please choose your character name.\nThis is the name that will be displayed to other players in game.", BlueStonez.label_interparkbold_11pt);
		GUI.color = new Color(1f, 1f, 1f, 0.3f);
		GUI.Label(new Rect(20f, 66f, 15f, 11f), (18 - this._characterName.Length).ToString(), BlueStonez.label_interparkmed_11pt_right);
		GUI.color = Color.white;
		GUI.enabled = !this._waitingForWsReturn;
		GUI.changed = false;
		GUI.SetNextControlName("@Name");
		this._characterName = GUI.TextField(new Rect(40f, 60f, 180f, 22f), this._characterName, 18, BlueStonez.textField);
		this._characterName = TextUtilities.Trim(this._characterName);
		if (GUI.changed)
		{
			this._selectedIndex = -1;
			this._checkButtonClicked = false;
		}
		if (string.IsNullOrEmpty(this._characterName) && GUI.GetNameOfFocusedControl() != "@Name")
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(new Rect(85f, 67f, 180f, 22f), LocalizedStrings.EnterYourName, BlueStonez.label_interparkmed_11pt_left);
			GUI.color = Color.white;
		}
		GUI.enabled = true;
		this.DrawCheckAvailabilityButton(position2);
		if (this._waitingForWsReturn)
		{
			GUI.contentColor = Color.gray;
			GUI.Label(new Rect(165f, 100f, 100f, 20f), LocalizedStrings.PleaseWait, BlueStonez.label_interparkbold_11pt_left);
			GUI.contentColor = Color.white;
			WaitingTexture.Draw(new Vector2(140f, 110f), 0);
		}
		else
		{
			GUI.contentColor = this._feedbackMessageColor;
			GUI.Label(new Rect(0f, 100f, position2.width, 20f), this._errorMessage, BlueStonez.label_interparkbold_11pt);
			GUI.contentColor = Color.white;
		}
		this.DrawAvailableNames(new Rect(0f, 120f, position2.width, position2.height - 162f));
		this.DrawOKButton(position2);
		GUI.EndGroup();
		GUI.EndGroup();
	}

	// Token: 0x06000CA3 RID: 3235 RVA: 0x0005572C File Offset: 0x0005392C
	private void DrawCheckAvailabilityButton(Rect position)
	{
		GUI.enabled = (!string.IsNullOrEmpty(this._characterName) && !this._checkButtonClicked && !this._waitingForWsReturn);
		if (GUITools.Button(new Rect(225f, 60f, 110f, 24f), new GUIContent("Check Availability"), BlueStonez.buttondark_small))
		{
			this.HideKeyboard();
			this._availableNames.Clear();
			this._checkButtonClicked = true;
			this._targetHeight = 260f;
			if (!ValidationUtilities.IsValidMemberName(this._characterName, ApplicationDataManager.CurrentLocale.ToString()))
			{
				this._feedbackMessageColor = Color.red;
				this._errorMessage = "'" + this._characterName + "' is not a valid name!";
			}
			else
			{
				this._waitingForWsReturn = true;
				UserWebServiceClient.IsDuplicateMemberName(this._characterName, new Action<bool>(this.IsDuplicatedNameCallback), delegate(Exception ex)
				{
					this._waitingForWsReturn = false;
					this._feedbackMessageColor = Color.red;
					this._errorMessage = "Our server had an error, please try again.";
				});
			}
		}
		GUI.enabled = true;
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x00055838 File Offset: 0x00053A38
	private void DrawOKButton(Rect position)
	{
		GUI.enabled = (!this._waitingForWsReturn && !string.IsNullOrEmpty(this._characterName));
		if (GUITools.Button(new Rect((position.width - 120f) / 2f, position.height - 42f, 120f, 32f), new GUIContent(LocalizedStrings.OkCaps), BlueStonez.button_green))
		{
			this.HideKeyboard();
			string name = this._characterName;
			if (this._selectedIndex != -1)
			{
				name = this._availableNames[this._selectedIndex];
			}
			this._waitingForWsReturn = true;
			AuthenticationWebServiceClient.CompleteAccount(PlayerDataManager.Cmid, name, ApplicationDataManager.Channel, ApplicationDataManager.CurrentLocale.ToString(), SystemInfo.deviceUniqueIdentifier, delegate(AccountCompletionResultView ev)
			{
				this.CompleteAccountCallback(ev, name);
			}, delegate(Exception ex)
			{
				this._waitingForWsReturn = false;
				this._feedbackMessageColor = Color.red;
				this._errorMessage = "Webservice error";
			});
		}
		GUI.enabled = true;
	}

	// Token: 0x06000CA5 RID: 3237 RVA: 0x00055940 File Offset: 0x00053B40
	private void DrawAvailableNames(Rect position)
	{
		if (this._availableNames.Count == 0)
		{
			return;
		}
		GUI.BeginGroup(position);
		GUI.Label(new Rect(0f, 0f, position.width, 20f), "Here are some suggestions", BlueStonez.label_interparkbold_11pt);
		GUI.enabled = !this._waitingForWsReturn;
		for (int i = 0; i < this._availableNames.Count; i++)
		{
			if (GUI.Toggle(new Rect(94f, (float)(24 + i * 20), position.width, 18f), i == this._selectedIndex, this._availableNames[i], BlueStonez.radiobutton))
			{
				this._selectedIndex = i;
			}
		}
		GUI.enabled = true;
		GUI.EndGroup();
	}

	// Token: 0x06000CA6 RID: 3238 RVA: 0x00055A0C File Offset: 0x00053C0C
	private void IsDuplicatedNameCallback(bool isDuplicate)
	{
		if (isDuplicate)
		{
			UserWebServiceClient.GenerateNonDuplicatedMemberNames(this._characterName, new Action<List<string>>(this.GetNonDuplicatedNamesCallback), delegate(Exception ex)
			{
				this._waitingForWsReturn = false;
			});
		}
		else
		{
			this._waitingForWsReturn = false;
			this._feedbackMessageColor = Color.green;
			this._errorMessage = "'" + this._characterName + "' is available!";
		}
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x00055A78 File Offset: 0x00053C78
	private void GetNonDuplicatedNamesCallback(List<string> names)
	{
		this._selectedIndex = -1;
		this._targetHeight = 330f;
		this._waitingForWsReturn = false;
		this._feedbackMessageColor = Color.red;
		this._errorMessage = "'" + this._characterName + "' is already taken!";
		this._availableNames.Clear();
		this._availableNames.AddRange(names);
	}

	// Token: 0x06000CA8 RID: 3240 RVA: 0x00055ADC File Offset: 0x00053CDC
	private void CompleteAccountCallback(AccountCompletionResultView result, string name)
	{
		this._selectedIndex = -1;
		this._waitingForWsReturn = false;
		switch (result.Result)
		{
		case 1:
		{
			this.Hide();
			List<IUnityItem> list = new List<IUnityItem>();
			foreach (int itemId in result.ItemsAttributed.Keys)
			{
				list.Add(Singleton<ItemManager>.Instance.GetItemInShop(itemId));
			}
			PlayerDataManager.Name = name;
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Operations.SendAuthenticationRequest(PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
			base.StartCoroutine(this.StartPreparingNewPlayersLoadout(list));
			break;
		}
		case 2:
			this.GetNonDuplicatedNamesCallback(result.NonDuplicateNames);
			break;
		case 3:
			this.Hide();
			Singleton<SceneLoader>.Instance.LoadLevel("Menu", null);
			break;
		case 4:
			this._feedbackMessageColor = Color.red;
			this._errorMessage = LocalizedStrings.NameInvalidCharsMsg;
			break;
		case 5:
			this._feedbackMessageColor = Color.red;
			this._errorMessage = LocalizedStrings.YourAccountHasBeenBanned;
			break;
		}
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x00055C20 File Offset: 0x00053E20
	private IEnumerator StartPreparingNewPlayersLoadout(List<IUnityItem> items)
	{
		yield return base.StartCoroutine(Singleton<ItemManager>.Instance.StartGetInventory(false));
		IUnityItem item = items.Find((IUnityItem i) => i.View.ID == 1000);
		if (item != null)
		{
			InventoryItem melee = new InventoryItem(item);
			Singleton<LoadoutManager>.Instance.SetLoadoutItem(LoadoutSlotType.WeaponMelee, melee.Item);
		}
		item = items.Find((IUnityItem i) => i.View.ID == 1002);
		if (item != null)
		{
			InventoryItem machinegun = new InventoryItem(item);
			Singleton<LoadoutManager>.Instance.SetLoadoutItem(LoadoutSlotType.WeaponPrimary, machinegun.Item);
		}
		item = items.Find((IUnityItem i) => i.View.ID == 1003);
		if (item != null)
		{
			InventoryItem shotgun = new InventoryItem(item);
			Singleton<LoadoutManager>.Instance.SetLoadoutItem(LoadoutSlotType.WeaponSecondary, shotgun.Item);
		}
		item = items.Find((IUnityItem i) => i.View.ID == 1004);
		if (item != null)
		{
			InventoryItem sniper = new InventoryItem(item);
			Singleton<LoadoutManager>.Instance.SetLoadoutItem(LoadoutSlotType.WeaponTertiary, sniper.Item);
		}
		if (items.Count > 0)
		{
			ItemListPopupDialog dialog = new ItemListPopupDialog("New Items", "You're now ready to start kicking ass!\nUse the PLAY button to join or create a game.", items, delegate()
			{
				Singleton<AuthenticationManager>.Instance.SetAuthComplete(true);
				MenuPageManager.Instance.LoadPage(PageType.Home, true);
			});
			PopupSystem.Show(dialog);
			Debug.Log("You've got new items: " + items.Count);
		}
		yield break;
	}

	// Token: 0x04000BEB RID: 3051
	private const int MAX_CHARACTER_NAME_LENGTH = 18;

	// Token: 0x04000BEC RID: 3052
	private const float NORMAL_HEIGHT = 260f;

	// Token: 0x04000BED RID: 3053
	private const float EXTENDED_HEIGHT = 330f;

	// Token: 0x04000BEE RID: 3054
	private string _characterName = string.Empty;

	// Token: 0x04000BEF RID: 3055
	private float _height = 260f;

	// Token: 0x04000BF0 RID: 3056
	private float _targetHeight = 260f;

	// Token: 0x04000BF1 RID: 3057
	private bool _checkButtonClicked;

	// Token: 0x04000BF2 RID: 3058
	private string _errorMessage = string.Empty;

	// Token: 0x04000BF3 RID: 3059
	private Dictionary<int, string> _errorMessages;

	// Token: 0x04000BF4 RID: 3060
	private List<string> _availableNames;

	// Token: 0x04000BF5 RID: 3061
	private int _selectedIndex = -1;

	// Token: 0x04000BF6 RID: 3062
	private bool _waitingForWsReturn;

	// Token: 0x04000BF7 RID: 3063
	private Color _feedbackMessageColor = Color.white;

	// Token: 0x04000BF8 RID: 3064
	private float _keyboardOffset;

	// Token: 0x04000BF9 RID: 3065
	private float _targetKeyboardOffset;
}
