using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class GameObjectHelper
{
	// Token: 0x060015A8 RID: 5544 RVA: 0x0000E7C5 File Offset: 0x0000C9C5
	public static GameObject Instantiate(GameObject template, Transform parent, Vector3 localPosition)
	{
		return GameObjectHelper.Instantiate(template, parent, localPosition, Vector3.one);
	}

	// Token: 0x060015A9 RID: 5545 RVA: 0x00079654 File Offset: 0x00077854
	public static GameObject Instantiate(GameObject template, Transform parent, Vector3 localPosition, Vector3 localScale)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(template) as GameObject;
		gameObject.transform.parent = parent;
		gameObject.transform.localPosition = localPosition;
		gameObject.transform.localScale = localScale;
		return gameObject;
	}
}
