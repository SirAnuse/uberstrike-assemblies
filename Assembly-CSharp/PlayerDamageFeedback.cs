using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class PlayerDamageFeedback : MonoBehaviour
{
	// Token: 0x060018FB RID: 6395 RVA: 0x00010A88 File Offset: 0x0000EC88
	private void Awake()
	{
		this.damageSplat = base.renderer.material;
	}

	// Token: 0x060018FC RID: 6396 RVA: 0x00010A9B File Offset: 0x0000EC9B
	public void RandomizeDamageFeedbackcolor()
	{
		this.colorIndex = UnityEngine.Random.Range(0, 5);
	}

	// Token: 0x060018FD RID: 6397 RVA: 0x000860F4 File Offset: 0x000842F4
	public void ShowDamageFeedback(float damage)
	{
		this.DamageColors[this.colorIndex].a = damage * this.Factor;
		this.damageSplat.color = this.DamageColors[this.colorIndex];
	}

	// Token: 0x04001765 RID: 5989
	private Material damageSplat;

	// Token: 0x04001766 RID: 5990
	public Color[] DamageColors;

	// Token: 0x04001767 RID: 5991
	public float Factor;

	// Token: 0x04001768 RID: 5992
	private int colorIndex;
}
