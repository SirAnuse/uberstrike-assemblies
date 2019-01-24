using System;
using System.Collections;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using Steamworks;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Core.ViewModel;
using UberStrike.DataCenter.Common.Entities;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020002D5 RID: 725
public class PlayerDataManager : Singleton<PlayerDataManager>
{
	// Token: 0x06001486 RID: 5254 RVA: 0x00075ABC File Offset: 0x00073CBC
	private PlayerDataManager()
	{
		this._serverLocalPlayerPlayerStatisticsView = new PlayerStatisticsView();
		this._playerClanData = new ClanView();
	}

	// Token: 0x170004DC RID: 1244
	// (get) Token: 0x06001487 RID: 5255 RVA: 0x0000DC20 File Offset: 0x0000BE20
	// (set) Token: 0x06001488 RID: 5256 RVA: 0x0000DC27 File Offset: 0x0000BE27
	public static string MagicHash { get; set; }

	// Token: 0x170004DD RID: 1245
	// (get) Token: 0x06001489 RID: 5257 RVA: 0x00003C84 File Offset: 0x00001E84
	public static bool IsTestBuild
	{
		get
		{
			return false;
		}
	}

	// Token: 0x170004DE RID: 1246
	// (get) Token: 0x0600148A RID: 5258 RVA: 0x0000DC2F File Offset: 0x0000BE2F
	public float GearWeight
	{
		get
		{
			return Mathf.Clamp01((float)(GameState.Current.PlayerData.ArmorCarried / 2 + 40) / 100f);
		}
	}

	// Token: 0x170004DF RID: 1247
	// (get) Token: 0x0600148B RID: 5259 RVA: 0x0000DC56 File Offset: 0x0000BE56
	public int FriendsCount
	{
		get
		{
			return this._friends.Count + this._facebookFriends.Count;
		}
	}

	// Token: 0x170004E0 RID: 1248
	// (get) Token: 0x0600148C RID: 5260 RVA: 0x00075B14 File Offset: 0x00073D14
	public static string SteamId
	{
		get
		{
			return SteamUser.GetSteamID().ToString();
		}
	}

	// Token: 0x170004E1 RID: 1249
	// (get) Token: 0x0600148D RID: 5261 RVA: 0x0000DC6F File Offset: 0x0000BE6F
	public PlayerStatisticsView ServerLocalPlayerStatisticsView
	{
		get
		{
			return this._serverLocalPlayerPlayerStatisticsView;
		}
	}

	// Token: 0x170004E2 RID: 1250
	// (get) Token: 0x0600148E RID: 5262 RVA: 0x0000DC77 File Offset: 0x0000BE77
	public static Color SkinColor
	{
		get
		{
			return Singleton<PlayerDataManager>.Instance._localPlayerSkinColor;
		}
	}

	// Token: 0x170004E3 RID: 1251
	// (get) Token: 0x0600148F RID: 5263 RVA: 0x0000DC83 File Offset: 0x0000BE83
	// (set) Token: 0x06001490 RID: 5264 RVA: 0x00075B30 File Offset: 0x00073D30
	public IEnumerable<PublicProfileView> FriendList
	{
		get
		{
			return this._friends.Values;
		}
		set
		{
			this._friends.Clear();
			if (value != null)
			{
				foreach (PublicProfileView publicProfileView in value)
				{
					this._friends[publicProfileView.Cmid] = publicProfileView;
				}
			}
		}
	}

	// Token: 0x170004E4 RID: 1252
	// (get) Token: 0x06001491 RID: 5265 RVA: 0x0000DC90 File Offset: 0x0000BE90
	// (set) Token: 0x06001492 RID: 5266 RVA: 0x00075BA0 File Offset: 0x00073DA0
	public IEnumerable<PublicProfileView> FacebookFriends
	{
		get
		{
			return this._facebookFriends.Values;
		}
		set
		{
			this._facebookFriends.Clear();
			if (value != null)
			{
				foreach (PublicProfileView publicProfileView in value)
				{
					if (!this._friends.ContainsKey(publicProfileView.Cmid))
					{
						this._facebookFriends[publicProfileView.Cmid] = publicProfileView;
					}
				}
			}
		}
	}

	// Token: 0x170004E5 RID: 1253
	// (get) Token: 0x06001493 RID: 5267 RVA: 0x00075C24 File Offset: 0x00073E24
	public List<PublicProfileView> MergedFriends
	{
		get
		{
			List<PublicProfileView> list = new List<PublicProfileView>(this.FriendList);
			list.AddRange(this.FacebookFriends);
			return list;
		}
	}

	// Token: 0x170004E6 RID: 1254
	// (get) Token: 0x06001494 RID: 5268 RVA: 0x0000DC9D File Offset: 0x0000BE9D
	public static bool IsPlayerLoggedIn
	{
		get
		{
			return PlayerDataManager.Cmid > 0;
		}
	}

	// Token: 0x170004E7 RID: 1255
	// (get) Token: 0x06001495 RID: 5269 RVA: 0x0000DCA7 File Offset: 0x0000BEA7
	// (set) Token: 0x06001496 RID: 5270 RVA: 0x0000DCAE File Offset: 0x0000BEAE
	public static MemberAccessLevel AccessLevel { get; private set; }

	// Token: 0x170004E8 RID: 1256
	// (get) Token: 0x06001497 RID: 5271 RVA: 0x0000DCB6 File Offset: 0x0000BEB6
	// (set) Token: 0x06001498 RID: 5272 RVA: 0x0000DCBD File Offset: 0x0000BEBD
	public static int Cmid { get; private set; }

	// Token: 0x170004E9 RID: 1257
	// (get) Token: 0x06001499 RID: 5273 RVA: 0x0000DCC5 File Offset: 0x0000BEC5
	// (set) Token: 0x0600149A RID: 5274 RVA: 0x0000DCCC File Offset: 0x0000BECC
	public static string Name { get; set; }

	// Token: 0x170004EA RID: 1258
	// (get) Token: 0x0600149B RID: 5275 RVA: 0x0000DCD4 File Offset: 0x0000BED4
	// (set) Token: 0x0600149C RID: 5276 RVA: 0x0000DCDB File Offset: 0x0000BEDB
	public static string Email { get; private set; }

	// Token: 0x170004EB RID: 1259
	// (get) Token: 0x0600149D RID: 5277 RVA: 0x0000DCE3 File Offset: 0x0000BEE3
	// (set) Token: 0x0600149E RID: 5278 RVA: 0x0000DCEA File Offset: 0x0000BEEA
	public static int Credits { get; private set; }

	// Token: 0x170004EC RID: 1260
	// (get) Token: 0x0600149F RID: 5279 RVA: 0x0000DCF2 File Offset: 0x0000BEF2
	// (set) Token: 0x060014A0 RID: 5280 RVA: 0x0000DCF9 File Offset: 0x0000BEF9
	public static int Points { get; set; }

	// Token: 0x170004ED RID: 1261
	// (get) Token: 0x060014A1 RID: 5281 RVA: 0x0000DD01 File Offset: 0x0000BF01
	// (set) Token: 0x060014A2 RID: 5282 RVA: 0x0000DD08 File Offset: 0x0000BF08
	public static int PlayerExperience { get; private set; }

	// Token: 0x170004EE RID: 1262
	// (get) Token: 0x060014A3 RID: 5283 RVA: 0x0000DD10 File Offset: 0x0000BF10
	// (set) Token: 0x060014A4 RID: 5284 RVA: 0x0000DD17 File Offset: 0x0000BF17
	public static int PlayerLevel { get; private set; }

	// Token: 0x170004EF RID: 1263
	// (get) Token: 0x060014A5 RID: 5285 RVA: 0x0000DD1F File Offset: 0x0000BF1F
	// (set) Token: 0x060014A6 RID: 5286 RVA: 0x0000DD26 File Offset: 0x0000BF26
	public static string AuthToken { get; set; }

	// Token: 0x170004F0 RID: 1264
	// (set) Token: 0x060014A7 RID: 5287 RVA: 0x00075C4C File Offset: 0x00073E4C
	public static ClanView ClanData
	{
		set
		{
			Singleton<PlayerDataManager>.Instance._playerClanData = value;
			Singleton<PlayerDataManager>.Instance._clanMembers.Clear();
			if (value != null)
			{
				PlayerDataManager.ClanID = value.GroupId;
				if (value.Members != null)
				{
					foreach (ClanMemberView clanMemberView in value.Members)
					{
						Singleton<PlayerDataManager>.Instance._clanMembers[clanMemberView.Cmid] = clanMemberView;
						if (clanMemberView.Cmid == PlayerDataManager.Cmid)
						{
							Singleton<PlayerDataManager>.Instance.RankInClan = clanMemberView.Position;
						}
					}
				}
			}
			else
			{
				PlayerDataManager.ClanID = 0;
				Singleton<PlayerDataManager>.Instance._clanMembers.Clear();
				Singleton<PlayerDataManager>.Instance.RankInClan = GroupPosition.Member;
			}
		}
	}

	// Token: 0x170004F1 RID: 1265
	// (get) Token: 0x060014A8 RID: 5288 RVA: 0x0000DD2E File Offset: 0x0000BF2E
	public static bool IsPlayerInClan
	{
		get
		{
			return PlayerDataManager.ClanID > 0;
		}
	}

	// Token: 0x170004F2 RID: 1266
	// (get) Token: 0x060014A9 RID: 5289 RVA: 0x0000DD38 File Offset: 0x0000BF38
	// (set) Token: 0x060014AA RID: 5290 RVA: 0x0000DD3F File Offset: 0x0000BF3F
	public static int ClanID { get; set; }

	// Token: 0x170004F3 RID: 1267
	// (get) Token: 0x060014AB RID: 5291 RVA: 0x0000DD47 File Offset: 0x0000BF47
	// (set) Token: 0x060014AC RID: 5292 RVA: 0x0000DD4F File Offset: 0x0000BF4F
	public GroupPosition RankInClan { get; set; }

	// Token: 0x170004F4 RID: 1268
	// (get) Token: 0x060014AD RID: 5293 RVA: 0x0000DD58 File Offset: 0x0000BF58
	public static string ClanName
	{
		get
		{
			return (Singleton<PlayerDataManager>.Instance._playerClanData == null) ? string.Empty : Singleton<PlayerDataManager>.Instance._playerClanData.Name;
		}
	}

	// Token: 0x170004F5 RID: 1269
	// (get) Token: 0x060014AE RID: 5294 RVA: 0x0000DD82 File Offset: 0x0000BF82
	public static string ClanTag
	{
		get
		{
			return (Singleton<PlayerDataManager>.Instance._playerClanData == null) ? string.Empty : Singleton<PlayerDataManager>.Instance._playerClanData.Tag;
		}
	}

	// Token: 0x170004F6 RID: 1270
	// (get) Token: 0x060014AF RID: 5295 RVA: 0x0000DDAC File Offset: 0x0000BFAC
	public static string ClanMotto
	{
		get
		{
			return (Singleton<PlayerDataManager>.Instance._playerClanData == null) ? string.Empty : Singleton<PlayerDataManager>.Instance._playerClanData.Motto;
		}
	}

	// Token: 0x170004F7 RID: 1271
	// (get) Token: 0x060014B0 RID: 5296 RVA: 0x0000DDD6 File Offset: 0x0000BFD6
	public static DateTime ClanFoundingDate
	{
		get
		{
			return (Singleton<PlayerDataManager>.Instance._playerClanData == null) ? DateTime.Now : Singleton<PlayerDataManager>.Instance._playerClanData.FoundingDate;
		}
	}

	// Token: 0x170004F8 RID: 1272
	// (get) Token: 0x060014B1 RID: 5297 RVA: 0x0000DE00 File Offset: 0x0000C000
	public static string ClanOwnerName
	{
		get
		{
			return (Singleton<PlayerDataManager>.Instance._playerClanData == null) ? string.Empty : Singleton<PlayerDataManager>.Instance._playerClanData.OwnerName;
		}
	}

	// Token: 0x170004F9 RID: 1273
	// (get) Token: 0x060014B2 RID: 5298 RVA: 0x0000DE2A File Offset: 0x0000C02A
	public static int ClanMembersLimit
	{
		get
		{
			return (Singleton<PlayerDataManager>.Instance._playerClanData == null) ? 0 : Singleton<PlayerDataManager>.Instance._playerClanData.MembersLimit;
		}
	}

	// Token: 0x170004FA RID: 1274
	// (get) Token: 0x060014B3 RID: 5299 RVA: 0x0000DE50 File Offset: 0x0000C050
	public int ClanMembersCount
	{
		get
		{
			return (this._playerClanData == null) ? 0 : this._playerClanData.Members.Count;
		}
	}

	// Token: 0x170004FB RID: 1275
	// (get) Token: 0x060014B4 RID: 5300 RVA: 0x0000DE73 File Offset: 0x0000C073
	public List<ClanMemberView> ClanMembers
	{
		get
		{
			return (this._playerClanData == null) ? new List<ClanMemberView>(0) : this._playerClanData.Members;
		}
	}

	// Token: 0x170004FC RID: 1276
	// (get) Token: 0x060014B5 RID: 5301 RVA: 0x0000DE96 File Offset: 0x0000C096
	public static bool CanInviteToClan
	{
		get
		{
			return Singleton<PlayerDataManager>.Instance.RankInClan == GroupPosition.Leader || Singleton<PlayerDataManager>.Instance.RankInClan == GroupPosition.Officer;
		}
	}

	// Token: 0x060014B6 RID: 5302 RVA: 0x0000DEB7 File Offset: 0x0000C0B7
	public void AddFriend(PublicProfileView view)
	{
		this._friends[view.Cmid] = view;
	}

	// Token: 0x060014B7 RID: 5303 RVA: 0x0000DECB File Offset: 0x0000C0CB
	public void RemoveFriend(int friendCmid)
	{
		this._friends.Remove(friendCmid);
	}

	// Token: 0x060014B8 RID: 5304 RVA: 0x00075D30 File Offset: 0x00073F30
	public void SetLocalPlayerMemberView(MemberView memberView)
	{
		PlayerDataManager.Cmid = memberView.PublicProfile.Cmid;
		PlayerDataManager.AccessLevel = memberView.PublicProfile.AccessLevel;
		PlayerDataManager.Name = memberView.PublicProfile.Name;
		PlayerDataManager.Points = memberView.MemberWallet.Points;
		PlayerDataManager.Credits = memberView.MemberWallet.Credits;
	}

	// Token: 0x060014B9 RID: 5305 RVA: 0x0000DEDA File Offset: 0x0000C0DA
	public void SetPlayerStatisticsView(PlayerStatisticsView value)
	{
		if (value != null)
		{
			this._serverLocalPlayerPlayerStatisticsView = value;
			PlayerDataManager.PlayerExperience = value.Xp;
			PlayerDataManager.PlayerLevel = XpPointsUtil.GetLevelForXp(value.Xp);
		}
	}

	// Token: 0x060014BA RID: 5306 RVA: 0x00075D90 File Offset: 0x00073F90
	public void UpdatePlayerStats(StatsCollection stats, StatsCollection best)
	{
		PlayerStatisticsView serverLocalPlayerStatisticsView = this.ServerLocalPlayerStatisticsView;
		int xp = serverLocalPlayerStatisticsView.Xp + GameState.Current.Statistics.GainedXp;
		int levelForXp = XpPointsUtil.GetLevelForXp(xp);
		this.SetPlayerStatisticsView(new PlayerStatisticsView(serverLocalPlayerStatisticsView.Cmid, serverLocalPlayerStatisticsView.Splats + stats.GetKills(), serverLocalPlayerStatisticsView.Splatted + stats.Deaths, serverLocalPlayerStatisticsView.Shots + (long)stats.GetShots(), serverLocalPlayerStatisticsView.Hits + (long)stats.GetHits(), serverLocalPlayerStatisticsView.Headshots + stats.Headshots, serverLocalPlayerStatisticsView.Nutshots + stats.Nutshots, xp, levelForXp, new PlayerPersonalRecordStatisticsView((serverLocalPlayerStatisticsView.PersonalRecord.MostHeadshots <= best.Headshots) ? best.Headshots : serverLocalPlayerStatisticsView.PersonalRecord.MostHeadshots, (serverLocalPlayerStatisticsView.PersonalRecord.MostNutshots <= best.Nutshots) ? best.Nutshots : serverLocalPlayerStatisticsView.PersonalRecord.MostNutshots, (serverLocalPlayerStatisticsView.PersonalRecord.MostConsecutiveSnipes <= best.ConsecutiveSnipes) ? best.ConsecutiveSnipes : serverLocalPlayerStatisticsView.PersonalRecord.MostConsecutiveSnipes, 0, (serverLocalPlayerStatisticsView.PersonalRecord.MostSplats <= best.GetKills()) ? best.GetKills() : serverLocalPlayerStatisticsView.PersonalRecord.MostSplats, (serverLocalPlayerStatisticsView.PersonalRecord.MostDamageDealt <= best.GetDamageDealt()) ? best.GetDamageDealt() : serverLocalPlayerStatisticsView.PersonalRecord.MostDamageDealt, (serverLocalPlayerStatisticsView.PersonalRecord.MostDamageReceived <= best.DamageReceived) ? best.DamageReceived : serverLocalPlayerStatisticsView.PersonalRecord.MostDamageReceived, (serverLocalPlayerStatisticsView.PersonalRecord.MostArmorPickedUp <= best.ArmorPickedUp) ? best.ArmorPickedUp : serverLocalPlayerStatisticsView.PersonalRecord.MostArmorPickedUp, (serverLocalPlayerStatisticsView.PersonalRecord.MostHealthPickedUp <= best.HealthPickedUp) ? best.HealthPickedUp : serverLocalPlayerStatisticsView.PersonalRecord.MostHealthPickedUp, (serverLocalPlayerStatisticsView.PersonalRecord.MostMeleeSplats <= best.MeleeKills) ? best.MeleeKills : serverLocalPlayerStatisticsView.PersonalRecord.MostMeleeSplats, (serverLocalPlayerStatisticsView.PersonalRecord.MostMachinegunSplats <= best.MachineGunKills) ? best.MachineGunKills : serverLocalPlayerStatisticsView.PersonalRecord.MostMachinegunSplats, (serverLocalPlayerStatisticsView.PersonalRecord.MostShotgunSplats <= best.ShotgunSplats) ? best.ShotgunSplats : serverLocalPlayerStatisticsView.PersonalRecord.MostShotgunSplats, (serverLocalPlayerStatisticsView.PersonalRecord.MostSniperSplats <= best.SniperKills) ? best.SniperKills : serverLocalPlayerStatisticsView.PersonalRecord.MostSniperSplats, (serverLocalPlayerStatisticsView.PersonalRecord.MostSplattergunSplats <= best.SplattergunKills) ? best.SplattergunKills : serverLocalPlayerStatisticsView.PersonalRecord.MostSplattergunSplats, (serverLocalPlayerStatisticsView.PersonalRecord.MostCannonSplats <= best.CannonKills) ? best.CannonKills : serverLocalPlayerStatisticsView.PersonalRecord.MostCannonSplats, (serverLocalPlayerStatisticsView.PersonalRecord.MostLauncherSplats <= best.LauncherKills) ? best.LauncherKills : serverLocalPlayerStatisticsView.PersonalRecord.MostLauncherSplats), new PlayerWeaponStatisticsView(serverLocalPlayerStatisticsView.WeaponStatistics.MeleeTotalSplats + stats.MeleeKills, serverLocalPlayerStatisticsView.WeaponStatistics.MachineGunTotalSplats + stats.MachineGunKills, serverLocalPlayerStatisticsView.WeaponStatistics.ShotgunTotalSplats + stats.ShotgunSplats, serverLocalPlayerStatisticsView.WeaponStatistics.SniperTotalSplats + stats.SniperKills, serverLocalPlayerStatisticsView.WeaponStatistics.SplattergunTotalSplats + stats.SplattergunKills, serverLocalPlayerStatisticsView.WeaponStatistics.CannonTotalSplats + stats.CannonKills, serverLocalPlayerStatisticsView.WeaponStatistics.LauncherTotalSplats + stats.LauncherKills, serverLocalPlayerStatisticsView.WeaponStatistics.MeleeTotalShotsFired + stats.MeleeShotsFired, serverLocalPlayerStatisticsView.WeaponStatistics.MeleeTotalShotsHit + stats.MeleeShotsHit, serverLocalPlayerStatisticsView.WeaponStatistics.MeleeTotalDamageDone + stats.MeleeDamageDone, serverLocalPlayerStatisticsView.WeaponStatistics.MachineGunTotalShotsFired + stats.MachineGunShotsFired, serverLocalPlayerStatisticsView.WeaponStatistics.MachineGunTotalShotsHit + stats.MachineGunShotsHit, serverLocalPlayerStatisticsView.WeaponStatistics.MachineGunTotalDamageDone + stats.MachineGunDamageDone, serverLocalPlayerStatisticsView.WeaponStatistics.ShotgunTotalShotsFired + stats.ShotgunShotsFired, serverLocalPlayerStatisticsView.WeaponStatistics.ShotgunTotalShotsHit + stats.ShotgunShotsHit, serverLocalPlayerStatisticsView.WeaponStatistics.ShotgunTotalDamageDone + stats.ShotgunDamageDone, serverLocalPlayerStatisticsView.WeaponStatistics.SniperTotalShotsFired + stats.SniperShotsFired, serverLocalPlayerStatisticsView.WeaponStatistics.SniperTotalShotsHit + stats.SniperShotsHit, serverLocalPlayerStatisticsView.WeaponStatistics.SniperTotalDamageDone + stats.SniperDamageDone, serverLocalPlayerStatisticsView.WeaponStatistics.SplattergunTotalShotsFired + stats.SplattergunShotsFired, serverLocalPlayerStatisticsView.WeaponStatistics.SplattergunTotalShotsHit + stats.SplattergunShotsHit, serverLocalPlayerStatisticsView.WeaponStatistics.SplattergunTotalDamageDone + stats.SplattergunDamageDone, serverLocalPlayerStatisticsView.WeaponStatistics.CannonTotalShotsFired + stats.CannonShotsFired, serverLocalPlayerStatisticsView.WeaponStatistics.CannonTotalShotsHit + stats.CannonShotsHit, serverLocalPlayerStatisticsView.WeaponStatistics.CannonTotalDamageDone + stats.CannonDamageDone, serverLocalPlayerStatisticsView.WeaponStatistics.LauncherTotalShotsFired + stats.LauncherShotsFired, serverLocalPlayerStatisticsView.WeaponStatistics.LauncherTotalShotsHit + stats.LauncherShotsHit, serverLocalPlayerStatisticsView.WeaponStatistics.LauncherTotalDamageDone + stats.LauncherDamageDone)));
	}

	// Token: 0x060014BB RID: 5307 RVA: 0x00003C87 File Offset: 0x00001E87
	private void HandleWebServiceError()
	{
	}

	// Token: 0x060014BC RID: 5308 RVA: 0x0000DF04 File Offset: 0x0000C104
	public void SetSkinColor(Color skinColor)
	{
		this._localPlayerSkinColor = skinColor;
	}

	// Token: 0x060014BD RID: 5309 RVA: 0x000762BC File Offset: 0x000744BC
	private LoadoutView CreateLocalPlayerLoadoutView()
	{
		return new LoadoutView(0, 0, Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.GearBoots), PlayerDataManager.Cmid, Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.GearFace), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.FunctionalItem1), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.FunctionalItem2), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.FunctionalItem3), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.GearGloves), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.GearHead), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.GearLowerBody), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.WeaponMelee), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.QuickUseItem1), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.QuickUseItem2), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.QuickUseItem3), AvatarType.LutzRavinoff, Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.GearUpperBody), Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.WeaponPrimary), 0, 0, 0, Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.WeaponSecondary), 0, 0, 0, Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.WeaponTertiary), 0, 0, 0, Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.GearHolo), ColorConverter.ColorToHex(this._localPlayerSkinColor));
	}

	// Token: 0x060014BE RID: 5310 RVA: 0x000763B0 File Offset: 0x000745B0
	public IEnumerator StartGetMemberWallet()
	{
		if (PlayerDataManager.Cmid < 1)
		{
			Debug.LogError("Player CMID is invalid! Have you called AuthenticationManager.StartAuthenticateMember?");
			ApplicationDataManager.LockApplication("The authentication process failed. Please sign in on www.uberstrike.com and restart UberStrike.");
		}
		else
		{
			IPopupDialog popupDialog = PopupSystem.ShowMessage("Updating", "Updating your points and credits balance...", PopupSystem.AlertType.None);
			yield return UserWebServiceClient.GetMemberWallet(PlayerDataManager.AuthToken, new Action<MemberWalletView>(this.OnGetMemberWalletEventReturn), delegate(Exception ex)
			{
			});
			yield return new WaitForSeconds(0.5f);
			PopupSystem.HideMessage(popupDialog);
		}
		yield break;
	}

	// Token: 0x060014BF RID: 5311 RVA: 0x000763CC File Offset: 0x000745CC
	public IEnumerator StartSetLoadout()
	{
		if (this._updateLoadoutTime == 0f)
		{
			this._updateLoadoutTime = Time.time + 5f;
			while (this._updateLoadoutTime > Time.time)
			{
				yield return new WaitForEndOfFrame();
			}
			this._updateLoadoutTime = 0f;
			yield return UserWebServiceClient.SetLoadout(PlayerDataManager.AuthToken, this.CreateLocalPlayerLoadoutView(), delegate(MemberOperationResult ev)
			{
				if (Singleton<GameStateController>.Instance.Client.IsConnected)
				{
					Singleton<GameStateController>.Instance.Client.Operations.SendUpdateLoadout();
				}
				if (ev != MemberOperationResult.Ok)
				{
					Debug.LogError("SetLoadout failed with error=" + ev);
				}
			}, delegate(Exception ex)
			{
			});
		}
		else
		{
			this._updateLoadoutTime = Time.time + 5f;
		}
		yield break;
	}

	// Token: 0x060014C0 RID: 5312 RVA: 0x000763E8 File Offset: 0x000745E8
	public IEnumerator StartGetLoadout()
	{
		if (!Singleton<ItemManager>.Instance.ValidateItemMall())
		{
			PopupSystem.ShowMessage("Error Getting Shop Data", "The shop is empty, perhaps there\nwas an error getting the Shop data?", PopupSystem.AlertType.OK, new Action(this.HandleWebServiceError));
			yield break;
		}
		yield return UserWebServiceClient.GetLoadout(PlayerDataManager.AuthToken, delegate(LoadoutView ev)
		{
			if (ev != null)
			{
				this.CheckLoadoutForExpiredItems(ev);
				Singleton<LoadoutManager>.Instance.UpdateLoadout(ev);
				GameState.Current.Avatar.SetLoadout(new Loadout(Singleton<LoadoutManager>.Instance.Loadout));
				this._localPlayerSkinColor = ColorConverter.HexToColor(ev.SkinColor);
			}
			else
			{
				ApplicationDataManager.LockApplication("It seems that you account is corrupted. Please visit support.uberstrike.com for advice.");
			}
		}, delegate(Exception ex)
		{
			ApplicationDataManager.LockApplication("There was an error getting your loadout.");
		});
		yield break;
	}

	// Token: 0x060014C1 RID: 5313 RVA: 0x00076404 File Offset: 0x00074604
	public IEnumerator StartGetMember()
	{
		yield return UserWebServiceClient.GetMember(PlayerDataManager.AuthToken, new Action<UberstrikeUserViewModel>(this.OnGetMemberEventReturn), delegate(Exception ex)
		{
			ApplicationDataManager.LockApplication("There was an error getting your player data.");
		});
		yield break;
	}

	// Token: 0x060014C2 RID: 5314 RVA: 0x0000DF0D File Offset: 0x0000C10D
	private void OnGetMemberWalletEventReturn(MemberWalletView ev)
	{
		this.NotifyPointsAndCreditsChanges(ev.Points, ev.Credits);
		this.UpdateSecurePointsAndCredits(ev.Points, ev.Credits);
	}

	// Token: 0x060014C3 RID: 5315 RVA: 0x00076420 File Offset: 0x00074620
	private void OnGetMemberEventReturn(UberstrikeUserViewModel ev)
	{
		this.NotifyPointsAndCreditsChanges(ev.CmuneMemberView.MemberWallet.Points, ev.CmuneMemberView.MemberWallet.Credits);
		this.SetPlayerStatisticsView(ev.UberstrikeMemberView.PlayerStatisticsView);
		this.SetLocalPlayerMemberView(ev.CmuneMemberView);
	}

	// Token: 0x060014C4 RID: 5316 RVA: 0x0000DF33 File Offset: 0x0000C133
	private void NotifyPointsAndCreditsChanges(int newPoints, int newCredits)
	{
		if (newPoints != PlayerDataManager.Points)
		{
			GlobalUIRibbon.Instance.AddPointsEvent(newPoints - PlayerDataManager.Points);
		}
		if (newCredits != PlayerDataManager.Credits)
		{
			GlobalUIRibbon.Instance.AddCreditsEvent(newCredits - PlayerDataManager.Credits);
		}
	}

	// Token: 0x060014C5 RID: 5317 RVA: 0x0000DF6D File Offset: 0x0000C16D
	public bool ValidateMemberData()
	{
		return PlayerDataManager.Cmid > 0 && this._serverLocalPlayerPlayerStatisticsView.Cmid > 0;
	}

	// Token: 0x060014C6 RID: 5318 RVA: 0x0000DF8B File Offset: 0x0000C18B
	public void AttributeXp(int xp)
	{
		PlayerDataManager.PlayerExperience += xp;
		PlayerDataManager.PlayerLevel = XpPointsUtil.GetLevelForXp(PlayerDataManager.PlayerExperience);
		this._serverLocalPlayerPlayerStatisticsView.Xp = PlayerDataManager.PlayerExperience;
		this._serverLocalPlayerPlayerStatisticsView.Level = PlayerDataManager.PlayerLevel;
	}

	// Token: 0x060014C7 RID: 5319 RVA: 0x0000DFC8 File Offset: 0x0000C1C8
	public void UpdateSecurePointsAndCredits(int points, int credits)
	{
		PlayerDataManager.Points = points;
		PlayerDataManager.Credits = credits;
	}

	// Token: 0x060014C8 RID: 5320 RVA: 0x00076470 File Offset: 0x00074670
	public void CheckLoadoutForExpiredItems(LoadoutView view)
	{
		view = new LoadoutView(view.LoadoutId, (!this.IsExpired(view.Backpack, "Backpack")) ? view.Backpack : 0, (!this.IsExpired(view.Boots, "Boots")) ? view.Boots : 0, view.Cmid, (!this.IsExpired(view.Face, "Face")) ? view.Face : 0, (!this.IsExpired(view.FunctionalItem1, "FunctionalItem1")) ? view.FunctionalItem1 : 0, (!this.IsExpired(view.FunctionalItem2, "FunctionalItem2")) ? view.FunctionalItem2 : 0, (!this.IsExpired(view.FunctionalItem3, "FunctionalItem3")) ? view.FunctionalItem3 : 0, (!this.IsExpired(view.Gloves, "Gloves")) ? view.Gloves : 0, (!this.IsExpired(view.Head, "Head")) ? view.Head : 0, (!this.IsExpired(view.LowerBody, "LowerBody")) ? view.LowerBody : 0, (!this.IsExpired(view.MeleeWeapon, "MeleeWeapon")) ? view.MeleeWeapon : 0, (!this.IsExpired(view.QuickItem1, "QuickItem1")) ? view.QuickItem1 : 0, (!this.IsExpired(view.QuickItem2, "QuickItem2")) ? view.QuickItem2 : 0, (!this.IsExpired(view.QuickItem3, "QuickItem3")) ? view.QuickItem3 : 0, view.Type, (!this.IsExpired(view.UpperBody, "UpperBody")) ? view.UpperBody : 0, (!this.IsExpired(view.Weapon1, "Weapon1")) ? view.Weapon1 : 0, (!this.IsExpired(view.Weapon1Mod1, "Weapon1Mod1")) ? view.Weapon1Mod1 : 0, (!this.IsExpired(view.Weapon1Mod2, "Weapon1Mod2")) ? view.Weapon1Mod2 : 0, (!this.IsExpired(view.Weapon1Mod3, "Weapon1Mod3")) ? view.Weapon1Mod3 : 0, (!this.IsExpired(view.Weapon2, "Weapon2")) ? view.Weapon2 : 0, (!this.IsExpired(view.Weapon2Mod1, "Weapon2Mod1")) ? view.Weapon2Mod1 : 0, (!this.IsExpired(view.Weapon2Mod2, "Weapon2Mod2")) ? view.Weapon2Mod2 : 0, (!this.IsExpired(view.Weapon2Mod3, "Weapon2Mod3")) ? view.Weapon2Mod3 : 0, (!this.IsExpired(view.Weapon3, "Weapon3")) ? view.Weapon3 : 0, (!this.IsExpired(view.Weapon3Mod1, "Weapon3Mod1")) ? view.Weapon3Mod1 : 0, (!this.IsExpired(view.Weapon3Mod2, "Weapon3Mod2")) ? view.Weapon3Mod2 : 0, (!this.IsExpired(view.Weapon3Mod3, "Weapon3Mod3")) ? view.Weapon3Mod3 : 0, (!this.IsExpired(view.Webbing, "Webbing")) ? view.Webbing : 0, view.SkinColor);
	}

	// Token: 0x060014C9 RID: 5321 RVA: 0x0000DFD6 File Offset: 0x0000C1D6
	private bool IsExpired(int itemId, string debug)
	{
		return !Singleton<InventoryManager>.Instance.Contains(itemId);
	}

	// Token: 0x060014CA RID: 5322 RVA: 0x0000DFE6 File Offset: 0x0000C1E6
	public static bool IsClanMember(int cmid)
	{
		return Singleton<PlayerDataManager>.Instance._clanMembers.ContainsKey(cmid);
	}

	// Token: 0x060014CB RID: 5323 RVA: 0x0000DFF8 File Offset: 0x0000C1F8
	public static bool IsFriend(int cmid)
	{
		return Singleton<PlayerDataManager>.Instance._friends.ContainsKey(cmid);
	}

	// Token: 0x060014CC RID: 5324 RVA: 0x0000E00A File Offset: 0x0000C20A
	public static bool IsFacebookFriend(int cmid)
	{
		return Singleton<PlayerDataManager>.Instance._facebookFriends.ContainsKey(cmid);
	}

	// Token: 0x060014CD RID: 5325 RVA: 0x0000E01C File Offset: 0x0000C21C
	public static bool TryGetFriend(int cmid, out PublicProfileView view)
	{
		return Singleton<PlayerDataManager>.Instance._friends.TryGetValue(cmid, out view) && view != null;
	}

	// Token: 0x060014CE RID: 5326 RVA: 0x0000E03F File Offset: 0x0000C23F
	public static bool TryGetClanMember(int cmid, out ClanMemberView view)
	{
		return Singleton<PlayerDataManager>.Instance._clanMembers.TryGetValue(cmid, out view) && view != null;
	}

	// Token: 0x170004FD RID: 1277
	// (get) Token: 0x060014CF RID: 5327 RVA: 0x0000E062 File Offset: 0x0000C262
	public static string NameAndTag
	{
		get
		{
			return (!PlayerDataManager.IsPlayerInClan) ? PlayerDataManager.Name : string.Format("[{0}] {1}", PlayerDataManager.ClanTag, PlayerDataManager.Name);
		}
	}

	// Token: 0x040013AD RID: 5037
	private PlayerStatisticsView _serverLocalPlayerPlayerStatisticsView;

	// Token: 0x040013AE RID: 5038
	private Dictionary<int, PublicProfileView> _friends = new Dictionary<int, PublicProfileView>();

	// Token: 0x040013AF RID: 5039
	private Dictionary<int, PublicProfileView> _facebookFriends = new Dictionary<int, PublicProfileView>();

	// Token: 0x040013B0 RID: 5040
	private Dictionary<int, ClanMemberView> _clanMembers = new Dictionary<int, ClanMemberView>();

	// Token: 0x040013B1 RID: 5041
	private Color _localPlayerSkinColor = Color.white;

	// Token: 0x040013B2 RID: 5042
	private ClanView _playerClanData;

	// Token: 0x040013B3 RID: 5043
	private float _updateLoadoutTime;
}
