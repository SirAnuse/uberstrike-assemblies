using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class GameData
{
	// Token: 0x17000622 RID: 1570
	// (get) Token: 0x06001B92 RID: 7058 RVA: 0x000123E9 File Offset: 0x000105E9
	public static bool CanShowFacebookView
	{
		get
		{
			return ApplicationDataManager.Channel == ChannelType.WebFacebook || ApplicationDataManager.Channel == ChannelType.IPad || Application.isEditor;
		}
	}

	// Token: 0x04001899 RID: 6297
	public static GameData Instance = new GameData();

	// Token: 0x0400189A RID: 6298
	public Property<MainMenuState> MainMenu = new Property<MainMenuState>(MainMenuState.Home);

	// Token: 0x0400189B RID: 6299
	public Property<List<CommActorInfo>> Players = new Property<List<CommActorInfo>>();

	// Token: 0x0400189C RID: 6300
	public Property<bool> IsShopLoaded = new Property<bool>(false);

	// Token: 0x0400189D RID: 6301
	public Property<GameStateId> GameState = new Property<GameStateId>(GameStateId.None);

	// Token: 0x0400189E RID: 6302
	public Property<PlayerStateId> PlayerState = new Property<PlayerStateId>(PlayerStateId.None);

	// Token: 0x0400189F RID: 6303
	public Property<TupleFour<GameActorInfo, GameActorInfo, UberstrikeItemClass, BodyPart>> OnPlayerKilled = new Property<TupleFour<GameActorInfo, GameActorInfo, UberstrikeItemClass, BodyPart>>();

	// Token: 0x040018A0 RID: 6304
	public Property<TupleTwo<string, PickUpMessageType>> OnItemPickup = new Property<TupleTwo<string, PickUpMessageType>>();

	// Token: 0x040018A1 RID: 6305
	public Property<TupleOne<int>> OnRespawnCountdown = new Property<TupleOne<int>>();

	// Token: 0x040018A2 RID: 6306
	public Property<TupleOne<string>> OnNotification = new Property<TupleOne<string>>();

	// Token: 0x040018A3 RID: 6307
	public Property<TupleThree<string, string, float>> OnNotificationFull = new Property<TupleThree<string, string, float>>();

	// Token: 0x040018A4 RID: 6308
	public Property<TupleOne<string>> OnWarningNotification = new Property<TupleOne<string>>();

	// Token: 0x040018A5 RID: 6309
	public Property<TupleThree<GameActorInfo, string, GameActorInfo>> OnHUDStreamMessage = new Property<TupleThree<GameActorInfo, string, GameActorInfo>>();

	// Token: 0x040018A6 RID: 6310
	public Property<Tuple> OnHUDStreamClear = new Property<Tuple>();

	// Token: 0x040018A7 RID: 6311
	public Property<TupleThree<string, string, MemberAccessLevel>> OnHUDChatMessage = new Property<TupleThree<string, string, MemberAccessLevel>>();

	// Token: 0x040018A8 RID: 6312
	public Property<Tuple> OnHUDChatClear = new Property<Tuple>();

	// Token: 0x040018A9 RID: 6313
	public Property<Tuple> OnHUDChatStartTyping = new Property<Tuple>();

	// Token: 0x040018AA RID: 6314
	public bool HUDChatIsTyping;

	// Token: 0x040018AB RID: 6315
	public Property<Tuple> OnQuickItemsChanged = new Property<Tuple>();

	// Token: 0x040018AC RID: 6316
	public Property<TupleTwo<int, float>> OnQuickItemsCooldown = new Property<TupleTwo<int, float>>(new TupleTwo<int, float>(0, 0f));

	// Token: 0x040018AD RID: 6317
	public Property<TupleTwo<int, float>> OnQuickItemsRecharge = new Property<TupleTwo<int, float>>(new TupleTwo<int, float>(0, 0f));

	// Token: 0x040018AE RID: 6318
	public Property<Tuple> VideoShowFps = new Property<Tuple>();

	// Token: 0x040018AF RID: 6319
	public Property<Tuple> OnEndOfMatchTimer = new Property<Tuple>();
}
