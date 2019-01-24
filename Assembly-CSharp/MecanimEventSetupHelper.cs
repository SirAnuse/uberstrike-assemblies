using System;
using UnityEngine;

// Token: 0x020002F8 RID: 760
public class MecanimEventSetupHelper : MonoBehaviour
{
	// Token: 0x060015A1 RID: 5537 RVA: 0x0007935C File Offset: 0x0007755C
	private void Awake()
	{
		if (this.dataSource == null && (this.dataSources == null || this.dataSources.Length == 0))
		{
			Debug.Log("Please setup data source of event system.");
			return;
		}
		if (this.dataSource != null)
		{
			MecanimEventManager.SetEventDataSource(this.dataSource);
		}
		else
		{
			MecanimEventManager.SetEventDataSource(this.dataSources);
		}
	}

	// Token: 0x04001456 RID: 5206
	public MecanimEventData dataSource;

	// Token: 0x04001457 RID: 5207
	public MecanimEventData[] dataSources;
}
