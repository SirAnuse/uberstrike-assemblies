using System;
using UnityEngine;

// Token: 0x02000413 RID: 1043
public static class TagUtil
{
	// Token: 0x06001D9C RID: 7580 RVA: 0x00093094 File Offset: 0x00091294
	public static string GetTag(Collider c)
	{
		string result = "Cement";
		try
		{
			if (c)
			{
				result = c.tag;
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed to get tag from collider: " + ex.Message);
		}
		return result;
	}
}
