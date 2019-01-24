using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000434 RID: 1076
[RequireComponent(typeof(Animator))]
public class WeaponAnimator : BaseWeaponEffect
{
	// Token: 0x06001EA1 RID: 7841 RVA: 0x0001440D File Offset: 0x0001260D
	private void Awake()
	{
		this._animator = base.GetComponent<Animator>();
	}

	// Token: 0x06001EA2 RID: 7842 RVA: 0x00095A40 File Offset: 0x00093C40
	private IEnumerator StartResetParameters()
	{
		yield return new WaitForEndOfFrame();
		yield return new WaitForSeconds(0.1f);
		this._animator.SetBool("Shoot", false);
		yield break;
	}

	// Token: 0x06001EA3 RID: 7843 RVA: 0x0001441B File Offset: 0x0001261B
	public override void OnShoot()
	{
		this._animator.SetBool("Shoot", true);
		base.StartCoroutine(this.StartResetParameters());
	}

	// Token: 0x06001EA4 RID: 7844 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void Hide()
	{
	}

	// Token: 0x06001EA5 RID: 7845 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001EA6 RID: 7846 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x04001A74 RID: 6772
	private Animator _animator;

	// Token: 0x02000435 RID: 1077
	private class WeaponCommand
	{
		// Token: 0x04001A75 RID: 6773
		public const string Shoot = "Shoot";
	}
}
