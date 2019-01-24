using System;
using UnityEngine;

// Token: 0x0200010D RID: 269
public class DontDestroyOnLoad : MonoBehaviour
{
	// Token: 0x060007E9 RID: 2025 RVA: 0x00007037 File Offset: 0x00005237
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}
}
