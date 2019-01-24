using System;
using UnityEngine;

// Token: 0x02000267 RID: 615
[Serializable]
public class ExplosiveGrenadeConfiguration : QuickItemConfiguration
{
	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x0600110B RID: 4363 RVA: 0x0000BCBE File Offset: 0x00009EBE
	public int Damage
	{
		get
		{
			return this._damage;
		}
	}

	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x0600110C RID: 4364 RVA: 0x0000BCC6 File Offset: 0x00009EC6
	public int SplashRadius
	{
		get
		{
			return this._splash;
		}
	}

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x0600110D RID: 4365 RVA: 0x0000BCCE File Offset: 0x00009ECE
	public int LifeTime
	{
		get
		{
			return this._lifeTime;
		}
	}

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x0600110E RID: 4366 RVA: 0x0000BCD6 File Offset: 0x00009ED6
	public float Bounciness
	{
		get
		{
			return (float)this._bounciness * 0.1f;
		}
	}

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x0600110F RID: 4367 RVA: 0x0000BCE5 File Offset: 0x00009EE5
	public bool IsSticky
	{
		get
		{
			return this._isSticky;
		}
	}

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06001110 RID: 4368 RVA: 0x0000BCED File Offset: 0x00009EED
	public int Speed
	{
		get
		{
			return this._speed;
		}
	}

	// Token: 0x04000E51 RID: 3665
	[SerializeField]
	[CustomProperty("Damage")]
	private int _damage = 100;

	// Token: 0x04000E52 RID: 3666
	[SerializeField]
	[CustomProperty("SplashRadius")]
	private int _splash = 2;

	// Token: 0x04000E53 RID: 3667
	[SerializeField]
	[CustomProperty("LifeTime")]
	private int _lifeTime = 15;

	// Token: 0x04000E54 RID: 3668
	[CustomProperty("Bounciness")]
	[SerializeField]
	private int _bounciness = 3;

	// Token: 0x04000E55 RID: 3669
	[CustomProperty("Sticky")]
	[SerializeField]
	private bool _isSticky = true;

	// Token: 0x04000E56 RID: 3670
	[SerializeField]
	private int _speed = 15;
}
