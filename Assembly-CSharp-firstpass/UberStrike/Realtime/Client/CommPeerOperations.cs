using System;
using System.Collections.Generic;
using System.IO;
using UberStrike.Core.Serialization;

namespace UberStrike.Realtime.Client
{
	// Token: 0x0200031F RID: 799
	public sealed class CommPeerOperations : IOperationSender
	{
		// Token: 0x06001256 RID: 4694 RVA: 0x0000BC59 File Offset: 0x00009E59
		public CommPeerOperations(byte id = 0)
		{
			this.__id = id;
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06001257 RID: 4695 RVA: 0x0000BC68 File Offset: 0x00009E68
		// (remove) Token: 0x06001258 RID: 4696 RVA: 0x0000BC81 File Offset: 0x00009E81
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

		// Token: 0x06001259 RID: 4697 RVA: 0x0001E5F0 File Offset: 0x0001C7F0
		public void SendAuthenticationRequest(string authToken, string magicHash)
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
					this.sendOperation(1, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x0001E66C File Offset: 0x0001C86C
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
					this.sendOperation(2, customOpParameters, true, 0, false);
				}
			}
		}

		// Token: 0x04000D1E RID: 3358
		private byte __id;

		// Token: 0x04000D1F RID: 3359
		private RemoteProcedureCall sendOperation;
	}
}
