using System;
using UnityEngine;

// Token: 0x0200008C RID: 140
[ExecuteInEditMode]
public class UISlicedSprite : UISprite
{
	// Token: 0x170000AE RID: 174
	// (get) Token: 0x060003CB RID: 971 RVA: 0x00004D4D File Offset: 0x00002F4D
	public override UISprite.Type type
	{
		get
		{
			return UISprite.Type.Sliced;
		}
	}
}
