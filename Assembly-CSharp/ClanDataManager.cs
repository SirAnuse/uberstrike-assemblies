using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020002A5 RID: 677
public class ClanDataManager : Singleton<ClanDataManager>
{
	// Token: 0x060012BA RID: 4794 RVA: 0x0000CCEF File Offset: 0x0000AEEF
	private ClanDataManager()
	{
	}

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x060012BB RID: 4795 RVA: 0x0000CCF7 File Offset: 0x0000AEF7
	// (set) Token: 0x060012BC RID: 4796 RVA: 0x0000CCFF File Offset: 0x0000AEFF
	public bool IsGetMyClanDone { get; set; }

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x060012BD RID: 4797 RVA: 0x0000CD08 File Offset: 0x0000AF08
	public bool HaveFriends
	{
		get
		{
			return Singleton<PlayerDataManager>.Instance.FriendsCount >= 1;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x060012BE RID: 4798 RVA: 0x0000CD1A File Offset: 0x0000AF1A
	public bool HaveLevel
	{
		get
		{
			return PlayerDataManager.PlayerLevel >= 4;
		}
	}

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x060012BF RID: 4799 RVA: 0x0000CD27 File Offset: 0x0000AF27
	public bool HaveLicense
	{
		get
		{
			return Singleton<InventoryManager>.Instance.HasClanLicense();
		}
	}

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x060012C0 RID: 4800 RVA: 0x0000CD33 File Offset: 0x0000AF33
	// (set) Token: 0x060012C1 RID: 4801 RVA: 0x0000CD3B File Offset: 0x0000AF3B
	public float NextClanRefresh { get; private set; }

	// Token: 0x060012C2 RID: 4802 RVA: 0x0000CD44 File Offset: 0x0000AF44
	private void HandleWebServiceError()
	{
		Debug.LogError("Error getting Clan data for local player.");
	}

	// Token: 0x060012C3 RID: 4803 RVA: 0x0000CD50 File Offset: 0x0000AF50
	public void CheckCompleteClanData()
	{
		ClanWebServiceClient.GetMyClanId(PlayerDataManager.AuthToken, delegate(int ev)
		{
			PlayerDataManager.ClanID = ev;
			this.RefreshClanData(true);
		}, delegate(Exception ex)
		{
		});
	}

	// Token: 0x060012C4 RID: 4804 RVA: 0x0006F138 File Offset: 0x0006D338
	public void RefreshClanData(bool force = false)
	{
		if (PlayerDataManager.IsPlayerInClan && (force || this.NextClanRefresh < Time.time))
		{
			this.NextClanRefresh = Time.time + 30f;
			ClanWebServiceClient.GetOwnClan(PlayerDataManager.AuthToken, PlayerDataManager.ClanID, delegate(ClanView ev)
			{
				this.SetClanData(ev);
			}, delegate(Exception ex)
			{
			});
		}
	}

	// Token: 0x060012C5 RID: 4805 RVA: 0x0000CD86 File Offset: 0x0000AF86
	public void SetClanData(ClanView view)
	{
		PlayerDataManager.ClanData = view;
		AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendContactList();
		Singleton<ChatManager>.Instance.UpdateClanSection();
	}

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x060012C6 RID: 4806 RVA: 0x0000CDAC File Offset: 0x0000AFAC
	// (set) Token: 0x060012C7 RID: 4807 RVA: 0x0000CDB4 File Offset: 0x0000AFB4
	public bool IsProcessingWebservice { get; private set; }

	// Token: 0x060012C8 RID: 4808 RVA: 0x0000CDBD File Offset: 0x0000AFBD
	public void LeaveClan()
	{
		this.IsProcessingWebservice = true;
		ClanWebServiceClient.LeaveAClan(PlayerDataManager.ClanID, PlayerDataManager.AuthToken, delegate(int ev)
		{
			this.IsProcessingWebservice = false;
			if (ev == 0)
			{
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendUpdateClanMembers();
				this.SetClanData(null);
			}
			else
			{
				PopupSystem.ShowMessage("Leave Clan", "There was an error removing you from this clan.\nErrorCode = " + ev, PopupSystem.AlertType.OK);
			}
		}, delegate(Exception ex)
		{
			this.IsProcessingWebservice = false;
		});
	}

	// Token: 0x060012C9 RID: 4809 RVA: 0x0000CDEE File Offset: 0x0000AFEE
	public void DisbanClan()
	{
		this.IsProcessingWebservice = true;
		ClanWebServiceClient.DisbandGroup(PlayerDataManager.ClanID, PlayerDataManager.AuthToken, delegate(int ev)
		{
			this.IsProcessingWebservice = false;
			if (ev == 0)
			{
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendUpdateClanMembers();
				this.SetClanData(null);
			}
		}, delegate(Exception ex)
		{
			this.IsProcessingWebservice = false;
		});
	}

	// Token: 0x060012CA RID: 4810 RVA: 0x0006F1B0 File Offset: 0x0006D3B0
	public void CreateNewClan(string name, string motto, string tag)
	{
		this.IsProcessingWebservice = true;
		GroupCreationView createClanData = new GroupCreationView
		{
			Name = name,
			Motto = motto,
			ApplicationId = 1,
			AuthToken = PlayerDataManager.AuthToken,
			Tag = tag,
			Locale = ApplicationDataManager.CurrentLocale.ToString()
		};
		ClanWebServiceClient.CreateClan(createClanData, delegate(ClanCreationReturnView ev)
		{
			this.IsProcessingWebservice = false;
			if (ev.ResultCode == 0)
			{
				global::EventHandler.Global.Fire(new GlobalEvents.ClanCreated());
				this.SetClanData(ev.ClanView);
			}
			else
			{
				int resultCode = ev.ResultCode;
				switch (resultCode)
				{
				case 1:
					PopupSystem.ShowMessage("Invalid Clan Name", "The name '" + name + "' is not valid, please modify it.");
					break;
				case 2:
					PopupSystem.ShowMessage("Clan Collision", "You are already member of another clan, please leave first before creating your own.");
					break;
				case 3:
					PopupSystem.ShowMessage("Clan Name", "The name '" + name + "' is already taken, try another one.");
					break;
				case 4:
					PopupSystem.ShowMessage("Invalid Clan Tag", "The tag '" + tag + "' is not valid, please modify it.");
					break;
				default:
					switch (resultCode)
					{
					case 100:
					case 101:
					case 102:
						PopupSystem.ShowMessage("Sorry", "You don't fulfill the minimal requirements to create your own clan.");
						break;
					default:
						PopupSystem.ShowMessage("Sorry", "There was an error (code " + ev.ResultCode + "), please visit support.uberstrike.com for help.");
						break;
					}
					break;
				case 8:
					PopupSystem.ShowMessage("Invalid Clan Motto", "The motto '" + motto + "' is not valid, please modify it.");
					break;
				case 10:
					PopupSystem.ShowMessage("Clan Tag", "The tag '" + tag + "' is already taken, try another one.");
					break;
				}
			}
		}, delegate(Exception ex)
		{
			this.IsProcessingWebservice = false;
			this.SetClanData(null);
		});
	}

	// Token: 0x060012CB RID: 4811 RVA: 0x0006F258 File Offset: 0x0006D458
	public void UpdateMemberTo(int cmid, GroupPosition position)
	{
		this.IsProcessingWebservice = true;
		ClanWebServiceClient.UpdateMemberPosition(new MemberPositionUpdateView(PlayerDataManager.ClanID, PlayerDataManager.AuthToken, cmid, position), delegate(int ev)
		{
			this.IsProcessingWebservice = false;
			ClanMemberView clanMemberView;
			if (ev == 0 && PlayerDataManager.TryGetClanMember(cmid, out clanMemberView))
			{
				clanMemberView.Position = position;
			}
		}, delegate(Exception ex)
		{
			this.IsProcessingWebservice = false;
		});
	}

	// Token: 0x060012CC RID: 4812 RVA: 0x0006F2C0 File Offset: 0x0006D4C0
	public void TransferOwnershipTo(int cmid)
	{
		this.IsProcessingWebservice = true;
		ClanWebServiceClient.TransferOwnership(PlayerDataManager.ClanID, PlayerDataManager.AuthToken, cmid, delegate(int ev)
		{
			this.IsProcessingWebservice = false;
			if (ev == 0)
			{
				ClanMemberView clanMemberView;
				if (PlayerDataManager.TryGetClanMember(cmid, out clanMemberView))
				{
					clanMemberView.Position = GroupPosition.Leader;
				}
				if (PlayerDataManager.TryGetClanMember(PlayerDataManager.Cmid, out clanMemberView))
				{
					clanMemberView.Position = GroupPosition.Member;
				}
				Singleton<PlayerDataManager>.Instance.RankInClan = GroupPosition.Member;
			}
			else
			{
				switch (ev)
				{
				case 100:
					PopupSystem.ShowMessage("Sorry", "The player you selected can't be a clan leader, because he is not level 4 yet!");
					break;
				case 101:
					PopupSystem.ShowMessage("Sorry", "The player you selected can't be a clan leader, because has no friends!");
					break;
				case 102:
					PopupSystem.ShowMessage("Sorry", "The player you selected can't be a clan leader, because he doesn't own a clan license.");
					break;
				default:
					PopupSystem.ShowMessage("Sorry", "There was an error (code " + ev + "), please visit support.uberstrike.com for help.");
					break;
				}
			}
		}, delegate(Exception ex)
		{
			this.IsProcessingWebservice = false;
		});
	}

	// Token: 0x060012CD RID: 4813 RVA: 0x0006F318 File Offset: 0x0006D518
	public void RemoveMemberFromClan(int cmid)
	{
		this.IsProcessingWebservice = true;
		ClanWebServiceClient.KickMemberFromClan(PlayerDataManager.ClanID, PlayerDataManager.AuthToken, cmid, delegate(int ev)
		{
			this.IsProcessingWebservice = false;
			if (ev == 0)
			{
				Singleton<PlayerDataManager>.Instance.ClanMembers.RemoveAll((ClanMemberView m) => m.Cmid == cmid);
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendUpdateClanMembers();
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendUpdateClanData(cmid);
				Singleton<ChatManager>.Instance.UpdateClanSection();
			}
		}, delegate(Exception ex)
		{
			this.IsProcessingWebservice = false;
		});
	}
}
