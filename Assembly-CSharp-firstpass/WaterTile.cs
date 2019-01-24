using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
[ExecuteInEditMode]
public class WaterTile : MonoBehaviour
{
	// Token: 0x0600149D RID: 5277 RVA: 0x0000CD6B File Offset: 0x0000AF6B
	public void Start()
	{
		this.AcquireComponents();
	}

	// Token: 0x0600149E RID: 5278 RVA: 0x0002703C File Offset: 0x0002523C
	private void AcquireComponents()
	{
		if (!this.reflection)
		{
			if (base.transform.parent)
			{
				this.reflection = base.transform.parent.GetComponent<PlanarReflection>();
			}
			else
			{
				this.reflection = base.transform.GetComponent<PlanarReflection>();
			}
		}
		if (!this.waterBase)
		{
			if (base.transform.parent)
			{
				this.waterBase = base.transform.parent.GetComponent<WaterBase>();
			}
			else
			{
				this.waterBase = base.transform.GetComponent<WaterBase>();
			}
		}
	}

	// Token: 0x0600149F RID: 5279 RVA: 0x000270EC File Offset: 0x000252EC
	public void OnWillRenderObject()
	{
		if (this.reflection)
		{
			this.reflection.WaterTileBeingRendered(base.transform, Camera.current);
		}
		if (this.waterBase)
		{
			this.waterBase.WaterTileBeingRendered(base.transform, Camera.current);
		}
	}

	// Token: 0x04000EAA RID: 3754
	public PlanarReflection reflection;

	// Token: 0x04000EAB RID: 3755
	public WaterBase waterBase;
}
