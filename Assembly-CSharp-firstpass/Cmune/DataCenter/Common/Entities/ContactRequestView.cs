using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000049 RID: 73
	[Serializable]
	public class ContactRequestView
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00002050 File Offset: 0x00000250
		public ContactRequestView()
		{
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000282C File Offset: 0x00000A2C
		public ContactRequestView(int initiatorCmid, int receiverCmid, string initiatorMessage)
		{
			this.InitiatorCmid = initiatorCmid;
			this.ReceiverCmid = receiverCmid;
			this.InitiatorMessage = initiatorMessage;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00002849 File Offset: 0x00000A49
		public ContactRequestView(int requestID, int initiatorCmid, string initiatorName, int receiverCmid, string initiatorMessage, ContactRequestStatus status, DateTime sentDate)
		{
			this.SetContactRequest(requestID, initiatorCmid, initiatorName, receiverCmid, initiatorMessage, status, sentDate);
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00002862 File Offset: 0x00000A62
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x0000286A File Offset: 0x00000A6A
		public int RequestId { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00002873 File Offset: 0x00000A73
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x0000287B File Offset: 0x00000A7B
		public int InitiatorCmid { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00002884 File Offset: 0x00000A84
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x0000288C File Offset: 0x00000A8C
		public string InitiatorName { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00002895 File Offset: 0x00000A95
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x0000289D File Offset: 0x00000A9D
		public int ReceiverCmid { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x000028A6 File Offset: 0x00000AA6
		// (set) Token: 0x060000FA RID: 250 RVA: 0x000028AE File Offset: 0x00000AAE
		public string InitiatorMessage { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000FB RID: 251 RVA: 0x000028B7 File Offset: 0x00000AB7
		// (set) Token: 0x060000FC RID: 252 RVA: 0x000028BF File Offset: 0x00000ABF
		public ContactRequestStatus Status { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000FD RID: 253 RVA: 0x000028C8 File Offset: 0x00000AC8
		// (set) Token: 0x060000FE RID: 254 RVA: 0x000028D0 File Offset: 0x00000AD0
		public DateTime SentDate { get; set; }

		// Token: 0x060000FF RID: 255 RVA: 0x000028D9 File Offset: 0x00000AD9
		public void SetContactRequest(int requestID, int initiatorCmid, string initiatorName, int receiverCmid, string initiatorMessage, ContactRequestStatus status, DateTime sentDate)
		{
			this.RequestId = requestID;
			this.InitiatorCmid = initiatorCmid;
			this.InitiatorName = initiatorName;
			this.ReceiverCmid = receiverCmid;
			this.InitiatorMessage = initiatorMessage;
			this.Status = status;
			this.SentDate = sentDate;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000D59C File Offset: 0x0000B79C
		public override string ToString()
		{
			string text = string.Concat(new object[]
			{
				"[Request contact: [Request ID: ",
				this.RequestId,
				"][Initiator Cmid :",
				this.InitiatorCmid,
				"][Initiator Name:",
				this.InitiatorName,
				"][Receiver Cmid: ",
				this.ReceiverCmid,
				"]"
			});
			string text2 = text;
			return string.Concat(new object[]
			{
				text2,
				"[Initiator Message: ",
				this.InitiatorMessage,
				"][Status: ",
				this.Status,
				"][Sent Date: ",
				this.SentDate,
				"]]"
			});
		}
	}
}
