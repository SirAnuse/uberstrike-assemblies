using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public static class LayerUtil
{
	// Token: 0x06001CAE RID: 7342 RVA: 0x000909F8 File Offset: 0x0008EBF8
	public static void ValidateUberstrikeLayers()
	{
		for (int i = 0; i < 32; i++)
		{
			if (i != 2)
			{
				if (!string.IsNullOrEmpty(LayerMask.LayerToName(i)))
				{
					if (Enum.GetName(typeof(UberstrikeLayer), i) != LayerMask.LayerToName(i))
					{
						Debug.LogError("Editor layer '" + LayerMask.LayerToName(i) + "' is not defined in the UberstrikeLayer enum!");
					}
				}
				else if (!string.IsNullOrEmpty(Enum.GetName(typeof(UberstrikeLayer), i)))
				{
					throw new Exception("UberstrikeLayer mismatch with Editor on layer: " + Enum.GetName(typeof(UberstrikeLayer), i));
				}
			}
		}
	}

	// Token: 0x06001CAF RID: 7343 RVA: 0x00090ABC File Offset: 0x0008ECBC
	public static int CreateLayerMask(params UberstrikeLayer[] layers)
	{
		int num = 0;
		foreach (int num2 in layers)
		{
			num |= 1 << num2;
		}
		return num;
	}

	// Token: 0x06001CB0 RID: 7344 RVA: 0x00090AF0 File Offset: 0x0008ECF0
	public static int AddToLayerMask(int mask, params UberstrikeLayer[] layers)
	{
		foreach (int num in layers)
		{
			mask |= 1 << num;
		}
		return mask;
	}

	// Token: 0x06001CB1 RID: 7345 RVA: 0x00090B28 File Offset: 0x0008ED28
	public static int RemoveFromLayerMask(int mask, params UberstrikeLayer[] layers)
	{
		foreach (int num in layers)
		{
			mask &= ~(1 << num);
		}
		return mask;
	}

	// Token: 0x06001CB2 RID: 7346 RVA: 0x0001317D File Offset: 0x0001137D
	public static void SetLayerRecursively(Transform transform, UberstrikeLayer layer)
	{
		LayerUtil.SetLayerRecursively(transform, (int)layer);
	}

	// Token: 0x06001CB3 RID: 7347 RVA: 0x00090B60 File Offset: 0x0008ED60
	public static void SetLayerRecursively(Transform transform, int layer)
	{
		foreach (Transform transform2 in transform.GetComponentsInChildren<Transform>(true))
		{
			transform2.gameObject.layer = layer;
		}
	}

	// Token: 0x06001CB4 RID: 7348 RVA: 0x0000C928 File Offset: 0x0000AB28
	public static int GetLayer(UberstrikeLayer layer)
	{
		return (int)layer;
	}

	// Token: 0x06001CB5 RID: 7349 RVA: 0x00013186 File Offset: 0x00011386
	public static bool IsLayerInMask(int mask, int layer)
	{
		return (mask & 1 << layer) != 0;
	}

	// Token: 0x06001CB6 RID: 7350 RVA: 0x00013186 File Offset: 0x00011386
	public static bool IsLayerInMask(int mask, UberstrikeLayer layer)
	{
		return (mask & 1 << (int)layer) != 0;
	}

	// Token: 0x1700065C RID: 1628
	// (get) Token: 0x06001CB7 RID: 7351 RVA: 0x00013196 File Offset: 0x00011396
	public static int LayerMaskEverything
	{
		get
		{
			return -1;
		}
	}

	// Token: 0x1700065D RID: 1629
	// (get) Token: 0x06001CB8 RID: 7352 RVA: 0x00003C84 File Offset: 0x00001E84
	public static int LayerMaskNothing
	{
		get
		{
			return 0;
		}
	}
}
