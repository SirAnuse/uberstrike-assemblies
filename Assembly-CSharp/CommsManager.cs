using System;
using System.Collections;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Realtime.UnitySdk;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020002AA RID: 682
public class CommsManager : Singleton<CommsManager>
{
	// Token: 0x060012E3 RID: 4835 RVA: 0x0000CEBE File Offset: 0x0000B0BE
	private CommsManager()
	{
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x060012E4 RID: 4836 RVA: 0x0000CEC6 File Offset: 0x0000B0C6
	// (set) Token: 0x060012E5 RID: 4837 RVA: 0x0000CECE File Offset: 0x0000B0CE
	public float NextFriendsRefresh { get; private set; }

	// Token: 0x060012E6 RID: 4838 RVA: 0x0006F708 File Offset: 0x0006D908
	public void SendFriendRequest(int cmid, string message)
	{
		message = TextUtilities.ShortenText(TextUtilities.Trim(message), 140, false);
		RelationshipWebServiceClient.SendContactRequest(PlayerDataManager.AuthToken, cmid, message, delegate
		{
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendUpdateInboxRequests(cmid);
		}, delegate(Exception ex)
		{
		});
	}

	// Token: 0x060012E7 RID: 4839 RVA: 0x0006F770 File Offset: 0x0006D970
	public IEnumerator GetContactsByGroups()
	{
		this.NextFriendsRefresh = Time.time + 30f;
		yield return RelationshipWebServiceClient.GetContactsByGroups(PlayerDataManager.AuthToken, false, delegate(List<ContactGroupView> ev)
		{
			List<PublicProfileView> list = new List<PublicProfileView>();
			foreach (ContactGroupView contactGroupView in ev)
			{
				foreach (PublicProfileView item in contactGroupView.Contacts)
				{
					list.Add(item);
				}
			}
			Singleton<PlayerDataManager>.Instance.FriendList = list;
			this.UpdateCommunicator();
		}, delegate(Exception ex)
		{
		});
		yield break;
	}

	// Token: 0x060012E8 RID: 4840 RVA: 0x0000CED7 File Offset: 0x0000B0D7
	public void UpdateCommunicator()
	{
		AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendContactList();
		Singleton<ChatManager>.Instance.UpdateFriendSection();
	}
}
