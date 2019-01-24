using System;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020003BC RID: 956
public static class ChatMessageFilter
{
	// Token: 0x06001C04 RID: 7172 RVA: 0x0008EC8C File Offset: 0x0008CE8C
	public static bool IsSpamming(string message)
	{
		bool flag = false;
		bool flag2 = false;
		float num = 0f;
		float num2 = 0f;
		int num3 = 0;
		string value = string.Empty;
		foreach (ChatMessageFilter.Message message2 in ChatMessageFilter._lastMessages)
		{
			if (message2.Time + 5f > Time.time)
			{
				if (message.StartsWith(message2.Text, StringComparison.InvariantCultureIgnoreCase))
				{
					message2.Time = Time.time;
					message2.Count++;
					flag = (message2.Count > 1);
					flag2 = true;
				}
				if (num2 != 0f)
				{
					num += Mathf.Clamp(1f - (message2.Time - num2), 0f, 1f);
					num3++;
				}
			}
			num2 = message2.Time;
			value = message2.Text;
		}
		if (!flag2)
		{
			ChatMessageFilter._lastMessages.Enqueue(new ChatMessageFilter.Message(message));
		}
		if (message.Equals(value, StringComparison.InvariantCultureIgnoreCase) && num2 + 10f > Time.time)
		{
			flag = true;
		}
		if (num3 > 0)
		{
			num /= (float)num3;
		}
		flag |= (num > 0.3f);
		return flag;
	}

	// Token: 0x06001C05 RID: 7173 RVA: 0x00012A09 File Offset: 0x00010C09
	public static string Cleanup(string msg)
	{
		return TextUtilities.ShortenText(TextUtilities.Trim(msg), 140, false);
	}

	// Token: 0x04001900 RID: 6400
	private static LimitedQueue<ChatMessageFilter.Message> _lastMessages = new LimitedQueue<ChatMessageFilter.Message>(5);

	// Token: 0x020003BD RID: 957
	private class Message
	{
		// Token: 0x06001C06 RID: 7174 RVA: 0x00012A1C File Offset: 0x00010C1C
		public Message(string text)
		{
			this.Text = text;
			this.Time = UnityEngine.Time.time;
		}

		// Token: 0x04001901 RID: 6401
		public float Time;

		// Token: 0x04001902 RID: 6402
		public string Text;

		// Token: 0x04001903 RID: 6403
		public int Count;
	}
}
