using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200016C RID: 364
public class ItemToolTip : AutoMonoBehaviour<ItemToolTip>
{
	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x060009B1 RID: 2481 RVA: 0x000080EA File Offset: 0x000062EA
	// (set) Token: 0x060009B2 RID: 2482 RVA: 0x000080F2 File Offset: 0x000062F2
	public bool IsEnabled { get; private set; }

	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x060009B3 RID: 2483 RVA: 0x000080FB File Offset: 0x000062FB
	private float Alpha
	{
		get
		{
			return Mathf.Clamp01(this._alpha - Time.time);
		}
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x0003D5E8 File Offset: 0x0003B7E8
	private void OnGUI()
	{
		this._rect = this._rect.Lerp(this._finalRect, Time.deltaTime * 5f);
		if (this.IsEnabled && !PanelManager.IsAnyPanelOpen)
		{
			GUI.color = new Color(1f, 1f, 1f, this.Alpha);
			GUI.BeginGroup(this._rect, BlueStonez.box_grey_outlined);
			this._item.DrawIcon(new Rect(20f, 10f, 48f, 48f));
			GUI.Label(new Rect(75f, 15f, 200f, 30f), this._item.View.Name, BlueStonez.label_interparkbold_13pt_left);
			GUI.Label(new Rect(20f, 70f, 220f, 50f), this._description, BlueStonez.label_interparkmed_11pt_left);
			if (this._duration != BuyingDurationType.None)
			{
				GUIContent content = new GUIContent(ShopUtils.PrintDuration(this._duration), ShopIcons.ItemexpirationIcon);
				GUI.Label(new Rect(75f, 40f, 200f, 20f), content, BlueStonez.label_interparkbold_11pt_left);
			}
			else if (this._daysLeft == 0)
			{
				GUIContent content2 = new GUIContent(ShopUtils.PrintDuration(BuyingDurationType.Permanent), ShopIcons.ItemexpirationIcon);
				GUI.Label(new Rect(75f, 40f, 200f, 20f), content2, BlueStonez.label_interparkmed_11pt_left);
			}
			else if (this._daysLeft > 0)
			{
				GUIContent content3 = new GUIContent(string.Format(LocalizedStrings.NDaysLeft, this._daysLeft), ShopIcons.ItemexpirationIcon);
				GUI.Label(new Rect(75f, 40f, 200f, 20f), content3, BlueStonez.label_interparkbold_11pt_left);
			}
			if (this.OnDrawItemDetails != null)
			{
				this.OnDrawItemDetails();
			}
			GUI.Label(new Rect(20f, 200f, 210f, 20f), LocalizedStrings.LevelRequired + this._level, BlueStonez.label_interparkbold_11pt_left);
			if (this._criticalHit > 0)
			{
				GUI.Label(new Rect(20f, 218f, 210f, 20f), LocalizedStrings.CriticalHitBonus + this._criticalHit + "%", BlueStonez.label_interparkmed_11pt_left);
			}
			GUI.EndGroup();
			this.OnDrawTip();
			GUI.color = Color.white;
			if (this._alpha - Time.time < 0f)
			{
				this.IsEnabled = false;
			}
		}
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x0003D888 File Offset: 0x0003BA88
	public void SetItem(IUnityItem item, Rect bounds, PopupViewSide side, int daysLeft = -1, BuyingDurationType duration = BuyingDurationType.None)
	{
		if (Event.current.type != EventType.Repaint || item == null || Singleton<ItemManager>.Instance.IsDefaultGearItem(item.View.PrefabName) || (item.View.LevelLock > PlayerDataManager.PlayerLevel && !Singleton<InventoryManager>.Instance.Contains(item.View.ID)))
		{
			return;
		}
		bool flag = this._alpha < Time.time + 0.1f;
		this._alpha = Mathf.Lerp(this._alpha, Time.time + 1.1f, Time.deltaTime * 12f);
		if (this._item != item || this._cacheRect != bounds || !this.IsEnabled)
		{
			this._cacheRect = bounds;
			bounds = GUITools.ToGlobal(bounds);
			this.IsEnabled = true;
			this._item = item;
			this._level = ((item.View == null) ? 0 : item.View.LevelLock);
			this._description = ((item.View == null) ? string.Empty : item.View.Description);
			this._daysLeft = daysLeft;
			this._criticalHit = 0;
			this._duration = duration;
			switch (side)
			{
			case PopupViewSide.Left:
			{
				float tipPosition = bounds.y - 10f + bounds.height * 0.5f;
				Rect rect = new Rect(bounds.x - this.Size.x - 9f, bounds.y - this.Size.y * 0.5f, this.Size.x, this.Size.y);
				Rect rect2 = new Rect(rect.xMax - 1f, tipPosition, 12f, 21f);
				if (rect.y <= (float)GlobalUIRibbon.Instance.Height())
				{
					rect.y += (float)GlobalUIRibbon.Instance.Height() - rect.y;
				}
				if (rect.yMax >= (float)Screen.height)
				{
					rect.y -= rect.yMax - (float)Screen.height;
				}
				if (rect2.y < this._finalRect.y || rect2.yMax > this._finalRect.yMax || this._finalRect.x != rect.x)
				{
					this._finalRect = rect;
					if (flag)
					{
						this._rect = rect;
					}
				}
				this.OnDrawTip = delegate()
				{
					GUI.DrawTexture(new Rect(this._rect.xMax - 1f, tipPosition, 12f, 21f), ConsumableHudTextures.TooltipRight);
				};
				break;
			}
			case PopupViewSide.Top:
			{
				float tipPosition = bounds.x - 10f + bounds.width * 0.5f;
				Rect rect3 = new Rect(bounds.x + (bounds.width - this.Size.x) * 0.5f, bounds.y - this.Size.y - 9f, this.Size.x, this.Size.y);
				Rect rect4 = new Rect(tipPosition, rect3.yMax - 1f, 21f, 12f);
				if (rect3.xMin <= 10f)
				{
					rect3.x = 10f;
				}
				if (rect3.xMax >= (float)(Screen.width - 10))
				{
					rect3.x -= rect3.xMax - (float)Screen.width + 10f;
				}
				if (rect4.x < this._finalRect.x || rect4.xMax > this._finalRect.xMax || this._finalRect.y != rect3.y)
				{
					this._finalRect = rect3;
					if (flag)
					{
						this._rect = rect3;
					}
				}
				this.OnDrawTip = delegate()
				{
					GUI.DrawTexture(new Rect(tipPosition, this._rect.yMax - 1f, 21f, 12f), ConsumableHudTextures.TooltipDown);
				};
				break;
			}
			}
			switch (item.View.ItemClass)
			{
			case UberstrikeItemClass.WeaponMelee:
			{
				this.OnDrawItemDetails = new Action(this.DrawMeleeWeapon);
				UberStrikeItemWeaponView uberStrikeItemWeaponView = item.View as UberStrikeItemWeaponView;
				if (uberStrikeItemWeaponView != null)
				{
					this._damage.Value = WeaponConfigurationHelper.GetDamage(uberStrikeItemWeaponView);
					this._damage.Max = WeaponConfigurationHelper.MaxDamage;
					this._fireRate.Value = WeaponConfigurationHelper.GetRateOfFire(uberStrikeItemWeaponView);
					this._fireRate.Max = WeaponConfigurationHelper.MaxRateOfFire;
				}
				return;
			}
			case UberstrikeItemClass.WeaponMachinegun:
			case UberstrikeItemClass.WeaponShotgun:
			case UberstrikeItemClass.WeaponSniperRifle:
			{
				this.OnDrawItemDetails = new Action(this.DrawInstantHitWeapon);
				UberStrikeItemWeaponView uberStrikeItemWeaponView2 = item.View as UberStrikeItemWeaponView;
				if (uberStrikeItemWeaponView2 != null)
				{
					this._ammo.Value = WeaponConfigurationHelper.GetAmmo(uberStrikeItemWeaponView2);
					this._ammo.Max = WeaponConfigurationHelper.MaxAmmo;
					this._damage.Value = WeaponConfigurationHelper.GetDamage(uberStrikeItemWeaponView2);
					this._damage.Max = WeaponConfigurationHelper.MaxDamage;
					this._fireRate.Value = WeaponConfigurationHelper.GetRateOfFire(uberStrikeItemWeaponView2);
					this._fireRate.Max = WeaponConfigurationHelper.MaxRateOfFire;
					this._accuracy.Value = WeaponConfigurationHelper.MaxAccuracySpread - WeaponConfigurationHelper.GetAccuracySpread(uberStrikeItemWeaponView2);
					this._accuracy.Max = WeaponConfigurationHelper.MaxAccuracySpread;
                    _armorPierced.Value = WeaponConfigurationHelper.GetArmorPierced(uberStrikeItemWeaponView2);
                    _armorPierced.Max = WeaponConfigurationHelper.MaxArmorPierced;

                    if (item.View.ItemProperties.ContainsKey(ItemPropertyType.CritDamageBonus))
					{
						this._criticalHit = item.View.ItemProperties[ItemPropertyType.CritDamageBonus];
					}
					else
					{
						this._criticalHit = 0;
					}
				}
				return;
			}
			case UberstrikeItemClass.WeaponCannon:
			case UberstrikeItemClass.WeaponSplattergun:
			case UberstrikeItemClass.WeaponLauncher:
			{
				this.OnDrawItemDetails = new Action(this.DrawProjectileWeapon);
				UberStrikeItemWeaponView uberStrikeItemWeaponView3 = item.View as UberStrikeItemWeaponView;
				if (uberStrikeItemWeaponView3 != null)
				{
					this._ammo.Value = WeaponConfigurationHelper.GetAmmo(uberStrikeItemWeaponView3);
					this._ammo.Max = WeaponConfigurationHelper.MaxAmmo;
					this._damage.Value = WeaponConfigurationHelper.GetDamage(uberStrikeItemWeaponView3);
					this._damage.Max = WeaponConfigurationHelper.MaxDamage;
					this._fireRate.Value = WeaponConfigurationHelper.GetRateOfFire(uberStrikeItemWeaponView3);
					this._fireRate.Max = WeaponConfigurationHelper.MaxRateOfFire;
					this._velocity.Value = WeaponConfigurationHelper.GetProjectileSpeed(uberStrikeItemWeaponView3);
					this._velocity.Max = WeaponConfigurationHelper.MaxProjectileSpeed;
					this._damageRadius.Value = WeaponConfigurationHelper.GetSplashRadius(uberStrikeItemWeaponView3);
					this._damageRadius.Max = WeaponConfigurationHelper.MaxSplashRadius;
				}
				return;
			}
			case UberstrikeItemClass.GearBoots:
			case UberstrikeItemClass.GearHead:
			case UberstrikeItemClass.GearFace:
			case UberstrikeItemClass.GearUpperBody:
			case UberstrikeItemClass.GearLowerBody:
			case UberstrikeItemClass.GearGloves:
			case UberstrikeItemClass.GearHolo:
				this.OnDrawItemDetails = new Action(this.DrawGear);
				this._armorCarried.Value = (float)((UberStrikeItemGearView)item.View).ArmorPoints;
				this._armorCarried.Max = 200f;
				return;
			case UberstrikeItemClass.QuickUseGeneral:
			case UberstrikeItemClass.QuickUseGrenade:
			case UberstrikeItemClass.QuickUseMine:
				this.OnDrawItemDetails = new Action(this.DrawQuickItem);
				return;
			}
			this.OnDrawItemDetails = null;
		}
	}

	// Token: 0x060009B6 RID: 2486 RVA: 0x0003E010 File Offset: 0x0003C210
	public void ComparisonOverlay(Rect position, float value, float otherValue)
	{
		float num = position.width - 80f - 50f;
		float num2 = (num - 4f) * Mathf.Clamp01(value);
		float num3 = (num - 4f) * Mathf.Clamp01(Mathf.Abs(value - otherValue));
		GUI.BeginGroup(position);
		if (value < otherValue)
		{
			GUI.color = Color.green.SetAlpha(this.Alpha * 0.9f);
			GUI.Label(new Rect(82f + num2, 3f, num3, 8f), string.Empty, BlueStonez.progressbar_thumb);
		}
		else
		{
			GUI.color = Color.red.SetAlpha(this.Alpha * 0.9f);
			GUI.Label(new Rect(82f + num2 - num3, 3f, num3, 8f), string.Empty, BlueStonez.progressbar_thumb);
		}
		GUI.color = new Color(1f, 1f, 1f, this.Alpha);
		GUI.EndGroup();
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x0003E114 File Offset: 0x0003C314
	public void ProgressBar(Rect position, string text, float percentage, Color barColor, string value)
	{
		float num = position.width - 80f - 50f;
		GUI.BeginGroup(position);
		GUI.Label(new Rect(0f, 0f, 80f, 14f), text, BlueStonez.label_interparkbold_11pt_left);
		GUI.Label(new Rect(80f, 1f, num, 12f), GUIContent.none, BlueStonez.progressbar_background);
		GUI.color = barColor.SetAlpha(this.Alpha);
		GUI.Label(new Rect(82f, 3f, (num - 4f) * Mathf.Clamp01(percentage), 8f), string.Empty, BlueStonez.progressbar_thumb);
		GUI.color = new Color(1f, 1f, 1f, this.Alpha);
		if (!string.IsNullOrEmpty(value))
		{
			GUI.Label(new Rect(80f + num + 10f, 0f, 40f, 14f), value, BlueStonez.label_interparkmed_10pt_left);
		}
		GUI.EndGroup();
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x0003E224 File Offset: 0x0003C424
	private void DrawGear()
	{
		this.ProgressBar(new Rect(20f, 120f, 200f, 12f), this._armorCarried.Title, this._armorCarried.Percent, ColorScheme.ProgressBar, string.Empty);
	}

	// Token: 0x060009B9 RID: 2489 RVA: 0x0003E270 File Offset: 0x0003C470
	private void DrawProjectileWeapon()
	{
		bool flag = Singleton<DragAndDrop>.Instance.IsDragging && ShopUtils.IsProjectileWeapon(Singleton<DragAndDrop>.Instance.DraggedItem.Item) && Singleton<DragAndDrop>.Instance.DraggedItem.Item.View.ItemClass == this._item.View.ItemClass;
		this.ProgressBar(new Rect(20f, 120f, 200f, 12f), this._damage.Title, this._damage.Percent, ColorScheme.ProgressBar, string.Empty);
		this.ProgressBar(new Rect(20f, 135f, 200f, 12f), this._fireRate.Title, 1f - this._fireRate.Percent, ColorScheme.ProgressBar, string.Empty);
		this.ProgressBar(new Rect(20f, 150f, 200f, 12f), this._velocity.Title, this._velocity.Percent, ColorScheme.ProgressBar, string.Empty);
		this.ProgressBar(new Rect(20f, 165f, 200f, 12f), this._damageRadius.Title, this._damageRadius.Percent, ColorScheme.ProgressBar, string.Empty);
		this.ProgressBar(new Rect(20f, 180f, 200f, 12f), this._ammo.Title, this._ammo.Percent, ColorScheme.ProgressBar, string.Empty);
		if (flag)
		{
			UberStrikeItemWeaponView view = Singleton<DragAndDrop>.Instance.DraggedItem.Item.View as UberStrikeItemWeaponView;
			this.ComparisonOverlay(new Rect(20f, 120f, 200f, 12f), this._damage.Percent, WeaponConfigurationHelper.GetDamageNormalized(view));
			this.ComparisonOverlay(new Rect(20f, 135f, 200f, 12f), 1f - this._fireRate.Percent, 1f - WeaponConfigurationHelper.GetRateOfFireNormalized(view));
			this.ComparisonOverlay(new Rect(20f, 150f, 200f, 12f), this._velocity.Percent, WeaponConfigurationHelper.GetProjectileSpeedNormalized(view));
			this.ComparisonOverlay(new Rect(20f, 165f, 200f, 12f), this._damageRadius.Percent, WeaponConfigurationHelper.GetSplashRadiusNormalized(view));
		}
	}

	// Token: 0x060009BA RID: 2490 RVA: 0x0003E504 File Offset: 0x0003C704
	private void DrawInstantHitWeapon()
	{
		bool flag = Singleton<DragAndDrop>.Instance.IsDragging && ShopUtils.IsInstantHitWeapon(Singleton<DragAndDrop>.Instance.DraggedItem.Item) && Singleton<DragAndDrop>.Instance.DraggedItem.Item.View.ItemClass == this._item.View.ItemClass;
		this.ProgressBar(new Rect(20f, 120f, 200f, 12f), this._damage.Title, this._damage.Percent, ColorScheme.ProgressBar, string.Empty);
		this.ProgressBar(new Rect(20f, 135f, 200f, 12f), this._fireRate.Title, 1f - this._fireRate.Percent, ColorScheme.ProgressBar, string.Empty);
		this.ProgressBar(new Rect(20f, 150f, 200f, 12f), this._accuracy.Title, this._accuracy.Percent, ColorScheme.ProgressBar, string.Empty);
		this.ProgressBar(new Rect(20f, 165f, 200f, 12f), this._ammo.Title, this._ammo.Percent, ColorScheme.ProgressBar, string.Empty);
        this.ProgressBar(new Rect(20f, 180f, 200f, 12f), this._armorPierced.Title, this._armorPierced.Percent, ColorScheme.ProgressBar, string.Empty);
        if (flag)
		{
			UberStrikeItemWeaponView view = Singleton<DragAndDrop>.Instance.DraggedItem.Item.View as UberStrikeItemWeaponView;
			this.ComparisonOverlay(new Rect(20f, 120f, 200f, 12f), this._damage.Percent, WeaponConfigurationHelper.GetDamageNormalized(view));
			this.ComparisonOverlay(new Rect(20f, 135f, 200f, 12f), 1f - this._fireRate.Percent, 1f - WeaponConfigurationHelper.GetRateOfFireNormalized(view));
			this.ComparisonOverlay(new Rect(20f, 150f, 200f, 12f), this._accuracy.Percent, 1f - WeaponConfigurationHelper.GetAccuracySpreadNormalized(view));
		}
	}

	// Token: 0x060009BB RID: 2491 RVA: 0x0003E72C File Offset: 0x0003C92C
	private void DrawMeleeWeapon()
	{
		this.ProgressBar(new Rect(20f, 120f, 200f, 12f), this._damage.Title, this._damage.Percent, ColorScheme.ProgressBar, string.Empty);
		this.ProgressBar(new Rect(20f, 135f, 200f, 12f), this._fireRate.Title, 1f - this._fireRate.Percent, ColorScheme.ProgressBar, string.Empty);
		if (Singleton<DragAndDrop>.Instance.IsDragging && ShopUtils.IsMeleeWeapon(Singleton<DragAndDrop>.Instance.DraggedItem.Item))
		{
			UberStrikeItemWeaponView view = Singleton<DragAndDrop>.Instance.DraggedItem.Item.View as UberStrikeItemWeaponView;
			this.ComparisonOverlay(new Rect(20f, 120f, 200f, 12f), this._damage.Percent, WeaponConfigurationHelper.GetDamageNormalized(view));
			this.ComparisonOverlay(new Rect(20f, 135f, 200f, 12f), 1f - this._fireRate.Percent, 1f - WeaponConfigurationHelper.GetRateOfFireNormalized(view));
		}
	}

	// Token: 0x060009BC RID: 2492 RVA: 0x0003E86C File Offset: 0x0003CA6C
	private void DrawQuickItem()
	{
		if (this._item != null)
		{
			QuickItemConfiguration quickItemConfiguration = this._item.View as QuickItemConfiguration;
			if (this._item.View is HealthBuffConfiguration)
			{
				HealthBuffConfiguration healthBuffConfiguration = this._item.View as HealthBuffConfiguration;
				GUI.Label(new Rect(20f, 102f, 200f, 20f), LocalizedStrings.HealthColon + healthBuffConfiguration.GetHealthBonusDescription(), BlueStonez.label_interparkbold_11pt_left);
				GUI.Label(new Rect(20f, 117f, 200f, 20f), LocalizedStrings.TimeColon + ((healthBuffConfiguration.IncreaseTimes <= 0) ? LocalizedStrings.Instant : (((float)(healthBuffConfiguration.IncreaseFrequency * healthBuffConfiguration.IncreaseTimes) / 1000f).ToString("f1") + "s")), BlueStonez.label_interparkbold_11pt_left);
			}
			else if (this._item.View is AmmoBuffConfiguration)
			{
				AmmoBuffConfiguration ammoBuffConfiguration = this._item.View as AmmoBuffConfiguration;
				GUI.Label(new Rect(20f, 102f, 200f, 20f), LocalizedStrings.AmmoColon + ammoBuffConfiguration.GetAmmoBonusDescription(), BlueStonez.label_interparkbold_11pt_left);
				GUI.Label(new Rect(20f, 117f, 200f, 20f), LocalizedStrings.TimeColon + ((ammoBuffConfiguration.IncreaseTimes <= 0) ? LocalizedStrings.Instant : (((float)(ammoBuffConfiguration.IncreaseFrequency * ammoBuffConfiguration.IncreaseTimes) / 1000f).ToString("f1") + "s")), BlueStonez.label_interparkbold_11pt_left);
			}
			else if (this._item.View is ArmorBuffConfiguration)
			{
				ArmorBuffConfiguration armorBuffConfiguration = this._item.View as ArmorBuffConfiguration;
				GUI.Label(new Rect(20f, 102f, 200f, 20f), LocalizedStrings.ArmorColon + armorBuffConfiguration.GetArmorBonusDescription(), BlueStonez.label_interparkbold_11pt_left);
				GUI.Label(new Rect(20f, 117f, 200f, 20f), LocalizedStrings.TimeColon + ((armorBuffConfiguration.IncreaseTimes <= 0) ? LocalizedStrings.Instant : (((float)(armorBuffConfiguration.IncreaseFrequency * armorBuffConfiguration.IncreaseTimes) / 1000f).ToString("f1") + "s")), BlueStonez.label_interparkbold_11pt_left);
			}
			else if (this._item.View is ExplosiveGrenadeConfiguration)
			{
				ExplosiveGrenadeConfiguration explosiveGrenadeConfiguration = this._item.View as ExplosiveGrenadeConfiguration;
				GUI.Label(new Rect(20f, 102f, 200f, 20f), LocalizedStrings.DamageColon + explosiveGrenadeConfiguration.Damage + "HP", BlueStonez.label_interparkbold_11pt_left);
				GUI.Label(new Rect(20f, 117f, 200f, 20f), LocalizedStrings.RadiusColon + explosiveGrenadeConfiguration.SplashRadius + "m", BlueStonez.label_interparkbold_11pt_left);
			}
			else if (this._item.View is SpringGrenadeConfiguration)
			{
				SpringGrenadeConfiguration springGrenadeConfiguration = this._item.View as SpringGrenadeConfiguration;
				GUI.Label(new Rect(20f, 102f, 200f, 20f), LocalizedStrings.ForceColon + springGrenadeConfiguration.Force, BlueStonez.label_interparkbold_11pt_left);
				GUI.Label(new Rect(20f, 117f, 200f, 20f), LocalizedStrings.LifetimeColon + springGrenadeConfiguration.LifeTime + "s", BlueStonez.label_interparkbold_11pt_left);
			}
			if (quickItemConfiguration != null)
			{
				GUI.Label(new Rect(20f, 132f, 200f, 20f), LocalizedStrings.WarmupColon + ((quickItemConfiguration.WarmUpTime <= 0) ? LocalizedStrings.Instant : (((float)quickItemConfiguration.WarmUpTime / 1000f).ToString("f1") + "s")), BlueStonez.label_interparkbold_11pt_left);
				GUI.Label(new Rect(20f, 147f, 200f, 20f), LocalizedStrings.CooldownColon + ((float)quickItemConfiguration.CoolDownTime / 1000f).ToString("f1") + "s", BlueStonez.label_interparkbold_11pt_left);
				GUI.Label(new Rect(20f, 162f, 200f, 20f), LocalizedStrings.UsesPerLifeColon + ((quickItemConfiguration.UsesPerLife <= 0) ? LocalizedStrings.Unlimited : quickItemConfiguration.UsesPerLife.ToString()), BlueStonez.label_interparkbold_11pt_left);
				GUI.Label(new Rect(20f, 177f, 200f, 20f), LocalizedStrings.UsesPerGameColon + ((quickItemConfiguration.UsesPerGame <= 0) ? LocalizedStrings.Unlimited : quickItemConfiguration.UsesPerGame.ToString()), BlueStonez.label_interparkbold_11pt_left);
			}
		}
	}

	// Token: 0x040009D3 RID: 2515
	private const int TextWidth = 80;

	// Token: 0x040009D4 RID: 2516
	private readonly Vector2 Size = new Vector2(260f, 240f);

	// Token: 0x040009D5 RID: 2517
	private ItemToolTip.FloatPropertyBar _ammo = new ItemToolTip.FloatPropertyBar(LocalizedStrings.Ammo);

    private ItemToolTip.FloatPropertyBar _armorPierced = new ItemToolTip.FloatPropertyBar(LocalizedStrings.ArmorPierced);

    // Token: 0x040009D6 RID: 2518
    private ItemToolTip.FloatPropertyBar _damage = new ItemToolTip.FloatPropertyBar(LocalizedStrings.Damage);

	// Token: 0x040009D7 RID: 2519
	private ItemToolTip.FloatPropertyBar _fireRate = new ItemToolTip.FloatPropertyBar(LocalizedStrings.RateOfFire);

	// Token: 0x040009D8 RID: 2520
	private ItemToolTip.FloatPropertyBar _accuracy = new ItemToolTip.FloatPropertyBar(LocalizedStrings.Accuracy);

	// Token: 0x040009D9 RID: 2521
	private ItemToolTip.FloatPropertyBar _velocity = new ItemToolTip.FloatPropertyBar(LocalizedStrings.Velocity);

	// Token: 0x040009DA RID: 2522
	private ItemToolTip.FloatPropertyBar _damageRadius = new ItemToolTip.FloatPropertyBar(LocalizedStrings.Radius);

	// Token: 0x040009DB RID: 2523
	private ItemToolTip.FloatPropertyBar _armorCarried = new ItemToolTip.FloatPropertyBar(LocalizedStrings.ArmorCarried);

	// Token: 0x040009DC RID: 2524
	private Rect _finalRect = new Rect(0f, 0f, 260f, 230f);

	// Token: 0x040009DD RID: 2525
	private Rect _rect = new Rect(0f, 0f, 260f, 230f);

	// Token: 0x040009DE RID: 2526
	private int _level;

	// Token: 0x040009DF RID: 2527
	private int _daysLeft;

	// Token: 0x040009E0 RID: 2528
	private int _criticalHit;

	// Token: 0x040009E1 RID: 2529
	private string _description;

	// Token: 0x040009E2 RID: 2530
	private IUnityItem _item;

	// Token: 0x040009E3 RID: 2531
	private Rect _cacheRect;

	// Token: 0x040009E4 RID: 2532
	private float _alpha;

	// Token: 0x040009E5 RID: 2533
	private BuyingDurationType _duration;

	// Token: 0x040009E6 RID: 2534
	private Action OnDrawItemDetails;

	// Token: 0x040009E7 RID: 2535
	private Action OnDrawTip;

	// Token: 0x0200016D RID: 365
	private class FloatPropertyBar
	{
		// Token: 0x060009BD RID: 2493 RVA: 0x0000810E File Offset: 0x0000630E
		public FloatPropertyBar(string title)
		{
			this.Title = title;
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x00008128 File Offset: 0x00006328
		// (set) Token: 0x060009BF RID: 2495 RVA: 0x00008130 File Offset: 0x00006330
		public string Title { get; private set; }

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x00008139 File Offset: 0x00006339
		public float SmoothValue
		{
			get
			{
				return Mathf.Lerp(this._lastValue, this.Value, (Time.time - this._time) * 5f);
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x0000815E File Offset: 0x0000635E
		// (set) Token: 0x060009C2 RID: 2498 RVA: 0x00008166 File Offset: 0x00006366
		public float Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._lastValue = this._value;
				this._time = Time.time;
				this._value = value;
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x060009C3 RID: 2499 RVA: 0x00008186 File Offset: 0x00006386
		public float Percent
		{
			get
			{
				return this.SmoothValue / this.Max;
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x00008195 File Offset: 0x00006395
		// (set) Token: 0x060009C5 RID: 2501 RVA: 0x0000819D File Offset: 0x0000639D
		public float Max
		{
			get
			{
				return this._max;
			}
			set
			{
				this._max = Mathf.Max(value, 1f);
			}
		}

		// Token: 0x040009E9 RID: 2537
		private float _value;

		// Token: 0x040009EA RID: 2538
		private float _lastValue;

		// Token: 0x040009EB RID: 2539
		private float _max = 1f;

		// Token: 0x040009EC RID: 2540
		private float _time;
	}
}
