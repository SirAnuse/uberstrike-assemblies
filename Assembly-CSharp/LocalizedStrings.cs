using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000296 RID: 662
public static class LocalizedStrings
{
	// Token: 0x06001229 RID: 4649
	static LocalizedStrings()
	{   
		LocalizedStrings.NDaysLeft = " {0} Days left";
		LocalizedStrings.LevelRequired = "Level Required: ";
		LocalizedStrings.CriticalHitBonus = "Critical Hit Bonus: ";
		LocalizedStrings.Instant = "instant";
		LocalizedStrings.Unlimited = "unlimited";
		LocalizedStrings.HealthColon = "Health: ";
		LocalizedStrings.AmmoColon = "Ammo: ";
		LocalizedStrings.ArmorColon = "Armor: ";
		LocalizedStrings.DamageColon = "Damage: ";
		LocalizedStrings.RadiusColon = "Radius: ";
		LocalizedStrings.ForceColon = "Force: ";
		LocalizedStrings.LifetimeColon = "Lifetime: ";
		LocalizedStrings.WarmupColon = "Warm-up: ";
		LocalizedStrings.CooldownColon = "Cooldown: ";
		LocalizedStrings.UsesPerLifeColon = "Uses per Life: ";
		LocalizedStrings.UsesPerGameColon = "Uses per Game: ";
		LocalizedStrings.TimeColon = "Time: ";
		LocalizedStrings.Help = "Help";
		LocalizedStrings.Otions = "Options";
		LocalizedStrings.Audio = "Audio";
		LocalizedStrings.Windowed = "Windowed";
		LocalizedStrings.FullscreenOnly = "fullscreen only";
		LocalizedStrings.Custom = "Custom";
		LocalizedStrings.ChangingScreenResolution = "Changing Screen Resolution...";
		LocalizedStrings.ChooseNewResolution = "Do you want to choose new resolution: ";
		LocalizedStrings.Auto = "Auto";
		LocalizedStrings.TargetFramerate = "Target Framerate:";
		LocalizedStrings.MaxQueuedFrames = "Max Queued Frames:";
		LocalizedStrings.SettingsTakeEffectAfterReloading = "This setting will take effect after reloading";
		LocalizedStrings.TextureQuality = "Texture Quality:";
		LocalizedStrings.VSync = "VSync:";
		LocalizedStrings.AntiAliasing = "Anti Aliasing:";
		LocalizedStrings.Options = "Options";
		LocalizedStrings.MysteryBox = "Mystery Box";
		LocalizedStrings.Packs = "Packs";
		LocalizedStrings.TransferCaps = "TRANSFER";
		LocalizedStrings.PromoteCaps = "PROMOTE";
		LocalizedStrings.DemoteCaps = "DEMOTE";
		LocalizedStrings.DisbandCaps = "DISBAND";
		LocalizedStrings.YourClan = "Your Clan";
		LocalizedStrings.ExploreMaps = "Explore Maps";
		LocalizedStrings.MobileGameMoreThan8Players = "Warning! UberStrike on iOS is optimized for games with 8 players or less. Your game may run slowly.";
		LocalizedStrings.HereYouCanCreateYourOwnClanFacebook = "Here you can create your own clan. This will create a group for your clan in Facebook";
		LocalizedStrings.TOTAL = "TOTAL";
		LocalizedStrings.Boost = "Boost";
		LocalizedStrings.SkillBonus = "Skill Bonus";
		LocalizedStrings.SharePhotoFacebook = "Press {0} to share screenshots";
		LocalizedStrings.SharePhotoIPad = "Share your avatar to Facebook";
		LocalizedStrings.ScreenshotTaken = "Added to 'UberStrike Photos' album";
	}

	// Token: 0x0600122A RID: 4650
	public static void UpdateLocalization(LocaleType type)
	{
		TextAsset textAsset = Resources.Load("strings." + type, typeof(TextAsset)) as TextAsset;
		if (textAsset != null)
		{
			XmlReaderSettings settings = new XmlReaderSettings
			{
				IgnoreComments = true,
				IgnoreWhitespace = true
			};
			Dictionary<string, string> allStrings = LocalizedStrings.GetAllStrings(XmlReader.Create(new StringReader(textAsset.text), settings));
			foreach (FieldInfo fieldInfo in typeof(LocalizedStrings).GetFields(BindingFlags.Static | BindingFlags.Public))
			{
				string value;
				if (allStrings.TryGetValue(fieldInfo.Name, out value))
				{
					fieldInfo.SetValue(null, value);
				}
			}
		}
	}

	// Token: 0x0600122B RID: 4651
	private static Dictionary<string, string> GetAllStrings(XmlReader reader)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		if (reader != null)
		{
			try
			{
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals("data"))
					{
						string attribute = reader.GetAttribute("name");
						string value = string.Empty;
						if (reader.Read() && reader.Read())
						{
							value = reader.ReadString();
						}
						dictionary[attribute] = value;
					}
				}
			}
			finally
			{
				reader.Close();
			}
		}
		return dictionary;
	}

	// Token: 0x04000F0D RID: 3853
	public static string Login = "Login";

	// Token: 0x04000F0E RID: 3854
	public static string Logout = "Logout";

	// Token: 0x04000F0F RID: 3855
	public static string LogoutCaps = "LOGOUT";

	// Token: 0x04000F10 RID: 3856
	public static string EmailAddress = "Email Address";

	// Token: 0x04000F11 RID: 3857
	public static string Password = "Password";

	// Token: 0x04000F12 RID: 3858
	public static string RememberMe = "Remember Me";

	// Token: 0x04000F13 RID: 3859
	public static string ForgotPassword = "Forgot Password?";

	// Token: 0x04000F14 RID: 3860
	public static string Quit = "Quit";

	// Token: 0x04000F15 RID: 3861
	public static string OkCaps = "OK";

	// Token: 0x04000F16 RID: 3862
	public static string ChangeTeam = "Change Team";

	// Token: 0x04000F17 RID: 3863
	public static string Continue = "Continue";

	// Token: 0x04000F18 RID: 3864
	public static string DeathMatch = "Deathmatch";

	// Token: 0x04000F19 RID: 3865
	public static string Fullscreen = "Fullscreen";

	// Token: 0x04000F1A RID: 3866
	public static string Headshot = "Headshot!";

	// Token: 0x04000F1B RID: 3867
	public static string KillsRemain = "Kills Remain";

	// Token: 0x04000F1C RID: 3868
	public static string Nutshot = "Nutshot!";

	// Token: 0x04000F1D RID: 3869
	public static string Respawn = "Respawn";

	// Token: 0x04000F1E RID: 3870
	public static string ShowMenu = "Show Menu";

	// Token: 0x04000F1F RID: 3871
	public static string SignUp = "Create new account";

	// Token: 0x04000F20 RID: 3872
	public static string TeamDeathMatch = "Team Deathmatch";

	// Token: 0x04000F21 RID: 3873
	public static string TeamElimination = "Team Elimination";

	// Token: 0x04000F22 RID: 3874
	public static string YouDied = "You Died!";

	// Token: 0x04000F23 RID: 3875
	public static string Absorption = "Absorption";

	// Token: 0x04000F24 RID: 3876
	public static string Accept = "Accept";

	// Token: 0x04000F25 RID: 3877
	public static string AcceptingClanInvitation = "Accepting clan invitation...";

	// Token: 0x04000F26 RID: 3878
	public static string AccountExistsMsg = "This account already has a UberStrike account associated with it.";

	// Token: 0x04000F27 RID: 3879
	public static string AccountIsInvalid = "Account is invalid.";

	// Token: 0x04000F28 RID: 3880
	public static string Accuracy = "Accuracy";

	// Token: 0x04000F29 RID: 3881
	public static string AddFriends = "Add Friends";

	// Token: 0x04000F2A RID: 3882
	public static string AdvancedCaps = "ADVANCED";

	// Token: 0x04000F2B RID: 3883
	public static string AdvancedWater = "Advanced Water";

	// Token: 0x04000F2C RID: 3884
	public static string ALeaderCannotLeaveHisOwnClanMsg = "A leader cannot leave his own clan.\nYou can only disband it.";

	// Token: 0x04000F2D RID: 3885
	public static string All = "All";

	// Token: 0x04000F2E RID: 3886
	public static string AreYouSureQuitMsg = "Are you sure you want to quit Uberstrike?";

	// Token: 0x04000F2F RID: 3887
	public static string AreYouSureLogoutMsg = "Are you sure you want to logout of Uberstrike?";

	// Token: 0x04000F30 RID: 3888
	public static string AuthenticatingAccount = "Authenticating Account";

	// Token: 0x04000F31 RID: 3889
	public static string BackCaps = "BACK";

	// Token: 0x04000F32 RID: 3890
	public static string BangYouJustReachedLevelN = "Bang! You just reached";

	// Token: 0x04000F33 RID: 3891
	public static string BestWeaponByAccuracy = "Best Weapon by Accuracy";

	// Token: 0x04000F34 RID: 3892
	public static string BestWeaponByDamageDealt = "Best Weapon by Damage Dealt";

	// Token: 0x04000F35 RID: 3893
	public static string BestWeaponByHits = "Best Weapon by Hits";

	// Token: 0x04000F36 RID: 3894
	public static string BestWeaponByKills = "Best Weapon by Kills";

	// Token: 0x04000F37 RID: 3895
	public static string BetweenYouAndN = "Between You and {0}";

	// Token: 0x04000F38 RID: 3896
	public static string BloomEffect = "Bloom Effect";

	// Token: 0x04000F39 RID: 3897
	public static string Blue = "Blue";

	// Token: 0x04000F3A RID: 3898
	public static string Boots = "Boots";

	// Token: 0x04000F3B RID: 3899
	public static string BothTeamsHadAndEqualNumberOfKills = "Both teams had an equal number of kills at match end.";

	// Token: 0x04000F3C RID: 3900
	public static string BothTeamsHadAndEqualNumberOfWins = "Both teams had an equal number of wins at match end.";

	// Token: 0x04000F3D RID: 3901
	public static string Bounty = "Bounty";

	// Token: 0x04000F3E RID: 3902
	public static string Busy = "Busy";

	// Token: 0x04000F3F RID: 3903
	public static string Buy = "Buy";

	// Token: 0x04000F40 RID: 3904
	public static string BuyAClanLicense = "- Buy a clan license in the Shop";

	// Token: 0x04000F41 RID: 3905
	public static string BuyCaps = "BUY";

	// Token: 0x04000F42 RID: 3906
	public static string BuyItem = "Buy Item";

	// Token: 0x04000F43 RID: 3907
	public static string Cancel = "Cancel";

	// Token: 0x04000F44 RID: 3908
	public static string CancelCaps = "CANCEL";

	// Token: 0x04000F45 RID: 3909
	public static string CancelingInvitation = "Canceling invitation...";

	// Token: 0x04000F46 RID: 3910
	public static string CancelingInvitationErrorMsg = "There has been an error canceling the invitation to {0}.";

	// Token: 0x04000F47 RID: 3911
	public static string CancelInvite = "Cancel Invite";

	// Token: 0x04000F48 RID: 3912
	public static string CancelInviteConfirmation = "Cancel Invite Confirmation";

	// Token: 0x04000F49 RID: 3913
	public static string CancelInviteToN = "Cancel invite to {0}?";

	// Token: 0x04000F4A RID: 3914
	public static string CancelInviteWarningMsg = "This will cancel the clan invitation to {0}.";

	// Token: 0x04000F4B RID: 3915
	public static string Cannons = "Cannons";

	// Token: 0x04000F4C RID: 3916
	public static string CannotFindPlayerData = "Cannot find any data for that player.";

	// Token: 0x04000F4D RID: 3917
	public static string Capacity = "Capacity";

	// Token: 0x04000F4E RID: 3918
	public static string CapacityDesc = "This refers to the amount of players that are currently playing on this game server.";

	// Token: 0x04000F4F RID: 3919
	public static string ChangePosition = "Change Position";

	// Token: 0x04000F50 RID: 3920
	public static string ChangeServer = "Change Server";

	// Token: 0x04000F51 RID: 3921
	public static string ChangingToTeamN = "Changing to team {0}";

	// Token: 0x04000F52 RID: 3922
	public static string ChatBtnTooltip = "Chat with friends and join their games.";

	// Token: 0x04000F53 RID: 3923
	public static string ChatCaps = "CHAT";

	// Token: 0x04000F54 RID: 3924
	public static string CheatingWillResultInAPermanentBan = "Cheating will result in a permanent ban!";

	// Token: 0x04000F55 RID: 3925
	public static string CheckAvailability = "Check Availability";

	// Token: 0x04000F56 RID: 3926
	public static string CheckingAvailableGameServers = "Checking available game servers...";

	// Token: 0x04000F57 RID: 3927
	public static string CheckingClanStatus = "Checking clan status...";

	// Token: 0x04000F58 RID: 3928
	public static string CheckMail = "Check Mail";

	// Token: 0x04000F59 RID: 3929
	public static string ChooseAGameCaps = "CHOOSE A GAME";

	// Token: 0x04000F5A RID: 3930
	public static string ChooseAMap = "Choose a Map";

	// Token: 0x04000F5B RID: 3931
	public static string ChooseCharacterName = "CHOOSE YOUR NAME";

	// Token: 0x04000F5C RID: 3932
	public static string ChooseYourRegionCaps = "CHOOSE YOUR REGION";

	// Token: 0x04000F5D RID: 3933
	public static string ClanAlreadyHasPendingRequestMsg = "This clan already has a pending request from you.\nYou cannot send another one.";

	// Token: 0x04000F5E RID: 3934
	public static string ClanBtnTooltip = "Create or manage a clan.";

	// Token: 0x04000F5F RID: 3935
	public static string ClanCreateSuccessMsg = "Congratulations! You have successfully created the {0} clan.\nInvite some members to join and sign up for clan wars on the forums!";

	// Token: 0x04000F60 RID: 3936
	public static string ClanDataNotFoundMsg = "Cannot find any data for that clan.\nEither an error has occurred or it has just disbanded.";

	// Token: 0x04000F61 RID: 3937
	public static string ClanDescriptionInvalidCharsMsg = "The description you have chosen contains\ninvalid characters(probably the weird ones).\nPlease specify a different one.";

	// Token: 0x04000F62 RID: 3938
	public static string ClanDescriptionRestrictedWordsMsg = "The description you have chosen contains restricted words.\nPlease specify a different one.";

	// Token: 0x04000F63 RID: 3939
	public static string ClanFullMsg = "This clan is full. You cannot request membership\nto a clan that is full.";

	// Token: 0x04000F64 RID: 3940
	public static string ClanHQCaps = "CLAN HQ";

	// Token: 0x04000F65 RID: 3941
	public static string ClanInvitationDeletedMsg = "This invitation no longer exists.\nIt may have expired or been withdrawn.";

	// Token: 0x04000F66 RID: 3942
	public static string ClanMottoInvalidMsg = "The motto you have chosen contains\ninvalid characters (probably the weird ones).\nPlease specify a different one.";

	// Token: 0x04000F67 RID: 3943
	public static string ClanMottoRestrictedWordsMsg = "The motto you have chosen contains restricted words.\nPlease specify a different one.";

	// Token: 0x04000F68 RID: 3944
	public static string ClanNameInUseMsg = "This clan name is already in use.\nPlease choose a different one.";

	// Token: 0x04000F69 RID: 3945
	public static string ClanNameInvlidMsg = "The name you have chosen contains non-alphanumeric characters.\nPlease specify a different one.";

	// Token: 0x04000F6A RID: 3946
	public static string ClanNameRestrictedWordsMsg = "The name you have chosen contains restricted words.\nPlease specify a different one.";

	// Token: 0x04000F6B RID: 3947
	public static string ClanNCreatedCaps = "CLAN {0} CREATED";

	// Token: 0x04000F6C RID: 3948
	public static string ClanRequestsYouHAveNPendingRequests = "Clan Requests - You have {0} pending clan request{1}";

	// Token: 0x04000F6D RID: 3949
	public static string Clans = "Clans";

	// Token: 0x04000F6E RID: 3950
	public static string ClansCaps = "CLANS";

	// Token: 0x04000F6F RID: 3951
	public static string ClanStatusErrorMsg = "Error checking player clan status.\nPlease try again in a moment.";

	// Token: 0x04000F70 RID: 3952
	public static string ClanTagInUseMsg = "This clan tag is already in use.\nPlease choose a different one.";

	// Token: 0x04000F71 RID: 3953
	public static string ClanTagInvalidMsg = "This clan tag contains non-alphanumeric characters.\nPlease specify a different one.";

	// Token: 0x04000F72 RID: 3954
	public static string ClanTagRestrictedWordsMsg = "The tag you have chosen contains restricted words.\nPlease specify a different one.";

	// Token: 0x04000F73 RID: 3955
	public static string ClickHereBuyCreditsMsg = "Click Here to buy UberStrike Credits!";

	// Token: 0x04000F74 RID: 3956
	public static string ColorCorrection = "Color Correction";

	// Token: 0x04000F75 RID: 3957
	public static string ComeBackTomorrowForEvenMorePoints = "Come back tomorrow for even more points!";

	// Token: 0x04000F76 RID: 3958
	public static string CongratulationsGrantedLicenseMsg = "Congratulations, you have just been granted the privateers license!\n\nLet's have some fun!";

	// Token: 0x04000F77 RID: 3959
	public static string ConnectingToLobby = "Connecting to Lobby...";

	// Token: 0x04000F78 RID: 3960
	public static string ConnectingToServer = "Connecting to server.";

	// Token: 0x04000F79 RID: 3961
	public static string ConnectionSlowMsg = "Your connection to this server is slow. Your game performance may be sub-optimal.";

	// Token: 0x04000F7A RID: 3962
	public static string CreateAClan = "Create a Clan";

	// Token: 0x04000F7B RID: 3963
	public static string CreateAClanAndInviteYourFriends = "Create a clan and invite your friends to join!";

	// Token: 0x04000F7C RID: 3964
	public static string CreateAClanCaps = "CREATE A CLAN";

	// Token: 0x04000F7D RID: 3965
	public static string CreateCaps = "CREATE";

	// Token: 0x04000F7E RID: 3966
	public static string CreatedN = "Created: {0}";

	// Token: 0x04000F7F RID: 3967
	public static string CreateGameCaps = "CREATE GAME";

	// Token: 0x04000F80 RID: 3968
	public static string CreateYourCharacterCaps = "CREATE YOUR CHARACTER";

	// Token: 0x04000F81 RID: 3969
	public static string CreatingAccount = "Creating Account...";

	// Token: 0x04000F82 RID: 3970
	public static string CreatingAccountMsg = "Creating your account.\nPlease wait a moment.";

	// Token: 0x04000F83 RID: 3971
	public static string Credits = "Credits";

	// Token: 0x04000F84 RID: 3972
	public static string CurrentXP = "Current XP:";

	// Token: 0x04000F85 RID: 3973
	public static string DailyRewardCaps = "DAILY REWARD";

	// Token: 0x04000F86 RID: 3974
	public static string Damage = "Damage";

	// Token: 0x04000F87 RID: 3975
	public static string DamageXP = "DAMAGE XP";

	// Token: 0x04000F88 RID: 3976
	public static string DataError = "Data Error";

	// Token: 0x04000F89 RID: 3977
	public static string DataInvalidMsg = "That data is extremely invalid. It's so invalid that it has caused this error.";

	// Token: 0x04000F8A RID: 3978
	public static string Day = "Day";

	// Token: 0x04000F8B RID: 3979
	public static string DaysAgo = "Days Ago";

	// Token: 0x04000F8C RID: 3980
	public static string DeathsCaps = "DEATHS";

	// Token: 0x04000F8D RID: 3981
	public static string Deaths = "Deaths";

	// Token: 0x04000F8E RID: 3982
	public static string DeleteThreadCaps = "DELETE THREAD";

	// Token: 0x04000F8F RID: 3983
	public static string DemoteMember = "Demote Member";

	// Token: 0x04000F90 RID: 3984
	public static string DisbandClan = "Disband Clan";

	// Token: 0x04000F91 RID: 3985
	public static string DisbandClanCaps = "DISBAND CLAN";

	// Token: 0x04000F92 RID: 3986
	public static string DisbandClanErrorMsg = "There has been an error processing your request to disband clan {0}.\nPlease try again in a moment.";

	// Token: 0x04000F93 RID: 3987
	public static string DisbandClanN = "Disband clan {0}?";

	// Token: 0x04000F94 RID: 3988
	public static string DisbandClanSuccessMsg = "Clan {0} has been disbanded.";

	// Token: 0x04000F95 RID: 3989
	public static string DisbandClanWarningMsg = "Disbanding your clan will completely remove all clan information from the\nUberStrike database. After disbanding, the clan will no longer exist.";

	// Token: 0x04000F96 RID: 3990
	public static string DiscardCaps = "DISCARD";

	// Token: 0x04000F97 RID: 3991
	public static string Done = "Done";

	// Token: 0x04000F98 RID: 3992
	public static string DownloadClanRequestErrorMsg = "Error downloading clan request data. Please try again in a moment.";

	// Token: 0x04000F99 RID: 3993
	public static string DownloadingClanData = "Downloading clan data...";

	// Token: 0x04000F9A RID: 3994
	public static string DownloadingClanDataErrorMsg = "Error downloading clan data.\nPlease try again in a moment.";

	// Token: 0x04000F9B RID: 3995
	public static string DownloadingRequestData = "Downloading request data...";

	// Token: 0x04000F9C RID: 3996
	public static string DoYouReallyWantToRemoveNFromYourFriendsList = "Do you really want to remove {0} from your friends list?";

	// Token: 0x04000F9D RID: 3997
	public static string DoYouWantToDeleteTheConversation = "Do you want to delete the conversation?";

	// Token: 0x04000F9E RID: 3998
	public static string DragToEquipTheN = "Drag to equip the {0}";

	// Token: 0x04000F9F RID: 3999
	public static string Draw = "Draw!";

	// Token: 0x04000FA0 RID: 4000
	public static string Duration = "Duration";

	// Token: 0x04000FA1 RID: 4001
	public static string EffectsVolume = "Effects Volume:";

	// Token: 0x04000FA2 RID: 4002
	public static string Email = "Email";

	// Token: 0x04000FA3 RID: 4003
	public static string EmailAddressAndNameInUseMsg = "By some miracle coincidence, both the email address AND the name you've chosen are in use. You'll have to choose different ones.";

	// Token: 0x04000FA4 RID: 4004
	public static string EmailAddressInUseMsg = "This email address is already in use. Please use another email address.";

	// Token: 0x04000FA5 RID: 4005
	public static string EmailAddressIsInvalid = "Email address is invalid.";

	// Token: 0x04000FA6 RID: 4006
	public static string EmailInvalidMsg = "That email address is invalid. Either you typed it wrong or you're an evil hacker trying to fool our system!";

	// Token: 0x04000FA7 RID: 4007
	public static string Empty = "Empty";

	// Token: 0x04000FA8 RID: 4008
	public static string EnableCustomizers = "Enable Customizers";

	// Token: 0x04000FA9 RID: 4009
	public static string EnableGamepad = "Enable Gamepad";

	// Token: 0x04000FAA RID: 4010
	public static string EnterGameName = "Enter game name";

	// Token: 0x04000FAB RID: 4011
	public static string EnterPassword = "Enter Password";

	// Token: 0x04000FAC RID: 4012
	public static string EnterYourEmailAddress = "Enter Your Email Address";

	// Token: 0x04000FAD RID: 4013
	public static string EnterYourName = "Enter Your Name";

	// Token: 0x04000FAE RID: 4014
	public static string EnterYourPassword = "Enter Your Password";

	// Token: 0x04000FAF RID: 4015
	public static string Equip = "Equip";

	// Token: 0x04000FB0 RID: 4016
	public static string Unequip = "Unequip";

	// Token: 0x04000FB1 RID: 4017
	public static string Error = "Error";

	// Token: 0x04000FB2 RID: 4018
	public static string ErrorCreatingClan = "Error creating clan.\nPlease try again later.";

	// Token: 0x04000FB3 RID: 4019
	public static string ErrorInvitingNToJoinClanN = "Error inviting {0} to join clan {1}.\nPlease try again in a moment.";

	// Token: 0x04000FB4 RID: 4020
	public static string ErrorInvitingToJoinClanN = "There was an error inviting the player to clan {0}.";

	// Token: 0x04000FB5 RID: 4021
	public static string ErrorSendingMessage = "Error sending message, Please try again later...";

	// Token: 0x04000FB6 RID: 4022
	public static string ExitFullscreen = "Exit fullscreen.";

	// Token: 0x04000FB7 RID: 4023
	public static string Expired = "Expired";

	// Token: 0x04000FB8 RID: 4024
	public static string Face = "Face";

	// Token: 0x04000FB9 RID: 4025
	public static string FailedToGetContacts = "Failed to get contacts";

	// Token: 0x04000FBA RID: 4026
	public static string FailedToRegister = "Failed to register";

	// Token: 0x04000FBB RID: 4027
	public static string FailedToRemoveNFromYourFriendList = "Failed to remove {0} from your friend list!";

	// Token: 0x04000FBC RID: 4028
	public static string FailedToSendYourMessage = "Failed to send your message!";

	// Token: 0x04000FBD RID: 4029
	public static string FastCaps = "FAST";

	// Token: 0x04000FBE RID: 4030
	public static string FiltersCaps = "FILTERS";

	// Token: 0x04000FBF RID: 4031
	public static string FrameRate = "Frame Rate";

	// Token: 0x04000FC0 RID: 4032
	public static string LowGravity = "Low gravity";

	// Token: 0x04000FC1 RID: 4033
	public static string Instakill = "Instakill";

	// Token: 0x04000FC2 RID: 4034
	public static string NinjaArena = "Ninja Arena";

	// Token: 0x04000FC3 RID: 4035
	public static string SniperArena = "Sniper Arena";

	// Token: 0x04000FC4 RID: 4036
	public static string CannonArena = "Cannon Arena";

	// Token: 0x04000FC5 RID: 4037
	public static string FriendRequest = "Friend Request";

	// Token: 0x04000FC6 RID: 4038
	public static string FriendRequestCaps = "FRIEND REQUEST";

	// Token: 0x04000FC7 RID: 4039
	public static string FriendRequestsYouHaveNPendingRequests = "Friend Requests - You have {0} pending friend request{1}";

	// Token: 0x04000FC8 RID: 4040
	public static string FriendsCaps = "FRIENDS";

	// Token: 0x04000FC9 RID: 4041
	public static string Full = "Full";

	// Token: 0x04000FCA RID: 4042
	public static string FunctionalItem = "Functional Item";

	// Token: 0x04000FCB RID: 4043
	public static string FunctionalItems = "Functional Items";

	// Token: 0x04000FCC RID: 4044
	public static string Game = "Game";

	// Token: 0x04000FCD RID: 4045
	public static string GameName = "Game Name";

	// Token: 0x04000FCE RID: 4046
	public static string GameNotFull = "Game not full";

	// Token: 0x04000FCF RID: 4047
	public static string Gamepad = "Gamepad";

	// Token: 0x04000FD0 RID: 4048
	public static string Games = "Games";

	// Token: 0x04000FD1 RID: 4049
	public static string GamesNotFound = "Games not found.";

	// Token: 0x04000FD2 RID: 4050
	public static string GameType = "Game Type";

	// Token: 0x04000FD3 RID: 4051
	public static string Gear = "Gear";

	// Token: 0x04000FD4 RID: 4052
	public static string GeneralCaps = "GENERAL";

	// Token: 0x04000FD5 RID: 4053
	public static string BuyCreditsCaps = "GET CREDITS!";

	// Token: 0x04000FD6 RID: 4054
	public static string GettingClan = "Getting player clan data...";

	// Token: 0x04000FD7 RID: 4055
	public static string GettingInventory = "Getting player inventory...";

	// Token: 0x04000FD8 RID: 4056
	public static string GettingLabsData = "Getting labs data...";

	// Token: 0x04000FD9 RID: 4057
	public static string GettingLoadout = "Getting player loadout...";

	// Token: 0x04000FDA RID: 4058
	public static string GettingStats = "Getting player statistics...";

	// Token: 0x04000FDB RID: 4059
	public static string Gloves = "Gloves";

	// Token: 0x04000FDC RID: 4060
	public static string GoCaps = "GO!";

	// Token: 0x04000FDD RID: 4061
	public static string GoFullscreen = "Go fullscreen.";

	// Token: 0x04000FDE RID: 4062
	public static string HardcoreMode = "Hardcore Mode";

	// Token: 0x04000FDF RID: 4063
	public static string HaveAtLeastOneFriend = "- Have at least 1 friend";

	// Token: 0x04000FE0 RID: 4064
	public static string Head = "Head";

	// Token: 0x04000FE1 RID: 4065
	public static string HeadshotXP = "HEADSHOT XP";

	// Token: 0x04000FE2 RID: 4066
	public static string ShowPostProcessingEffects = "Enable Post Processing Effects";

	// Token: 0x04000FE3 RID: 4067
	public static string HelpBtnTooltip = "Learn how to really play the game.";

	// Token: 0x04000FE4 RID: 4068
	public static string HelpCaps = "HELP";

	// Token: 0x04000FE5 RID: 4069
	public static string HereYouCanCreateYourOwnClan = "Here you can create your own clan.";

	// Token: 0x04000FE6 RID: 4070
	public static string HiYoureInvitedToJoinMyClanN = "Hi, you're invited to join my clan, {0}.";

	// Token: 0x04000FE7 RID: 4071
	public static string Holo = "Holo";

	// Token: 0x04000FE8 RID: 4072
	public static string HomeBtnTooltip = "Back to the blimp.";

	// Token: 0x04000FE9 RID: 4073
	public static string HomeCaps = "HOME";

	// Token: 0x04000FEA RID: 4074
	public static string IAgreeToThe = "By clicking OK you agree to the";

	// Token: 0x04000FEB RID: 4075
	public static string IfTheErrorPersistsBugReportTaskbar = "If the error persists, please use\nthe bug reporting feature on the taskbar.";

	// Token: 0x04000FEC RID: 4076
	public static string Ignore = "Ignore";

	// Token: 0x04000FED RID: 4077
	public static string IgnoringClanInvitation = "Ignoring clan invitation...";

	// Token: 0x04000FEE RID: 4078
	public static string Impact = "Impact";

	// Token: 0x04000FEF RID: 4079
	public static string InboxBtnTooltip = "Receive messages from your friends.";

	// Token: 0x04000FF0 RID: 4080
	public static string InboxCaps = "INBOX";

	// Token: 0x04000FF1 RID: 4081
	public static string InGame = "In Game";

	// Token: 0x04000FF2 RID: 4082
	public static string InivitingNToJoinClanN = "Inviting {0} to join clan {1}...";

	// Token: 0x04000FF3 RID: 4083
	public static string InMyClan = "In my clan";

	// Token: 0x04000FF4 RID: 4084
	public static string InvalidData = "Invalid data has been supplied.";

	// Token: 0x04000FF5 RID: 4085
	public static string Inventory = "Inventory";

	// Token: 0x04000FF6 RID: 4086
	public static string InventoryCaps = "INVENTORY";

	// Token: 0x04000FF7 RID: 4087
	public static string InvertMouseButtons = "Invert Mouse Buttons";

	// Token: 0x04000FF8 RID: 4088
	public static string InvitationCancelled = "Invitation Cancelled";

	// Token: 0x04000FF9 RID: 4089
	public static string InvitationPending = "Invitation Pending";

	// Token: 0x04000FFA RID: 4090
	public static string InvitationToJoinClanNHasBeenSent = "Invitation to join clan {0}\nhas been sent.";

	// Token: 0x04000FFB RID: 4091
	public static string Invite = "Invite!";

	// Token: 0x04000FFC RID: 4092
	public static string InviteFriends = "Invite Friends";

	// Token: 0x04000FFD RID: 4093
	public static string InvitePlayer = "Invite Player";

	// Token: 0x04000FFE RID: 4094
	public static string InvitingToJoinClan = "Inviting to join clan...";

	// Token: 0x04000FFF RID: 4095
	public static string JoinBlueCaps = "JOIN BLUE";

	// Token: 0x04001000 RID: 4096
	public static string JoinCaps = "JOIN";

	// Token: 0x04001001 RID: 4097
	public static string JoinDate = "Join Date";

	// Token: 0x04001002 RID: 4098
	public static string JoinRedCaps = "JOIN RED";

	// Token: 0x04001003 RID: 4099
	public static string JoinClanSuccessMsg = "You have successfully joined the clan.";

	// Token: 0x04001004 RID: 4100
	public static string JoinClanErrorMsg = "There was an error joining the clan.";

	// Token: 0x04001005 RID: 4101
	public static string JustForFun = "Just for fun";

	// Token: 0x04001006 RID: 4102
	public static string KDR = "KDR";

	// Token: 0x04001007 RID: 4103
	public static string Keyboard = "Keyboard";

	// Token: 0x04001008 RID: 4104
	public static string KeyButton = "Key/Button";

	// Token: 0x04001009 RID: 4105
	public static string Kills = "Kills";

	// Token: 0x0400100A RID: 4106
	public static string KillXP = "KILL XP";

	// Token: 0x0400100B RID: 4107
	public static string LabsCaps = "LABS";

	// Token: 0x0400100C RID: 4108
	public static string LastDay = "Last Day";

	// Token: 0x0400100D RID: 4109
	public static string LastOnlineN = "Last Online: {0}";

	// Token: 0x0400100E RID: 4110
	public static string Launchers = "Launchers";

	// Token: 0x0400100F RID: 4111
	public static string Leader = "Leader";

	// Token: 0x04001010 RID: 4112
	public static string LeaderN = "Leader: {0}";

	// Token: 0x04001011 RID: 4113
	public static string LeaveClan = "Leave Clan";

	// Token: 0x04001012 RID: 4114
	public static string LeaveClanCaps = "LEAVE CLAN";

	// Token: 0x04001013 RID: 4115
	public static string LeaveClanErrorMsg = "There has been an error processing your request to leave clan {0}. Please try again in a moment.";

	// Token: 0x04001014 RID: 4116
	public static string LeaveClanN = "Leave clan {0}?";

	// Token: 0x04001015 RID: 4117
	public static string LeaveClanSuccessMsg = "You have successfully left the clan {0}.";

	// Token: 0x04001016 RID: 4118
	public static string LeaveClanWarningMsg = "After leaving you will no longer receive clan notifications or have the clan tag displayed next to your name.";

	// Token: 0x04001017 RID: 4119
	public static string LeavingClanN = "Leaving Clan {0}...";

	// Token: 0x04001018 RID: 4120
	public static string Level = "Level";

	// Token: 0x04001019 RID: 4121
	public static string LevelAndXP = "Level & XP";

	// Token: 0x0400101A RID: 4122
	public static string LimitFramerate = "Limit FrameRate:";

	// Token: 0x0400101B RID: 4123
	public static string LoadingGameList = "Loading game list...";

	// Token: 0x0400101C RID: 4124
	public static string LoadoutCaps = "LOADOUT";

	// Token: 0x0400101D RID: 4125
	public static string LoginFailed = "Login Failed";

	// Token: 0x0400101E RID: 4126
	public static string Low = "Low";

	// Token: 0x0400101F RID: 4127
	public static string LowerBody = "Lower Body";

	// Token: 0x04001020 RID: 4128
	public static string LowerBodyArmor = "Lower Body Armor";

	// Token: 0x04001021 RID: 4129
	public static string Machineguns = "Machineguns";

	// Token: 0x04001022 RID: 4130
	public static string ManageYourClan = "Manage your clan";

	// Token: 0x04001023 RID: 4131
	public static string Map = "Map";

	// Token: 0x04001024 RID: 4132
	public static string MasterVolume = "Master Volume:";

	// Token: 0x04001025 RID: 4133
	public static string MatchPerformance = "Match Performance";

	// Token: 0x04001026 RID: 4134
	public static string MaxPlayers = "Max Players";

	// Token: 0x04001027 RID: 4135
	public static string MedCaps = "MED";

	// Token: 0x04001028 RID: 4136
	public static string Melee = "Melee";

	// Token: 0x04001029 RID: 4137
	public static string MeleeWeapons = "Melee Weapons";

	// Token: 0x0400102A RID: 4138
	public static string Member = "Member";

	// Token: 0x0400102B RID: 4139
	public static string Message = "Message:";

	// Token: 0x0400102C RID: 4140
	public static string MessageCaps = "MESSAGE:";

	// Token: 0x0400102D RID: 4141
	public static string MessagesCaps = "MESSAGES";

	// Token: 0x0400102E RID: 4142
	public static string Minutes = "Minutes";

	// Token: 0x0400102F RID: 4143
	public static string Misc = "Misc";

	// Token: 0x04001030 RID: 4144
	public static string Mode = "Mode";

	// Token: 0x04001031 RID: 4145
	public static string Moderate = "Moderate";

	// Token: 0x04001032 RID: 4146
	public static string MonthsAgo = "Months Ago";

	// Token: 0x04001033 RID: 4147
	public static string MostArmorPickedUp = "Most Armor Picked Up";

	// Token: 0x04001034 RID: 4148
	public static string MostCannonKills = "Most Cannon Kills";

	// Token: 0x04001035 RID: 4149
	public static string MostConsecutiveSnipes = "Most Consecutive Snipes";

	// Token: 0x04001036 RID: 4150
	public static string MostDamageDealt = "Most Damage Dealt";

	// Token: 0x04001037 RID: 4151
	public static string MostDamageReceived = "Most Damage Received";

	// Token: 0x04001038 RID: 4152
	public static string MostDeadlyWeapons = "Most Deadly Weapons";

	// Token: 0x04001039 RID: 4153
	public static string MostHeadshots = "Most Headshots";

	// Token: 0x0400103A RID: 4154
	public static string MostHealthPickedUp = "Most Health Picked Up";

	// Token: 0x0400103B RID: 4155
	public static string MostKills = "Most Kills";

	// Token: 0x0400103C RID: 4156
	public static string MostLauncherKills = "Most Launcher Kills";

	// Token: 0x0400103D RID: 4157
	public static string MostMachinegunKills = "Most Machinegun Kills";

	// Token: 0x0400103E RID: 4158
	public static string MostMeleeKills = "Most Melee Kills";

	// Token: 0x0400103F RID: 4159
	public static string MostNutshots = "Most Nutshots";

	// Token: 0x04001040 RID: 4160
	public static string MostShotgunKills = "Most Shotgun Kills";

	// Token: 0x04001041 RID: 4161
	public static string MostSniperRifleKills = "Most Sniper Rifle Kills";

	// Token: 0x04001042 RID: 4162
	public static string MostSplattergunKills = "Most Splattergun Kills";

	// Token: 0x04001043 RID: 4163
	public static string MostValuablePlayers = "Most Valuable Players";

	// Token: 0x04001044 RID: 4164
	public static string MostXPEarned = "Most XP Earned";

	// Token: 0x04001045 RID: 4165
	public static string MotionBlur = "Motion Blur";

	// Token: 0x04001046 RID: 4166
	public static string Motto = "Motto";

	// Token: 0x04001047 RID: 4167
	public static string MottoN = "Motto: {0}";

	// Token: 0x04001048 RID: 4168
	public static string Mouse = "Mouse";

	// Token: 0x04001049 RID: 4169
	public static string MouseSensitivity = "Mouse Sensitivity:";

	// Token: 0x0400104A RID: 4170
	public static string Movement = "Movement";

	// Token: 0x0400104B RID: 4171
	public static string MusicVolume = "Background/Music:";

	// Token: 0x0400104C RID: 4172
	public static string Mute = "Mute audio.";

	// Token: 0x0400104D RID: 4173
	public static string Name = "Name";

	// Token: 0x0400104E RID: 4174
	public static string NameInUseMsg = "This name has already been taken. Please choose another one.";

	// Token: 0x0400104F RID: 4175
	public static string NameInvalidCharsMsg = "That name contains invalid characters.";

	// Token: 0x04001050 RID: 4176
	public static string NameN = "Name: {0}";

	// Token: 0x04001051 RID: 4177
	public static string NameTooManySpacesMsg = "That name has too many spaces.";

	// Token: 0x04001052 RID: 4178
	public static string NameTooShortMsg = "That name is too short.";

	// Token: 0x04001053 RID: 4179
	public static string NClanInformation = "[{0}] Clan Information";

	// Token: 0x04001054 RID: 4180
	public static string NClanRoster = "[{0}] Clan Roster";

	// Token: 0x04001055 RID: 4181
	public static string NetworkError = "Network Error";

	// Token: 0x04001056 RID: 4182
	public static string NewAndSaleItems = "New And Sale Items";

	// Token: 0x04001057 RID: 4183
	public static string NewHereSignUpAndPlayForFree = "New here? SIGN UP and play for free!";

	// Token: 0x04001058 RID: 4184
	public static string NewMessage = "New Mail";

	// Token: 0x04001059 RID: 4185
	public static string NextCaps = "NEXT";

	// Token: 0x0400105A RID: 4186
	public static string NiceJobThatWasSeriousCarnage = "Nice job, that was some serious carnage!";

	// Token: 0x0400105B RID: 4187
	public static string NinetyDays = "90 Days";

	// Token: 0x0400105C RID: 4188
	public static string NIsNoLongerAMemberOfClanN = "{0} is no longer a member of clan {1}";

	// Token: 0x0400105D RID: 4189
	public static string NIsNoLongerInvitedToJoinClanN = "{0} is no longer invited to jon clan {1}.";

	// Token: 0x0400105E RID: 4190
	public static string NMembersNOnline = "{0}/{1} members ({2} online)";

	// Token: 0x0400105F RID: 4191
	public static string NNeedsAClanLicenseToBeLeader = "{0} need a Clan License to be leader of a clan.\nThe Clan License is a special item\nthat {0} can buy in the Shop.";

	// Token: 0x04001060 RID: 4192
	public static string NNeedsToBeLevelFourToBeAClanLeader = "{0} need to be at least level 4\nto be leader of a clan.";

	// Token: 0x04001061 RID: 4193
	public static string NNeedsToHaveOneFriendToBeAClanLeader = "{0} need to have at least 1 friend\nto be leader of a clan.";

	// Token: 0x04001062 RID: 4194
	public static string NoConversationSelected = "No Conversation Selected";

	// Token: 0x04001063 RID: 4195
	public static string NoFriendlyFire = "No Friendly Fire";

	// Token: 0x04001064 RID: 4196
	public static string None = "None";

	// Token: 0x04001065 RID: 4197
	public static string NoSelectedItems = "No Selected Items";

	// Token: 0x04001066 RID: 4198
	public static string NoThanks = "No Thanks";

	// Token: 0x04001067 RID: 4199
	public static string NotPasswordProtected = "Not password protected";

	// Token: 0x04001068 RID: 4200
	public static string NPercentOff = "{0:N0}% Off!";

	// Token: 0x04001069 RID: 4201
	public static string NPlayers = "{0} Players";

	// Token: 0x0400106A RID: 4202
	public static string NTeamWins = "{0} Team Wins!";

	// Token: 0x0400106B RID: 4203
	public static string NutshotXP = "NUTSHOT XP";

	// Token: 0x0400106C RID: 4204
	public static string OffensiveNameMsg = "The name contains offensive words.";

	// Token: 0x0400106D RID: 4205
	public static string Officer = "Officer";

	// Token: 0x0400106E RID: 4206
	public static string Offline = "Offline";

	// Token: 0x0400106F RID: 4207
	public static string On = "On";

	// Token: 0x04001070 RID: 4208
	public static string OneDay = "1 Day";

	// Token: 0x04001071 RID: 4209
	public static string Online = "Online";

	// Token: 0x04001072 RID: 4210
	public static string OnlyYourClanLeaderCanDoThis = "Only your clan leader can do this.";

	// Token: 0x04001073 RID: 4211
	public static string OptionsBtnTooltip = "Configure controls, visual and gameplay options.";

	// Token: 0x04001074 RID: 4212
	public static string OptionsCaps = "OPTIONS";

	// Token: 0x04001075 RID: 4213
	public static string PasswordDoNotMatch = "Passwords do not match.";

	// Token: 0x04001076 RID: 4214
	public static string PasswordIncorrect = "Password Incorrect";

	// Token: 0x04001077 RID: 4215
	public static string PasswordInvalidCharsMsg = "Password should have at least 6 characters.";

	// Token: 0x04001078 RID: 4216
	public static string PasswordIsInvalid = "Password is invalid.";

	// Token: 0x04001079 RID: 4217
	public static string PasswordProtected = "Password Protected";

	// Token: 0x0400107A RID: 4218
	public static string PasswordsDoNotMatch = "Passwords do not match.";

	// Token: 0x0400107B RID: 4219
	public static string PendingRequestsCaps = "PENDING REQUESTS";

	// Token: 0x0400107C RID: 4220
	public static string PerformanceReportCaps = "PERFORMANCE REPORT";

	// Token: 0x0400107D RID: 4221
	public static string Permanent = "Permanent";

	// Token: 0x0400107E RID: 4222
	public static string Personal = "Personal";

	// Token: 0x0400107F RID: 4223
	public static string PersonalRecordsPerLife = "Personal Records (per Life)";

	// Token: 0x04001080 RID: 4224
	public static string Ping = "Ping";

	// Token: 0x04001081 RID: 4225
	public static string PlayBtnTooltip = "Join other players games.";

	// Token: 0x04001082 RID: 4226
	public static string PlayCaps = "PLAY";

	// Token: 0x04001083 RID: 4227
	public static string Player = "Player";

	// Token: 0x04001084 RID: 4228
	public static string PlayerAlreadyHasPendingClanInviteMsg = "This player already has a pending invitation.\nYou cannot send another one.";

	// Token: 0x04001085 RID: 4229
	public static string PlayerAlreadyInClanMsg = "This player is already in a clan. You cannot invite players\nto join your clan if they are already in a clan.";

	// Token: 0x04001086 RID: 4230
	public static string PlayerCaps = "PLAYER:";

	// Token: 0x04001087 RID: 4231
	public static string PlayerLevelNMinusRestriction = "[Player Level <{0} Restriction]";

	// Token: 0x04001088 RID: 4232
	public static string PlayerLevelNPlusRestriction = "[Player Level {0}+ Restriction]";

	// Token: 0x04001089 RID: 4233
	public static string PlayerLevelNRestriction = "[Player Level {0} Restriction]";

	// Token: 0x0400108A RID: 4234
	public static string PlayerLevelNToNRestriction = "[Player Level {0}-{1} Restriction]";

	// Token: 0x0400108B RID: 4235
	public static string Players = "Players";

	// Token: 0x0400108C RID: 4236
	public static string PlayersOnline = "Players Online";

	// Token: 0x0400108D RID: 4237
	public static string PlayTime = "Playtime";

	// Token: 0x0400108E RID: 4238
	public static string PleaseAgreeTOSMsg = "Please agree to the Terms of Service.";

	// Token: 0x0400108F RID: 4239
	public static string PleaseProvideValidEmailPasswordMsg = "Please provide a valid email address and password.\nThis email will be used as your login in future.";

	// Token: 0x04001090 RID: 4240
	public static string PleaseWait = "Please wait";

	// Token: 0x04001091 RID: 4241
	public static string Points = "Points";

	// Token: 0x04001092 RID: 4242
	public static string PointsEarnedN = "Points Earned {0}";

	// Token: 0x04001093 RID: 4243
	public static string Position = "Position";

	// Token: 0x04001094 RID: 4244
	public static string PressRefreshToSeeCurrentGames = "Press Refresh to see current games";

	// Token: 0x04001095 RID: 4245
	public static string Price = "Price";

	// Token: 0x04001096 RID: 4246
	public static string PrimaryWeapon = "Primary";

	// Token: 0x04001097 RID: 4247
	public static string PrivateChat = "Private Chat";

	// Token: 0x04001098 RID: 4248
	public static string PrivateersLicense = "Privateers\nLicense";

	// Token: 0x04001099 RID: 4249
	public static string PrivateersLicenseGranted = "Privateers License Granted!";

	// Token: 0x0400109A RID: 4250
	public static string PrivatePosition = "Private Chat";

	// Token: 0x0400109B RID: 4251
	public static string ProblemBuyingItem = "Problem Buying Item";

	// Token: 0x0400109C RID: 4252
	public static string ProcessingLogin = "Processing Login...";

	// Token: 0x0400109D RID: 4253
	public static string ProcessingTransactionPleaseWait = "Processing transaction, please wait...";

	// Token: 0x0400109E RID: 4254
	public static string PromoteMember = "Promote Member";

	// Token: 0x0400109F RID: 4255
	public static string QualitySettings = "Quality Settings";

	// Token: 0x040010A0 RID: 4256
	public static string QuickItem = "Quick Item";

	// Token: 0x040010A1 RID: 4257
	public static string QuickItems = "Quick Items";

	// Token: 0x040010A2 RID: 4258
	public static string QuickSearch = "Quick Search";

	// Token: 0x040010A3 RID: 4259
	public static string QuitCaps = "QUIT";

	// Token: 0x040010A4 RID: 4260
	public static string RateOfFire = "Rate of Fire";

	// Token: 0x040010A5 RID: 4261
	public static string ReachLevelFour = "- Reach Level 4";

	// Token: 0x040010A6 RID: 4262
	public static string ReadyCaps = "READY";

	// Token: 0x040010A7 RID: 4263
	public static string RecentPickupWeapons = "Recent Pick-up Weapons";

	// Token: 0x040010A8 RID: 4264
	public static string Recoil = "Recoil";

	// Token: 0x040010A9 RID: 4265
	public static string Red = "Red";

	// Token: 0x040010AA RID: 4266
	public static string Refresh = "Refresh";

	// Token: 0x040010AB RID: 4267
	public static string RefreshCaps = "REFRESH";

	// Token: 0x040010AC RID: 4268
	public static string RefreshingServer = "Refreshing server";

	// Token: 0x040010AD RID: 4269
	public static string RejectClanInvitation = "Reject Clan Invitation";

	// Token: 0x040010AE RID: 4270
	public static string RejectTheClanInvitationFromN = "Reject the clan invitation from {0}?";

	// Token: 0x040010AF RID: 4271
	public static string RemainingXP = "Remaining XP:";

	// Token: 0x040010B0 RID: 4272
	public static string Remove = "Remove";

	// Token: 0x040010B1 RID: 4273
	public static string RemoveFriendCaps = "REMOVE FRIEND";

	// Token: 0x040010B2 RID: 4274
	public static string RemoveMember = "Remove Member";

	// Token: 0x040010B3 RID: 4275
	public static string RemoveMemberCaps = "REMOVE MEMBER";

	// Token: 0x040010B4 RID: 4276
	public static string RemoveMemberErrorMsg = "Error removing {0} from clan {1}.\nPlease try again in a moment.";

	// Token: 0x040010B5 RID: 4277
	public static string RemoveMemberWarningMsg = "The clan tag will not show up next to their name and they will not receive clan notifications.";

	// Token: 0x040010B6 RID: 4278
	public static string RemoveNFromClanN = "Remove {0} from clan {1}?";

	// Token: 0x040010B7 RID: 4279
	public static string RemovingNFromClanN = "Removing {0} from clan {1}...";

	// Token: 0x040010B8 RID: 4280
	public static string Renew = "Renew";

	// Token: 0x040010B9 RID: 4281
	public static string Reply = "Reply";

	// Token: 0x040010BA RID: 4282
	public static string ReportBug = "Report a bug.";

	// Token: 0x040010BB RID: 4283
	public static string ReportPlayer = "Report a player.";

	// Token: 0x040010BC RID: 4284
	public static string RequestNoLongerExistsMsg = "This request no longer exists.\nIt may have expired or been withdrawn.";

	// Token: 0x040010BD RID: 4285
	public static string RequestsCaps = "REQUESTS";

	// Token: 0x040010BE RID: 4286
	public static string ResetDefaults = "Reset Defaults";

	// Token: 0x040010BF RID: 4287
	public static string ResetFiltersCaps = "RESET FILTERS";

	// Token: 0x040010C0 RID: 4288
	public static string Retry = "Retry";

	// Token: 0x040010C1 RID: 4289
	public static string RetypeYourPassword = "Retype Your Password";

	// Token: 0x040010C2 RID: 4290
	public static string Round = "Round";

	// Token: 0x040010C3 RID: 4291
	public static string RoundEndCaps = "ROUND END!";

	// Token: 0x040010C4 RID: 4292
	public static string StartsInCaps = "STARTS IN";

	// Token: 0x040010C5 RID: 4293
	public static string RoundTime = "Round Time";

	// Token: 0x040010C6 RID: 4294
	public static string Search = "Search";

	// Token: 0x040010C7 RID: 4295
	public static string SearchMessages = "Search Messages";

	// Token: 0x040010C8 RID: 4296
	public static string SecondaryWeapon = "Secondary";

	// Token: 0x040010C9 RID: 4297
	public static string SelectWeapon = "Select weapon:";

	// Token: 0x040010CA RID: 4298
	public static string SelectYourLoadoutCaps = "SELECT YOUR LOADOUT";

	// Token: 0x040010CB RID: 4299
	public static string SendCaps = "SEND";

	// Token: 0x040010CC RID: 4300
	public static string SendMessage = "Send Mail";

	// Token: 0x040010CD RID: 4301
	public static string SentInvites = "Sent Invites";

	// Token: 0x040010CE RID: 4302
	public static string ServerError = "Server Error";

	// Token: 0x040010CF RID: 4303
	public static string ServerFull = "Server full";

	// Token: 0x040010D0 RID: 4304
	public static string ServerFullMsg = "This server is full. Please select a different server.";

	// Token: 0x040010D1 RID: 4305
	public static string ServerIsNotReachable = "Server is not reachable";

	// Token: 0x040010D2 RID: 4306
	public static string ServerName = "Server Name";

	// Token: 0x040010D3 RID: 4307
	public static string ServerNameDesc = "The server is named after the region that the server is located. Choose the server that is located closest to you for the best network performance.";

	// Token: 0x040010D4 RID: 4308
	public static string SettingUp = "Setting Up...";

	// Token: 0x040010D5 RID: 4309
	public static string SevenDays = "7 Days";

	// Token: 0x040010D6 RID: 4310
	public static string Share = "Share!";

	// Token: 0x040010D7 RID: 4311
	public static string ShareTheFunWithYourFaceBookFriends = "Share the fun with your Facebook friends!";

	// Token: 0x040010D8 RID: 4312
	public static string ShopBtnTooltip = "Equip your character with kick ass weapons and gear!";

	// Token: 0x040010D9 RID: 4313
	public static string ShopCaps = "SHOP";

	// Token: 0x040010DA RID: 4314
	public static string Shotguns = "Shotguns";

	// Token: 0x040010DB RID: 4315
	public static string ShowFPS = "Show FPS in-game";

	// Token: 0x040010DC RID: 4316
	public static string SingleWeaponLimit = "Single Weapon Limit";

	// Token: 0x040010DD RID: 4317
	public static string SkinTone = "Skin Tone";

	// Token: 0x040010DE RID: 4318
	public static string SlowCaps = "SLOW";

	// Token: 0x040010DF RID: 4319
	public static string Smackdown = "Smackdowns";

	// Token: 0x040010E0 RID: 4320
	public static string SniperRifles = "Sniper Rifles";

	// Token: 0x040010E1 RID: 4321
	public static string SocNetInvalidMsg = "The social network you have arrived from is incorrect.";

	// Token: 0x040010E2 RID: 4322
	public static string Spectate = "Spectate";

	// Token: 0x040010E3 RID: 4323
	public static string Speed = "Speed";

	// Token: 0x040010E4 RID: 4324
	public static string SpeedDesc = "This refers to the network performance between you and the game server. The number value (known as 'ping'), in milliseconds, refers to the amount of time it takes for information to travel from your computer to the game server and back. Lower ping equates to better network performance, so always look to join the fastest available server.";

	// Token: 0x040010E5 RID: 4325
	public static string KillLimit = "Kill Limit";

	// Token: 0x040010E6 RID: 4326
	public static string Splatterguns = "Splatterguns";

	// Token: 0x040010E7 RID: 4327
	public static string StartTypingTheNameOfAFriend = "Start typing the name of a friend";

	// Token: 0x040010E8 RID: 4328
	public static string StatsBtnTooltip = "Check your characters statistics.";

	// Token: 0x040010E9 RID: 4329
	public static string ProfileCaps = "PROFILE";

	// Token: 0x040010EA RID: 4330
	public static string Status = "Status";

	// Token: 0x040010EB RID: 4331
	public static string Subject = "Subject:";

	// Token: 0x040010EC RID: 4332
	public static string SuicideXP = "SUICIDE XP";

	// Token: 0x040010ED RID: 4333
	public static string Tag = "Tag";

	// Token: 0x040010EE RID: 4334
	public static string TermsOfService = "Terms of Service";

	// Token: 0x040010EF RID: 4335
	public static string TertiaryWeapon = "Tertiary";

	// Token: 0x040010F0 RID: 4336
	public static string TheAmountYouTriedToPurchaseIsInvalid = "Sorry, the maximum amount for this consumable is {0}!";

	// Token: 0x040010F1 RID: 4337
	public static string TheNTeamHadTheMostKillsAtMatchEnd = "The {0} team had the most kills at match end.";

	// Token: 0x040010F2 RID: 4338
	public static string ThereAreNoPendingRequestsForN = "There are no pending requests for {0}.";

	// Token: 0x040010F3 RID: 4339
	public static string ThirtyDays = "30 Days";

	// Token: 0x040010F4 RID: 4340
	public static string ThisActionCannotBeUndoneCaps = "THIS ACTION CANNOT BE UNDONE.";

	// Token: 0x040010F5 RID: 4341
	public static string ThisGameIsFull = "This game is full.";

	// Token: 0x040010F6 RID: 4342
	public static string ThisGameNoLongerExists = "This game no longer exists.";

	// Token: 0x040010F7 RID: 4343
	public static string ThisIsAListOfPeopleYouHaveAskedToJoinClanNotAccepted = "This is a list of people you have asked to join the clan who have not yet accepted.";

	// Token: 0x040010F8 RID: 4344
	public static string ThisIsTheOfficialNameOfYourClan = "This is the official name of your clan.";

	// Token: 0x040010F9 RID: 4345
	public static string ThisIsYourOfficialClanMotto = "This is your official clan motto.";

	// Token: 0x040010FA RID: 4346
	public static string ThisItemCannotBePurchasedForDuration = "This item cannot be purchased for that particular duration.";

	// Token: 0x040010FB RID: 4347
	public static string ThisItemCannotBePurchasedFromTheShop = "This item cannot be purchased from the Shop.";

	// Token: 0x040010FC RID: 4348
	public static string ThisItemCannotBePurchasedFromTheUnderground = "This item cannot be purchased from the Underground.";

	// Token: 0x040010FD RID: 4349
	public static string ThisItemCannotBePurchasedPermanently = "This item cannot be purchased permanently.";

	// Token: 0x040010FE RID: 4350
	public static string ThisItemCannotBeRented = "This item cannot be rented.";

	// Token: 0x040010FF RID: 4351
	public static string ThisItemIsNotForSale = "This item is not for sale!";

	// Token: 0x04001100 RID: 4352
	public static string ThisItemIsOutOfStock = "This item is now out of stock.";

	// Token: 0x04001101 RID: 4353
	public static string ThisPackIsDisabled = "This pack is disabled.";

	// Token: 0x04001102 RID: 4354
	public static string ThisTagGetsDisplayedNextToYourName = "This tag gets displayed next to clan member names.";

	// Token: 0x04001103 RID: 4355
	public static string ThisWillChangeNPositionToN = "This will change {0} position to {1}.";

	// Token: 0x04001104 RID: 4356
	public static string TiedForWinner = "Tied for winner!";

	// Token: 0x04001105 RID: 4357
	public static string TimeLimit = "Time Limit";

	// Token: 0x04001106 RID: 4358
	public static string To = "To:";

	// Token: 0x04001107 RID: 4359
	public static string ToCreateAClanYouStillNeedTo = "To create a clan, you still need to:";

	// Token: 0x04001108 RID: 4360
	public static string Today = "Today";

	// Token: 0x04001109 RID: 4361
	public static string TopBlues = "Top Blue";

	// Token: 0x0400110A RID: 4362
	public static string TopReds = "Top Reds";

	// Token: 0x0400110B RID: 4363
	public static string TrainingCaps = "TRAINING";

	// Token: 0x0400110C RID: 4364
	public static string TrainingModeDesc = "Explore mode is for you to practice without the stress of having other players around shooting you in the face.";

	// Token: 0x0400110D RID: 4365
	public static string TranserClanSuccessMsg = "Leadership of clan {0} has successfully\nbe transferred to {1}";

	// Token: 0x0400110E RID: 4366
	public static string TransferClanErrorMsg = "Error transferring leadership of clan {0} to {1}.\nPlease try again in a moment..";

	// Token: 0x0400110F RID: 4367
	public static string TransferClanLeaderhsipToN = "Transfer clan leadership to {0}?";

	// Token: 0x04001110 RID: 4368
	public static string TransferClanWarningMsg = "You will not be the leader of this clan anymore.";

	// Token: 0x04001111 RID: 4369
	public static string TransferLeadership = "Transfer Leadership";

	// Token: 0x04001112 RID: 4370
	public static string TransferLeadershipCaps = "TRANSFER LEADERSHIP";

	// Token: 0x04001113 RID: 4371
	public static string TransferringLeadershipOfClanNtoN = "Transferring leadership of clan {0} to {1}...";

	// Token: 0x04001114 RID: 4372
	public static string Try = "Try";

	// Token: 0x04001115 RID: 4373
	public static string TryThe = "Try the";

	// Token: 0x04001116 RID: 4374
	public static string TryYourWeapons = "Try your Weapons";

	// Token: 0x04001117 RID: 4375
	public static string TypePasswordHere = "Type Password Here";

	// Token: 0x04001118 RID: 4376
	public static string UndergroundCaps = "UNDERGROUND";

	// Token: 0x04001119 RID: 4377
	public static string UnequippingDuplicateFunctionalItemClass = "Unequipping duplicate\nfunctional item class.";

	// Token: 0x0400111A RID: 4378
	public static string UnequippingDuplicateQuickItemClass = "Unequipping duplicate\nquick item class.";

	// Token: 0x0400111B RID: 4379
	public static string UnequippingDuplicateWeaponClass = "Unequipping duplicate\nweapon class.";

	// Token: 0x0400111C RID: 4380
	public static string UnexpectedReturn = "Unexpected Return";

	// Token: 0x0400111D RID: 4381
	public static string Unknown = "Unknown";

	// Token: 0x0400111E RID: 4382
	public static string Unmute = "Unmute audio.";

	// Token: 0x0400111F RID: 4383
	public static string UnreadyCaps = "UNREADY";

	// Token: 0x04001120 RID: 4384
	public static string UnspecifiedErrorMsg = "An error of unspecified nature has\nsurreptitiously caused this popup to appear.\nIt would be great if you could report this.";

	// Token: 0x04001121 RID: 4385
	public static string UpdateMemberErrorMsg = "Error updating member status of {0}.\nPlease try again in a moment.";

	// Token: 0x04001122 RID: 4386
	public static string UpdateMemberStatus = "Update Member Status";

	// Token: 0x04001123 RID: 4387
	public static string UpdateMemberSuccessMsg = "Member status of {0} has been successfully updated.";

	// Token: 0x04001124 RID: 4388
	public static string UpdateMemberWarningMsg = "This will change {0} position\n to {1}.";

	// Token: 0x04001125 RID: 4389
	public static string UpdateNPosition = "Update {0} position?";

	// Token: 0x04001126 RID: 4390
	public static string UpdatingInventory = "Updating Inventory";

	// Token: 0x04001127 RID: 4391
	public static string UpdatingItemMall = "Updating Item Mall";

	// Token: 0x04001128 RID: 4392
	public static string UpdatingMemberStatusOfN = "Updating member status of {0}...";

	// Token: 0x04001129 RID: 4393
	public static string UpperBody = "Upper Body";

	// Token: 0x0400112A RID: 4394
	public static string UpperBodyArmor = "Upper Body Armor";

	// Token: 0x0400112B RID: 4395
	public static string UseThisFormToSendClanInvitations = "Use this form to send clan invitations to your friends.";

	// Token: 0x0400112C RID: 4396
	public static string Velocity = "Velocity";

	// Token: 0x0400112D RID: 4397
	public static string VerifyPassword = "Verify Password";

	// Token: 0x0400112E RID: 4398
	public static string ViewOutstandingInvitesAndRequests = "View outstanding invites and requests";

	// Token: 0x0400112F RID: 4399
	public static string Volume = "Volume";

	// Token: 0x04001130 RID: 4400
	public static string Warning = "Warning";

	// Token: 0x04001131 RID: 4401
	public static string WaterQuality = "Water Quality";

	// Token: 0x04001132 RID: 4402
	public static string WeaponClassRecords = "Weapon Class Records";

	// Token: 0x04001133 RID: 4403
	public static string WeaponLoadout = "Weapon Loadout";

	// Token: 0x04001134 RID: 4404
	public static string WeaponPerformaceTotal = "Weapon Performance (in Total)";

	// Token: 0x04001135 RID: 4405
	public static string Weapons = "Weapons";

	// Token: 0x04001136 RID: 4406
	public static string WeaponsCaps = "WEAPONS";

	// Token: 0x04001137 RID: 4407
	public static string Welcome = "Welcome";

	// Token: 0x04001138 RID: 4408
	public static string WelcomeToUS = "Welcome To UberStrike";

	// Token: 0x04001139 RID: 4409
	public static string WereUpdatingTheItemMallPleaseWait = "We're updating the item mall, please wait...";

	// Token: 0x0400113A RID: 4410
	public static string WereUpdatingYourInventoryPleaseWait = "We're updating your inventory, please wait...";

	// Token: 0x0400113B RID: 4411
	public static string WonWithAScoreOf = "won with a score of";

	// Token: 0x0400113C RID: 4412
	public static string XPEarnedN = "XP Earned {0}";

	// Token: 0x0400113D RID: 4413
	public static string Yesterday = "Yesterday";

	// Token: 0x0400113E RID: 4414
	public static string YouAlreadyMasteredThisLevel = "You already mastered this Level!";

	// Token: 0x0400113F RID: 4415
	public static string YouAlreadyOwnThisItem = "You already own this item.";

	// Token: 0x04001140 RID: 4416
	public static string YouCannotPurchaseThisItemForMoreThanNDays = "You cannot purchase this item for more than {0} days.";

	// Token: 0x04001141 RID: 4417
	public static string YouCantChangeYourClanInfoOnceCreated = "You can’t change any of your clan info once your clan is created, so make it count!";

	// Token: 0x04001142 RID: 4418
	public static string YouDontHaveEnoughPointsOrCreditsToPurchaseThisItem = "You don't have enough points or credits to buy this item.";

	// Token: 0x04001143 RID: 4419
	public static string YouDontNeedToEquipLicenses = "You don't need to\nequip licenses.";

	// Token: 0x04001144 RID: 4420
	public static string YouDontPermissionToPerformThisAction = "You don't have the right permissions to perform this action.";

	// Token: 0x04001145 RID: 4421
	public static string YouHaveNFriends = "You have {0} friends";

	// Token: 0x04001146 RID: 4422
	public static string YouHaveNNewMessages = "You have {0} new message(s)";

	// Token: 0x04001147 RID: 4423
	public static string YouHaveNoFriends = "You have no friends.";

	// Token: 0x04001148 RID: 4424
	public static string YouHaveOnlyOneFriend = "You have only one friend";

	// Token: 0x04001149 RID: 4425
	public static string YouHaveToReachLevelNToJoinThisGame = "You have to reach Level {0} to join this game!";

	// Token: 0x0400114A RID: 4426
	public static string YouNeedAClanLicenseToCreateClanMsg = "You need a Clan License to create a clan.\nThe Clan License is a special item that you can buy in the Shop.";

	// Token: 0x0400114B RID: 4427
	public static string YouNeedAtLeastOneFriendToCreateAClan = "You need to have at least 1 friend to create a clan.";

	// Token: 0x0400114C RID: 4428
	public static string YouNeedMoreCreditsToBuyThisItem = "You need more credits to buy this item.";

	// Token: 0x0400114D RID: 4429
	public static string YouNeedToBeAtLeastLevelFourToCreateAClan = "You need to be at least level 4 to create a clan.";

	// Token: 0x0400114E RID: 4430
	public static string YouNeedToBeLevelNToBuyThisItem = "You need to be Level {0} to buy this item.";

	// Token: 0x0400114F RID: 4431
	public static string YouNeedToEarnMorePointsToBuyThisItem = "You need to earn more points to buy this item.";

	// Token: 0x04001150 RID: 4432
	public static string YourAccountHasBeenBanned = "Your account\nhas been banned.";

	// Token: 0x04001151 RID: 4433
	public static string YourAreNoLongerAMemberOfClanN = "You are no longer a member of clan {0}.";

	// Token: 0x04001152 RID: 4434
	public static string YourClanIsBeingCreated = "Your clan is being created...";

	// Token: 0x04001153 RID: 4435
	public static string YourFriendRequestIsAlreadySent = "Your friend request is sent already!";

	// Token: 0x04001154 RID: 4436
	public static string YourGameNameIsInvalid = "Your Game Name is not valid.";

	// Token: 0x04001155 RID: 4437
	public static string YourLevelIsTooLowToBuyThisItem = "Your level is too low to purchase this item.";

	// Token: 0x04001156 RID: 4438
	public static string YourMessageHasBeenSent = "Your message has been sent!";

	// Token: 0x04001157 RID: 4439
	public static string YourMessageHasNotBeenSent = "Your message has not been sent!";

	// Token: 0x04001158 RID: 4440
	public static string YourRequestHasBeenSent = "Your request has been sent!";

	// Token: 0x04001159 RID: 4441
	public static string YourProfileCaps = "YOUR PROFILE";

	// Token: 0x0400115A RID: 4442
	public static string YouveAlreadyInvitedThatPlayer = "You've already invited the player!";

	// Token: 0x0400115B RID: 4443
	public static string AddAsFriend = "Add as Friend";

	// Token: 0x0400115C RID: 4444
	public static string Admin = "Admin";

	// Token: 0x0400115D RID: 4445
	public static string Always = "Always";

	// Token: 0x0400115E RID: 4446
	public static string AreYouSureYouWantToLeaveTheGame = "Are you sure you want to leave the game";

	// Token: 0x0400115F RID: 4447
	public static string AudioCaps = "AUDIO";

	// Token: 0x04001160 RID: 4448
	public static string BugType = "Bug Type";

	// Token: 0x04001161 RID: 4449
	public static string ChangingToBlueTeam = "Changing to the Blue Team.";

	// Token: 0x04001162 RID: 4450
	public static string ChangingToRedTeam = "Changing to the Red Team.";

	// Token: 0x04001163 RID: 4451
	public static string Chat = "Chat";

	// Token: 0x04001164 RID: 4452
	public static string ChatInClan = "CHAT IN CLAN";

	// Token: 0x04001165 RID: 4453
	public static string ChatInLobby = "CHAT IN LOBBY";

	// Token: 0x04001166 RID: 4454
	public static string ChatWith = "Chat with";

	// Token: 0x04001167 RID: 4455
	public static string Cheaters = "Cheaters";

	// Token: 0x04001168 RID: 4456
	public static string Clan = "Clan";

	// Token: 0x04001169 RID: 4457
	public static string ClickToRespawn = "Click to Respawn!";

	// Token: 0x0400116A RID: 4458
	public static string CongratulationsYouKilledYourself = "Congratulations. You killed yourself.";

	// Token: 0x0400116B RID: 4459
	public static string Contacts = "Contacts";

	// Token: 0x0400116C RID: 4460
	public static string Controls = "Controls";

	// Token: 0x0400116D RID: 4461
	public static string ControlsCaps = "CONTROLS";

	// Token: 0x0400116E RID: 4462
	public static string Crash = "Crash";

	// Token: 0x0400116F RID: 4463
	public static string Details = "Details";

	// Token: 0x04001170 RID: 4464
	public static string DisconnectionIn = "Disconnection in";

	// Token: 0x04001171 RID: 4465
	public static string DontSpamTheLobbyChat = "Don't spam the Lobby chat!";

	// Token: 0x04001172 RID: 4466
	public static string EnableRagdoll = "Enable Ragdoll";

	// Token: 0x04001173 RID: 4467
	public static string EnterAMessageHere = "Enter a message here";

	// Token: 0x04001174 RID: 4468
	public static string EnterAMessageInGameHere = "Enter a message in game here";

	// Token: 0x04001175 RID: 4469
	public static string EnterAMessageToClanHere = "Enter a message to clan here";

	// Token: 0x04001176 RID: 4470
	public static string EnterAMessageToLobbyHere = "Enter a message to lobby here";

	// Token: 0x04001177 RID: 4471
	public static string EnteredTrainingMode = "entered Training Mode!";

	// Token: 0x04001178 RID: 4472
	public static string FirstTime = "First Time";

	// Token: 0x04001179 RID: 4473
	public static string Frequency = "Frequency";

	// Token: 0x0400117A RID: 4474
	public static string Friends = "Friends";

	// Token: 0x0400117B RID: 4475
	public static string Gameplay = "Gameplay";

	// Token: 0x0400117C RID: 4476
	public static string Graphics = "Graphics";

	// Token: 0x0400117D RID: 4477
	public static string HeadshotFromN = "Headshot from {0}.";

	// Token: 0x0400117E RID: 4478
	public static string HowToReproduceIt = "How to reproduce it?";

	// Token: 0x0400117F RID: 4479
	public static string InviteToClan = "Invite to Clan";

	// Token: 0x04001180 RID: 4480
	public static string IsNotOnline = "is not online";

	// Token: 0x04001181 RID: 4481
	public static string JoinedTheGame = "joined the game.";

	// Token: 0x04001182 RID: 4482
	public static string JoinGame = "Join Game";

	// Token: 0x04001183 RID: 4483
	public static string KilledByN = "killed by {0}.";

	// Token: 0x04001184 RID: 4484
	public static string LeaveCaps = "LEAVE";

	// Token: 0x04001185 RID: 4485
	public static string LeaveGameWarningMsg = "If you leave before the round ends you will lose all the XP and Points that you earned in this round!\nAre you sure you want to leave?";

	// Token: 0x04001186 RID: 4486
	public static string LeavingGame = "Leaving Game";

	// Token: 0x04001187 RID: 4487
	public static string LeftTheGame = "left the game";

	// Token: 0x04001188 RID: 4488
	public static string Lobby = "Lobby";

	// Token: 0x04001189 RID: 4489
	public static string MoreInfo = "More info...";

	// Token: 0x0400118A RID: 4490
	public static string NKilledThemself = "suicided.";

	// Token: 0x0400118B RID: 4491
	public static string NKillsLeft = "{0} Kills Left!";

	// Token: 0x0400118C RID: 4492
	public static string NoMatchFound = "No Match Found";

	// Token: 0x0400118D RID: 4493
	public static string NoPlayerSelected = "No Player Selected";

	// Token: 0x0400118E RID: 4494
	public static string NoPlayersToReport = "No Players to Report";

	// Token: 0x0400118F RID: 4495
	public static string NutshotFromN = "Nutshot from {0}.";

	// Token: 0x04001190 RID: 4496
	public static string OneKillLeft = "One Kill Left!";

	// Token: 0x04001191 RID: 4497
	public static string OnlyOneTeamChangePerLife = "Only one team change per life.";

	// Token: 0x04001192 RID: 4498
	public static string OpenThisLinkInANewBrowserWindow = "Open this link in a new browser window";

	// Token: 0x04001193 RID: 4499
	public static string Others = "Others";

	// Token: 0x04001194 RID: 4500
	public static string PlayerNames = "Player Names";

	// Token: 0x04001195 RID: 4501
	public static string Private = "Private";

	// Token: 0x04001196 RID: 4502
	public static string Report = "Report";

	// Token: 0x04001197 RID: 4503
	public static string ReportBugCaps = "REPORT BUG";

	// Token: 0x04001198 RID: 4504
	public static string ReportBugSuccessMsg = "Your  bug has been successfully reported!";

	// Token: 0x04001199 RID: 4505
	public static string ReportPlayerCaps = "REPORT PLAYER";

	// Token: 0x0400119A RID: 4506
	public static string ReportPlayerErrorMsg = "Your report was not submitted because you are not connected to our servers";

	// Token: 0x0400119B RID: 4507
	public static string ReportPlayerInfoMsg = "In this form you can report illegal activities detected while playing UberStrike.";

	// Token: 0x0400119C RID: 4508
	public static string ReportPlayerSuccessMsg = "Your report was sent and will be reviewed!\n\nThank you for keeping our community clean.";

	// Token: 0x0400119D RID: 4509
	public static string ReportPlayerWarningMsg = "Are you sure you want to report the player '{0}'?\n\nFalsifying reports is a punishable offense!";

	// Token: 0x0400119E RID: 4510
	public static string ReportType = "Report Type";

	// Token: 0x0400119F RID: 4511
	public static string SelectAPlayer = "Select a Player";

	// Token: 0x040011A0 RID: 4512
	public static string SelectType = "Select Type";

	// Token: 0x040011A1 RID: 4513
	public static string Send = "Send";

	// Token: 0x040011A2 RID: 4514
	public static string ServerDown = "Server Down";

	// Token: 0x040011A3 RID: 4515
	public static string ShopTutorialMsg01 = "Welcome to the Testing Area!";

	// Token: 0x040011A4 RID: 4516
	public static string ShopTutorialMsg02 = "Press 'ESC' or 'Backspace' at any time to exit.";

	// Token: 0x040011A5 RID: 4517
	public static string SmackdownFromN = "Smackdown from {0}.";

	// Token: 0x040011A6 RID: 4518
	public static string Sometimes = "Sometimes";

	// Token: 0x040011A7 RID: 4519
	public static string SysInfoCaps = "SYS INFO";

	// Token: 0x040011A8 RID: 4520
	public static string TheCommunicator = "The Communicator";

	// Token: 0x040011A9 RID: 4521
	public static string TrainingBtnTooltip = "Practice Uberstrike in single player mode.";

	// Token: 0x040011AA RID: 4522
	public static string TrainingTutorialMsg01 = "Welcome to Basic Training!";

	// Token: 0x040011AB RID: 4523
	public static string TrainingTutorialMsg02 = "Press {0} at any time to dismiss these messages.";

	// Token: 0x040011AC RID: 4524
	public static string TrainingTutorialMsg03 = "Ok, let's get started...";

	// Token: 0x040011AD RID: 4525
	public static string TrainingTutorialMsg04 = "You can use the mouse to look around.";

	// Token: 0x040011AE RID: 4526
	public static string TrainingTutorialMsg05 = "Now, use the {0}{1}{2}{3} keys to move your character.";

	// Token: 0x040011AF RID: 4527
	public static string TrainingTutorialMsg06 = "To shoot, use the {0}.";

	// Token: 0x040011B0 RID: 4528
	public static string TrainingTutorialMsg07 = "To select next weapon, use {0}.\nTo select previous weapon, use {1}.";

	// Token: 0x040011B1 RID: 4529
	public static string TrainingTutorialMsg08 = "You can also use\n the {0} {1} {2} {3} keys \n to directly select a weapon.";

	// Token: 0x040011B2 RID: 4530
	public static string TrainingTutorialMsg09 = "To crouch, hold down the {0} key.";

	// Token: 0x040011B3 RID: 4531
	public static string TrainingTutorialMsg10 = "Use {0} to enter full screen mode.";

	// Token: 0x040011B4 RID: 4532
	public static string TrainingTutorialMsg11 = "That's all you need to get started. Good luck!";

	// Token: 0x040011B5 RID: 4533
	public static string TrainingMobileMsg1 = "Swipe your finger to look around.";

	// Token: 0x040011B6 RID: 4534
	public static string TrainingMobileMsg2 = "You can change between multi-finger mode\n and two-thumb mode at any time.";

	// Token: 0x040011B7 RID: 4535
	public static string TrainingMobileMsg3 = "Tap the buttons on screen to control your character.";

	// Token: 0x040011B8 RID: 4536
	public static string TrainingMobileMsg4 = "In multi-finger mode, double tap to zoom your weapon.";

	// Token: 0x040011B9 RID: 4537
	public static string UnassignedKeyMappingsWarningMsg = "There are unassigned key mappings!\nPlease check your Control Settings.";

	// Token: 0x040011BA RID: 4538
	public static string UserInterface = "User Interface";

	// Token: 0x040011BB RID: 4539
	public static string VideoCaps = "VIDEO";

	// Token: 0x040011BC RID: 4540
	public static string WaitingForOtherPlayers = "Waiting for other players...";

	// Token: 0x040011BD RID: 4541
	public static string WhatHappened = "What happened?";

	// Token: 0x040011BE RID: 4542
	public static string YouAreOnTheBlueTeam = "You are on the Blue Team.";

	// Token: 0x040011BF RID: 4543
	public static string YouAreOnTheRedTeam = "You are on the Red Team.";

	// Token: 0x040011C0 RID: 4544
	public static string YouCannotChangeToATeamWithEqual = "You cannot change to a team\nwith equal or more players.";

	// Token: 0x040011C1 RID: 4545
	public static string YouKilledN = "you killed {0}.";

	// Token: 0x040011C2 RID: 4546
	public static string YouShotNInTheHead = "You shot {0} in the head.";

	// Token: 0x040011C3 RID: 4547
	public static string YouShotNInTheNuts = "You shot {0} in the nuts.";

	// Token: 0x040011C4 RID: 4548
	public static string YouSmackedDownN = "You smacked down {0}.";

	// Token: 0x040011C5 RID: 4549
	public static string General = "General";

	// Token: 0x040011C6 RID: 4550
	public static string Home = "Home";

	// Token: 0x040011C7 RID: 4551
	public static string HomeHelpDesc = "The Home Screen is where you are when you first launch UberStrike. From here you can join games, create games or chat with friends.";

	// Token: 0x040011C8 RID: 4552
	public static string Introduction = "Introduction";

	// Token: 0x040011C9 RID: 4553
	public static string IntroHelpDesc = "UberStrike is a 3D multiplayer first person shooter (FPS) game. This means that you are looking through the eyes of a character, and you are playing in a game world with other players.\n\nUberStrike is, first and foremost, an action game, where the objective is to eliminate as many players as possible using the weapons available to you.\n\nUberStrike is played in a fully 3D environment that you can enjoy with your friends. You can explore, fight, chat, and form clans with your friends in the game. As you play UberStrike, you earn points, which you can use to customize your character and buy new items.";

	// Token: 0x040011CA RID: 4554
	public static string Items = "Items";

	// Token: 0x040011CB RID: 4555
	public static string Play = "Play";

	// Token: 0x040011CC RID: 4556
	public static string PlayHelpDesc = "The Play Screen is where you can join active games. It is home to the Game List, which is a detailed view of all UberStrike games that are currently being played. Here you can view current players in the game and see your ping time to the game (measured in ms), which is a determinant of network performance. Lower ping is better.";

	// Token: 0x040011CD RID: 4557
	public static string Shop = "Shop";

	// Token: 0x040011CE RID: 4558
	public static string ShopHelpDesc = "The shop is where you can buy items, including weapons and gear. The shop is divided into three parts: your Loadout, your Inventory, and the Shop.";

	// Token: 0x040011CF RID: 4559
	public static string Profile = "Profile";

	// Token: 0x040011D0 RID: 4560
	public static string ProfileHelpDesc = "The Profile Screen is where you can view your personal performance in UberStrike and compare your performance to other players. Performance is divided into Personal Records, which has your best 'per-life' stats, and Weapon Stats, which shows information on how you’ve performed with each class of weapon.";

	// Token: 0x040011D1 RID: 4561
	public static string GunsNStuffCaps = "GUNS N STUFF";

	// Token: 0x040011D2 RID: 4562
	public static string MainMenuPlayTooltip = "Instantly connect to a game with other\nplayers of a similar level and kick ass!";

	// Token: 0x040011D3 RID: 4563
	public static string MainMenuQuitTooltip = "Quit Uberstrike.";

	// Token: 0x040011D4 RID: 4564
	public static string MainMenuShopTooltip = "Grab some weapons of mass destruction\nbefore facing off with your opponents.";

	// Token: 0x040011D5 RID: 4565
	public static string MainMenuTrainTooltip = "Learn how to play Uberstrike and avoid pwnage.\nTraining is single player.";

	// Token: 0x040011D6 RID: 4566
	public static string FindingAServerToJoin = "Finding a server to join...";

	// Token: 0x040011D7 RID: 4567
	public static string LostParadise2 = "Lost Paradise 2";

	// Token: 0x040011D8 RID: 4568
	public static string MonkeyIsland2 = "Monkey Island 2";

	// Token: 0x040011D9 RID: 4569
	public static string TemplOfTheRaven = "Temple of the Raven";

	// Token: 0x040011DA RID: 4570
	public static string TheWarehouse = "The Warehouse";

	// Token: 0x040011DB RID: 4571
	public static string Week = "Week";

	// Token: 0x040011DC RID: 4572
	public static string Month = "Month";

	// Token: 0x040011DD RID: 4573
	public static string ThreeMonths = "3 Months";

	// Token: 0x040011DE RID: 4574
	public static string Off = "Off";

	// Token: 0x040011DF RID: 4575
	public static string MIDescriptionMsg = "The last resting place of the feared pirate Captain Bradford Pegleg. This forgotten island is rumoured to be home to Bradford's Treasure and was once a place of worship for the tribe of the Monkey King.";

	// Token: 0x040011E0 RID: 4576
	public static string LPDescriptionMsg = "A group of islands located just off the coast of Costa Rica, the Paradise Islands are a great hunting ground for privateers with a keen eye for sniping. Two towering volcanic pillars provide the perfect lookout for those able to make it there in one piece.";

	// Token: 0x040011E1 RID: 4577
	public static string TWDescriptionMsg = "Used by RAID Corporation for the storage of weapons and other experimental technology, the Warehouse is a fast paced arena for short range fire fights. Only for privateers who can handle the adrenaline hit.";

	// Token: 0x040011E2 RID: 4578
	public static string TORDescriptionMsg = "The mighty ravens watch over the temple as privateers try their luck at unlocking the secrets to the inner sanctum. Great for mid range gameplay.";

	// Token: 0x040011E3 RID: 4579
	public static string GTDescriptionMsg = "Brave the heights of Gideons Tower, situated in the heart of Ubercity One. Beware, for a fall from its narrow ledges means certain death for any privateer.";

	// Token: 0x040011E4 RID: 4580
	public static string FWDescriptionMsg = "Created by: Team Cmune\nFort Winter is a small, intense map designed for furious team elimination gameplay. Best played with 6 players per team.";

	// Token: 0x040011E5 RID: 4581
	public static string SGDescriptionMsg = "Created by: Team Cmune\nSky Garden is a wide open map that forces players to tread carefully and take cannon shots with care lest they fall off the edge of the map.";

	// Token: 0x040011E6 RID: 4582
	public static string DMModeDescriptionMsg = "Shoot anything that moves. The player with the most kills at the end of the round wins.";

	// Token: 0x040011E7 RID: 4583
	public static string TDMModeDescriptionMsg = "Shoot anyone not on your team. The team with the most kills at the end of the round wins.";

	// Token: 0x040011E8 RID: 4584
	public static string ELMModeDescriptionMsg = "Eliminate all players on the enemy team. The team with players standing at the end of the round wins.";

	// Token: 0x040011E9 RID: 4585
	public static string Effects = "Effects";

	// Token: 0x040011EA RID: 4586
	public static string ScreenResolution = "Screen Resolution";

	// Token: 0x040011EB RID: 4587
	public static string MaxRounds = "Max Rounds";

	// Token: 0x040011EC RID: 4588
	public static string MaxKills = "Max Kills";

	// Token: 0x040011ED RID: 4589
	public static string NewItem = "New Item";

	// Token: 0x040011EE RID: 4590
	public static string NotNow = "Not now";

	// Token: 0x040011EF RID: 4591
	public static string Congratulations = "Congratulations";

	// Token: 0x040011F0 RID: 4592
	public static string YouHaveBeenGrantedNItems = "You have been granted {0} free items! Go to your inventory to equip them!";

	// Token: 0x040011F1 RID: 4593
	public static string NoItems = "There are no items";

	// Token: 0x040011F2 RID: 4594
	public static string NoDescriptionAvailable = "No description available.";

	// Token: 0x040011F3 RID: 4595
	public static string Default = "Default";

	// Token: 0x040011F4 RID: 4596
	public static string EliminateAllYourEnemies = "Eliminate all your enemies!";

	// Token: 0x040011F5 RID: 4597
	public static string FinalRoundCaps = "FINAL ROUND";

	// Token: 0x040011F6 RID: 4598
	public static string FinalRoundX = "Final Round {0}";

	// Token: 0x040011F7 RID: 4599
	public static string NRoundsLeft = "{0} Rounds Left!";

	// Token: 0x040011F8 RID: 4600
	public static string RedCaps = "RED";

	// Token: 0x040011F9 RID: 4601
	public static string BlueCaps = "BLUE";

	// Token: 0x040011FA RID: 4602
	public static string Following = "Following";

	// Token: 0x040011FB RID: 4603
	public static string Nobody = "Nobody";

	// Token: 0x040011FC RID: 4604
	public static string SpectatorMode = "Spectator Mode";

	// Token: 0x040011FD RID: 4605
	public static string YouAreNotLoggedIn = "You are not logged in!";

	// Token: 0x040011FE RID: 4606
	public static string UpdateAvailable = "Update Available";

	// Token: 0x040011FF RID: 4607
	public static string UberStrikeIsOutOfDatePleaseRefreshPage = "UberStrike v{0} is out of date.\nRefresh your browser window to update to v{1}!";

	// Token: 0x04001200 RID: 4608
	public static string UberStrikeIsOutOfDatePleaseDownloadClient = "UberStrike v{0} out of date, latest is v{1}.\nDownload the new client from:\n{2}";

	// Token: 0x04001201 RID: 4609
	public static string UberStrikeIsOutOfDateVisitWebsite = "UberStrike v{0} out of date.\nVisit UberStrike.com to get v{1}!";

	// Token: 0x04001202 RID: 4610
	public static string UberStrikeIsOutOfDateUpdateMacApp = "UberStrike v{0} out of date, latest is v{1}.\nPlease update from the Mac App Store.";

	// Token: 0x04001203 RID: 4611
	public static string ConnectionProblem = "Connection Problem";

	// Token: 0x04001204 RID: 4612
	public static string ErrorInternetConnection = "No active internet connection detected.\nAn internet connection is required to play UberStrike.\nPlease check your connection and try again.";

	// Token: 0x04001205 RID: 4613
	public static string ErrorWebservices = "There seems to be a problem with our service. Please restart Uberstrike and try to sign in again. If this problem persists please visit support.uberstrike.com. Thank you!";

	// Token: 0x04001206 RID: 4614
	public static string ErrorReadingConfiguration = "Error Reading Configuration";

	// Token: 0x04001207 RID: 4615
	public static string ThereWasProblemRetrievingWebplayerConfiguration = "There was a problem retrieving the webplayer configuration. Please email support.uberstrike.com";

	// Token: 0x04001208 RID: 4616
	public static string RefreshWallet = "Refresh Wallet";

	// Token: 0x04001209 RID: 4617
	public static string IfYouPurchasedCreditsClickOKToRefreshYourWallet = "If you purchased credits, click OK to refresh your wallet and inventory.";

	// Token: 0x0400120A RID: 4618
	public static string ClanInvite = "Clan Invite";

	// Token: 0x0400120B RID: 4619
	public static string YouAlreadyInClanMsg = "You are already in a clan. You cannot join\nanother clan until you leave your current clan.";

	// Token: 0x0400120C RID: 4620
	public static string Hits = "Hits";

	// Token: 0x0400120D RID: 4621
	public static string GideonsTower = "Gideons Tower";

	// Token: 0x0400120E RID: 4622
	public static string SkyGarden = "SkyGarden";

	// Token: 0x0400120F RID: 4623
	public static string FortWinter = "FortWinter";

	// Token: 0x04001210 RID: 4624
	public static string AqualabResearchHub = "Aqualab Research Hub";

	// Token: 0x04001211 RID: 4625
	public static string CuberStrike = "CuberStrike";

	// Token: 0x04001212 RID: 4626
	public static string TuberStrike = "TuberStrike";

	// Token: 0x04001213 RID: 4627
	public static string AccountHistory = "Account History";

	// Token: 0x04001214 RID: 4628
	public static string RecommendedLoadoutCaps = "RECOMMENDED LOADOUT";

	// Token: 0x04001215 RID: 4629
	public static string MostEfficientWeaponCaps = "MOST EFFICIENT WEAPON";

	// Token: 0x04001216 RID: 4630
	public static string RecommendedArmorCaps = "RECOMMENDED ARMOR";

	// Token: 0x04001217 RID: 4631
	public static string StaffPickCaps = "STAFF PICK";

	// Token: 0x04001218 RID: 4632
	public static string RecommendedWeaponCaps = "RECOMMENDED WEAPON";

	// Token: 0x04001219 RID: 4633
	public static string UseMultiTouchInput = "Use Multi-touch input";

	// Token: 0x0400121A RID: 4634
	public static string LookSensitivity = "Look Sensitivity";

	// Token: 0x0400121B RID: 4635
	public static string JoystickSensitivity = "Joystick Sensitivity";

	// Token: 0x0400121C RID: 4636
	public static string TouchInput = "Touch Input";

	// Token: 0x0400121D RID: 4637
	public static string ControlStyle = "Control Style";

	// Token: 0x0400121E RID: 4638
	public static string PackOneAmount = "10 Uses";

	// Token: 0x0400121F RID: 4639
	public static string PackTwoAmount = "100 Uses";

	// Token: 0x04001220 RID: 4640
	public static string PackThreeAmount = "1000 Uses";

	// Token: 0x04001221 RID: 4641
	public static string DiscountPercentOff = "{0}% Off!";

	// Token: 0x04001222 RID: 4642
	public static string NonMobileServer = "Warning! The server you are joining has players from the desktop version of UberStrike. You may get owned.";

	// Token: 0x04001223 RID: 4643
	public static string MobileGameMoreThan6Players = "Warning! UberStrike on mobile is optimized for games with 6 players or less. Your game may run slowly.";

	// Token: 0x04001224 RID: 4644
	public static string MessageQuickItemsTry = "QuickItems will not be consumed in this training mode";

	// Token: 0x04001225 RID: 4645
	public static string TapToRespawn = "Tap to Respawn!";

	// Token: 0x04001226 RID: 4646
	public static string TooltipForgotPassword = "Did you forget your password?\nFear not, we can resend it via email!";

	// Token: 0x04001227 RID: 4647
	public static string CreateNewAccount = "Create a brand new account.";

	// Token: 0x04001228 RID: 4648
	public static string TooltipFacebookAccount = "If you already play UberStrike on Facebook,\nget your email and password set up.";

	// Token: 0x04001229 RID: 4649
	public static string ErrorEmailIsEmpty = "The email address or password you are trying to use is empty.";

	// Token: 0x0400122A RID: 4650
	public static string ErrorProblemLoadingUberStrike = "There was a problem loading UberStrike. Please check your internet connection and try again.";

	// Token: 0x0400122B RID: 4651
	public static string LoadingFriendsList = "Loading Friends List";

	// Token: 0x0400122C RID: 4652
	public static string LoadingCharacterData = "Loading Character Data";

	// Token: 0x0400122D RID: 4653
	public static string ErrorLoadingData = "There was an error loading player level data.";

	// Token: 0x0400122E RID: 4654
	public static string LoadingNewsFeed = "Loading News Feeds";

	// Token: 0x0400122F RID: 4655
	public static string ErrorLoadingNewsFeed = "There was an error getting the latest news.";

	// Token: 0x04001230 RID: 4656
	public static string LoadingMapData = "Loading Map Data";

	// Token: 0x04001231 RID: 4657
	public static string ErrorLoadingMaps = "There was an error loading the maps.";

	// Token: 0x04001232 RID: 4658
	public static string ErrorLoadingMapsSupport = "There was an error getting the Maps.\nPlease visit support.uberstrike.com";

	// Token: 0x04001233 RID: 4659
	public static string LoadingWeaponAndGear = "Loading Weapons and Gear";

	// Token: 0x04001234 RID: 4660
	public static string ErrorGettingShopData = "Error Getting Shop Data";

	// Token: 0x04001235 RID: 4661
	public static string ErrorGettingShopDataSupport = "There was an error getting the Shop Data.\nPlease visit support.uberstrike.com";

	// Token: 0x04001236 RID: 4662
	public static string LoadingPlayerInventory = "Loading Player Inventory";

	// Token: 0x04001237 RID: 4663
	public static string ErrorLoadingPlayerInventory = "It looks like you're trying to login with an old account.\nPlease visit support.uberstrike.com to upgrade.";

	// Token: 0x04001238 RID: 4664
	public static string GettingPlayerLoadout = "Getting Player Loadout";

	// Token: 0x04001239 RID: 4665
	public static string ErrorGettingPlayerLoadout = "Error Getting Player Loadout";

	// Token: 0x0400123A RID: 4666
	public static string ErrorGettingPlayerLoadoutSupport = "There was an error getting the Player Loadout.\nPlease visit support.uberstrike.com";

	// Token: 0x0400123B RID: 4667
	public static string LoadingPlayerStatistics = "Loading Player Statistics";

	// Token: 0x0400123C RID: 4668
	public static string ErrorGettingPlayerStatistics = "Error Getting Player Statistics";

	// Token: 0x0400123D RID: 4669
	public static string ErrorPlayerStatisticsSupport = "There was an error getting the Player Statistics.\nPlease visit support.uberstrike.com";

	// Token: 0x0400123E RID: 4670
	public static string LoadingClanData = "Loading Clan Data";

	// Token: 0x0400123F RID: 4671
	public static string ClaimYourDailyLuck = "CLAIM YOUR DAILY LUCK";

	// Token: 0x04001240 RID: 4672
	public static string LuckyDrawHelpText = "Try your luck at winning one of the prizes above!\nBe careful not to play for items you already own permanently!";

	// Token: 0x04001241 RID: 4673
	public static string LuckyDrawWinningsInInventory = "You find your winnings in the inventory!";

	// Token: 0x04001242 RID: 4674
	public static string PlayAgainCaps = "PLAY AGAIN";

	// Token: 0x04001243 RID: 4675
	public static string DoneCaps = "DONE";

	// Token: 0x04001244 RID: 4676
	public static string Ammo = "Ammo";

	// Token: 0x04001245 RID: 4677
	public static string Radius = "Radius";

	// Token: 0x04001246 RID: 4678
	public static string ArmorCarried = "Armor Carried";

	// Token: 0x04001247 RID: 4679
	public static string NDaysLeft;

	// Token: 0x04001248 RID: 4680
	public static string LevelRequired;

	// Token: 0x04001249 RID: 4681
	public static string CriticalHitBonus;

	// Token: 0x0400124A RID: 4682
	public static string Instant;

	// Token: 0x0400124B RID: 4683
	public static string Unlimited;

	// Token: 0x0400124C RID: 4684
	public static string HealthColon;

	// Token: 0x0400124D RID: 4685
	public static string AmmoColon;

	// Token: 0x0400124E RID: 4686
	public static string ArmorColon;

	// Token: 0x0400124F RID: 4687
	public static string DamageColon;

	// Token: 0x04001250 RID: 4688
	public static string RadiusColon;

	// Token: 0x04001251 RID: 4689
	public static string ForceColon;

	// Token: 0x04001252 RID: 4690
	public static string LifetimeColon;

	// Token: 0x04001253 RID: 4691
	public static string WarmupColon;

	// Token: 0x04001254 RID: 4692
	public static string CooldownColon;

	// Token: 0x04001255 RID: 4693
	public static string UsesPerLifeColon;

	// Token: 0x04001256 RID: 4694
	public static string UsesPerGameColon;

	// Token: 0x04001257 RID: 4695
	public static string TimeColon;

	// Token: 0x04001258 RID: 4696
	public static string Help;

	// Token: 0x04001259 RID: 4697
	public static string Otions;

	// Token: 0x0400125A RID: 4698
	public static string Audio;

	// Token: 0x0400125B RID: 4699
	public static string Windowed;

	// Token: 0x0400125C RID: 4700
	public static string FullscreenOnly;

	// Token: 0x0400125D RID: 4701
	public static string Custom;

	// Token: 0x0400125E RID: 4702
	public static string ChangingScreenResolution;

	// Token: 0x0400125F RID: 4703
	public static string ChooseNewResolution;

	// Token: 0x04001260 RID: 4704
	public static string Auto;

	// Token: 0x04001261 RID: 4705
	public static string TargetFramerate;

	// Token: 0x04001262 RID: 4706
	public static string MaxQueuedFrames;

	// Token: 0x04001263 RID: 4707
	public static string SettingsTakeEffectAfterReloading;

	// Token: 0x04001264 RID: 4708
	public static string TextureQuality;

	// Token: 0x04001265 RID: 4709
	public static string VSync;

	// Token: 0x04001266 RID: 4710
	public static string AntiAliasing;

	// Token: 0x04001267 RID: 4711
	public static string Options;

	// Token: 0x04001268 RID: 4712
	public static string MysteryBox;

	// Token: 0x04001269 RID: 4713
	public static string Packs;

	// Token: 0x0400126A RID: 4714
	public static string TransferCaps;

	// Token: 0x0400126B RID: 4715
	public static string PromoteCaps;

	// Token: 0x0400126C RID: 4716
	public static string DemoteCaps;

	// Token: 0x0400126D RID: 4717
	public static string DisbandCaps;

	// Token: 0x0400126E RID: 4718
	public static string YourClan;

	// Token: 0x0400126F RID: 4719
	public static string ExploreMaps;

	// Token: 0x04001270 RID: 4720
	public static string MobileGameMoreThan8Players;

	// Token: 0x04001271 RID: 4721
	public static string HereYouCanCreateYourOwnClanFacebook;

	// Token: 0x04001272 RID: 4722
	public static string TOTAL;

	// Token: 0x04001273 RID: 4723
	public static string Boost;

	// Token: 0x04001274 RID: 4724
	public static string SkillBonus;

	// Token: 0x04001275 RID: 4725
	public static string SharePhotoFacebook;

	// Token: 0x04001276 RID: 4726
	public static string SharePhotoIPad;

	// Token: 0x04001277 RID: 4727
	public static string ScreenshotTaken;

	// Token: 0x04001EB2 RID: 7858
	public static string ArmorDestroyed = "Armor Destroyed";

	// Token: 0x04001EB3 RID: 7859
	public static string ArmorPierced = "Armor Pierced";
}
