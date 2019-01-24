using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

namespace UberStrike.Core.Models
{
	// Token: 0x02000287 RID: 647
	public class GameActorInfoDelta
	{
		// Token: 0x1700039E RID: 926
		// (get) Token: 0x060010B0 RID: 4272 RVA: 0x0000ADCB File Offset: 0x00008FCB
		// (set) Token: 0x060010B1 RID: 4273 RVA: 0x0000ADD3 File Offset: 0x00008FD3
		public int DeltaMask { get; set; }

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x060010B2 RID: 4274 RVA: 0x0000ADDC File Offset: 0x00008FDC
		// (set) Token: 0x060010B3 RID: 4275 RVA: 0x0000ADE4 File Offset: 0x00008FE4
		public byte Id { get; set; }

		// Token: 0x060010B4 RID: 4276 RVA: 0x00015A10 File Offset: 0x00013C10
		public void Apply(GameActorInfo instance)
		{
			foreach (KeyValuePair<GameActorInfoDelta.Keys, object> keyValuePair in this.Changes)
			{
				switch (keyValuePair.Key)
				{
				case GameActorInfoDelta.Keys.AccessLevel:
					instance.AccessLevel = (MemberAccessLevel)((int)keyValuePair.Value);
					break;
				case GameActorInfoDelta.Keys.ArmorPointCapacity:
					instance.ArmorPointCapacity = (byte)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.ArmorPoints:
					instance.ArmorPoints = (byte)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.Channel:
					instance.Channel = (ChannelType)((int)keyValuePair.Value);
					break;
				case GameActorInfoDelta.Keys.ClanTag:
					instance.ClanTag = (string)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.Cmid:
					instance.Cmid = (int)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.CurrentFiringMode:
					instance.CurrentFiringMode = (FireMode)((int)keyValuePair.Value);
					break;
				case GameActorInfoDelta.Keys.CurrentWeaponSlot:
					instance.CurrentWeaponSlot = (byte)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.Deaths:
					instance.Deaths = (short)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.FunctionalItems:
					instance.FunctionalItems = (List<int>)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.Gear:
					instance.Gear = (List<int>)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.Health:
					instance.Health = (short)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.Kills:
					instance.Kills = (short)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.Level:
					instance.Level = (int)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.Ping:
					instance.Ping = (ushort)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.PlayerId:
					instance.PlayerId = (byte)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.PlayerName:
					instance.PlayerName = (string)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.PlayerState:
					instance.PlayerState = (PlayerStates)((byte)keyValuePair.Value);
					break;
				case GameActorInfoDelta.Keys.QuickItems:
					instance.QuickItems = (List<int>)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.Rank:
					instance.Rank = (byte)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.SkinColor:
					instance.SkinColor = (Color)keyValuePair.Value;
					break;
				case GameActorInfoDelta.Keys.StepSound:
					instance.StepSound = (SurfaceType)((int)keyValuePair.Value);
					break;
				case GameActorInfoDelta.Keys.TeamID:
					instance.TeamID = (TeamID)((int)keyValuePair.Value);
					break;
				case GameActorInfoDelta.Keys.Weapons:
					instance.Weapons = (List<int>)keyValuePair.Value;
					break;
				}
			}
		}

		// Token: 0x04000C83 RID: 3203
		public readonly Dictionary<GameActorInfoDelta.Keys, object> Changes = new Dictionary<GameActorInfoDelta.Keys, object>();

		// Token: 0x02000288 RID: 648
		public enum Keys
		{
			// Token: 0x04000C87 RID: 3207
			AccessLevel,
			// Token: 0x04000C88 RID: 3208
			ArmorPointCapacity,
			// Token: 0x04000C89 RID: 3209
			ArmorPoints,
			// Token: 0x04000C8A RID: 3210
			Channel,
			// Token: 0x04000C8B RID: 3211
			ClanTag,
			// Token: 0x04000C8C RID: 3212
			Cmid,
			// Token: 0x04000C8D RID: 3213
			CurrentFiringMode,
			// Token: 0x04000C8E RID: 3214
			CurrentWeaponSlot,
			// Token: 0x04000C8F RID: 3215
			Deaths,
			// Token: 0x04000C90 RID: 3216
			FunctionalItems,
			// Token: 0x04000C91 RID: 3217
			Gear,
			// Token: 0x04000C92 RID: 3218
			Health,
			// Token: 0x04000C93 RID: 3219
			Kills,
			// Token: 0x04000C94 RID: 3220
			Level,
			// Token: 0x04000C95 RID: 3221
			Ping,
			// Token: 0x04000C96 RID: 3222
			PlayerId,
			// Token: 0x04000C97 RID: 3223
			PlayerName,
			// Token: 0x04000C98 RID: 3224
			PlayerState,
			// Token: 0x04000C99 RID: 3225
			QuickItems,
			// Token: 0x04000C9A RID: 3226
			Rank,
			// Token: 0x04000C9B RID: 3227
			SkinColor,
			// Token: 0x04000C9C RID: 3228
			StepSound,
			// Token: 0x04000C9D RID: 3229
			TeamID,
			// Token: 0x04000C9E RID: 3230
			Weapons
		}
	}
}
