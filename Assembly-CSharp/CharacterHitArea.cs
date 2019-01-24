using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000367 RID: 871
public class CharacterHitArea : BaseGameProp
{
	// Token: 0x1700059F RID: 1439
	// (get) Token: 0x0600186E RID: 6254 RVA: 0x00010596 File Offset: 0x0000E796
	// (set) Token: 0x0600186F RID: 6255 RVA: 0x0001059E File Offset: 0x0000E79E
	public IShootable Shootable { get; set; }

	// Token: 0x06001870 RID: 6256 RVA: 0x0008349C File Offset: 0x0008169C
	public override void ApplyDamage(DamageInfo shot)
	{
		shot.BodyPart = this._part;
		if (this.Shootable != null)
		{
			if (this.Shootable.IsVulnerable)
			{
				if (this._part == BodyPart.Head || this._part == BodyPart.Nuts)
				{
					shot.Damage += (short)((float)shot.Damage * shot.CriticalStrikeBonus);
				}
				this.Shootable.ApplyDamage(shot);
			}
		}
		else
		{
			Debug.LogError("No character set to the body part!");
		}
	}

	// Token: 0x170005A0 RID: 1440
	// (get) Token: 0x06001871 RID: 6257 RVA: 0x000105A7 File Offset: 0x0000E7A7
	public override bool IsLocal
	{
		get
		{
			return this.Shootable != null && this.Shootable.IsLocal;
		}
	}

	// Token: 0x04001705 RID: 5893
	[SerializeField]
	private BodyPart _part;
}
