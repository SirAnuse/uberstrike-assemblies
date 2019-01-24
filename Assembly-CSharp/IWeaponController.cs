using System;

// Token: 0x02000441 RID: 1089
public interface IWeaponController
{
	// Token: 0x06001EF3 RID: 7923
	int NextProjectileId();

	// Token: 0x1700069A RID: 1690
	// (get) Token: 0x06001EF4 RID: 7924
	byte PlayerNumber { get; }

	// Token: 0x1700069B RID: 1691
	// (get) Token: 0x06001EF5 RID: 7925
	int Cmid { get; }

	// Token: 0x1700069C RID: 1692
	// (get) Token: 0x06001EF6 RID: 7926
	bool IsLocal { get; }

	// Token: 0x06001EF7 RID: 7927
	void UpdateWeaponDecorator(IUnityItem item);
}
