using System;
using UnityEngine;

// Token: 0x02000341 RID: 833
public class ZoomInView : MonoBehaviour
{
	// Token: 0x0600172A RID: 5930 RVA: 0x0007F6F4 File Offset: 0x0007D8F4
	private void UpdateReticleSize()
	{
		UIRoot uiroot = NGUITools.FindInParents<UIRoot>(base.gameObject);
		float pixelSizeAdjustment = uiroot.pixelSizeAdjustment;
		Vector3 localScale = this.leftBg.cachedTransform.localScale;
		localScale.x = 2f * ((float)Screen.width * 0.5f * pixelSizeAdjustment - this.zoomReticle.cachedTransform.localScale.x * 0.5f + this.PADDING * pixelSizeAdjustment);
		this.leftBg.cachedTransform.localScale = localScale;
		this.rightBg.cachedTransform.localScale = localScale;
	}

	// Token: 0x0600172B RID: 5931 RVA: 0x0000F9B4 File Offset: 0x0000DBB4
	public void Show(bool show)
	{
		this.zoomReticle.gameObject.SetActive(show);
		this.leftBg.gameObject.SetActive(show);
		this.rightBg.gameObject.SetActive(show);
		this.isShown = show;
	}

	// Token: 0x0600172C RID: 5932 RVA: 0x0000F9F0 File Offset: 0x0000DBF0
	private void LateUpdate()
	{
		if (this.isShown)
		{
			this.UpdateReticleSize();
		}
	}

	// Token: 0x04001619 RID: 5657
	[SerializeField]
	private UITexture zoomReticle;

	// Token: 0x0400161A RID: 5658
	[SerializeField]
	private UISprite leftBg;

	// Token: 0x0400161B RID: 5659
	[SerializeField]
	private UISprite rightBg;

	// Token: 0x0400161C RID: 5660
	public bool isShown;

	// Token: 0x0400161D RID: 5661
	public float PADDING = 2f;
}
