using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200033D RID: 829
public class HUDWeaponScroller : MonoBehaviour
{
	// Token: 0x06001715 RID: 5909 RVA: 0x0000F893 File Offset: 0x0000DA93
	private void OnEnable()
	{
		GameState.Current.PlayerData.LoadoutWeapons.Fire();
	}

	// Token: 0x06001716 RID: 5910 RVA: 0x0007F354 File Offset: 0x0007D554
	private void Start()
	{
		GameState.Current.PlayerData.LoadoutWeapons.AddEventAndFire(delegate(Dictionary<LoadoutSlotType, IUnityItem> el)
		{
			if (el == null)
			{
				return;
			}
			this.loadoutWeapons.Clear();
			foreach (KeyValuePair<LoadoutSlotType, IUnityItem> item in el)
			{
				switch (item.Key)
				{
				case LoadoutSlotType.WeaponMelee:
					this.SetElement(item, this.melee);
					break;
				case LoadoutSlotType.WeaponPrimary:
					this.SetElement(item, this.primary);
					break;
				case LoadoutSlotType.WeaponSecondary:
					this.SetElement(item, this.secondary);
					break;
				case LoadoutSlotType.WeaponTertiary:
					this.SetElement(item, this.tertiary);
					break;
				}
			}
			if (this.loadoutWeapons.Count > 2)
			{
				this.scrollList.scrollType = NGUIScrollList.ScrollType.Visible3;
			}
			else
			{
				this.scrollList.scrollType = NGUIScrollList.ScrollType.NotCircular;
			}
			this.scrollList.SetActiveElements(new List<GameObject>(this.loadoutWeapons.Values));
		}, this);
		base.StartCoroutine(this.Show(false, 0f, 0f));
		GameState.Current.PlayerData.NextActiveWeapon.AddEvent(delegate(WeaponSlot el)
		{
			if (el != null && this.loadoutWeapons.ContainsKey(el.Slot))
			{
				base.StopAllCoroutines();
				base.StartCoroutine(this.Show(true, 0f, 0.3f));
				this.PlayTweenOnElement(this.scrollList.SelectedElement, false);
				this.scrollList.SelectElement(this.loadoutWeapons[el.Slot], 100f);
				this.PlayTweenOnElement(this.loadoutWeapons[el.Slot], true);
				base.StartCoroutine(this.Show(false, 2.5f, 1f));
			}
		}, this);
	}

	// Token: 0x06001717 RID: 5911 RVA: 0x0000F8A9 File Offset: 0x0000DAA9
	private void SetElement(KeyValuePair<LoadoutSlotType, IUnityItem> item, HUDWeaponScrollItem slot)
	{
		if (item.Value != null)
		{
			slot.WeaponName = item.Value.View.Name;
			this.loadoutWeapons[item.Key] = slot.gameObject;
		}
	}

	// Token: 0x06001718 RID: 5912 RVA: 0x0007F3BC File Offset: 0x0007D5BC
	private IEnumerator Show(bool show, float delay, float duration = 1f)
	{
		yield return new WaitForSeconds(delay);
		TweenAlpha.Begin(this.scrollList.Panel.gameObject, duration, (float)((!show) ? 0 : 1));
		yield break;
	}

	// Token: 0x06001719 RID: 5913 RVA: 0x0007F404 File Offset: 0x0007D604
	private void PlayTweenOnElement(GameObject element, bool forward)
	{
		if (element != null)
		{
			float num = (!forward) ? 1f : 1.6f;
			TweenScale.Begin(element, 0f, new Vector3(num, num, 1f));
			TweenAlpha.Begin(element, 0f, (!forward) ? 0.6f : 1f);
		}
	}

	// Token: 0x04001606 RID: 5638
	[SerializeField]
	private NGUIScrollList scrollList;

	// Token: 0x04001607 RID: 5639
	[SerializeField]
	private HUDWeaponScrollItem melee;

	// Token: 0x04001608 RID: 5640
	[SerializeField]
	private HUDWeaponScrollItem primary;

	// Token: 0x04001609 RID: 5641
	[SerializeField]
	private HUDWeaponScrollItem secondary;

	// Token: 0x0400160A RID: 5642
	[SerializeField]
	private HUDWeaponScrollItem tertiary;

	// Token: 0x0400160B RID: 5643
	private Dictionary<LoadoutSlotType, GameObject> loadoutWeapons = new Dictionary<LoadoutSlotType, GameObject>();
}
