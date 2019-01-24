using System;
using System.Collections.Generic;
using System.IO;
using UberStrike.Core.Models;
using UberStrike.Core.Serialization;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000320 RID: 800
	public sealed class LobbyRoomOperations : IOperationSender
	{
		// Token: 0x0600125B RID: 4699 RVA: 0x0000BC9A File Offset: 0x00009E9A
		public LobbyRoomOperations(byte id = 0)
		{
			this.__id = id;
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600125C RID: 4700 RVA: 0x0000BCA9 File Offset: 0x00009EA9
		// (remove) Token: 0x0600125D RID: 4701 RVA: 0x0000BCC2 File Offset: 0x00009EC2
		public event RemoteProcedureCall SendOperation
		{
			add
			{
				this.sendOperation = (RemoteProcedureCall)Delegate.Combine(this.sendOperation, value);
			}
			remove
			{
				this.sendOperation = (RemoteProcedureCall)Delegate.Remove(this.sendOperation, value);
			}
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x0001E6E8 File Offset: 0x0001C8E8
		public void SendFullPlayerListUpdate()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(1, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x0001E754 File Offset: 0x0001C954
		public void SendUpdatePlayerRoom(GameRoom room)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				GameRoomProxy.Serialize(memoryStream, room);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(2, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x0001E7C8 File Offset: 0x0001C9C8
		public void SendResetPlayerRoom()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(3, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x0001E834 File Offset: 0x0001CA34
		public void SendUpdateFriendsList(int cmid)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(4, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x0001E8A8 File Offset: 0x0001CAA8
		public void SendUpdateClanData(int cmid)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(5, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x0001E91C File Offset: 0x0001CB1C
		public void SendUpdateInboxMessages(int cmid, int messageId)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Int32Proxy.Serialize(memoryStream, messageId);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(6, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x0001E998 File Offset: 0x0001CB98
		public void SendUpdateInboxRequests(int cmid)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(7, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x0001EA0C File Offset: 0x0001CC0C
		public void SendUpdateClanMembers(List<int> clanMembers)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ListProxy<int>.Serialize(memoryStream, clanMembers, new ListProxy<int>.Serializer<int>(Int32Proxy.Serialize));
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(8, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x0001EA8C File Offset: 0x0001CC8C
		public void SendGetPlayersWithMatchingName(string search)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, search);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(9, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x0001EB00 File Offset: 0x0001CD00
		public void SendChatMessageToAll(string message)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, message);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(10, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x0001EB74 File Offset: 0x0001CD74
		public void SendChatMessageToPlayer(int cmid, string message)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				StringProxy.Serialize(memoryStream, message);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(11, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x0001EBF0 File Offset: 0x0001CDF0
		public void SendChatMessageToClan(List<int> clanMembers, string message)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ListProxy<int>.Serialize(memoryStream, clanMembers, new ListProxy<int>.Serializer<int>(Int32Proxy.Serialize));
				StringProxy.Serialize(memoryStream, message);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(12, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x0001EC78 File Offset: 0x0001CE78
		public void SendModerationMutePlayer(int durationInMinutes, int mutedCmid, bool disableChat)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, durationInMinutes);
				Int32Proxy.Serialize(memoryStream, mutedCmid);
				BooleanProxy.Serialize(memoryStream, disableChat);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(13, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x0600126B RID: 4715 RVA: 0x0001ECFC File Offset: 0x0001CEFC
		public void SendModerationPermanentBan(int cmid)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(14, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x0001ED70 File Offset: 0x0001CF70
		public void SendModerationBanPlayer(int cmid)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(15, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x0001EDE4 File Offset: 0x0001CFE4
		public void SendModerationKickGame(int cmid)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(16, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x0001EE58 File Offset: 0x0001D058
		public void SendModerationUnbanPlayer(int cmid)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(17, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x0600126F RID: 4719 RVA: 0x0001EECC File Offset: 0x0001D0CC
		public void SendModerationCustomMessage(int cmid, string message)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				StringProxy.Serialize(memoryStream, message);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(18, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001270 RID: 4720 RVA: 0x0001EF48 File Offset: 0x0001D148
		public void SendSpeedhackDetection()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(19, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x0001EFB4 File Offset: 0x0001D1B4
		public void SendSpeedhackDetectionNew(List<float> timeDifferences)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ListProxy<float>.Serialize(memoryStream, timeDifferences, new ListProxy<float>.Serializer<float>(SingleProxy.Serialize));
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(20, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x0001F034 File Offset: 0x0001D234
		public void SendPlayersReported(List<int> cmids, int type, string details, string logs)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ListProxy<int>.Serialize(memoryStream, cmids, new ListProxy<int>.Serializer<int>(Int32Proxy.Serialize));
				Int32Proxy.Serialize(memoryStream, type);
				StringProxy.Serialize(memoryStream, details);
				StringProxy.Serialize(memoryStream, logs);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(21, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001273 RID: 4723 RVA: 0x0001F0CC File Offset: 0x0001D2CC
		public void SendUpdateNaughtyList()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(22, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x0001F138 File Offset: 0x0001D338
		public void SendClearModeratorFlags(int cmid)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(23, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x0001F1AC File Offset: 0x0001D3AC
		public void SendSetContactList(List<int> cmids)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ListProxy<int>.Serialize(memoryStream, cmids, new ListProxy<int>.Serializer<int>(Int32Proxy.Serialize));
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(24, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001276 RID: 4726 RVA: 0x0001F22C File Offset: 0x0001D42C
		public void SendUpdateAllActors()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(25, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x0001F298 File Offset: 0x0001D498
		public void SendUpdateContacts()
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>
				{
					{
						this.__id,
						memoryStream.ToArray()
					}
				};
				if (this.sendOperation != null)
				{
					this.sendOperation(26, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x04000D20 RID: 3360
		private byte __id;

		// Token: 0x04000D21 RID: 3361
		private RemoteProcedureCall sendOperation;
	}
}
