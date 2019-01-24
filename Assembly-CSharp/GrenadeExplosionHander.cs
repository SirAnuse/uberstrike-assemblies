using System;

// Token: 0x0200043D RID: 1085
public class GrenadeExplosionHander : IWeaponFireHandler
{
	// Token: 0x06001EDC RID: 7900 RVA: 0x0001467E File Offset: 0x0001287E
	public GrenadeExplosionHander()
	{
		this.IsTriggerPulled = false;
	}

	// Token: 0x17000694 RID: 1684
	// (get) Token: 0x06001EDD RID: 7901 RVA: 0x0001468D File Offset: 0x0001288D
	// (set) Token: 0x06001EDE RID: 7902 RVA: 0x00014695 File Offset: 0x00012895
	public bool IsTriggerPulled { get; private set; }

	// Token: 0x06001EDF RID: 7903 RVA: 0x0001469E File Offset: 0x0001289E
	public void OnTriggerPulled(bool pulled)
	{
		this.IsTriggerPulled = pulled;
		if (pulled)
		{
			Singleton<ProjectileManager>.Instance.RemoveAllLimitedProjectiles(true);
		}
	}

	// Token: 0x06001EE0 RID: 7904 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Update()
	{
	}

	// Token: 0x06001EE1 RID: 7905 RVA: 0x000146B8 File Offset: 0x000128B8
	public void Stop()
	{
		this.IsTriggerPulled = false;
	}

	// Token: 0x17000695 RID: 1685
	// (get) Token: 0x06001EE2 RID: 7906 RVA: 0x00004D4D File Offset: 0x00002F4D
	public bool CanShoot
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x00003C87 File Offset: 0x00001E87
	public void RegisterShot()
	{
	}
}
