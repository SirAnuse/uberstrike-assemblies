using System;
using UnityEngine;

// Token: 0x020000A6 RID: 166
public class SoundArea : MonoBehaviour
{
	// Token: 0x0600045E RID: 1118 RVA: 0x0000532C File Offset: 0x0000352C
	private void OnTriggerEnter(Collider other)
	{
		this.SetFootStep(other);
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x0000532C File Offset: 0x0000352C
	private void OnTriggerStay(Collider other)
	{
		this.SetFootStep(other);
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x0002DCBC File Offset: 0x0002BEBC
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Avatar")
		{
			CharacterTrigger component = other.GetComponent<CharacterTrigger>();
			if (component && component.Character.Avatar != null && component.Character.Avatar.Decorator && GameState.Current.Map != null)
			{
				component.Character.Avatar.Decorator.CurrentFootStep = GameState.Current.Map.DefaultFootStep;
			}
		}
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x0002DD54 File Offset: 0x0002BF54
	private void SetFootStep(Collider other)
	{
		if (other.tag == "Avatar")
		{
			CharacterTrigger component = other.GetComponent<CharacterTrigger>();
			if (component && component.Character.Avatar != null && component.Character.Avatar.Decorator)
			{
				component.Character.Avatar.Decorator.CurrentFootStep = this._footStep;
			}
		}
	}

	// Token: 0x040003E2 RID: 994
	[SerializeField]
	private FootStepSoundType _footStep;
}
