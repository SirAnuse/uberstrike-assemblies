using System;
using UberStrike.Core.Types;
using UnityEngine;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000245 RID: 581
	[Serializable]
	public class UberStrikeItemWeaponView : BaseUberStrikeItemView
	{
		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000FEB RID: 4075 RVA: 0x0000AB3B File Offset: 0x00008D3B
		public override UberstrikeItemType ItemType
		{
			get
			{
				return UberstrikeItemType.Weapon;
			}
		}

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000FEC RID: 4076 RVA: 0x0000AB3E File Offset: 0x00008D3E
		// (set) Token: 0x06000FED RID: 4077 RVA: 0x0000AB46 File Offset: 0x00008D46
		public int DamageKnockback
		{
			get
			{
				return this._damageKnockback;
			}
			set
			{
				this._damageKnockback = value;
			}
		}

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000FEE RID: 4078 RVA: 0x0000AB4F File Offset: 0x00008D4F
		// (set) Token: 0x06000FEF RID: 4079 RVA: 0x0000AB57 File Offset: 0x00008D57
		public int DamagePerProjectile
		{
			get
			{
				return this._damagePerProjectile;
			}
			set
			{
				this._damagePerProjectile = value;
			}
		}

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000FF0 RID: 4080 RVA: 0x0000AB60 File Offset: 0x00008D60
		// (set) Token: 0x06000FF1 RID: 4081 RVA: 0x0000AB68 File Offset: 0x00008D68
		public int AccuracySpread
		{
			get
			{
				return this._accuracySpread;
			}
			set
			{
				this._accuracySpread = value;
			}
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x0000AB71 File Offset: 0x00008D71
		// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x0000AB79 File Offset: 0x00008D79
		public int RecoilKickback
		{
			get
			{
				return this._recoilKickback;
			}
			set
			{
				this._recoilKickback = value;
			}
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x0000AB82 File Offset: 0x00008D82
		// (set) Token: 0x06000FF5 RID: 4085 RVA: 0x0000AB8A File Offset: 0x00008D8A
		public int StartAmmo
		{
			get
			{
				return this._startAmmo;
			}
			set
			{
				this._startAmmo = value;
			}
		}

        public int ArmorPierced
        {
            get
            {
                return this._armorPierced;
            }
            set
            {
                this._armorPierced = value;
            }
        }

        // Token: 0x17000386 RID: 902
        // (get) Token: 0x06000FF6 RID: 4086 RVA: 0x0000AB93 File Offset: 0x00008D93
        // (set) Token: 0x06000FF7 RID: 4087 RVA: 0x0000AB9B File Offset: 0x00008D9B
        public int MaxAmmo
		{
			get
			{
				return this._maxAmmo;
			}
			set
			{
				this._maxAmmo = value;
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		// (set) Token: 0x06000FF9 RID: 4089 RVA: 0x0000ABAC File Offset: 0x00008DAC
		public int MissileTimeToDetonate
		{
			get
			{
				return this._missileTimeToDetonate;
			}
			set
			{
				this._missileTimeToDetonate = value;
			}
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000FFA RID: 4090 RVA: 0x0000ABB5 File Offset: 0x00008DB5
		// (set) Token: 0x06000FFB RID: 4091 RVA: 0x0000ABBD File Offset: 0x00008DBD
		public int MissileForceImpulse
		{
			get
			{
				return this._missileForceImpulse;
			}
			set
			{
				this._missileForceImpulse = value;
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000FFC RID: 4092 RVA: 0x0000ABC6 File Offset: 0x00008DC6
		// (set) Token: 0x06000FFD RID: 4093 RVA: 0x0000ABCE File Offset: 0x00008DCE
		public int MissileBounciness
		{
			get
			{
				return this._missileBounciness;
			}
			set
			{
				this._missileBounciness = value;
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000FFE RID: 4094 RVA: 0x0000ABD7 File Offset: 0x00008DD7
		// (set) Token: 0x06000FFF RID: 4095 RVA: 0x0000ABDF File Offset: 0x00008DDF
		public int SplashRadius
		{
			get
			{
				return this._splashRadius;
			}
			set
			{
				this._splashRadius = value;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06001000 RID: 4096 RVA: 0x0000ABE8 File Offset: 0x00008DE8
		// (set) Token: 0x06001001 RID: 4097 RVA: 0x0000ABF0 File Offset: 0x00008DF0
		public int ProjectilesPerShot
		{
			get
			{
				return this._projectilesPerShot;
			}
			set
			{
				this._projectilesPerShot = value;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06001002 RID: 4098 RVA: 0x0000ABF9 File Offset: 0x00008DF9
		// (set) Token: 0x06001003 RID: 4099 RVA: 0x0000AC01 File Offset: 0x00008E01
		public int ProjectileSpeed
		{
			get
			{
				return this._projectileSpeed;
			}
			set
			{
				this._projectileSpeed = value;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06001004 RID: 4100 RVA: 0x0000AC0A File Offset: 0x00008E0A
		// (set) Token: 0x06001005 RID: 4101 RVA: 0x0000AC12 File Offset: 0x00008E12
		public int RateOfFire
		{
			get
			{
				return this._rateOfFire;
			}
			set
			{
				this._rateOfFire = value;
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06001006 RID: 4102 RVA: 0x0000AC1B File Offset: 0x00008E1B
		// (set) Token: 0x06001007 RID: 4103 RVA: 0x0000AC23 File Offset: 0x00008E23
		public int RecoilMovement
		{
			get
			{
				return this._recoilMovement;
			}
			set
			{
				this._recoilMovement = value;
			}
		}

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06001008 RID: 4104 RVA: 0x0000AC2C File Offset: 0x00008E2C
		// (set) Token: 0x06001009 RID: 4105 RVA: 0x0000AC34 File Offset: 0x00008E34
		public int CombatRange
		{
			get
			{
				return this._combatRange;
			}
			set
			{
				this._combatRange = value;
			}
		}

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x0600100A RID: 4106 RVA: 0x0000AC3D File Offset: 0x00008E3D
		// (set) Token: 0x0600100B RID: 4107 RVA: 0x0000AC45 File Offset: 0x00008E45
		public int Tier
		{
			get
			{
				return this._tier;
			}
			set
			{
				this._tier = value;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x0600100C RID: 4108 RVA: 0x0000AC4E File Offset: 0x00008E4E
		// (set) Token: 0x0600100D RID: 4109 RVA: 0x0000AC56 File Offset: 0x00008E56
		public int SecondaryActionReticle
		{
			get
			{
				return this._secondaryActionReticle;
			}
			set
			{
				this._secondaryActionReticle = value;
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x0600100E RID: 4110 RVA: 0x0000AC5F File Offset: 0x00008E5F
		// (set) Token: 0x0600100F RID: 4111 RVA: 0x0000AC67 File Offset: 0x00008E67
		public int WeaponSecondaryAction
		{
			get
			{
				return this._weaponSecondaryAction;
			}
			set
			{
				this._weaponSecondaryAction = value;
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06001010 RID: 4112 RVA: 0x0000AC70 File Offset: 0x00008E70
		// (set) Token: 0x06001011 RID: 4113 RVA: 0x0000AC78 File Offset: 0x00008E78
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

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06001012 RID: 4114 RVA: 0x0000AC81 File Offset: 0x00008E81
		public float DamagePerSecond
		{
			get
			{
				return (float)((this.RateOfFire == 0) ? 0 : (this.DamagePerProjectile * this.ProjectilesPerShot / this.RateOfFire));
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06001013 RID: 4115 RVA: 0x0000ACA9 File Offset: 0x00008EA9
		// (set) Token: 0x06001014 RID: 4116 RVA: 0x0000ACB1 File Offset: 0x00008EB1
		public bool HasAutomaticFire
		{
			get
			{
				return this._hasAutoFire;
			}
			set
			{
				this._hasAutoFire = value;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06001015 RID: 4117 RVA: 0x0000ACBA File Offset: 0x00008EBA
		// (set) Token: 0x06001016 RID: 4118 RVA: 0x0000ACC2 File Offset: 0x00008EC2
		public int DefaultZoomMultiplier
		{
			get
			{
				return this._defaultZoomMultiplier;
			}
			set
			{
				this._defaultZoomMultiplier = value;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06001017 RID: 4119 RVA: 0x0000ACCB File Offset: 0x00008ECB
		// (set) Token: 0x06001018 RID: 4120 RVA: 0x0000ACD3 File Offset: 0x00008ED3
		public int MinZoomMultiplier
		{
			get
			{
				return this._minZoomMultiplier;
			}
			set
			{
				this._minZoomMultiplier = value;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06001019 RID: 4121 RVA: 0x0000ACDC File Offset: 0x00008EDC
		// (set) Token: 0x0600101A RID: 4122 RVA: 0x0000ACE4 File Offset: 0x00008EE4
		public int MaxZoomMultiplier
		{
			get
			{
				return this._maxZoomMultiplier;
			}
			set
			{
				this._maxZoomMultiplier = value;
			}
		}

        [SerializeField]
        private int _armorPierced;

		// Token: 0x04000C5D RID: 3165
		[SerializeField]
		private int _damageKnockback;

		// Token: 0x04000C5E RID: 3166
		[SerializeField]
		private int _damagePerProjectile;

		// Token: 0x04000C5F RID: 3167
		[SerializeField]
		private int _accuracySpread;

		// Token: 0x04000C60 RID: 3168
		[SerializeField]
		private int _recoilKickback;

		// Token: 0x04000C61 RID: 3169
		[SerializeField]
		private int _startAmmo;

		// Token: 0x04000C62 RID: 3170
		[SerializeField]
		private int _maxAmmo;

		// Token: 0x04000C63 RID: 3171
		[SerializeField]
		private int _missileTimeToDetonate;

		// Token: 0x04000C64 RID: 3172
		[SerializeField]
		private int _missileForceImpulse;

		// Token: 0x04000C65 RID: 3173
		[SerializeField]
		private int _missileBounciness;

		// Token: 0x04000C66 RID: 3174
		[SerializeField]
		private int _splashRadius;

		// Token: 0x04000C67 RID: 3175
		[SerializeField]
		private int _projectilesPerShot;

		// Token: 0x04000C68 RID: 3176
		[SerializeField]
		private int _projectileSpeed;

		// Token: 0x04000C69 RID: 3177
		[SerializeField]
		private int _rateOfFire;

		// Token: 0x04000C6A RID: 3178
		[SerializeField]
		private int _recoilMovement;

		// Token: 0x04000C6B RID: 3179
		[SerializeField]
		private int _combatRange;

		// Token: 0x04000C6C RID: 3180
		[SerializeField]
		private int _tier;

		// Token: 0x04000C6D RID: 3181
		[SerializeField]
		private int _secondaryActionReticle;

		// Token: 0x04000C6E RID: 3182
		[SerializeField]
		private int _weaponSecondaryAction;

		// Token: 0x04000C6F RID: 3183
		private int _criticalStrikeBonus;

		// Token: 0x04000C70 RID: 3184
		[SerializeField]
		private bool _hasAutoFire;

		// Token: 0x04000C71 RID: 3185
		[SerializeField]
		private int _defaultZoomMultiplier;

		// Token: 0x04000C72 RID: 3186
		[SerializeField]
		private int _minZoomMultiplier;

		// Token: 0x04000C73 RID: 3187
		[SerializeField]
		private int _maxZoomMultiplier;
	}
}
