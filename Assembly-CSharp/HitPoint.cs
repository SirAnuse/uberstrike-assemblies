using System;
using UnityEngine;

// Token: 0x02000463 RID: 1123
public class HitPoint
{
	// Token: 0x06002002 RID: 8194 RVA: 0x00015188 File Offset: 0x00013388
	public HitPoint(Vector3 p, string t)
	{
		this.Point = p;
		this.Tag = t;
	}

	// Token: 0x170006E2 RID: 1762
	// (get) Token: 0x06002003 RID: 8195 RVA: 0x0001519E File Offset: 0x0001339E
	// (set) Token: 0x06002004 RID: 8196 RVA: 0x000151A6 File Offset: 0x000133A6
	public Vector3 Point { get; private set; }

	// Token: 0x170006E3 RID: 1763
	// (get) Token: 0x06002005 RID: 8197 RVA: 0x000151AF File Offset: 0x000133AF
	// (set) Token: 0x06002006 RID: 8198 RVA: 0x000151B7 File Offset: 0x000133B7
	public string Tag { get; private set; }
}
