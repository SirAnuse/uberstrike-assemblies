using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public abstract class BaseWeaponEffect : MonoBehaviour
{
	// Token: 0x06001E5C RID: 7772 RVA: 0x00014221 File Offset: 0x00012421
	public void SetDecorator(BaseWeaponDecorator decorator)
	{
		this._decorator = decorator;
	}

	// Token: 0x06001E5D RID: 7773
	public abstract void OnShoot();

	// Token: 0x06001E5E RID: 7774
	public abstract void OnPostShoot();

	// Token: 0x06001E5F RID: 7775
	public abstract void OnHits(RaycastHit[] hits);

	// Token: 0x06001E60 RID: 7776
	public abstract void Hide();

	// Token: 0x04001A4B RID: 6731
	protected BaseWeaponDecorator _decorator;
}
