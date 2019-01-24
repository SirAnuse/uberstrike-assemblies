using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
[AddComponentMenu("NGUI/Interaction/Button Activate Advanced")]
public class UIButtonActivateExtended : MonoBehaviour
{
	// Token: 0x06000032 RID: 50 RVA: 0x000161BC File Offset: 0x000143BC
	private void OnClick()
	{
		if (this._targets.Length == 0)
		{
			return;
		}
		foreach (GameObject gameObject in this._targets)
		{
			if (gameObject != null)
			{
				NGUITools.SetActive(gameObject, (!this._switch) ? this._state : (!gameObject.activeInHierarchy));
			}
		}
	}

	// Token: 0x0400003E RID: 62
	[SerializeField]
	private GameObject[] _targets;

	// Token: 0x0400003F RID: 63
	[SerializeField]
	private bool _state;

	// Token: 0x04000040 RID: 64
	[SerializeField]
	private bool _switch;
}
