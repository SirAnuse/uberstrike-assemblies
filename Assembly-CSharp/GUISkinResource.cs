using System;
using UnityEngine;

// Token: 0x020003D0 RID: 976
internal class GUISkinResource : MonoBehaviour
{
	// Token: 0x06001C91 RID: 7313 RVA: 0x00013006 File Offset: 0x00011206
	private void Awake()
	{
		BlueStonez.Initialize(this.blueStonez);
		StormFront.Initialize(this.stormFront);
	}

	// Token: 0x0400196B RID: 6507
	[SerializeField]
	private GUISkin blueStonez;

	// Token: 0x0400196C RID: 6508
	[SerializeField]
	private GUISkin stormFront;
}
