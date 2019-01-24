using System;
using UnityEngine;

// Token: 0x02000448 RID: 1096
public class ArrowProjectile : MonoBehaviour
{
	// Token: 0x06001F2F RID: 7983 RVA: 0x0000C06E File Offset: 0x0000A26E
	public void Destroy()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x06001F30 RID: 7984 RVA: 0x00014911 File Offset: 0x00012B11
	public void Destroy(int timeDelay)
	{
		UnityEngine.Object.Destroy(base.gameObject, (float)timeDelay);
	}

	// Token: 0x06001F31 RID: 7985 RVA: 0x00014920 File Offset: 0x00012B20
	public void SetParent(Transform parent)
	{
		base.transform.parent = parent;
	}
}
