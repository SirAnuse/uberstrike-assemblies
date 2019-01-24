using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200034E RID: 846
public class TrafficMonitor
{
	// Token: 0x06001405 RID: 5125 RVA: 0x0000C3D0 File Offset: 0x0000A5D0
	internal TrafficMonitor(bool enable = true)
	{
		this.AllEvents = new LinkedList<string>();
		this.IsEnabled = enable;
	}

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x06001406 RID: 5126 RVA: 0x0000C40B File Offset: 0x0000A60B
	// (set) Token: 0x06001407 RID: 5127 RVA: 0x0000C413 File Offset: 0x0000A613
	public LinkedList<string> AllEvents { get; private set; }

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x06001408 RID: 5128 RVA: 0x0000C41C File Offset: 0x0000A61C
	// (set) Token: 0x06001409 RID: 5129 RVA: 0x0000C424 File Offset: 0x0000A624
	public bool IsEnabled { get; internal set; }

	// Token: 0x0600140A RID: 5130 RVA: 0x00023FE8 File Offset: 0x000221E8
	public void AddEvent(string ev)
	{
		if (this.lastEvent == ev)
		{
			LinkedListNode<string> last = this.AllEvents.Last;
			last.Value += ".";
		}
		else
		{
			this.AllEvents.AddLast(Time.frameCount + ": " + ev);
		}
		while (this.AllEvents.Count >= 200)
		{
			this.AllEvents.RemoveFirst();
		}
		this.lastEvent = ev;
	}

	// Token: 0x0600140B RID: 5131 RVA: 0x00024078 File Offset: 0x00022278
	internal bool SendOperation(byte operationCode, Dictionary<byte, object> customOpParameters, bool sendReliable, byte channelId, bool encrypted)
	{
		if (customOpParameters.ContainsKey(0))
		{
			this.AddEvent(string.Concat(new object[]
			{
				"Room Operation<",
				operationCode,
				">: ",
				(!this.roomOperationNames.ContainsKey((int)operationCode)) ? operationCode.ToString() : this.roomOperationNames[(int)operationCode]
			}));
		}
		else if (customOpParameters.ContainsKey(1))
		{
			this.AddEvent(string.Concat(new object[]
			{
				"Peer Operation<",
				operationCode,
				">: ",
				(!this.peerOperationNames.ContainsKey((int)operationCode)) ? operationCode.ToString() : this.peerOperationNames[(int)operationCode]
			}));
		}
		else
		{
			this.AddEvent("Operation<" + operationCode + ">");
		}
		return true;
	}

	// Token: 0x0600140C RID: 5132 RVA: 0x00024170 File Offset: 0x00022370
	internal void OnEvent(byte eventCode, byte[] data)
	{
		this.AddEvent(string.Concat(new object[]
		{
			"OnEvent<",
			eventCode,
			">: ",
			(!this.eventNames.ContainsKey((int)eventCode)) ? eventCode.ToString() : this.eventNames[(int)eventCode]
		}));
	}

	// Token: 0x0600140D RID: 5133 RVA: 0x000241D4 File Offset: 0x000223D4
	public void AddNamesForPeerOperations(Type enumType)
	{
		if (!enumType.IsEnum)
		{
			throw new ArgumentException("AddNamesForPeerOperations failed because argument must be an enumerated type");
		}
		foreach (object obj in Enum.GetValues(enumType))
		{
			this.peerOperationNames[(int)obj] = obj.ToString();
		}
	}

	// Token: 0x0600140E RID: 5134 RVA: 0x00024258 File Offset: 0x00022458
	public void AddNamesForRoomOperations(Type enumType)
	{
		if (!enumType.IsEnum)
		{
			throw new ArgumentException("AddNamesForPeerOperations failed because argument must be an enumerated type");
		}
		foreach (object obj in Enum.GetValues(enumType))
		{
			this.roomOperationNames[(int)obj] = obj.ToString();
		}
	}

	// Token: 0x0600140F RID: 5135 RVA: 0x000242DC File Offset: 0x000224DC
	public void AddNamesForEvents(Type enumType)
	{
		if (!enumType.IsEnum)
		{
			throw new ArgumentException("AddNamesForPeerOperations failed because argument must be an enumerated type");
		}
		foreach (object obj in Enum.GetValues(enumType))
		{
			this.eventNames[(int)obj] = obj.ToString();
		}
	}

	// Token: 0x04000E29 RID: 3625
	private string lastEvent;

	// Token: 0x04000E2A RID: 3626
	private Dictionary<int, string> peerOperationNames = new Dictionary<int, string>();

	// Token: 0x04000E2B RID: 3627
	private Dictionary<int, string> roomOperationNames = new Dictionary<int, string>();

	// Token: 0x04000E2C RID: 3628
	private Dictionary<int, string> eventNames = new Dictionary<int, string>();
}
