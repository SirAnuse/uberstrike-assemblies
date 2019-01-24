using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001D2 RID: 466
public class LoginPanelGUI : PanelGuiBase
{
	// Token: 0x17000332 RID: 818
	// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00009A5F File Offset: 0x00007C5F
	// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x00009A66 File Offset: 0x00007C66
	public static string ErrorMessage { get; set; }

	// Token: 0x17000333 RID: 819
	// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x00009A6E File Offset: 0x00007C6E
	// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x00009A75 File Offset: 0x00007C75
	public static bool IsBanned { get; set; }

	// Token: 0x06000CFA RID: 3322 RVA: 0x00009A7D File Offset: 0x00007C7D
	private void Start()
	{
		this._rememberPassword = CmunePrefs.ReadKey<bool>(CmunePrefs.Key.Player_AutoLogin);
		if (this._rememberPassword)
		{
			this._password = CmunePrefs.ReadKey<string>(CmunePrefs.Key.Player_Password);
			this._emailAddress = CmunePrefs.ReadKey<string>(CmunePrefs.Key.Player_Email);
		}
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x00009AB1 File Offset: 0x00007CB1
	public override void Hide()
	{
		base.Hide();
		this._errorAlpha = 0f;
		LoginPanelGUI.ErrorMessage = string.Empty;
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x00059528 File Offset: 0x00057728
	public override void Show()
	{
		base.Show();
		if (LoginPanelGUI.IsBanned)
		{
			LoginPanelGUI.ErrorMessage = LocalizedStrings.YourAccountHasBeenBanned;
		}
		if (!string.IsNullOrEmpty(LoginPanelGUI.ErrorMessage))
		{
			this._errorAlpha = 1f;
		}
		this._panelAlpha = 0f;
		this._keyboardOffset = 0f;
		this._targetKeyboardOffset = 0f;
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x00003C87 File Offset: 0x00001E87
	private void HideKeyboard()
	{
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x0005958C File Offset: 0x0005778C
	private void Update()
	{
		if (!string.IsNullOrEmpty(this._emailAddress))
		{
			this._emailAddress = this._emailAddress.Replace("\n", string.Empty).Replace("\t", string.Empty);
		}
		if (!string.IsNullOrEmpty(this._password))
		{
			this._password = this._password.Replace("\n", string.Empty).Replace("\t", string.Empty);
		}
		if (this._errorAlpha > 0f)
		{
			this._errorAlpha -= Time.deltaTime * 0.1f;
		}
	}

	// Token: 0x06000CFF RID: 3327 RVA: 0x00059638 File Offset: 0x00057838
	private void OnGUI()
	{
		this._panelAlpha = Mathf.Lerp(this._panelAlpha, 1f, Time.deltaTime / 2f);
		GUI.color = new Color(1f, 1f, 1f, this._panelAlpha);
		if (Mathf.Abs(this._keyboardOffset - this._targetKeyboardOffset) > 2f)
		{
			this._keyboardOffset = Mathf.Lerp(this._keyboardOffset, this._targetKeyboardOffset, Time.deltaTime * 4f);
		}
		else
		{
			this._keyboardOffset = this._targetKeyboardOffset;
		}
		this._rect = new Rect((float)((Screen.width - 400) / 2), (float)((Screen.height - 290) / 2) - this._keyboardOffset, 400f, 290f);
		this.DrawLoginPanel();
		if (!string.IsNullOrEmpty(GUI.tooltip))
		{
			Matrix4x4 matrix = GUI.matrix;
			GUI.matrix = Matrix4x4.identity;
			Vector2 vector = BlueStonez.tooltip.CalcSize(new GUIContent(GUI.tooltip));
			Rect position = new Rect(Mathf.Clamp(Event.current.mousePosition.x, 14f, (float)Screen.width - (vector.x + 14f)), Event.current.mousePosition.y + 24f, vector.x, vector.y + 16f);
			GUI.Label(position, GUI.tooltip, BlueStonez.tooltip);
			GUI.matrix = matrix;
		}
		GUI.color = Color.white;
	}

	// Token: 0x06000D00 RID: 3328 RVA: 0x000597CC File Offset: 0x000579CC
	private void DrawLoginPanel()
	{
		GUI.BeginGroup(this._rect, GUIContent.none, BlueStonez.window);
		GUI.depth = 3;
		GUI.Label(new Rect(0f, 0f, this._rect.width, 23f), "Add an existing UberStrike Account to Steam", BlueStonez.tab_strip);
		GUI.Label(new Rect(0f, 48f, this._rect.width - 10f, 48f), "Your UberStrike account will be permanently associated with your Steam account", BlueStonez.label_interparkbold_11pt);
		GUI.Label(new Rect(20f, 108f, 100f, 24f), "Email:");
		this._emailAddress = GUI.TextField(new Rect(128f, 108f, this._rect.width - 164f, 24f), this._emailAddress, 100, BlueStonez.textField);
		if (string.IsNullOrEmpty(this._emailAddress))
		{
			GUI.color = Color.white.SetAlpha(0.3f);
			GUI.color = Color.white;
		}
		GUI.Label(new Rect(20f, 144f, 100f, 24f), "Password:");
		this._password = GUI.PasswordField(new Rect(128f, 144f, this._rect.width - 164f, 24f), this._password, '*', 64, BlueStonez.textField);
		if (string.IsNullOrEmpty(this._password))
		{
			GUI.color = Color.white.SetAlpha(0.3f);
			GUI.color = Color.white;
		}
		if (GUITools.Button(new Rect(70f, 190f, 100f, 52f), new GUIContent("Cancel"), BlueStonez.buttondark_medium))
		{
			this.Hide();
			Singleton<AuthenticationManager>.Instance.LoginByChannel();
		}
		if (GUITools.Button(new Rect(210f, 190f, 100f, 52f), new GUIContent("Add"), BlueStonez.button_green))
		{
			this.HideKeyboard();
			this.Login(this._emailAddress, this._password);
		}
		GUI.Label(new Rect(8f, 256f, this._rect.width - 16f, 8f), GUIContent.none, BlueStonez.horizontal_line_grey95);
		if (GUITools.Button(new Rect(20f, 264f, 100f, 40f), new GUIContent("Forgot password?"), BlueStonez.label_interparkbold_11pt_url))
		{
			this.HideKeyboard();
			ApplicationDataManager.OpenUrl(string.Empty, "http://www.uberstrike.com/#forgot_password");
		}
		if (GUITools.Button(new Rect(this._rect.width - 118f, 264f, 98f, 40f), new GUIContent("Facebook player?"), BlueStonez.label_interparkbold_11pt_url))
		{
			this.HideKeyboard();
			ApplicationDataManager.OpenUrl(string.Empty, "http://www.uberstrike.com/steam");
		}
		GUI.enabled = true;
		GUI.EndGroup();
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x00059ADC File Offset: 0x00057CDC
	public IEnumerator StartCancelDialogTimer()
	{
		if (this.dialogTimer < 5f)
		{
			this.dialogTimer = 5f;
		}
		yield break;
	}

	// Token: 0x06000D02 RID: 3330 RVA: 0x00059AF8 File Offset: 0x00057CF8
	private void Login(string emailAddress, string password)
	{
		CmunePrefs.WriteKey<bool>(CmunePrefs.Key.Player_AutoLogin, this._rememberPassword);
		if (this._rememberPassword)
		{
			CmunePrefs.WriteKey<string>(CmunePrefs.Key.Player_Password, password);
			CmunePrefs.WriteKey<string>(CmunePrefs.Key.Player_Email, emailAddress);
		}
		this._errorAlpha = 1f;
		if (string.IsNullOrEmpty(emailAddress))
		{
			LoginPanelGUI.ErrorMessage = LocalizedStrings.EnterYourEmailAddress;
		}
		else if (string.IsNullOrEmpty(password))
		{
			LoginPanelGUI.ErrorMessage = LocalizedStrings.EnterYourPassword;
		}
		else if (!ValidationUtilities.IsValidEmailAddress(emailAddress))
		{
			LoginPanelGUI.ErrorMessage = LocalizedStrings.EmailAddressIsInvalid;
		}
		else if (!ValidationUtilities.IsValidPassword(password))
		{
			LoginPanelGUI.ErrorMessage = LocalizedStrings.PasswordIsInvalid;
		}
		else
		{
			this.Hide();
			UnityRuntime.StartRoutine(Singleton<AuthenticationManager>.Instance.StartLoginMemberEmail(emailAddress, password));
		}
	}

	// Token: 0x04000C50 RID: 3152
	private Rect _rect;

	// Token: 0x04000C51 RID: 3153
	private string _emailAddress = string.Empty;

	// Token: 0x04000C52 RID: 3154
	private string _password = string.Empty;

	// Token: 0x04000C53 RID: 3155
	private bool _rememberPassword;

	// Token: 0x04000C54 RID: 3156
	private float _keyboardOffset;

	// Token: 0x04000C55 RID: 3157
	private float _targetKeyboardOffset;

	// Token: 0x04000C56 RID: 3158
	private float _errorAlpha;

	// Token: 0x04000C57 RID: 3159
	private float _panelAlpha;

	// Token: 0x04000C58 RID: 3160
	private float dialogTimer;
}
