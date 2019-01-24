using System;
using UnityEngine;

// Token: 0x020000A7 RID: 167
public class SoundOnTouchArea : MonoBehaviour
{
	// Token: 0x06000463 RID: 1123 RVA: 0x0002DDD0 File Offset: 0x0002BFD0
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Avatar")
		{
			CharacterTrigger component = other.GetComponent<CharacterTrigger>();
			if (component && component.Character.IsLocal)
			{
				this.source.position = GameState.Current.PlayerData.Position + Vector3.down;
			}
		}
	}

	// Token: 0x040003E3 RID: 995
	[SerializeField]
	private Transform source;
}
