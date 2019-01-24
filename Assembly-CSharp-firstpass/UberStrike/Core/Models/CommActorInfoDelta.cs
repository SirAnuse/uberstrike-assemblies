using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Models
{
	// Token: 0x02000284 RID: 644
	public class CommActorInfoDelta
	{
		// Token: 0x1700039C RID: 924
		// (get) Token: 0x060010A8 RID: 4264 RVA: 0x0000AD96 File Offset: 0x00008F96
		// (set) Token: 0x060010A9 RID: 4265 RVA: 0x0000AD9E File Offset: 0x00008F9E
		public int DeltaMask { get; set; }

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x060010AA RID: 4266 RVA: 0x0000ADA7 File Offset: 0x00008FA7
		// (set) Token: 0x060010AB RID: 4267 RVA: 0x0000ADAF File Offset: 0x00008FAF
		public byte Id { get; set; }

		// Token: 0x060010AC RID: 4268 RVA: 0x00015648 File Offset: 0x00013848
		public void Apply(CommActorInfo instance)
		{
			foreach (KeyValuePair<CommActorInfoDelta.Keys, object> keyValuePair in this.Changes)
			{
				switch (keyValuePair.Key)
				{
				case CommActorInfoDelta.Keys.AccessLevel:
					instance.AccessLevel = (MemberAccessLevel)((int)keyValuePair.Value);
					break;
				case CommActorInfoDelta.Keys.Channel:
					instance.Channel = (ChannelType)((int)keyValuePair.Value);
					break;
				case CommActorInfoDelta.Keys.ClanTag:
					instance.ClanTag = (string)keyValuePair.Value;
					break;
				case CommActorInfoDelta.Keys.Cmid:
					instance.Cmid = (int)keyValuePair.Value;
					break;
				case CommActorInfoDelta.Keys.CurrentRoom:
					instance.CurrentRoom = (GameRoom)keyValuePair.Value;
					break;
				case CommActorInfoDelta.Keys.ModerationFlag:
					instance.ModerationFlag = (byte)keyValuePair.Value;
					break;
				case CommActorInfoDelta.Keys.ModInformation:
					instance.ModInformation = (string)keyValuePair.Value;
					break;
				case CommActorInfoDelta.Keys.PlayerName:
					instance.PlayerName = (string)keyValuePair.Value;
					break;
				}
			}
		}

		// Token: 0x04000C77 RID: 3191
		public readonly Dictionary<CommActorInfoDelta.Keys, object> Changes = new Dictionary<CommActorInfoDelta.Keys, object>();

		// Token: 0x02000285 RID: 645
		public enum Keys
		{
			// Token: 0x04000C7B RID: 3195
			AccessLevel,
			// Token: 0x04000C7C RID: 3196
			Channel,
			// Token: 0x04000C7D RID: 3197
			ClanTag,
			// Token: 0x04000C7E RID: 3198
			Cmid,
			// Token: 0x04000C7F RID: 3199
			CurrentRoom,
			// Token: 0x04000C80 RID: 3200
			ModerationFlag,
			// Token: 0x04000C81 RID: 3201
			ModInformation,
			// Token: 0x04000C82 RID: 3202
			PlayerName
		}
	}
}
