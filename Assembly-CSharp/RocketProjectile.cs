using System;
using UnityEngine;

// Token: 0x0200044E RID: 1102
public class RocketProjectile : Projectile
{
	// Token: 0x170006B0 RID: 1712
	// (get) Token: 0x06001F67 RID: 8039 RVA: 0x00014B2F File Offset: 0x00012D2F
	// (set) Token: 0x06001F68 RID: 8040 RVA: 0x00014B37 File Offset: 0x00012D37
	public Color SmokeColor
	{
		get
		{
			return this._smokeColor;
		}
		set
		{
			this._smokeColor = value;
			if (this._smokeRenderer)
			{
				this._smokeRenderer.material.SetColor("_TintColor", this._smokeColor);
			}
		}
	}

	// Token: 0x170006B1 RID: 1713
	// (get) Token: 0x06001F69 RID: 8041 RVA: 0x00014B6B File Offset: 0x00012D6B
	// (set) Token: 0x06001F6A RID: 8042 RVA: 0x00096B6C File Offset: 0x00094D6C
	public float SmokeAmount
	{
		get
		{
			return this._smokeAmount;
		}
		set
		{
			this._smokeAmount = value;
			if (this._smokeEmitter)
			{
				this._smokeEmitter.minEmission = this._smokeAmount * 10f;
				this._smokeEmitter.maxEmission = this._smokeAmount * 20f;
			}
		}
	}

	// Token: 0x06001F6B RID: 8043 RVA: 0x00096BC0 File Offset: 0x00094DC0
	protected override void Awake()
	{
		base.Awake();
		this.SmokeColor = this._smokeColor;
		this.SmokeAmount = this._smokeAmount;
		if (this._light != null)
		{
			this._light.enabled = Application.isWebPlayer;
		}
	}

	// Token: 0x06001F6C RID: 8044 RVA: 0x00096C0C File Offset: 0x00094E0C
	protected override void OnTriggerEnter(Collider c)
	{
		if (!base.IsProjectileExploded && LayerUtil.IsLayerInMask(base.CollisionMask, c.gameObject.layer))
		{
			Singleton<ProjectileManager>.Instance.RemoveProjectile(this.ID, true);
			GameState.Current.Actions.RemoveProjectile(this.ID, true);
		}
	}

	// Token: 0x06001F6D RID: 8045 RVA: 0x00096C6C File Offset: 0x00094E6C
	protected override void OnCollisionEnter(Collision c)
	{
		if (!base.IsProjectileExploded && c.gameObject && LayerUtil.IsLayerInMask(base.CollisionMask, c.gameObject.layer))
		{
			Singleton<ProjectileManager>.Instance.RemoveProjectile(this.ID, true);
			GameState.Current.Actions.RemoveProjectile(this.ID, true);
		}
	}

	// Token: 0x04001AC3 RID: 6851
	[SerializeField]
	private ParticleRenderer _smokeRenderer;

	// Token: 0x04001AC4 RID: 6852
	[SerializeField]
	private ParticleEmitter _smokeEmitter;

	// Token: 0x04001AC5 RID: 6853
	[SerializeField]
	private Color _smokeColor = Color.white;

	// Token: 0x04001AC6 RID: 6854
	[SerializeField]
	private float _smokeAmount = 1f;

	// Token: 0x04001AC7 RID: 6855
	[SerializeField]
	private Light _light;
}
