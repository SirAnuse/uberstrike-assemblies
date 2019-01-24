using System;
using UnityEngine;

// Token: 0x0200043A RID: 1082
public class WeaponShootAnimator : BaseWeaponEffect
{
	// Token: 0x06001EC3 RID: 7875 RVA: 0x00003C87 File Offset: 0x00001E87
	private void Awake()
	{
	}

	// Token: 0x06001EC4 RID: 7876 RVA: 0x00003C87 File Offset: 0x00001E87
	private void Start()
	{
	}

	// Token: 0x06001EC5 RID: 7877 RVA: 0x000144E9 File Offset: 0x000126E9
	private void OnEnable()
	{
		if (this._weaponAnimator)
		{
			this._weaponAnimator.SetBool(WeaponShootAnimator.SHOOT_PARAM, false);
			this._IsShooting = false;
		}
	}

	// Token: 0x06001EC6 RID: 7878 RVA: 0x00014513 File Offset: 0x00012713
	public override void OnShoot()
	{
		if (this._weaponAnimator)
		{
			this._weaponAnimator.SetBool(WeaponShootAnimator.SHOOT_PARAM, true);
			this._IsShooting = true;
		}
	}

	// Token: 0x06001EC7 RID: 7879 RVA: 0x00095C78 File Offset: 0x00093E78
	public void FixedUpdate()
	{
		if (this._weaponAnimator && this._IsShooting && this._weaponAnimator.GetCurrentAnimatorStateInfo(0).nameHash == WeaponShootAnimator.SHOOT_STATE && !this._weaponAnimator.IsInTransition(0))
		{
			this._weaponAnimator.SetBool(WeaponShootAnimator.SHOOT_PARAM, false);
			this._IsShooting = false;
		}
	}

	// Token: 0x06001EC8 RID: 7880 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001EC9 RID: 7881 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x06001ECA RID: 7882 RVA: 0x000144E9 File Offset: 0x000126E9
	public override void Hide()
	{
		if (this._weaponAnimator)
		{
			this._weaponAnimator.SetBool(WeaponShootAnimator.SHOOT_PARAM, false);
			this._IsShooting = false;
		}
	}

	// Token: 0x04001A7D RID: 6781
	[SerializeField]
	private Animator _weaponAnimator;

	// Token: 0x04001A7E RID: 6782
	private bool _IsShooting;

	// Token: 0x04001A7F RID: 6783
	private static readonly int SHOOT_STATE = Animator.StringToHash("Base Layer.Shoot");

	// Token: 0x04001A80 RID: 6784
	private static readonly int SHOOT_PARAM = Animator.StringToHash("Shoot");
}
