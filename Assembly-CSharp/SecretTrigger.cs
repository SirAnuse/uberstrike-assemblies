using System;
using UnityEngine;

// Token: 0x0200028B RID: 651
[RequireComponent(typeof(BoxCollider))]
public class SecretTrigger : BaseGameProp
{
	// Token: 0x060011F8 RID: 4600 RVA: 0x0000C564 File Offset: 0x0000A764
	private void Awake()
	{
		base.gameObject.layer = 21;
	}

	// Token: 0x060011F9 RID: 4601 RVA: 0x0006A56C File Offset: 0x0006876C
	private void OnDisable()
	{
		foreach (Renderer renderer in this._visuals)
		{
			renderer.material.SetColor("_Color", Color.black);
		}
	}

	// Token: 0x060011FA RID: 4602 RVA: 0x0006A5B0 File Offset: 0x000687B0
	private void Update()
	{
		if (this._showVisualsEndTime > Time.time)
		{
			foreach (Renderer renderer in this._visuals)
			{
				renderer.material.SetColor("_Color", new Color((Mathf.Sin(Time.time * 4f) + 1f) * 0.3f, 0f, 0f));
			}
		}
		else
		{
			base.enabled = false;
		}
	}

	// Token: 0x060011FB RID: 4603 RVA: 0x0006A634 File Offset: 0x00068834
	public override void ApplyDamage(DamageInfo shot)
	{
		if (this._reciever)
		{
			base.enabled = true;
			this._showVisualsEndTime = Time.time + this._activationTime;
			this._reciever.SetTriggerActivated(this);
		}
		else
		{
			Debug.LogError("The SecretTrigger " + base.gameObject.name + " is not assigned to a SecretReciever!");
		}
	}

	// Token: 0x060011FC RID: 4604 RVA: 0x0000C729 File Offset: 0x0000A929
	public void SetSecretReciever(SecretBehaviour logic)
	{
		this._reciever = logic;
	}

	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x060011FD RID: 4605 RVA: 0x0000C732 File Offset: 0x0000A932
	public float ActivationTimeOut
	{
		get
		{
			return this._showVisualsEndTime;
		}
	}

	// Token: 0x04000EE2 RID: 3810
	[SerializeField]
	private Renderer[] _visuals;

	// Token: 0x04000EE3 RID: 3811
	[SerializeField]
	private float _activationTime = 15f;

	// Token: 0x04000EE4 RID: 3812
	private SecretBehaviour _reciever;

	// Token: 0x04000EE5 RID: 3813
	private float _showVisualsEndTime;
}
