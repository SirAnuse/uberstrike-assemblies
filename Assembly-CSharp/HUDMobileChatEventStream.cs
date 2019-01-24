using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class HUDMobileChatEventStream : MonoBehaviour
{
	// Token: 0x060015FF RID: 5631 RVA: 0x0007AD94 File Offset: 0x00078F94
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
		GameData.Instance.OnHUDStreamMessage.AddEvent(new Action<GameActorInfo, string, GameActorInfo>(this.AddMessage), this);
		GameData.Instance.OnHUDStreamClear.AddEvent(new Action(this.ClearLog), this);
		GameData.Instance.OnPlayerKilled.AddEvent(new Action<GameActorInfo, GameActorInfo, UberstrikeItemClass, BodyPart>(HUDDesktopEventStream.HandleKilledMessage), this);
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
			GameObject gameObject = GameObjectHelper.Instantiate(this.template.gameObject, this.template.transform.parent, new Vector3(0f, (float)i * this.ySpace, 0f));
			gameObject.name = "Item " + i;
			this.itemsGfx.Add(new HUDMobileChatEventStream.ItemGfx
			{
				Label1 = gameObject.transform.Find("1_label").GetComponent<UILabel>(),
				Label2 = gameObject.transform.Find("2_label").GetComponent<UILabel>(),
				Label3 = gameObject.transform.Find("3_label").GetComponent<UILabel>(),
				Aligner = gameObject.GetComponent<UIHorizontalAligner>()
			});
		}
		this.template.gameObject.SetActive(false);
		this.ApplyChanges();
		this.ActivateTextInput(false);
	}

	// Token: 0x06001600 RID: 5632 RVA: 0x0007B01C File Offset: 0x0007921C
	private void ApplyChanges()
	{
		for (int i = 0; i < this.itemsGfx.Count; i++)
		{
			HUDMobileChatEventStream.ItemGfx itemGfx = this.itemsGfx[i];
			HUDMobileChatEventStream.Item item = (i >= this.items.Count) ? null : this.items[i];
			itemGfx.Aligner.gameObject.SetActive(item != null);
			if (item != null)
			{
				itemGfx.Label1.text = item.Label1;
				itemGfx.Label1.lineWidth = item.Label1MaxWidth;
				itemGfx.Label1.effectColor = item.Label1EffectColor;
				itemGfx.Label1.effectStyle = item.Label1Effect;
				itemGfx.Label2.text = item.Label2;
				itemGfx.Label3.text = item.Label3;
				itemGfx.Label3.effectColor = item.Label3EffectColor;
				itemGfx.Label3.effectStyle = item.Label3Effect;
				itemGfx.Label1.gameObject.SetActive(itemGfx.Label1.text != string.Empty);
				itemGfx.Label2.gameObject.SetActive(itemGfx.Label2.text != string.Empty);
				itemGfx.Label3.gameObject.SetActive(itemGfx.Label3.text != string.Empty);
				itemGfx.Aligner.Reposition();
			}
		}
		this.aligner.Reposition();
	}

	// Token: 0x06001601 RID: 5633 RVA: 0x0007B1A8 File Offset: 0x000793A8
	private void OnSubmit(string text)
	{
		text = NGUITools.StripSymbols(text).Trim();
		text = TextUtilities.Trim(text);
		if (text != string.Empty && !GameState.Current.SendChatMessage(text, ChatContext.Player))
		{
			this.spamLabel.enabled = true;
		}
		this.ActivateTextInput(false);
	}

	// Token: 0x06001602 RID: 5634 RVA: 0x0007B200 File Offset: 0x00079400
	public void AddMessage(GameActorInfo player1, string actionString, GameActorInfo player2)
	{
		this.items.Add(new HUDMobileChatEventStream.Item
		{
			Label1 = ((!string.IsNullOrEmpty(player1.ClanTag)) ? ("[" + player1.ClanTag + "] " + player1.PlayerName) : player1.PlayerName),
			Label1Effect = UILabel.Effect.Outline,
			Label1EffectColor = HUDDesktopEventStream.GetPlayerColor(player1),
			Label2 = actionString,
			Label3 = ((player2 != null) ? ((!string.IsNullOrEmpty(player2.ClanTag)) ? ("[" + player2.ClanTag + "] " + player2.PlayerName) : player2.PlayerName) : string.Empty),
			Label3Effect = UILabel.Effect.Outline,
			Label3EffectColor = HUDDesktopEventStream.GetPlayerColor(player2),
			TimeEnd = Time.time + this.displayTime
		});
		if (this.items.Count > this.maxItems)
		{
			this.items.RemoveAt(0);
		}
		this.ApplyChanges();
	}

	// Token: 0x06001603 RID: 5635 RVA: 0x0007B310 File Offset: 0x00079510
	public void AddMessage(string from, string message, MemberAccessLevel accessLevel)
	{
		string str = GUIUtils.ColorToNGuiModifier(ColorScheme.GetNameColorByAccessLevel(accessLevel));
		this.items.Add(new HUDMobileChatEventStream.Item
		{
			Label1 = str + from + ": [-]" + message,
			Label1MaxWidth = 270,
			Label1Effect = UILabel.Effect.Shadow,
			Label1EffectColor = GUIUtils.ColorBlack,
			Label2 = string.Empty,
			Label3 = string.Empty,
			TimeEnd = Time.time + this.displayTime
		});
		if (this.items.Count > this.maxItems)
		{
			this.items.RemoveAt(0);
		}
		this.ApplyChanges();
	}

	// Token: 0x06001604 RID: 5636 RVA: 0x0000ED75 File Offset: 0x0000CF75
	public void ClearLog()
	{
		this.items.Clear();
		this.ApplyChanges();
	}

	// Token: 0x06001605 RID: 5637 RVA: 0x0007B3BC File Offset: 0x000795BC
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Return) && !PopupSystem.IsAnyPopupOpen)
		{
			this.ActivateTextInput(true);
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
	}

	// Token: 0x06001606 RID: 5638 RVA: 0x0007B450 File Offset: 0x00079650
	private void ActivateTextInput(bool enabled)
	{
		GameData.Instance.HUDChatIsTyping = enabled;
		this.textInput.selected = enabled;
		global::EventHandler.Global.Fire(new GameEvents.ChatWindow
		{
			IsEnabled = enabled
		});
	}

	// Token: 0x040014BF RID: 5311
	[SerializeField]
	private UIHorizontalAligner template;

	// Token: 0x040014C0 RID: 5312
	[SerializeField]
	private UIVerticalAligner aligner;

	// Token: 0x040014C1 RID: 5313
	[SerializeField]
	private float ySpace = 20f;

	// Token: 0x040014C2 RID: 5314
	[SerializeField]
	private int maxItems = 8;

	// Token: 0x040014C3 RID: 5315
	[SerializeField]
	private float displayTime = 5f;

	// Token: 0x040014C4 RID: 5316
	[SerializeField]
	private UILabel muteLabel;

	// Token: 0x040014C5 RID: 5317
	[SerializeField]
	private UILabel spamLabel;

	// Token: 0x040014C6 RID: 5318
	private UIInput textInput;

	// Token: 0x040014C7 RID: 5319
	private List<HUDMobileChatEventStream.ItemGfx> itemsGfx = new List<HUDMobileChatEventStream.ItemGfx>();

	// Token: 0x040014C8 RID: 5320
	private List<HUDMobileChatEventStream.Item> items = new List<HUDMobileChatEventStream.Item>();

	// Token: 0x02000311 RID: 785
	[Serializable]
	public class ItemGfx
	{
		// Token: 0x040014C9 RID: 5321
		public UILabel Label1;

		// Token: 0x040014CA RID: 5322
		public UILabel Label2;

		// Token: 0x040014CB RID: 5323
		public UILabel Label3;

		// Token: 0x040014CC RID: 5324
		public UIHorizontalAligner Aligner;
	}

	// Token: 0x02000312 RID: 786
	[Serializable]
	public class Item
	{
		// Token: 0x040014CD RID: 5325
		public string Label1 = string.Empty;

		// Token: 0x040014CE RID: 5326
		public int Label1MaxWidth;

		// Token: 0x040014CF RID: 5327
		public Color Label1EffectColor;

		// Token: 0x040014D0 RID: 5328
		public UILabel.Effect Label1Effect;

		// Token: 0x040014D1 RID: 5329
		public string Label2 = string.Empty;

		// Token: 0x040014D2 RID: 5330
		public string Label3 = string.Empty;

		// Token: 0x040014D3 RID: 5331
		public Color Label3EffectColor;

		// Token: 0x040014D4 RID: 5332
		public UILabel.Effect Label3Effect;

		// Token: 0x040014D5 RID: 5333
		public float TimeEnd;
	}
}
