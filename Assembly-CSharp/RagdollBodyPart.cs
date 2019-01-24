using System;
using UnityEngine;

// Token: 0x02000228 RID: 552
[RequireComponent(typeof(Rigidbody))]
public class RagdollBodyPart : BaseGameProp, IShootable
{
	// Token: 0x06000F3C RID: 3900 RVA: 0x00064394 File Offset: 0x00062594
	public override void ApplyDamage(DamageInfo damageInfo)
	{
		Vector3 vector = damageInfo.Force * 0.5f;
		vector += new Vector3(0f, damageInfo.UpwardsForceMultiplier, 0f);
		base.rigidbody.AddForce(vector, ForceMode.Impulse);
	}
}
