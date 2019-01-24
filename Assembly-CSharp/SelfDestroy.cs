using System;
using UnityEngine;

// Token: 0x0200039F RID: 927
public class SelfDestroy : MonoBehaviour
{
	// Token: 0x06001B64 RID: 7012 RVA: 0x0001223E File Offset: 0x0001043E
	private void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject, this._destroyInSeconds);
	}

	// Token: 0x06001B65 RID: 7013 RVA: 0x00012251 File Offset: 0x00010451
	public void SetDelay(float seconds)
	{
		this._destroyInSeconds = seconds;
	}

	// Token: 0x04001869 RID: 6249
	[SerializeField]
	private float _destroyInSeconds = 1f;
}
