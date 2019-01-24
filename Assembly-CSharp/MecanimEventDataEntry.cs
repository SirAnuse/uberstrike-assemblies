using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
[Serializable]
public class MecanimEventDataEntry
{
	// Token: 0x06001594 RID: 5524 RVA: 0x0000E739 File Offset: 0x0000C939
	public MecanimEventDataEntry()
	{
		this.events = new MecanimEvent[0];
	}

	// Token: 0x06001595 RID: 5525 RVA: 0x00078C9C File Offset: 0x00076E9C
	public MecanimEventDataEntry(MecanimEventDataEntry other)
	{
		this.animatorController = other.animatorController;
		this.layer = other.layer;
		this.stateNameHash = other.stateNameHash;
		if (other.events == null)
		{
			this.events = new MecanimEvent[0];
		}
		else
		{
			this.events = new MecanimEvent[other.events.Length];
			for (int i = 0; i < this.events.Length; i++)
			{
				this.events[i] = new MecanimEvent(other.events[i]);
			}
		}
	}

	// Token: 0x04001448 RID: 5192
	public UnityEngine.Object animatorController;

	// Token: 0x04001449 RID: 5193
	public int layer;

	// Token: 0x0400144A RID: 5194
	public int stateNameHash;

	// Token: 0x0400144B RID: 5195
	public MecanimEvent[] events;
}
