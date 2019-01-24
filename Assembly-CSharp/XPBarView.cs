using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class XPBarView : MonoBehaviour
{
	// Token: 0x0600179B RID: 6043 RVA: 0x00080578 File Offset: 0x0007E778
	private IEnumerator Animate(float percentage01)
	{
		percentage01 = Mathf.Clamp01(percentage01);
		Transform tr = this.bar.transform;
		float fullWidth = this.bgr.transform.localScale.x;
		while (Mathf.Abs(tr.localScale.x / fullWidth - percentage01) > 0.01f)
		{
			Vector3 scale = tr.localScale;
			scale.x = Mathf.MoveTowards(scale.x, fullWidth * percentage01, Time.deltaTime * this.animageSpeed * fullWidth);
			tr.localScale = scale;
			yield return 0;
		}
		yield break;
	}

	// Token: 0x0600179C RID: 6044 RVA: 0x000805A4 File Offset: 0x0007E7A4
	private void Update()
	{
		int playerExperience = PlayerDataManager.PlayerExperience;
		if ((float)playerExperience != this.cachedXP)
		{
			this.cachedXP = (float)playerExperience;
			int levelForXp = XpPointsUtil.GetLevelForXp(playerExperience);
			this.currentLevel.text = "Lvl " + levelForXp;
			this.nextLevel.text = "Lvl " + Mathf.Clamp(levelForXp + 1, 1, XpPointsUtil.MaxPlayerLevel);
			int num;
			int num2;
			XpPointsUtil.GetXpRangeForLevel(levelForXp, out num, out num2);
			base.StopAllCoroutines();
			base.StartCoroutine(this.Animate((float)(playerExperience - num) / (float)(num2 - num)));
		}
	}

	// Token: 0x04001674 RID: 5748
	[SerializeField]
	private UILabel currentLevel;

	// Token: 0x04001675 RID: 5749
	[SerializeField]
	private UILabel nextLevel;

	// Token: 0x04001676 RID: 5750
	[SerializeField]
	private UISprite bgr;

	// Token: 0x04001677 RID: 5751
	[SerializeField]
	private UISprite bar;

	// Token: 0x04001678 RID: 5752
	[SerializeField]
	private float animageSpeed = 2f;

	// Token: 0x04001679 RID: 5753
	private float cachedXP = -1f;
}
