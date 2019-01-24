using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class MuzzleHeatWave : BaseWeaponEffect
{
	// Token: 0x06001E87 RID: 7815 RVA: 0x00095854 File Offset: 0x00093A54
	private void Awake()
	{
		this._transform = base.transform;
		this._renderer = base.renderer;
		if (this._renderer == null)
		{
			throw new Exception("No Renderer attached to HeatWave script on GameObject " + base.gameObject.name);
		}
	}

	// Token: 0x06001E88 RID: 7816 RVA: 0x000142F2 File Offset: 0x000124F2
	private void Start()
	{
		this._renderer.enabled = false;
		base.enabled = false;
	}

	// Token: 0x06001E89 RID: 7817 RVA: 0x000958A8 File Offset: 0x00093AA8
	private void Update()
	{
		if (this._transform && this._renderer)
		{
			this._elapsedTime += Time.deltaTime;
			this._normalizedTime = this._elapsedTime / this._duration;
			this._s = Mathf.Lerp(this._startSize, this._maxSize, this._normalizedTime);
			this._renderer.material.SetFloat("_BumpAmt", (1f - this._normalizedTime) * this._distortion);
			this._transform.localScale = new Vector3(this._s, this._s, this._s);
			this._transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - this._transform.position);
			if (this._elapsedTime > this._duration)
			{
				this._transform.localScale = new Vector3(0f, 0f, 0f);
				this._renderer.enabled = false;
				base.enabled = false;
			}
		}
	}

	// Token: 0x06001E8A RID: 7818 RVA: 0x000959D4 File Offset: 0x00093BD4
	public override void OnShoot()
	{
		if (SystemInfo.supportsImageEffects)
		{
			this._elapsedTime = 0f;
			this._transform.rotation = Quaternion.FromToRotation(Vector3.up, Camera.main.transform.position - this._transform.position);
			this._renderer.enabled = true;
			base.enabled = true;
		}
	}

	// Token: 0x06001E8B RID: 7819 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001E8C RID: 7820 RVA: 0x00014307 File Offset: 0x00012507
	public override void Hide()
	{
		if (!this._renderer)
		{
			this._renderer = base.renderer;
		}
		if (this._renderer)
		{
			this._renderer.enabled = false;
		}
	}

	// Token: 0x06001E8D RID: 7821 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x04001A68 RID: 6760
	[SerializeField]
	private float _startSize;

	// Token: 0x04001A69 RID: 6761
	[SerializeField]
	private float _maxSize = 0.05f;

	// Token: 0x04001A6A RID: 6762
	[SerializeField]
	private float _duration = 0.25f;

	// Token: 0x04001A6B RID: 6763
	[SerializeField]
	private float _distortion = 64f;

	// Token: 0x04001A6C RID: 6764
	private Transform _transform;

	// Token: 0x04001A6D RID: 6765
	private Renderer _renderer;

	// Token: 0x04001A6E RID: 6766
	private float _elapsedTime;

	// Token: 0x04001A6F RID: 6767
	private float _normalizedTime;

	// Token: 0x04001A70 RID: 6768
	private float _s;
}
