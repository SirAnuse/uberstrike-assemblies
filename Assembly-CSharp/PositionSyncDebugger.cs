using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000394 RID: 916
public class PositionSyncDebugger
{
	// Token: 0x06001B20 RID: 6944 RVA: 0x00003C87 File Offset: 0x00001E87
	public void AddSample(Vector3 position, MoveStates state)
	{
	}

	// Token: 0x0400182E RID: 6190
	private Queue<PositionSyncDebugger.PositionInfo> positions = new Queue<PositionSyncDebugger.PositionInfo>();

	// Token: 0x02000395 RID: 917
	private class PositionInfo
	{
		// Token: 0x0400182F RID: 6191
		public Vector3 Position;

		// Token: 0x04001830 RID: 6192
		public Color Color;

		// Token: 0x04001831 RID: 6193
		public MoveStates State;
	}
}
