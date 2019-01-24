using System;
using System.Collections.Generic;
using System.IO;
using UberStrike.Core.Models;
using UberStrike.Core.Serialization;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000327 RID: 807
	public sealed class GamePeerOperations : IOperationSender
	{
		// Token: 0x060012AF RID: 4783 RVA: 0x0000BD3C File Offset: 0x00009F3C
		public GamePeerOperations(byte id = 0)
		{
			this.__id = id;
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060012B0 RID: 4784 RVA: 0x0000BD4B File Offset: 0x00009F4B
		// (remove) Token: 0x060012B1 RID: 4785 RVA: 0x0000BD64 File Offset: 0x00009F64
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

		// Token: 0x060012B2 RID: 4786 RVA: 0x0001FB2C File Offset: 0x0001DD2C
		public void SendSendHeartbeatResponse(string authToken, string responseHash)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, responseHash);
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

		// Token: 0x060012B3 RID: 4787 RVA: 0x0001FBA8 File Offset: 0x0001DDA8
		public void SendGetServerLoad()
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
					this.sendOperation(2, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x0001FC14 File Offset: 0x0001DE14
		public void SendGetGameInformation(int number)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, number);
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

		// Token: 0x060012B5 RID: 4789 RVA: 0x0001FC88 File Offset: 0x0001DE88
		public void SendGetGameListUpdates()
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
					this.sendOperation(4, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012B6 RID: 4790 RVA: 0x0001FCF4 File Offset: 0x0001DEF4
		public void SendEnterRoom(int roomId, string password, string clientVersion, string authToken, string magicHash)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, roomId);
				StringProxy.Serialize(memoryStream, password);
				StringProxy.Serialize(memoryStream, clientVersion);
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, magicHash);
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

		// Token: 0x060012B7 RID: 4791 RVA: 0x0001FD84 File Offset: 0x0001DF84
		public void SendCreateRoom(GameRoomData metaData, string password, string clientVersion, string authToken, string magicHash)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				GameRoomDataProxy.Serialize(memoryStream, metaData);
				StringProxy.Serialize(memoryStream, password);
				StringProxy.Serialize(memoryStream, clientVersion);
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, magicHash);
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

		// Token: 0x060012B8 RID: 4792 RVA: 0x0001FE14 File Offset: 0x0001E014
		public void SendLeaveRoom()
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
					this.sendOperation(7, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x0001FE80 File Offset: 0x0001E080
		public void SendCloseRoom(int roomId, string authToken, string magicHash)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, roomId);
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, magicHash);
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

		// Token: 0x060012BA RID: 4794 RVA: 0x0001FF00 File Offset: 0x0001E100
		public void SendInspectRoom(int roomId, string authToken)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, roomId);
				StringProxy.Serialize(memoryStream, authToken);
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

		// Token: 0x060012BB RID: 4795 RVA: 0x0001FF7C File Offset: 0x0001E17C
		public void SendReportPlayer(int cmid, string authToken)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				StringProxy.Serialize(memoryStream, authToken);
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

		// Token: 0x060012BC RID: 4796 RVA: 0x0001FFF8 File Offset: 0x0001E1F8
		public void SendKickPlayer(int cmid, string authToken, string magicHash)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, magicHash);
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

		// Token: 0x060012BD RID: 4797 RVA: 0x0002007C File Offset: 0x0001E27C
		public void SendUpdateLoadout()
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
					this.sendOperation(12, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x000200E8 File Offset: 0x0001E2E8
		public void SendUpdatePing(ushort ping)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				UInt16Proxy.Serialize(memoryStream, ping);
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

		// Token: 0x060012BF RID: 4799 RVA: 0x0002015C File Offset: 0x0001E35C
		public void SendUpdateKeyState(byte state)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ByteProxy.Serialize(memoryStream, state);
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

		// Token: 0x060012C0 RID: 4800 RVA: 0x000201D0 File Offset: 0x0001E3D0
		public void SendRefreshBackendData(string authToken, string magicHash)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, magicHash);
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

		// Token: 0x04000D5B RID: 3419
		private byte __id;

		// Token: 0x04000D5C RID: 3420
		private RemoteProcedureCall sendOperation;
	}
}
