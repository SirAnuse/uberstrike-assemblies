using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Realtime.UnitySdk;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020001AD RID: 429
public class NameChangePanelGUI : PanelGuiBase
{
	// Token: 0x06000BC7 RID: 3015 RVA: 0x00003C87 File Offset: 0x00001E87
	private void Update()
	{
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x00003C87 File Offset: 0x00001E87
	private void HideKeyboard()
	{
	}

	// Token: 0x06000BC9 RID: 3017 RVA: 0x0004D3CC File Offset: 0x0004B5CC
	private void OnGUI()
	{
		if (Mathf.Abs(this._keyboardOffset - this._targetKeyboardOffset) > 2f)
		{
			this._keyboardOffset = Mathf.Lerp(this._keyboardOffset, this._targetKeyboardOffset, Time.deltaTime * 4f);
		}
		else
		{
			this._keyboardOffset = this._targetKeyboardOffset;
		}
		this._groupRect = new Rect((float)(Screen.width - 340) * 0.5f, (float)(Screen.height - 200) * 0.5f - this._keyboardOffset, 340f, 200f);
		GUI.depth = 3;
		GUI.skin = BlueStonez.Skin;
		Rect groupRect = this._groupRect;
		GUI.BeginGroup(groupRect, string.Empty, BlueStonez.window_standard_grey38);
		if (this.nameChangeItem != null)
		{
			this.nameChangeItem.DrawIcon(new Rect(8f, 8f, 48f, 48f));
			if (BlueStonez.label_interparkbold_32pt_left.CalcSize(new GUIContent(this.nameChangeItem.View.Name)).x > groupRect.width - 72f)
			{
				GUI.Label(new Rect(64f, 8f, groupRect.width - 72f, 30f), this.nameChangeItem.View.Name, BlueStonez.label_interparkbold_18pt_left);
			}
			else
			{
				GUI.Label(new Rect(64f, 8f, groupRect.width - 72f, 30f), this.nameChangeItem.View.Name, BlueStonez.label_interparkbold_32pt_left);
			}
		}
		GUI.Label(new Rect(64f, 30f, groupRect.width - 72f, 30f), LocalizedStrings.FunctionalItem, BlueStonez.label_interparkbold_16pt_left);
		Rect rect = new Rect(8f, 116f, this._groupRect.width - 16f, this._groupRect.height - 120f - 46f);
		GUI.BeginGroup(new Rect(rect.xMin, 74f, rect.width, rect.height + 42f), string.Empty, BlueStonez.group_grey81);
		GUI.EndGroup();
		GUI.Label(new Rect(56f, 72f, 227f, 20f), LocalizedStrings.ChooseCharacterName, BlueStonez.label_interparkbold_11pt);
		GUI.SetNextControlName("@ChooseName");
		Rect position = new Rect(56f, 102f, 227f, 24f);
		GUI.changed = false;
		this.newName = GUI.TextField(position, this.newName, 18, BlueStonez.textField);
		this.newName = TextUtilities.Trim(this.newName);
		if (string.IsNullOrEmpty(this.newName) && GUI.GetNameOfFocusedControl() != "@ChooseName")
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(position, LocalizedStrings.EnterYourName, BlueStonez.label_interparkmed_11pt);
			GUI.color = Color.white;
		}
		if (GUITools.Button(new Rect(groupRect.width - 118f, 160f, 110f, 32f), new GUIContent(LocalizedStrings.CancelCaps), BlueStonez.button))
		{
			this.HideKeyboard();
			this.Hide();
		}
		GUI.enabled = !this.isChangingName;
		if (GUITools.Button(new Rect(groupRect.width - 230f, 160f, 110f, 32f), new GUIContent(LocalizedStrings.OkCaps), BlueStonez.button_green))
		{
			this.HideKeyboard();
			this.ChangeName();
		}
		GUI.EndGroup();
		GUI.enabled = true;
		if (this.isChangingName)
		{
			WaitingTexture.Draw(new Vector2(groupRect.x + 305f, groupRect.y + 114f), 0);
		}
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000BCA RID: 3018 RVA: 0x0004D7C8 File Offset: 0x0004B9C8
	private void ChangeName()
	{
		if (!this.newName.Equals(this.oldName) && !string.IsNullOrEmpty(this.newName))
		{
			this.isChangingName = true;
			UserWebServiceClient.ChangeMemberName(PlayerDataManager.AuthToken, this.newName, ApplicationDataManager.CurrentLocale.ToString(), SystemInfo.deviceUniqueIdentifier, delegate(MemberOperationResult t)
			{
				switch (t)
				{
				case MemberOperationResult.Ok:
					PlayerDataManager.Name = this.newName;
					AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Operations.SendAuthenticationRequest(PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
					base.StartCoroutine(Singleton<ItemManager>.Instance.StartGetInventory(false));
					PopupSystem.ShowMessage("Congratulations", "You successfully changed your name to:\n" + this.newName, PopupSystem.AlertType.OK, "YEAH", delegate()
					{
					});
					this.Hide();
					break;
				default:
					switch (t)
					{
					case MemberOperationResult.InvalidName:
						PopupSystem.ShowMessage(LocalizedStrings.Error, LocalizedStrings.NameInvalidCharsMsg);
						goto IL_123;
					case MemberOperationResult.OffensiveName:
						PopupSystem.ShowMessage(LocalizedStrings.Error, LocalizedStrings.OffensiveNameMsg);
						goto IL_123;
					}
					Debug.LogError("Failed to change name: " + t);
					PopupSystem.ShowMessage(LocalizedStrings.Error, LocalizedStrings.Unknown);
					break;
				case MemberOperationResult.DuplicateName:
					PopupSystem.ShowMessage(LocalizedStrings.Error, LocalizedStrings.NameInUseMsg);
					break;
				}
				IL_123:
				this.isChangingName = false;
			}, delegate(Exception ex)
			{
				this.isChangingName = false;
				this.Hide();
			});
		}
	}

	// Token: 0x06000BCB RID: 3019 RVA: 0x0004D840 File Offset: 0x0004BA40
	public override void Show()
	{
		base.Show();
		this.nameChangeItem = Singleton<ItemManager>.Instance.GetItemInShop(1294);
		this.oldName = PlayerDataManager.Name;
		this.newName = this.oldName;
		this._targetKeyboardOffset = 0f;
		this._keyboardOffset = 0f;
	}

	// Token: 0x04000B3B RID: 2875
	private const int MAX_CHARACTER_NAME_LENGTH = 18;

	// Token: 0x04000B3C RID: 2876
	private Rect _groupRect = new Rect(1f, 1f, 1f, 1f);

	// Token: 0x04000B3D RID: 2877
	private string newName = string.Empty;

	// Token: 0x04000B3E RID: 2878
	private string oldName = string.Empty;

	// Token: 0x04000B3F RID: 2879
	private IUnityItem nameChangeItem;

	// Token: 0x04000B40 RID: 2880
	private bool isChangingName;

	// Token: 0x04000B41 RID: 2881
	private float _keyboardOffset;

	// Token: 0x04000B42 RID: 2882
	private float _targetKeyboardOffset;
}
