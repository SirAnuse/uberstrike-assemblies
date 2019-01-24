using System;
using System.Collections;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000320 RID: 800
public class HUDAmmoBar : MonoBehaviour
{
	// Token: 0x06001657 RID: 5719 RVA: 0x0000F159 File Offset: 0x0000D359
	private void OnEnable()
	{
		GameState.Current.PlayerData.ActiveWeapon.Fire();
	}

	// Token: 0x06001658 RID: 5720 RVA: 0x0007C478 File Offset: 0x0007A678
	private void Start()
	{
		this.baseWidth = this.bgr.transform.localScale.x;
		this.baseScale = this.text.transform.localScale.x;
		GameState.Current.PlayerData.ActiveWeapon.AddEventAndFire(delegate(WeaponSlot el)
		{
			if (el != null)
			{
				WeaponSlot currentWeapon = Singleton<WeaponController>.Instance.GetCurrentWeapon();
				this.oldValue = (float)AmmoDepot.AmmoOfClass(currentWeapon.View.ItemClass);
				this.OnChanged();
			}
		}, this);
		GameState.Current.PlayerData.Ammo.AddEvent(delegate(int el)
		{
			this.OnChanged();
		}, this);
	}

	// Token: 0x06001659 RID: 5721 RVA: 0x0007C504 File Offset: 0x0007A704
	private void OnChanged()
	{
		WeaponSlot currentWeapon = Singleton<WeaponController>.Instance.GetCurrentWeapon();
		bool flag = currentWeapon != null && currentWeapon.View.ItemClass != UberstrikeItemClass.WeaponMelee;
		this.panel.alpha = (float)((!flag) ? 0 : 1);
		if (!flag)
		{
			return;
		}
		int num = AmmoDepot.AmmoOfClass(currentWeapon.View.ItemClass);
		int maxValue = AmmoDepot.MaxAmmoOfClass(currentWeapon.View.ItemClass);
		base.StopAllCoroutines();
		if ((float)num != this.oldValue)
		{
			base.StartCoroutine(this.PulseCrt((float)num >= this.oldValue));
		}
		base.StartCoroutine(this.AnimateCrt(num, maxValue));
	}

	// Token: 0x0600165A RID: 5722 RVA: 0x0007C5B8 File Offset: 0x0007A7B8
	private IEnumerator AnimateCrt(int value, int maxValue)
	{
		this.panel.alpha = 1f;
		do
		{
			this.oldValue = Mathf.MoveTowards(this.oldValue, (float)value, Time.deltaTime * this.animateSpeed);
			this.bgr.transform.localScale = this.bgr.transform.localScale.SetX(Mathf.Max((float)maxValue, this.oldValue) / (float)maxValue * this.baseWidth);
			this.bar.transform.localScale = this.bgr.transform.localScale.SetX(this.oldValue / (float)maxValue * this.baseWidth);
			this.text.text = Mathf.FloorToInt(this.oldValue).ToString();
			yield return 0;
		}
		while ((float)value != this.oldValue);
		yield break;
	}

	// Token: 0x0600165B RID: 5723 RVA: 0x0007C5F0 File Offset: 0x0007A7F0
	private IEnumerator PulseCrt(bool up)
	{
		float time = 0f;
		for (;;)
		{
			time = Mathf.Min(time + Time.deltaTime * this.PulseSpeed, 3.14159274f);
			float pulse = Mathf.Sin(time) * this.PulseScale;
			this.text.transform.localScale = (Vector3.one * (this.baseScale + pulse * (float)((!up) ? -1 : 1))).SetZ(1f);
			if (time >= 3.14159274f)
			{
				break;
			}
			yield return 0;
		}
		yield break;
		yield break;
	}

	// Token: 0x0400152C RID: 5420
	[SerializeField]
	private UIPanel panel;

	// Token: 0x0400152D RID: 5421
	[SerializeField]
	private UISprite bar;

	// Token: 0x0400152E RID: 5422
	[SerializeField]
	private UISprite bgr;

	// Token: 0x0400152F RID: 5423
	[SerializeField]
	private UISprite icon;

	// Token: 0x04001530 RID: 5424
	[SerializeField]
	private UILabel text;

	// Token: 0x04001531 RID: 5425
	[SerializeField]
	private float animateSpeed = 200f;

	// Token: 0x04001532 RID: 5426
	[SerializeField]
	private float PulseSpeed = 20f;

	// Token: 0x04001533 RID: 5427
	[SerializeField]
	private float PulseScale = 7f;

	// Token: 0x04001534 RID: 5428
	private float oldValue = -1f;

	// Token: 0x04001535 RID: 5429
	private float baseWidth;

	// Token: 0x04001536 RID: 5430
	private float baseScale;
}
