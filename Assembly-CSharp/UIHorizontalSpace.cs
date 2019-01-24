using System;
using UnityEngine;

// Token: 0x02000357 RID: 855
[ExecuteInEditMode]
[AddComponentMenu("NGUI/CMune Extensions/Horizontal Space")]
public class UIHorizontalSpace : UIWidget
{
	// Token: 0x1700056C RID: 1388
	// (get) Token: 0x060017C1 RID: 6081 RVA: 0x0000FFFB File Offset: 0x0000E1FB
	public override Vector2 relativeSize
	{
		get
		{
			return new Vector2(this.Width, 0f);
		}
	}

	// Token: 0x040016A3 RID: 5795
	public float Width;
}
