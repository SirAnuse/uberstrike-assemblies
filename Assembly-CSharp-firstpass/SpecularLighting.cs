using System;
using UnityEngine;

// Token: 0x0200036A RID: 874
[ExecuteInEditMode]
[RequireComponent(typeof(WaterBase))]
public class SpecularLighting : MonoBehaviour
{
	// Token: 0x06001496 RID: 5270 RVA: 0x0000CCF5 File Offset: 0x0000AEF5
	public void Start()
	{
		this.waterBase = (WaterBase)base.gameObject.GetComponent(typeof(WaterBase));
	}

	// Token: 0x06001497 RID: 5271 RVA: 0x00026ED4 File Offset: 0x000250D4
	public void Update()
	{
		if (!this.waterBase)
		{
			this.waterBase = (WaterBase)base.gameObject.GetComponent(typeof(WaterBase));
		}
		if (this.specularLight && this.waterBase.sharedMaterial)
		{
			this.waterBase.sharedMaterial.SetVector("_WorldLightDir", this.specularLight.transform.forward);
		}
	}

	// Token: 0x04000EA1 RID: 3745
	public Transform specularLight;

	// Token: 0x04000EA2 RID: 3746
	private WaterBase waterBase;
}
