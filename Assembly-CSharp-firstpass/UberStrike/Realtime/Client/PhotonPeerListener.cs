using System;
using System.Runtime.Serialization;
using ExitGames.Client.Photon;
using UnityEngine;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000354 RID: 852
	public sealed class PhotonPeerListener : IPhotonPeerListener
	{
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06001422 RID: 5154 RVA: 0x0000C50B File Offset: 0x0000A70B
		// (remove) Token: 0x06001423 RID: 5155 RVA: 0x0000C524 File Offset: 0x0000A724
		public event Action<byte, byte[]> EventDispatcher
		{
			add
			{
				this.eventDispatcher = (Action<byte, byte[]>)Delegate.Combine(this.eventDispatcher, value);
			}
			remove
			{
				this.eventDispatcher = (Action<byte, byte[]>)Delegate.Remove(this.eventDispatcher, value);
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06001424 RID: 5156 RVA: 0x0000C53D File Offset: 0x0000A73D
		// (remove) Token: 0x06001425 RID: 5157 RVA: 0x0000C556 File Offset: 0x0000A756
		public event Action OnConnect
		{
			add
			{
				this.onConnect = (Action)Delegate.Combine(this.onConnect, value);
			}
			remove
			{
				this.onConnect = (Action)Delegate.Remove(this.onConnect, value);
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06001426 RID: 5158 RVA: 0x0000C56F File Offset: 0x0000A76F
		// (remove) Token: 0x06001427 RID: 5159 RVA: 0x0000C588 File Offset: 0x0000A788
		public event Action<StatusCode> OnDisconnect
		{
			add
			{
				this.onDisconnect = (Action<StatusCode>)Delegate.Combine(this.onDisconnect, value);
			}
			remove
			{
				this.onDisconnect = (Action<StatusCode>)Delegate.Remove(this.onDisconnect, value);
			}
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06001428 RID: 5160 RVA: 0x0000C5A1 File Offset: 0x0000A7A1
		// (remove) Token: 0x06001429 RID: 5161 RVA: 0x0000C5BA File Offset: 0x0000A7BA
		public event Action<string> OnError
		{
			add
			{
				this.onError = (Action<string>)Delegate.Combine(this.onError, value);
			}
			remove
			{
				this.onError = (Action<string>)Delegate.Remove(this.onError, value);
			}
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x0000C5D3 File Offset: 0x0000A7D3
		internal void ClearEvents()
		{
			this.eventDispatcher = null;
			this.onConnect = null;
			this.onDisconnect = null;
			this.onError = null;
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x00024534 File Offset: 0x00022734
		public void OnEvent(EventData eventData)
		{
			try
			{
				if (this.eventDispatcher != null)
				{
					this.eventDispatcher(eventData.Code, (byte[])eventData.Parameters[0]);
				}
			}
			catch (SerializationException)
			{
				throw;
			}
			catch (Exception ex)
			{
				Debug.LogError("OnEvent failed: " + eventData.ToStringFull() + "\n" + ex.ToString());
				throw ex;
			}
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x000245C0 File Offset: 0x000227C0
		public void OnOperationResponse(OperationResponse operationResponse)
		{
			if (operationResponse.ReturnCode > 0)
			{
				Debug.LogError("OnOperationResponse: " + operationResponse.DebugMessage);
				if (this.onError != null)
				{
					this.onError(operationResponse.DebugMessage);
				}
			}
			else
			{
				Debug.Log("OnOperationResponse: " + operationResponse.OperationCode);
			}
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x0002462C File Offset: 0x0002282C
		public void OnStatusChanged(StatusCode statusCode)
		{
			Debug.Log("PeerStatusCallback " + statusCode);
			switch (statusCode)
			{
			case StatusCode.ExceptionOnConnect:
			case StatusCode.Disconnect:
			case StatusCode.Exception:
				break;
			case StatusCode.Connect:
				if (this.onConnect != null)
				{
					this.onConnect();
				}
				return;
			default:
				switch (statusCode)
				{
				case StatusCode.TimeoutDisconnect:
				case StatusCode.DisconnectByServer:
				case StatusCode.DisconnectByServerUserLimit:
				case StatusCode.DisconnectByServerLogic:
					break;
				default:
					Debug.LogWarning("Unhandled OnStatusChanged " + statusCode);
					return;
				}
				break;
			case StatusCode.SendError:
				Debug.LogWarning("Operation sent without connection to server");
				return;
			}
			if (this.onDisconnect != null)
			{
				this.onDisconnect(statusCode);
			}
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x0000C5F1 File Offset: 0x0000A7F1
		public void DebugReturn(DebugLevel level, string message)
		{
			Debug.Log("DebugReturn " + message);
		}

		// Token: 0x04000E34 RID: 3636
		private Action<byte, byte[]> eventDispatcher;

		// Token: 0x04000E35 RID: 3637
		private Action onConnect;

		// Token: 0x04000E36 RID: 3638
		private Action<StatusCode> onDisconnect;

		// Token: 0x04000E37 RID: 3639
		private Action<string> onError;
	}
}
