using System;
using UnityEngine;

// Token: 0x02000242 RID: 578
[Serializable]
public class WeaponItemConfiguration
{
	// Token: 0x170003BE RID: 958
	// (get) Token: 0x06000FE9 RID: 4073 RVA: 0x0000B331 File Offset: 0x00009531
	public bool Sticky
	{
		get
		{
			return this._sticky != 0;
		}
	}

	// Token: 0x170003BF RID: 959
	// (get) Token: 0x06000FEA RID: 4074 RVA: 0x0000B33F File Offset: 0x0000953F
	// (set) Token: 0x06000FEB RID: 4075 RVA: 0x0000B347 File Offset: 0x00009547
	public int SwitchDelayMilliSeconds
	{
		get
		{
			return this._switchDelay;
		}
		set
		{
			this._switchDelay = value;
		}
	}

	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x06000FEC RID: 4076 RVA: 0x0000B350 File Offset: 0x00009550
	public int MaxConcurrentProjectiles
	{
		get
		{
			return this._maxConcurrentProjectiles;
		}
	}

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x06000FED RID: 4077 RVA: 0x0000B358 File Offset: 0x00009558
	// (set) Token: 0x06000FEE RID: 4078 RVA: 0x0000B360 File Offset: 0x00009560
	public int MinProjectileDistance
	{
		get
		{
			return this._minProjectileDistance;
		}
		set
		{
			this._minProjectileDistance = value;
		}
	}

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06000FEF RID: 4079 RVA: 0x0000B369 File Offset: 0x00009569
	// (set) Token: 0x06000FF0 RID: 4080 RVA: 0x0000B371 File Offset: 0x00009571
	public Vector3 Position
	{
		get
		{
			return this._position;
		}
		set
		{
			this._position = value;
		}
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06000FF1 RID: 4081 RVA: 0x0000B37A File Offset: 0x0000957A
	// (set) Token: 0x06000FF2 RID: 4082 RVA: 0x0000B382 File Offset: 0x00009582
	public Vector3 Rotation
	{
		get
		{
			return this._rotation;
		}
		set
		{
			this._rotation = value;
		}
	}

	// Token: 0x170003C4 RID: 964
	// (get) Token: 0x06000FF3 RID: 4083 RVA: 0x0000B38B File Offset: 0x0000958B
	// (set) Token: 0x06000FF4 RID: 4084 RVA: 0x0000B393 File Offset: 0x00009593
	public bool ShowReticleForPrimaryAction
	{
		get
		{
			return this._showReticleForPrimaryAction;
		}
		set
		{
			this._showReticleForPrimaryAction = value;
		}
	}

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x06000FF5 RID: 4085 RVA: 0x0000B39C File Offset: 0x0000959C
	// (set) Token: 0x06000FF6 RID: 4086 RVA: 0x0000B3A4 File Offset: 0x000095A4
	public Vector3 IronSightPosition
	{
		get
		{
			return this._ironSightPosition;
		}
		set
		{
			this._ironSightPosition = value;
		}
	}

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x0000B3AD File Offset: 0x000095AD
	// (set) Token: 0x06000FF8 RID: 4088 RVA: 0x0000B3B5 File Offset: 0x000095B5
	public DamageEffectType DamageEffectFlag
	{
		get
		{
			return this._damageEffectFlag;
		}
		set
		{
			this._damageEffectFlag = value;
		}
	}

	// Token: 0x170003C7 RID: 967
	// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x0000B3BE File Offset: 0x000095BE
	// (set) Token: 0x06000FFA RID: 4090 RVA: 0x0000B3C6 File Offset: 0x000095C6
	public float DamageEffectValue
	{
		get
		{
			return this._damageEffectValue;
		}
		set
		{
			this._damageEffectValue = value;
		}
	}

	// Token: 0x170003C8 RID: 968
	// (get) Token: 0x06000FFB RID: 4091 RVA: 0x0000B3CF File Offset: 0x000095CF
	// (set) Token: 0x06000FFC RID: 4092 RVA: 0x0000B3D7 File Offset: 0x000095D7
	public ParticleConfigurationType ParticleEffect
	{
		get
		{
			return this._impactEffect;
		}
		set
		{
			this._impactEffect = value;
		}
	}

	// Token: 0x170003C9 RID: 969
	// (get) Token: 0x06000FFD RID: 4093 RVA: 0x0000B3E0 File Offset: 0x000095E0
	// (set) Token: 0x06000FFE RID: 4094 RVA: 0x0000B3E8 File Offset: 0x000095E8
	public int CriticalStrikeBonus
	{
		get
		{
			return this._criticalStrikeBonus;
		}
		set
		{
			this._criticalStrikeBonus = value;
		}
	}

	// Token: 0x04000DDA RID: 3546
	[CustomProperty("SwitchDelay")]
	private int _switchDelay = 500;

	// Token: 0x04000DDB RID: 3547
	[CustomProperty("MaxConcurrentProjectiles")]
	private int _maxConcurrentProjectiles;

	// Token: 0x04000DDC RID: 3548
	[CustomProperty("Sticky")]
	private int _sticky;

	// Token: 0x04000DDD RID: 3549
	private int _criticalStrikeBonus;

	// Token: 0x04000DDE RID: 3550
	[SerializeField]
	private DamageEffectType _damageEffectFlag;

	// Token: 0x04000DDF RID: 3551
	[SerializeField]
	private float _damageEffectValue;

	// Token: 0x04000DE0 RID: 3552
	[SerializeField]
	private Vector3 _ironSightPosition;

	// Token: 0x04000DE1 RID: 3553
	[SerializeField]
	private bool _showReticleForPrimaryAction;

	// Token: 0x04000DE2 RID: 3554
	[SerializeField]
	private int _minProjectileDistance = 2;

	// Token: 0x04000DE3 RID: 3555
	[SerializeField]
	private Vector3 _position;

	// Token: 0x04000DE4 RID: 3556
	[SerializeField]
	private Vector3 _rotation;

	// Token: 0x04000DE5 RID: 3557
	[SerializeField]
	private ParticleConfigurationType _impactEffect;
}
