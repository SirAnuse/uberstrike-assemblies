using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public class MecanimEventEmitter : MonoBehaviour
{
	// Token: 0x06001597 RID: 5527 RVA: 0x00078D30 File Offset: 0x00076F30
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
	}

	// Token: 0x06001598 RID: 5528 RVA: 0x00078D84 File Offset: 0x00076F84
	private void Update()
	{
		ICollection<MecanimEvent> events = MecanimEventManager.GetEvents(this.animatorController.GetInstanceID(), this.animator);
		foreach (MecanimEvent mecanimEvent in events)
		{
			MecanimEvent.SetCurrentContext(mecanimEvent);
			MecanimEventEmitTypes mecanimEventEmitTypes = this.emitType;
			if (mecanimEventEmitTypes != MecanimEventEmitTypes.Upwards)
			{
				if (mecanimEventEmitTypes != MecanimEventEmitTypes.Broadcast)
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
				else if (mecanimEvent.paramType != MecanimEventParamTypes.None)
				{
					base.BroadcastMessage(mecanimEvent.functionName, mecanimEvent.parameter, SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					base.BroadcastMessage(mecanimEvent.functionName, SendMessageOptions.DontRequireReceiver);
				}
			}
			else if (mecanimEvent.paramType != MecanimEventParamTypes.None)
			{
				base.SendMessageUpwards(mecanimEvent.functionName, mecanimEvent.parameter, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				base.SendMessageUpwards(mecanimEvent.functionName, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	// Token: 0x04001450 RID: 5200
	public UnityEngine.Object animatorController;

	// Token: 0x04001451 RID: 5201
	public Animator animator;

	// Token: 0x04001452 RID: 5202
	public MecanimEventEmitTypes emitType;
}
