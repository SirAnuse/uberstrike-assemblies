using System;
using UnityEngine;

// Token: 0x02000273 RID: 627
[Serializable]
public class SpringGrenadeConfiguration : QuickItemConfiguration
{
	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x06001175 RID: 4469 RVA: 0x0000C0D2 File Offset: 0x0000A2D2
	public Vector3 JumpDirection
	{
		get
		{
			return this._jumpDirection;
		}
	}

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x06001176 RID: 4470 RVA: 0x0000C0DA File Offset: 0x0000A2DA
	public int Force
	{
		get
		{
			return this._force;
		}
	}

	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x06001177 RID: 4471 RVA: 0x0000C0E2 File Offset: 0x0000A2E2
	public int LifeTime
	{
		get
		{
			return this._lifeTime;
		}
	}

	// Token: 0x17000445 RID: 1093
	// (get) Token: 0x06001178 RID: 4472 RVA: 0x0000C0EA File Offset: 0x0000A2EA
	public bool IsSticky
	{
		get
		{
			return this._isSticky;
		}
	}

	// Token: 0x17000446 RID: 1094
	// (get) Token: 0x06001179 RID: 4473 RVA: 0x0000C0F2 File Offset: 0x0000A2F2
	public int Speed
	{
		get
		{
			return this._speed;
		}
	}

	// Token: 0x04000E8D RID: 3725
	[SerializeField]
	private Vector3 _jumpDirection = Vector3.up;

	// Token: 0x04000E8E RID: 3726
	[CustomProperty("Force")]
	[SerializeField]
	private int _force = 1250;

	// Token: 0x04000E8F RID: 3727
	[CustomProperty("LifeTime")]
	[SerializeField]
	private int _lifeTime = 15;

	// Token: 0x04000E90 RID: 3728
	[SerializeField]
	[CustomProperty("Sticky")]
	private bool _isSticky = true;

	// Token: 0x04000E91 RID: 3729
	[SerializeField]
	private int _speed = 10;
}
