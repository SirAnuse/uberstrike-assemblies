using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000364 RID: 868
public class AvatarHudInformation : MonoBehaviour
{
	// Token: 0x0600183B RID: 6203 RVA: 0x000103E9 File Offset: 0x0000E5E9
	private void Awake()
	{
		this._transform = base.transform;
		this._nameTextStyle = BlueStonez.label_interparkbold_13pt;
	}

	// Token: 0x0600183C RID: 6204 RVA: 0x00082270 File Offset: 0x00080470
	private void OnGUI()
	{
		if (!this._isInViewport)
		{
			return;
		}
		GUI.depth = 100;
		if (!this._isEnemy && !this._isMe && GameState.Current.HasJoinedGame)
		{
			Rect position = new Rect(this._screenPosition.x - 50f, (float)Screen.height - this._screenPosition.y + this._barOffset.y, 100f, 6f);
			this.DrawBar(position, 100);
			Rect position2 = new Rect(position.xMin, (float)Screen.height - this._screenPosition.y - this._textSize.y - 6f, this._textSize.x, this._textSize.y);
			this.DrawName(position2);
		}
		else if (this._isMe || this._show)
		{
			Rect position3 = new Rect(this._screenPosition.x - this._textSize.x * 0.5f, (float)Screen.height - this._screenPosition.y - this._textSize.y - 6f, this._textSize.x, this._textSize.y);
			this.DrawName(position3);
		}
	}

	// Token: 0x0600183D RID: 6205 RVA: 0x000823D0 File Offset: 0x000805D0
	private void LateUpdate()
	{
		this._isInViewport = this.IsTransformInViewport();
		this._isEnemy = (this._info != null && (this._info.TeamID == TeamID.NONE || this._info.TeamID != GameState.Current.PlayerData.Player.TeamID) && !GameState.Current.PlayerData.IsSpectator);
		this._isMe = (this._info == null || this._info.Cmid == PlayerDataManager.Cmid);
		this._color.a = Mathf.Clamp01(this._color.a + Time.deltaTime * 2f);
		if (this._timer > 0f)
		{
			this._timer = Mathf.Max(this._timer - Time.deltaTime, 0f);
			this._color.a = Mathf.Clamp01(this._timer);
			this._show = (this._timer > 0f);
		}
	}

	// Token: 0x0600183E RID: 6206 RVA: 0x00010402 File Offset: 0x0000E602
	public void Show()
	{
		this._show = true;
		if (this._isEnemy)
		{
			this._timer = 2f;
		}
	}

	// Token: 0x0600183F RID: 6207 RVA: 0x00010421 File Offset: 0x0000E621
	public void Hide()
	{
		this._show = false;
	}

	// Token: 0x06001840 RID: 6208 RVA: 0x0001042A File Offset: 0x0000E62A
	public void SetAvatarLabel(string name)
	{
		this._text = name;
		this._textSize = this._nameTextStyle.CalcSize(new GUIContent(name));
	}

	// Token: 0x06001841 RID: 6209 RVA: 0x0001044A File Offset: 0x0000E64A
	public void SetHealthBarValue(float value)
	{
		this._barValue = Mathf.Clamp01(value);
	}

	// Token: 0x06001842 RID: 6210 RVA: 0x000824E8 File Offset: 0x000806E8
	public void SetCharacterInfo(GameActorInfo info)
	{
		if (info != null)
		{
			this.SetAvatarLabel((!string.IsNullOrEmpty(info.ClanTag)) ? ("[" + info.ClanTag + "] " + info.PlayerName) : info.PlayerName);
			this._info = info;
		}
	}

	// Token: 0x06001843 RID: 6211 RVA: 0x00082540 File Offset: 0x00080740
	private bool IsTransformInViewport()
	{
		if (Camera.main)
		{
			this._screenPosition = Vector3.Lerp(this._screenPosition, Camera.main.WorldToScreenPoint(this._transform.position + this._offset), Time.deltaTime * 30f);
			Vector3 rhs = this._transform.position + this._offset - Camera.main.transform.position;
			Camera.main.ResetWorldToCameraMatrix();
			return Vector3.Dot(Camera.main.transform.forward, rhs) > 0f && (this._screenPosition.x >= 0f && this._screenPosition.x <= (float)Screen.width && this._screenPosition.y >= 0f) && this._screenPosition.y <= (float)Screen.height;
		}
		return false;
	}

	// Token: 0x06001844 RID: 6212 RVA: 0x0008264C File Offset: 0x0008084C
	private void DrawName(Rect position)
	{
		if (this._color.a > 0f)
		{
			GUI.color = new Color(0f, 0f, 0f, this._color.a);
			GUI.Label(new Rect(position.x + 1f, position.y + 1f, position.width, position.height), this._text, this._nameTextStyle);
			GUI.color = this._color;
			GUI.Label(position, this._text, this._nameTextStyle);
			GUI.color = Color.white;
		}
	}

	// Token: 0x06001845 RID: 6213 RVA: 0x000826F8 File Offset: 0x000808F8
	private void DrawBar(Rect position, int barWidth)
	{
		if (this._color.a > 0f)
		{
			GUI.color = new Color(1f, 1f, 1f, this._color.a);
			GUI.DrawTexture(position, UberstrikeIconsHelper.White);
			GUI.color = Color.green.SetAlpha(this._color.a);
			GUI.DrawTexture(new Rect(position.xMin + 1f, position.yMin + 1f, (position.width - 2f) * this._barValue, position.height - 2f), UberstrikeIconsHelper.White);
			GUI.color = Color.white;
		}
	}

	// Token: 0x040016E7 RID: 5863
	[SerializeField]
	private Vector2 _barOffset = new Vector2(0f, 0f);

	// Token: 0x040016E8 RID: 5864
	[SerializeField]
	private Color _color = Color.white;

	// Token: 0x040016E9 RID: 5865
	[SerializeField]
	private Vector3 _offset = new Vector3(0f, 2f, 0f);

	// Token: 0x040016EA RID: 5866
	private string _text;

	// Token: 0x040016EB RID: 5867
	private Transform _transform;

	// Token: 0x040016EC RID: 5868
	private Vector3 _screenPosition;

	// Token: 0x040016ED RID: 5869
	private float _barValue;

	// Token: 0x040016EE RID: 5870
	private Vector2 _textSize;

	// Token: 0x040016EF RID: 5871
	private bool _isInViewport;

	// Token: 0x040016F0 RID: 5872
	private bool _show;

	// Token: 0x040016F1 RID: 5873
	private float _timer;

	// Token: 0x040016F2 RID: 5874
	private GameActorInfo _info;

	// Token: 0x040016F3 RID: 5875
	private GUIStyle _nameTextStyle;

	// Token: 0x040016F4 RID: 5876
	private bool _isMe;

	// Token: 0x040016F5 RID: 5877
	private bool _isEnemy;
}
