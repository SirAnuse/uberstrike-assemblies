using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
[ExecuteInEditMode]
public class UIFilledSprite : UISprite
{
	// Token: 0x17000075 RID: 117
	// (get) Token: 0x0600030D RID: 781 RVA: 0x0000442A File Offset: 0x0000262A
	public override UISprite.Type type
	{
		get
		{
			return UISprite.Type.Filled;
		}
	}
}
