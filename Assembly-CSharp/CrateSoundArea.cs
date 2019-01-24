using System;
using UnityEngine;

// Token: 0x0200039D RID: 925
[RequireComponent(typeof(SoundArea))]
public class CrateSoundArea : MonoBehaviour
{
	// Token: 0x06001B58 RID: 7000 RVA: 0x000121E4 File Offset: 0x000103E4
	private void Awake()
	{
		this._boxCollider.isTrigger = true;
		base.gameObject.layer = 2;
	}

	// Token: 0x04001855 RID: 6229
	[SerializeField]
	private BoxCollider _boxCollider;
}
