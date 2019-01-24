using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000185 RID: 389
public class PopupMenu
{
	// Token: 0x06000AB7 RID: 2743 RVA: 0x00008A74 File Offset: 0x00006C74
	public PopupMenu()
	{
		this._items = new List<PopupMenu.MenuItem>();
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x00044984 File Offset: 0x00042B84
	public void AddMenuCopyItem(string caption, Action<CommUser, InstantMessage> action, Func<CommUser, bool> isEnabledForUser)
	{
		PopupMenu.MenuItem item = new PopupMenu.MenuItem
		{
			Caption = caption,
			CopyMsgCallback = action,
			CopyMsg = action,
			CheckItem = isEnabledForUser
		};
		this._items.Add(item);
	}

	// Token: 0x06000AB9 RID: 2745 RVA: 0x000449C4 File Offset: 0x00042BC4
	public void AddMenuCopyPlayerName(string caption, Action<CommUser, InstantMessage> action, Func<CommUser, bool> isEnabledForUser)
	{
		PopupMenu.MenuItem item = new PopupMenu.MenuItem
		{
			Caption = caption,
			CopyPlayerName = action,
			CopyMsg = action,
			CheckItem = isEnabledForUser
		};
		this._items.Add(item);
	}

	// Token: 0x06000ABA RID: 2746 RVA: 0x00044A04 File Offset: 0x00042C04
	public void AddMenuItem(Func<CommUser, string> caption, Action<CommUser> action, Func<CommUser, bool> isEnabledForUser)
	{
		PopupMenu.MenuItem item = new PopupMenu.MenuItem
		{
			DynamicCaption = caption,
			Caption = string.Empty,
			Callback = action,
			CheckItem = isEnabledForUser
		};
		this._items.Add(item);
	}

	// Token: 0x06000ABB RID: 2747 RVA: 0x00044A48 File Offset: 0x00042C48
	public void AddMenuItem(string caption, Action<CommUser> action, Func<CommUser, bool> isEnabledForUser)
	{
		PopupMenu.MenuItem item = new PopupMenu.MenuItem
		{
			Caption = caption,
			Callback = action,
			CheckItem = isEnabledForUser
		};
		this._items.Add(item);
	}

	// Token: 0x06000ABC RID: 2748 RVA: 0x00044A80 File Offset: 0x00042C80
	private void Configure()
	{
		foreach (PopupMenu.MenuItem menuItem in this._items)
		{
			menuItem.Enabled = menuItem.CheckItem(this._selectedUser);
			if (menuItem.DynamicCaption != null)
			{
				menuItem.Caption = menuItem.DynamicCaption(this._selectedUser);
			}
		}
	}

	// Token: 0x06000ABD RID: 2749 RVA: 0x00008A87 File Offset: 0x00006C87
	public static void Hide()
	{
		PopupMenu.Current = null;
	}

	// Token: 0x06000ABE RID: 2750 RVA: 0x00008A8F File Offset: 0x00006C8F
	public void Show(Vector2 screenPos, CommUser user)
	{
		PopupMenu.Show(screenPos, user, this);
	}

	// Token: 0x06000ABF RID: 2751 RVA: 0x00044B0C File Offset: 0x00042D0C
	public static void Show(Vector2 screenPos, CommUser user, PopupMenu menu)
	{
		if (menu != null)
		{
			menu._selectedUser = user;
			menu.Configure();
			menu._position.height = (float)(24 * menu._items.FindAll((PopupMenu.MenuItem i) => i.Enabled).Count);
			menu._position.width = 105f;
			menu._position.x = screenPos.x - 1f;
			if (screenPos.y + menu._position.height > (float)Screen.height)
			{
				menu._position.y = screenPos.y - menu._position.height + 1f;
			}
			else
			{
				menu._position.y = screenPos.y - 1f;
			}
			PopupMenu.Current = menu;
		}
	}

	// Token: 0x06000AC0 RID: 2752 RVA: 0x00044BF8 File Offset: 0x00042DF8
	public void Draw()
	{
		GUI.BeginGroup(new Rect(this._position.x, this._position.y, this._position.width, this._position.height + 6f), BlueStonez.window);
		GUI.Label(new Rect(1f, 1f, this._position.width - 2f, this._position.height + 4f), GUIContent.none, BlueStonez.box_grey50);
		GUI.Label(new Rect(0f, 0f, this._position.width, this._position.height + 6f), GUIContent.none, BlueStonez.box_grey50);
		GUITools.PushGUIState();
		int num = 0;
		foreach (PopupMenu.MenuItem menuItem in this._items)
		{
			if (menuItem.Enabled)
			{
				if (menuItem.CopyMsgCallback != null)
				{
					GUI.enabled = (menuItem.CopyMsgCallback != null);
				}
				else
				{
					GUI.enabled = (menuItem.Callback != null);
				}
				GUI.Label(new Rect(8f, (float)(8 + num * 24), this._position.width - 8f, 24f), menuItem.Caption, BlueStonez.label_interparkmed_11pt_left);
				if (menuItem.Callback != null && GUI.Button(new Rect(2f, (float)(3 + num * 24), this._position.width - 4f, 24f), GUIContent.none, BlueStonez.dropdown_list))
				{
					PopupMenu.Current = null;
					menuItem.Callback(this._selectedUser);
				}
				else if (menuItem.CopyMsgCallback != null && GUI.Button(new Rect(2f, (float)(3 + num * 24), this._position.width - 4f, 24f), GUIContent.none, BlueStonez.dropdown_list))
				{
					PopupMenu.Current = null;
					menuItem.CopyMsgCallback(this._selectedUser, this.msg);
				}
				num++;
			}
		}
		GUITools.PopGUIState();
		GUI.EndGroup();
		if (Event.current.type == EventType.MouseUp && !this._position.Contains(Event.current.mousePosition))
		{
			PopupMenu.Current = null;
		}
	}

	// Token: 0x170002E9 RID: 745
	// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x00008A99 File Offset: 0x00006C99
	public CommUser SelectedUser
	{
		get
		{
			return this._selectedUser;
		}
	}

	// Token: 0x170002EA RID: 746
	// (get) Token: 0x06000AC2 RID: 2754 RVA: 0x00008AA1 File Offset: 0x00006CA1
	// (set) Token: 0x06000AC3 RID: 2755 RVA: 0x00008AA9 File Offset: 0x00006CA9
	public InstantMessage msg { get; set; }

	// Token: 0x170002EB RID: 747
	// (get) Token: 0x06000AC4 RID: 2756 RVA: 0x00008AB2 File Offset: 0x00006CB2
	// (set) Token: 0x06000AC5 RID: 2757 RVA: 0x00008AB9 File Offset: 0x00006CB9
	public static PopupMenu Current { get; private set; }

	// Token: 0x170002EC RID: 748
	// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x00008AC1 File Offset: 0x00006CC1
	public static bool IsEnabled
	{
		get
		{
			return PopupMenu.Current != null;
		}
	}

	// Token: 0x04000A5E RID: 2654
	private const int Height = 24;

	// Token: 0x04000A5F RID: 2655
	private const int Width = 105;

	// Token: 0x04000A60 RID: 2656
	private Rect _position;

	// Token: 0x04000A61 RID: 2657
	private List<PopupMenu.MenuItem> _items;

	// Token: 0x04000A62 RID: 2658
	private CommUser _selectedUser;

	// Token: 0x02000186 RID: 390
	private class MenuItem
	{
		// Token: 0x04000A66 RID: 2662
		public string Caption;

		// Token: 0x04000A67 RID: 2663
		public Action<CommUser> Callback;

		// Token: 0x04000A68 RID: 2664
		public Action<CommUser, InstantMessage> CopyMsgCallback;

		// Token: 0x04000A69 RID: 2665
		public Action<CommUser, InstantMessage> CopyMsg;

		// Token: 0x04000A6A RID: 2666
		public Action<CommUser, InstantMessage> CopyPlayerName;

		// Token: 0x04000A6B RID: 2667
		public Func<CommUser, bool> CheckItem;

		// Token: 0x04000A6C RID: 2668
		public Func<CommUser, string> DynamicCaption;

		// Token: 0x04000A6D RID: 2669
		public bool Enabled;
	}
}
