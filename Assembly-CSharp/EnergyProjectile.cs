using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000449 RID: 1097
public class EnergyProjectile : Projectile
{
	// Token: 0x170006A2 RID: 1698
	// (get) Token: 0x06001F33 RID: 7987 RVA: 0x0001494C File Offset: 0x00012B4C
	// (set) Token: 0x06001F34 RID: 7988 RVA: 0x00014954 File Offset: 0x00012B54
	public Color EnergyColor
	{
		get
		{
			return this._energyColor;
		}
		set
		{
			this._energyColor = value;
			this._headRenderer.material.SetColor("_TintColor", this._energyColor);
			this._trailRenderer.material.SetColor("_TintColor", this._energyColor);
		}
	}

	// Token: 0x170006A3 RID: 1699
	// (get) Token: 0x06001F35 RID: 7989 RVA: 0x00014993 File Offset: 0x00012B93
	// (set) Token: 0x06001F36 RID: 7990 RVA: 0x0001499B File Offset: 0x00012B9B
	public float AfterGlowDuration
	{
		get
		{
			return this._afterGlowDuration;
		}
		set
		{
			this._afterGlowDuration = value;
		}
	}

	// Token: 0x06001F37 RID: 7991 RVA: 0x000149A4 File Offset: 0x00012BA4
	protected override void Awake()
	{
		base.Awake();
		if (this._light != null)
		{
			this._light.enabled = Application.isWebPlayer;
		}
	}

	// Token: 0x06001F38 RID: 7992 RVA: 0x000149CD File Offset: 0x00012BCD
	protected override void OnTriggerEnter(Collider c)
	{
		if (!base.IsProjectileExploded && LayerUtil.IsLayerInMask(base.CollisionMask, c.gameObject.layer))
		{
			this.Explode();
		}
	}

	// Token: 0x06001F39 RID: 7993 RVA: 0x00096438 File Offset: 0x00094638
	protected override void OnCollisionEnter(Collision c)
	{
		if (!base.IsProjectileExploded && LayerUtil.IsLayerInMask(base.CollisionMask, c.gameObject.layer))
		{
			if (c.contacts.Length > 0)
			{
				base.Explode(c.contacts[0].point, c.contacts[0].normal, TagUtil.GetTag(c.collider));
			}
			else
			{
				this.Explode();
			}
		}
	}

	// Token: 0x06001F3A RID: 7994 RVA: 0x000964B8 File Offset: 0x000946B8
	protected override IEnumerator StartTimeout()
	{
		yield return new WaitForSeconds((base.TimeOut <= 0f) ? 30f : base.TimeOut);
		this.Explode();
		yield break;
	}

	// Token: 0x04001AA8 RID: 6824
	[SerializeField]
	private MeshRenderer _trailRenderer;

	// Token: 0x04001AA9 RID: 6825
	[SerializeField]
	private MeshRenderer _headRenderer;

	// Token: 0x04001AAA RID: 6826
	[SerializeField]
	private Light _light;

	// Token: 0x04001AAB RID: 6827
	[SerializeField]
	private Color _energyColor = Color.white;

	// Token: 0x04001AAC RID: 6828
	[SerializeField]
	private float _afterGlowDuration = 2f;
}
