using System;
using UnityEngine;

// Token: 0x0200005D RID: 93
public class AnimatedAlpha : MonoBehaviour
{
	// Token: 0x06000271 RID: 625 RVA: 0x00003C9C File Offset: 0x00001E9C
	private void Awake()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.mPanel = base.GetComponent<UIPanel>();
		this.Update();
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00020EB8 File Offset: 0x0001F0B8
	private void Update()
	{
		if (this.mWidget != null)
		{
			this.mWidget.alpha = this.alpha;
		}
		if (this.mPanel != null)
		{
			this.mPanel.alpha = this.alpha;
		}
	}

	// Token: 0x04000213 RID: 531
	public float alpha = 1f;

	// Token: 0x04000214 RID: 532
	private UIWidget mWidget;

	// Token: 0x04000215 RID: 533
	private UIPanel mPanel;
}
