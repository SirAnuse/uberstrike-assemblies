using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000174 RID: 372
public class ChatGroupPanel
{
	// Token: 0x060009EE RID: 2542 RVA: 0x00008373 File Offset: 0x00006573
	public ChatGroupPanel()
	{
		this.SearchText = string.Empty;
		this.chatGroups = new List<ChatGroup>();
	}

	// Token: 0x170002C4 RID: 708
	// (get) Token: 0x060009EF RID: 2543 RVA: 0x00008391 File Offset: 0x00006591
	// (set) Token: 0x060009F0 RID: 2544 RVA: 0x00008399 File Offset: 0x00006599
	public Vector2 Scroll { get; set; }

	// Token: 0x170002C5 RID: 709
	// (get) Token: 0x060009F1 RID: 2545 RVA: 0x000083A2 File Offset: 0x000065A2
	// (set) Token: 0x060009F2 RID: 2546 RVA: 0x000083AA File Offset: 0x000065AA
	public string SearchText { get; set; }

	// Token: 0x170002C6 RID: 710
	// (get) Token: 0x060009F3 RID: 2547 RVA: 0x000083B3 File Offset: 0x000065B3
	// (set) Token: 0x060009F4 RID: 2548 RVA: 0x000083BB File Offset: 0x000065BB
	public float ContentHeight { get; set; }

	// Token: 0x170002C7 RID: 711
	// (get) Token: 0x060009F5 RID: 2549 RVA: 0x000083C4 File Offset: 0x000065C4
	// (set) Token: 0x060009F6 RID: 2550 RVA: 0x000083CC File Offset: 0x000065CC
	public float WindowHeight { get; set; }

	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x060009F7 RID: 2551 RVA: 0x000083D5 File Offset: 0x000065D5
	public IEnumerable<ChatGroup> Groups
	{
		get
		{
			return this.chatGroups;
		}
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x000083DD File Offset: 0x000065DD
	public void AddGroup(UserGroups group, string name, ICollection<CommUser> users)
	{
		this.chatGroups.Add(new ChatGroup(group, name, users));
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x0003F1F4 File Offset: 0x0003D3F4
	public void ScrollToUser(int cmid)
	{
		float total = 0f;
		int num = 0;
		foreach (ChatGroup chatGroup in this.chatGroups)
		{
			foreach (CommUser commUser in chatGroup.Players)
			{
				num++;
				if (commUser.Cmid == cmid)
				{
					break;
				}
			}
		}
		this.chatGroups.ForEach(delegate(ChatGroup g)
		{
			total += (float)g.Players.Count;
		});
		float y = this.ContentHeight * (float)num / total;
		this.Scroll = new Vector2(this.Scroll.x, y);
	}

	// Token: 0x04000A05 RID: 2565
	private readonly List<ChatGroup> chatGroups;
}
