using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000363 RID: 867
public class AvatarGearParts
{
	// Token: 0x06001832 RID: 6194 RVA: 0x000103A3 File Offset: 0x0000E5A3
	public AvatarGearParts()
	{
		this.Parts = new List<GameObject>();
	}

	// Token: 0x1700058D RID: 1421
	// (get) Token: 0x06001833 RID: 6195 RVA: 0x000103B6 File Offset: 0x0000E5B6
	// (set) Token: 0x06001834 RID: 6196 RVA: 0x000103BE File Offset: 0x0000E5BE
	public GameObject Base { get; set; }

	// Token: 0x1700058E RID: 1422
	// (get) Token: 0x06001835 RID: 6197 RVA: 0x000103C7 File Offset: 0x0000E5C7
	// (set) Token: 0x06001836 RID: 6198 RVA: 0x000103CF File Offset: 0x0000E5CF
	public string Avatar { get; set; }

	// Token: 0x1700058F RID: 1423
	// (get) Token: 0x06001837 RID: 6199 RVA: 0x000103D8 File Offset: 0x0000E5D8
	// (set) Token: 0x06001838 RID: 6200 RVA: 0x000103E0 File Offset: 0x0000E5E0
	public List<GameObject> Parts { get; private set; }

	// Token: 0x06001839 RID: 6201 RVA: 0x000821E4 File Offset: 0x000803E4
	public void DestroyGearParts()
	{
		for (int i = 0; i < this.Parts.Count; i++)
		{
			UnityEngine.Object.Destroy(this.Parts[i]);
		}
	}
}
