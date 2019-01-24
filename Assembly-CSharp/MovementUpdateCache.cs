using System;
using UnityEngine;

// Token: 0x0200038B RID: 907
internal class MovementUpdateCache
{
	// Token: 0x170005ED RID: 1517
	// (get) Token: 0x06001AA2 RID: 6818 RVA: 0x00011ABC File Offset: 0x0000FCBC
	// (set) Token: 0x06001AA3 RID: 6819 RVA: 0x00011AC4 File Offset: 0x0000FCC4
	public Vector3 Position { get; private set; }

	// Token: 0x170005EE RID: 1518
	// (get) Token: 0x06001AA4 RID: 6820 RVA: 0x00011ACD File Offset: 0x0000FCCD
	// (set) Token: 0x06001AA5 RID: 6821 RVA: 0x00011AD5 File Offset: 0x0000FCD5
	public byte HRotation { get; private set; }

	// Token: 0x170005EF RID: 1519
	// (get) Token: 0x06001AA6 RID: 6822 RVA: 0x00011ADE File Offset: 0x0000FCDE
	// (set) Token: 0x06001AA7 RID: 6823 RVA: 0x00011AE6 File Offset: 0x0000FCE6
	public byte VRotation { get; private set; }

	// Token: 0x170005F0 RID: 1520
	// (get) Token: 0x06001AA8 RID: 6824 RVA: 0x00011AEF File Offset: 0x0000FCEF
	// (set) Token: 0x06001AA9 RID: 6825 RVA: 0x00011AF7 File Offset: 0x0000FCF7
	public byte MovementState { get; private set; }

	// Token: 0x06001AAA RID: 6826 RVA: 0x0008B3C8 File Offset: 0x000895C8
	public bool Update(Vector3 position, byte hAngle, byte vAngle, byte moveState)
	{
		if (this.Position != position || this.MovementState != moveState)
		{
			this.lastUpdate = Time.time;
		}
		else if ((this.HRotation != hAngle || this.VRotation != vAngle) && this.lastUpdate + 0.5f < Time.time)
		{
			this.lastUpdate = Time.time;
		}
		this.Position = position;
		this.MovementState = moveState;
		this.HRotation = hAngle;
		this.VRotation = vAngle;
		return this.lastUpdate < Time.time + 1f;
	}

	// Token: 0x040017E3 RID: 6115
	private float lastUpdate;
}
