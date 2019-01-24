using System;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x02000241 RID: 577
[Serializable]
public class HoloGearItemConfiguration : UberStrikeItemGearView
{
	// Token: 0x170003BC RID: 956
	// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x0000B307 File Offset: 0x00009507
	public AvatarDecorator Avatar
	{
		get
		{
			return this._avatar;
		}
	}

	// Token: 0x170003BD RID: 957
	// (get) Token: 0x06000FE7 RID: 4071 RVA: 0x0000B30F File Offset: 0x0000950F
	public AvatarDecoratorConfig Ragdoll
	{
		get
		{
			return this._ragdoll;
		}
	}

	// Token: 0x04000DD8 RID: 3544
	[SerializeField]
	private AvatarDecorator _avatar;

	// Token: 0x04000DD9 RID: 3545
	[SerializeField]
	private AvatarDecoratorConfig _ragdoll;
}
