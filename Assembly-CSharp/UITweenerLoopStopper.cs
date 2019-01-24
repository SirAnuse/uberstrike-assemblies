using System;
using UnityEngine;

// Token: 0x0200034F RID: 847
[AddComponentMenu("NGUI/CMune Extensions/Tweener Loop Stopper")]
public class UITweenerLoopStopper : MonoBehaviour
{
	// Token: 0x06001798 RID: 6040 RVA: 0x0008046C File Offset: 0x0007E66C
	private void Awake()
	{
		if (this.tweener == null && base.gameObject.GetComponent<UITweener>())
		{
			this.tweener = base.gameObject.GetComponent<UITweener>();
		}
		if (this.tweener != null)
		{
			UITweener uitweener = this.tweener;
			uitweener.onCycleFinished = (UITweener.OnFinished)Delegate.Combine(uitweener.onCycleFinished, new UITweener.OnFinished(this.HandleOnCycleFinished));
		}
		else
		{
			Debug.LogError("No tween was assigned to UITweenerLoopStopper in " + base.gameObject.name);
		}
	}

	// Token: 0x06001799 RID: 6041 RVA: 0x00080508 File Offset: 0x0007E708
	private void HandleOnCycleFinished(UITweener tween)
	{
		if (this.fireOnce)
		{
			this.tweener.Reset();
			this.tweener.enabled = false;
			return;
		}
		if (this.currentCycles >= this.numberOfCycles)
		{
			this.tweener.Reset();
			this.tweener.enabled = false;
			this.currentCycles = 0;
			return;
		}
		this.currentCycles++;
	}

	// Token: 0x04001670 RID: 5744
	[SerializeField]
	private UITweener tweener;

	// Token: 0x04001671 RID: 5745
	[SerializeField]
	private int numberOfCycles = 1;

	// Token: 0x04001672 RID: 5746
	[SerializeField]
	private bool fireOnce;

	// Token: 0x04001673 RID: 5747
	private int currentCycles;
}
