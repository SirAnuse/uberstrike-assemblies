using System;

// Token: 0x0200043E RID: 1086
public interface IWeaponFireHandler
{
	// Token: 0x06001EE4 RID: 7908
	void OnTriggerPulled(bool pulled);

	// Token: 0x06001EE5 RID: 7909
	void Update();

	// Token: 0x06001EE6 RID: 7910
	void Stop();

	// Token: 0x06001EE7 RID: 7911
	void RegisterShot();

	// Token: 0x17000696 RID: 1686
	// (get) Token: 0x06001EE8 RID: 7912
	bool IsTriggerPulled { get; }

	// Token: 0x17000697 RID: 1687
	// (get) Token: 0x06001EE9 RID: 7913
	bool CanShoot { get; }
}
