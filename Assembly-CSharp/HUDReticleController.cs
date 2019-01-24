using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000334 RID: 820
public class HUDReticleController : MonoBehaviour
{
	// Token: 0x17000549 RID: 1353
	// (get) Token: 0x060016D6 RID: 5846 RVA: 0x0000F5A3 File Offset: 0x0000D7A3
	private bool IsSecondaryReticle
	{
		get
		{
			return GameState.Current.PlayerData.ActiveWeapon.Value.View.SecondaryActionReticle != 1;
		}
	}

	// Token: 0x1700054A RID: 1354
	// (get) Token: 0x060016D7 RID: 5847 RVA: 0x0000F5C9 File Offset: 0x0000D7C9
	public ReticleView ActiveReticle
	{
		get
		{
			return (!this.reticles.ContainsKey(this.activeReticleId)) ? null : this.reticles[this.activeReticleId];
		}
	}

	// Token: 0x060016D8 RID: 5848 RVA: 0x0000F159 File Offset: 0x0000D359
	private void OnEnable()
	{
		GameState.Current.PlayerData.ActiveWeapon.Fire();
	}

	// Token: 0x060016D9 RID: 5849 RVA: 0x0000F5F8 File Offset: 0x0000D7F8
	private void OnDisable()
	{
		this.zoomInView.Show(false);
	}

	// Token: 0x060016DA RID: 5850 RVA: 0x0007E7C4 File Offset: 0x0007C9C4
	private void Start()
	{
		this.reticles.Add(UberstrikeItemClass.WeaponMelee, this.melee);
		this.reticles.Add(UberstrikeItemClass.WeaponMachinegun, this.machinegun);
		this.reticles.Add(UberstrikeItemClass.WeaponShotgun, this.shotgun);
		this.reticles.Add(UberstrikeItemClass.WeaponSplattergun, this.splattergun);
		this.reticles.Add(UberstrikeItemClass.WeaponCannon, this.cannon);
		this.reticles.Add(UberstrikeItemClass.WeaponLauncher, this.launcher);
		this.reticles.Add(UberstrikeItemClass.WeaponSniperRifle, this.sniper);
		GameState.Current.PlayerData.ActiveWeapon.AddEventAndFire(delegate(WeaponSlot el)
		{
			if (el == null)
			{
				return;
			}
			this.EnableReticle(false);
			this.activeReticleId = el.View.ItemClass;
			this.EnableReticle(this.activeReticleId != UberstrikeItemClass.WeaponSniperRifle || el.View.CustomProperties.ContainsKey("ShowReticleForSniper"));
			this.zoomInView.Show(false);
		}, this);
		GameState.Current.PlayerData.WeaponFired.AddEvent(delegate(WeaponSlot el)
		{
			if (this.ActiveReticle != null)
			{
				this.ActiveReticle.Shoot();
			}
		}, this);
		GameState.Current.PlayerData.FocusedPlayerTeam.AddEvent(delegate(TeamID el)
		{
			if (GameState.Current.IsTeamGame && el == GameState.Current.PlayerData.Player.TeamID)
			{
				this.UpdateColorForState(HUDReticleController.State.Friend);
				return;
			}
			this.UpdateColorForState((!this.isDisplayingEnemyReticle) ? HUDReticleController.State.None : HUDReticleController.State.Enemy);
		}, this);
		GameState.Current.PlayerData.AppliedDamage.AddEvent(delegate(DamageInfo el)
		{
			this.isDisplayingEnemyReticle = true;
			this.enemyReticleElapsedTime = Time.time + 1f;
		}, this);
		GameState.Current.PlayerData.IsIronSighted.AddEvent(delegate(bool el)
		{
			if (this.IsSecondaryReticle)
			{
				this.EnableReticle(!el);
			}
		}, this);
		GameState.Current.PlayerData.IsZoomedIn.AddEvent(delegate(bool el)
		{
			this.zoomInView.Show(el && this.IsSecondaryReticle);
		}, this);
	}

	// Token: 0x060016DB RID: 5851 RVA: 0x0000F606 File Offset: 0x0000D806
	public void EnableReticle(bool isEnabled)
	{
		if (this.ActiveReticle != null)
		{
			this.ActiveReticle.gameObject.SetActive(isEnabled);
		}
	}

	// Token: 0x060016DC RID: 5852 RVA: 0x0007E918 File Offset: 0x0007CB18
	private void UpdateColorForState(HUDReticleController.State newState)
	{
		Color color;
		if (newState != HUDReticleController.State.Enemy)
		{
			if (newState != HUDReticleController.State.Friend)
			{
				color = Color.white;
			}
			else
			{
				color = Color.green;
			}
		}
		else
		{
			color = Color.red;
		}
		if (this.ActiveReticle != null)
		{
			this.ActiveReticle.SetColor(color);
		}
	}

	// Token: 0x060016DD RID: 5853 RVA: 0x0000F62A File Offset: 0x0000D82A
	private void Update()
	{
		if (this.isDisplayingEnemyReticle && Time.time > this.enemyReticleElapsedTime)
		{
			this.isDisplayingEnemyReticle = false;
		}
	}

	// Token: 0x040015D0 RID: 5584
	[SerializeField]
	private ReticleView melee;

	// Token: 0x040015D1 RID: 5585
	[SerializeField]
	private ReticleView machinegun;

	// Token: 0x040015D2 RID: 5586
	[SerializeField]
	private ReticleView shotgun;

	// Token: 0x040015D3 RID: 5587
	[SerializeField]
	private ReticleView splattergun;

	// Token: 0x040015D4 RID: 5588
	[SerializeField]
	private ReticleView cannon;

	// Token: 0x040015D5 RID: 5589
	[SerializeField]
	private ReticleView launcher;

	// Token: 0x040015D6 RID: 5590
	[SerializeField]
	private ReticleView sniper;

	// Token: 0x040015D7 RID: 5591
	[SerializeField]
	private ZoomInView zoomInView;

	// Token: 0x040015D8 RID: 5592
	private UberstrikeItemClass activeReticleId;

	// Token: 0x040015D9 RID: 5593
	private bool isDisplayingEnemyReticle;

	// Token: 0x040015DA RID: 5594
	private float enemyReticleElapsedTime;

	// Token: 0x040015DB RID: 5595
	private Dictionary<UberstrikeItemClass, ReticleView> reticles = new Dictionary<UberstrikeItemClass, ReticleView>();

	// Token: 0x02000335 RID: 821
	public enum State
	{
		// Token: 0x040015DD RID: 5597
		None,
		// Token: 0x040015DE RID: 5598
		Enemy,
		// Token: 0x040015DF RID: 5599
		Friend
	}
}
