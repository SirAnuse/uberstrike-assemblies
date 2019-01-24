using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class HUDDesktopChat : MonoBehaviour
{
	// Token: 0x060015CD RID: 5581 RVA: 0x00079E78 File Offset: 0x00078078
	private void Start()
	{
		this.spamLabel.enabled = false;
		this.textInput = base.GetComponent<UIInput>();
		if (this.textInput == null)
		{
			throw new Exception("Chat: no UIInput attached.");
		}
		GameData.Instance.OnHUDChatMessage.AddEvent(new Action<string, string, MemberAccessLevel>(this.AddMessage), this);
		GameData.Instance.OnHUDChatClear.AddEvent(new Action(this.ClearLog), this);
		GameData.Instance.OnHUDChatStartTyping.AddEvent(delegate()
		{
			this.ActivateTextInput(true);
		}, this);
		GameData.Instance.GameState.AddEvent(delegate(GameStateId el)
		{
			this.ActivateTextInput(false);
		}, this);
		GameData.Instance.PlayerState.AddEvent(delegate(PlayerStateId el)
		{
			this.ActivateTextInput(false);
		}, this);
		AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.IsPlayerMuted.AddEventAndFire(delegate(bool el)
		{
			this.muteLabel.enabled = el;
		}, this);
		foreach (object obj in this.template.transform.parent)
		{
			Transform transform = (Transform)obj;
			if (transform != this.template.transform)
			{
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		for (int i = 0; i < this.maxItems; i++)
		{
			GameObject gameObject = GameObjectHelper.Instantiate(this.template.gameObject, this.template.transform.parent, new Vector3(0f, (float)i * this.ySpace, 0f), this.template.transform.localScale);
			gameObject.name = "Item " + i;
			this.itemsGfx.Add(new HUDDesktopChat.ItemGfx
			{
				Label = gameObject.GetComponent<UILabel>()
			});
		}
		this.template.gameObject.SetActive(false);
		this.ApplyChanges();
		this.ActivateTextInput(false);
	}

	// Token: 0x060015CE RID: 5582 RVA: 0x0000EAB7 File Offset: 0x0000CCB7
	private void OnEnable()
	{
		this.spamLabel.enabled = false;
	}

	// Token: 0x060015CF RID: 5583 RVA: 0x0007A0A0 File Offset: 0x000782A0
	private void ApplyChanges()
	{
		for (int i = 0; i < this.itemsGfx.Count; i++)
		{
			HUDDesktopChat.ItemGfx itemGfx = this.itemsGfx[i];
			HUDDesktopChat.Item item = (i >= this.items.Count) ? null : this.items[i];
			itemGfx.Label.gameObject.SetActive(item != null);
			if (item != null)
			{
				if (item.From != string.Empty)
				{
					itemGfx.Label.color = item.color;
					itemGfx.Label.supportEncoding = (item.accessLevel > MemberAccessLevel.Default);
					itemGfx.Label.text = item.From + ": " + item.Message;
				}
				else
				{
					itemGfx.Label.text = string.Empty;
				}
			}
		}
		this.aligner.Reposition();
	}

	// Token: 0x060015D0 RID: 5584 RVA: 0x0007A198 File Offset: 0x00078398
	private void OnSubmit(string text)
	{
		text = NGUITools.StripSymbols(text).Trim();
		text = TextUtilities.Trim(text);
		if (!string.IsNullOrEmpty(text) && !GameState.Current.SendChatMessage(text, ChatContext.Player))
		{
			this.spamLabel.enabled = true;
			this.lastSpammingTime = Time.time;
		}
		this.OnInputChanged(null);
		this.ActivateTextInput(false);
		this.skipNextEnter = true;
		this.textInput.text = string.Empty;
	}

	// Token: 0x060015D1 RID: 5585 RVA: 0x0007A214 File Offset: 0x00078414
	private void OnInputChanged(object input = null)
	{
		this.textInput.text = this.textInput.text.Replace(this.textInput.caratChar, string.Empty);
		this.inputLabel.text = this.textInput.text;
		float num = NGUIMath.CalculateRelativeWidgetBounds(this.inputLabel.transform).size.y * this.inputLabel.transform.localScale.y;
		this.inputLabelBgr.transform.localScale = this.inputLabelBgr.transform.localScale.SetY(num + this.inputLabel.transform.localScale.y);
	}

	// Token: 0x060015D2 RID: 5586 RVA: 0x0007A2DC File Offset: 0x000784DC
	public void AddMessage(string from, string message, MemberAccessLevel accessLevel)
	{
		this.items.Add(new HUDDesktopChat.Item
		{
			From = from,
			Message = message,
			ColorMod = GUIUtils.ColorToNGuiModifier(ColorScheme.GetNameColorByAccessLevel(accessLevel)),
			accessLevel = accessLevel,
			color = ColorScheme.GetNameColorByAccessLevel(accessLevel),
			TimeEnd = Time.time + this.displayTime
		});
		if (this.items.Count > this.maxItems)
		{
			this.items.RemoveAt(0);
		}
		this.ApplyChanges();
	}

	// Token: 0x060015D3 RID: 5587 RVA: 0x0000EAC5 File Offset: 0x0000CCC5
	public void ClearLog()
	{
		this.items.Clear();
		this.ApplyChanges();
	}

	// Token: 0x060015D4 RID: 5588 RVA: 0x0007A368 File Offset: 0x00078568
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Return) && !PopupSystem.IsAnyPopupOpen)
		{
			if (!this.skipNextEnter)
			{
				this.ActivateTextInput(!GameData.Instance.HUDChatIsTyping);
			}
			this.skipNextEnter = false;
		}
		if (GameData.Instance.HUDChatIsTyping && !this.textInput.selected)
		{
			this.ActivateTextInput(false);
		}
		while (this.items.Count > 0 && Time.time >= this.items[0].TimeEnd)
		{
			this.items.RemoveAt(0);
			this.ApplyChanges();
		}
		if (this.spamLabel.enabled && Time.time >= this.lastSpammingTime + 5f)
		{
			this.spamLabel.enabled = false;
		}
	}

	// Token: 0x060015D5 RID: 5589 RVA: 0x0007A44C File Offset: 0x0007864C
	private void ActivateTextInput(bool enabled)
	{
		enabled &= !AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.IsPlayerMuted;
		GameData.Instance.HUDChatIsTyping = enabled;
		this.textInput.selected = enabled;
		if (enabled)
		{
			this.OnInputChanged(null);
		}
		this.inputLabel.enabled = enabled;
		this.inputLabelBgr.enabled = enabled;
		global::EventHandler.Global.Fire(new GameEvents.ChatWindow
		{
			IsEnabled = enabled
		});
	}

	// Token: 0x0400148D RID: 5261
	[SerializeField]
	private UILabel template;

	// Token: 0x0400148E RID: 5262
	[SerializeField]
	private UIVerticalAligner aligner;

	// Token: 0x0400148F RID: 5263
	[SerializeField]
	private UILabel inputLabel;

	// Token: 0x04001490 RID: 5264
	[SerializeField]
	private UISprite inputLabelBgr;

	// Token: 0x04001491 RID: 5265
	[SerializeField]
	private float ySpace = -17f;

	// Token: 0x04001492 RID: 5266
	[SerializeField]
	private int maxItems = 8;

	// Token: 0x04001493 RID: 5267
	[SerializeField]
	private float displayTime = 5f;

	// Token: 0x04001494 RID: 5268
	[SerializeField]
	private UILabel muteLabel;

	// Token: 0x04001495 RID: 5269
	[SerializeField]
	private UILabel spamLabel;

	// Token: 0x04001496 RID: 5270
	private UIInput textInput;

	// Token: 0x04001497 RID: 5271
	private List<HUDDesktopChat.ItemGfx> itemsGfx = new List<HUDDesktopChat.ItemGfx>();

	// Token: 0x04001498 RID: 5272
	private List<HUDDesktopChat.Item> items = new List<HUDDesktopChat.Item>();

	// Token: 0x04001499 RID: 5273
	private float lastSpammingTime;

	// Token: 0x0400149A RID: 5274
	private bool skipNextEnter;

	// Token: 0x02000307 RID: 775
	[Serializable]
	public class ItemGfx
	{
		// Token: 0x0400149B RID: 5275
		public UILabel Label;
	}

	// Token: 0x02000308 RID: 776
	[Serializable]
	public class Item
	{
		// Token: 0x0400149C RID: 5276
		public string From = string.Empty;

		// Token: 0x0400149D RID: 5277
		public string ColorMod;

		// Token: 0x0400149E RID: 5278
		public MemberAccessLevel accessLevel;

		// Token: 0x0400149F RID: 5279
		public Color color;

		// Token: 0x040014A0 RID: 5280
		public string Message = string.Empty;

		// Token: 0x040014A1 RID: 5281
		public float TimeEnd;
	}
}
