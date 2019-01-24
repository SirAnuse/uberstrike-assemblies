using System;
using UnityEngine;

// Token: 0x020003A1 RID: 929
public class SkyManager : MonoBehaviour
{
	// Token: 0x1700061A RID: 1562
	// (get) Token: 0x06001B6A RID: 7018 RVA: 0x00012278 File Offset: 0x00010478
	// (set) Token: 0x06001B6B RID: 7019 RVA: 0x00012280 File Offset: 0x00010480
	public float DayNightCycle
	{
		get
		{
			return this._dayNightCycle;
		}
		set
		{
			this._dayNightCycle = value;
		}
	}

	// Token: 0x1700061B RID: 1563
	// (get) Token: 0x06001B6C RID: 7020 RVA: 0x00012289 File Offset: 0x00010489
	// (set) Token: 0x06001B6D RID: 7021 RVA: 0x00012291 File Offset: 0x00010491
	public float CloudXAxisRot
	{
		get
		{
			return this._cloudXAxisRot;
		}
		set
		{
			this._cloudXAxisRot = value;
		}
	}

	// Token: 0x1700061C RID: 1564
	// (get) Token: 0x06001B6E RID: 7022 RVA: 0x0001229A File Offset: 0x0001049A
	// (set) Token: 0x06001B6F RID: 7023 RVA: 0x000122A2 File Offset: 0x000104A2
	public float CloudYAxisRot
	{
		get
		{
			return this._cloudYAxisRot;
		}
		set
		{
			this._cloudYAxisRot = value;
		}
	}

	// Token: 0x06001B70 RID: 7024 RVA: 0x000122AB File Offset: 0x000104AB
	private void OnEnable()
	{
		this._skyMaterial = new Material(base.renderer.material);
	}

	// Token: 0x06001B71 RID: 7025 RVA: 0x000122C3 File Offset: 0x000104C3
	private void OnDisable()
	{
		base.renderer.material = this._skyMaterial;
	}

	// Token: 0x06001B72 RID: 7026 RVA: 0x0008D124 File Offset: 0x0008B324
	private void Update()
	{
		this._dayCloudMoveVector.x = this._dayCloudMoveVector.x + Time.deltaTime * this._cloudXAxisRot;
		this._dayCloudHorizonMoveVector.y = this._dayCloudHorizonMoveVector.y + Time.deltaTime * this._cloudYAxisRot;
		if (this._dayCloudMoveVector.x > 1f)
		{
			this._dayCloudMoveVector.x = 0f;
			if (this._cloudXAxisRot > 0.008f)
			{
				this._cloudXAxisRotIndex = -0.001f;
			}
			if (this._cloudXAxisRot < 0.002f)
			{
				this._cloudXAxisRotIndex = 0.001f;
			}
			this._cloudXAxisRot += this._cloudXAxisRotIndex;
		}
		if (this._dayCloudHorizonMoveVector.y > 1f)
		{
			this._dayCloudHorizonMoveVector.y = 0f;
			if (this._cloudYAxisRot > 0.008f)
			{
				this._cloudYAxisRotIndex = -0.001f;
			}
			if (this._cloudYAxisRot < 0.002f)
			{
				this._cloudYAxisRotIndex = 0.001f;
			}
			this._cloudYAxisRot += this._cloudYAxisRotIndex;
		}
		base.renderer.material.SetTextureOffset("_DayCloudTex", this._dayCloudMoveVector);
		base.renderer.material.SetTextureOffset("_NightCloudTex", this._dayCloudHorizonMoveVector);
		this._dayNightCycle = Mathf.Clamp01(this._dayNightCycle);
		base.renderer.material.SetFloat("_DayNightCycle", Mathf.Clamp01(this._dayNightCycle));
		this._sunsetOffset = Mathf.Clamp01(this._sunsetOffset);
		base.renderer.material.SetFloat("_SunsetOffset", Mathf.Clamp01(this._sunsetOffset));
		this._sunsetVisibility = Mathf.Clamp01(this._sunsetVisibility);
		base.renderer.material.SetFloat("_SunsetVisibility", this._sunsetVisibility);
		base.renderer.material.SetColor("_HorizonColor", this._horizonColor);
		base.renderer.material.SetColor("_DaySkyColor", this._daySkyColor);
		base.renderer.material.SetColor("_SunSetColor", this._sunsetColor);
	}

	// Token: 0x0400186E RID: 6254
	[SerializeField]
	private float _dayNightCycle;

	// Token: 0x0400186F RID: 6255
	[SerializeField]
	private float _sunsetOffset;

	// Token: 0x04001870 RID: 6256
	[SerializeField]
	private float _sunsetVisibility;

	// Token: 0x04001871 RID: 6257
	[SerializeField]
	private Color _daySkyColor;

	// Token: 0x04001872 RID: 6258
	[SerializeField]
	private Color _horizonColor;

	// Token: 0x04001873 RID: 6259
	[SerializeField]
	private Color _sunsetColor;

	// Token: 0x04001874 RID: 6260
	private Vector2 _dayCloudMoveVector = new Vector2(0f, 0f);

	// Token: 0x04001875 RID: 6261
	private Vector2 _dayCloudHorizonMoveVector = new Vector2(0f, 0f);

	// Token: 0x04001876 RID: 6262
	private float _cloudXAxisRot = 0.005f;

	// Token: 0x04001877 RID: 6263
	private float _cloudYAxisRot = 0.005f;

	// Token: 0x04001878 RID: 6264
	private float _cloudXAxisRotIndex = 0.001f;

	// Token: 0x04001879 RID: 6265
	private float _cloudYAxisRotIndex = 0.001f;

	// Token: 0x0400187A RID: 6266
	private Material _skyMaterial;
}
