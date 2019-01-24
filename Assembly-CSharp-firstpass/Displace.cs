using System;
using UnityEngine;

// Token: 0x02000366 RID: 870
[ExecuteInEditMode]
[RequireComponent(typeof(WaterBase))]
public class Displace : MonoBehaviour
{
	// Token: 0x0600147F RID: 5247 RVA: 0x0000CB66 File Offset: 0x0000AD66
	public void Awake()
	{
		if (base.enabled)
		{
			this.OnEnable();
		}
		else
		{
			this.OnDisable();
		}
	}

	// Token: 0x06001480 RID: 5248 RVA: 0x0000CB84 File Offset: 0x0000AD84
	public void OnEnable()
	{
		Shader.EnableKeyword("WATER_VERTEX_DISPLACEMENT_ON");
		Shader.DisableKeyword("WATER_VERTEX_DISPLACEMENT_OFF");
	}

	// Token: 0x06001481 RID: 5249 RVA: 0x0000CB9A File Offset: 0x0000AD9A
	public void OnDisable()
	{
		Shader.EnableKeyword("WATER_VERTEX_DISPLACEMENT_OFF");
		Shader.DisableKeyword("WATER_VERTEX_DISPLACEMENT_ON");
	}
}
