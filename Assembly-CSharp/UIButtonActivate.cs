using System;
using UnityEngine;

// Token: 0x0200000A RID: 10
[AddComponentMenu("NGUI/Interaction/Button Activate")]
public class UIButtonActivate : MonoBehaviour
{
	// Token: 0x06000030 RID: 48 RVA: 0x000022DE File Offset: 0x000004DE
	private void OnClick()
	{
		if (this.target != null)
		{
			NGUITools.SetActive(this.target, this.state);
		}
	}

	// Token: 0x0400003C RID: 60
	public GameObject target;

	// Token: 0x0400003D RID: 61
	public bool state = true;
}
