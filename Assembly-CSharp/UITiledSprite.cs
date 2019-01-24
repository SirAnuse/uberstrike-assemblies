using System;
using UnityEngine;

// Token: 0x02000097 RID: 151
[ExecuteInEditMode]
public class UITiledSprite : UISlicedSprite
{
	// Token: 0x170000C9 RID: 201
	// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000505C File Offset: 0x0000325C
	public override UISprite.Type type
	{
		get
		{
			return UISprite.Type.Tiled;
		}
	}
}
