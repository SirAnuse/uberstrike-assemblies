using System;
using System.Collections.Generic;

// Token: 0x02000173 RID: 371
public class ChatGroup
{
	// Token: 0x060009E6 RID: 2534 RVA: 0x00008323 File Offset: 0x00006523
	public ChatGroup(UserGroups group, string title, ICollection<CommUser> players)
	{
		this.GroupId = group;
		this.Title = title;
		this.Players = players;
	}

	// Token: 0x060009E7 RID: 2535 RVA: 0x0003F160 File Offset: 0x0003D360
	public bool HasUnreadMessages()
	{
		if (this.Players != null)
		{
			foreach (CommUser commUser in this.Players)
			{
				ChatDialog chatDialog;
				if (Singleton<ChatManager>.Instance._dialogsByCmid.TryGetValue(commUser.Cmid, out chatDialog) && chatDialog != null && chatDialog.HasUnreadMessage)
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x060009E8 RID: 2536 RVA: 0x00008340 File Offset: 0x00006540
	// (set) Token: 0x060009E9 RID: 2537 RVA: 0x00008348 File Offset: 0x00006548
	public UserGroups GroupId { get; private set; }

	// Token: 0x170002C2 RID: 706
	// (get) Token: 0x060009EA RID: 2538 RVA: 0x00008351 File Offset: 0x00006551
	// (set) Token: 0x060009EB RID: 2539 RVA: 0x00008359 File Offset: 0x00006559
	public string Title { get; private set; }

	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x060009EC RID: 2540 RVA: 0x00008362 File Offset: 0x00006562
	// (set) Token: 0x060009ED RID: 2541 RVA: 0x0000836A File Offset: 0x0000656A
	public ICollection<CommUser> Players { get; private set; }
}
