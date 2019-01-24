using System;
using System.Collections.Generic;

namespace UberStrike.Core.Models
{
	// Token: 0x02000216 RID: 534
	[Serializable]
	public class DamageEvent
	{
		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000DDA RID: 3546 RVA: 0x000099C6 File Offset: 0x00007BC6
		// (set) Token: 0x06000DDB RID: 3547 RVA: 0x000099CE File Offset: 0x00007BCE
		public Dictionary<byte, byte> Damage { get; set; }

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000DDC RID: 3548 RVA: 0x000099D7 File Offset: 0x00007BD7
		// (set) Token: 0x06000DDD RID: 3549 RVA: 0x000099DF File Offset: 0x00007BDF
		public byte BodyPartFlag { get; set; }

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000DDE RID: 3550 RVA: 0x000099E8 File Offset: 0x00007BE8
		// (set) Token: 0x06000DDF RID: 3551 RVA: 0x000099F0 File Offset: 0x00007BF0
		public int DamageEffectFlag { get; set; }

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000DE0 RID: 3552 RVA: 0x000099F9 File Offset: 0x00007BF9
		// (set) Token: 0x06000DE1 RID: 3553 RVA: 0x00009A01 File Offset: 0x00007C01
		public float DamgeEffectValue { get; set; }

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x00009A0A File Offset: 0x00007C0A
		public int Count
		{
			get
			{
				return (this.Damage == null) ? 0 : this.Damage.Count;
			}
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x00009A28 File Offset: 0x00007C28
		public void Clear()
		{
			if (this.Damage == null)
			{
				this.Damage = new Dictionary<byte, byte>();
			}
			this.BodyPartFlag = 0;
			this.Damage.Clear();
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x000119A8 File Offset: 0x0000FBA8
		public void AddDamage(byte angle, short damage, byte bodyPart, int damageEffectFlag, float damageEffectValue)
		{
			if (this.Damage == null)
			{
				this.Damage = new Dictionary<byte, byte>();
			}
			if (this.Damage.ContainsKey(angle))
			{
				Dictionary<byte, byte> damage2;
				Dictionary<byte, byte> dictionary = damage2 = this.Damage;
				byte b = damage2[angle];
				dictionary[angle] = (byte)(b + (byte)damage);
			}
			else
			{
				this.Damage[angle] = (byte)damage;
			}
			this.BodyPartFlag |= bodyPart;
			this.DamageEffectFlag = damageEffectFlag;
			this.DamgeEffectValue = damageEffectValue;
		}
	}
}
