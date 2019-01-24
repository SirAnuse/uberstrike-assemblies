using System;
using System.Collections.Generic;
using System.Text;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000054 RID: 84
	public class ItemView
	{
		// Token: 0x060001A9 RID: 425 RVA: 0x00002050 File Offset: 0x00000250
		public ItemView()
		{
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000DCBC File Offset: 0x0000BEBC
		protected ItemView(ItemView itemView)
		{
			this.AmountRemaining = itemView.AmountRemaining;
			this.ClassId = itemView.ClassId;
			this.CreditsPerDay = itemView.CreditsPerDay;
			this.Description = itemView.Description;
			this.IsFeatured = itemView.IsFeatured;
			this.IsForSale = itemView.IsForSale;
			this.IsNew = itemView.IsNew;
			this.IsPopular = itemView.IsPopular;
			this.ItemId = itemView.ItemId;
			this.Name = itemView.Name;
			this.PrefabName = itemView.PrefabName;
			this.PermanentCredits = itemView.PermanentCredits;
			this.PointsPerDay = itemView.PointsPerDay;
			this.PurchaseType = itemView.PurchaseType;
			this.TypeId = itemView.TypeId;
			this.PackOneAmount = itemView.PackOneAmount;
			this.PackTwoAmount = itemView.PackTwoAmount;
			this.PackThreeAmount = itemView.PackThreeAmount;
			this.MaximumOwnableAmount = itemView.MaximumOwnableAmount;
			this.Enable1Day = itemView.Enable1Day;
			this.Enable7Days = itemView.Enable7Days;
			this.Enable30Days = itemView.Enable30Days;
			this.Enable90Days = itemView.Enable90Days;
			this.MaximumDurationDays = itemView.MaximumDurationDays;
			this.PermanentPoints = itemView.PermanentPoints;
			this.IsDisable = itemView.IsDisable;
			this.CustomProperties = ((itemView.CustomProperties == null) ? new Dictionary<string, string>() : new Dictionary<string, string>(itemView.CustomProperties));
			this.ItemProperties = ((this.ItemProperties == null) ? new Dictionary<ItemPropertyType, int>() : new Dictionary<ItemPropertyType, int>(itemView.ItemProperties));
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00002E44 File Offset: 0x00001044
		// (set) Token: 0x060001AC RID: 428 RVA: 0x00002E4C File Offset: 0x0000104C
		public int ItemId { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00002E55 File Offset: 0x00001055
		// (set) Token: 0x060001AE RID: 430 RVA: 0x00002E5D File Offset: 0x0000105D
		public string Name { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00002E66 File Offset: 0x00001066
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x00002E6E File Offset: 0x0000106E
		public string PrefabName { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00002E77 File Offset: 0x00001077
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x00002E7F File Offset: 0x0000107F
		public string Description { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00002E88 File Offset: 0x00001088
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x00002E90 File Offset: 0x00001090
		public int CreditsPerDay { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00002E99 File Offset: 0x00001099
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x00002EA1 File Offset: 0x000010A1
		public int PointsPerDay { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00002EAA File Offset: 0x000010AA
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00002EB2 File Offset: 0x000010B2
		public int PermanentPoints { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00002EBB File Offset: 0x000010BB
		// (set) Token: 0x060001BA RID: 442 RVA: 0x00002EC3 File Offset: 0x000010C3
		public int PermanentCredits { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00002ECC File Offset: 0x000010CC
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00002ED4 File Offset: 0x000010D4
		public bool IsDisable { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00002EDD File Offset: 0x000010DD
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00002EE5 File Offset: 0x000010E5
		public bool IsForSale { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00002EEE File Offset: 0x000010EE
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00002EF6 File Offset: 0x000010F6
		public bool IsNew { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00002EFF File Offset: 0x000010FF
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00002F07 File Offset: 0x00001107
		public bool IsPopular { get; set; }

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00002F10 File Offset: 0x00001110
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00002F18 File Offset: 0x00001118
		public bool IsFeatured { get; set; }

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00002F21 File Offset: 0x00001121
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00002F29 File Offset: 0x00001129
		public PurchaseType PurchaseType { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00002F32 File Offset: 0x00001132
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00002F3A File Offset: 0x0000113A
		public int TypeId { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00002F43 File Offset: 0x00001143
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00002F4B File Offset: 0x0000114B
		public int ClassId { get; set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00002F54 File Offset: 0x00001154
		// (set) Token: 0x060001CC RID: 460 RVA: 0x00002F5C File Offset: 0x0000115C
		public int AmountRemaining { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00002F65 File Offset: 0x00001165
		// (set) Token: 0x060001CE RID: 462 RVA: 0x00002F6D File Offset: 0x0000116D
		public int PackOneAmount { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00002F76 File Offset: 0x00001176
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x00002F7E File Offset: 0x0000117E
		public int PackTwoAmount { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00002F87 File Offset: 0x00001187
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x00002F8F File Offset: 0x0000118F
		public int PackThreeAmount { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00002F98 File Offset: 0x00001198
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x00002FA0 File Offset: 0x000011A0
		public bool Enable1Day { get; set; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00002FA9 File Offset: 0x000011A9
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00002FB1 File Offset: 0x000011B1
		public bool Enable7Days { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00002FBA File Offset: 0x000011BA
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x00002FC2 File Offset: 0x000011C2
		public bool Enable30Days { get; set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00002FCB File Offset: 0x000011CB
		// (set) Token: 0x060001DA RID: 474 RVA: 0x00002FD3 File Offset: 0x000011D3
		public bool Enable90Days { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00002FDC File Offset: 0x000011DC
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00002FE4 File Offset: 0x000011E4
		public int MaximumDurationDays { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00002FED File Offset: 0x000011ED
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00002FF5 File Offset: 0x000011F5
		public int MaximumOwnableAmount { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00002FFE File Offset: 0x000011FE
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00003006 File Offset: 0x00001206
		public Dictionary<string, string> CustomProperties { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000300F File Offset: 0x0000120F
		// (set) Token: 0x060001E2 RID: 482 RVA: 0x00003017 File Offset: 0x00001217
		public Dictionary<ItemPropertyType, int> ItemProperties { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00003020 File Offset: 0x00001220
		public bool EnablePermanent
		{
			get
			{
				return this.PermanentCredits != -1 || this.PermanentPoints != -1;
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000DE54 File Offset: 0x0000C054
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[ItemView: [AmountRemaining: ");
			stringBuilder.Append(this.AmountRemaining);
			stringBuilder.Append("][ClassId: ");
			stringBuilder.Append(this.ClassId);
			stringBuilder.Append("][CreditsPerDayShop: ");
			stringBuilder.Append(this.CreditsPerDay);
			stringBuilder.Append("][Description: ");
			stringBuilder.Append(this.Description);
			stringBuilder.Append("][IsFeatured: ");
			stringBuilder.Append(this.IsFeatured);
			stringBuilder.Append("][IsForSale: ");
			stringBuilder.Append(this.IsForSale);
			stringBuilder.Append("][IsNew: ");
			stringBuilder.Append(this.IsNew);
			stringBuilder.Append("][IsPopular: ");
			stringBuilder.Append(this.IsPopular);
			stringBuilder.Append("][ItemId: ");
			stringBuilder.Append(this.ItemId);
			stringBuilder.Append("][Name: ");
			stringBuilder.Append(this.Name);
			stringBuilder.Append("][PrefabName: ");
			stringBuilder.Append(this.PrefabName);
			stringBuilder.Append("][PermanentCredits: ");
			stringBuilder.Append(this.PermanentCredits);
			stringBuilder.Append("][PointsPerDayShop: ");
			stringBuilder.Append(this.PointsPerDay);
			stringBuilder.Append("][PurchaseType: ");
			stringBuilder.Append(this.PurchaseType);
			stringBuilder.Append("][TypeId: ");
			stringBuilder.Append(this.TypeId);
			stringBuilder.Append("][PackOneAmount: ");
			stringBuilder.Append(this.PackOneAmount);
			stringBuilder.Append("][PackTwoAmount: ");
			stringBuilder.Append(this.PackTwoAmount);
			stringBuilder.Append("][PackThreeAmount: ");
			stringBuilder.Append(this.PackThreeAmount);
			stringBuilder.Append("][MaximumOwnableAmount: ");
			stringBuilder.Append(this.MaximumOwnableAmount);
			stringBuilder.Append("][Enable1Day: ");
			stringBuilder.Append(this.Enable1Day);
			stringBuilder.Append("][Enable7Days: ");
			stringBuilder.Append(this.Enable7Days);
			stringBuilder.Append("][Enable30Days: ");
			stringBuilder.Append(this.Enable30Days);
			stringBuilder.Append("][Enable90Days: ");
			stringBuilder.Append(this.Enable90Days);
			stringBuilder.Append("][MaximumDurationDays: ");
			stringBuilder.Append(this.MaximumDurationDays);
			stringBuilder.Append("][PermanentPoints: ");
			stringBuilder.Append(this.PermanentPoints);
			stringBuilder.Append("][IsDisable: ");
			stringBuilder.Append(this.IsDisable);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
