using System;
using UnityEngine;

// Token: 0x02000286 RID: 646
public class LevelEnviroment : MonoBehaviour
{
	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060011E6 RID: 4582 RVA: 0x0000C698 File Offset: 0x0000A898
	// (set) Token: 0x060011E7 RID: 4583 RVA: 0x0000C69F File Offset: 0x0000A89F
	public static LevelEnviroment Instance { get; private set; }

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x060011E8 RID: 4584 RVA: 0x0000C6A7 File Offset: 0x0000A8A7
	public static bool Exists
	{
		get
		{
			return LevelEnviroment.Instance != null;
		}
	}

	// Token: 0x060011E9 RID: 4585 RVA: 0x0000C6B4 File Offset: 0x0000A8B4
	private void Awake()
	{
		LevelEnviroment.Instance = this;
	}

	// Token: 0x04000ED8 RID: 3800
	public EnviromentSettings Settings;
}
