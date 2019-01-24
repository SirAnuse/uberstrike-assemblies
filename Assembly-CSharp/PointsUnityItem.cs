using System;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200024B RID: 587
public class PointsUnityItem : IUnityItem
{
	// Token: 0x06001031 RID: 4145 RVA: 0x00065D30 File Offset: 0x00063F30
	public PointsUnityItem(int points)
	{
		this.Name = points.ToString("N0") + " Points";
		this.View = new PointsUnityItem.DummyItemView
		{
			Description = string.Format("An extra {0:N0} Points to fatten up your UberWallet!", points)
		};
	}

	// Token: 0x170003E1 RID: 993
	// (get) Token: 0x06001032 RID: 4146 RVA: 0x00003C84 File Offset: 0x00001E84
	public bool Equippable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x170003E2 RID: 994
	// (get) Token: 0x06001033 RID: 4147 RVA: 0x00004D4D File Offset: 0x00002F4D
	public bool IsLoaded
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170003E3 RID: 995
	// (get) Token: 0x06001034 RID: 4148 RVA: 0x0000B53D File Offset: 0x0000973D
	// (set) Token: 0x06001035 RID: 4149 RVA: 0x0000B545 File Offset: 0x00009745
	public string Name { get; private set; }

	// Token: 0x170003E4 RID: 996
	// (get) Token: 0x06001036 RID: 4150 RVA: 0x0000B54E File Offset: 0x0000974E
	// (set) Token: 0x06001037 RID: 4151 RVA: 0x0000B556 File Offset: 0x00009756
	public BaseUberStrikeItemView View { get; private set; }

	// Token: 0x170003E5 RID: 997
	// (get) Token: 0x06001038 RID: 4152 RVA: 0x0000A4BA File Offset: 0x000086BA
	public GameObject Prefab
	{
		get
		{
			return null;
		}
	}

	// Token: 0x06001039 RID: 4153 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Unload()
	{
	}

	// Token: 0x0600103A RID: 4154 RVA: 0x0000A4BA File Offset: 0x000086BA
	public GameObject Create(Vector3 position, Quaternion rotation)
	{
		return null;
	}

	// Token: 0x0600103B RID: 4155 RVA: 0x0000B55F File Offset: 0x0000975F
	public void DrawIcon(Rect position)
	{
		GUI.DrawTexture(position, ShopIcons.Points48x48);
	}

	// Token: 0x0200024C RID: 588
	private class DummyItemView : BaseUberStrikeItemView
	{
		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x0600103D RID: 4157 RVA: 0x00008BFB File Offset: 0x00006DFB
		public override UberstrikeItemType ItemType
		{
			get
			{
				return UberstrikeItemType.Special;
			}
		}
	}
}
