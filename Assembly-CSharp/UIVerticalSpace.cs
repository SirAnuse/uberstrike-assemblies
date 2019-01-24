using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
[ExecuteInEditMode]
[AddComponentMenu("NGUI/CMune Extensions/Vertical Space")]
public class UIVerticalSpace : UIWidget
{
	// Token: 0x1700056F RID: 1391
	// (get) Token: 0x060017D4 RID: 6100 RVA: 0x000100B3 File Offset: 0x0000E2B3
	public override Vector2 relativeSize
	{
		get
		{
			return new Vector2(0f, this.Width);
		}
	}

	// Token: 0x040016B9 RID: 5817
	public float Width;
}
