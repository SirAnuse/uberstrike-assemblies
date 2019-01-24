using System;
using System.Collections.Generic;
using System.Text;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x02000171 RID: 369
public class ChatDialog
{
	// Token: 0x060009CF RID: 2511 RVA: 0x00008237 File Offset: 0x00006437
	public ChatDialog(string title = "")
	{
		this.UserName = string.Empty;
		this.Title = title;
		this._msgQueue = new Queue<InstantMessage>();
		this.AddMessage(new InstantMessage(0, "Disclaimer", "Do not share your password or any other confidential information with anybody. The members of Cmune and the Uberstrike Moderators will never ask you to provide such information.", MemberAccessLevel.Admin, ChatContext.None));
	}

	// Token: 0x060009D0 RID: 2512 RVA: 0x0003EDA4 File Offset: 0x0003CFA4
	public ChatDialog(CommUser user, UserGroups group) : this(string.Empty)
	{
		this.Group = group;
		if (user != null)
		{
			this.UserName = user.ShortName;
			this.UserCmid = user.Cmid;
			this.Title = "Chat with " + this.UserName;
		}
	}

	// Token: 0x060009D1 RID: 2513 RVA: 0x0003EDF8 File Offset: 0x0003CFF8
	public void AddMessage(InstantMessage msg)
	{
		this._reset = true;
		while (this._msgQueue.Count > 200)
		{
			this._msgQueue.Dequeue();
		}
		if (this._lastMessage != null && this._lastMessage.Cmid == msg.Cmid && this._lastMessage.ArrivalTime.AddMinutes(1.0) > DateTime.Now && !msg.IsNotification && !this._lastMessage.IsNotification)
		{
			this._lastMessage.Append(msg.Text);
		}
		else
		{
			this._msgQueue.Enqueue(msg);
			this._lastMessage = msg;
		}
	}

	// Token: 0x060009D2 RID: 2514 RVA: 0x00008275 File Offset: 0x00006475
	public void Clear()
	{
		this._msgQueue.Clear();
		this._lastMessage = null;
	}

	// Token: 0x060009D3 RID: 2515 RVA: 0x00008289 File Offset: 0x00006489
	public void RecalulateBounds()
	{
		this._reset = true;
	}

	// Token: 0x170002BA RID: 698
	// (get) Token: 0x060009D4 RID: 2516 RVA: 0x00008292 File Offset: 0x00006492
	public bool CanChat
	{
		get
		{
			return this.UserCmid == 0 || AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.HasPlayer(this.UserCmid);
		}
	}

	// Token: 0x060009D5 RID: 2517 RVA: 0x0003EEC4 File Offset: 0x0003D0C4
	public bool CheckSize(Rect rect)
	{
		if (this._reset || rect.width != this._frameSize.x || rect.height != this._frameSize.y)
		{
			this._reset = false;
			this._frameSize.x = rect.width;
			this._frameSize.y = rect.height;
			this._contentSize.y = rect.height;
			if (this._totalHeight < rect.height)
			{
				this._totalHeight = 0f;
				this._contentSize.x = rect.width;
				foreach (InstantMessage instantMessage in this._msgQueue)
				{
					instantMessage.UpdateHeight(BlueStonez.label_interparkbold_11pt_left_wrap, this._contentSize.x - 8f, 24, Singleton<ChatManager>.Instance.IsMuted(instantMessage.Cmid));
					this._totalHeight += instantMessage.Height;
				}
			}
			else
			{
				this._totalHeight = 0f;
				this._contentSize.x = rect.width - 17f;
				foreach (InstantMessage instantMessage2 in this._msgQueue)
				{
					instantMessage2.UpdateHeight(BlueStonez.label_interparkbold_11pt_left_wrap, this._contentSize.x - 8f, 24, Singleton<ChatManager>.Instance.IsMuted(instantMessage2.Cmid));
					this._totalHeight += instantMessage2.Height;
				}
			}
			this._contentSize.y = this._totalHeight;
			return true;
		}
		return false;
	}

	// Token: 0x060009D6 RID: 2518 RVA: 0x0003F0BC File Offset: 0x0003D2BC
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Title: " + this.Title);
		stringBuilder.AppendLine("Group: " + this.Group);
		stringBuilder.AppendLine(string.Concat(new object[]
		{
			"User: ",
			this.UserName,
			" ",
			this.UserCmid
		}));
		stringBuilder.AppendLine("CanChat: " + this.CanChat);
		return stringBuilder.ToString();
	}

	// Token: 0x170002BB RID: 699
	// (get) Token: 0x060009D7 RID: 2519 RVA: 0x000082BC File Offset: 0x000064BC
	// (set) Token: 0x060009D8 RID: 2520 RVA: 0x000082C4 File Offset: 0x000064C4
	public string Title { get; private set; }

	// Token: 0x170002BC RID: 700
	// (get) Token: 0x060009D9 RID: 2521 RVA: 0x000082CD File Offset: 0x000064CD
	// (set) Token: 0x060009DA RID: 2522 RVA: 0x000082D5 File Offset: 0x000064D5
	public string UserName { get; private set; }

	// Token: 0x170002BD RID: 701
	// (get) Token: 0x060009DB RID: 2523 RVA: 0x000082DE File Offset: 0x000064DE
	// (set) Token: 0x060009DC RID: 2524 RVA: 0x000082E6 File Offset: 0x000064E6
	public int UserCmid { get; private set; }

	// Token: 0x170002BE RID: 702
	// (get) Token: 0x060009DD RID: 2525 RVA: 0x000082EF File Offset: 0x000064EF
	// (set) Token: 0x060009DE RID: 2526 RVA: 0x000082F7 File Offset: 0x000064F7
	public UserGroups Group { get; set; }

	// Token: 0x170002BF RID: 703
	// (get) Token: 0x060009DF RID: 2527 RVA: 0x00008300 File Offset: 0x00006500
	// (set) Token: 0x060009E0 RID: 2528 RVA: 0x00008308 File Offset: 0x00006508
	public bool HasUnreadMessage { get; set; }

	// Token: 0x170002C0 RID: 704
	// (get) Token: 0x060009E1 RID: 2529 RVA: 0x00008311 File Offset: 0x00006511
	public ICollection<InstantMessage> AllMessages
	{
		get
		{
			return new List<InstantMessage>(this._msgQueue.ToArray());
		}
	}

	// Token: 0x040009F4 RID: 2548
	public ChatDialog.CanShowMessage CanShow;

	// Token: 0x040009F5 RID: 2549
	public Queue<InstantMessage> _msgQueue;

	// Token: 0x040009F6 RID: 2550
	private InstantMessage _lastMessage;

	// Token: 0x040009F7 RID: 2551
	private float _totalHeight;

	// Token: 0x040009F8 RID: 2552
	private bool _reset;

	// Token: 0x040009F9 RID: 2553
	private string _title;

	// Token: 0x040009FA RID: 2554
	public Vector2 _frameSize;

	// Token: 0x040009FB RID: 2555
	public Vector2 _contentSize;

	// Token: 0x040009FC RID: 2556
	public float _heightCache;

	// Token: 0x02000172 RID: 370
	// (Invoke) Token: 0x060009E3 RID: 2531
	public delegate bool CanShowMessage(ChatContext c);
}
