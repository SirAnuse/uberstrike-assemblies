using System;
using UnityEngine;

// Token: 0x0200005E RID: 94
[RequireComponent(typeof(UIWidget))]
[ExecuteInEditMode]
public class AnimatedColor : MonoBehaviour
{
	// Token: 0x06000274 RID: 628 RVA: 0x00003CCF File Offset: 0x00001ECF
	private void Awake()
	{
		this.mWidget = base.GetComponent<UIWidget>();
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00003CDD File Offset: 0x00001EDD
	private void Update()
	{
		this.mWidget.color = this.color;
	}

	// Token: 0x04000216 RID: 534
	public Color color = Color.white;

	// Token: 0x04000217 RID: 535
	private UIWidget mWidget;
}
