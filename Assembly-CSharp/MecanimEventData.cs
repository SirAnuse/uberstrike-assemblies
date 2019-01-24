using System;
using UnityEngine;

// Token: 0x020002F3 RID: 755
public class MecanimEventData : MonoBehaviour
{
	// Token: 0x06001592 RID: 5522 RVA: 0x00078BB0 File Offset: 0x00076DB0
	private void Start()
	{
		if (this.animator == null)
		{
			Debug.LogWarning("Do not find animator component.");
			base.enabled = false;
			return;
		}
		if (this.animatorController == null)
		{
			Debug.LogWarning("Please assgin animator in editor. Add emitter at runtime is not currently supported.");
			base.enabled = false;
			return;
		}
		MecanimEventManager.SetEventDataSource(this);
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x00078C0C File Offset: 0x00076E0C
	private void Update()
	{
		foreach (MecanimEvent mecanimEvent in MecanimEventManager.GetEvents(this.animatorController.GetInstanceID(), this.animator))
		{
			if (mecanimEvent.paramType != MecanimEventParamTypes.None)
			{
				base.SendMessage(mecanimEvent.functionName, mecanimEvent.parameter, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				base.SendMessage(mecanimEvent.functionName, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	// Token: 0x04001445 RID: 5189
	public MecanimEventDataEntry[] data;

	// Token: 0x04001446 RID: 5190
	public UnityEngine.Object animatorController;

	// Token: 0x04001447 RID: 5191
	public Animator animator;
}
