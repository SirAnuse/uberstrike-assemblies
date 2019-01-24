using System;
using UnityEngine;

// Token: 0x02000279 RID: 633
[RequireComponent(typeof(Animation))]
public class AnimationSynchronizer : MonoBehaviour
{
	// Token: 0x060011B1 RID: 4529 RVA: 0x0000C3C3 File Offset: 0x0000A5C3
	private void Start()
	{
		this.animationState = base.animation[base.animation.clip.name];
	}

	// Token: 0x060011B2 RID: 4530 RVA: 0x0000C3E6 File Offset: 0x0000A5E6
	private void LateUpdate()
	{
		if (GameState.Current.IsMultiplayer)
		{
			this.animationState.time = GameState.Current.GameTime;
		}
		else
		{
			this.animationState.time = Time.timeSinceLevelLoad;
		}
	}

	// Token: 0x04000EAB RID: 3755
	private AnimationState animationState;
}
