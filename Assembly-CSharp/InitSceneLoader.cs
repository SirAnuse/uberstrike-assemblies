using System;
using UnityEngine;

// Token: 0x0200023B RID: 571
public class InitSceneLoader : MonoBehaviour
{
	// Token: 0x06000FB3 RID: 4019 RVA: 0x0000B159 File Offset: 0x00009359
	private void Awake()
	{
		if (!GlobalSceneLoader.IsInitialised)
		{
			Application.LoadLevel("InitScene");
		}
	}
}
