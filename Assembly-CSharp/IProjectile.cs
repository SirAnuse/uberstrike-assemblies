using System;
using UnityEngine;

// Token: 0x0200021B RID: 539
public interface IProjectile
{
	// Token: 0x17000380 RID: 896
	// (get) Token: 0x06000EF6 RID: 3830
	// (set) Token: 0x06000EF7 RID: 3831
	int ID { get; set; }

	// Token: 0x06000EF8 RID: 3832
	Vector3 Explode();

	// Token: 0x06000EF9 RID: 3833
	void Destroy();
}
