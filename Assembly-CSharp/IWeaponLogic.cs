using System;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000461 RID: 1121
public interface IWeaponLogic
{
	// Token: 0x06001FF9 RID: 8185
	void Shoot(Ray ray, out CmunePairList<BaseGameProp, ShotPoint> hits);

	// Token: 0x170006DE RID: 1758
	// (get) Token: 0x06001FFA RID: 8186
	BaseWeaponDecorator Decorator { get; }
}
