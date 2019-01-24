using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x0200023C RID: 572
public class InstantMessage
{
	// Token: 0x06000FB4 RID: 4020 RVA: 0x00065620 File Offset: 0x00063820
	public InstantMessage(int cmid, string playerName, string messageText, MemberAccessLevel level, ChatContext context = ChatContext.None)
	{
		this.Cmid = cmid;
		this.PlayerName = playerName;
		this.Text = messageText;
		this.AccessLevel = level;
		this.ArrivalTime = DateTime.Now;
		this.TimeString = this.ArrivalTime.ToString("t");
		this.Context = context;
		this.IsFriend = PlayerDataManager.IsFriend(this.Cmid);
		this.IsFacebookFriend = PlayerDataManager.IsFacebookFriend(this.Cmid);
		this.IsClan = PlayerDataManager.IsClanMember(this.Cmid);
	}

	// Token: 0x06000FB5 RID: 4021 RVA: 0x000656B0 File Offset: 0x000638B0
	public InstantMessage(int cmid, string playerName, string messageText, MemberAccessLevel level, CommActorInfo actor, ChatContext context = ChatContext.None)
	{
		this.Cmid = cmid;
		this.PlayerName = playerName;
		this.Text = messageText;
		this.AccessLevel = level;
		this.ArrivalTime = DateTime.Now;
		this.TimeString = this.ArrivalTime.ToString("t");
		this.Context = context;
		this.IsFriend = PlayerDataManager.IsFriend(this.Cmid);
		this.IsFacebookFriend = PlayerDataManager.IsFacebookFriend(this.Cmid);
		this.IsClan = PlayerDataManager.IsClanMember(this.Cmid);
		this.Actor = actor;
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x00065748 File Offset: 0x00063948
	public InstantMessage(InstantMessage instantMessage)
	{
		this.Cmid = instantMessage.Cmid;
		this.PlayerName = instantMessage.PlayerName;
		this.Text = instantMessage.Text;
		this.TimeString = instantMessage.TimeString;
		this.AccessLevel = instantMessage.AccessLevel;
		this.Context = instantMessage.Context;
		this.IsFriend = PlayerDataManager.IsFriend(this.Cmid);
		this.IsFacebookFriend = PlayerDataManager.IsFacebookFriend(this.Cmid);
		this.IsClan = PlayerDataManager.IsClanMember(this.Cmid);
	}

	// Token: 0x170003AA RID: 938
	// (get) Token: 0x06000FB7 RID: 4023 RVA: 0x0000B16F File Offset: 0x0000936F
	// (set) Token: 0x06000FB8 RID: 4024 RVA: 0x0000B177 File Offset: 0x00009377
	public int Cmid { get; private set; }

	// Token: 0x170003AB RID: 939
	// (get) Token: 0x06000FB9 RID: 4025 RVA: 0x0000B180 File Offset: 0x00009380
	// (set) Token: 0x06000FBA RID: 4026 RVA: 0x0000B188 File Offset: 0x00009388
	public float Height { get; private set; }

	// Token: 0x170003AC RID: 940
	// (get) Token: 0x06000FBB RID: 4027 RVA: 0x0000B191 File Offset: 0x00009391
	// (set) Token: 0x06000FBC RID: 4028 RVA: 0x0000B199 File Offset: 0x00009399
	public string PlayerName { get; private set; }

	// Token: 0x170003AD RID: 941
	// (get) Token: 0x06000FBD RID: 4029 RVA: 0x0000B1A2 File Offset: 0x000093A2
	// (set) Token: 0x06000FBE RID: 4030 RVA: 0x0000B1AA File Offset: 0x000093AA
	public string Text { get; private set; }

	// Token: 0x170003AE RID: 942
	// (get) Token: 0x06000FBF RID: 4031 RVA: 0x0000B1B3 File Offset: 0x000093B3
	// (set) Token: 0x06000FC0 RID: 4032 RVA: 0x0000B1BB File Offset: 0x000093BB
	public string TimeString { get; private set; }

	// Token: 0x170003AF RID: 943
	// (get) Token: 0x06000FC1 RID: 4033 RVA: 0x0000B1C4 File Offset: 0x000093C4
	// (set) Token: 0x06000FC2 RID: 4034 RVA: 0x0000B1CC File Offset: 0x000093CC
	public DateTime ArrivalTime { get; private set; }

	// Token: 0x170003B0 RID: 944
	// (get) Token: 0x06000FC3 RID: 4035 RVA: 0x0000B1D5 File Offset: 0x000093D5
	// (set) Token: 0x06000FC4 RID: 4036 RVA: 0x0000B1DD File Offset: 0x000093DD
	public MemberAccessLevel AccessLevel { get; private set; }

	// Token: 0x170003B1 RID: 945
	// (get) Token: 0x06000FC5 RID: 4037 RVA: 0x0000B1E6 File Offset: 0x000093E6
	// (set) Token: 0x06000FC6 RID: 4038 RVA: 0x0000B1EE File Offset: 0x000093EE
	public bool IsFriend { get; private set; }

	// Token: 0x170003B2 RID: 946
	// (get) Token: 0x06000FC7 RID: 4039 RVA: 0x0000B1F7 File Offset: 0x000093F7
	// (set) Token: 0x06000FC8 RID: 4040 RVA: 0x0000B1FF File Offset: 0x000093FF
	public bool IsFacebookFriend { get; private set; }

	// Token: 0x170003B3 RID: 947
	// (get) Token: 0x06000FC9 RID: 4041 RVA: 0x0000B208 File Offset: 0x00009408
	// (set) Token: 0x06000FCA RID: 4042 RVA: 0x0000B210 File Offset: 0x00009410
	public bool IsClan { get; private set; }

	// Token: 0x170003B4 RID: 948
	// (get) Token: 0x06000FCB RID: 4043 RVA: 0x0000B219 File Offset: 0x00009419
	// (set) Token: 0x06000FCC RID: 4044 RVA: 0x0000B221 File Offset: 0x00009421
	public ChatContext Context { get; private set; }

	// Token: 0x170003B5 RID: 949
	// (get) Token: 0x06000FCD RID: 4045 RVA: 0x0000B22A File Offset: 0x0000942A
	public bool IsNotification
	{
		get
		{
			return string.IsNullOrEmpty(this.PlayerName);
		}
	}

	// Token: 0x170003B6 RID: 950
	// (get) Token: 0x06000FCE RID: 4046 RVA: 0x0000B237 File Offset: 0x00009437
	// (set) Token: 0x06000FCF RID: 4047 RVA: 0x0000B23F File Offset: 0x0000943F
	public CommActorInfo Actor { get; private set; }

	// Token: 0x06000FD0 RID: 4048 RVA: 0x0000B248 File Offset: 0x00009448
	public void UpdateHeight(GUIStyle style, float width, int offset = 0, bool isMuted = false)
	{
		this.Height = ((!isMuted) ? (style.CalcHeight(new GUIContent(this.Text), width) + (float)offset) : 0f);
	}

	// Token: 0x06000FD1 RID: 4049 RVA: 0x0000B276 File Offset: 0x00009476
	public void Append(string message)
	{
		this.Text = this.Text + "\n" + message;
	}
}
