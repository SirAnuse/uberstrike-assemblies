using System;
using UnityEngine;

// Token: 0x02000259 RID: 601
public class QuickItemRestriction
{
	// Token: 0x06001098 RID: 4248 RVA: 0x00066B54 File Offset: 0x00064D54
	public QuickItemRestriction()
	{
		this._quickItemRestrictions = new QuickItemRestriction.RestrictedUsage[LoadoutManager.QuickSlots.Length];
		for (int i = 0; i < this._quickItemRestrictions.Length; i++)
		{
			this._quickItemRestrictions[i] = new QuickItemRestriction.RestrictedUsage();
		}
	}

	// Token: 0x17000406 RID: 1030
	// (get) Token: 0x06001099 RID: 4249 RVA: 0x0000B8D0 File Offset: 0x00009AD0
	// (set) Token: 0x0600109A RID: 4250 RVA: 0x0000B8D8 File Offset: 0x00009AD8
	public bool IsEnabled { get; set; }

	// Token: 0x0600109B RID: 4251 RVA: 0x00066BA0 File Offset: 0x00064DA0
	public void InitializeSlot(int index, QuickItem quickItem = null, int amountRemaining = 0)
	{
		if (index >= 0 && index < this._quickItemRestrictions.Length)
		{
			if (this.IsEnabled && quickItem != null)
			{
				if (quickItem.Configuration.ID != this._quickItemRestrictions[index].ItemId)
				{
					this._quickItemRestrictions[index].Init(quickItem);
				}
			}
			else
			{
				this._quickItemRestrictions[index].Init(null);
			}
			this._quickItemRestrictions[index].RenewLifeUses();
			if (quickItem != null)
			{
				int num = Mathf.Min(amountRemaining, this._quickItemRestrictions[index].RemainingLifeUses);
				quickItem.Behaviour.CurrentAmount = num;
				quickItem.Configuration.AmountRemaining = num;
			}
		}
	}

	// Token: 0x0600109C RID: 4252 RVA: 0x00066C5C File Offset: 0x00064E5C
	public void RenewGameUses()
	{
		foreach (QuickItemRestriction.RestrictedUsage restrictedUsage in this._quickItemRestrictions)
		{
			restrictedUsage.RenewGameUses();
		}
	}

	// Token: 0x0600109D RID: 4253 RVA: 0x00066C90 File Offset: 0x00064E90
	public void RenewRoundUses()
	{
		foreach (QuickItemRestriction.RestrictedUsage restrictedUsage in this._quickItemRestrictions)
		{
			restrictedUsage.RenewRoundUses();
		}
	}

	// Token: 0x0600109E RID: 4254 RVA: 0x00066CC4 File Offset: 0x00064EC4
	public void RenewLifeUses()
	{
		foreach (QuickItemRestriction.RestrictedUsage restrictedUsage in this._quickItemRestrictions)
		{
			restrictedUsage.RenewLifeUses();
		}
	}

	// Token: 0x0600109F RID: 4255 RVA: 0x0000B8E1 File Offset: 0x00009AE1
	public void DecreaseUse(int index)
	{
		if (this.IsEnabled && index < this._quickItemRestrictions.Length && index >= 0)
		{
			this._quickItemRestrictions[index].DecreaseUse();
		}
	}

	// Token: 0x060010A0 RID: 4256 RVA: 0x00066CF8 File Offset: 0x00064EF8
	public int GetCurrentAvailableAmount(int index, int inventoryRemainingAmount)
	{
		if (!this.IsEnabled || index >= this._quickItemRestrictions.Length || index < 0)
		{
			return inventoryRemainingAmount;
		}
		QuickItemRestriction.RestrictedUsage restrictedUsage = this._quickItemRestrictions[index];
		if (inventoryRemainingAmount >= restrictedUsage.RemainingLifeUses)
		{
			return restrictedUsage.RemainingLifeUses;
		}
		return inventoryRemainingAmount;
	}

	// Token: 0x04000E1A RID: 3610
	private QuickItemRestriction.RestrictedUsage[] _quickItemRestrictions;

	// Token: 0x0200025A RID: 602
	private class RestrictedUsage
	{
		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x060010A2 RID: 4258 RVA: 0x0000B910 File Offset: 0x00009B10
		// (set) Token: 0x060010A3 RID: 4259 RVA: 0x0000B918 File Offset: 0x00009B18
		public int RemainingGameUses { get; private set; }

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x060010A4 RID: 4260 RVA: 0x0000B921 File Offset: 0x00009B21
		// (set) Token: 0x060010A5 RID: 4261 RVA: 0x0000B929 File Offset: 0x00009B29
		public int RemainingRoundUses { get; private set; }

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x060010A6 RID: 4262 RVA: 0x0000B932 File Offset: 0x00009B32
		// (set) Token: 0x060010A7 RID: 4263 RVA: 0x0000B93A File Offset: 0x00009B3A
		public int RemainingLifeUses { get; private set; }

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x060010A8 RID: 4264 RVA: 0x0000B943 File Offset: 0x00009B43
		// (set) Token: 0x060010A9 RID: 4265 RVA: 0x0000B94B File Offset: 0x00009B4B
		public int ItemId { get; private set; }

		// Token: 0x060010AA RID: 4266 RVA: 0x00066D44 File Offset: 0x00064F44
		public void Init(QuickItem item = null)
		{
			if (item != null)
			{
				this.ItemId = item.Configuration.ID;
				this._totalUsesPerGame = ((item.Configuration.UsesPerGame <= 0) ? int.MaxValue : item.Configuration.UsesPerGame);
				this._totalUsesPerRound = ((item.Configuration.UsesPerRound <= 0) ? int.MaxValue : item.Configuration.UsesPerRound);
				this._totalUsesPerLife = ((item.Configuration.UsesPerLife <= 0) ? int.MaxValue : item.Configuration.UsesPerLife);
			}
			else
			{
				this.ItemId = 0;
				this._totalUsesPerGame = int.MaxValue;
				this._totalUsesPerRound = int.MaxValue;
				this._totalUsesPerLife = int.MaxValue;
			}
			this.RenewGameUses();
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x0000B954 File Offset: 0x00009B54
		public void RenewGameUses()
		{
			this.RemainingGameUses = this._totalUsesPerGame;
			this.RemainingRoundUses = this._totalUsesPerRound;
			this.RemainingLifeUses = this._totalUsesPerLife;
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x0000B97A File Offset: 0x00009B7A
		public void RenewRoundUses()
		{
			this.RemainingRoundUses = Mathf.Min(this._totalUsesPerRound, this.RemainingGameUses);
			this.RenewLifeUses();
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x0000B999 File Offset: 0x00009B99
		public void RenewLifeUses()
		{
			this.RemainingLifeUses = Mathf.Min(this._totalUsesPerLife, this.RemainingRoundUses);
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x0000B9B2 File Offset: 0x00009BB2
		public void DecreaseUse()
		{
			this.RemainingGameUses = Mathf.Max(this.RemainingGameUses - 1, 0);
			this.RemainingRoundUses = Mathf.Max(this.RemainingRoundUses - 1, 0);
			this.RemainingLifeUses = Mathf.Max(this.RemainingLifeUses - 1, 0);
		}

		// Token: 0x04000E1C RID: 3612
		private int _totalUsesPerGame;

		// Token: 0x04000E1D RID: 3613
		private int _totalUsesPerRound;

		// Token: 0x04000E1E RID: 3614
		private int _totalUsesPerLife;
	}
}
