using System;
using UnityEngine;

// Token: 0x0200026E RID: 622
public interface IGrenadeProjectile : IProjectile
{
	// Token: 0x14000006 RID: 6
	// (add) Token: 0x0600114F RID: 4431
	// (remove) Token: 0x06001150 RID: 4432
	event Action<IGrenadeProjectile> OnProjectileEmitted;

	// Token: 0x14000007 RID: 7
	// (add) Token: 0x06001151 RID: 4433
	// (remove) Token: 0x06001152 RID: 4434
	event Action<IGrenadeProjectile> OnProjectileExploded;

	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x06001153 RID: 4435
	Vector3 Position { get; }

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x06001154 RID: 4436
	Vector3 Velocity { get; }

	// Token: 0x06001155 RID: 4437
	IGrenadeProjectile Throw(Vector3 position, Vector3 velocity);

	// Token: 0x06001156 RID: 4438
	void SetLayer(UberstrikeLayer layer);
}
