using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020001DC RID: 476
public class SignupPanelGUI : PanelGuiBase
{
	// Token: 0x06000D61 RID: 3425 RVA: 0x00009E78 File Offset: 0x00008078
	private void Awake()
	{
		this._errorMessages = new Dictionary<MemberRegistrationResult, string>();
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x0005D894 File Offset: 0x0005BA94
	private void Start()
	{
		this._errorMessages.Add(MemberRegistrationResult.DuplicateEmail, LocalizedStrings.EmailAddressInUseMsg);
		this._errorMessages.Add(MemberRegistrationResult.DuplicateEmailName, LocalizedStrings.EmailAddressAndNameInUseMsg);
		this._errorMessages.Add(MemberRegistrationResult.DuplicateHandle, LocalizedStrings.NameInUseMsg);
		this._errorMessages.Add(MemberRegistrationResult.DuplicateName, LocalizedStrings.NameInUseMsg);
		this._errorMessages.Add(MemberRegistrationResult.InvalidData, LocalizedStrings.InvalidData);
		this._errorMessages.Add(MemberRegistrationResult.InvalidEmail, LocalizedStrings.EmailAddressIsInvalid);
		this._errorMessages.Add(MemberRegistrationResult.InvalidEsns, LocalizedStrings.InvalidData + " (Esns)");
		this._errorMessages.Add(MemberRegistrationResult.InvalidHandle, LocalizedStrings.InvalidData + " (Handle)");
		this._errorMessages.Add(MemberRegistrationResult.InvalidName, LocalizedStrings.NameInvalidCharsMsg);
		this._errorMessages.Add(MemberRegistrationResult.InvalidPassword, LocalizedStrings.PasswordIsInvalid);
		this._errorMessages.Add(MemberRegistrationResult.IsIpBanned, "IP is banned");
		this._errorMessages.Add(MemberRegistrationResult.MemberNotFound, "I can't find that member. Maybe he's hiding. In any case, you'll have to try again.");
		this._errorMessages.Add(MemberRegistrationResult.OffensiveName, LocalizedStrings.OffensiveNameMsg);
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x00003C87 File Offset: 0x00001E87
	private void HideKeyboard()
	{
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x0005D998 File Offset: 0x0005BB98
	private void Update()
	{
		if (this._height != this._targetHeight)
		{
			this._height = Mathf.Lerp(this._height, this._targetHeight, 10f * Time.deltaTime);
			if (Mathf.Approximately(this._height, this._targetHeight))
			{
				this._height = this._targetHeight;
			}
		}
	}

	// Token: 0x06000D65 RID: 3429 RVA: 0x00009E85 File Offset: 0x00008085
	private void SetTargetKeyboardOffset()
	{
		this._targetKeyboardOffset = ((float)Screen.height - this._height) * 0.5f - ((float)Screen.height * 0.5f - this._height) * 0.5f;
	}

	// Token: 0x06000D66 RID: 3430 RVA: 0x0005D9FC File Offset: 0x0005BBFC
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
		Rect position = new Rect((float)(Screen.width - 500) * 0.5f, ((float)Screen.height - this._height) * 0.5f - this._keyboardOffset, 500f, this._height);
		GUI.BeginGroup(position, GUIContent.none, BlueStonez.window);
		GUI.Label(new Rect(0f, 0f, position.width, 56f), LocalizedStrings.Welcome, BlueStonez.tab_strip);
		Rect position2 = new Rect(20f, 55f, position.width - 40f, position.height - 78f);
		GUI.Label(position2, GUIContent.none, BlueStonez.window_standard_grey38);
		GUI.BeginGroup(position2);
		GUI.Label(new Rect(0f, 0f, position2.width, 60f), LocalizedStrings.PleaseProvideValidEmailPasswordMsg, BlueStonez.label_interparkbold_18pt);
		GUI.Label(new Rect(0f, 76f, 170f, 11f), LocalizedStrings.Email, BlueStonez.label_interparkbold_11pt_right);
		GUI.Label(new Rect(0f, 110f, 170f, 11f), LocalizedStrings.Password, BlueStonez.label_interparkbold_11pt_right);
		GUI.Label(new Rect(0f, 147f, 170f, 11f), LocalizedStrings.VerifyPassword, BlueStonez.label_interparkbold_11pt_right);
		GUI.enabled = this._enableGUI;
		GUI.SetNextControlName("@Email");
		this._emailAddress = GUI.TextField(new Rect(180f, 69f, 180f, 22f), this._emailAddress, BlueStonez.textField);
		if (string.IsNullOrEmpty(this._emailAddress) && GUI.GetNameOfFocusedControl() != "@Email")
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(new Rect(188f, 75f, 180f, 22f), LocalizedStrings.EnterYourEmailAddress, BlueStonez.label_interparkmed_11pt_left);
			GUI.color = Color.white;
		}
		GUI.SetNextControlName("@Password1");
		this._password1 = GUI.PasswordField(new Rect(180f, 104f, 180f, 22f), this._password1, '*', BlueStonez.textField);
		if (string.IsNullOrEmpty(this._password1) && GUI.GetNameOfFocusedControl() != "@Password1")
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(new Rect(188f, 110f, 172f, 18f), LocalizedStrings.EnterYourPassword, BlueStonez.label_interparkmed_11pt_left);
			GUI.color = Color.white;
		}
		GUI.SetNextControlName("@Password2");
		this._password2 = GUI.PasswordField(new Rect(180f, 140f, 180f, 22f), this._password2, '*', BlueStonez.textField);
		if (string.IsNullOrEmpty(this._password2) && GUI.GetNameOfFocusedControl() != "@Password2")
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(new Rect(188f, 146f, 180f, 22f), LocalizedStrings.RetypeYourPassword, BlueStonez.label_interparkmed_11pt_left);
			GUI.color = Color.white;
		}
		GUI.enabled = true;
		GUI.contentColor = this._errorMessageColor;
		GUI.Label(new Rect(0f, 175f, position2.width, 40f), this._errorMessage, BlueStonez.label_interparkbold_11pt);
		GUI.contentColor = Color.white;
		GUI.EndGroup();
		GUI.Label(new Rect(100f, position.height - 42f - 22f, 300f, 16f), "By clicking OK you agree to the", BlueStonez.label_interparkbold_11pt);
		if (GUI.Button(new Rect(185f, position.height - 30f - 12f, 130f, 20f), "Terms of Service", BlueStonez.buttondark_small))
		{
			ApplicationDataManager.OpenUrl("Terms Of Service", "http://www.cmune.com/index.php/terms-of-service/");
			this.HideKeyboard();
		}
		GUI.Label(new Rect(207f, position.height - 15f - 22f, 90f, 20f), GUIContent.none, BlueStonez.horizontal_line_grey95);
		GUI.enabled = this._enableGUI;
		if (GUITools.Button(new Rect(position.width - 150f, position.height - 42f - 22f, 120f, 32f), new GUIContent(LocalizedStrings.OkCaps), BlueStonez.button_green))
		{
			this.HideKeyboard();
			if (!ValidationUtilities.IsValidEmailAddress(this._emailAddress))
			{
				this._targetHeight = 340f;
				this._errorMessageColor = Color.red;
				this._errorMessage = LocalizedStrings.EmailAddressIsInvalid;
			}
			else if (this._password1 != this._password2)
			{
				this._targetHeight = 340f;
				this._errorMessageColor = Color.red;
				this._errorMessage = LocalizedStrings.PasswordDoNotMatch;
			}
			else if (!ValidationUtilities.IsValidPassword(this._password1))
			{
				this._targetHeight = 340f;
				this._errorMessageColor = Color.red;
				this._errorMessage = LocalizedStrings.PasswordInvalidCharsMsg;
			}
			else
			{
				this._enableGUI = false;
				this._targetHeight = 340f;
				this._errorMessageColor = Color.grey;
				this._errorMessage = LocalizedStrings.PleaseWait;
				AuthenticationWebServiceClient.CreateUser(this._emailAddress, this._password1, ApplicationDataManager.Channel, ApplicationDataManager.CurrentLocale.ToString(), SystemInfo.deviceUniqueIdentifier, delegate(MemberRegistrationResult result)
				{
					if (result == MemberRegistrationResult.Ok)
					{
						this.Hide();
						CmunePrefs.WriteKey<string>(CmunePrefs.Key.Player_Email, this._emailAddress);
						CmunePrefs.WriteKey<string>(CmunePrefs.Key.Player_Password, this._password1);
						UnityRuntime.StartRoutine(Singleton<AuthenticationManager>.Instance.StartLoginMemberEmail(this._emailAddress, this._password1));
						this._targetHeight = 300f;
						this._errorMessage = string.Empty;
						this._emailAddress = string.Empty;
						this._password1 = string.Empty;
						this._password2 = string.Empty;
						this._errorMessageColor = Color.red;
						this._enableGUI = true;
					}
					else
					{
						this._enableGUI = true;
						this._targetHeight = 340f;
						this._errorMessageColor = Color.red;
						this._errorMessages.TryGetValue(result, out this._errorMessage);
					}
				}, delegate(Exception ex)
				{
					this._enableGUI = true;
					this._targetHeight = 300f;
					this._errorMessage = string.Empty;
					this.ShowSignUpErrorPopup(LocalizedStrings.Error, "Sign Up was unsuccessful. There was an error communicating with the server.");
				});
			}
		}
		if (GUITools.Button(new Rect(30f, position.height - 42f - 22f, 120f, 32f), new GUIContent(LocalizedStrings.BackCaps), BlueStonez.button))
		{
			this.Hide();
			this.HideKeyboard();
			PanelManager.Instance.OpenPanel(PanelType.Login);
		}
		GUI.enabled = true;
		GUI.EndGroup();
	}

	// Token: 0x06000D67 RID: 3431 RVA: 0x00009EBA File Offset: 0x000080BA
	private void ShowSignUpErrorPopup(string title, string message)
	{
		this.Hide();
		PopupSystem.ShowMessage(title, message, PopupSystem.AlertType.OK, delegate()
		{
			LoginPanelGUI.ErrorMessage = string.Empty;
			this.Show();
		});
	}

	// Token: 0x04000CB5 RID: 3253
	private const float NORMAL_HEIGHT = 300f;

	// Token: 0x04000CB6 RID: 3254
	private const float EXTENDED_HEIGHT = 340f;

	// Token: 0x04000CB7 RID: 3255
	private string _emailAddress = string.Empty;

	// Token: 0x04000CB8 RID: 3256
	private string _password1 = string.Empty;

	// Token: 0x04000CB9 RID: 3257
	private string _password2 = string.Empty;

	// Token: 0x04000CBA RID: 3258
	private string _errorMessage = string.Empty;

	// Token: 0x04000CBB RID: 3259
	private Color _errorMessageColor = Color.red;

	// Token: 0x04000CBC RID: 3260
	private Dictionary<MemberRegistrationResult, string> _errorMessages;

	// Token: 0x04000CBD RID: 3261
	private bool _enableGUI = true;

	// Token: 0x04000CBE RID: 3262
	private float _keyboardOffset;

	// Token: 0x04000CBF RID: 3263
	private float _targetKeyboardOffset;

	// Token: 0x04000CC0 RID: 3264
	private float _height = 300f;

	// Token: 0x04000CC1 RID: 3265
	private float _targetHeight = 300f;
}
