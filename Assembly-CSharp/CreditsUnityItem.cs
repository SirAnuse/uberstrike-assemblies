using System;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000245 RID: 581
public class CreditsUnityItem : IUnityItem
{
	// Token: 0x06001007 RID: 4103 RVA: 0x00065C0C File Offset: 0x00063E0C
	public CreditsUnityItem(int credits)
	{
		this.Name = credits.ToString("N0") + " Credits";
		this.View = new CreditsUnityItem.DummyItemView
		{
			Description = string.Format("An extra {0:N0} Credits to fatten up your UberWallet!", credits)
		};
	}

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x06001008 RID: 4104 RVA: 0x00003C84 File Offset: 0x00001E84
	public bool Equippable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x170003CD RID: 973
	// (get) Token: 0x06001009 RID: 4105 RVA: 0x0000B41B File Offset: 0x0000961B
	// (set) Token: 0x0600100A RID: 4106 RVA: 0x0000B423 File Offset: 0x00009623
	public string Name { get; private set; }

	// Token: 0x170003CE RID: 974
	// (get) Token: 0x0600100B RID: 4107 RVA: 0x0000B42C File Offset: 0x0000962C
	// (set) Token: 0x0600100C RID: 4108 RVA: 0x0000B434 File Offset: 0x00009634
	public BaseUberStrikeItemView View { get; private set; }

	// Token: 0x170003CF RID: 975
	// (get) Token: 0x0600100D RID: 4109 RVA: 0x00004D4D File Offset: 0x00002F4D
	public bool IsLoaded
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170003D0 RID: 976
	// (get) Token: 0x0600100E RID: 4110 RVA: 0x0000A4BA File Offset: 0x000086BA
	public GameObject Prefab
	{
		get
		{
			return null;
		}
	}

	// Token: 0x0600100F RID: 4111 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Unload()
	{
	}

	// Token: 0x06001010 RID: 4112 RVA: 0x0000A4BA File Offset: 0x000086BA
	public GameObject Create(Vector3 position, Quaternion rotation)
	{
		return null;
	}

	// Token: 0x06001011 RID: 4113 RVA: 0x0000B43D File Offset: 0x0000963D
	public void DrawIcon(Rect position)
	{
		GUI.DrawTexture(position, ShopIcons.CreditsIcon48x48);
	}

	// Token: 0x02000246 RID: 582
	private class DummyItemView : BaseUberStrikeItemView
	{
		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06001013 RID: 4115 RVA: 0x00008BFB File Offset: 0x00006DFB
		public override UberstrikeItemType ItemType
		{
			get
			{
				return UberstrikeItemType.Special;
			}
		}
	}
}
