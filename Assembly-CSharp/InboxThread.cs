using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020001A0 RID: 416
public class InboxThread
{
	// Token: 0x06000B66 RID: 2918 RVA: 0x00008F9D File Offset: 0x0000719D
	public InboxThread(MessageThreadView threadView)
	{
		this._threadView = threadView;
		this._messages = new SortedList<int, InboxMessage>(threadView.MessageCount, new InboxThread.MessageSorter());
		this.LastServerUpdate = this._threadView.LastUpdate;
	}

	// Token: 0x170002FD RID: 765
	// (get) Token: 0x06000B67 RID: 2919 RVA: 0x00008FD3 File Offset: 0x000071D3
	// (set) Token: 0x06000B68 RID: 2920 RVA: 0x00008FDA File Offset: 0x000071DA
	public static InboxThread Current { get; set; }

	// Token: 0x170002FE RID: 766
	// (get) Token: 0x06000B69 RID: 2921 RVA: 0x00008FE2 File Offset: 0x000071E2
	// (set) Token: 0x06000B6A RID: 2922 RVA: 0x00008FEA File Offset: 0x000071EA
	public bool IsLoading { get; set; }

	// Token: 0x170002FF RID: 767
	// (get) Token: 0x06000B6B RID: 2923 RVA: 0x00008FF3 File Offset: 0x000071F3
	// (set) Token: 0x06000B6C RID: 2924 RVA: 0x00008FFB File Offset: 0x000071FB
	public DateTime LastServerUpdate { get; private set; }

	// Token: 0x17000300 RID: 768
	// (get) Token: 0x06000B6D RID: 2925 RVA: 0x00009004 File Offset: 0x00007204
	public int ThreadId
	{
		get
		{
			return this._threadView.ThreadId;
		}
	}

	// Token: 0x17000301 RID: 769
	// (get) Token: 0x06000B6E RID: 2926 RVA: 0x00009011 File Offset: 0x00007211
	public string Name
	{
		get
		{
			return this._threadView.ThreadName;
		}
	}

	// Token: 0x17000302 RID: 770
	// (get) Token: 0x06000B6F RID: 2927 RVA: 0x0000901E File Offset: 0x0000721E
	public DateTime LastMessageDateTime
	{
		get
		{
			return this._threadView.LastUpdate;
		}
	}

	// Token: 0x17000303 RID: 771
	// (get) Token: 0x06000B70 RID: 2928 RVA: 0x0000902B File Offset: 0x0000722B
	public IEnumerable<InboxMessage> Messages
	{
		get
		{
			return this._messages.Values;
		}
	}

	// Token: 0x17000304 RID: 772
	// (get) Token: 0x06000B71 RID: 2929 RVA: 0x00009038 File Offset: 0x00007238
	public bool HasUnreadMessage
	{
		get
		{
			return this._threadView.HasNewMessages;
		}
	}

	// Token: 0x17000305 RID: 773
	// (get) Token: 0x06000B72 RID: 2930 RVA: 0x000493F0 File Offset: 0x000475F0
	private string Date
	{
		get
		{
			return string.Concat(new string[]
			{
				this._threadView.LastUpdate.ToString("yyyy MMM "),
				" ",
				this._threadView.LastUpdate.Day.ToString(),
				" at ",
				this._threadView.LastUpdate.ToShortTimeString()
			});
		}
	}

	// Token: 0x17000306 RID: 774
	// (get) Token: 0x06000B73 RID: 2931 RVA: 0x00009045 File Offset: 0x00007245
	public bool IsAdmin
	{
		get
		{
			return this.ThreadId == 767;
		}
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x00049468 File Offset: 0x00047668
	public bool Contains(string keyword)
	{
		bool result = false;
		string value = keyword.ToLower();
		if (this._threadView.ThreadName.ToLower().Contains(value))
		{
			return true;
		}
		foreach (InboxMessage inboxMessage in this._messages.Values)
		{
			if (inboxMessage.Content.ToLower().Contains(value))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x00049504 File Offset: 0x00047704
	public int DrawThread(int y, int width)
	{
		Rect position = new Rect(8f, (float)(y + 8), (float)(width - 8), 68f);
		if (InboxThread.Current == this)
		{
			GUI.Box(new Rect(4f, (float)(y + 4), (float)width, 76f), GUIContent.none, BlueStonez.box_grey50);
		}
		GUI.BeginGroup(position);
		GUI.Label(new Rect(0f, 0f, (float)width, 18f), string.Format("{0} ({1})", this._threadView.ThreadName, this._threadView.MessageCount), BlueStonez.label_interparkbold_13pt);
		GUI.color = new Color(1f, 1f, 1f, 0.5f);
		GUI.Label(new Rect(0f, 20f, (float)width, 10f), this.Date, BlueStonez.label_interparkmed_10pt_left);
		GUI.color = Color.white;
		GUI.Label(new Rect(0f, 50f, (float)width, 18f), this._threadView.LastMessagePreview, BlueStonez.label_interparkmed_10pt_left);
		GUI.EndGroup();
		Rect rect = new Rect((float)(width - 18), (float)(y + 9), 16f, 16f);
		if (GUI.enabled && position.Contains(Event.current.mousePosition))
		{
			GUI.Box(new Rect(4f, (float)(y + 4), (float)width, 76f), GUIContent.none, BlueStonez.group_grey81);
			if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && !rect.Contains(Event.current.mousePosition))
			{
				InboxThread.Current = this;
				this.Scroll.y = float.MinValue;
				if (!this._messagesLoaded)
				{
					this._messagesLoaded = true;
					Singleton<InboxManager>.Instance.LoadMessagesForThread(this, 0);
				}
				if (this._threadView.HasNewMessages)
				{
					this._threadView.HasNewMessages = false;
					Singleton<InboxManager>.Instance.MarkThreadAsRead(this._threadView.ThreadId);
				}
				Event.current.Use();
			}
		}
		if (this._threadView.HasNewMessages)
		{
			GUI.Label(new Rect((float)(width - 40), (float)(y + 5), 29f, 29f), CommunicatorIcons.NewInboxMessage);
		}
		return y + 76 + 8;
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x0004975C File Offset: 0x0004795C
	public int DrawMessageList(int y, int scrollRectWidth, float scrollRectHeight, float curScrollY)
	{
		for (int i = this._messages.Values.Count - 1; i >= 0; i--)
		{
			InboxMessage msg = this._messages.Values[i];
			y += this.DrawContent(msg, y + 12, scrollRectWidth) + 16;
		}
		if (this._messages.Count == 0)
		{
			GUI.Label(new Rect(0f, (float)y, (float)scrollRectWidth, 100f), "This thread is empty", BlueStonez.label_interparkbold_13pt);
		}
		else
		{
			float num = (float)y - scrollRectHeight;
			num = Mathf.Clamp(num, 0f, num);
			if (curScrollY >= num && this._threadView.MessageCount > this._messages.Count && !this.IsLoading)
			{
				this._curPageIndex++;
				Singleton<InboxManager>.Instance.LoadMessagesForThread(this, this._curPageIndex);
			}
		}
		if (this.IsLoading)
		{
			GUI.Label(new Rect(0f, (float)y, (float)scrollRectWidth, 30f), "Loading messages...", BlueStonez.label_interparkbold_13pt);
			y += 30;
		}
		return y;
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x00009054 File Offset: 0x00007254
	public int DrawContent(InboxMessage msg, int y, int width)
	{
		if (msg.IsMine)
		{
			return this.DrawMyMessage(msg, 100, y, width - 100);
		}
		return this.DrawOtherMessage(msg, 0, y, width - 100);
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x0004987C File Offset: 0x00047A7C
	private int DrawOtherMessage(InboxMessage msg, int x, int y, int width)
	{
		int num = Mathf.RoundToInt(BlueStonez.speechbubble_left.CalcHeight(new GUIContent(msg.Content), (float)width)) + 30;
		Rect position = new Rect((float)x, (float)y, (float)width, (float)num);
		GUI.color = new Color(0.5f, 0.5f, 0.5f);
		int num2 = (int)BlueStonez.label_interparkbold_11pt_left.CalcSize(new GUIContent(msg.SenderName)).x;
		GUI.Label(new Rect(position.x + 28f, position.y - 16f, position.width, 12f), msg.SenderName, BlueStonez.label_interparkbold_11pt_left);
		GUI.Label(new Rect(position.x + (float)num2 + 34f, position.y - 15f, position.width, 12f), msg.SentDateString, BlueStonez.label_interparkmed_10pt_left);
		GUI.color = Color.white;
		GUI.BeginGroup(position);
		GUI.backgroundColor = new Color(1f, 1f, 1f, 0.5f);
		if (ApplicationDataManager.IsMobile)
		{
			GUI.Label(new Rect(0f, 0f, position.width, (float)num), msg.Content, BlueStonez.speechbubble_left);
		}
		else
		{
			GUI.TextArea(new Rect(0f, 0f, position.width, (float)num), msg.Content, BlueStonez.speechbubble_left);
		}
		GUI.backgroundColor = Color.white;
		GUI.EndGroup();
		return num;
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x00049A0C File Offset: 0x00047C0C
	private int DrawMyMessage(InboxMessage msg, int x, int y, int width)
	{
		int num = Mathf.RoundToInt(BlueStonez.speechbubble_right.CalcHeight(new GUIContent(msg.Content), (float)width)) + 30;
		Rect position = new Rect((float)x, (float)y, (float)width, (float)num);
		GUI.color = new Color(0.5f, 0.5f, 0.5f);
		int num2 = (int)BlueStonez.label_interparkbold_11pt_left.CalcSize(new GUIContent(msg.SenderName)).x;
		int num3 = (int)BlueStonez.label_interparkmed_10pt_left.CalcSize(new GUIContent(msg.SentDateString)).x;
		GUI.Label(new Rect(position.x + position.width - (float)(num3 + num2 + 40), position.y - 16f, (float)(num2 + 2), 12f), msg.SenderName, BlueStonez.label_interparkbold_11pt_left);
		GUI.Label(new Rect(position.x + position.width - (float)(num3 + 32), position.y - 15f, (float)(num3 + 2), 12f), msg.SentDateString, BlueStonez.label_interparkmed_10pt_left);
		GUI.color = Color.white;
		GUI.BeginGroup(position);
		GUI.backgroundColor = new Color(0.376f, 0.631f, 0.886f, 0.5f);
		if (ApplicationDataManager.IsMobile)
		{
			GUI.Label(new Rect(position.width - position.width, 0f, position.width, (float)num), msg.Content, BlueStonez.speechbubble_right);
		}
		else
		{
			GUI.TextArea(new Rect(position.width - position.width, 0f, position.width, (float)num), msg.Content, BlueStonez.speechbubble_right);
		}
		GUI.backgroundColor = Color.white;
		GUI.EndGroup();
		return num;
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x0000907D File Offset: 0x0000727D
	internal void UpdateThread(MessageThreadView newThreadView)
	{
		if (newThreadView.MessageCount != this._threadView.MessageCount)
		{
			this._messagesLoaded = false;
		}
		this._threadView = newThreadView;
		this.LastServerUpdate = this._threadView.LastUpdate;
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x00049BD8 File Offset: 0x00047DD8
	internal void AddMessage(PrivateMessageView message)
	{
		if (!this._messages.ContainsKey(message.PrivateMessageId))
		{
			this._messages.Add(message.PrivateMessageId, new InboxMessage(message, (message.FromCmid != PlayerDataManager.Cmid) ? this._threadView.ThreadName : PlayerDataManager.Name));
			this._threadView.MessageCount++;
			if (!message.IsRead && message.ToCmid == PlayerDataManager.Cmid)
			{
				this._threadView.HasNewMessages = true;
			}
			if (message.DateSent > this._threadView.LastUpdate)
			{
				this._threadView.LastUpdate = message.DateSent;
				this._threadView.LastMessagePreview = TextUtilities.ShortenText(message.ContentText, 25, true);
			}
		}
		this.Scroll.y = float.MinValue;
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x00049CC8 File Offset: 0x00047EC8
	internal void AddMessages(List<PrivateMessageView> messages)
	{
		foreach (PrivateMessageView privateMessageView in messages)
		{
			if (!this._messages.ContainsKey(privateMessageView.PrivateMessageId))
			{
				this._messages.Add(privateMessageView.PrivateMessageId, new InboxMessage(privateMessageView, (privateMessageView.FromCmid != PlayerDataManager.Cmid) ? this._threadView.ThreadName : PlayerDataManager.Name));
			}
		}
	}

	// Token: 0x04000ACA RID: 2762
	public const int AdminCmid = 767;

	// Token: 0x04000ACB RID: 2763
	public const int NameWidth = 100;

	// Token: 0x04000ACC RID: 2764
	public const int ThreadHeight = 76;

	// Token: 0x04000ACD RID: 2765
	public Vector2 Scroll;

	// Token: 0x04000ACE RID: 2766
	private bool _messagesLoaded;

	// Token: 0x04000ACF RID: 2767
	private MessageThreadView _threadView;

	// Token: 0x04000AD0 RID: 2768
	private SortedList<int, InboxMessage> _messages;

	// Token: 0x04000AD1 RID: 2769
	private int _curPageIndex;

	// Token: 0x020001A1 RID: 417
	private class MessageSorter : IComparer<int>
	{
		// Token: 0x06000B7E RID: 2942 RVA: 0x000090B4 File Offset: 0x000072B4
		public int Compare(int obj1, int obj2)
		{
			return obj1 - obj2;
		}
	}
}
