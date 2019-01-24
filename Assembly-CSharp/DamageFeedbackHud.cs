using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000238 RID: 568
public class DamageFeedbackHud : Singleton<DamageFeedbackHud>
{
	// Token: 0x06000FA6 RID: 4006 RVA: 0x0000B0BE File Offset: 0x000092BE
	private DamageFeedbackHud()
	{
		this._damageFeedbackMarkList = new List<DamageFeedbackHud.DamageFeedbackMark>();
		this.Enabled = true;
	}

	// Token: 0x06000FA7 RID: 4007 RVA: 0x00065330 File Offset: 0x00063530
	public void Draw()
	{
		if (!this.Enabled)
		{
			return;
		}
		for (int i = 0; i < this._damageFeedbackMarkList.Count; i++)
		{
			float num = this._damageFeedbackMarkList[i].DamageDirection;
			Vector3 vector = Quaternion.AngleAxis(-num, Vector3.up) * Vector3.back;
			vector = Camera.main.transform.InverseTransformDirection(vector);
			num = Quaternion.LookRotation(vector).eulerAngles.y;
			GUIUtility.RotateAroundPivot(num, new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f));
			GUI.color = new Color(0.975f, 0.201f, 0.135f, this._damageFeedbackMarkList[i].DamageAlpha);
			int num2 = Mathf.RoundToInt(128f * this._damageFeedbackMarkList[i].DamageAmount);
			GUI.DrawTexture(new Rect((float)Screen.width * 0.5f - (float)num2 * 0.5f, (float)Screen.height * 0.5f - 256f, (float)num2, 128f), HudTextures.DamageFeedbackMark);
			GUI.matrix = Matrix4x4.identity;
		}
		GUI.color = Color.white;
	}

	// Token: 0x06000FA8 RID: 4008 RVA: 0x00065474 File Offset: 0x00063674
	public void Update()
	{
		if (this._damageFeedbackMarkList.Count > 0)
		{
			for (int i = 0; i < this._damageFeedbackMarkList.Count; i++)
			{
				if (this._damageFeedbackMarkList[i].DamageAlpha < 0f)
				{
					this._damageFeedbackMarkList.RemoveAt(i);
				}
			}
			for (int j = 0; j < this._damageFeedbackMarkList.Count; j++)
			{
				this._damageFeedbackMarkList[j].DamageAlpha -= Time.deltaTime * 0.5f;
			}
		}
	}

	// Token: 0x06000FA9 RID: 4009 RVA: 0x0000B0D8 File Offset: 0x000092D8
	public void AddDamageMark(float normalizedDamage, float horizontalAngle)
	{
		this._damageFeedbackMarkList.Add(new DamageFeedbackHud.DamageFeedbackMark(normalizedDamage, horizontalAngle));
		LevelCamera.DoFeedback(LevelCamera.FeedbackType.GetDamage, Vector3.back, 0.1f, normalizedDamage, 0.04f, 0.08f, 10f, Vector3.forward);
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x0000B111 File Offset: 0x00009311
	public void ClearAll()
	{
		this._damageFeedbackMarkList.Clear();
	}

	// Token: 0x170003A8 RID: 936
	// (get) Token: 0x06000FAB RID: 4011 RVA: 0x0000B11E File Offset: 0x0000931E
	// (set) Token: 0x06000FAC RID: 4012 RVA: 0x0000B126 File Offset: 0x00009326
	public bool Enabled { get; set; }

	// Token: 0x04000DB9 RID: 3513
	private const float PEAKTIME = 0.04f;

	// Token: 0x04000DBA RID: 3514
	private const float ENDTIME = 0.08f;

	// Token: 0x04000DBB RID: 3515
	private List<DamageFeedbackHud.DamageFeedbackMark> _damageFeedbackMarkList;

	// Token: 0x02000239 RID: 569
	public class DamageFeedbackMark
	{
		// Token: 0x06000FAD RID: 4013 RVA: 0x0000B12F File Offset: 0x0000932F
		public DamageFeedbackMark(float normalizedDamage, float horizontalAngle)
		{
			this.DamageAlpha = 1f;
			this.DamageAmount = normalizedDamage;
			this.DamageDirection = horizontalAngle;
		}

		// Token: 0x04000DBD RID: 3517
		public float DamageAlpha;

		// Token: 0x04000DBE RID: 3518
		public float DamageAmount;

		// Token: 0x04000DBF RID: 3519
		public float DamageDirection;
	}
}
