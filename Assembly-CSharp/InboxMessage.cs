using System;
using Cmune.DataCenter.Common.Entities;

// Token: 0x0200019C RID: 412
public class InboxMessage
{
	// Token: 0x06000B49 RID: 2889 RVA: 0x00008ECB File Offset: 0x000070CB
	public InboxMessage(PrivateMessageView view, string senderName)
	{
		this.MessageView = view;
		this.SenderName = senderName;
	}

	// Token: 0x170002F6 RID: 758
	// (get) Token: 0x06000B4A RID: 2890 RVA: 0x00008EE1 File Offset: 0x000070E1
	public bool IsMine
	{
		get
		{
			return this.MessageView.FromCmid == PlayerDataManager.Cmid;
		}
	}

	// Token: 0x170002F7 RID: 759
	// (get) Token: 0x06000B4B RID: 2891 RVA: 0x00008EF5 File Offset: 0x000070F5
	public bool IsAdmin
	{
		get
		{
			return this.MessageView.FromCmid == 767;
		}
	}

	// Token: 0x170002F8 RID: 760
	// (get) Token: 0x06000B4C RID: 2892 RVA: 0x00008F09 File Offset: 0x00007109
	public string Content
	{
		get
		{
			return this.MessageView.ContentText;
		}
	}

	// Token: 0x170002F9 RID: 761
	// (get) Token: 0x06000B4D RID: 2893 RVA: 0x00047C70 File Offset: 0x00045E70
	public string SentDateString
	{
		get
		{
			return string.Concat(new string[]
			{
				this.MessageView.DateSent.ToString("MMM"),
				" ",
				this.MessageView.DateSent.Day.ToString(),
				" at ",
				this.MessageView.DateSent.ToShortTimeString()
			});
		}
	}

	// Token: 0x170002FA RID: 762
	// (get) Token: 0x06000B4E RID: 2894 RVA: 0x00008F16 File Offset: 0x00007116
	// (set) Token: 0x06000B4F RID: 2895 RVA: 0x00008F1E File Offset: 0x0000711E
	public string SenderName { get; private set; }

	// Token: 0x170002FB RID: 763
	// (get) Token: 0x06000B50 RID: 2896 RVA: 0x00008F27 File Offset: 0x00007127
	// (set) Token: 0x06000B51 RID: 2897 RVA: 0x00008F2F File Offset: 0x0000712F
	public PrivateMessageView MessageView { get; private set; }
}
