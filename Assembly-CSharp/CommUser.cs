using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;

// Token: 0x02000181 RID: 385
public class CommUser
{
	// Token: 0x06000A75 RID: 2677 RVA: 0x00008804 File Offset: 0x00006A04
	public CommUser(CommActorInfo user)
	{
		this.SetActor(user);
	}

	// Token: 0x06000A76 RID: 2678 RVA: 0x0000881E File Offset: 0x00006A1E
	public CommUser(GameActorInfo user)
	{
		this.Cmid = user.Cmid;
		this.Name = user.PlayerName;
		this.ActorId = user.Cmid;
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x00043748 File Offset: 0x00041948
	public CommUser(PublicProfileView profile)
	{
		if (profile != null)
		{
			this.IsFriend = PlayerDataManager.IsFriend(profile.Cmid);
			this.IsFacebookFriend = PlayerDataManager.IsFacebookFriend(profile.Cmid);
			this.Cmid = profile.Cmid;
			this.AccessLevel = profile.AccessLevel;
			this.Name = ((!string.IsNullOrEmpty(profile.GroupTag)) ? ("[" + profile.GroupTag + "] " + profile.Name) : profile.Name);
		}
	}

	// Token: 0x06000A78 RID: 2680 RVA: 0x000437E4 File Offset: 0x000419E4
	public CommUser(ClanMemberView member)
	{
		if (member != null)
		{
			this.IsClanMember = true;
			this.Cmid = member.Cmid;
			this.AccessLevel = MemberAccessLevel.Default;
			this.Name = ((!string.IsNullOrEmpty(PlayerDataManager.ClanTag)) ? ("[" + PlayerDataManager.ClanTag + "] " + member.Name) : member.Name);
		}
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x00008855 File Offset: 0x00006A55
	public override int GetHashCode()
	{
		return this.Cmid;
	}

	// Token: 0x06000A7A RID: 2682 RVA: 0x0004385C File Offset: 0x00041A5C
	public void SetActor(CommActorInfo actor)
	{
		if (actor != null)
		{
			this.Cmid = actor.Cmid;
			this.AccessLevel = actor.AccessLevel;
			this.Name = ((!string.IsNullOrEmpty(actor.ClanTag)) ? ("[" + actor.ClanTag + "] " + actor.PlayerName) : actor.PlayerName);
			this.Channel = actor.Channel;
			this.ModerationFlag = (int)actor.ModerationFlag;
			this.ModerationInfo = actor.ModInformation;
			this.CurrentGame = actor.CurrentRoom;
			this.IsOnline = true;
		}
		else
		{
			this.ActorId = 0;
			this.CurrentGame = null;
			this.IsOnline = false;
		}
	}

	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0000885D File Offset: 0x00006A5D
	// (set) Token: 0x06000A7C RID: 2684 RVA: 0x00008865 File Offset: 0x00006A65
	public int Cmid { get; private set; }

	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06000A7E RID: 2686 RVA: 0x0000886E File Offset: 0x00006A6E
	// (set) Token: 0x06000A7D RID: 2685 RVA: 0x00043914 File Offset: 0x00041B14
	public string Name
	{
		get
		{
			return this._name;
		}
		set
		{
			this.ShortName = value;
			this._name = value;
			int num = this._name.IndexOf("]");
			if (num > 0 && num + 1 < this._name.Length)
			{
				this.ShortName = this._name.Substring(num + 1);
			}
		}
	}

	// Token: 0x170002DC RID: 732
	// (get) Token: 0x06000A7F RID: 2687 RVA: 0x00008876 File Offset: 0x00006A76
	// (set) Token: 0x06000A80 RID: 2688 RVA: 0x0000887E File Offset: 0x00006A7E
	public int ActorId { get; private set; }

	// Token: 0x170002DD RID: 733
	// (get) Token: 0x06000A81 RID: 2689 RVA: 0x00008887 File Offset: 0x00006A87
	// (set) Token: 0x06000A82 RID: 2690 RVA: 0x0000888F File Offset: 0x00006A8F
	public string ShortName { get; private set; }

	// Token: 0x170002DE RID: 734
	// (get) Token: 0x06000A83 RID: 2691 RVA: 0x00008898 File Offset: 0x00006A98
	// (set) Token: 0x06000A84 RID: 2692 RVA: 0x000088A0 File Offset: 0x00006AA0
	public MemberAccessLevel AccessLevel { get; private set; }

	// Token: 0x170002DF RID: 735
	// (get) Token: 0x06000A85 RID: 2693 RVA: 0x000088A9 File Offset: 0x00006AA9
	public PresenceType PresenceIndex
	{
		get
		{
			if (this.IsOnline)
			{
				return (!this.IsInGame) ? PresenceType.Online : PresenceType.InGame;
			}
			return PresenceType.Offline;
		}
	}

	// Token: 0x170002E0 RID: 736
	// (get) Token: 0x06000A86 RID: 2694 RVA: 0x000088CA File Offset: 0x00006ACA
	// (set) Token: 0x06000A87 RID: 2695 RVA: 0x000088D2 File Offset: 0x00006AD2
	public int ModerationFlag { get; private set; }

	// Token: 0x170002E1 RID: 737
	// (get) Token: 0x06000A88 RID: 2696 RVA: 0x000088DB File Offset: 0x00006ADB
	// (set) Token: 0x06000A89 RID: 2697 RVA: 0x000088E3 File Offset: 0x00006AE3
	public string ModerationInfo { get; private set; }

	// Token: 0x170002E2 RID: 738
	// (get) Token: 0x06000A8A RID: 2698 RVA: 0x000088EC File Offset: 0x00006AEC
	// (set) Token: 0x06000A8B RID: 2699 RVA: 0x000088F4 File Offset: 0x00006AF4
	public ChannelType Channel { get; private set; }

	// Token: 0x170002E3 RID: 739
	// (get) Token: 0x06000A8C RID: 2700 RVA: 0x000088FD File Offset: 0x00006AFD
	// (set) Token: 0x06000A8D RID: 2701 RVA: 0x00008905 File Offset: 0x00006B05
	public GameRoom CurrentGame { get; set; }

	// Token: 0x170002E4 RID: 740
	// (get) Token: 0x06000A8E RID: 2702 RVA: 0x0000890E File Offset: 0x00006B0E
	// (set) Token: 0x06000A8F RID: 2703 RVA: 0x00008916 File Offset: 0x00006B16
	public bool IsFriend { get; set; }

	// Token: 0x170002E5 RID: 741
	// (get) Token: 0x06000A90 RID: 2704 RVA: 0x0000891F File Offset: 0x00006B1F
	// (set) Token: 0x06000A91 RID: 2705 RVA: 0x00008927 File Offset: 0x00006B27
	public bool IsFacebookFriend { get; set; }

	// Token: 0x170002E6 RID: 742
	// (get) Token: 0x06000A92 RID: 2706 RVA: 0x00008930 File Offset: 0x00006B30
	// (set) Token: 0x06000A93 RID: 2707 RVA: 0x00008938 File Offset: 0x00006B38
	public bool IsClanMember { get; set; }

	// Token: 0x170002E7 RID: 743
	// (get) Token: 0x06000A94 RID: 2708 RVA: 0x00008941 File Offset: 0x00006B41
	public bool IsInGame
	{
		get
		{
			return this.CurrentGame != null && this.CurrentGame.Number > 0 && this.CurrentGame.Server != null;
		}
	}

	// Token: 0x170002E8 RID: 744
	// (get) Token: 0x06000A95 RID: 2709 RVA: 0x00008973 File Offset: 0x00006B73
	// (set) Token: 0x06000A96 RID: 2710 RVA: 0x0000897B File Offset: 0x00006B7B
	public bool IsOnline { get; set; }

	// Token: 0x04000A3F RID: 2623
	private string _name = string.Empty;
}
