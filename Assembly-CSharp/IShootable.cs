using System;
using UnityEngine;

// Token: 0x0200021C RID: 540
public interface IShootable
{
	// Token: 0x06000EFA RID: 3834
	void ApplyDamage(DamageInfo shot);

	// Token: 0x06000EFB RID: 3835
	void ApplyForce(Vector3 position, Vector3 force);

	// Token: 0x17000381 RID: 897
	// (get) Token: 0x06000EFC RID: 3836
	bool IsVulnerable { get; }

	// Token: 0x17000382 RID: 898
	// (get) Token: 0x06000EFD RID: 3837
	bool IsLocal { get; }

	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06000EFE RID: 3838
	Transform Transform { get; }
}
